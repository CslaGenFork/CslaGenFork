using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace CslaGenerator
{
    internal static class VersionHelper
    {
        internal const string CurrentFileVersion = "4.0.6";
        private static string[] FileLines { get; set; }
        private static string _fileVersionFound;
        private static bool _forceSave;

        public static void WriteAllLinesBetter(string path, params string[] lines)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            if (lines == null)
                throw new ArgumentNullException("lines");

            using (var stream = File.OpenWrite(path))
            {
                stream.SetLength(0);
                using (var writer = new StreamWriter(stream))
                {
                    if (lines.Length > 0)
                    {
                        for (var i = 0; i < lines.Length - 1; i++)
                        {
                            writer.WriteLine(lines[i]);
                        }
                        writer.Write(lines[lines.Length - 1]);
                    }
                }
            }
        }

        internal static bool SolveVersionNumberIssues(string filePath, Exception previousException)
        {
            FileLines = File.ReadAllLines(filePath);
            var fileVersion = ExtractFileVersion();

            if (fileVersion == CurrentFileVersion)
                throw previousException;

            var numericFileVersion = GetNumericFileVersion(fileVersion);
            HandleFileVersion(numericFileVersion);
            WriteAllLinesBetter(filePath, FileLines);

            return _forceSave;
        }

        internal static string ExtractFileVersion()
        {
            var fileVersion = String.Empty;
            foreach (var line in FileLines)
            {
                var lineStart = line.IndexOf(@"<FileVersion>", StringComparison.InvariantCulture);
                if (lineStart != -1)
                {
                    lineStart += 13;
                    var length = line.IndexOf(@"</FileVersion>", StringComparison.InvariantCulture) - lineStart;
                    fileVersion = line.Substring(lineStart, length);
                    break;
                }
            }

            _fileVersionFound = fileVersion;
            return fileVersion;
        }

        internal static int GetNumericFileVersion(string fileVersion)
        {
            var noDotsFileVersion = fileVersion.Replace(".", String.Empty);
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

        internal static void HandleFileVersion(int numericFileVersion)
        {
            if (numericFileVersion == 0)
                InsertFileVersionZero();

            if (numericFileVersion < 403)
                ConvertPre403();

            if (numericFileVersion < 404)
                Convert403To404();

            if (numericFileVersion < 405)
                Convert404To405();

            if (numericFileVersion < 406)
                Convert405To406();
        }

        private static void InsertFileVersionZero()
        {
            var newFileVersion = "0.0.0";
            var replaceString = @"<FileVersion>" + newFileVersion + "</FileVersion>";

            var fileVersionPosition = FileLines.Length - 3;
            if (FileLines[fileVersionPosition].Contains("<FileVersion />"))
            {
                FileLines[fileVersionPosition] = FileLines[fileVersionPosition].Replace(@"<FileVersion />",
                    replaceString);
            }
            else
            {
                var fileLinesList = FileLines.ToList();
                fileLinesList.Add(String.Empty);
                FileLines = fileLinesList.ToArray();
                fileVersionPosition = FileLines.Length - 2; // recalculate on the new array
                FileLines[fileVersionPosition + 1] = FileLines[fileVersionPosition];
                FileLines[fileVersionPosition] = "  " + replaceString;
            }

            _fileVersionFound = newFileVersion;
        }

        private static void ConvertPre403()
        {
            var newFileVersion = "4.0.3";
            for (var index = 0; index < FileLines.Length; index++)
            {
                FileLines[index] = FileLines[index].Replace(@"<RelationType>MultipleToMultiple</RelationType>",
                    @"<RelationType>ManyToMany</RelationType>");
                FileLines[index] = FileLines[index].Replace(@"<RelationType>OneToMultiple</RelationType>",
                    @"<RelationType>OneToMany</RelationType>");
                FileLines[index] = FileLines[index].Replace(@"<FileVersion>" + _fileVersionFound + "</FileVersion>",
                    @"<FileVersion>" + newFileVersion + "</FileVersion>");
            }

            _fileVersionFound = newFileVersion;
        }

        private static void Convert403To404()
        {
            var newFileVersion = "4.0.4";
            for (var index = 0; index < FileLines.Length; index++)
            {
                FileLines[index] = FileLines[index].Replace(@"<Implements />", @"<Interfaces />");
                FileLines[index] = FileLines[index].Replace(@"<Implements>", @"<Interfaces>");
                FileLines[index] = FileLines[index].Replace(@"</Implements>", @"</Interfaces>");
                FileLines[index] = FileLines[index].Replace(@"<FileVersion>" + _fileVersionFound + "</FileVersion>",
                    @"<FileVersion>" + newFileVersion + "</FileVersion>");
            }

            _fileVersionFound = newFileVersion;
        }

        private static void Convert404To405()
        {
            var newFileVersion = "4.0.5";
            for (var index = 0; index < FileLines.Length; index++)
            {
                FileLines[index] = FileLines[index].Replace(@"<PropSetAccessibility>NoSetter</PropSetAccessibility>",
                    @"<PropSetAccessibility>Default</PropSetAccessibility>");
                FileLines[index] = FileLines[index].Replace(@"<FileVersion>" + _fileVersionFound + "</FileVersion>",
                    @"<FileVersion>" + newFileVersion + "</FileVersion>");
            }

            _fileVersionFound = newFileVersion;
        }

        private static void Convert405To406()
        {
            var newFileVersion = "4.0.6";

            var xmlFile = string.Empty;
            for (var index = 1; index < FileLines.Length; index++)
            {
                var line = FileLines[index];
                xmlFile += line;
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.PreserveWhitespace = true;
            xDoc.LoadXml(xmlFile);
            XmlElement root = xDoc.DocumentElement;

            XmlNodeList cslaObjects = root.SelectNodes("//CslaObjects");
            if (cslaObjects != null)
            {
                foreach (XmlNode cslaObject in cslaObjects)
                {
                    XmlNodeList parameters = cslaObject.SelectNodes("//LoadParameters/Parameter");
                    if (parameters != null)
                    {
                        for (var index = 0; index < parameters.Count; index++)
                        {
                            XmlNode newParameter = HandleParameter(xDoc, parameters[index]);
                            XmlNode parentNode = parameters[index].ParentNode;
                            parameters[index].ParentNode.RemoveChild(parameters[index]);
                            parentNode.AppendChild(newParameter);
                        }
                    }
                }
            }

            XmlNodeList associativeEntities = root.SelectNodes("//AssociativeEntities");
            if (associativeEntities != null)
            {
                foreach (XmlNode associativeEntity in associativeEntities)
                {
                    XmlNodeList parameters = associativeEntity.SelectNodes("//MainLoadParameters/Parameter");
                    if (parameters != null)
                    {
                        for (var index = 0; index < parameters.Count; index++)
                        {
                            XmlNode newParameter = HandleParameter(xDoc, parameters[index]);
                            XmlNode parentNode = parameters[index].ParentNode;
                            parameters[index].ParentNode.RemoveChild(parameters[index]);
                            parentNode.AppendChild(newParameter);
                        }
                    }

                    parameters = associativeEntity.SelectNodes("//SecondaryLoadParameters/Parameter");
                    if (parameters != null)
                    {
                        for (var index = 0; index < parameters.Count; index++)
                        {
                            XmlNode newParameter = HandleParameter(xDoc, parameters[index]);
                            XmlNode parentNode = parameters[index].ParentNode;
                            parameters[index].ParentNode.RemoveChild(parameters[index]);
                            parentNode.AppendChild(newParameter);
                        }
                    }
                }
            }

            var firstline = FileLines[0];
            FileLines = new[] {firstline, xDoc.InnerXml};

            for (var index = 0; index < FileLines.Length; index++)
            {
                FileLines[index] = FileLines[index].Replace(@"<FileVersion>" + _fileVersionFound + "</FileVersion>",
                    @"<FileVersion>" + newFileVersion + "</FileVersion>");
            }

            _fileVersionFound = newFileVersion;

            _forceSave = true;
        }

        private static XmlNode HandleParameter(XmlDocument xDoc, XmlNode parameter)
        {
            XmlNodeList criteriaName = parameter.SelectNodes("./Criteria/Name");
            XmlNodeList propertyName = parameter.SelectNodes("./Property/ParameterName");
            XmlNode newParameter = xDoc.CreateNode(XmlNodeType.Element, "Parameter", string.Empty);

            for (var index = 0; index < criteriaName.Count; index++)
            {
                XmlNode newCriteria = xDoc.CreateNode(XmlNodeType.Element, "CriteriaName", string.Empty);
                newCriteria.InnerText = criteriaName[index].InnerText;
                newParameter.AppendChild(newCriteria);
            }

            for (var index = 0; index < criteriaName.Count; index++)
            {
                XmlNode newProperty = xDoc.CreateNode(XmlNodeType.Element, "PropertyName", string.Empty);
                newProperty.InnerText = propertyName[index].InnerText;
                newParameter.AppendChild(newProperty);
            }

            return newParameter;
        }

        internal static int ReplaceEnum(string filePath, string originalItem, string replacementItem)
        {
            var counter = 0;

            FileLines = File.ReadAllLines(filePath);

            var search = string.Format(">{0}</", originalItem);
            var replace = string.Format(">{0}</", replacementItem);

            for (var index = 0; index < FileLines.Length; index++)
            {
                if (FileLines[index].Contains(search))
                {
                    FileLines[index] = FileLines[index].Replace(search, replace);
                    counter++;
                }
            }

            WriteAllLinesBetter(filePath, FileLines);

            return counter;
        }

        internal static int FindEnum(string filePath, string originalItem)
        {
            FileLines = File.ReadAllLines(filePath);

            var search = string.Format(">{0}</", originalItem);

            return FileLines.Count(t => t.Contains(search));
        }
    }
}