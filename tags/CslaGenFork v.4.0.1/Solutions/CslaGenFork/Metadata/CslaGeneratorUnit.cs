using System;
using System.ComponentModel;
using System.Data;
using CslaGenerator.Controls;

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
        private ProjectParameters mParams = new ProjectParameters();
        private GenerationParameters _GenerationParams = new GenerationParameters();

        public CslaGeneratorUnit()
        {
            _cslaObjects = new CslaObjectInfoCollection();
            _projectName = "Project";
        }

        public ProjectParameters Params
        {
            get { return mParams; }
            set { if (value != null) { mParams= value; }}
        }

        public GenerationParameters GenerationParams
        {
            get
            {
                return _GenerationParams;
            }
            set
            {
                if (value != null)
                    _GenerationParams = value;
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

        [field : NonSerialized]
        public event EventHandler ProjectNameChanged;

        protected void OnProjectNameChanged()
        {
            if (ProjectNameChanged != null)
            {
                ProjectNameChanged(this,EventArgs.Empty);
            }
        }

        [field : NonSerialized]
        public event EventHandler TargetDirectoryChanged;

        protected void OnTargetDirectoryChanged()
        {
            if (TargetDirectoryChanged != null)
            {
                TargetDirectoryChanged(this,EventArgs.Empty);
            }
        }

        public void ResetParent()
        {
            foreach(CslaObjectInfo info in _cslaObjects)
            {
                info.Parent = this;
            }
            foreach(AssociativeEntity info in _associativeEntities)
            {
                info.Parent = this;
            }
        }
    }
}
