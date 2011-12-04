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
        private AuthorizationLevel _generateAuthorization = AuthorizationLevel.FullSupport;
        private HeaderVerbosity _headerVerbosity = HeaderVerbosity.Full;
        private bool _useBypassPropertyChecks;
        private bool _useSingleCriteria;
        private bool _usePublicPropertyInfo;
        private bool _useChildFactory;
        private bool _forceReadOnlyProperties;
        private string _baseFilenameSuffix = string.Empty;
        private string _extendedFilenameSuffix = string.Empty;
        private string _classCommentFilenameSuffix = string.Empty;
        private bool _separateClassComment;
        private string _baseNamespace = String.Empty;
        private string _utilitiesNamespace = String.Empty;
        private string _utilitiesFolder = String.Empty;
        private string _dalInterfaceNamespace = "DataAccess";
        private string _dalObjectNamespace = "DataAccess.Sql";
        private bool _generateSprocs = true;
        private bool _oneSpFilePerObject = true;
        private bool _generateInlineQueries;
        private bool _generateQueriesWithSchema = true;
        private bool _generateDatabaseClass = true;
        private bool _useConnectionName = true;
        private bool _usesCslaAuthorizationProvider = true;
        private bool _generateWinForms = true;
        private bool _generateWPF;
        private bool _generateSilverlight;
        private bool _silverlightUsingServices;
        private string _databaseConnection;
        private TargetDto _useDto = TargetDto.MoreThan;
        private int _dtoLimit = 7;
        private bool _generateDalInterface = true;
        private bool _generateDalObject = true;
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
            get { return BaseFilenameSuffix == ".Designer"; }
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

        public AuthorizationLevel GenerateAuthorization
        {
            get { return _generateAuthorization; }
            set
            {
                if (_generateAuthorization == value)
                    return;
                _generateAuthorization = value;
                OnPropertyChanged("GenerateAuthorization");
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

        public bool UseChildFactory
        {
            get { return _useChildFactory; }
            set
            {
                if (_useChildFactory == value)
                    return;
                _useChildFactory = value;
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
                value = PropertyHelper.TidyFilename(value);
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
                value = PropertyHelper.TidyFilename(value);
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
                value = PropertyHelper.TidyFilename(value);
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
                value = PropertyHelper.TidyFilename(value);
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
                value = PropertyHelper.TidyFilename(value);
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
                value = PropertyHelper.TidyFilename(value);
                if (_utilitiesFolder == value)
                    return;
                _utilitiesFolder = value;
                OnPropertyChanged("");
            }
        }

        public string DalInterfaceNamespace
        {
            get { return _dalInterfaceNamespace; }
            set
            {
                value = PropertyHelper.TidyFilename(value);
                if (_dalInterfaceNamespace == value)
                    return;
                _dalInterfaceNamespace = value;
                OnPropertyChanged("");
            }
        }

        public string DalObjectNamespace
        {
            get { return _dalObjectNamespace; }
            set
            {
                value = PropertyHelper.TidyFilename(value);
                if (_dalObjectNamespace == value)
                    return;
                _dalObjectNamespace = value;
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
                OnPropertyChanged("GenerateSprocs");
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
        public bool UseConnectionName
        {
            get { return _useConnectionName; }
            set
            {
                if (_useConnectionName == value)
                    return;
                _useConnectionName = value;
                OnPropertyChanged("");
            }
        }

        public bool UsesCslaAuthorizationProvider
        {
            get { return _usesCslaAuthorizationProvider; }
            set
            {
                if (_usesCslaAuthorizationProvider == value)
                    return;
                _usesCslaAuthorizationProvider = value;
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

        public bool SilverlightUsingServices
        {
            get { return _silverlightUsingServices; }
            set
            {
                if (_silverlightUsingServices == value)
                    return;
                _silverlightUsingServices = value;
                OnPropertyChanged("SilverlightUsingServices");
            }
        }

        public string DatabaseConnection
        {
            get
            {
                if (string.IsNullOrEmpty(_databaseConnection))
                    if (GeneratorController.Current.CurrentUnit.Params != null)
                        return GeneratorController.Current.CurrentUnit.Params.DefaultDataBase;

                return _databaseConnection;
            }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (_databaseConnection == value)
                    return;
                _databaseConnection = value;
                GeneratorController.Current.CurrentUnit.Params.DefaultDataBase = value;
                OnPropertyChanged("");
            }
        }


        public TargetDto UseDto
        {
            get { return _useDto; }
            set
            {
                if (_useDto == value)
                    return;
                _useDto = value;
                OnPropertyChanged("UseDto");
            }
        }

        public int DtoLimit
        {
            get { return _dtoLimit; }
            set
            {
                if (_dtoLimit == value)
                    return;
                _dtoLimit = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateDalInterface
        {
            get { return _generateDalInterface; }
            set
            {
                if (_generateDalInterface == value)
                    return;
                _generateDalInterface = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateDalObject
        {
            get { return _generateDalObject; }
            set
            {
                if (_generateDalObject == value)
                    return;
                _generateDalObject = value;
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
                    SetServerInvocationOptions();
                if (propertyName == "GenerateWPF")
                    SetServerInvocationOptions();
                if (propertyName == "GenerateSilverlight4")
                {
                    if (_generateSilverlight)
                        _silverlightUsingServices = false;
                    SetServerInvocationOptions();
                }
                if (propertyName == "SilverlightUsingServices")
                {
                    if (_silverlightUsingServices)
                        _generateSilverlight = false;
                    SetServerInvocationOptions();
                }
                if (propertyName == "GenerateSynchronous")
                    SetServerInvocationOptions();
                if (propertyName == "GenerateAsynchronous")
                    SetServerInvocationOptions();
                if (propertyName == "GenerateAuthorization")
                {
                    if (_generateAuthorization == AuthorizationLevel.None ||
                        _generateAuthorization == AuthorizationLevel.Custom)
                        _usesCslaAuthorizationProvider = false;
                }
            }

            Dirty = true;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetCsla4Options()
        {
            UseCsla4 = false;
            UseDal = false;
            _generateDalInterface = false;
            _generateDalObject = false;

            if (_targetFramework == TargetFramework.CSLA40 || _targetFramework == TargetFramework.CSLA40DAL)
            {
                UseCsla4 = true;
                _activeObjects = false;
                _useSingleCriteria = false;
            }
            else
            {
                _usesCslaAuthorizationProvider = true;
                _generateAuthorization = AuthorizationLevel.ObjectLevel;
                _usesCslaAuthorizationProvider = true;
            }

            if (_targetFramework == TargetFramework.CSLA40DAL)
            {
                UseDal = true;
                _generateDalInterface = true;
                _generateDalObject = true;
                _silverlightUsingServices = false;
                _generateDatabaseClass = false;
            }
        }

        private void SetServerInvocationOptions()
        {
            ForceSync = false;
            ForceAsync = false;

            if (_generateSilverlight && (_generateWinForms || _generateWPF))
            {
                _generateAsynchronous = true;
                ForceAsync = true;
            }

            if (_silverlightUsingServices && !(_generateWinForms || _generateWPF))
            {
                _generateSynchronous = false;
                _generateAsynchronous = false;
                ForceSync = true;
                ForceAsync = true;
            }
        }

        [Browsable(false)]
        internal bool UseCsla4 { get; private set; }

        [Browsable(false)]
        internal bool UseDal { get; private set; }

        [Browsable(false)]
        internal bool ForceSync { get; private set; }

        [Browsable(false)]
        internal bool ForceAsync { get; private set; }

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
            OnPropertyChanged("GenerateAuthorization");
            OnPropertyChanged("UseDto");
            OnPropertyChanged("GenerateSprocs");
        }
    }
}
