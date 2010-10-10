using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using CslaGenerator.Controls;
using CslaGenerator.Util;
using WeifenLuo.WinFormsUI.Docking;
using System.Collections.Generic;
using CslaGenerator.Plugins;
using Ionic.Zip;
using Microsoft.VisualBasic;

namespace CslaGenerator
{
	/// <summary>
	/// Summary description for MainUI.
	/// </summary>
	public partial class CSLAgen : System.Windows.Forms.Form
    {
		private string _baseFormText = "Csla Generator Fork";
		private bool isNewProject = true;

		public CSLAgen(GeneratorController controller)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Init();
			_controller = controller;
            //generator = new CslaGenerator.Templates.CodeGenerator();
		}

		private void Init()
		{
		    Text = _baseFormText;
			sfdSave.Filter = "Csla Gen files (*.xml) | *.xml";
			sfdSave.DefaultExt = "xml";

			ofdLoad.Filter = sfdSave.Filter;
			ofdLoad.DefaultExt = sfdSave.DefaultExt;

            //fbGenerate.OnlyFilesystem = true;
			projectPanel.TargetDirChanged += projectPanel_TargetDirChanged;
            projectPanel.SelectedItemsChanged += projectPanel_SelectedItemsChanged;
		}

        internal void AddCtrlToMiddlePane(DbSchemaPanel dbSchemaPanel)
        {
            foreach (Control ctl in dockPanel1.Contents)
            {
                if (ctl.Text == "Schema")
                {
                    ((Form)ctl).Close();
                    ctl.Dispose();
                    break;
                }
            }

            DockContent pane = new DockContent();
            pane.Controls.Add(dbSchemaPanel);
            dbSchemaPanel.Dock = DockStyle.Fill;
            pane.DockAreas = DockAreas.Float | DockAreas.Document;

            pane.MdiParent = this;
            pane.Text = "Schema";
            pane.Show(dockPanel1);
        }
        internal WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel
        {
            get
            {
                return dockPanel1;
            }
        }

        DockContent projectDockPanel;
        DockContent propertyGridDockPanel;
        DockContent webBrowserDockPanel;
        DockContent objectRelationsBuilderDockPanel;

        public DockContent ObjectRelationsBuilderDockPanel
        {
            get { return objectRelationsBuilderDockPanel; }
            set { objectRelationsBuilderDockPanel = value; }
        }

		private void MainUI_Load(object sender, System.EventArgs e)
		{
			// show start page
			ShowStartPage();

            PanelsSetUp();

            LoadPlugins();
		}

        List<ISimplePlugin> plugins=new List<ISimplePlugin>();
        void LoadPlugins()
        {
            plugins = PluginLoader.LoadPlugins();
            if (plugins == null || plugins.Count == 0)
            {
                pluginsToolStripMenuItem.Visible = false;
                return;
            }
            foreach (ISimplePlugin plugin in plugins)
            {
                foreach (ScriptCommandInfo cmd in plugin.GetCommands())
                {
                    ToolStripMenuItem pluginMenu = new ToolStripMenuItem(cmd.CommandTitle);
                    pluginMenu.Tag = cmd;
                    pluginMenu.Click += new EventHandler(pluginMenu_Click);
                    pluginsToolStripMenuItem.DropDownItems.Add(pluginMenu);
                }
            }
        }

        void pluginMenu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ISimplePlugin plugin in plugins)
                {
                    plugin.Catalog = GeneratorController.Catalog;
                    plugin.Unit = _controller.CurrentUnit;
                    plugin.SelectedObjects = projectPanel.GetSelectedObjects();
                }
                ToolStripMenuItem menu = (ToolStripMenuItem)sender;
                ScriptCommandInfo cmd = (ScriptCommandInfo)menu.Tag;
                cmd.RunCommand();
            }
            catch (Exception ex)
            {
                OutputWindow.Current.AddOutputInfo("Error runnin plugin:");
                OutputWindow.Current.AddOutputInfo(ex.Message);
            }
        }

        bool showingStartPage;
		private void ShowStartPage()
		{
            showingStartPage = true;
			string str = "";
			object nullObject = 0;
			object nullObjStr = str;
			string startupPath = Application.StartupPath;
			int idx = startupPath.IndexOf(@"\bin");
			string url = string.Empty;
			if (idx == -1)
			{
				url = startupPath + @"\" + @"StartPage\startpage.html";		
			}
			else
			{		
				url = startupPath.Substring(0,idx) + @"\" + @"StartPage\startpage.html";	
			}
            webBrowser1.Navigate(url);
            showingStartPage = false;
		}


		private void projectPanel_TargetDirChanged(string path)
		{
			_controller.CurrentUnit.TargetDirectory = path;
		}

        private void projectPanel_SelectedItemsChanged(object sender, EventArgs e)
		{
            ConditonalButtonsAndMenus();
		}

        public void OpenProjectFile(string fileName)
        {
            _controller.Load(fileName);
            isNewProject = false;
            // if we are calling this from the controller, then the 
            // file dialog will not have been used to open the file, and since other code relies
            // on the file dialog having been used (no local/controller storage for file name) ...
            if (ofdLoad.FileName != fileName)
            {
                ofdLoad.FileName = fileName;
            }
        }

        private void Generator_RequestSave(object sender, EventArgs e)
		{
            saveToolStripMenuItem_Click(sender,e);
		}

        #region " Control Properties "

        // Properties made available mainly for use within controller
		internal PropertyGrid PropertyGrid
		{
			get { return pgGrid; }
		}
		internal TextBox ProjectNameTextBox
		{
			get { return projectPanel.ProjectNameTextBox; }
		}
		internal TextBox TargetDirectoryTextBox
		{
			get { return projectPanel.TargetDirectory; }
		}

        internal ProjectPanel ProjectPanel
        {
            get
            {
                return projectPanel;
            }
        }

        internal ObjectRelationsBuilder ObjectRelationsBuilder
        {
            get
            {
                return objectRelationsBuilder;
            }
        }
      
		internal DbSchemaPanel DbSchemaPanel
		{
			get { return dbSchemaPanel; }
			set 
			{ 
				dbSchemaPanel = value; 
			}
		}

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!showingStartPage)
            {
                e.Cancel = true;
                System.Diagnostics.Process.Start(e.Url.AbsolutePath);
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

        #region " Menu Handlers "

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
            var objectSelected = (ProjectPanel.ListObjects.SelectedIndices.Count != 0);

            deleteObjectButton.Enabled = objectSelected;
            duplicateObjectButton.Enabled = objectSelected;

            moveuUpObjectButton.Enabled = (objectSelected &&
                                          ProjectPanel.SortOptionsNone.Checked &&
                                          ProjectPanel.ListObjects.SelectedIndex > 0) ||
                                          ProjectPanel.ListObjects.SelectedIndices.Count > 1;
            moveDownObjectButton.Enabled = (objectSelected &&
                                           ProjectPanel.SortOptionsNone.Checked &&
                                           ProjectPanel.ListObjects.SelectedIndex < ProjectPanel.ListObjects.Items.Count - 1) ||
                                           ProjectPanel.ListObjects.SelectedIndices.Count > 1;

            newObjectRelationButton.Enabled = objectSelected;
            addToObjectRelationButton.Enabled = objectSelected;

            var objectsPresent = (ProjectPanel.Objects.Count > 0);
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
                result = MessageBox.Show("There are unsaved changes in the project properties tab. Would you like to save the project now?", 
                    "CslaGenerator", 
                    isClosing ? 
                    MessageBoxButtons.YesNo :
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _controller.CurrentPropertiesTab.cmdApply.PerformClick();
                    saveToolStripMenuItem_Click(this, new EventArgs());
                }
            }
            return result;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = SaveBeforeClose(false);
            if (result == DialogResult.Cancel)
                return;
            
            appClosing = true;
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.NewCslaUnit();
            isNewProject = true;
            ofdLoad.FileName = string.Empty;
            Text = _baseFormText;
            _controller.CurrentPropertiesTab.cmdGetDefault.PerformClick();
            AfterOpenEnableButtonsAndMenus();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdLoad.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                OpenProjectFile(ofdLoad.FileName);
                Cursor.Current = Cursors.Default;
                Text = _controller.CurrentUnit.ProjectName + " - " + _baseFormText;
                AfterOpenEnableButtonsAndMenus();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (!isNewProject && ofdLoad.FileName.Length > 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                _controller.Save(ofdLoad.FileName);
                Cursor.Current = Cursors.Default;
                Text = _controller.CurrentUnit.ProjectName + " - " + _baseFormText;
                return;
            }
            else
                saveasToolStripMenuItem_Click(sender, e);
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (ofdLoad.FileName.Length > 1)
                this.sfdSave.FileName = _controller.RetrieveFilename(ofdLoad.FileName);
            else if (_controller.CurrentUnit != null)
                this.sfdSave.FileName = _controller.CurrentUnit.ProjectName + ".xml";
            else
                this.sfdSave.FileName = "Project.xml";

            DialogResult result = sfdSave.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                _controller.Save(sfdSave.FileName);
                ofdLoad.FileName = sfdSave.FileName;
                isNewProject = false;
                Cursor.Current = Cursors.Default;
                Text = _controller.CurrentUnit.ProjectName + " - " + _baseFormText;
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowProjectProperties();
        }

        public void ShowProjectProperties()
        {
            if (this._controller.CurrentUnit != null)
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
                MessageBox.Show("You need to open or create a project to set it's properties.", "Project properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void refreshSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dbSchemaPanel != null)
                this.dbSchemaPanel.BuildSchemaTree();
        }

        private void retrieveSummariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg;
            msg = "Do you want to retrieve summaries for all objects or just the current object?";
            msg += Environment.NewLine;
            msg += "Choose yes to update all objects or no for the current one.";
            System.Windows.Forms.DialogResult dr;
            dr = MessageBox.Show(msg, "Csla Generator", MessageBoxButtons.YesNoCancel);
            if (dr != DialogResult.Cancel)
            {
                if (dr == DialogResult.Yes)
                {
                    foreach (Metadata.CslaObjectInfo info in this._controller.CurrentUnit.CslaObjects)
                    {
                        foreach (Metadata.ValueProperty vp in info.ValueProperties)
                            vp.RetrieveSummaryFromColumnDefinition();
                    }
                }
                else
                {
                    foreach (Metadata.ValueProperty vp in dbSchemaPanel.CslaObjectInfo.ValueProperties)
                        vp.RetrieveSummaryFromColumnDefinition();
                }
            }
        }

        #endregion

        #region " Toolbar Handlers "

        private void addAnewObjectToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            projectPanel.AddNewObject();
        }
        private void removeSelectedObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projectPanel.RemoveSelected();
        }
        private void duplicateObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projectPanel.DuplicateSelected();
        }

        private void newObjectRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projectPanel.AddNewObjectRelation();
        }

        private void addToObjectRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projectPanel.AddToObjectRelationBuilder();
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void openProjectButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void saveProjectButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void addObjectButton_Click(object sender, EventArgs e)
        {
            projectPanel.AddNewObject();
        }

        private void deleteObjectButton_Click(object sender, EventArgs e)
        {
            projectPanel.RemoveSelected();
        }

        private void duplicateObjectButton_Click(object sender, EventArgs e)
        {
            projectPanel.DuplicateSelected();
        }

        private void moveuUpObjectButton_Click(object sender, EventArgs e)
        {
            projectPanel.MoveUpSelected();
        }

        private void moveDownObjectButton_Click(object sender, EventArgs e)
        {
            projectPanel.MoveDownSelected();
        }

        private void newRelationsObjectButton_Click(object sender, EventArgs e)
        {
            projectPanel.AddNewObjectRelation();
        }

        private void addToRelationButton_Click(object sender, EventArgs e)
        {
            projectPanel.AddToObjectRelationBuilder();
        }

        private void connectDatabaseButton_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void tsbGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (Generating)
                generator.Abort();
        }

        void generator_Step(string e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                Invoke((MethodInvoker) delegate () { progressBar.Value++; });
            }
        }

        #endregion

        #region " Project Panels "

        void PanelsSetUp()
        {
            dockPanel1.BringToFront();
            dockPanel1.Dock = DockStyle.Fill;


            OutputWindow output = new OutputWindow();
            output.VisibleChanged += delegate(object sender, EventArgs e) { outputWindowToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            output.FormClosing += new FormClosingEventHandler(pane_FormClosing);
            output.Show(dockPanel1);

            DockContent pane;
            //set up docking for the PropertyGrid
            this.Controls.Remove(PropertyGrid);
            pane = new DockContent();
            pane.Icon = Icon.FromHandle(CslaGenerator.Properties.Resources.Properties.GetHicon());
            pane.Controls.Add(PropertyGrid);
            pane.DockAreas = DockAreas.DockRight |
                DockAreas.DockLeft |
                DockAreas.Float;
            PropertyGrid.Dock = DockStyle.Fill;
            pane.Text = "Csla Object Info";
            pane.VisibleChanged += delegate(object sender, EventArgs e) { objectPropertiesPanelToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            pane.FormClosing += new FormClosingEventHandler(pane_FormClosing);
            propertyGridDockPanel = pane;
            pane.Show(dockPanel1);
            //set up docking for the web browser
            this.Controls.Remove(webBrowser1);
            pane = new DockContent();
            pane.Controls.Add(webBrowser1);
            webBrowser1.Dock = DockStyle.Fill;
            pane.DockAreas = DockAreas.Float | DockAreas.Document;
            pane.MdiParent = this;
            pane.Text = "Start Page";
            pane.VisibleChanged += delegate(object sender, EventArgs e) { mainPageToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            pane.FormClosing += new FormClosingEventHandler(pane_FormClosing);
            webBrowserDockPanel = pane;
            pane.Show(dockPanel1);

            //set up docking for the object relations builder
            this.Controls.Remove(objectRelationsBuilder);
            pane = new DockContent();
            pane.Controls.Add(objectRelationsBuilder);
            objectRelationsBuilder.Dock = DockStyle.Fill;
            pane.DockAreas = DockAreas.Float | DockAreas.Document;
            pane.MdiParent = this;
            pane.Text = "Object Relations Builder";
            pane.VisibleChanged += delegate(object sender, EventArgs e) { objectRelationsBuilderPageToolStripMenuItem.Checked = ((DockContent) sender).Visible; };
            pane.FormClosing += new FormClosingEventHandler(pane_FormClosing);
            objectRelationsBuilderDockPanel = pane;
//            pane.Show(dockPanel1);
            webBrowserDockPanel.BringToFront();

            //set up docking for the Project Panel);
            this.Controls.Remove(projectPanel);
            projectPanel.Dock = DockStyle.Fill;
            pane = new DockContent();
            pane.Icon = Icon.FromHandle(CslaGenerator.Properties.Resources.Classes.GetHicon());
            pane.Controls.Add(projectPanel);
            pane.DockAreas = DockAreas.DockLeft |
                 DockAreas.DockRight |
                 DockAreas.Float;
            pane.ShowHint = DockState.DockLeft;
            pane.Text = "CslaGen Project";
            pane.VisibleChanged += delegate(object sender, EventArgs e) { projectPanelToolStripMenuItem.Checked = ((DockContent)sender).Visible; };
            pane.FormClosing += new FormClosingEventHandler(pane_FormClosing);
            projectDockPanel = pane;
            pane.Show(dockPanel1);
        }

        void pane_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (appClosing)
                return;
            SaveBeforeClose(true);
            e.Cancel = true;
            ((DockContent)sender).Hide();
        }
        bool appClosing = false;
        protected override void OnClosing(CancelEventArgs e)
        {
            appClosing = true;
            base.OnClosing(e);
        }

        private void objectPropertiesPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objectPropertiesPanelToolStripMenuItem.Checked)
                propertyGridDockPanel.Hide();
            else
                propertyGridDockPanel.Show(dockPanel1);
        }

        private void mainPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainPageToolStripMenuItem.Checked)
                webBrowserDockPanel.Hide();
            else
                webBrowserDockPanel.Show(dockPanel1);
        }


        private void objectRelationsBuilderPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objectRelationsBuilderPageToolStripMenuItem.Checked)
                objectRelationsBuilderDockPanel.Hide();
            else
                objectRelationsBuilderDockPanel.Show(dockPanel1);
        }

        private void projectPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectPanelToolStripMenuItem.Checked)
                projectDockPanel.Hide();
            else
                projectDockPanel.Show(dockPanel1);
        }

        private void outputWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (outputWindowToolStripMenuItem.Checked)
                OutputWindow.Current.Hide();
            else
                OutputWindow.Current.Show(dockPanel1);

        }

        #endregion

        void Connect()
        {
            if (_controller.CurrentUnit != null)
            {
                Application.DoEvents();
                _controller.Connect();
            }
            else
                MessageBox.Show("You must load or start a new project before connecting to a database", "CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool _Generating = false;
        public bool Generating
        {
            get
            {
                return _Generating;
            }
            set
            {
                _Generating = value;
                tsbCancel.Enabled = value;
                tsbGenerate.Enabled = !value;
                progressBar.Visible = value;
            }
        }



        internal bool ApplyProjectProperties()
        {
            if (_controller.CurrentPropertiesTab.IsDirty)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes in the project properties tab. Would you like to apply them now?", "CslaGenerator", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

        void Generate()
        {
            if (this._controller.CurrentUnit == null)
            {
                MessageBox.Show("You must open a project before generating");
                return;
            }
            if (Generating)
            {
                MessageBox.Show("The Generation process is already running!");
                return;
            }
            if (!ApplyProjectProperties())
                return;
            
            if (_controller.CurrentUnit.GenerationParams.SaveBeforeGenerate)
                saveToolStripMenuItem_Click(this, EventArgs.Empty);

            Generating = true;
            if (generator != null)
            {
                generator.Step -= new CslaGenerator.Templates.CodeGenerator.GenerationInformationDelegate(generator_Step);
            }
            string targetDir = _controller.CurrentUnit.TargetDirectory;
            if (targetDir.StartsWith(".") || targetDir.StartsWith(".."))
            {
                targetDir = _controller.CurrentFilePath + @"\" + targetDir;
            }
            generator = new CslaGenerator.Templates.CodeGenerator(targetDir, _controller.TemplatesDirectory);
            generator.Step += new CslaGenerator.Templates.CodeGenerator.GenerationInformationDelegate(generator_Step);
            int i = 0;
            foreach (Metadata.CslaObjectInfo obj in _controller.CurrentUnit.CslaObjects)
            {
                if (obj.Generate)
                    i++;
            }
            progressBar.Value = 0;
            progressBar.Maximum = i;
            backgroundWorker1.RunWorkerAsync();
        }

        Templates.CodeGenerator generator;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            generator.GenerateProject(_controller.CurrentUnit);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Generating = false;
        }

        private void CSLAgen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && !this.Generating)
                Generate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox frm = new AboutBox())
            {
                frm.ShowDialog();
            }
        }

        private void locateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tDirDialog = new FolderBrowserDialog();
            tDirDialog.Description = "Current folder location of the CslaGen templates is:" + Environment.NewLine +
                                     _controller.TemplatesDirectory + Environment.NewLine +
                                     "Select a new folder location and press OK.";
            tDirDialog.ShowNewFolderButton = false;
            if (!string.IsNullOrEmpty(_controller.TemplatesDirectory))
                tDirDialog.SelectedPath = _controller.TemplatesDirectory;
            tDirDialog.RootFolder = Environment.SpecialFolder.Desktop;
            tDirDialog.ShowDialog();
            var tdir = tDirDialog.SelectedPath + @"\";
            if(_controller.TemplatesDirectory != tdir)
            {
                _controller.TemplatesDirectory = tdir;
                ConfigTools.Change("TemplatesDirectory", _controller.TemplatesDirectory);
            }
        }

        private void codeSmithExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Title = "CodeSmith Extension - Select the free CodeSmith ZIP file";
            openFile.Filter = "ZIP files (*.zip) | *.zip";
            openFile.DefaultExt = "zip";
            openFile.Multiselect = false;
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.AddExtension = true;
            var result = openFile.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var targetDir = Application.StartupPath+"\\";

            using (var zip = ZipFile.Read(openFile.FileName))
            {
                zip["CodeSmith.Engine.dll"].Extract(targetDir, ExtractExistingFileAction.OverwriteSilently);
                zip["license.rtf"].Extract(targetDir, ExtractExistingFileAction.OverwriteSilently);
            }

            File.Delete(targetDir + "CodeSmith.license.rtf");
            FileSystem.Rename(targetDir + "license.rtf", targetDir + "CodeSmith.license.rtf");
        }

    }
}
