using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CslaGenerator.Controls;
using CslaGenerator.Metadata;
using CslaGenerator.Plugins;
using CslaGenerator.Properties;
using CslaGenerator.Util;
using CslaGenerator.Util.PropertyBags;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Private fields

        private const string BaseFormText = "Csla Generator Fork";
        private bool _isNewProject = true;
        private bool _showingStartPage;
        private bool _generating;
        private bool _appClosing;
        private bool _resetLayout;
        private GeneratorController _controller = null;
        private ICodeGenerator _generator;
        private List<ISimplePlugin> _plugins = new List<ISimplePlugin>();
        private ObjectRelationsBuilder _objectRelationsBuilderPanel = new ObjectRelationsBuilder();
        private ProjectPanel _projectPanel= new ProjectPanel();
        private ObjectInfo _objectInfoPanel = new ObjectInfo();
        private StartPage _webBrowserDockPanel = new StartPage();
        private GenerationReportViewer _errorPannel = new GenerationReportViewer();
        private GenerationReportViewer _warningPannel = new GenerationReportViewer();
        private ProjectProperties _projectPropertiesPanel = null;
        private DbSchemaPanel _dbSchemaPanel = null;
        private OutputWindow _outputPanel = new OutputWindow();
        private DeserializeDockContent _deserializeDockContent;

        #endregion

        #region Properties

        internal bool Generating
        {
            get { return _generating; }
            set
            {
                _generating = value;
                newToolStripMenuItem.Enabled = !value;
                openToolStripMenuItem.Enabled = !value;
                mruItem0.Enabled = !value;
                mruItem1.Enabled = !value;
                mruItem2.Enabled = !value;
                mruItem3.Enabled = !value;
                mruItem4.Enabled = !value;
                newProjectButton.Enabled = !value;
                openProjectButton.Enabled = !value;
                cancelButton.Enabled = value;
                generateButton.Enabled = !value;
                progressBar.Visible = value;
            }
        }

        private string DockSettingsFile
        {
            get
            {
                return Application.LocalUserAppDataPath.Substring(0, Application.LocalUserAppDataPath.LastIndexOf("\\")) +
                    @"\DockSettings.xml";
            }
        }

        internal PropertyGrid ObjectInfoGrid
        {
            get { return _objectInfoPanel.propertyGrid; }
        }

        internal TextBox ProjectNameTextBox
        {
            get { return _projectPanel.ProjectNameTextBox; }
        }

        internal Button TargetDirectoryButton
        {
            get { return _projectPanel.TargetDirectoryButton; }
        }

        internal TextBox TargetDirectoryTextBox
        {
            get { return _projectPanel.TargetDirectory; }
        }

        internal ProjectPanel ProjectPanel
        {
            get { return _projectPanel; }
        }

        internal ObjectRelationsBuilder ObjectRelationsBuilderPanel
        {
            get { return _objectRelationsBuilderPanel; }
        }

        internal ProjectProperties ProjectPropertiesPanel
        {
            get { return _projectPropertiesPanel; }
            set { _projectPropertiesPanel = value; }
        }

        internal DbSchemaPanel DbSchemaPanel
        {
            get { return _dbSchemaPanel; }
            set { _dbSchemaPanel = value; }
        }

        internal DockPanel DockPanel
        {
            get { return dockPanel; }
        }

        #endregion

        #region Constructor

        public MainForm(GeneratorController controller)
        {
            InitializeComponent();
            _controller = controller;
            _deserializeDockContent = GetContentFromPersistString;
        }
        
        #endregion

        #region Loading

        private bool ForceLoadCodeSmith()
        {
            if (!CodeSmithExists())
                Windows7Security.StartCodeSmithHandler();

            return CodeSmithExists();
        }

        private bool CodeSmithExists()
        {
            return File.Exists(Application.StartupPath + @"\CodeSmith.Engine.dll");
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

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(StartPage).ToString())
                return _webBrowserDockPanel;
            if (persistString == typeof(OutputWindow).ToString())
                return _outputPanel;
            if (persistString == typeof(ProjectPanel).ToString())
                return _projectPanel;
            if (persistString == typeof(ObjectInfo).ToString())
                return _objectInfoPanel;

            return new DockContent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(File.Exists(DockSettingsFile))
                dockPanel.LoadFromXml(DockSettingsFile, _deserializeDockContent);

            ShowStartPage();
            PanelsSetUp();
            LoadPlugins();
            LoadMru();
        }

        private void ShowStartPage()
        {
            _showingStartPage = true;
            var startupPath = Application.StartupPath;
            var idx = startupPath.IndexOf(@"\bin");
            string url;
            if (idx == -1)
                url = startupPath + @"\" + @"StartPage\startpage.html";
            else
                url = startupPath.Substring(0, idx) + @"\" + @"StartPage\startpage.html";

            // Web Browser
            _webBrowserDockPanel.webBrowser.TabIndex = 1;
            _webBrowserDockPanel.webBrowser.Navigating += WebBrowser_Navigating;
            _webBrowserDockPanel.MdiParent = this;
            _webBrowserDockPanel.VisibleChanged +=
                delegate(object sender, EventArgs e) { startPageToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            _webBrowserDockPanel.FormClosing += PaneFormClosing;
            _webBrowserDockPanel.webBrowser.Navigate(url);
            _webBrowserDockPanel.Show(dockPanel);
            _showingStartPage = false;
        }

        private void PanelsSetUp()
        {
            Text = BaseFormText;
            saveFileDialog.Filter = @"Csla Gen files (*.xml) | *.xml";
            saveFileDialog.DefaultExt = "xml";

            openFileDialog.Filter = saveFileDialog.Filter;
            openFileDialog.DefaultExt = saveFileDialog.DefaultExt;

            dockPanel.BringToFront();

            // Output panel
            _outputPanel.VisibleChanged +=
                delegate(object sender, EventArgs e) { outputWindowToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            _outputPanel.FormClosing += PaneFormClosing;
            _outputPanel.Show(dockPanel);

            // ProjectPanel
            _projectPanel.TabIndex = 0;
            _projectPanel.ProjectNameTextBox.Enabled = false;
            _projectPanel.ProjectNameTextBox.Text = @"Load or create a project";
            _projectPanel.TargetDirectory.Enabled = false;
            _projectPanel.TargetDirectoryButton.Enabled = false;
            _projectPanel.TargetDirChanged += ProjectPanel_TargetDirChanged;
            _projectPanel.SelectedItemsChanged += ProjectPanel_SelectedItemsChanged;
            _projectPanel.VisibleChanged +=
                delegate(object sender, EventArgs e) { projectPanelToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            _projectPanel.FormClosing += PaneFormClosing;
            _projectPanel.Show(dockPanel);

            // CslaObjectInfo PropertyGrid
            _objectInfoPanel.TabIndex = 1;
            _objectInfoPanel.Icon = Icon.FromHandle(Resources.Properties.GetHicon());
            _objectInfoPanel.propertyGrid.SelectedObject = null;
            _objectInfoPanel.propertyGrid.PropertySortChanged += OnSort;
            _objectInfoPanel.propertyGrid.SelectedGridItemChanged += OnSelectedGridItemChanged;
            _objectInfoPanel.VisibleChanged +=
                delegate(object sender, EventArgs e) { objectPropertiesPanelToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            _objectInfoPanel.FormClosing += PaneFormClosing;
            _objectInfoPanel.Show(dockPanel);

            // Object Relations Builder
            _objectRelationsBuilderPanel.AssociativeEntities = null;
            _objectRelationsBuilderPanel.TabIndex = 1;
            _objectRelationsBuilderPanel.Dock = DockStyle.Fill;
            _objectRelationsBuilderPanel.DockAreas = DockAreas.Float | DockAreas.Document;
            _objectRelationsBuilderPanel.MdiParent = this;
            _objectRelationsBuilderPanel.VisibleChanged +=
                delegate(object sender, EventArgs e) { objectRelationsBuilderPageToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            _objectRelationsBuilderPanel.FormClosing += PaneFormClosing;
            _webBrowserDockPanel.BringToFront();
        }

        /// <summary>
        /// Activate and show the Project Properties panel.
        /// </summary>
        internal void ActivateShowProjectProperties()
        {
            _projectPropertiesPanel.MdiParent = this;
            _projectPropertiesPanel.VisibleChanged +=
                delegate(object sender, EventArgs e) { projectPropertiesPageToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            _projectPropertiesPanel.FormClosing += PaneFormClosing;
            _projectPropertiesPanel.Show(dockPanel);
        }

        /// <summary>
        /// Activate and show the Schema panel.
        /// </summary>
        /// <remarks>
        /// Used by GeneratorController.BuildSchemaTree.
        /// </remarks>
        internal void ActivateShowSchema()
        {
            _dbSchemaPanel.MdiParent = this;
            _dbSchemaPanel.VisibleChanged +=
                delegate(object sender, EventArgs e) { schemaPageToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            _dbSchemaPanel.FormClosing += PaneFormClosing;
            _dbSchemaPanel.Show(dockPanel);
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
                    var pluginMenu = new ToolStripMenuItem(cmd.CommandTitle);
                    pluginMenu.Tag = cmd;
                    pluginMenu.Click += PluginMenuClick;
                    pluginsToolStripMenuItem.DropDownItems.Add(pluginMenu);
                }
            }
        }

        private void LoadMru()
        {
            _controller.MruItems = new List<string>();
            _controller.MruItems = ConfigTools.GetMru();
            MruDisplay();
        }

        #endregion

        #region Closing

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            _appClosing = true;
            if (_controller.CurrentProjectProperties != null)
                _controller.CurrentProjectProperties.Close();
            _objectRelationsBuilderPanel.Close();
            _errorPannel.Close();
            _warningPannel.Close();
            if (DbSchemaPanel != null)
                DbSchemaPanel.Close();

            if (_resetLayout)
                File.Delete(DockSettingsFile);
            else
                dockPanel.SaveAsXml(DockSettingsFile, Encoding.UTF8);
        }

        private void PaneFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_appClosing)
                return;

            // individual controls on the form are closing
            SaveBeforeClose(true);
            e.Cancel = true;
            ((DockContent)sender).Hide();
        }

        private DialogResult SaveBeforeClose(bool isClosing)
        {
            DialogResult result = DialogResult.None;
            if (_controller.CurrentProjectProperties != null && _controller.CurrentProjectProperties.IsDirty)
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
                    _controller.CurrentProjectProperties.cmdApply.PerformClick();
                    SaveToolStripMenuItem_Click(this, new EventArgs());
                }
            }
            return result;
        }

        #endregion

        #region Misc events

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && !Generating)
                Generate();
        }

        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!_showingStartPage)
            {
                e.Cancel = true;
                Process.Start(e.Url.AbsolutePath);
            }
        }

        #endregion

        #region Generation

        private void Generate()
        {
            if (_controller.CurrentUnit == null)
            {
                MessageBox.Show(@"You must open a project before generating.", "Invalid Generate Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Generating)
            {
                MessageBox.Show(@"The Generation process is already running.", "Invalid Generate Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ApplyProjectProperties())
                return;

            ClearErrorsAndWarning();
            globalStatus.Image = Resources._112_RefreshArrow_Green_16x16_72;
            globalStatus.ToolTipText = @"Generating...";
            statusStrip.Refresh();

            if (_controller.CurrentUnit.GenerationParams.SaveBeforeGenerate)
                SaveToolStripMenuItem_Click(this, EventArgs.Empty);

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
            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _generator.GenerateProject(_controller.CurrentUnit);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var timer = _controller.CurrentUnit.GenerationTimer.Elapsed;
            generatingTimer.Text = String.Format("Generating: {0}:{1},{2}",
                                                 timer.Minutes.ToString("00"),
                                                 timer.Seconds.ToString("00"),
                                                 timer.Milliseconds.ToString("000"));
            Generating = false;
            if (!_controller.HasErrors && !_controller.HasWarnings)
            {
                globalStatus.Image = Resources.Green;
                globalStatus.ToolTipText = @"Generation terminated.";
            }
            else
            {
                if (_controller.HasWarnings)
                {
                    globalStatus.Image = Resources.Orange;
                    globalStatus.ToolTipText = @"Generation with issues.";
                    warnings.Image = Resources._109_AllAnnotations_Warning_16x16_72;
                    warnings.DoubleClickEnabled = true;
                    warnings.ToolTipText = @"Double click to get the warning list.";
                    warnings.AutoToolTip = true;
                }
                if (_controller.HasErrors)
                {
                    globalStatus.Image = Resources.Red;
                    globalStatus.ToolTipText = @"Generation with errors.";
                    errors.Image = Resources._109_AllAnnotations_Error_16x16_72;
                    errors.DoubleClickEnabled = true;
                    errors.ToolTipText = @"Double click to get the error list.";
                    errors.AutoToolTip = true;
                }
            }
            statusStrip.Refresh();
        }

        private void GeneratorStep(string e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                Invoke((MethodInvoker)delegate { progressBar.Value++; });
            }
        }

        internal bool ApplyProjectProperties()
        {
            if (!_controller.CurrentProjectProperties.ValidateOptions())
                return false;

            if (_controller.CurrentProjectProperties.IsDirty)
            {
                DialogResult result =
                    MessageBox.Show(
                        @"There are unsaved changes in the project properties tab. Would you like to apply them now?",
                        @"CslaGenerator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        _controller.CurrentProjectProperties.cmdApply.PerformClick();
                        break;
                    case DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        #endregion
        
        #region Project panel

        private void ProjectPanel_TargetDirChanged(string path)
        {
            _controller.CurrentUnit.TargetDirectory = path;
        }

        private void ProjectPanel_SelectedItemsChanged(object sender, EventArgs e)
        {
            ConditonalButtonsAndMenus();
        }

        #endregion

        #region CslaObjectInfo panel

        public void OnSort(object sender, EventArgs e)
        {
            if (_objectInfoPanel.propertyGrid.PropertySort == PropertySort.CategorizedAlphabetical)
                _objectInfoPanel.propertyGrid.PropertySort = PropertySort.Categorized;
        }

        private void OnSelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            CslaObjectInfo cslaObj = ((PropertyBag)((PropertyGrid)sender).SelectedObject).SelectedObject[0];
            switch (e.NewSelection.Label)
            {
                case "Create Authorization Type":
                    cslaObj.ActionProperty = AuthorizationActions.CreateObject;
                    break;
                case "Get Authorization Type":
                    cslaObj.ActionProperty = AuthorizationActions.GetObject;
                    break;
                case "Update Authorization Type":
                    cslaObj.ActionProperty = AuthorizationActions.EditObject;
                    break;
                case "Delete Authorization Type":
                    cslaObj.ActionProperty = AuthorizationActions.DeleteObject;
                    break;
            }
        }

        #endregion

        #region General toolbar and menu handlers

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
            generateButton.Enabled = objectsPresent;

            // Menus

            removeSelectedObjectToolStripMenuItem.Enabled = objectSelected;
            duplicateObjectToolStripMenuItem.Enabled = objectSelected;
            newObjectRelationToolStripMenuItem.Enabled = objectSelected;
            addToObjectRelationToolStripMenuItem.Enabled = objectSelected;
        }

        #endregion

        #region Toolbar

        private void NewProjectButton_Click(object sender, EventArgs e)
        {
            NewToolStripMenuItem_Click(sender, e);
        }

        private void OpenProjectButton_Click(object sender, EventArgs e)
        {
            OpenToolStripMenuItem_Click(sender, e);
        }

        private void SaveProjectButton_Click(object sender, EventArgs e)
        {
            SaveToolStripMenuItem_Click(sender, e);
        }

        private void AddObjectButton_Click(object sender, EventArgs e)
        {
            _projectPanel.AddNewObject();
        }

        private void DeleteObjectButton_Click(object sender, EventArgs e)
        {
            _projectPanel.RemoveSelected();
        }

        private void DuplicateObjectButton_Click(object sender, EventArgs e)
        {
            _projectPanel.DuplicateSelected();
        }

        private void MoveuUpObjectButton_Click(object sender, EventArgs e)
        {
            _projectPanel.MoveUpSelected();
        }

        private void MoveDownObjectButton_Click(object sender, EventArgs e)
        {
            _projectPanel.MoveDownSelected();
        }

        private void NewObjectRelationButton_Click(object sender, EventArgs e)
        {
            _projectPanel.AddNewObjectRelation();
        }

        private void AddToObjectRelationButton_Click(object sender, EventArgs e)
        {
            _projectPanel.AddToObjectRelationBuilder();
        }

        private void ConnectDatabaseButton_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (Generating)
                _generator.Abort();
        }

        #endregion

        #region File menu

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ForceLoadCodeSmith())
            {
                _controller.NewCslaUnit();
                _isNewProject = true;
                openFileDialog.FileName = string.Empty;
                Text = BaseFormText;
                if (!File.Exists(Application.CommonAppDataPath + @"\Default.xml"))
                {
                    _controller.CurrentProjectProperties.CmdResetToFactory.PerformClick();
                    _controller.CurrentProjectProperties.cmdSetDefault.PerformClick();
                }

                _controller.CurrentProjectProperties.cmdGetDefault.PerformClick();
                AfterOpenEnableButtonsAndMenus();
                if (_controller.IsDBConnected)
                {
                    globalStatus.Image = Resources.Blue;
                    globalStatus.ToolTipText = @"New project.";
                }
                else
                {
                    globalStatus.Image = Resources.Orange;
                    globalStatus.ToolTipText = @"New project has no database connection.";
                }
                loadingTimer.Text = "Loading:";
                FillObjects();
                ClearErrorsAndWarning();
                statusStrip.Refresh();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ForceLoadCodeSmith())
            {
                openFileDialog.InitialDirectory = _controller.ProjectsDirectory;
                DialogResult result = openFileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    _controller.ProjectsDirectory = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf('\\'));
                    ConfigTools.Change("ProjectsDirectory", _controller.ProjectsDirectory);
                    Application.DoEvents();
                    Cursor.Current = Cursors.WaitCursor;
                    OpenProjectFile(openFileDialog.FileName);
                    HandleMruItemsNewCurrent(openFileDialog.FileName);
                    Cursor.Current = Cursors.Default;
                    Text = _controller.CurrentUnit.ProjectName + @" - " + BaseFormText;
                    AfterOpenEnableButtonsAndMenus();
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (!_isNewProject && openFileDialog.FileName.Length > 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                _controller.Save(openFileDialog.FileName);
                HandleMruItemsNewCurrent(openFileDialog.FileName);
                Cursor.Current = Cursors.Default;
                Text = _controller.CurrentUnit.ProjectName + @" - " + BaseFormText;
                return;
            }

            SaveAsToolStripMenuItem_Click(sender, e);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (openFileDialog.FileName.Length > 1)
                saveFileDialog.FileName = _controller.RetrieveFilename(openFileDialog.FileName);
            else if (_controller.CurrentUnit != null)
                saveFileDialog.FileName = _controller.CurrentUnit.ProjectName + ".xml";
            else
                saveFileDialog.FileName = "Project.xml";

            saveFileDialog.InitialDirectory = _controller.ProjectsDirectory;
            DialogResult result = saveFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _controller.ProjectsDirectory = saveFileDialog.FileName.Substring(0, saveFileDialog.FileName.LastIndexOf('\\'));
                ConfigTools.Change("ProjectsDirectory", _controller.ProjectsDirectory);
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                _controller.Save(saveFileDialog.FileName);
                openFileDialog.FileName = saveFileDialog.FileName;
                HandleMruItemsNewCurrent(openFileDialog.FileName);
                _isNewProject = false;
                Cursor.Current = Cursors.Default;
                Text = _controller.CurrentUnit.ProjectName + @" - " + BaseFormText;
            }
        }

        private void MruItem0_Click(object sender, EventArgs e)
        {
            HanddleMruItem(0);
        }

        private void MruItem1_Click(object sender, EventArgs e)
        {
            HanddleMruItem(1);
        }

        private void MruItem2_Click(object sender, EventArgs e)
        {
            HanddleMruItem(2);
        }

        private void MruItem3_Click(object sender, EventArgs e)
        {
            HanddleMruItem(3);
        }

        private void MruItem4_Click(object sender, EventArgs e)
        {
            HanddleMruItem(4);
        }

        private void ExitResetLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _resetLayout = true;
            DialogResult result = SaveBeforeClose(false);
            if (result == DialogResult.Cancel)
                return;

            Close();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = SaveBeforeClose(false);
            if (result == DialogResult.Cancel)
                return;

            Close();
        }

        #region MRU helpers

        private void HanddleMruItem(int mruItem)
        {
            if (_controller.MruItems.Count > mruItem)
            {
                if (ForceLoadCodeSmith())
                {
                    if (!File.Exists(_controller.MruItems[mruItem]))
                        HandleMruItemsMissing(mruItem);
                    else
                    {
                        openFileDialog.FileName = _controller.MruItems[mruItem];
                        _controller.ProjectsDirectory = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf('\\'));
                        ConfigTools.Change("ProjectsDirectory", _controller.ProjectsDirectory);
                        Application.DoEvents();
                        Cursor.Current = Cursors.WaitCursor;
                        OpenProjectFile(openFileDialog.FileName);
                        HandleMruItemsNewCurrent(openFileDialog.FileName);
                        Cursor.Current = Cursors.Default;
                        Text = _controller.CurrentUnit.ProjectName + @" - " + BaseFormText;
                        AfterOpenEnableButtonsAndMenus();
                    }
                }
            }
        }

        private void HandleMruItemsNewCurrent(string filename)
        {
            _controller.MruItems.Insert(0, filename);
            _controller.ReSortMruItems();
            MruDisplay();
        }

        private void HandleMruItemsMissing(int mruItem)
        {
            var message = _controller.MruItems[mruItem] + Environment.NewLine +
                          @"project file wasn't found." + Environment.NewLine + Environment.NewLine +
                          @"Do you want to remove it from the recently used list?";
            if (MessageBox.Show(message, @"Project file not found.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                _controller.MruItems.RemoveAt(mruItem);
                MruDisplay();
            }
        }

        private void MruDisplay()
        {
            mruItem0.Text = string.Empty;
            mruItem0.Visible = false;
            mruItem1.Text = string.Empty;
            mruItem1.Visible = false;
            mruItem2.Text = string.Empty;
            mruItem2.Visible = false;
            mruItem3.Text = string.Empty;
            mruItem3.Visible = false;
            mruItem4.Text = string.Empty;
            mruItem4.Visible = false;

            for (var i = 0; i < 5; i++)
            {
                if (i == _controller.MruItems.Count)
                    break;

                var tooltip = _controller.MruItems[i];
                var text = "&" + (i + 1) + " ...\\" + tooltip.Substring(tooltip.LastIndexOf('\\') + 1);

                switch (i)
                {
                    case 0:
                        mruItem0.ToolTipText = tooltip;
                        mruItem0.Text = text;
                        mruItem0.Visible = true;
                        break;
                    case 1:
                        mruItem1.ToolTipText = tooltip;
                        mruItem1.Text = text;
                        mruItem1.Visible = true;
                        break;
                    case 2:
                        mruItem2.ToolTipText = tooltip;
                        mruItem2.Text = text;
                        mruItem2.Visible = true;
                        break;
                    case 3:
                        mruItem3.ToolTipText = tooltip;
                        mruItem3.Text = text;
                        mruItem3.Visible = true;
                        break;
                    case 4:
                        mruItem4.ToolTipText = tooltip;
                        mruItem4.Text = text;
                        mruItem4.Visible = true;
                        break;
                }
            }
            HandleMruSeparator();
        }

        private void HandleMruSeparator()
        {
            if (_controller.MruItems.Count == 0)
                mruSeparator.Visible = false;
            else
                mruSeparator.Visible = true;
        }

        #endregion

        #endregion

        #region File menu helpers

        public void OpenProjectFile(string fileName)
        {
            globalStatus.Image = Resources._112_RefreshArrow_Green_16x16_72;
            globalStatus.ToolTipText = @"Loading...";
            loadingTimer.Text = "Loading:";
            ClearErrorsAndWarning();
            statusStrip.Refresh();
            _controller.NewCslaUnit();
            _controller.Load(fileName);
            var timer = _controller.LoadingTimer.Elapsed;
            loadingTimer.Text = String.Format("Loading: {0}:{1},{2}",
                                                 timer.Minutes.ToString("00"),
                                                 timer.Seconds.ToString("00"),
                                                 timer.Milliseconds.ToString("000"));
            _isNewProject = false;
            // if we are calling this from the controller, then the
            // file dialog will not have been used to open the file, and since other code relies
            // on the file dialog having been used (no local/controller storage for file name) ...
            if (openFileDialog.FileName != fileName)
            {
                openFileDialog.FileName = fileName;
            }
            FillDatabaseObjects();
            FillObjects();
            if (_controller.IsDBConnected)
            {
                globalStatus.Image = Resources.Blue;
                globalStatus.ToolTipText = @"Project loaded.";
            }
            else
            {
                globalStatus.Image = Resources.Orange;
                globalStatus.ToolTipText = @"No database connection.";
            }
            statusStrip.Refresh();
        }

        #endregion

        #region Project menu

        private void AddAnewObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _projectPanel.AddNewObject();
        }

        private void RemoveSelectedObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _projectPanel.RemoveSelected();
        }

        private void DuplicateObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _projectPanel.DuplicateSelected();
        }

        private void SelectAllObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _projectPanel.SelectAll();
        }

        private void NewObjectRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _projectPanel.AddNewObjectRelation();
        }

        private void AddToObjectRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _projectPanel.AddToObjectRelationBuilder();
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_controller.CurrentUnit != null)
            {
                if (_controller.CurrentProjectProperties != null)
                {
                    if (_controller.CurrentProjectProperties.Visible)
                        _controller.CurrentProjectProperties.Focus();
                    else
                        _controller.CurrentProjectProperties.Show(dockPanel);
                }
            }
            else
            {
                MessageBox.Show(@"You need to open or create a project to set its properties.", @"Project properties",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Database menu

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void RefreshSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dbSchemaPanel != null)
                _dbSchemaPanel.BuildSchemaTree();
        }

        private void RetrieveSummariesToolStripMenuItem_Click(object sender, EventArgs e)
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
                    foreach (ValueProperty vp in _dbSchemaPanel.CslaObjectInfo.ValueProperties)
                        vp.RetrieveSummaryFromColumnDefinition();
                }
            }
        }

        #endregion

        #region Database helpers

        private void Connect()
        {
            if (_controller.CurrentUnit != null)
            {
                Application.DoEvents();
                _controller.Connect();
                FillDatabaseObjects();
                if (_controller.IsDBConnected)
                {
                    globalStatus.Image = Resources.Blue;
                    if (globalStatus.ToolTipText == @"New project has no database connection.")
                        globalStatus.ToolTipText = @"New project.";
                }
            }
            else
                MessageBox.Show(@"You must load or start a new project before connecting to a database",
                                @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Tools menu

        private void LocateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tDirDialog = new FolderBrowserDialog();
            tDirDialog.Description = @"Current folder location of the CslaGenFork templates is:" + Environment.NewLine +
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

        private void CodeSmithExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows7Security.StartCodeSmithHandler();
        }

        #endregion

        #region View menu

        private void ProjectPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectPanelToolStripMenuItem.Checked)
                _projectPanel.Hide();
            else
                _projectPanel.Show(dockPanel);
        }

        private void StartPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (startPageToolStripMenuItem.Checked)
                _webBrowserDockPanel.Hide();
            else
                _webBrowserDockPanel.Show(dockPanel);
        }

        private void ObjectRelationsBuilderPageToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (objectRelationsBuilderPageToolStripMenuItem.Checked)
                ObjectRelationsBuilderPanel.Hide();
            else
            {
                if (_controller.CurrentUnit != null)
                    ObjectRelationsBuilderPanel.Show(dockPanel);
            }
        }

        private void ProjectPropertiesPageToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (ProjectPropertiesPanel == null)
                return;

            if (projectPropertiesPageToolStripMenuItem.Checked)
                ProjectPropertiesPanel.Hide();
            else
            {
                if (_controller.CurrentUnit != null)
                    ProjectPropertiesPanel.Show(dockPanel);
            }
        }

        private void SchemaPageToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (DbSchemaPanel == null)
                return;

            if (schemaPageToolStripMenuItem.Checked)
                DbSchemaPanel.Hide();
            else
            {
                if (_controller.CurrentUnit != null)
                    DbSchemaPanel.Show(dockPanel);
            }
        }

        private void ObjectPropertiesPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objectPropertiesPanelToolStripMenuItem.Checked)
                _objectInfoPanel.Hide();
            else
                _objectInfoPanel.Show(dockPanel);
        }

        private void OutputWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (outputWindowToolStripMenuItem.Checked)
                OutputWindow.Current.Hide();
            else
                OutputWindow.Current.Show(dockPanel);
        }

        #endregion

        #region Plugin menu

        private void PluginMenuClick(object sender, EventArgs e)
        {
            try
            {
                foreach (ISimplePlugin plugin in _plugins)
                {
                    plugin.Catalog = GeneratorController.Catalog;
                    plugin.Unit = _controller.CurrentUnit;
                    plugin.SelectedObjects = _projectPanel.GetSelectedObjects();
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

        #endregion

        #region Help menu

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new AboutBox())
            {
                frm.ShowDialog();
            }
        }

        #endregion

        #region Status bar

        private void ClearErrorsAndWarning()
        {
            generatingTimer.Text = "Generating:";
            _errorPannel.Empty();
            _errorPannel.Hide();
            _warningPannel.Empty();
            _warningPannel.Hide();
            errors.Image = null;
            warnings.Image = null;
            errors.DoubleClickEnabled = false;
            warnings.DoubleClickEnabled = false;
            errors.ToolTipText = string.Empty;
            warnings.ToolTipText = string.Empty;
            errors.AutoToolTip = false;
            warnings.AutoToolTip = false;
        }

        private void FillDatabaseObjects()
        {
            if (_controller.IsDBConnected)
            {
                tables.Text = string.Format("Tables: {0}", _controller.Tables);
                views.Text = string.Format("Views: {0}", _controller.Views);
                sprocs.Text = string.Format("SProcs: {0}", _controller.Sprocs);
            }
            else
            {
                tables.Text = "Tables:";
                views.Text = "Views:";
                sprocs.Text = "SProcs:";
            }
        }

        internal void FillObjects()
        {
            objects.Text = string.Format("Objects: {0}", _controller.CurrentUnit.CslaObjects.Count);
        }

        private void Errors_DoubleClick(object sender, EventArgs e)
        {
            _errorPannel.Fill(_generator.ErrorReport);
            _errorPannel.TabText = @"Errors";
            //_errorPannel.VisibleChanged += delegate(object sender, EventArgs e) { outputWindowToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            _errorPannel.FormClosing += PaneFormClosing;
            _errorPannel.Show(_outputPanel.Pane, _outputPanel);
        }

        private void Warnings_DoubleClick(object sender, EventArgs e)
        {
            _warningPannel.Fill(_generator.WarningReport);
            _warningPannel.TabText = @"Warnings";
            //_warningPannel.VisibleChanged += delegate(object sender, EventArgs e) { outputWindowToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            _warningPannel.FormClosing += PaneFormClosing;
            _warningPannel.Show(_outputPanel.Pane, _outputPanel);
        }
        
        #endregion

    }
}
