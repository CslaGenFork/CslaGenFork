using System;
using System.ComponentModel;
using System.Data;

namespace CslaGenerator.Metadata
{
    public class GenerationParameters : INotifyPropertyChanged
    {
        #region State Fields

        private bool _saveBeforeGenerate = true;
        private TargetFramework _targetFramework = TargetFramework.CSLA40;
        private bool _backupOldSource = false;
        private bool _separateNamespaces = true;
        private bool _separateBaseClasses = false;
        private bool _activeObjects = false;
        private bool _useDotDesignerFileNameConvention = true;
        private bool _recompileTemplates = false;
        private bool _nullableSupport = false;
        private CodeLanguage _outputLanguage = CodeLanguage.CSharp;
        private CslaPropertyMode _propertyMode = CslaPropertyMode.Default;
        private UIEnvironment _generatedUIEnvironment = UIEnvironment.WinForms_WPF;
        private bool _useChildDataPortal = true;
        private Authorization _generateAuthorization = Authorization.FullSupport;
        private HeaderVerbosity _headerVerbosity = HeaderVerbosity.Full;
        private bool _useBypassPropertyChecks = true;
        private bool _useSingleCriteria = false;
        private bool _forceReadOnlyProperties = false;
        private string _baseFilenameSuffix = string.Empty;
        private string _extendedFilenameSuffix = string.Empty;
        private string _classCommentFilenameSuffix = string.Empty;
        private bool _separateClassComment = false;
        private string _utilitiesFolder = String.Empty;
        private string _utilitiesNamespace = String.Empty;
        private bool _generateSprocs = true;
        private bool _oneSpFilePerObject = true;
        private bool _onlyNeededSprocs = true;
        private bool _generateDatabaseClass = true;

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
                OnPropertyChanged("");
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
            get { return false; }
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

        public UIEnvironment GeneratedUIEnvironment
        {
            get { return _generatedUIEnvironment; }
            set
            {
                if (_generatedUIEnvironment == value)
                    return;
                _generatedUIEnvironment = value;
                OnPropertyChanged("");
            }
        }

        public bool UseChildDataPortal
        {
            get { return _useChildDataPortal; }
            set
            {
                if (_useChildDataPortal == value)
                    return;
                _useChildDataPortal = value;
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

        public string UtilitiesNamespace
        {
            get { return _utilitiesNamespace; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_');
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

        public bool OnlyNeededSprocs
        {
            get { return _onlyNeededSprocs; }
            set
            {
                if (_onlyNeededSprocs == value)
                    return;
                _onlyNeededSprocs = value;
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

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            _Dirty = true;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool _Dirty = false;
        [Browsable(false)]
        internal bool Dirty
        {
            get { return _Dirty; }
            set
            {
                _Dirty = value;
            }
        }

        #endregion

        internal GenerationParameters Clone()
        {
            GenerationParameters obj = null;
            try
            {
                obj = (GenerationParameters)Util.ObjectCloner.CloneShallow(this);
                obj._Dirty = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return obj;
        }

    }
}