using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CodeSmith.Engine;
using CslaGenerator.Controls;
using CslaGenerator.Metadata;

namespace CslaGenerator.CodeGen
{
    public class AdvancedGenerator : CodeGeneratorBase, ICodeGenerator
    {
        #region Private Fields

        private readonly Dictionary<string, bool?> _fileSuccess = new Dictionary<string, bool?>();
        private List<string> _methodList;
        private readonly string _templatesDirectory = string.Empty;
        private bool _abortRequested;
        private string _fullTemplatesPath;
        private bool _generateDatabaseClass;
        private int _objFailed;
        private int _objSuccess;
        private int _objectWarnings;
        private int _sprocFailed;
        private int _sprocSuccess;
        private TargetFramework _targetFramework;
        private bool _generateInterfaceDAL;
        private Hashtable _templates = new Hashtable();

        #endregion

        #region ICodeGenerator Members

        public string TargetDirectory { get; set; }

        public void Abort()
        {
            _abortRequested = true;
        }

        private bool TargetDALAlert(CslaGeneratorUnit unit)
        {
            var result = true;
            if (unit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
            {
                var alert = MessageBox.Show(
                    unit.ProjectName + @" targets CSLA 4 using DAL and isn't supported (yet) in this release of CslaGenFork.",
                    @"CslaGenFork project generation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (alert == DialogResult.Cancel)
                    result = false;
            }

            return result;
        }

        public void GenerateProject(CslaGeneratorUnit unit)
        {
            if (!TargetDALAlert(unit))
            {
                _objFailed++;
                OnGenerationInformation("Project generation cancelled." + Environment.NewLine);
                return;
            }

            CslaTemplateHelperCS.PrimaryKeys.ClearCache();
            CslaObjectInfo objInfo = null;
            _objFailed = 0;
            _objSuccess = 0;
            _sprocFailed = 0;
            _sprocSuccess = 0;
            OutputWindow.Current.ClearOutput();
            var generationParams = unit.GenerationParams;
            _generateDatabaseClass = generationParams.GenerateDatabaseClass;
            _targetFramework = generationParams.TargetFramework;
            _generateInterfaceDAL = generationParams.TargetDAL == TargetDAL.Interface;
            _abortRequested = false;
            _fullTemplatesPath = _templatesDirectory + generationParams.TargetFramework + @"\";
            _templates = new Hashtable(); //to recompile templates in case they changed.
            //This is just in case users add/remove objects while generating...
            var list = new List<CslaObjectInfo>();
            for (var i = 0; i < unit.CslaObjects.Count; i++)
            {
                if (unit.CslaObjects[i].Generate)
                    list.Add(unit.CslaObjects[i]);
            }

            foreach (var info in list)
            {
// list already filter Generate status
//                if (info.Generate)
//                {
                    if (objInfo == null)
                        objInfo = info;
                    if (_abortRequested) break;
                    OnStep(info.ObjectName);


                    // Business Objects

                    try
                    {
                        GenerateObject(info, unit);
                    }
                    catch (Exception ex)
                    {
                        var sb = new StringBuilder();
                        sb.AppendFormat("Business Objects: {0} failed to generate:", info.ObjectName);
                        sb.AppendLine();
                        sb.Append("    ");
                        sb.Append(ex.Message);
                        OnGenerationInformation(sb.ToString());
                    }
                    if (_abortRequested)
                        break;


                    // Interface DAL

                    try
                    {
                        GenerateInterfaceDAL(info, unit);
                    }
                    catch (Exception ex)
                    {
                        var sb = new StringBuilder();
                        sb.AppendFormat("Interface DAL: {0} failed to generate:", info.ObjectName);
                        sb.AppendLine();
                        sb.Append("    ");
                        sb.Append(ex.Message);
                        OnGenerationInformation(sb.ToString());
                    }
                    if (_abortRequested)
                        break;


                    // DAL Objects

                    try
                    {
                        GenerateDAL(info, unit);
                    }
                    catch (Exception ex)
                    {
                        var sb = new StringBuilder();
                        sb.AppendFormat("DAL Objects: {0} failed to generate:", info.ObjectName);
                        sb.AppendLine();
                        sb.Append("    ");
                        sb.Append(ex.Message);
                        OnGenerationInformation(sb.ToString());
                    }
                    if (_abortRequested)
                        break;


                    // Stored Procedures 

                    if (generationParams.GenerateSprocs && info.GenerateSprocs && info.ObjectType != CslaObjectType.UnitOfWork)
                    {
                        try
                        {
                            if (generationParams.OneSpFilePerObject)
                            {
                                GenerateAllSprocsFile(info, TargetDirectory, generationParams);
                            }
                            else
                            {
                                GenerateSelectProcedure(info, TargetDirectory);
                                if (_abortRequested)
                                    break;

                                if (info.ObjectType != CslaObjectType.ReadOnlyObject
                                    && info.ObjectType != CslaObjectType.ReadOnlyCollection
                                    && info.ObjectType != CslaObjectType.EditableRootCollection
                                    && info.ObjectType != CslaObjectType.DynamicEditableRootCollection
                                    && info.ObjectType != CslaObjectType.EditableChildCollection
                                    && info.ObjectType != CslaObjectType.NameValueList)
                                {
                                    GenerateInsertProcedure(info, TargetDirectory);
                                    if (_abortRequested)
                                        break;

                                    GenerateDeleteProcedure(info, TargetDirectory);
                                    if (_abortRequested)
                                        break;

                                    GenerateUpdateProcedure(info, TargetDirectory);
                                    if (_abortRequested)
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var generationErrors = new StringBuilder();
                            generationErrors.Append(Environment.NewLine + "	SpGeneration Crashed:");
                            generationErrors.Append(ex.Message);
                            generationErrors.AppendLine();
                            generationErrors.AppendLine();
                            if (ex.InnerException != null)
                            {
                                generationErrors.AppendLine(ex.InnerException.Message);
                                generationErrors.AppendLine();
                                generationErrors.AppendLine(ex.InnerException.StackTrace);
                            }
                            generationErrors.AppendLine();
                            OnGenerationInformation(generationErrors.ToString());
                        }
                    }
//                }
            }


            // Infrastructure classes

            if (_generateDatabaseClass)
            {
                GenerateUtilityFile("Database", objInfo, unit, GenerationStep.Business);
            }
            else
            {
                _fileSuccess.Add("Database", null);
            }

            GenerateUtilityFile("DataPortalHookArgs", objInfo, unit, GenerationStep.Business);

            if (_generateInterfaceDAL)
            {
                GenerateUtilityFile("IDalManager", objInfo, unit, GenerationStep.InterfaceDAL);
                GenerateUtilityFile("DalFactory", objInfo, unit, GenerationStep.InterfaceDAL);
                GenerateUtilityFile("DataNotFoundException", objInfo, unit, GenerationStep.InterfaceDAL);
            }

            if (_generateInterfaceDAL)
            {
                GenerateUtilityFile("DalManager", objInfo, unit, GenerationStep.DAL);
            }

            if (_abortRequested)
            {
                OnGenerationInformation(Environment.NewLine + "Code Generation Cancelled!");
            }
            OnFinalized();
        }

        public event GenerationInformationDelegate GenerationInformation;
        public event GenerationInformationDelegate Step;
        public event EventHandler Finalized;

        #endregion

        #region Constructor

        public AdvancedGenerator(string targetDirectory, string templatesDirectory)
        {
            TargetDirectory = targetDirectory;
            _templatesDirectory = templatesDirectory;
        }

        #endregion

        #region Private code generatiom

        private bool EditableSwitchableAlert(CslaObjectInfo objInfo)
        {
            var result = true;
            if (objInfo.ObjectType == CslaObjectType.EditableSwitchable)
            {
                var alert = MessageBox.Show(
                    objInfo.ObjectName + @" is EditableSwitchable" + Environment.NewLine +
                    @"and isn't supported (yet) in this release of CslaGenFork.",
                    @"CslaGenFork object generation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (alert == DialogResult.Cancel)
                    result = false;
            }

            return result;
        }

        private void GenerateObject(CslaObjectInfo objInfo, CslaGeneratorUnit unit)
        {
            if (!EditableSwitchableAlert(objInfo))
            {
                _objFailed++;
                OnGenerationInformation("Object generation cancelled." + Environment.NewLine);
                return;
            }
            
            var generationParams = unit.GenerationParams;
            var fileName = GetBaseFileName(objInfo, false, generationParams.SeparateBaseClasses,
                                           unit.GenerationParams.BaseNamespace,
                                           generationParams.SeparateNamespaces,
                                           generationParams.BaseFilenameSuffix,
                                           generationParams.ExtendedFilenameSuffix,
                                           generationParams.ClassCommentFilenameSuffix, false, false);
            var baseFileName = GetBaseFileName(objInfo, true, generationParams.SeparateBaseClasses,
                                               unit.GenerationParams.BaseNamespace,
                                               generationParams.SeparateNamespaces,
                                               generationParams.BaseFilenameSuffix,
                                               generationParams.ExtendedFilenameSuffix,
                                               generationParams.ClassCommentFilenameSuffix, false, false);
            var classCommentFileName = string.Empty;
            if (!string.IsNullOrEmpty(generationParams.ClassCommentFilenameSuffix))
                classCommentFileName = GetBaseFileName(objInfo, false, generationParams.SeparateBaseClasses,
                                                       unit.GenerationParams.BaseNamespace,
                                                       generationParams.SeparateNamespaces,
                                                       generationParams.BaseFilenameSuffix,
                                                       generationParams.ExtendedFilenameSuffix,
                                                       generationParams.ClassCommentFilenameSuffix, true,
                                                       generationParams.SeparateClassComment);
            _methodList = new List<string>();
            StreamWriter swBase = null;
            StreamWriter sw = null;
            try
            {
                var tPath = _fullTemplatesPath + objInfo.OutputLanguage + @"\" + GetTemplateName(objInfo);
                var template = GetTemplate(objInfo, tPath);
                if (template != null)
                {
                    var errorsOutput = new StringBuilder();
                    var warningsOutput = new StringBuilder();
                    // discontinue ActiveObjects
                    //template.SetProperty("ActiveObjects", generationParams.ActiveObjects);
                    template.SetProperty("Errors", errorsOutput);
                    template.SetProperty("Warnings", warningsOutput);
                    template.SetProperty("MethodList", _methodList);
                    template.SetProperty("CurrentUnit", unit);
                    template.SetProperty("DataSetLoadingScheme", objInfo.DataSetLoadingScheme);
                    if (generationParams.BackupOldSource && File.Exists(baseFileName))
                    {
                        var oldFile = new FileInfo(baseFileName);
                        if (File.Exists(baseFileName + ".old"))
                        {
                            File.Delete(baseFileName + ".old");
                        }
                        oldFile.MoveTo(baseFileName + ".old");
                    }
                    var fsBase = File.Open(baseFileName, FileMode.Create);
                    OnGenerationFileName(baseFileName);
                    swBase = new StreamWriter(fsBase);
                    template.Render(swBase);
                    errorsOutput = (StringBuilder)template.GetProperty("Errors");
                    warningsOutput = (StringBuilder)template.GetProperty("Warnings");
                    _methodList = (List<string>)template.GetProperty("MethodList");
                    if (errorsOutput.Length > 0)
                    {
                        _objFailed++;
                        OnGenerationInformation("Failed:" + Environment.NewLine + errorsOutput);
                    }
                    else
                    {
                        if (warningsOutput != null)
                        {
                            if (warningsOutput.Length > 0)
                            {
                                _objectWarnings++;
                                OnGenerationInformation("Warning:" + Environment.NewLine + warningsOutput);
                            }
                        }
                        _objSuccess++;
                        //OnGenerationInformation("Success");
                    }
                }
                GenerateInheritanceFile(fileName, objInfo, generationParams.ActiveObjects, unit);
                if (!string.IsNullOrEmpty(generationParams.ClassCommentFilenameSuffix))
                    GenerateClassCommentFile(classCommentFileName, objInfo, generationParams.ActiveObjects, unit);
            }
            catch (Exception e)
            {
                _objFailed++;
                ShowExceptionInformation(e);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                if (swBase != null)
                {
                    swBase.Close();
                }
            }
        }

        private void GenerateInterfaceDAL(CslaObjectInfo objInfo, CslaGeneratorUnit unit)
        {
            if (!_generateInterfaceDAL)
                return;
        }

        private void GenerateDAL(CslaObjectInfo objInfo, CslaGeneratorUnit unit)
        {
            if (_targetFramework == TargetFramework.CSLA40)
                return;
        }

        private void GenerateInheritanceFile(string fileName, CslaObjectInfo objInfo, bool activeObjects, CslaGeneratorUnit unit)
        {
            GenerateAccessoryFile(fileName, "\\InheritFromBase.cst", objInfo, activeObjects, unit);
        }

        private void GenerateClassCommentFile(string fileName, CslaObjectInfo objInfo, bool activeObjects, CslaGeneratorUnit unit)
        {
            GenerateAccessoryFile(fileName, "\\ClassComment.cst", objInfo, activeObjects, unit);
        }

        private void GenerateAccessoryFile(string fileName, string templateFile, CslaObjectInfo objInfo, bool activeObjects, CslaGeneratorUnit unit)
        {
            // Create Inheritance file if it does not exist
            if (!File.Exists(fileName)) //&& objInfo.ObjectType != CslaObjectType.NameValueList)
            {
                // string tPath = this._fullTemplatesPath + objInfo.OutputLanguage.ToString() + "\\InheritFromBase.cst";
                var tPath = _fullTemplatesPath + objInfo.OutputLanguage + templateFile;
                var template = GetTemplate(objInfo, tPath);
                if (template != null)
                {
                    // discontinue ActiveObjects
                    //template.SetProperty("ActiveObjects", activeObjects);
                    template.SetProperty("CurrentUnit", unit);
                    if (_methodList != null)
                        template.SetProperty("MethodList", _methodList);
                    var fs = File.Open(fileName, FileMode.Create);
                    OnGenerationFileName(fileName);
                    var sw = new StreamWriter(fs);
                    try
                    {
                        template.Render(sw);
                    }
                    catch (Exception e)
                    {
                        ShowExceptionInformation(e);
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
        }

        private void GenerateUtilityFile(string utilityFilename, CslaObjectInfo objInfo, CslaGeneratorUnit unit, GenerationStep step)
        {
            _fileSuccess.Add(utilityFilename, null);

            var fullFilename = GetFolderPath(unit, step);
            CheckDirectory(fullFilename);

            // filename w/o extension
            fullFilename += utilityFilename;

            // extension
            if (objInfo.OutputLanguage == CodeLanguage.CSharp)
                fullFilename += ".cs";
            else if (objInfo.OutputLanguage == CodeLanguage.VB)
                fullFilename += ".vb";

            // Create utility class file if it does not exist
            if (!File.Exists(fullFilename))
            {
                var tPath = _fullTemplatesPath + objInfo.OutputLanguage + "\\" + utilityFilename + ".cst";
                var template = GetTemplate(objInfo, tPath);
                if (template != null)
                {
                    template.SetProperty("FileName", utilityFilename);
                    template.SetProperty("CurrentUnit", unit);
                    var fs = File.Open(fullFilename, FileMode.Create);
                    OnGenerationInformation(utilityFilename + " file:");
                    OnGenerationFileName(fullFilename);
                    var sw = new StreamWriter(fs);
                    try
                    {
                        template.Render(sw);
                        _fileSuccess[utilityFilename] = true;
                    }
                    catch (Exception e)
                    {
                        ShowExceptionInformation(e);
                        _fileSuccess[utilityFilename] = false;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
        }

        private string GetFolderPath(CslaGeneratorUnit unit, GenerationStep step)
        {
            // base directory of project
            var folderpath = TargetDirectory + @"\";

            if (step == GenerationStep.Business)
            {
                folderpath = GetFolderPath(unit.GenerationParams.SeparateNamespaces,
                                            unit.GenerationParams.BaseNamespace,
                                            unit.GenerationParams.UtilitiesNamespace,
                                            unit.GenerationParams.UtilitiesFolder);
            }
            else if (step == GenerationStep.InterfaceDAL)
            {
                folderpath = GetFolderPath(unit.GenerationParams.SeparateNamespaces,
                                            unit.GenerationParams.BaseNamespace,
                                            unit.GenerationParams.InterfaceDALNamespace,
                                            unit.GenerationParams.InterfaceDALNamespace);
            }
            else if (step == GenerationStep.DAL)
            {
                string baseNamespace = unit.GenerationParams.BaseNamespace;
                if ((unit.GenerationParams.TargetDAL == TargetDAL.Interface) ||
                    (unit.GenerationParams.TargetDAL == TargetDAL.Interface_DTO))
                    baseNamespace = unit.GenerationParams.InterfaceDALNamespace;
                folderpath = GetFolderPath(unit.GenerationParams.SeparateNamespaces,
                                           baseNamespace,
                                           unit.GenerationParams.DALNamespace,
                                           unit.GenerationParams.DALNamespace);
            }

            return folderpath;
        }

        private string GetFolderPath(bool separateNamespaces, string baseNamespace, string fullNamespace, string insideFolder)
        {
            var result = TargetDirectory + @"\";
            if (separateNamespaces)// check whether to use namespace as folder
            {
                if(fullNamespace.IndexOf(baseNamespace + ".") == 0)
                {
                    result += baseNamespace + ".";
                    fullNamespace = fullNamespace.Substring(baseNamespace.Length + 1);
                }
                result += fullNamespace.Replace(".", @"\");
            }
            else if (!insideFolder.Equals(String.Empty))
            {
                // output folder inside directory
                result += insideFolder;
            }

            if (result.EndsWith(@"\") == false)
            {
                result += @"\";
            }

            return result;
        }

        private CodeTemplate GetTemplate(CslaObjectInfo objInfo, string templatePath)
        {
            CodeTemplateCompiler compiler;

            if (!_templates.ContainsKey(templatePath))
            {
                if (!File.Exists(templatePath))
                    throw new ApplicationException("The specified template could not be found: " + templatePath);

                compiler = new CodeTemplateCompiler(templatePath);
                compiler.Compile();
                _templates.Add(templatePath, compiler);

                var sb = new StringBuilder();
                for (int i = 0; i < compiler.Errors.Count; i++)
                {
                    sb.Append(compiler.Errors[i].ToString());
                    sb.Append(Environment.NewLine);
                }
                if (compiler.Errors.Count > 0)
                    throw new Exception(String.Format(
                        "Template {0} failed to compile. Objects of the same type will be ignored.",
                        templatePath) + Environment.NewLine + sb);
            }
            else
            {
                compiler = (CodeTemplateCompiler)_templates[templatePath];
            }
            if (compiler.Errors.Count > 0)
                return null;

            var template = compiler.CreateInstance();
            template.SetProperty("Info", objInfo);
            return template;
        }

        private void ShowExceptionInformation(Exception e)
        {
            var sb = new StringBuilder();
            sb.Append("An error occurred while generating object:");
            sb.Append(Environment.NewLine);
            sb.Append(e.Message);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Stack Trace:");
            sb.Append(Environment.NewLine);
            sb.Append(e.StackTrace);
            OnGenerationInformation(sb.ToString());
        }

        private void WriteToFile(string fileName, string data)
        {
            StreamWriter sw = null;
            try
            {
                var fs = File.Open(fileName, FileMode.Create);
                OnGenerationFileName(fileName);
                sw = new StreamWriter(fs);
                sw.Write(data);
            }
            catch (Exception e)
            {
                var errorDesc = String.Format("Error writing to file {0}: {1}",
                                                 fileName, e.Message);

                OnGenerationInformation(errorDesc);
            }
            finally
            {
                sw.Close();
            }
        }

        #endregion

        #region Private Stored Procedures generation

        private void GenerateAllSprocsFile(CslaObjectInfo info, string dir, GenerationParameters generationParams)
        {
            var selfLoad = CslaTemplateHelperCS.GetSelfLoad(info);

            var proc = new StringBuilder();

            //make sure we don't generate selects when we don't need to.
            if (!((info.ObjectType == CslaObjectType.EditableChildCollection ||
                   info.ObjectType == CslaObjectType.EditableChild) && !selfLoad))
            {
                foreach (var crit in info.CriteriaObjects)
                {
                    if (crit.GetOptions.Procedure && !String.IsNullOrEmpty(crit.GetOptions.ProcedureName))
                        proc.AppendLine(GenerateProcedure(info, crit, "SelectProcedure.cst",
                                                          crit.GetOptions.ProcedureName));
                }
            }

            if (info.ObjectType != CslaObjectType.ReadOnlyObject
                && info.ObjectType != CslaObjectType.ReadOnlyCollection
                && info.ObjectType != CslaObjectType.EditableRootCollection
                && info.ObjectType != CslaObjectType.DynamicEditableRootCollection
                && info.ObjectType != CslaObjectType.EditableChildCollection
                && info.ObjectType != CslaObjectType.NameValueList)
            {
                //Insert
                if (info.InsertProcedureName != "")
                {
                    proc.AppendLine(GenerateProcedure(info, null, "InsertProcedure.cst", info.InsertProcedureName));
                }

                //update
                if (info.UpdateProcedureName != "")
                {
                    proc.AppendLine(GenerateProcedure(info, null, "UpdateProcedure.cst", info.UpdateProcedureName));
                }

                //delete
                foreach (var crit in info.CriteriaObjects)
                {
                    if (crit.DeleteOptions.Procedure && !String.IsNullOrEmpty(crit.DeleteOptions.ProcedureName))
                        proc.AppendLine(GenerateProcedure(info, crit, "DeleteProcedure.cst",
                                                          crit.DeleteOptions.ProcedureName));
                }
                /*if (_targetFramework != TargetFramework.CSLA40 && info.ObjectType == CslaObjectType.EditableChild)
                {
                    proc.AppendLine(GenerateProcedure(info, null, "DeleteProcedure.cst", info.DeleteProcedureName));
                }*/
            }
            if (proc.Length > 0)
            {
                CheckDirectory(dir + @"\sprocs");
                WriteToFile(dir + @"\sprocs\" + info.ObjectName + ".sql", proc.ToString());
            }
        }

        private void GenerateSelectProcedure(CslaObjectInfo info, string dir)
        {
            var lazyLoad = CslaTemplateHelperCS.GetLazyLoad(info);

            //make sure we don't generate selects when we don't need to.
            if (
                !((info.ObjectType == CslaObjectType.EditableChildCollection ||
                   info.ObjectType == CslaObjectType.EditableChild) && !lazyLoad))
            {
                foreach (var crit in info.CriteriaObjects)
                {
                    if (crit.GetOptions.Procedure && !String.IsNullOrEmpty(crit.GetOptions.ProcedureName))
                    {
                        string proc = GenerateProcedure(info, crit, "SelectProcedure.cst", crit.GetOptions.ProcedureName);
                        CheckDirectory(dir + @"\sprocs");
                        WriteToFile(dir + @"\sprocs\" + crit.GetOptions.ProcedureName + ".sql", proc);
                    }
                }
            }
        }

        private void GenerateInsertProcedure(CslaObjectInfo info, string dir)
        {
            if (info.InsertProcedureName != "")
            {
                var proc = GenerateProcedure(info, null, "InsertProcedure.cst", info.InsertProcedureName);
                CheckDirectory(dir + @"\sprocs");
                WriteToFile(dir + @"\sprocs\" + info.InsertProcedureName + ".sql", proc);
            }
        }

        private void GenerateUpdateProcedure(CslaObjectInfo info, string dir)
        {
            if (info.UpdateProcedureName != "")
            {
                var proc = GenerateProcedure(info, null, "UpdateProcedure.cst", info.UpdateProcedureName);
                CheckDirectory(dir + @"\sprocs");
                WriteToFile(dir + @"\sprocs\" + info.UpdateProcedureName + ".sql", proc);
            }
        }

        private void GenerateDeleteProcedure(CslaObjectInfo info, string dir)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.DeleteOptions.Procedure && !String.IsNullOrEmpty(crit.DeleteOptions.ProcedureName))
                {
                    string proc = GenerateProcedure(info, crit, "DeleteProcedure.cst", crit.DeleteOptions.ProcedureName);
                    CheckDirectory(dir + @"\sprocs");
                    WriteToFile(dir + @"\sprocs\" + crit.DeleteOptions.ProcedureName + ".sql", proc);
                }
            }
            /*if (_targetFramework != TargetFramework.CSLA40 && info.ObjectType == CslaObjectType.EditableChild)
            {
                var proc = GenerateProcedure(info, null, "DeleteProcedure.cst", info.DeleteProcedureName);
                CheckDirectory(dir + @"\sprocs");
                WriteToFile(dir + @"\sprocs\" + info.DeleteProcedureName + ".sql", proc);
            }*/
        }

        private string GenerateProcedure(CslaObjectInfo objInfo, Criteria crit, string templateName, string sprocName)
        {
            if (objInfo != null)
            {
                StringWriter sw = null;
                try
                {
                    if (templateName != String.Empty)
                    {
                        var path = _templatesDirectory + @"sprocs\" + templateName;
                        var template = GetTemplate(objInfo, path);
                        if (crit != null)
                            template.SetProperty("Criteria", crit);
                        template.SetProperty("IncludeParentProperties", objInfo.DataSetLoadingScheme);
                        if (template != null)
                        {
                            //template.SetProperty("Catalog", _);
                            sw = new StringWriter();
                            template.Render(sw);
                            _sprocSuccess++;
                            return sw.ToString();
                        }
                    }
                }
                catch (Exception e)
                {
                    _sprocFailed++;
                    throw (new Exception(
                        "Error generating " + GetFileNameWithoutExtension(templateName) + ": " + sprocName, e));
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
            }
            return String.Empty;
        }

        #endregion

        #region Private File / Directory related methods

        private static void CheckDirectory(string dir)
        {
            if (!Directory.Exists(dir))
            {
                if (dir.StartsWith(@"\\"))
                {
                    throw new ApplicationException("Illegal path: UNC paths are not supported.");
                }
                // Recursion 
                // If this folder doesn't exists, check the parent folder
                if (dir.EndsWith(@"\"))
                {
                    dir = dir.Substring(0, dir.Length - 1);
                }
                else if (dir.IndexOf(@"\") == -1)
                    throw new ApplicationException(
                        String.Format("The output path could not be created. Check that the \"{0}\" unit exists.", dir));

                CheckDirectory(dir.Substring(0, dir.LastIndexOf(@"\")));
                Directory.CreateDirectory(dir);
            }
        }

        private static string GetNamespaceDirectory(string targetDir, CslaObjectInfo info, bool isBaseClass,
                                                    bool separateNamespaces, string baseNamespace, bool isClassComment)
        {
            if (targetDir.EndsWith(@"\") == false)
            {
                targetDir += @"\";
            }


            if (separateNamespaces)// check whether to use namespace as folder
            {
                var objectNamespace = info.ObjectNamespace;
                if (objectNamespace.IndexOf(baseNamespace + ".") == 0)
                {
                    targetDir += baseNamespace + ".";
                    objectNamespace = objectNamespace.Substring(baseNamespace.Length + 1);
                }
                targetDir += objectNamespace.Replace(".", @"\");

                if (targetDir.EndsWith(@"\") == false)
                {
                    targetDir += @"\";
                }
            }

            if (!info.Folder.Trim().Equals(String.Empty))
                targetDir += info.Folder + @"\";
            if (isBaseClass)
            {
                targetDir += @"Base\";
            }
            if (isClassComment)
            {
                targetDir += @"Comment\";
            }
            CheckDirectory(targetDir);
            return targetDir;
        }

        private string GetBaseFileName(CslaObjectInfo info, bool isBaseClass, bool separateBaseClasses, string baseNamespace,
                                       bool separateNamespaces, string baseFilenameSuffix, string extendedFilenameSuffix,
                                       string classCommentFilenameSuffix, bool isClassComment, bool separateClassComment)
        {
            var fileNoExtension = GetFileNameWithoutExtension(info.FileName);
            if (isBaseClass)
            {
                if (!string.IsNullOrEmpty(baseFilenameSuffix))
                    fileNoExtension += baseFilenameSuffix;
                else
                    fileNoExtension += "Base";
            }
            else if (isClassComment)
            {
                if (!string.IsNullOrEmpty(classCommentFilenameSuffix))
                    fileNoExtension += classCommentFilenameSuffix;
            }
            else
            {
                if (!string.IsNullOrEmpty(extendedFilenameSuffix))
                    fileNoExtension += extendedFilenameSuffix;
            }

            var fileExtension = GetFileExtension(info.FileName);
            if (fileExtension == String.Empty)
            {
                if (info.OutputLanguage == CodeLanguage.CSharp) fileNoExtension += ".cs";
                if (info.OutputLanguage == CodeLanguage.VB) fileNoExtension += ".vb";
            }
            else
            {
                fileNoExtension += fileExtension;
            }

            return
                (GetNamespaceDirectory(TargetDirectory, info,
                                       isBaseClass ? separateBaseClasses : false,
                                       separateNamespaces, baseNamespace,
                                       isClassComment ? separateClassComment : false) +
                 fileNoExtension);
        }

        private static string GetFileNameWithoutExtension(string fileName)
        {
            var index = fileName.LastIndexOf(".");
            if (index >= 0)
            {
                return fileName.Substring(0, index);
            }
            return fileName;
        }

        private static string GetFileExtension(string fileName)
        {
            var index = fileName.LastIndexOf(".");
            if (index >= 0)
            {
                return fileName.Substring(index + 1);
            }
            return String.Empty;
        }

        private static string GetTemplateName(CslaObjectInfo info)
        {
            return GetTemplateName(info.ObjectType);
        }

        private static string GetTemplateName(CslaObjectType type)
        {
            return String.Format("{0}.cst", type);
        }

        #endregion

        #region Event triggers

        private void OnGenerationFileName(string e)
        {
            if (GenerationInformation != null)
                GenerationInformation(e);
            OutputWindow.Current.AddOutputInfo("\tFile: " + e);
        }

        private void OnGenerationInformation(string e)
        {
            if (GenerationInformation != null)
                GenerationInformation(e);
            OutputWindow.Current.AddOutputInfo(e, 1);
        }

        private void OnStep(string objectName)
        {
            if (Step != null)
                Step(objectName);
            OutputWindow.Current.AddOutputInfo(String.Format("{0}:", objectName));
        }

        private void OnFinalized()
        {
            if (Finalized != null)
                Finalized(this, new EventArgs());
            OutputWindow.Current.AddOutputInfo("\r\nDone");

            if (_generateDatabaseClass)
            {
                if (_fileSuccess["Database"] == null)
                    OutputWindow.Current.AddOutputInfo(String.Format("Database classe: already exists."));
                else if (_fileSuccess["Database"] == false)
                    OutputWindow.Current.AddOutputInfo(String.Format("Database classe: failed."));
            }

            if (_fileSuccess["DataPortalHookArgs"] == null)
                OutputWindow.Current.AddOutputInfo(String.Format("DataPortalHookArgs classe: already exists."));
            else if (_fileSuccess["DataPortalHookArgs"] == false)
                OutputWindow.Current.AddOutputInfo(String.Format("DataPortalHookArgs classe: failed."));

            if (_generateInterfaceDAL)
            {
                if (_fileSuccess["IDalManager"] == null)
                    OutputWindow.Current.AddOutputInfo(String.Format("IDalManager classe: already exists."));
                else if (_fileSuccess["IDalManager"] == false)
                    OutputWindow.Current.AddOutputInfo(String.Format("IDalManager classe: failed."));
                if (_fileSuccess["DalFactory"] == null)
                    OutputWindow.Current.AddOutputInfo(String.Format("DalFactory classe: already exists."));
                else if (_fileSuccess["DalFactory"] == false)
                    OutputWindow.Current.AddOutputInfo(String.Format("DalFactory classe: failed."));
                if (_fileSuccess["DataNotFoundException"] == null)
                    OutputWindow.Current.AddOutputInfo(String.Format("DataNotFoundException classe: already exists."));
                else if (_fileSuccess["DataNotFoundException"] == false)
                    OutputWindow.Current.AddOutputInfo(String.Format("DataNotFoundException classe: failed."));
                if (_fileSuccess["DalManager"] == null)
                    OutputWindow.Current.AddOutputInfo(String.Format("DalManager classe: already exists."));
                else if (_fileSuccess["DalManager"] == false)
                    OutputWindow.Current.AddOutputInfo(String.Format("DalManager classe: failed."));
            }

            if (_objectWarnings > 0)
                OutputWindow.Current.AddOutputInfo(String.Format("Warnings: {0} object{1}.", _objectWarnings,
                                                                 _objectWarnings > 1 ? "s" : ""));

            OutputWindow.Current.AddOutputInfo(String.Format("\r\nClasses: {0} generated. {1} failed.",
                                                             (_objFailed + _objSuccess), _objFailed));
            OutputWindow.Current.AddOutputInfo(String.Format("Stored Procs: {0} generated. {1} failed.",
                                                             (_sprocFailed + _sprocSuccess), _sprocFailed));
        }

        #endregion
    }
}
