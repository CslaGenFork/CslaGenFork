using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
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
        private readonly GenerationReportCollection _errorReport = new GenerationReportCollection();
        private readonly GenerationReportCollection _warningReport = new GenerationReportCollection();
        private int _objFailed;
        private int _objSuccess;
        private int _objectWarnings;
        private int _sprocFailed;
        private int _sprocWarnings;
        private int _sprocSuccess;
        private TargetFramework _targetFramework;
        private Hashtable _templates = new Hashtable();
        private string _codeEncoding;
        private string _sprocEncoding;
        private CslaGeneratorUnit _unit;
        private bool _businessError;

        #endregion

        #region ICodeGenerator Members

        public string TargetDirectory { get; set; }

        public GenerationReportCollection ErrorReport
        {
            get { return _errorReport; }
        }

        public GenerationReportCollection WarningReport
        {
            get { return _warningReport; }
        }

        public void Abort()
        {
            _abortRequested = true;
        }

        public void GenerateProject(CslaGeneratorUnit unit)
        {
            _unit = unit;
            if (_unit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL &&
                (_unit.GenerationParams.UseDto == TargetDto.MoreThan ||
                _unit.GenerationParams.UseDto == TargetDto.Always))
            {
                MessageBox.Show(@"DTO aren't supported in this release of CslaGenFork.",
                    @"CslaGenFork DAL project generation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _unit.GenerationTimer.Restart();
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
            _abortRequested = false;
            _fullTemplatesPath = _templatesDirectory + generationParams.TargetFramework + @"\";
            _templates = new Hashtable(); //to recompile templates in case they changed.
            //This is just in case users add/remove objects while generating...
            var list = unit.CslaObjects.Where(t => t.Generate).ToList();
            /*for (var i = 0; i < unit.CslaObjects.Count; i++)
            {
                if (unit.CslaObjects[i].Generate)
                    list.Add(unit.CslaObjects[i]);
            }*/

            var generalValidation = GeneralValidation(GenerationStep.Business);
            if (generationParams.GenerateDalInterface)
                generalValidation &= GeneralValidation(GenerationStep.DalInterface);
            if (generationParams.GenerateDalObject)
                generalValidation &= GeneralValidation( GenerationStep.DalObject);

            if(!generalValidation)
            {
                _unit.GenerationTimer.Stop();
                OnFinalized(false);
                return;
            }

            // add blank line
            OnGenerationInformation("");

            foreach (var info in list)
            {
                _businessError = false;
                if (objInfo == null)
                    objInfo = info;
                if (_abortRequested) break;
                OnStep(info.ObjectName);

                // Business Objects
                try
                {
                    GenerateObject(info);
                }
                catch (Exception ex)
                {
                    _objFailed++;
                    _errorReport.Add(new GenerationReport
                    {
                        ObjectName = info.ObjectName,
                        ObjectType = info.ObjectType.ToString(),
                        Message = ex.Message,
                        FileName = "unknown (Business)"
                    });
                    var sb = new StringBuilder();
                    sb.AppendLine("* * * Error:");
                    sb.AppendFormat("Business Object: {0} failed to generate:", info.ObjectName);
                    sb.AppendLine();
                    sb.AppendLine(ex.Message);
                    OnGenerationInformation(sb.ToString());
                }
                if (_abortRequested)
                    break;

                if (((generationParams.GenerateDalInterface || generationParams.GenerateDalObject)
                    && info.GenerateDataAccessRegion) &&
                    ((NeedsDbFetch(info) && HasFetchCriteria(info)) ||
                    (NeedsDbInsUpdDel(info) && HasInsUpdDelcriteria(info))))
                {

                    // DAL Interface
                    try
                    {
                        DoGenerateDalInterface(info);
                    }
                    catch (Exception ex)
                    {
                        _objFailed++;
                        _errorReport.Add(new GenerationReport
                        {
                            ObjectName = info.ObjectName,
                            ObjectType = info.ObjectType.ToString(),
                            Message = ex.Message,
                            FileName = "unknown (DAL interface)"
                        });
                        var sb = new StringBuilder();
                        sb.AppendLine("* * * Error:");
                        sb.AppendFormat("DAL Interface: {0} failed to generate:", info.ObjectName);
                        sb.AppendLine();
                        sb.AppendLine(ex.Message);
                        OnGenerationInformation(sb.ToString());
                    }
                    if (_abortRequested)
                        break;

                    // DAL Objects
                    try
                    {
                        DoGenerateDalObject(info);
                    }
                    catch (Exception ex)
                    {
                        _objFailed++;
                        _errorReport.Add(new GenerationReport
                        {
                            ObjectName = info.ObjectName,
                            ObjectType = info.ObjectType.ToString(),
                            Message = ex.Message,
                            FileName = "unknown (DAL)"
                        });
                        var sb = new StringBuilder();
                        sb.AppendLine("* * * Error:");
                        sb.AppendFormat("DAL Object: {0} failed to generate:", info.ObjectName);
                        sb.AppendLine();
                        sb.AppendLine(ex.Message);
                        OnGenerationInformation(sb.ToString());
                    }
                    if (_abortRequested)
                        break;
                }

                // Stored Procedures
                if (generationParams.GenerateSprocs && info.GenerateSprocs)
                {
                    try
                    {
                        if (generationParams.OneSpFilePerObject)
                        {
                            GenerateAllSprocsFile(info, TargetDirectory);
                        }
                        else
                        {
                            GenerateSelectProcedure(info, TargetDirectory);
                            if (_abortRequested)
                                break;

//                            if (info.ObjectType != CslaObjectType.ReadOnlyObject
//                                && info.ObjectType != CslaObjectType.ReadOnlyCollection
//                                && info.ObjectType != CslaObjectType.EditableRootCollection
//                                && info.ObjectType != CslaObjectType.DynamicEditableRootCollection
//                                && info.ObjectType != CslaObjectType.EditableChildCollection
//                                && info.ObjectType != CslaObjectType.NameValueList
//                                && info.ObjectType != CslaObjectType.UnitOfWork)
                            if (NeedsDbInsUpdDel(info))
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
                        generationErrors.AppendLine("* * * Error:");
                        generationErrors.AppendFormat("SProc {0} failed to generate:", info.ObjectName);
                        generationErrors.AppendLine();
                        generationErrors.AppendLine(ex.Message);
                        if (ex.InnerException != null)
                        {
                            generationErrors.AppendLine(ex.InnerException.Message);
                            generationErrors.AppendLine("Stack Trace");
                            generationErrors.AppendLine(ex.InnerException.StackTrace);
                        }
                        OnGenerationInformation(generationErrors.ToString());
                    }
                }
            }

            var dbConnection = CslaTemplateHelperCS.GetConnectionName(_unit);

            // Infrastructure classes
            if (_generateDatabaseClass && generationParams.TargetFramework == TargetFramework.CSLA40)
            {
                const GenerationStep step = GenerationStep.Business;
                GenerateUtilityFile("Database" + dbConnection, false, "Database", step);
            }
            else
            {
                _fileSuccess.Add("Database", null);
            }

            GenerateUtilityFile("DataPortalHookArgs", false, "DataPortalHookArgs", GenerationStep.Business);

            if (generationParams.GenerateDalInterface)
            {
                GenerateUtilityFile("IDalManager" + dbConnection, false, "IDalManager", GenerationStep.DalInterface);
                GenerateUtilityFile("DalFactory" + dbConnection, false, "DalFactory", GenerationStep.DalInterface);
                GenerateUtilityFile("DataNotFoundException", false, "DataNotFoundException", GenerationStep.DalInterface);
            }
            else
            {
                _fileSuccess.Add("IDalManager", null);
                _fileSuccess.Add("DalFactory", null);
                _fileSuccess.Add("DataNotFoundException", null);
            }

            if (generationParams.GenerateDalObject)
            {
                GenerateUtilityFile("DalManager" + dbConnection, false, "DalManager", GenerationStep.DalObject);
            }
            else
            {
                _fileSuccess.Add("DalManager", null);
            }

            if (_abortRequested)
            {
                OnGenerationInformation(Environment.NewLine + "* * * * Code Generation Cancelled!");
            }
            _unit.GenerationTimer.Stop();
            OnFinalized(true);
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
            _codeEncoding = ValidateEncodings("CodeEncoding");
            _sprocEncoding = ValidateEncodings("SProcEncoding");
        }

        #endregion

        #region Private code generatiom

        private bool GeneralValidation(GenerationStep step)
        {
            var templateName = "ProjectValidate_" + step + ".cst";
            var utilityFilename = "Validating_" + step + ".txt";

            var fullFilename = TargetDirectory + @"\";
            CheckDirectory(fullFilename);
            fullFilename += utilityFilename;
            if (File.Exists(fullFilename))
            {
                File.Delete(fullFilename);
            }

            // Create utility class file if it does not exist
            if (!File.Exists(fullFilename))
            {
                StreamWriter sw = null;
                try
                {
                    var tPath = _fullTemplatesPath + _unit.GenerationParams.OutputLanguage + "\\" + templateName;
                    var template = GetTemplate(new CslaObjectInfo(), tPath);
                    if (template != null)
                    {
                        var errorsOutput = new StringBuilder();
                        var warningsOutput = new StringBuilder();
                        template.SetProperty("Errors", errorsOutput);
                        template.SetProperty("Warnings", warningsOutput);
                        template.SetProperty("CurrentUnit", _unit);
                        var fs = File.Open(fullFilename, FileMode.Create);
                        OnGenerationInformation("Validation: " + step);
                        sw = new StreamWriter(fs, Encoding.GetEncoding(_codeEncoding));
                        template.Render(sw);
                        errorsOutput = (StringBuilder) template.GetProperty("Errors");
                        warningsOutput = (StringBuilder) template.GetProperty("Warnings");
                        if (errorsOutput.Length > 0)
                        {
                            _errorReport.AddMultiline(new GenerationReport
                                                 {
                                                     ObjectName = "General Validation",
                                                     ObjectType = step.ToString(),
                                                     Message = errorsOutput.ToString(),
                                                     FileName = fullFilename
                                                 });
                            OnGenerationInformation("* * Failed:" + Environment.NewLine + errorsOutput);
                            _fileSuccess[templateName] = false;
                        }
                        else
                        {
                            if (warningsOutput != null)
                            {
                                if (warningsOutput.Length > 0)
                                {
                                    _warningReport.AddMultiline(new GenerationReport
                                                                    {
                                                                        ObjectName = "General Validation",
                                                                        ObjectType = step.ToString(),
                                                                        Message = warningsOutput.ToString(),
                                                                        FileName = fullFilename
                                                                    });
                                    OnGenerationInformation("* Warning:" + Environment.NewLine + warningsOutput);
                                }
                            }
                            _fileSuccess[templateName] = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    _fileSuccess[templateName] = false;
                    var msg = ShowExceptionInformation(e);
                    _errorReport.Add(new GenerationReport
                                         {
                                             ObjectName = "General Validation",
                                             ObjectType = step.ToString(),
                                             Message = msg,
                                             FileName = fullFilename
                                         });
                    OnGenerationInformation(msg);
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }

            // delete validation output file
            if (File.Exists(fullFilename))
            {
                File.Delete(fullFilename);
            }

            if (_fileSuccess[templateName] == true)
            {
                OnGenerationInformation("Passed.");
                return true;
            }
            return false;
        }

        private static string ValidateEncodings(string key)
        {
            const string defaultEncoding = "iso-8859-1";
            string encoding = ConfigurationManager.AppSettings.Get(key);

            if (string.IsNullOrWhiteSpace(encoding))
            {
                MessageBox.Show(@"Error in ""appSettings"" section of ""CslaGenerator.exe.config"" file." + Environment.NewLine +
                                @"The key """ + key + @""" is empty or missing." + Environment.NewLine +
                                @"Will use " + defaultEncoding + @" instead.",
                                @"CslaGenFork object generation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return defaultEncoding;
            }

            try
            {
                var encode = Encoding.GetEncoding(encoding);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Error in ""appSettings"" section of ""CslaGenerator.exe.config"" file." + Environment.NewLine +
                                @"The key """ + key + @"""=""" + encoding + @""" is not valid." + Environment.NewLine +
                                @"Will use """ + defaultEncoding + @""" instead.",
                                @"CslaGenFork object generation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return defaultEncoding;
            }

            return encoding;
        }

        private bool EditableSwitchableAlert(CslaObjectInfo objInfo)
        {
            _unit.GenerationTimer.Stop();
            var result = true;
            if (objInfo.ObjectType == CslaObjectType.EditableSwitchable)
            {
                var alert = MessageBox.Show(
                    objInfo.ObjectName + @" is EditableSwitchable" + Environment.NewLine +
                    @"and isn't supported in this release of CslaGenFork.",
                    @"CslaGenFork object generation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (alert == DialogResult.Cancel)
                    result = false;
            }

            _unit.GenerationTimer.Start();
            return result;
        }

        private void GenerateObject(CslaObjectInfo objInfo)
        {
            if (!EditableSwitchableAlert(objInfo))
            {
                _objFailed++;
                OnGenerationInformation("Object generation cancelled." + Environment.NewLine);
                return;
            }

            var generationParams = _unit.GenerationParams;
            var baseFileName = GetBaseFileName(objInfo, true, generationParams.BaseNamespace, false, GenerationStep.Business);
            var extendedFileName = GetBaseFileName(objInfo, false, generationParams.BaseNamespace, false, GenerationStep.Business);
            var classCommentFileName = string.Empty;
            if (!string.IsNullOrEmpty(generationParams.ClassCommentFilenameSuffix))
                classCommentFileName = GetBaseFileName(objInfo, false, generationParams.BaseNamespace, true, GenerationStep.Business);
            _methodList = new List<string>();
            StreamWriter sw = null;
            try
            {
                var tPath = _fullTemplatesPath + objInfo.OutputLanguage + @"\" + GetTemplateName(objInfo, GenerationStep.Business);
                var template = GetTemplate(objInfo, tPath);
                if (template != null)
                {
                    var errorsOutput = new StringBuilder();
                    var warningsOutput = new StringBuilder();
                    template.SetProperty("Errors", errorsOutput);
                    template.SetProperty("Warnings", warningsOutput);
                    template.SetProperty("MethodList", _methodList);
                    template.SetProperty("CurrentUnit", _unit);
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
                    sw = new StreamWriter(fsBase, Encoding.GetEncoding(_codeEncoding));
                    template.Render(sw);
                    errorsOutput = (StringBuilder)template.GetProperty("Errors");
                    warningsOutput = (StringBuilder)template.GetProperty("Warnings");
                    _methodList = (List<string>)template.GetProperty("MethodList");
                    if (errorsOutput.Length > 0)
                    {
                        _businessError = true;
                        _objFailed++;
                        _errorReport.Add(new GenerationReport
                                             {
                                                 ObjectName = objInfo.ObjectName,
                                                 ObjectType = objInfo.ObjectType.ToString(),
                                                 Message = errorsOutput.ToString(),
                                                 FileName = baseFileName
                                             });
                        OnGenerationInformation("* * Failed:" + Environment.NewLine + errorsOutput);
                    }
                    else
                    {
                        if (warningsOutput != null)
                        {
                            if (warningsOutput.Length > 0)
                            {
                                _objectWarnings++;
                                _warningReport.AddMultiline(new GenerationReport
                                                                {
                                                                    ObjectName = objInfo.ObjectName,
                                                                    ObjectType = objInfo.ObjectType.ToString(),
                                                                    Message = warningsOutput.ToString(),
                                                                    FileName = baseFileName
                                                                });
                                OnGenerationInformation("* Warning:" + Environment.NewLine + warningsOutput);
                            }
                        }
                        _objSuccess++;
                        //OnGenerationInformation("Success");
                    }
                }
                GenerateExtendedFile(extendedFileName, objInfo);
                if (!string.IsNullOrEmpty(generationParams.ClassCommentFilenameSuffix))
                    GenerateClassCommentFile(classCommentFileName, objInfo);
            }
            catch (Exception e)
            {
                _objFailed++;
                var msg = ShowExceptionInformation(e);
                _errorReport.Add(new GenerationReport
                {
                    ObjectName = objInfo.ObjectName,
                    ObjectType = objInfo.ObjectType.ToString(),
                    Message = msg,
                    FileName = baseFileName
                });
                OnGenerationInformation(msg);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private void GenerateExtendedFile(string fileName, CslaObjectInfo objInfo)
        {
            GenerateExtendedFile(fileName, "\\ExtendedFile.cst", objInfo);
        }

        private void GenerateDalExtendedFile(string fileName, CslaObjectInfo objInfo, GenerationStep step)
        {
            GenerateExtendedFile(fileName, "\\ExtendedFile_" + step + ".cst", objInfo);
        }

        private void GenerateExtendedFile(string fileName, string templateFile, CslaObjectInfo objInfo)
        {
            // Create Extended file if it does not exist
            if (!File.Exists(fileName))
            {
                StreamWriter sw = null;
                try
                {
                    if (templateFile != string.Empty)
                    {
                        var tPath = _fullTemplatesPath + objInfo.OutputLanguage + templateFile;
                        var template = GetTemplate(objInfo, tPath);
                        if (template != null)
                        {
                            template.SetProperty("CurrentUnit", _unit);
                            if (_methodList != null)
                                template.SetProperty("MethodList", _methodList);
                            var fs = File.Open(fileName, FileMode.Create);
                            OnGenerationFileName(fileName);
                            sw = new StreamWriter(fs, Encoding.GetEncoding(_codeEncoding));
                            template.Render(sw);
                        }
                    }
                }
                catch (Exception e)
                {
                    _objFailed++;
                    var msg = ShowExceptionInformation(e);
                    _errorReport.Add(new GenerationReport
                    {
                        ObjectName = objInfo.ObjectName,
                        ObjectType = objInfo.ObjectType.ToString(),
                        Message = msg,
                        FileName = fileName
                    });
                    OnGenerationInformation(msg);
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }
        }

        private void GenerateClassCommentFile(string fileName, CslaObjectInfo objInfo)
        {
            GenerateExtendedFile(fileName, "\\ClassComment.cst", objInfo);
        }

        private void GenerateDalClassCommentFile(string fileName, CslaObjectInfo objInfo, GenerationStep step)
        {
            GenerateExtendedFile(fileName, "\\ClassComment_" + step + ".cst", objInfo);
        }

        private void DoGenerateDalInterface(CslaObjectInfo objInfo)
        {
            if (!GeneratorController.Current.CurrentUnit.GenerationParams.GenerateDalInterface)
                return;

            DoGenerateDal(objInfo, GenerationStep.DalInterface);
        }

        private void DoGenerateDalObject(CslaObjectInfo objInfo)
        {
            if (!GeneratorController.Current.CurrentUnit.GenerationParams.GenerateDalObject)
                return;

            DoGenerateDal(objInfo, GenerationStep.DalObject);
        }

        private void DoGenerateDal(CslaObjectInfo objInfo, GenerationStep step)
        {
            if (objInfo.ObjectType == CslaObjectType.UnitOfWork)
                return;

            if (!EditableSwitchableAlert(objInfo))
            {
                _objFailed++;
                OnGenerationInformation("Object generation cancelled." + Environment.NewLine);
                return;
            }

            var generationParams = _unit.GenerationParams;
            var baseFileName = GetBaseFileName(objInfo, true, GetContextBaseNamespace(_unit, step), false, step);

            if (_businessError)
            {
                OnGenerationFileName(baseFileName);
                _objFailed++;
                _errorReport.Add(new GenerationReport
                                     {
                                         ObjectName = objInfo.ObjectName,
                                         ObjectType = objInfo.ObjectType.ToString(),
                                         Message = "Error on Business generation.",
                                         FileName = baseFileName
                                     });
                OnGenerationInformation("* * Failed:" + Environment.NewLine + "Error on Business generation." + Environment.NewLine);
                return;
            }

            var extendedFileName = GetBaseFileName(objInfo, false, GetContextBaseNamespace(_unit, step), false, step);
            var classCommentFileName = string.Empty;
            if (!string.IsNullOrEmpty(generationParams.ClassCommentFilenameSuffix))
                classCommentFileName = GetBaseFileName(objInfo, false, GetContextBaseNamespace(_unit, step), true, step);
            _methodList = new List<string>();
            StreamWriter sw = null;
            try
            {
                var tPath = _fullTemplatesPath + objInfo.OutputLanguage + @"\" + GetTemplateName(objInfo, step);
                var template = GetTemplate(objInfo, tPath);
                if (template != null)
                {
                    var errorsOutput = new StringBuilder();
                    var warningsOutput = new StringBuilder();
                    template.SetProperty("Errors", errorsOutput);
                    template.SetProperty("Warnings", warningsOutput);
                    template.SetProperty("MethodList", _methodList);
                    template.SetProperty("CurrentUnit", _unit);
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
                    sw = new StreamWriter(fsBase, Encoding.GetEncoding(_codeEncoding));
                    template.Render(sw);
                    errorsOutput = (StringBuilder) template.GetProperty("Errors");
                    warningsOutput = (StringBuilder) template.GetProperty("Warnings");
                    _methodList = (List<string>) template.GetProperty("MethodList");
                    if (errorsOutput.Length > 0)
                    {
                        _objFailed++;
                        _errorReport.Add(new GenerationReport
                                               {
                                                   ObjectName = objInfo.ObjectName,
                                                   ObjectType = objInfo.ObjectType.ToString(),
                                                   Message = errorsOutput.ToString(),
                                                   FileName = baseFileName
                                               });
                        OnGenerationInformation("* * Failed:" + Environment.NewLine + errorsOutput);
                    }
                    else
                    {
                        if (warningsOutput != null)
                        {
                            if (warningsOutput.Length > 0)
                            {
                                _objectWarnings++;
                                _warningReport.AddMultiline(new GenerationReport
                                                                {
                                                                    ObjectName = objInfo.ObjectName,
                                                                    ObjectType = objInfo.ObjectType.ToString(),
                                                                    Message = warningsOutput.ToString(),
                                                                    FileName = baseFileName
                                                                });
                                OnGenerationInformation("* Warning:" + Environment.NewLine + warningsOutput);
                            }
                        }
                        _objSuccess++;
                        //OnGenerationInformation("Success");
                    }
                }
                GenerateDalExtendedFile(extendedFileName, objInfo, step);
                if (!string.IsNullOrEmpty(generationParams.ClassCommentFilenameSuffix))
                    GenerateDalClassCommentFile(classCommentFileName, objInfo, step);
            }
            catch (Exception e)
            {
                _objFailed++;
                var msg = ShowExceptionInformation(e);
                _errorReport.Add(new GenerationReport
                {
                    ObjectName = objInfo.ObjectName,
                    ObjectType = objInfo.ObjectType.ToString(),
                    Message = msg,
                    FileName = "unknown (" + step + ")"
                });
                OnGenerationInformation(msg);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private void GenerateUtilityFile(string utilityFilename, bool deleteFile, string utilityTemplate, GenerationStep step)
        {
            var outputLanguage = _unit.GenerationParams.OutputLanguage;
            _fileSuccess.Add(utilityFilename, null);

            var fullFilename = GetUtilitiesFolderPath(step);
            CheckDirectory(fullFilename);

            // filename w/o extension
            fullFilename += utilityFilename;

            // extension
            if (outputLanguage == CodeLanguage.CSharp)
                fullFilename += ".cs";
            else if (outputLanguage == CodeLanguage.VB)
                fullFilename += ".vb";

            if (File.Exists(fullFilename) && deleteFile)
            {
                File.Delete(fullFilename);
            }

            // Create utility class file if it does not exist
            if (!File.Exists(fullFilename))
            {
                StreamWriter sw = null;
                try
                {
                    if (utilityTemplate != string.Empty)
                    {
                        var tPath = _fullTemplatesPath + outputLanguage + "\\" + utilityTemplate + ".cst";
                        var template = GetTemplate(new CslaObjectInfo(), tPath);
                        if (template != null)
                        {
                            var errorsOutput = new StringBuilder();
                            var warningsOutput = new StringBuilder();
                            template.SetProperty("Errors", errorsOutput);
                            template.SetProperty("Warnings", warningsOutput);
                            template.SetProperty("CurrentUnit", _unit);
                            var fs = File.Open(fullFilename, FileMode.Create);
                            OnGenerationInformation(utilityFilename + " file:");
                            OnGenerationFileName(fullFilename);
                            sw = new StreamWriter(fs, Encoding.GetEncoding(_codeEncoding));
                            template.Render(sw);
                            errorsOutput = (StringBuilder) template.GetProperty("Errors");
                            warningsOutput = (StringBuilder) template.GetProperty("Warnings");
                            if (errorsOutput.Length > 0)
                            {
                                _errorReport.Add(new GenerationReport
                                                     {
                                                         ObjectName = "Utility",
                                                         ObjectType = step.ToString(),
                                                         Message = errorsOutput.ToString(),
                                                         FileName = fullFilename
                                                     });
                                OnGenerationInformation("* * Failed:" + Environment.NewLine + errorsOutput);
                                _fileSuccess[utilityFilename] = false;
                            }
                            else
                            {
                                if (warningsOutput != null)
                                {
                                    if (warningsOutput.Length > 0)
                                    {
                                        _warningReport.AddMultiline(new GenerationReport
                                                                        {
                                                                            ObjectName = "Utility",
                                                                            ObjectType = step.ToString(),
                                                                            Message = warningsOutput.ToString(),
                                                                            FileName = fullFilename
                                                                        });
                                        OnGenerationInformation("* Warning:" + Environment.NewLine + warningsOutput);
                                    }
                                }
                                //OnGenerationInformation("Success");
                                _fileSuccess[utilityFilename] = true;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    _fileSuccess[utilityFilename] = false;
                    var msg = ShowExceptionInformation(e);
                    _errorReport.Add(new GenerationReport
                    {
                        ObjectName = "Utility",
                        ObjectType = step.ToString(),
                        Message = msg,
                        FileName = fullFilename
                    });
                    OnGenerationInformation(msg);
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }
        }

        private string GetUtilitiesFolderPath(GenerationStep step)
        {
            // base directory of project
            var result = TargetDirectory + @"\";

            if (_unit.GenerationParams.SeparateNamespaces)// use namespace as folder
            {
                result += GetContextBaseNamespace(_unit, step) + @"\";
                if (_unit.GenerationParams.UtilitiesNamespace == _unit.GenerationParams.BaseNamespace)
                    return result;

                return result + _unit.GenerationParams.UtilitiesNamespace.Substring(_unit.GenerationParams.BaseNamespace.Length + 1) + @"\";
            }

            // use step for base folder to avoid the mess
            if (_unit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
                result += step + @"\";

            if (!_unit.GenerationParams.UtilitiesFolder.Equals(string.Empty))
                result += _unit.GenerationParams.UtilitiesFolder;

            if (result.EndsWith(@"\") == false)
                result += @"\";

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
                    throw new Exception(string.Format(
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

        private string ShowExceptionInformation(Exception e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("* * * Error:");
            sb.AppendLine(e.Message);
            sb.AppendLine("Stack Trace:");
            sb.AppendLine(e.StackTrace);
            return sb.ToString();
        }

        private void WriteToFile(string fileName, string data)
        {
            if (_unit.GenerationParams.BackupOldSource && File.Exists(fileName))
            {
                var oldFile = new FileInfo(fileName);
                if (File.Exists(fileName + ".old"))
                {
                    File.Delete(fileName + ".old");
                }
                oldFile.MoveTo(fileName + ".old");
            }

            StreamWriter sw = null;
            try
            {
                var fs = File.Open(fileName, FileMode.Create);
                sw = new StreamWriter(fs, Encoding.GetEncoding(_sprocEncoding));
                sw.Write(data);
            }
            catch (Exception e)
            {
                var errorDesc = string.Format("Error writing to file {0}: {1}", fileName, e.Message);
                OnGenerationInformation(errorDesc);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        #endregion

        #region Private Stored Procedures generation

        private bool NeedsDbFetch(CslaObjectInfo info)
        {
            var selfLoad = CslaTemplateHelperCS.IsChildSelfLoaded(info);
            return (!((info.ObjectType == CslaObjectType.EditableChildCollection ||
                       info.ObjectType == CslaObjectType.EditableChild) &&
                       !selfLoad));
        }

        private bool HasFetchCriteria(CslaObjectInfo info)
        {
            return (info.CriteriaObjects.Any(crit => crit.GetOptions.Procedure &&
                !string.IsNullOrEmpty(crit.GetOptions.ProcedureName)));

//            foreach (var crit in info.CriteriaObjects)
//                if (crit.GetOptions.Procedure && !string.IsNullOrEmpty(crit.GetOptions.ProcedureName))
//                    return true;
        }

        private bool HasInsUpdDelcriteria(CslaObjectInfo info)
        {
            return (info.InsertProcedureName != string.Empty) ||
                (info.UpdateProcedureName != string.Empty) ||
                (info.CriteriaObjects.Any(crit => crit.DeleteOptions.Procedure &&
                    !string.IsNullOrEmpty(crit.DeleteOptions.ProcedureName)));
        }

        private bool NeedsDbInsUpdDel(CslaObjectInfo info)
        {
            return (info.ObjectType != CslaObjectType.ReadOnlyObject
                    && info.ObjectType != CslaObjectType.ReadOnlyCollection
                    && info.ObjectType != CslaObjectType.EditableRootCollection
                    && info.ObjectType != CslaObjectType.DynamicEditableRootCollection
                    && info.ObjectType != CslaObjectType.EditableChildCollection
                    && info.ObjectType != CslaObjectType.NameValueList
                    && info.ObjectType != CslaObjectType.UnitOfWork);

            /*return info.ObjectType == CslaObjectType.DynamicEditableRoot ||
                   info.ObjectType == CslaObjectType.EditableChild ||
                   info.ObjectType == CslaObjectType.EditableRoot ||
                   info.ObjectType == CslaObjectType.EditableSwitchable;*/

        }

        private void GenerateAllSprocsFile(CslaObjectInfo info, string dir)
        {
            var filename = dir + @"\sprocs\" + info.ObjectName + ".sql";
//            var selfLoad = CslaTemplateHelperCS.GetSelfLoad(info);

            var proc = new StringBuilder();

//            if (!((info.ObjectType == CslaObjectType.EditableChildCollection ||
//                   info.ObjectType == CslaObjectType.EditableChild) && !selfLoad))

            //make sure we don't generate selects when we don't need to.
            if (NeedsDbFetch(info))
            {
                foreach (var crit in info.CriteriaObjects)
                {
                    if (crit.GetOptions.Procedure && !string.IsNullOrEmpty(crit.GetOptions.ProcedureName))
                    {
                        proc.AppendLine(GenerateProcedure(info, crit, "SelectProcedure.cst", crit.GetOptions.ProcedureName, filename));
                        filename = string.Empty;
                    }
                }
            }

            if (NeedsDbInsUpdDel(info))
            {
                //Insert
                if (info.InsertProcedureName != string.Empty)
                {
                    proc.AppendLine(GenerateProcedure(info, null, "InsertProcedure.cst", info.InsertProcedureName, filename));
                    filename = string.Empty;
                }

                //Update
                if (info.UpdateProcedureName != string.Empty)
                {
                    proc.AppendLine(GenerateProcedure(info, null, "UpdateProcedure.cst", info.UpdateProcedureName, filename));
                    filename = string.Empty;
                }

                //Delete
                if (info.ObjectType == CslaObjectType.EditableChild)
                {
                    if (info.DeleteProcedureName != string.Empty)
                    {
                        proc.AppendLine(GenerateProcedure(info, null, "DeleteProcedure.cst",
                                                              info.DeleteProcedureName, filename));
                            filename = string.Empty;
                    }
                }
                else
                {
                    foreach (var crit in info.CriteriaObjects)
                    {
                        if (crit.DeleteOptions.Procedure && !string.IsNullOrEmpty(crit.DeleteOptions.ProcedureName))
                        {
                            proc.AppendLine(GenerateProcedure(info, crit, "DeleteProcedure.cst",
                                                              crit.DeleteOptions.ProcedureName, filename));
                            filename = string.Empty;
                        }
                    }
                }
            }
            if (proc.Length > 0)
            {
                CheckDirectory(dir + @"\sprocs");
                WriteToFile(dir + @"\sprocs\" + info.ObjectName + ".sql", proc.ToString());
            }
        }

        private void GenerateSelectProcedure(CslaObjectInfo info, string dir)
        {
//            var lazyLoad = CslaTemplateHelperCS.GetLazyLoad(info);

//            if (!((info.ObjectType == CslaObjectType.EditableChildCollection ||
//                   info.ObjectType == CslaObjectType.EditableChild) && !lazyLoad))

            //make sure we don't generate selects when we don't need to.
            if (NeedsDbFetch(info))
            {
                foreach (var crit in info.CriteriaObjects)
                {
                    if (crit.GetOptions.Procedure && !string.IsNullOrEmpty(crit.GetOptions.ProcedureName))
                    {
                        var proc = GenerateProcedure(info, crit, "SelectProcedure.cst", crit.GetOptions.ProcedureName,
                                                        dir + @"\sprocs\" + crit.GetOptions.ProcedureName + ".sql");
                        CheckDirectory(dir + @"\sprocs");
                        WriteToFile(dir + @"\sprocs\" + crit.GetOptions.ProcedureName + ".sql", proc);
                    }
                }
            }
        }

        private void GenerateInsertProcedure(CslaObjectInfo info, string dir)
        {
            if (info.InsertProcedureName != string.Empty)
            {
                var proc = GenerateProcedure(info, null, "InsertProcedure.cst", info.InsertProcedureName, dir + @"\sprocs\" + info.InsertProcedureName + ".sql");
                CheckDirectory(dir + @"\sprocs");
                WriteToFile(dir + @"\sprocs\" + info.InsertProcedureName + ".sql", proc);
            }
        }

        private void GenerateUpdateProcedure(CslaObjectInfo info, string dir)
        {
            if (info.UpdateProcedureName != string.Empty)
            {
                var proc = GenerateProcedure(info, null, "UpdateProcedure.cst", info.UpdateProcedureName, dir + @"\sprocs\" + info.UpdateProcedureName + ".sql");
                CheckDirectory(dir + @"\sprocs");
                WriteToFile(dir + @"\sprocs\" + info.UpdateProcedureName + ".sql", proc);
            }
        }

        private void GenerateDeleteProcedure(CslaObjectInfo info, string dir)
        {
            if (info.ObjectType == CslaObjectType.EditableChild)
            {
                if (info.DeleteProcedureName != string.Empty)
                {
                    var proc = GenerateProcedure(info, null, "DeleteProcedure.cst", info.DeleteProcedureName,
                        dir + @"\sprocs\" + info.DeleteProcedureName + ".sql");
                    CheckDirectory(dir + @"\sprocs");
                    WriteToFile(dir + @"\sprocs\" + info.DeleteProcedureName + ".sql", proc);
                }
            }
            else
            {
                foreach (var crit in info.CriteriaObjects)
                {
                    if (crit.DeleteOptions.Procedure && !string.IsNullOrEmpty(crit.DeleteOptions.ProcedureName))
                    {
                        var proc = GenerateProcedure(info, crit, "DeleteProcedure.cst", crit.DeleteOptions.ProcedureName,
                            dir + @"\sprocs\" + crit.DeleteOptions.ProcedureName + ".sql");
                        CheckDirectory(dir + @"\sprocs");
                        WriteToFile(dir + @"\sprocs\" + crit.DeleteOptions.ProcedureName + ".sql", proc);
                    }
                }
            }
        }

        private string GenerateProcedure(CslaObjectInfo objInfo, Criteria crit, string templateName, string sprocName, string filename)
        {
            if (objInfo != null)
            {
                StringWriter sw = null;
                try
                {
                    if (templateName != string.Empty)
                    {
                        var path = _templatesDirectory + @"SProcs4\" + templateName;
                        var template = GetTemplate(objInfo, path);
                        if (template != null)
                        {
                            var errorsOutput = new StringBuilder();
                            var warningsOutput = new StringBuilder();
                            template.SetProperty("Errors", errorsOutput);
                            template.SetProperty("Warnings", warningsOutput);
                            if (crit != null)
                                template.SetProperty("Criteria", crit);
                            template.SetProperty("IncludeParentProperties", objInfo.DataSetLoadingScheme);
                            sw = new StringWriter();
                            if (!string.IsNullOrEmpty(filename))
                                OnGenerationFileName(filename);
                            template.Render(sw);
                            errorsOutput = (StringBuilder) template.GetProperty("Errors");
                            warningsOutput = (StringBuilder) template.GetProperty("Warnings");
                            if (errorsOutput.Length > 0)
                            {
                                _sprocFailed++;
                                _errorReport.Add(new GenerationReport
                                                     {
                                                         ObjectName = objInfo.ObjectName,
                                                         ObjectType = objInfo.ObjectType.ToString(),
                                                         Message = errorsOutput.ToString(),
                                                         FileName = filename
                                                     });
                                OnGenerationInformation("* * Failed:" + Environment.NewLine + errorsOutput);
                            }
                            else
                            {
                                if (warningsOutput != null)
                                {
                                    if (warningsOutput.Length > 0)
                                    {
                                        _sprocWarnings++;
                                        _warningReport.AddMultiline(new GenerationReport
                                                                        {
                                                                            ObjectName = objInfo.ObjectName,
                                                                            ObjectType = objInfo.ObjectType.ToString(),
                                                                            Message = warningsOutput.ToString(),
                                                                            FileName = filename
                                                                        });
                                        OnGenerationInformation("* Warning:" + Environment.NewLine + warningsOutput);
                                    }
                                }
                                _sprocSuccess++;
                                //OnGenerationInformation("Success");
                            }

                            var sproc = sw.ToString();
                            sproc = sproc.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n");
                            sproc = sproc.Replace("\r\n\r\n\r\n", "\r\n\r\n");
                            return sproc;
                        }
                    }
                }
                catch (Exception e)
                {
                    _sprocFailed++;
                    throw (new Exception("Error generating " + GetFileNameWithoutExtension(templateName) + ": " + sprocName, e));
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }
            return string.Empty;
        }

        #endregion

        #region Private File / Directory related methods

        internal static string GetContextBaseNamespace(CslaGeneratorUnit unit, GenerationStep step)
        {
            if (step == GenerationStep.Business)
                return unit.GenerationParams.BaseNamespace;

            if (step == GenerationStep.DalInterface)
                return unit.GenerationParams.DalInterfaceNamespace;

            //if (step == GenerationStep.DalObject)
            return unit.GenerationParams.DalObjectNamespace;
        }

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
                    throw new ApplicationException(string.Format("The output path could not be created. Check that the \"{0}\" unit exists.", dir));

                CheckDirectory(dir.Substring(0, dir.LastIndexOf(@"\")));
                Directory.CreateDirectory(dir);
            }
        }

        private string GetDirectoryForNamespace(string targetDir, CslaObjectInfo info, bool isBaseClass,
            string baseNamespace, bool isClassComment, GenerationStep step)
        {
            if (targetDir.EndsWith(@"\") == false)
                targetDir += @"\";

            if (_unit.GenerationParams.SeparateNamespaces) // use namespace as folder
            {
                var objectNamespace = info.ObjectNamespace;
                targetDir += baseNamespace;
                objectNamespace = objectNamespace.Substring(_unit.GenerationParams.BaseNamespace.Length);
                targetDir += objectNamespace.Replace(".", @"\");

                if (targetDir.EndsWith(@"\") == false)
                {
                    targetDir += @"\";
                }
            }
            else if (_unit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
            {
                targetDir += step + @"\";
            }

            if (!info.Folder.Trim().Equals(string.Empty))
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

        private string GetBaseFileName(CslaObjectInfo info, bool isBaseClass, string baseNamespace,
            bool isClassComment, GenerationStep step)
        {
            var fileNoExtension = GetFileNameWithoutExtension(info.FileName);

            if (step != GenerationStep.Business)
            {
                fileNoExtension += "Dal";
                if (step == GenerationStep.DalInterface)
                    fileNoExtension = "I" + fileNoExtension;
            }

            if (isBaseClass)
            {
                if (!string.IsNullOrEmpty(_unit.GenerationParams.BaseFilenameSuffix))
                    fileNoExtension += _unit.GenerationParams.BaseFilenameSuffix;
            }
            else if (isClassComment)
            {
                if (!string.IsNullOrEmpty(_unit.GenerationParams.ClassCommentFilenameSuffix))
                    fileNoExtension += _unit.GenerationParams.ClassCommentFilenameSuffix;
            }
            else
            {
                if (!string.IsNullOrEmpty(_unit.GenerationParams.ExtendedFilenameSuffix))
                    fileNoExtension += _unit.GenerationParams.ExtendedFilenameSuffix;
            }

            var fileExtension = GetFileExtension(info.FileName);
            if (fileExtension == string.Empty)
            {
                if (info.OutputLanguage == CodeLanguage.CSharp) fileNoExtension += ".cs";
                if (info.OutputLanguage == CodeLanguage.VB) fileNoExtension += ".vb";
            }
            else
            {
                fileNoExtension += fileExtension;
            }

            return GetDirectoryForNamespace(TargetDirectory, info,
                                         (isBaseClass && _unit.GenerationParams.SeparateBaseClasses),
                                         baseNamespace,
                                         (isClassComment && _unit.GenerationParams.SeparateClassComment), step) +
                                         fileNoExtension;
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
            return string.Empty;
        }

        private static string GetTemplateName(CslaObjectInfo info, GenerationStep step)
        {
            return GetTemplateName(info.ObjectType, step );
        }

        private static string GetTemplateName(CslaObjectType type, GenerationStep step)
        {
            if (step == GenerationStep.Business)
                return string.Format("{0}.cst", type);

            return string.Format("{0}_{1}.cst", type, step);
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
            OutputWindow.Current.AddOutputInfo(string.Format("{0}:", objectName));
        }

        private void OnFinalized(bool isProjectValid)
        {
            if (Finalized != null)
                Finalized(this, new EventArgs());
            OutputWindow.Current.AddOutputInfo("\r\nDone");

            if (isProjectValid)
            {
                var dbConnection = CslaTemplateHelperCS.GetConnectionName(_unit);
                if (_generateDatabaseClass)
                {
                    if (_fileSuccess["Database" + dbConnection] == null)
                        OutputWindow.Current.AddOutputInfo(string.Format("Database" + dbConnection + " classe: already exists."));
                    else if (_fileSuccess["Database" + dbConnection] == false)
                        OutputWindow.Current.AddOutputInfo(string.Format("Database" + dbConnection + " classe: failed."));
                }

                if (_fileSuccess["DataPortalHookArgs"] == null)
                    OutputWindow.Current.AddOutputInfo(string.Format("DataPortalHookArgs classe: already exists."));
                else if (_fileSuccess["DataPortalHookArgs"] == false)
                    OutputWindow.Current.AddOutputInfo(string.Format("DataPortalHookArgs classe: failed."));

                if (GeneratorController.Current.CurrentUnit.GenerationParams.GenerateDalInterface)
                {
                    if (_fileSuccess["IDalManager" + dbConnection] == null)
                        OutputWindow.Current.AddOutputInfo(string.Format("IDalManager" + dbConnection + " classe: already exists."));
                    else if (_fileSuccess["IDalManager" + dbConnection] == false)
                        OutputWindow.Current.AddOutputInfo(string.Format("IDalManager" + dbConnection + " classe: failed."));
                    if (_fileSuccess["DalFactory" + dbConnection] == null)
                        OutputWindow.Current.AddOutputInfo(string.Format("DalFactory" + dbConnection + " classe: already exists."));
                    else if (_fileSuccess["DalFactory" + dbConnection] == false)
                        OutputWindow.Current.AddOutputInfo(string.Format("DalFactory" + dbConnection + " classe: failed."));
                    if (_fileSuccess["DataNotFoundException"] == null)
                        OutputWindow.Current.AddOutputInfo(string.Format("DataNotFoundException classe: already exists."));
                    else if (_fileSuccess["DataNotFoundException"] == false)
                        OutputWindow.Current.AddOutputInfo(string.Format("DataNotFoundException classe: failed."));
                }

                if (GeneratorController.Current.CurrentUnit.GenerationParams.GenerateDalObject)
                {
                    if (_fileSuccess["DalManager" + dbConnection] == null)
                        OutputWindow.Current.AddOutputInfo(string.Format("DalManager" + dbConnection + " classe: already exists."));
                    else if (_fileSuccess["DalManager" + dbConnection] == false)
                        OutputWindow.Current.AddOutputInfo(string.Format("DalManager" + dbConnection + " classe: failed."));
                }

                if (_sprocWarnings > 0 || _objectWarnings > 0)
                    OutputWindow.Current.AddOutputInfo("");

                if (_sprocWarnings > 0)
                    OutputWindow.Current.AddOutputInfo(string.Format("SProc warnings: {0} object{1}.", _sprocWarnings,
                                                                     _sprocWarnings > 1 ? "s" : ""));

                if (_objectWarnings > 0)
                    OutputWindow.Current.AddOutputInfo(string.Format("Object warnings: {0} object{1}.", _objectWarnings,
                                                                     _objectWarnings > 1 ? "s" : ""));

                OutputWindow.Current.AddOutputInfo(string.Format("\r\nClasses: {0} generated. {1} failed.",
                                                                 (_objFailed + _objSuccess), _objFailed));
                OutputWindow.Current.AddOutputInfo(string.Format("Stored Procs: {0} generated. {1} failed.",
                                                                 (_sprocFailed + _sprocSuccess), _sprocFailed));
            }

            GeneratorController.Current.HasErrors = _errorReport.Count > 0;
            GeneratorController.Current.HasWarnings = _warningReport.Count > 0;
        }

        #endregion
    }
}
