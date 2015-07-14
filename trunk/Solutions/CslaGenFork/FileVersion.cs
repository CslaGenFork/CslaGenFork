using System;

namespace CslaGenerator
{
	internal class FileVersion
	{
		internal const string CurrentFileVersion = "4.0.3";
		internal static string FileVersionFound;

		internal static string ExtractFileVersion(string[] fileLines)
		{
			var fileVersion = string.Empty;
			foreach (var line in fileLines)
			{
				var lineStart = line.IndexOf(@"<FileVersion>");
				if (lineStart != -1)
				{
					lineStart += 13;
					var length = line.IndexOf(@"</FileVersion>") - lineStart;
					fileVersion = line.Substring(lineStart, length);
					break;
				}
			}

			FileVersionFound = fileVersion;
			return fileVersion;
		}

		internal static int ConvertDotFileVersionToInt(string fileVersion)
		{
			var noDotsFileVersion = fileVersion.Replace(".", string.Empty);
			int convertedFileVersion;
			try
			{
				convertedFileVersion = Convert.ToInt32(noDotsFileVersion);
			}
			catch (Exception)
			{
				return 0;
			}

			return convertedFileVersion;
		}

		internal static string[] HandleFileVersion(int intFileVersion, string[] fileLines)
		{
			if (intFileVersion < 403)
				return ConvertFrom402To403(fileLines);

			return fileLines;
		}

		internal static string[] ConvertFrom402To403(string[] fileLines)
		{
			for (var index = 0; index < fileLines.Length; index++)
			{
				fileLines[index] = fileLines[index].Replace(@"<RelationType>MultipleToMultiple</RelationType>",
					@"<RelationType>ManyToMany</RelationType>");
				fileLines[index] = fileLines[index].Replace(@"<RelationType>OneToMultiple</RelationType>",
					@"<RelationType>OneToMany</RelationType>");
				fileLines[index] = fileLines[index].Replace(@"<FileVersion>" + FileVersionFound + "</FileVersion>",
					@"<FileVersion>4.0.3</FileVersion>");
			}
			return fileLines;
		}
	}
}