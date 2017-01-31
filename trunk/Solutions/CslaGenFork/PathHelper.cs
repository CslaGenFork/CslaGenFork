using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CslaGenerator
{
    public static class PathHelper
    {
        private static readonly string Separator = System.IO.Path.DirectorySeparatorChar.ToString();

        private static readonly string DrivePathValidator =
            string.Format(@"^(?:[a-zA-Z]\:\{0})(?:[^\{0}\/\:\*\?\{1}\<\>\|]*\{0})*(?:[^\{0}\/\:\*\?\{1}\<\>\|]*)+$",
                Separator, '"');

        private static readonly string RelativePathValidator =
            string.Format(
                @"^(?:\.\{0}|\.\.\{0})(?:\.\.\{0})*(?:[^\{0}\/\:\*\?\{1}\<\>\|]+\{0})*(?:[^\{0}\/\:\*\?\{1}\<\>\|]*)+$",
                Separator, '"');

        public static string GetCurrentFilePath
        {
            get { return GeneratorController.Current.CurrentFilePath; }
        }

        public static string GetCurrentDirectory
        {
            get { return Environment.CurrentDirectory; }
        }

        public static string GetStartupPath
        {
            get { return Application.StartupPath; }
        }

        public static bool IsValidDrivePath(this string path)
        {
            return Regex.IsMatch(path, DrivePathValidator);
        }

        public static bool IsValidRelativePath(this string path)
        {
            return Regex.IsMatch(path, RelativePathValidator);
        }

        public static int StripRelativePath(ref string path)
        {
            var downLevels = 0;

            while (StripRelativePathSingleLevel(ref path))
            {
                downLevels++;
            }

            return downLevels;
        }

        public static string StripEndSeparator(this string path)
        {
            if (path.EndsWith(Separator))
                return path.Substring(0, path.Length - 1);

            return path;
        }

        private static bool StripRelativePathSingleLevel(ref string path)
        {
            if (path.StartsWith(string.Format("..{0}", Separator)))
            {
                path = path.Substring(3, path.Length - 3);

                return true;
            }

            if (path == "..")
            {
                path = path.Substring(2, path.Length - 2);

                return true;
            }

            if (path.StartsWith(string.Format(".{0}", Separator)))
                path = path.Substring(2, path.Length - 2);

            if (path == ".")
                path = path.Substring(1, path.Length - 1);

            return false;
        }

        public static string GetPathDown(this string path, int levels)
        {
            for (var level = 0; level < levels; level++)
            {
                path = path.GetPathDownOneFolder();
            }

            return path;
        }

        private static string GetPathDownOneFolder(this string path)
        {
            var previousFolder = path.LastIndexOf(Separator, StringComparison.InvariantCulture);
            return path.Substring(0, previousFolder);
        }

        public static string GetComposedPath(string startPath, params string[] parts)
        {
            var fullPath = startPath;
            foreach (var part in parts)
            {
                if (part != string.Empty)
                    fullPath += Separator + part;
            }

            return fullPath;
        }
    }
}