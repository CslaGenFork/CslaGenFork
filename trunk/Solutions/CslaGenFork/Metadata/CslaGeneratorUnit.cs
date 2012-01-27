using System;
using System.Diagnostics;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for CslaGeneratorUnit.
    /// </summary>
    [Serializable]
    public class CslaGeneratorUnit
    {
        private CslaObjectInfoCollection _cslaObjects = new CslaObjectInfoCollection();
        private AssociativeEntityCollection _associativeEntities = new AssociativeEntityCollection();
        private string _connectionString = String.Empty;
        private string _projectName = String.Empty;
        private string _targetDirectory = String.Empty;
        private string _fileVersion = CslaGenerator.FileVersion.CurrentFileVersion;
        private ProjectParameters _projectParams = new ProjectParameters();
        private GenerationParameters _generationParams = new GenerationParameters();
        internal Stopwatch GenerationTimer = new Stopwatch();

        public CslaGeneratorUnit()
        {
            _cslaObjects = new CslaObjectInfoCollection();
            _projectName = "MyProject";
        }

        public ProjectParameters Params
        {
            get { return _projectParams; }
            set { if (value != null) { _projectParams = value; } }
        }

        public GenerationParameters GenerationParams
        {
            get
            {
                return _generationParams;
            }
            set
            {
                if (value != null)
                    _generationParams = value;
            }
        }

        public CslaObjectInfoCollection CslaObjects
        {
            get { return _cslaObjects; }
            set { _cslaObjects = value; }
        }

        public AssociativeEntityCollection AssociativeEntities
        {
            get { return _associativeEntities; }
            set { _associativeEntities = value; }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                if (_projectName != value)
                {
                    _projectName = value;
                    OnProjectNameChanged();
                }
            }
        }

        public string TargetDirectory
        {
            get { return _targetDirectory; }
            set
            {
                if (_targetDirectory != value)
                {
                    _targetDirectory = value;
                    OnTargetDirectoryChanged();
                }
            }
        }

        public string FileVersion
        {
            get { return CslaGenerator.FileVersion.CurrentFileVersion; }
            set { _fileVersion = value; }
        }

        [field: NonSerialized]
        public event EventHandler ProjectNameChanged;

        protected void OnProjectNameChanged()
        {
            if (ProjectNameChanged != null)
            {
                ProjectNameChanged(this, EventArgs.Empty);
            }
        }

        [field: NonSerialized]
        public event EventHandler TargetDirectoryChanged;

        protected void OnTargetDirectoryChanged()
        {
            if (TargetDirectoryChanged != null)
            {
                TargetDirectoryChanged(this, EventArgs.Empty);
            }
        }

        public void ResetParent()
        {
            foreach (var info in _cslaObjects)
            {
                info.Parent = this;
            }
            foreach (var info in _associativeEntities)
            {
                info.Parent = this;
            }
        }
    }
}
