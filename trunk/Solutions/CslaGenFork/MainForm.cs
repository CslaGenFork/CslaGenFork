using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CslaGenerator.Controls;
using CslaGenerator.Metadata;
using CslaGenerator.Plugins;
using CslaGenerator.Properties;
using CslaGenerator.Util;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        private const string BaseFormText = "Csla Generator Fork";
        private bool _generating;
        private ICodeGenerator _generator;
        private bool _isNewProject = true;
        private List<ISimplePlugin> _plugins = new List<ISimplePlugin>();
        private DockContent _projectDockPanel;
        private DockContent _propertyGridDockPanel;
        private bool _showingStartPage;
        private DockContent _webBrowserDockPanel;

        public MainForm(GeneratorController controller)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            Init();
            _controller = controller;
            //generator = new CslaGenerator.CodeGen.CodeGenerator();
        }

        internal DockPanel DockPanel
        {
            get { return dockPanel1; }
        }

        public DockContent ObjectRelationsBuilderDockPanel { get; set; }

        public bool Generating
        {
            get { return _generating; }
            set
            {
                _generating = value;
                tsbCancel.Enabled = value;
                tsbGenerate.Enabled = !value;
                progressBar.Visible = value;
            }
        }

        private void Init()
        {
            Text = BaseFormText;
            sfdSave.Filter = @"Csla Gen files (*.xml) | *.xml";
            sfdSave.DefaultExt = "xml";

            ofdLoad.Filter = sfdSave.Filter;
            ofdLoad.DefaultExt = sfdSave.DefaultExt;

            //fbGenerate.OnlyFilesystem = true;
            projectPanel.TargetDirChanged += ProjectPanelTargetDirChanged;
            projectPanel.SelectedItemsChanged += ProjectPanelSelectedItemsChanged;
            projectPanel.ProjectNameTextBox.Enabled = false;
            projectPanel.ProjectNameTextBox.Text = @"Load or create a project";
            projectPanel.TargetDirectory.Enabled = false;
            projectPanel.TargetDirectoryButton.Enabled = false;
        }

        private static void ShieldBitmap(object sender, PaintEventArgs e)
        {
            if (!Windows7Security.IsVistaOrHigher())
                return;

            // Construct an Icon.
            var icon1 = new Icon(SystemIcons.Shield, 16, 16);

            // Call ToBitmap to convert it.
            Bitmap bmp = icon1.ToBitmap();

            // Draw the bitmap.
            e.Graphics.DrawImage(bmp, new Point(5, 3));
        }

        internal void AddCtrlToMiddlePane(DbSchemaPanel dbSchemaPnl)
        {
            foreach (Control ctl in dockPanel1.Contents)
            {
                if (ctl.Text == @"Schema")
                {
                    ((Form)ctl).Close();
                    ctl.Dispose();
                    break;
                }
            }

            var pane = new DockContent();
            pane.Controls.Add(dbSchemaPnl);
            dbSchemaPnl.Dock = DockStyle.Fill;
            pane.DockAreas = DockAreas.Float | DockAreas.Document;
            pane.CloseButton = false;

            pane.MdiParent = this;
            pane.Text = @"Schema";
            pane.Show(dockPanel1);
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            // show start page
            ShowStartPage();

            PanelsSetUp();

            LoadPlugins();
        }

        private void LoadPlugins()
        {
            _plugins = PluginLoader.LoadPlugins();
            if (_plugins == null || _plugins.Count == 0)
            {
                pluginsToolStripMenuItem.Visible = false;
                return;
            }
            foreach (ISimplePlugin plugin in _plugins)
            {
                foreach (ScriptCommandInfo cmd in plugin.GetCommands())
                {
                    // ReSharper disable UseObjectOrCollectionInitializer
                    var pluginMenu = new ToolStripMenuItem(cmd.CommandTitle);
                    // ReSharper restore UseObjectOrCollectionInitializer
                    pluginMenu.Tag = cmd;
                    pluginMenu.Click += PluginMenuClick;
                    pluginsToolStripMenuItem.DropDownItems.Add(pluginMenu);
                }
            }
        }

        private void PluginMenuClick(object sender, EventArgs e)
        {
            try
            {
                foreach (ISimplePlugin plugin in _plugins)
                {
                    plugin.Catalog = GeneratorController.Catalog;
                    plugin.Unit = _controller.CurrentUnit;
                    plugin.SelectedObjects = projectPanel.GetSelectedObjects();
                }
                var menu = (ToolStripMenuItem)sender;
                var cmd = (ScriptCommandInfo)menu.Tag;
                cmd.RunCommand();
            }
            catch (Exception ex)
            {
                OutputWindow.Current.AddOutputInfo("Error running plugin:");
                OutputWindow.Current.AddOutputInfo(ex.Message);
            }
        }

        private void ShowStartPage()
        {
            _showingStartPage = true;
            //            var str = "";
            //            object nullObject = 0;
            //            object nullObjStr = "";
            string startupPath = Application.StartupPath;
            int idx = startupPath.IndexOf(@"\bin");
            string url;
            if (idx == -1)
            {
                url = startupPath + @"\" + @"StartPage\startpage.html";
            }
            else
            {
                url = startupPath.Substring(0, idx) + @"\" + @"StartPage\startpage.html";
            }
            webBrowser1.Navigate(url);
            _showingStartPage = false;
        }

        private void ProjectPanelTargetDirChanged(string path)
        {
            _controller.CurrentUnit.TargetDirectory = path;
        }

        private void ProjectPanelSelectedItemsChanged(object sender, EventArgs e)
        {
            ConditonalButtonsAndMenus();
        }

        public void OpenProjectFile(string fileName)
        {
            _controller.Load(fileName);
            _isNewProject = false;
            // if we are calling this from the controller, then the
            // file dialog will not have been used to open the file, and since other code relies
            // on the file dialog having been used (no local/controller storage for file name) ...
            // ReSharper disable RedundantCheckBeforeAssignment
            if (ofdLoad.FileName != fileName)
            // ReSharper restore RedundantCheckBeforeAssignment
            {
                ofdLoad.FileName = fileName;
            }
        }

        // ReSharper disable UnusedMember.Local
        private void GeneratorRequestSave(object sender, EventArgs e)
        // ReSharper restore UnusedMember.Local
        {
            SaveToolStripMenuItemClick(sender, e);
        }

        private void Connect()
        {
            if (_controller.CurrentUnit != null)
            {
                Application.DoEvents();
                _controller.Connect();
            }
            else
                MessageBox.Show(@"You must load or start a new project before connecting to a database",
                                @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal bool ApplyProjectProperties()
        {
            if (!_controller.CurrentPropertiesTab.ValidateOptions())
                return false;

            if (_controller.CurrentPropertiesTab.IsDirty)
            {
                DialogResult result =
                    MessageBox.Show(
                        @"There are unsaved changes in the project properties tab. Would you like to apply them now?",
                        @"CslaGenerator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        _controller.CurrentPropertiesTab.cmdApply.PerformClick();
                        break;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        private void Generate()
        {
            if (_controller.CurrentUnit == null)
            {
                MessageBox.Show(@"You must open a project before generating");
                return;
            }
            if (Generating)
            {
                MessageBox.Show(@"The Generation process is already running!");
                return;
            }
            if (!ApplyProjectProperties())
                return;

            if (_controller.CurrentUnit.GenerationParams.SaveBeforeGenerate)
                SaveToolStripMenuItemClick(this, EventArgs.Empty);

            Generating = true;
            if (_generator != null)
            {
                _generator.Step -= GeneratorStep;
            }
            var targetDir = _controller.CurrentUnit.TargetDirectory;
            if (targetDir.StartsWith(".") || targetDir.StartsWith(".."))
            {
                targetDir = _controller.CurrentFilePath + @"\" + targetDir;
            }
            if (_controller.CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40 ||
                _controller.CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
            {
                _generator = new CodeGen.AdvancedGenerator(targetDir, _controller.TemplatesDirectory);
            }
            else
            {
                _generator = new Templates.CodeGenerator(targetDir, _controller.TemplatesDirectory);
            }
            _generator.Step += GeneratorStep;
            var i = 0;
            foreach (var obj in _controller.CurrentUnit.CslaObjects)
            {
                if (obj.Generate)
                    i++;
            }
            progressBar.Value = 0;
            progressBar.Maximum = i;
            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
        {
            _generator.GenerateProject(_controller.CurrentUnit);
        }

        private void BackgroundWorker1RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Generating = false;
        }

        private void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && !Generating)
                Generate();
        }

        // ReSharper disable MemberCanBeMadeStatic.Local
        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        // ReSharper restore MemberCanBeMadeStatic.Local
        {
            using (var frm = new AboutBox())
            {
                frm.ShowDialog();
            }
        }

        private void LocateToolStripMenuItemClick(object sender, EventArgs e)
        {
            // ReSharper disable UseObjectOrCollectionInitializer
            var tDirDialog = new FolderBrowserDialog();
            // ReSharper restore UseObjectOrCollectionInitializer
            tDirDialog.Description = @"Current folder location of the CslaGen templates is:" + Environment.NewLine +
                                     _controller.TemplatesDirectory + Environment.NewLine +
                                     @"Select a new folder location and press OK.";
            tDirDialog.ShowNewFolderButton = false;
            if (!string.IsNullOrEmpty(_controller.TemplatesDirectory))
                tDirDialog.SelectedPath = _controller.TemplatesDirectory;
            else
                tDirDialog.RootFolder = Environment.SpecialFolder.Desktop;

            DialogResult dialogResult = tDirDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string tdir = tDirDialog.SelectedPath;
                if (tDirDialog.SelectedPath.LastIndexOf('\\') != tDirDialog.SelectedPath.Length - 1)
                    tdir += @"\";
                _controller.TemplatesDirectory = tdir;
                ConfigTools.Change("TemplatesDirectory", _controller.TemplatesDirectory);
            }
        }

        // ReSharper disable MemberCanBeMadeStatic.Local
        private void CodeSmithExtensionToolStripMenuItemClick(object sender, EventArgs e)
        // ReSharper restore MemberCanBeMadeStatic.Local
        {
            Windows7Security.StartCodeSmithHandler();
        }

        #region Control Properties

        // Properties made available mainly for use within controller
        internal PropertyGrid PropertyGrid
        {
            get { return pgGrid; }
        }

        internal TextBox ProjectNameTextBox
        {
            get { return projectPanel.ProjectNameTextBox; }
        }

        internal Button TargetDirectoryButton
        {
            get { return projectPanel.TargetDirectoryButton; }
        }

        internal TextBox TargetDirectoryTextBox
        {
            get { return projectPanel.TargetDirectory; }
        }

        internal ProjectPanel ProjectPanel
        {
            get { return projectPanel; }
        }

        internal ObjectRelationsBuilder ObjectRelationsBuilder
        {
            get { return objectRelationsBuilder; }
        }

        internal DbSchemaPanel DbSchemaPanel
        {
            get { return dbSchemaPanel; }
            set { dbSchemaPanel = value; }
        }

        private void WebBrowser1Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!_showingStartPage)
            {
                e.Cancel = true;
                Process.Start(e.Url.AbsolutePath);
            }
        }

        #endregion

        #region PropertyGrid stuff

        public void OnSort(object sender, EventArgs e)
        {
            if (pgGrid.PropertySort == PropertySort.CategorizedAlphabetical)
                pgGrid.PropertySort = PropertySort.Categorized;
        }

        #endregion

        #region Menu Handlers

        private void AfterOpenEnableButtonsAndMenus()
        {
            saveasToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveProjectButton.Enabled = true;
            addObjectButton.Enabled = true;
            connectDatabaseButton.Enabled = true;
            projectToolStripMenuItem.Enabled = true;
            dataBaseToolStripMenuItem.Enabled = true;

            ConditonalButtonsAndMenus();
        }

        private void ConditonalButtonsAndMenus()
        {
            bool objectSelected = (ProjectPanel.ListObjects.SelectedIndices.Count != 0);

            deleteObjectButton.Enabled = objectSelected;
            duplicateObjectButton.Enabled = objectSelected;

            moveuUpObjectButton.Enabled = (objectSelected &&
                                           ProjectPanel.SortOptionsNone.Checked &&
                                           ProjectPanel.ListObjects.SelectedIndex > 0) ||
                                          ProjectPanel.ListObjects.SelectedIndices.Count > 1;
            moveDownObjectButton.Enabled = (objectSelected &&
                                            ProjectPanel.SortOptionsNone.Checked &&
                                            ProjectPanel.ListObjects.SelectedIndex <
                                            ProjectPanel.ListObjects.Items.Count - 1) ||
                                           ProjectPanel.ListObjects.SelectedIndices.Count > 1;

            newObjectRelationButton.Enabled = objectSelected;
            addToObjectRelationButton.Enabled = objectSelected;

            bool objectsPresent = (ProjectPanel.Objects.Count > 0);
            tsbGenerate.Enabled = objectsPresent;

            // Menus

            removeSelectedObjectToolStripMenuItem.Enabled = objectSelected;
            duplicateObjectToolStripMenuItem.Enabled = objectSelected;
            newObjectRelationToolStripMenuItem.Enabled = objectSelected;
            addToObjectRelationToolStripMenuItem.Enabled = objectSelected;
        }

        private DialogResult SaveBeforeClose(bool isClosing)
        {
            DialogResult result = DialogResult.None;
            if (_controller.CurrentPropertiesTab != null && _controller.CurrentPropertiesTab.IsDirty)
            {
                result =
                    MessageBox.Show(
                        @"There are unsaved changes in the project properties tab. Would you like to save the project now?",
                        @"CslaGenerator",
                        isClosing
                            ? MessageBoxButtons.YesNo
                            : MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _controller.CurrentPropertiesTab.cmdApply.PerformClick();
                    SaveToolStripMenuItemClick(this, new EventArgs());
                }
            }
            return result;
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult result = SaveBeforeClose(false);
            if (result == DialogResult.Cancel)
                return;

            _appClosing = true;
            Application.Exit();
        }

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            _controller.NewCslaUnit();
            _isNewProject = true;
            ofdLoad.FileName = string.Empty;
            Text = BaseFormText;
            if (!File.Exists(Application.CommonAppDataPath + @"\Default.xml"))
            {
                _controller.CurrentPropertiesTab.CmdResetToFactory.PerformClick();
                _controller.CurrentPropertiesTab.cmdSetDefault.PerformClick();
            }

            _controller.CurrentPropertiesTab.cmdGetDefault.PerformClick();
            AfterOpenEnableButtonsAndMenus();
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            DialogResult result = ofdLoad.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                OpenProjectFile(ofdLoad.FileName);
                Cursor.Current = Cursors.Default;
                Text = _controller.CurrentUnit.ProjectName + @" - " + BaseFormText;
                AfterOpenEnableButtonsAndMenus();
            }
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (!_isNewProject && ofdLoad.FileName.Length > 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                _controller.Save(ofdLoad.FileName);
                Cursor.Current = Cursors.Default;
                Text = _controller.CurrentUnit.ProjectName + @" - " + BaseFormText;
                return;
            }

            SaveasToolStripMenuItemClick(sender, e);
        }

        private void SaveasToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (ofdLoad.FileName.Length > 1)
                sfdSave.FileName = _controller.RetrieveFilename(ofdLoad.FileName);
            else if (_controller.CurrentUnit != null)
                sfdSave.FileName = _controller.CurrentUnit.ProjectName + ".xml";
            else
                sfdSave.FileName = "Project.xml";

            DialogResult result = sfdSave.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                _controller.Save(sfdSave.FileName);
                ofdLoad.FileName = sfdSave.FileName;
                _isNewProject = false;
                Cursor.Current = Cursors.Default;
                Text = _controller.CurrentUnit.ProjectName + @" - " + BaseFormText;
            }
        }

        private void PropertiesToolStripMenuItemClick(object sender, EventArgs e)
        {
            ShowProjectProperties();
        }

        public void ShowProjectProperties()
        {
            if (_controller.CurrentUnit != null)
            {
                if (_controller.CurrentPropertiesTab != null)
                {
                    if (_controller.CurrentPropertiesTab.Visible)
                        _controller.CurrentPropertiesTab.Focus();
                    else
                        _controller.CurrentPropertiesTab.Show(dockPanel1);
                }
            }
            else
            {
                MessageBox.Show(@"You need to open or create a project to set its properties.", @"Project properties",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConnectToolStripMenuItemClick(object sender, EventArgs e)
        {
            Connect();
        }

        private void RefreshSchemaToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (dbSchemaPanel != null)
                dbSchemaPanel.BuildSchemaTree();
        }

        private void RetrieveSummariesToolStripMenuItemClick(object sender, EventArgs e)
        {
            string msg = @"Do you want to retrieve summaries for all objects or just the current object?";
            msg += Environment.NewLine;
            msg += @"Choose yes to update all objects or no for the current one.";
            DialogResult dr = MessageBox.Show(msg, @"Csla Generator", MessageBoxButtons.YesNoCancel);
            if (dr != DialogResult.Cancel)
            {
                if (dr == DialogResult.Yes)
                {
                    foreach (CslaObjectInfo info in _controller.CurrentUnit.CslaObjects)
                    {
                        foreach (ValueProperty vp in info.ValueProperties)
                            vp.RetrieveSummaryFromColumnDefinition();
                    }
                }
                else
                {
                    foreach (ValueProperty vp in dbSchemaPanel.CslaObjectInfo.ValueProperties)
                        vp.RetrieveSummaryFromColumnDefinition();
                }
            }
        }

        #endregion

        #region Toolbar Handlers

        private void AddAnewObjectToolStripMenuItemClick(object sender, EventArgs e)
        {
            projectPanel.AddNewObject();
        }

        private void RemoveSelectedObjectToolStripMenuItemClick(object sender, EventArgs e)
        {
            projectPanel.RemoveSelected();
        }

        private void DuplicateObjectToolStripMenuItemClick(object sender, EventArgs e)
        {
            projectPanel.DuplicateSelected();
        }

        private void NewObjectRelationToolStripMenuItemClick(object sender, EventArgs e)
        {
            projectPanel.AddNewObjectRelation();
        }

        private void AddToObjectRelationToolStripMenuItemClick(object sender, EventArgs e)
        {
            projectPanel.AddToObjectRelationBuilder();
        }

        private void NewProjectButtonClick(object sender, EventArgs e)
        {
            NewToolStripMenuItemClick(sender, e);
        }

        private void OpenProjectButtonClick(object sender, EventArgs e)
        {
            OpenToolStripMenuItemClick(sender, e);
        }

        private void SaveProjectButtonClick(object sender, EventArgs e)
        {
            SaveToolStripMenuItemClick(sender, e);
        }

        private void AddObjectButtonClick(object sender, EventArgs e)
        {
            projectPanel.AddNewObject();
        }

        private void DeleteObjectButtonClick(object sender, EventArgs e)
        {
            projectPanel.RemoveSelected();
        }

        private void DuplicateObjectButtonClick(object sender, EventArgs e)
        {
            projectPanel.DuplicateSelected();
        }

        private void MoveuUpObjectButtonClick(object sender, EventArgs e)
        {
            projectPanel.MoveUpSelected();
        }

        private void MoveDownObjectButtonClick(object sender, EventArgs e)
        {
            projectPanel.MoveDownSelected();
        }

        private void NewRelationsObjectButtonClick(object sender, EventArgs e)
        {
            projectPanel.AddNewObjectRelation();
        }

        private void AddToRelationButtonClick(object sender, EventArgs e)
        {
            projectPanel.AddToObjectRelationBuilder();
        }

        private void ConnectDatabaseButtonClick(object sender, EventArgs e)
        {
            Connect();
        }

        private void TsbGenerateClick(object sender, EventArgs e)
        {
            Generate();
        }

        private void TsbCancelClick(object sender, EventArgs e)
        {
            if (Generating)
                _generator.Abort();
        }

        private void GeneratorStep(string e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                Invoke((MethodInvoker)delegate { progressBar.Value++; });
            }
        }

        #endregion

        #region Project Panels

        private bool _appClosing;

        private void PanelsSetUp()
        {
            dockPanel1.BringToFront();
            dockPanel1.Dock = DockStyle.Fill;

            var output = new OutputWindow();
            output.VisibleChanged +=
                delegate(object sender, EventArgs e) { outputWindowToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            output.FormClosing += PaneFormClosing;
            output.Show(dockPanel1);

            // ReSharper disable JoinDeclarationAndInitializer
            DockContent pane;
            // ReSharper restore JoinDeclarationAndInitializer
            //set up docking for the PropertyGrid
            Controls.Remove(PropertyGrid);
            // ReSharper disable UseObjectOrCollectionInitializer
            pane = new DockContent();
            // ReSharper restore UseObjectOrCollectionInitializer
            pane.Icon = Icon.FromHandle(Resources.Properties.GetHicon());
            pane.Controls.Add(PropertyGrid);
            pane.DockAreas = DockAreas.DockRight |
                             DockAreas.DockLeft |
                             DockAreas.Float;
            PropertyGrid.Dock = DockStyle.Fill;
            pane.Text = @"Csla Object Info";
            pane.VisibleChanged +=
                delegate(object sender, EventArgs e) { objectPropertiesPanelToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            pane.FormClosing += PaneFormClosing;
            _propertyGridDockPanel = pane;
            pane.Show(dockPanel1);
            //set up docking for the web browser
            Controls.Remove(webBrowser1);
            pane = new DockContent();
            pane.Controls.Add(webBrowser1);
            webBrowser1.Dock = DockStyle.Fill;
            pane.DockAreas = DockAreas.Float | DockAreas.Document;
            pane.MdiParent = this;
            pane.Text = @"Start Page";
            pane.VisibleChanged +=
                delegate(object sender, EventArgs e) { mainPageToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            pane.FormClosing += PaneFormClosing;
            _webBrowserDockPanel = pane;
            pane.Show(dockPanel1);

            //set up docking for the object relations builder
            Controls.Remove(objectRelationsBuilder);
            pane = new DockContent();
            pane.Controls.Add(objectRelationsBuilder);
            objectRelationsBuilder.Dock = DockStyle.Fill;
            pane.DockAreas = DockAreas.Float | DockAreas.Document;
            pane.MdiParent = this;
            pane.Text = @"Object Relations Builder";
            pane.VisibleChanged +=
                delegate(object sender, EventArgs e) { objectRelationsBuilderPageToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            pane.FormClosing += PaneFormClosing;
            ObjectRelationsBuilderDockPanel = pane;
            //            pane.Show(dockPanel1);
            _webBrowserDockPanel.BringToFront();

            //set up docking for the Project Panel);
            Controls.Remove(projectPanel);
            projectPanel.Dock = DockStyle.Fill;
            // ReSharper disable UseObjectOrCollectionInitializer
            pane = new DockContent();
            // ReSharper restore UseObjectOrCollectionInitializer
            pane.Icon = Icon.FromHandle(Resources.Classes.GetHicon());
            pane.Controls.Add(projectPanel);
            pane.DockAreas = DockAreas.DockLeft |
                             DockAreas.DockRight |
                             DockAreas.Float;
            pane.ShowHint = DockState.DockLeft;
            pane.Text = @"CslaGen Project";
            pane.VisibleChanged +=
                delegate(object sender, EventArgs e) { projectPanelToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            pane.FormClosing += PaneFormClosing;
            _projectDockPanel = pane;
            pane.Show(dockPanel1);
        }

        private void PaneFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_appClosing)
                return;
            SaveBeforeClose(true);
            e.Cancel = true;
            ((DockContent)sender).Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _appClosing = true;
            base.OnClosing(e);
        }

        private void ObjectPropertiesPanelToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (objectPropertiesPanelToolStripMenuItem.Checked)
                _propertyGridDockPanel.Hide();
            else
                _propertyGridDockPanel.Show(dockPanel1);
        }

        private void MainPageToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (mainPageToolStripMenuItem.Checked)
                _webBrowserDockPanel.Hide();
            else
                _webBrowserDockPanel.Show(dockPanel1);
        }

        private void ObjectRelationsBuilderPageToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (objectRelationsBuilderPageToolStripMenuItem.Checked)
                ObjectRelationsBuilderDockPanel.Hide();
            else
            {
                if (_controller.CurrentUnit != null)
                    ObjectRelationsBuilderDockPanel.Show(dockPanel1);
            }
        }

        private void ProjectPanelToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (projectPanelToolStripMenuItem.Checked)
                _projectDockPanel.Hide();
            else
                _projectDockPanel.Show(dockPanel1);
        }

        private void OutputWindowToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (outputWindowToolStripMenuItem.Checked)
                OutputWindow.Current.Hide();
            else
                OutputWindow.Current.Show(dockPanel1);
        }

        #endregion
    }
}
