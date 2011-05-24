using System;
using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public class GenerationParameters : INotifyPropertyChanged
    {
        #region State Fields

        private bool _saveBeforeGenerate = true;
        private TargetFramework _targetFramework = TargetFramework.CSLA40;
        private bool _backupOldSource;
        private bool _separateNamespaces = true;
        private bool _separateBaseClasses;
        private bool _activeObjects;
        private bool _useDotDesignerFileNameConvention = true;
        private bool _recompileTemplates;
        private bool _nullableSupport;
        private CodeLanguage _outputLanguage = CodeLanguage.CSharp;
        private CslaPropertyMode _propertyMode = CslaPropertyMode.Default;
        private Authorization _generateAuthorization = Authorization.FullSupport;
        private HeaderVerbosity _headerVerbosity = HeaderVerbosity.Full;
        private bool _useBypassPropertyChecks;
        private bool _useSingleCriteria;
        private bool _usePublicPropertyInfo;
        private bool _forceReadOnlyProperties;
        private string _baseFilenameSuffix = string.Empty;
        private string _extendedFilenameSuffix = string.Empty;
        private string _classCommentFilenameSuffix = string.Empty;
        private bool _separateClassComment;
        private string _baseNamespace = String.Empty;
        private string _utilitiesNamespace = String.Empty;
        private string _utilitiesFolder = String.Empty;
        private string _interfaceDALNamespace = "DataAccess";
        private string _dalNamespace = "DataAccess.Sql";
        private bool _generateSprocs = true;
        private bool _oneSpFilePerObject = true;
        private bool _generateInlineQueries;
        private bool _generateQueriesWithSchema = true;
        private bool _generateDatabaseClass = true;
        private bool _generateWinForms = true;
        private bool _generateWPF;
        private bool _generateSilverlight;
        private TargetDAL _targetDAL = TargetDAL.None;
        private bool _generateDAL = true;
        private bool _generateSynchronous = true;
        private bool _generateAsynchronous;

        #endregion

        #region Properties

        public bool SaveBeforeGenerate
        {
            get { return _saveBeforeGenerate; }
            set
            {
                if (_saveBeforeGenerate == value)
                    return;
                _saveBeforeGenerate = value;
                OnPropertyChanged("");
            }
        }

        public TargetFramework TargetFramework
        {
            get { return _targetFramework; }
            set
            {
                if (_targetFramework == value)
                    return;
                _targetFramework = value;
                OnPropertyChanged("TargetFramework");
            }
        }

        public bool BackupOldSource
        {
            get { return _backupOldSource; }
            set
            {
                if (_backupOldSource == value)
                    return;
                _backupOldSource = value;
                OnPropertyChanged("");
            }
        }

        public bool SeparateNamespaces
        {
            get { return _separateNamespaces; }
            set
            {
                if (_separateNamespaces == value)
                    return;
                _separateNamespaces = value;
                OnPropertyChanged("");
            }
        }

        public bool SeparateBaseClasses
        {
            get { return _separateBaseClasses; }
            set
            {
                if (_separateBaseClasses == value)
                    return;
                _separateBaseClasses = value;
                OnPropertyChanged("");
            }
        }

        public bool ActiveObjects
        {
            get { return _activeObjects; }
            set
            {
                if (_activeObjects == value)
                    return;
                _activeObjects = value;
                OnPropertyChanged("");
            }
        }

        public bool UseDotDesignerFileNameConvention
        {
            get
            {
                return BaseFilenameSuffix == ".Designer";
            }
            set
            {
                if (value)
                    BaseFilenameSuffix = ".Designer";
                if (_useDotDesignerFileNameConvention == value)
                    return;
                _useDotDesignerFileNameConvention = value;
                OnPropertyChanged("");
            }
        }

        [Browsable(false)]
        public bool RecompileTemplates
        {
            get { return _recompileTemplates; }
            set
            {
                if (_recompileTemplates == value)
                    return;
                _recompileTemplates = value;
                OnPropertyChanged("");
            }
        }

        public CodeLanguage OutputLanguage
        {
            get { return _outputLanguage; }
            set
            {
                if (_outputLanguage == value)
                    return;
                _outputLanguage = value;
                OnPropertyChanged("");
            }
        }

        public bool NullableSupport
        {
            get { return _nullableSupport; }
            set
            {
                if (_nullableSupport == value)
                    return;
                _nullableSupport = value;
                OnPropertyChanged("");

            }
        }

        public CslaPropertyMode PropertyMode
        {
            get { return _propertyMode; }
            set
            {
                if (_propertyMode == value)
                    return;
                _propertyMode = value;
                OnPropertyChanged("");
            }
        }

        public Authorization GenerateAuthorization
        {
            get { return _generateAuthorization; }
            set
            {
                if (_generateAuthorization == value)
                    return;
                _generateAuthorization = value;
                OnPropertyChanged("");
            }
        }

        public HeaderVerbosity HeaderVerbosity
        {
            get { return _headerVerbosity; }
            set
            {
                if (_headerVerbosity == value)
                    return;
                _headerVerbosity = value;
                OnPropertyChanged("");
            }
        }

        public bool UseBypassPropertyChecks
        {
            get { return _useBypassPropertyChecks; }
            set
            {
                if (_useBypassPropertyChecks == value)
                    return;
                _useBypassPropertyChecks = value;
                OnPropertyChanged("");
            }
        }

        public bool UseSingleCriteria
        {
            get { return _useSingleCriteria; }
            set
            {
                if (_useSingleCriteria == value)
                    return;
                _useSingleCriteria = value;
                OnPropertyChanged("");
            }
        }

        public bool UsePublicPropertyInfo
        {
            get { return _usePublicPropertyInfo; }
            set
            {
                if (_usePublicPropertyInfo == value)
                    return;
                _usePublicPropertyInfo = value;
                OnPropertyChanged("");
            }
        }

        public bool ForceReadOnlyProperties
        {
            get { return _forceReadOnlyProperties; }
            set
            {
                if (_forceReadOnlyProperties == value)
                    return;
                _forceReadOnlyProperties = value;
                OnPropertyChanged("");
            }
        }

        public string BaseFilenameSuffix
        {
            get { return _baseFilenameSuffix; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_');
                if (_baseFilenameSuffix == value)
                    return;
                _baseFilenameSuffix = value;
                OnPropertyChanged("");
            }
        }

        public string ExtendedFilenameSuffix
        {
            get { return _extendedFilenameSuffix; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_');
                if (_extendedFilenameSuffix == value)
                    return;
                _extendedFilenameSuffix = value;
                OnPropertyChanged("");
            }
        }

        public string ClassCommentFilenameSuffix
        {
            get { return _classCommentFilenameSuffix; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_');
                if (_classCommentFilenameSuffix == value)
                    return;
                _classCommentFilenameSuffix = value;
                OnPropertyChanged("");
            }
        }

        /// <summary>
        /// Separate class comments in a folder.
        /// </summary>
        /// <value>
        ///     <c>true</c> if Separate class comments in a folder; otherwise, <c>false</c>.
        /// </value>
        public bool SeparateClassComment
        {
            get { return _separateClassComment; }
            set
            {
                if (_separateClassComment == value)
                    return;
                _separateClassComment = value;
                OnPropertyChanged("");
            }
        }

        public string BaseNamespace
        {
            get { return _baseNamespace; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_').Replace('\\', '.').Replace('/', '.');
                if (_baseNamespace == value)
                    return;
                _baseNamespace = value;
                OnPropertyChanged("");
            }
        }

        public string UtilitiesNamespace
        {
            get { return _utilitiesNamespace; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_').Replace('\\', '.').Replace('/', '.');
                if (_utilitiesNamespace == value)
                    return;
                _utilitiesNamespace = value;
                OnPropertyChanged("");
            }
        }

        public string UtilitiesFolder
        {
            get { return _utilitiesFolder; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_');
                if (_utilitiesFolder == value)
                    return;
                _utilitiesFolder = value;
                OnPropertyChanged("");
            }
        }

        public string InterfaceDALNamespace
        {
            get { return _interfaceDALNamespace; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_').Replace('\\', '.').Replace('/', '.');
                if (_interfaceDALNamespace == value)
                    return;
                _interfaceDALNamespace = value;
                OnPropertyChanged("");
            }
        }

        public string DALNamespace
        {
            get { return _dalNamespace; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_').Replace('\\', '.').Replace('/', '.');
                if (_dalNamespace == value)
                    return;
                _dalNamespace = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateSprocs
        {
            get { return _generateSprocs; }
            set
            {
                if (_generateSprocs == value)
                    return;
                _generateSprocs = value;
                OnPropertyChanged("");
            }
        }

        public bool OneSpFilePerObject
        {
            get { return _oneSpFilePerObject; }
            set
            {
                if (_oneSpFilePerObject == value)
                    return;
                _oneSpFilePerObject = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateInlineQueries
        {
            get { return _generateInlineQueries; }
            set
            {
                if (_generateInlineQueries == value)
                    return;
                _generateInlineQueries = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateQueriesWithSchema
        {
            get { return _generateQueriesWithSchema; }
            set
            {
                if (_generateQueriesWithSchema == value)
                    return;
                _generateQueriesWithSchema = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateDatabaseClass
        {
            get { return _generateDatabaseClass; }
            set
            {
                if (_generateDatabaseClass == value)
                    return;
                _generateDatabaseClass = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateWinForms
        {
            get { return _generateWinForms; }
            set
            {
                if (_generateWinForms == value)
                    return;
                _generateWinForms = value;
                OnPropertyChanged("GenerateWinForms");
            }
        }

        public bool GenerateWPF
        {
            get { return _generateWPF; }
            set
            {
                if (_generateWPF == value)
                    return;
                _generateWPF = value;
                OnPropertyChanged("GenerateWPF");
            }
        }

        public bool GenerateSilverlight4
        {
            get { return _generateSilverlight; }
            set
            {
                if (_generateSilverlight == value)
                    return;
                _generateSilverlight = value;
                OnPropertyChanged("GenerateSilverlight4");
            }
        }

        public TargetDAL TargetDAL
        {
            get { return _targetDAL; }
            set
            {
                if (_targetDAL == value)
                    return;
                _targetDAL = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateDAL
        {
            get { return _generateDAL; }
            set
            {
                if (_generateDAL == value)
                    return;
                _generateDAL = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateSynchronous
        {
            get { return _generateSynchronous; }
            set
            {
                if (_generateSynchronous == value)
                    return;
                _generateSynchronous = value;
                OnPropertyChanged("GenerateSynchronous");
            }
        }

        public bool GenerateAsynchronous
        {
            get { return _generateAsynchronous; }
            set
            {
                if (_generateAsynchronous == value)
                    return;
                _generateAsynchronous = value;
                OnPropertyChanged("GenerateAsynchronous");
            }
        }

        [Browsable(false)]
        public bool DualListInheritance
        {
            get { return GenerateWinForms && (GenerateWPF || GenerateSilverlight4); }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                if (propertyName == "TargetFramework")
                    SetCsla4Options();
                if (propertyName == "GenerateWinForms")
                    SetAsyncUIOptions();
                if (propertyName == "GenerateWPF")
                    SetAsyncUIOptions();
                if (propertyName == "GenerateSilverlight4")
                    SetAsyncUIOptions();
                if (propertyName == "GenerateSynchronous")
                    SetAsyncUIOptions();
                if (propertyName == "GenerateAsynchronous")
                    SetAsyncUIOptions();
            }

            Dirty = true;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetCsla4Options()
        {
            UseCsla4 = false;
            UseCsla4 = false;
            _targetDAL = TargetDAL.None;
            UseDal = false;
            _generateDAL = false;

            if (_targetFramework == TargetFramework.CSLA40 || _targetFramework == TargetFramework.CSLA40DAL)
            {
                UseCsla4 = true;
                _activeObjects = false;
                _useSingleCriteria = false;
            }

            if (_targetFramework == TargetFramework.CSLA40DAL)
            {
                UseDal = true;
                _targetDAL = TargetDAL.Simple;
                _generateDAL = true;
            }
        }

        private void SetAsyncUIOptions()
        {
            if (_generateSilverlight)
            {
                _generateAsynchronous = true;
                ForceAsyncUI = true;
            }
            else
            {
                ForceAsyncUI = false;
            }

            if (!(_generateWinForms || _generateWPF))
            {
                _generateSynchronous = false;
                ForceSyncUI = true;
            }
            else
            {
                ForceSyncUI = false;
            }
        }

        [Browsable(false)]
        internal bool UseCsla4 { get; private set; }

        [Browsable(false)]
        internal bool UseDal { get; private set; }

        [Browsable(false)]
        internal bool ForceSyncUI { get; private set; }

        [Browsable(false)]
        internal bool ForceAsyncUI { get; private set; }

        [Browsable(false)]
        internal bool Dirty { get; set; }

        #endregion

        internal GenerationParameters Clone()
        {
            GenerationParameters obj = null;
            try
            {
                obj = (GenerationParameters)Util.ObjectCloner.CloneShallow(this);
                obj.Dirty = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return obj;
        }

        public GenerationParameters()
        {
            OnPropertyChanged("TargetFramework");
            OnPropertyChanged("GenerateWinForms");
            OnPropertyChanged("GenerateWPF");
            OnPropertyChanged("GenerateSilverlight4");
            OnPropertyChanged("GenerateSynchronous");
            OnPropertyChanged("GenerateAsynchronous");
        }
    }
}
