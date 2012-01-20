using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using CslaGenerator.Controls;
using CslaGenerator.Data;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using CslaGenerator.Util.PropertyBags;
using DBSchemaInfo.Base;

namespace CslaGenerator
{
    public class GeneratorController : IDisposable
    {
        #region Private Fields

        private string[] _commandlineArgs;
        private CslaGeneratorUnit _currentUnit;
        private CslaObjectInfo _currentCslaObject;
        private AssociativeEntity _currentAssociativeEntitiy;
        private ProjectProperties _currentPropertiesTab;
        private string _currentFilePath = string.Empty;
        private MainForm _mainForm;
        private static ICatalog _catalog;
        private static GeneratorController _current;
        private readonly PropertyContext _propertyContext = new PropertyContext();
        private DbSchemaPanel _dbSchemaPanel;
        public bool IsLoading;

        #endregion

        #region Constructors/Dispose

        public GeneratorController()
        {
            Init();
            _current = this;
            GetConfig();
        }

        private void Init()
        {
            _mainForm = new MainForm(this);
            _mainForm.ProjectPanel.SelectedItemsChanged += CslaObjectList_SelectedItemsChanged;
            _mainForm.ProjectPanel.LastItemRemoved += delegate { _currentCslaObject = null; };
            _mainForm.ObjectRelationsBuilder.SelectedItemsChanged += AssociativeEntitiesList_SelectedItemsChanged;
            _mainForm.Show();
            _mainForm.formSizePosition1.RestoreFormSizePosition();
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// Processes command line args passed to CSLA Gen.  Called after the generator is created.
        /// </summary>
        private void ProcessCommandLineArgs()
        {
            if (CommandLineArgs.Length > 0)
            {
                string filename = CommandLineArgs[0];
                if (File.Exists(filename))
                {
                    // request that the UI load the project, since it keeps track
                    // of *additional* state (isNew) that this class is unaware of.
                    _mainForm.OpenProjectFile(filename);
                }
            }
        }

        #endregion

        #region Main (application entry point)

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// Command line arguments.  First arg can be a filename to load.
        /// </param>
        [STAThread]
        static void Main(string[] args)
        {
            var controller = new GeneratorController();
            controller.MainForm.Closing += controller.GeneratorForm_Closing;
            controller.CommandLineArgs = args;
            // process the command line args here so we have a UI, also, we can not process in Init without
            // modifying more code to take args[]
            controller.ProcessCommandLineArgs();
            Application.Run();
        }

        #endregion

        #region Public Properties

        public CslaGeneratorUnit CurrentUnit
        {
            get { return _currentUnit; }
            private set
            {
                _mainForm.ObjectRelationsBuilderDockPanel.Show(_mainForm.DockPanel);
                if (_currentUnit != null)
                {
                    if (_currentPropertiesTab != null && !_currentPropertiesTab.IsDisposed)
                    {
                        if (_currentPropertiesTab.Visible)
                            _currentPropertiesTab.Close();
                        _currentPropertiesTab.Dispose();
                    }
                }
                _currentUnit = value;
                _currentPropertiesTab = new ProjectProperties();
                _currentPropertiesTab.LoadInfo();
                _currentPropertiesTab.Show(_mainForm.DockPanel);
            }
        }

        public string TemplatesDirectory { get; set; }
        public string ProjectsDirectory { get; set; }
        public string ObjectsDirectory { get; set; }
        public string RulesDirectory { get; set; }
        public List<string> MruItems { get; set; }

        internal ProjectProperties ProjectPropertiesTab
        {
            get
            {
                return _currentPropertiesTab;
            }
        }

        public string[] CommandLineArgs
        {
            get { return _commandlineArgs; }
            set { _commandlineArgs = value; }
        }

        internal ProjectProperties CurrentPropertiesTab
        {
            get
            {
                if (_currentPropertiesTab != null)
                    if (_currentPropertiesTab.IsDisposed)
                    {
                        _currentPropertiesTab = new ProjectProperties();
                        _currentPropertiesTab.LoadInfo();
                    }
                return _currentPropertiesTab;
            }
        }

        public MainForm MainForm
        {
            get { return _mainForm; }
            set { _mainForm = value; }
        }

        public string CurrentFilePath
        {
            get { return _currentFilePath; }
            set { _currentFilePath = value; }
        }

        #endregion

        #region Internal Properties

        internal static ICatalog Catalog
        {
            get { return _catalog; }
            set { _catalog = value; }
        }

        internal static GeneratorController Current
        {
            get { return _current; }
        }

        #endregion

        #region Public Methods

        public void Connect()
        {
            var frmConn = new ConnectionForm();
            var result = frmConn.ShowDialog();
            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                BuildSchemaTree(ConnectionFactory.ConnectionString);
                Cursor.Current = Cursors.Default;
            }
        }

        public void Load(string fileName)
        {
            IsLoading = true;
            FileStream fs = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fs = File.Open(fileName, FileMode.Open);
                var s = new XmlSerializer(typeof(CslaGeneratorUnit));
                CurrentUnit = (CslaGeneratorUnit)s.Deserialize(fs);
                _currentUnit.ResetParent();
                _currentCslaObject = null;
                _currentAssociativeEntitiy = null;
                _currentFilePath = GetFilePath(fileName);

                ConnectionFactory.ConnectionString = _currentUnit.ConnectionString;
                // check if this is a valid connection, else let the user enter new connection info
                SqlConnection cn = null;
                try
                {
                    cn = ConnectionFactory.NewConnection;
                    cn.Open();
                    BuildSchemaTree(_currentUnit.ConnectionString);
                }
                catch //(SqlException e)
                {
                    // call connect function which will allow user to enter new info
                    Connect();
                }
                finally
                {
                    if (cn != null && cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                }

                BindControls();
                _currentUnit.CslaObjects.ListChanged += CslaObjects_ListChanged;
                foreach (var info in _currentUnit.CslaObjects)
                {
                    info.InheritedType.Parent = info;
                }
                if (_currentUnit.CslaObjects.Count > 0)
                {
                    if (_mainForm.ProjectPanel.ListObjects.Items.Count > 0)
                    {
                        _currentCslaObject = (CslaObjectInfo)_mainForm.ProjectPanel.ListObjects.Items[0];
                        // _frmGenerator.PropertyGrid.SelectedObject = new PropertyBag(_currentCslaObject, _propertyContext);
                    }
                    else
                    {
                        _currentCslaObject = null;
                        // _frmGenerator.PropertyGrid.SelectedObject = null;
                    }

                    if (_dbSchemaPanel != null)
                        _dbSchemaPanel.CslaObjectInfo = _currentCslaObject;
                }
                else
                {
                    _currentCslaObject = null;
                    // _frmGenerator.PropertyGrid.SelectedObject = null;
                    if (_dbSchemaPanel != null)
                        _dbSchemaPanel.CslaObjectInfo = null;
                }
                _mainForm.ProjectPanel.ApplyFiltersPresenter();

                _currentUnit.AssociativeEntities.ListChanged += AssociativeEntities_ListChanged;
                /*if (_currentUnit.AssociativeEntities.Count > 0)
                {
                    _currentAssociativeEntitiy = _currentUnit.AssociativeEntities[0];
                }
                else
                {
                    _currentAssociativeEntitiy = null;
                    _frmGenerator.ObjectRelationsBuilder.PropertyGrid1.SelectedObject = null;
                    _frmGenerator.ObjectRelationsBuilder.PropertyGrid2.SelectedObject = null;
                    _frmGenerator.ObjectRelationsBuilder.PropertyGrid3.SelectedObject = null;
                }*/

            }
            catch (Exception e)
            {
                MessageBox.Show(_mainForm,
                                fileName + Environment.NewLine +
                                e.Message, "Loading File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                fs.Close();
                IsLoading = false;
            }
        }

        private void CslaObjects_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                if (e.PropertyDescriptor.Name == "ObjectType" && _mainForm.ProjectPanel.FilterTypeIsActive)
                    ReloadPropertyGrid();
            }
        }

        private void AssociativeEntities_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                if (e.PropertyDescriptor.Name == "ObjectName" || e.PropertyDescriptor.Name == "RelationType")
                    ReloadBuilderPropertyGrid();
            }
        }

        public void NewCslaUnit()
        {
            CurrentUnit = new CslaGeneratorUnit();
            _currentFilePath = Path.GetTempPath() + @"\" + Guid.NewGuid().ToString();
            _currentCslaObject = null;
            _currentUnit.ConnectionString = ConnectionFactory.ConnectionString;
            BindControls();
            EnableButtons();
            _mainForm.PropertyGrid.SelectedObject = null;
        }

        public void Save(string fileName)
        {
            if (!_mainForm.ApplyProjectProperties())
                return;
            FileStream fs = null;
            string tempFile = Path.GetTempPath() + Guid.NewGuid().ToString() + ".cslagenerator";
            bool success = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fs = File.Open(tempFile, FileMode.Create);
                var s = new XmlSerializer(typeof(CslaGeneratorUnit));
                s.Serialize(fs, _currentUnit);
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(_mainForm, @"An error occurred while trying to save: " + Environment.NewLine + e.Message, "Save Error");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                fs.Close();
            }
            if (success)
            {
                File.Delete(fileName);
                File.Move(tempFile, fileName);
                _currentFilePath = GetFilePath(fileName);
            }
        }

        public string RetrieveFilename(string fileName)
        {
            int n = fileName.Length - 1;
            int x = 0;
            while (n >= 0)
            {
                x = x + 1;
                if (fileName.Substring(n, 1) == @"\")
                {
                    return fileName.Substring(n + 1, x - 1);
                }
                n = n - 1;
            }
            return "";
        }

        #endregion

        #region Private Methods

        private string GetFilePath(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            return fi.Directory.FullName;
        }

        private void BindControls()
        {
            if (_currentUnit != null)
            {
                _mainForm.ProjectNameTextBox.Enabled = true;
                _mainForm.ProjectNameTextBox.DataBindings.Clear();
                _mainForm.ProjectNameTextBox.DataBindings.Add("Text", _currentUnit, "ProjectName");

                _mainForm.TargetDirectoryButton.Enabled = true;
                _mainForm.TargetDirectoryTextBox.Enabled = true;
                _mainForm.TargetDirectoryTextBox.DataBindings.Clear();
                _mainForm.TargetDirectoryTextBox.DataBindings.Add("Text", _currentUnit, "TargetDirectory");

                BindCslaList();
                BindRelationsList();
            }
        }

        private void BindCslaList()
        {
            if (_currentUnit != null)
            {
                _mainForm.ProjectPanel.Objects = _currentUnit.CslaObjects;
                _mainForm.ProjectPanel.ApplyFilters(true);
                _mainForm.ProjectPanel.ListObjects.ClearSelected();
                if (_mainForm.ProjectPanel.ListObjects.Items.Count > 0)
                    _mainForm.ProjectPanel.ListObjects.SelectedIndex = 0;

                // make sure the previous stored selection is cleared
                _mainForm.ProjectPanel.ClearSelectedItems();
            }
        }

        private void BindRelationsList()
        {
            if (_currentUnit != null)
            {
                _mainForm.ObjectRelationsBuilder.AssociativeEntities = _currentUnit.AssociativeEntities;
                _mainForm.ObjectRelationsBuilder.FillViews(true);
                _mainForm.ObjectRelationsBuilder.GetCurrentListBox().ClearSelected();
                if (_mainForm.ObjectRelationsBuilder.GetCurrentListBox().Items.Count > 0)
                    _mainForm.ObjectRelationsBuilder.GetCurrentListBox().SelectedIndex = 0;

                // make sure the previous stored selection is cleared
                _mainForm.ObjectRelationsBuilder.ClearSelectedItems();
            }
        }

        private void BuildSchemaTree(string connectionString)
        {
            try
            {
                //dbSchemaPanel = new DbSchemaPanel(ref _currentUnit, ref _currentCslaObject, connectionString);
                _dbSchemaPanel = new DbSchemaPanel(_currentUnit, _currentCslaObject, connectionString);
                _dbSchemaPanel.BuildSchemaTree();
                _mainForm.DbSchemaPanel = _dbSchemaPanel;
                _mainForm.AddCtrlToMiddlePane(_dbSchemaPanel);
                _dbSchemaPanel.SetDbColumnsPctHeight(73);
                _dbSchemaPanel.SetDbTreeViewPctHeight(73);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private void EnableButtons()
        {
            //TODO: This needs to be applied to menu
            //frmGenerator.AddPropertiesButtton.Enabled = true;
            //frmGenerator.AddObjectButton.Enabled = true;
            //frmGenerator.DeleteObjectButton.Enabled = true;
            //frmGenerator.SaveButton.Enabled = true;
            //frmGenerator.DuplicateButton.Enabled = true;
            //frmGenerator.ConnectButton.Enabled = true;
            //frmGenerator.SelectDirectoryButton.Enabled = true;
        }

        private string GetFileNameWithoutExtension(string fileName)
        {
            int index = fileName.LastIndexOf(".");
            if (index >= 0)
            {
                return fileName.Substring(0, index);
            }
            return fileName;
        }

        private string GetFileExtension(string fileName)
        {
            int index = fileName.LastIndexOf(".");
            if (index >= 0)
            {
                return fileName.Substring(index + 1);
            }
            return ".cs";
        }

        private string GetTemplateName(CslaObjectInfo info)
        {
            switch (info.ObjectType)
            {
                case CslaObjectType.EditableRoot:
                    return ConfigurationManager.AppSettings["EditableRootTemplate"];
                case CslaObjectType.EditableChild:
                    return ConfigurationManager.AppSettings["EditableChildTemplate"];
                case CslaObjectType.EditableRootCollection:
                    return ConfigurationManager.AppSettings["EditableRootCollectionTemplate"];
                case CslaObjectType.EditableChildCollection:
                    return ConfigurationManager.AppSettings["EditableChildCollectionTemplate"];
                case CslaObjectType.EditableSwitchable:
                    return ConfigurationManager.AppSettings["EditableSwitchableTemplate"];
                case CslaObjectType.DynamicEditableRoot:
                    return ConfigurationManager.AppSettings["DynamicEditableRootTemplate"];
                case CslaObjectType.DynamicEditableRootCollection:
                    return ConfigurationManager.AppSettings["DynamicEditableRootCollectionTemplate"];
                case CslaObjectType.ReadOnlyObject:
                    return ConfigurationManager.AppSettings["ReadOnlyObjectTemplate"];
                case CslaObjectType.ReadOnlyCollection:
                    return ConfigurationManager.AppSettings["ReadOnlyCollectionTemplate"];
                default:
                    return String.Empty;
            }
        }

        #endregion

        #region Event Handlers

        private void GeneratorForm_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        private void CslaObjectList_SelectedItemsChanged(object sender, EventArgs e)
        {
            // fired on "ObjectName" changed for the following scenario:
            //     Suppose we have a filter on the name,
            //     and we change the object name in such way that
            //     the object isn't visible any longer,
            //     and it must not be shown on the PropertyGrid
            //     THEN we need to reload the PropertyGrid
            ReloadPropertyGrid();
        }

        private void AssociativeEntitiesList_SelectedItemsChanged(object sender, EventArgs e)
        {
            ReloadBuilderPropertyGrid();
        }

        // changed visibility so ActiveObjects settings can be hidden dynamicaly
        internal void ReloadPropertyGrid()
        {
            if (_dbSchemaPanel != null)
                _dbSchemaPanel.CslaObjectInfo = null;

            var selectedItems = new List<CslaObjectInfo>();
            foreach (CslaObjectInfo obj in _mainForm.ProjectPanel.ListObjects.SelectedItems)
            {
                selectedItems.Add(obj);
                if (!IsLoading && _dbSchemaPanel != null)
                {
                    _currentCslaObject = obj;
                    _dbSchemaPanel.CslaObjectInfo = obj;
                }
            }

            if (_dbSchemaPanel != null && selectedItems.Count != 1)
            {
                _currentCslaObject = null;
                _dbSchemaPanel.CslaObjectInfo = null;
            }

            if (selectedItems.Count == 0)
                _mainForm.PropertyGrid.SelectedObject = null;
            else
                _mainForm.PropertyGrid.SelectedObject = new PropertyBag(selectedItems.ToArray(), _propertyContext);
        }

        void ReloadBuilderPropertyGrid()
        {
            var selectedItems = new List<AssociativeEntity>();
            var listBoxSelectedItems = _mainForm.ObjectRelationsBuilder.GetCurrentListBox().SelectedItems;

            foreach (AssociativeEntity obj in listBoxSelectedItems)
            {
                selectedItems.Add(obj);
                if (!IsLoading)
                {
                    _currentAssociativeEntitiy = obj;
                }
            }

            if (selectedItems.Count == 0)
            {
                _currentAssociativeEntitiy = null;
            }
            else
            {
                if (_currentAssociativeEntitiy == null)
                    _currentAssociativeEntitiy = selectedItems[0];
            }
            _mainForm.ObjectRelationsBuilder.SetAllPropertyGridSelectedObject(_currentAssociativeEntitiy);
        }

        #endregion

        private void GetConfig()
        {
            GetConfigTemplatesFolder();
            GetConfigProjectsFolder();
            GetConfigObjectsFolder();
            GetConfigRulesFolder();
            GetConfigMruItems();
        }

        private void GetConfigTemplatesFolder()
        {
            var tDir = ConfigTools.Get("TemplatesDirectory");
            if (string.IsNullOrEmpty(tDir))
            {
                tDir = ConfigTools.OriginalGet("TemplatesDirectory");

                while (tDir.LastIndexOf(@"\\") == tDir.Length - 2)
                {
                    tDir = tDir.Substring(0, tDir.Length - 1);
                }
            }

            if (string.IsNullOrEmpty(tDir))
            {
                TemplatesDirectory = Environment.SpecialFolder.Desktop.ToString();
            }
            else
            {
                TemplatesDirectory = tDir;
            }
        }

        private void GetConfigProjectsFolder()
        {
            var tDir = ConfigTools.Get("ProjectsDirectory");
            if (string.IsNullOrEmpty(tDir))
            {
                tDir = ConfigTools.OriginalGet("ProjectsDirectory");

                while (tDir.LastIndexOf(@"\\") == tDir.Length - 2)
                {
                    tDir = tDir.Substring(0, tDir.Length - 1);
                }
            }

            if (string.IsNullOrEmpty(tDir))
            {
                ProjectsDirectory = Environment.SpecialFolder.Desktop.ToString();
            }
            else
            {
                ProjectsDirectory = tDir;
            }
        }

        internal void GetConfigObjectsFolder()
        {
            var tDir = ConfigTools.Get("ObjectsDirectory");
            if (string.IsNullOrEmpty(tDir))
            {
                tDir = ConfigTools.OriginalGet("ObjectsDirectory");

                while (tDir.LastIndexOf(@"\\") == tDir.Length - 2)
                {
                    tDir = tDir.Substring(0, tDir.Length - 1);
                }
            }

            if (string.IsNullOrEmpty(tDir))
            {
                ObjectsDirectory = Environment.SpecialFolder.Desktop.ToString();
            }
            else
            {
                ObjectsDirectory = tDir;
            }
        }

        internal void GetConfigRulesFolder()
        {
            var tDir = ConfigTools.Get("RulesDirectory");
            if (string.IsNullOrEmpty(tDir))
            {
                tDir = ConfigTools.OriginalGet("RulesDirectory");

                while (tDir.LastIndexOf(@"\\") == tDir.Length - 2)
                {
                    tDir = tDir.Substring(0, tDir.Length - 1);
                }
            }

            if (string.IsNullOrEmpty(tDir))
            {
                RulesDirectory = Environment.SpecialFolder.Desktop.ToString();
            }
            else
            {
                RulesDirectory = tDir;
            }
        }

        internal void GetConfigMruItems()
        {
            var tDir = ConfigTools.Get("RulesDirectory");
            if (string.IsNullOrEmpty(tDir))
            {
                tDir = ConfigTools.OriginalGet("RulesDirectory");

                while (tDir.LastIndexOf(@"\\") == tDir.Length - 2)
                {
                    tDir = tDir.Substring(0, tDir.Length - 1);
                }
            }

            if (string.IsNullOrEmpty(tDir))
            {
                RulesDirectory = Environment.SpecialFolder.Desktop.ToString();
            }
            else
            {
                RulesDirectory = tDir;
            }
        }

        internal void ResortMruItems()
        {
            string[] original = MruItems.ToArray();
            MruItems.Clear();
            foreach (var item in original)
            {
                if(!MruItems.Contains(item))
                    MruItems.Add(item);
            }

            ConfigTools.ChangeMru(MruItems);
        }

        #region Nested CslaObjectInfoComparer

        private class CslaObjectInfoComparer : IComparer<CslaObjectInfo>
        {
            #region IComparer<CslaObjectInfo> Members

            public int Compare(CslaObjectInfo x, CslaObjectInfo y)
            {
                return x.ObjectName.CompareTo(y.ObjectName);
            }

            #endregion
        }

        #endregion

    }
}