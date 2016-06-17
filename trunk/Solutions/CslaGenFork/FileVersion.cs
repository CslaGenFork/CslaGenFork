using System;

namespace CslaGenerator
{
    internal class FileVersion
    {
        internal const string CurrentFileVersion = "4.0.4";
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
                return ConvertFrom403To404(ConvertFrom402To403(fileLines));

            if (intFileVersion < 404)
                return ConvertFrom403To404(fileLines);

            return fileLines;
        }

        internal static string[] ConvertFrom402To403(string[] fileLines)
        {
            var newFileVersion = "4.0.3";
            for (var index = 0; index < fileLines.Length; index++)
            {
                fileLines[index] = fileLines[index].Replace(@"<RelationType>MultipleToMultiple</RelationType>",
                    @"<RelationType>ManyToMany</RelationType>");
                fileLines[index] = fileLines[index].Replace(@"<RelationType>OneToMultiple</RelationType>",
                    @"<RelationType>OneToMany</RelationType>");
                fileLines[index] = fileLines[index].Replace(@"<FileVersion>" + FileVersionFound + "</FileVersion>",
                    @"<FileVersion>" + newFileVersion + "</FileVersion>");
                FileVersionFound = newFileVersion;
            }
            return fileLines;
        }

        internal static string[] ConvertFrom403To404(string[] fileLines)
        {
            var newFileVersion = "4.0.4";
            for (var index = 0; index < fileLines.Length; index++)
            {
                fileLines[index] = fileLines[index].Replace(@"<TargetFramework>CSLA10</TargetFramework>",
                    @"<TargetFramework>CSLA40</TargetFramework>");
                fileLines[index] = fileLines[index].Replace(@"<TargetFramework>CSLA20</TargetFramework>",
                    @"<TargetFramework>CSLA40</TargetFramework>");
                fileLines[index] = fileLines[index].Replace(@"<TargetFramework>CSLA35</TargetFramework>",
                    @"<TargetFramework>CSLA40</TargetFramework>");
                fileLines[index] = fileLines[index].Replace(@"<FileVersion>" + FileVersionFound + "</FileVersion>",
                    @"<FileVersion>" + newFileVersion + "</FileVersion>");
                FileVersionFound = newFileVersion;
            }
            return fileLines;
        }
    }
}