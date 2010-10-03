using System;
using System.ComponentModel;
using System.Data;

namespace CslaGenerator.Metadata
{
    public class GenerationParameters : INotifyPropertyChanged
    {
        #region State Fields

        private TargetFramework _TargetFramework = TargetFramework.CSLA40;
        bool _BackupOldSource = false;
        bool _SeparateNamespaces = true;
        bool _SeparateBaseClasses = false;
        bool _GenerateSprocs = true;
        bool _ActiveObjects = false;
        bool _OneSpFilePerObject = true;
        bool _UseDotDesignerFileNameConvention = true;
        bool _SaveBeforeGenerate = true;
        bool _RecompileTemplates = false;
        bool _NullableSupport = false;
        CodeLanguage _OutputLanguage = CodeLanguage.CSharp;
        CslaPropertyMode _PropertyMode = CslaPropertyMode.Default;
        UIEnvironment _generatedUIEnvironment = UIEnvironment.WinForms_WPF;
        private bool _useChildDataPortal = true;
        bool _generateDatabaseClass = true;
        Authorization _generateAuthorization = Authorization.FullSupport;
        HeaderVerbosity _headerVerbosity = HeaderVerbosity.Full;
        bool _useBypassPropertyChecks = true;
        private string _baseFilenameSuffix = string.Empty;
        private string _extendedFilenameSuffix = string.Empty;
        private string _classCommentFilenameSuffix = string.Empty;
        bool _separateClassComment = false;
        private string _utilitiesFolder = String.Empty;
        private string _utilitiesNamespace = String.Empty;

        #endregion

        #region Properties

        public bool SaveBeforeGenerate
        {
            get { return _SaveBeforeGenerate; }
            set
            {
                if (_SaveBeforeGenerate == value)
                    return;
                _SaveBeforeGenerate = value;
                OnPropertyChanged("");
            }
        }

        public TargetFramework TargetFramework
        {
            get
            {
                return _TargetFramework;
            }
            set
            {
                if (_TargetFramework == value)
                    return;
                _TargetFramework = value;
                OnPropertyChanged("");
            }
        }

        public bool BackupOldSource
        {
            get
            {
                return _BackupOldSource;
            }
            set
            {
                if (_BackupOldSource == value)
                    return;
                _BackupOldSource = value;
                OnPropertyChanged("");
            }
        }

        public bool SeparateNamespaces
        {
            get
            {
                return _SeparateNamespaces;
            }
            set
            {
                if (_SeparateNamespaces == value)
                    return;
                _SeparateNamespaces = value;
                OnPropertyChanged("");
            }
        }

        public bool SeparateBaseClasses
        {
            get
            {
                return _SeparateBaseClasses;
            }
            set
            {
                if (_SeparateBaseClasses == value)
                    return;
                _SeparateBaseClasses = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateSprocs
        {
            get
            {
                return _GenerateSprocs;
            }
            set
            {
                if (_GenerateSprocs == value)
                    return;
                _GenerateSprocs = value;
                OnPropertyChanged("");
            }
        }

        public bool ActiveObjects
        {
            get
            {
                return _ActiveObjects;
            }
            set
            {
                if (_ActiveObjects == value)
                    return;
                _ActiveObjects = value;
                OnPropertyChanged("");
            }
        }

        public bool OneSpFilePerObject
        {
            get
            {
                return _OneSpFilePerObject;
            }
            set
            {
                if (_OneSpFilePerObject == value)
                    return;
                _OneSpFilePerObject = value;
                OnPropertyChanged("");
            }
        }

        public bool UseDotDesignerFileNameConvention
        {
            get
            {
                //return _UseDotDesignerFileNameConvention;
                return false;
            }
            set
            {
                if (value)
                    BaseFilenameSuffix = ".Designer";
                if (_UseDotDesignerFileNameConvention == value)
                    return;
                _UseDotDesignerFileNameConvention = value;
                OnPropertyChanged("");
            }
        }

        public bool RecompileTemplates
        {
            get
            {
                return _RecompileTemplates;
            }
            set
            {
                if (_RecompileTemplates == value)
                    return;
                _RecompileTemplates = value;
                OnPropertyChanged("");
            }
        }
        
        public CodeLanguage OutputLanguage
        {
            get
            {
                return _OutputLanguage;
            }
            set
            {
                if (_OutputLanguage == value)
                    return;
                _OutputLanguage = value;
                OnPropertyChanged("");
            }
        }

        public bool NullableSupport
        {
            get { return _NullableSupport; }
            set
            {
                if (_NullableSupport == value)
                    return;
                _NullableSupport = value;
                OnPropertyChanged("");
                
            }
        }

        public CslaPropertyMode PropertyMode
        {
            get
            {
                return _PropertyMode;
            }
            set
            {
                if (_PropertyMode == value)
                    return;
                _PropertyMode = value;
                OnPropertyChanged("");
            }
        }

        public UIEnvironment GeneratedUIEnvironment
        {
            get
            {
                return _generatedUIEnvironment;
            }
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
            get
            {
                return _useChildDataPortal;
            }
            set
            {
                if (_useChildDataPortal == value)
                    return;
                _useChildDataPortal = value;
                OnPropertyChanged("");
            }
        }

        public bool GenerateDatabaseClass
        {
            get
            {
                return _generateDatabaseClass;
            }
            set
            {
                if (_generateDatabaseClass == value)
                    return;
                _generateDatabaseClass = value;
                OnPropertyChanged("");
            }
        }

        public Authorization GenerateAuthorization
        {
            get 
            {
                return _generateAuthorization;
            }
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
            get
            {
                return _headerVerbosity;
            }
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
            get
            {
                return _useBypassPropertyChecks;
            }
            set
            {
                if (_useBypassPropertyChecks == value)
                    return;
                _useBypassPropertyChecks = value;
                OnPropertyChanged("");
            }
        }

        public string BaseFilenameSuffix
        {
            get
            {
                return _baseFilenameSuffix;
            }
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
            get
            {
                return _extendedFilenameSuffix;
            }
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
            get
            {
                return _classCommentFilenameSuffix;
            }
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
        /// 	<c>true</c> if Separate class comments in a folder; otherwise, <c>false</c>.
        /// </value>
        public bool SeparateClassComment
        {
            get
            {
                return _separateClassComment;
            }
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
            get
            {
                return _utilitiesNamespace;
            }
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
            get
            {
                return _utilitiesFolder;
            }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_');
                if (_utilitiesFolder == value)
                    return;
                _utilitiesFolder = value;
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
        private bool _Dirty=false;
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
