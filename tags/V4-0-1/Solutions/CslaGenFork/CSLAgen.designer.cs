using CslaGenerator;
using CslaGenerator.Controls;
using System.Windows.Forms;
using System;
namespace CslaGenerator
{
    partial class CSLAgen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSLAgen));
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.ofdLoad = new System.Windows.Forms.OpenFileDialog();
            this.pgGrid = new System.Windows.Forms.PropertyGrid();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.objectRelationsBuilder = new CslaGenerator.Controls.ObjectRelationsBuilder();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAnewObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newObjectRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToObjectRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retrieveSummariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.locateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeSmithExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectRelationsBuilderPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectPropertiesPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newProjectButton = new System.Windows.Forms.ToolStripButton();
            this.openProjectButton = new System.Windows.Forms.ToolStripButton();
            this.saveProjectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addObjectButton = new System.Windows.Forms.ToolStripButton();
            this.deleteObjectButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateObjectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveuUpObjectButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownObjectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.newObjectRelationButton = new System.Windows.Forms.ToolStripButton();
            this.addToObjectRelationButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.connectDatabaseButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbGenerate = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.projectPanel = new CslaGenerator.Controls.ProjectPanel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgGrid
            // 
            this.pgGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.pgGrid.Location = new System.Drawing.Point(523, 66);
            this.pgGrid.Name = "pgGrid";
            this.pgGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgGrid.Size = new System.Drawing.Size(274, 479);
            this.pgGrid.TabIndex = 1;
            this.pgGrid.PropertySortChanged += OnSort;
            // 
            // webBrowser1
            // 
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(237, 66);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(280, 431);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // objectRelationsBuilder
            // 
            this.objectRelationsBuilder.AssociativeEntities = null;
            this.objectRelationsBuilder.Location = new System.Drawing.Point(237, 66);
            this.objectRelationsBuilder.MinimumSize = new System.Drawing.Size(20, 20);
            this.objectRelationsBuilder.Name = "objectRelationsBuilder";
            this.objectRelationsBuilder.Size = new System.Drawing.Size(280, 431);
            this.objectRelationsBuilder.TabIndex = 1;
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel1.Location = new System.Drawing.Point(0, 63);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(798, 477);
            this.dockPanel1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.dataBaseToolStripMenuItem,
            this.toolStripMenuItem4,
            this.viewToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.fileMenuSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Enabled = false;
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveasToolStripMenuItem.Text = "Save &as";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.saveasToolStripMenuItem_Click);
            // 
            // fileMenuSeparator1
            // 
            this.fileMenuSeparator1.Name = "fileMenuSeparator1";
            this.fileMenuSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAnewObjectToolStripMenuItem,
            this.removeSelectedObjectToolStripMenuItem,
            this.duplicateObjectToolStripMenuItem,
            this.projectMenuSeparator1,
            this.newObjectRelationToolStripMenuItem,
            this.addToObjectRelationToolStripMenuItem,
            this.projectMenuSeparator2,
            this.propertiesToolStripMenuItem});
            this.projectToolStripMenuItem.Enabled = false;
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.projectToolStripMenuItem.Text = "&Project";
            // 
            // addAnewObjectToolStripMenuItem
            // 
            this.addAnewObjectToolStripMenuItem.Name = "addAnewObjectToolStripMenuItem";
            this.addAnewObjectToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.addAnewObjectToolStripMenuItem.Text = "&Add a new object";
            this.addAnewObjectToolStripMenuItem.Click += new System.EventHandler(this.addAnewObjectToolStripMenuItem_Click);
            // 
            // removeSelectedObjectToolStripMenuItem
            // 
            this.removeSelectedObjectToolStripMenuItem.Name = "removeSelectedObjectToolStripMenuItem";
            this.removeSelectedObjectToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.removeSelectedObjectToolStripMenuItem.Text = "&Remove Selected Object";
            this.removeSelectedObjectToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedObjectToolStripMenuItem_Click);
            // 
            // duplicateObjectToolStripMenuItem
            // 
            this.duplicateObjectToolStripMenuItem.Name = "duplicateObjectToolStripMenuItem";
            this.duplicateObjectToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.duplicateObjectToolStripMenuItem.Text = "&Duplicate Selected Object";
            this.duplicateObjectToolStripMenuItem.Click += new System.EventHandler(this.duplicateObjectToolStripMenuItem_Click);
            // 
            // projectMenuSeparator1
            // 
            this.projectMenuSeparator1.Name = "projectMenuSeparator1";
            this.projectMenuSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // newObjectRelationToolStripMenuItem
            // 
            this.newObjectRelationToolStripMenuItem.Name = "newObjectRelationToolStripMenuItem";
            this.newObjectRelationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.newObjectRelationToolStripMenuItem.Text = "Add a new object relation";
            this.newObjectRelationToolStripMenuItem.Click += new System.EventHandler(this.newObjectRelationToolStripMenuItem_Click);
            // 
            // addToObjectRelationToolStripMenuItem
            // 
            this.addToObjectRelationToolStripMenuItem.Name = "addToObjectRelationToolStripMenuItem";
            this.addToObjectRelationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.addToObjectRelationToolStripMenuItem.Text = "Add to object &relation as ...";
            this.addToObjectRelationToolStripMenuItem.Click += new System.EventHandler(this.addToObjectRelationToolStripMenuItem_Click);
            // 
            // projectMenuSeparator2
            // 
            this.projectMenuSeparator2.Name = "projectMenuSeparator2";
            this.projectMenuSeparator2.Size = new System.Drawing.Size(220, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.propertiesToolStripMenuItem.Text = "&Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // dataBaseToolStripMenuItem
            // 
            this.dataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.refreshSchemaToolStripMenuItem,
            this.retrieveSummariesToolStripMenuItem});
            this.dataBaseToolStripMenuItem.Enabled = false;
            this.dataBaseToolStripMenuItem.Name = "dataBaseToolStripMenuItem";
            this.dataBaseToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.dataBaseToolStripMenuItem.Text = "&Database";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.connectToolStripMenuItem.Text = "&Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // refreshSchemaToolStripMenuItem
            // 
            this.refreshSchemaToolStripMenuItem.Name = "refreshSchemaToolStripMenuItem";
            this.refreshSchemaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.refreshSchemaToolStripMenuItem.Text = "&Refresh Schema";
            this.refreshSchemaToolStripMenuItem.Click += new System.EventHandler(this.refreshSchemaToolStripMenuItem_Click);
            // 
            // retrieveSummariesToolStripMenuItem
            // 
            this.retrieveSummariesToolStripMenuItem.Name = "retrieveSummariesToolStripMenuItem";
            this.retrieveSummariesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.retrieveSummariesToolStripMenuItem.Text = "Retrieve Summaries";
            this.retrieveSummariesToolStripMenuItem.Click += new System.EventHandler(this.retrieveSummariesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locateToolStripMenuItem,
            this.codeSmithExtensionToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem4.Text = "&Tools";
            // 
            // locateToolStripMenuItem
            // 
            this.locateToolStripMenuItem.Name = "locateToolStripMenuItem";
            this.locateToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.locateToolStripMenuItem.Text = "&Locate Template Directory";
            this.locateToolStripMenuItem.Click += new System.EventHandler(this.LocateToolStripMenuItemClick);
            // 
            // codeSmithExtensionToolStripMenuItem
            // 
            this.codeSmithExtensionToolStripMenuItem.Name = "codeSmithExtensionToolStripMenuItem";
            this.codeSmithExtensionToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.codeSmithExtensionToolStripMenuItem.Text = "CodeSmith Extension...";
            this.codeSmithExtensionToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.ShieldBitmap);
            this.codeSmithExtensionToolStripMenuItem.Click += new System.EventHandler(this.CodeSmithExtensionToolStripMenuItemClick);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Checked = true;
            this.viewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectPanelToolStripMenuItem,
            this.mainPageToolStripMenuItem,
            this.objectRelationsBuilderPageToolStripMenuItem,
            this.objectPropertiesPanelToolStripMenuItem,
            this.outputWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // projectPanelToolStripMenuItem
            // 
            this.projectPanelToolStripMenuItem.Checked = true;
            this.projectPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.projectPanelToolStripMenuItem.Name = "projectPanelToolStripMenuItem";
            this.projectPanelToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.projectPanelToolStripMenuItem.Text = "&Project Panel";
            this.projectPanelToolStripMenuItem.Click += new System.EventHandler(this.projectPanelToolStripMenuItem_Click);
            // 
            // mainPageToolStripMenuItem
            // 
            this.mainPageToolStripMenuItem.Checked = true;
            this.mainPageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mainPageToolStripMenuItem.Name = "mainPageToolStripMenuItem";
            this.mainPageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.mainPageToolStripMenuItem.Text = "&Main Page";
            this.mainPageToolStripMenuItem.Click += new System.EventHandler(this.mainPageToolStripMenuItem_Click);
            // 
            // objectRelationsBuilderPageToolStripMenuItem
            // 
            this.objectRelationsBuilderPageToolStripMenuItem.Checked = true;
            this.objectRelationsBuilderPageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objectRelationsBuilderPageToolStripMenuItem.Name = "objectRelationsBuilderPageToolStripMenuItem";
            this.objectRelationsBuilderPageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.objectRelationsBuilderPageToolStripMenuItem.Text = "Object Relations Builder Page";
            this.objectRelationsBuilderPageToolStripMenuItem.Click += new System.EventHandler(this.objectRelationsBuilderPageToolStripMenuItem_Click);
            // 
            // objectPropertiesPanelToolStripMenuItem
            // 
            this.objectPropertiesPanelToolStripMenuItem.Checked = true;
            this.objectPropertiesPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objectPropertiesPanelToolStripMenuItem.Name = "objectPropertiesPanelToolStripMenuItem";
            this.objectPropertiesPanelToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.objectPropertiesPanelToolStripMenuItem.Text = "&Object Properties Panel";
            this.objectPropertiesPanelToolStripMenuItem.Click += new System.EventHandler(this.objectPropertiesPanelToolStripMenuItem_Click);
            // 
            // outputWindowToolStripMenuItem
            // 
            this.outputWindowToolStripMenuItem.Checked = true;
            this.outputWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.outputWindowToolStripMenuItem.Name = "outputWindowToolStripMenuItem";
            this.outputWindowToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.outputWindowToolStripMenuItem.Text = "Output Window";
            this.outputWindowToolStripMenuItem.Click += new System.EventHandler(this.outputWindowToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectButton,
            this.openProjectButton,
            this.saveProjectButton,
            this.toolStripSeparator1,
            this.addObjectButton,
            this.deleteObjectButton,
            this.duplicateObjectButton,
            this.toolStripSeparator2,
            this.moveuUpObjectButton,
            this.moveDownObjectButton,
            this.toolStripSeparator3,
            this.newObjectRelationButton,
            this.addToObjectRelationButton,
            this.toolStripSeparator4,
            this.connectDatabaseButton,
            this.toolStripSeparator5,
            this.tsbGenerate,
            this.tsbCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 39);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newProjectButton
            // 
            this.newProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newProjectButton.Image = global::CslaGenerator.Properties.Resources.New_Project;
            this.newProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newProjectButton.Name = "newProjectButton";
            this.newProjectButton.Size = new System.Drawing.Size(36, 36);
            this.newProjectButton.Text = "New Project";
            this.newProjectButton.ToolTipText = "New Project";
            this.newProjectButton.Click += new System.EventHandler(this.newProjectButton_Click);
            // 
            // openProjectButton
            // 
            this.openProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openProjectButton.Image = global::CslaGenerator.Properties.Resources.Open_Project;
            this.openProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openProjectButton.Name = "openProjectButton";
            this.openProjectButton.Size = new System.Drawing.Size(36, 36);
            this.openProjectButton.Text = "Open Project";
            this.openProjectButton.ToolTipText = "Open Project";
            this.openProjectButton.Click += new System.EventHandler(this.openProjectButton_Click);
            // 
            // saveProjectButton
            // 
            this.saveProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveProjectButton.Enabled = false;
            this.saveProjectButton.Image = global::CslaGenerator.Properties.Resources.Save_Project;
            this.saveProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveProjectButton.Name = "saveProjectButton";
            this.saveProjectButton.Size = new System.Drawing.Size(36, 36);
            this.saveProjectButton.Text = "Save Project";
            this.saveProjectButton.ToolTipText = "Save Project";
            this.saveProjectButton.Click += new System.EventHandler(this.saveProjectButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // addObjectButton
            // 
            this.addObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addObjectButton.Enabled = false;
            this.addObjectButton.Image = global::CslaGenerator.Properties.Resources.Add_Object;
            this.addObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addObjectButton.Name = "addObjectButton";
            this.addObjectButton.Size = new System.Drawing.Size(36, 36);
            this.addObjectButton.Text = "Add Object";
            this.addObjectButton.ToolTipText = "Add Object";
            this.addObjectButton.Click += new System.EventHandler(this.addObjectButton_Click);
            // 
            // deleteObjectButton
            // 
            this.deleteObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteObjectButton.Enabled = false;
            this.deleteObjectButton.Image = global::CslaGenerator.Properties.Resources.Delete_Object;
            this.deleteObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteObjectButton.Name = "deleteObjectButton";
            this.deleteObjectButton.Size = new System.Drawing.Size(36, 36);
            this.deleteObjectButton.Text = "Delete Object";
            this.deleteObjectButton.Click += new System.EventHandler(this.deleteObjectButton_Click);
            // 
            // duplicateObjectButton
            // 
            this.duplicateObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.duplicateObjectButton.Enabled = false;
            this.duplicateObjectButton.Image = global::CslaGenerator.Properties.Resources.Duplicate_Object;
            this.duplicateObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.duplicateObjectButton.Name = "duplicateObjectButton";
            this.duplicateObjectButton.Size = new System.Drawing.Size(36, 36);
            this.duplicateObjectButton.Text = "Duplicate Object";
            this.duplicateObjectButton.Click += new System.EventHandler(this.duplicateObjectButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // moveuUpObjectButton
            // 
            this.moveuUpObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveuUpObjectButton.Enabled = false;
            this.moveuUpObjectButton.Image = global::CslaGenerator.Properties.Resources.Move_Up_Object;
            this.moveuUpObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveuUpObjectButton.Name = "moveuUpObjectButton";
            this.moveuUpObjectButton.Size = new System.Drawing.Size(36, 36);
            this.moveuUpObjectButton.Text = "Move Up Object";
            this.moveuUpObjectButton.Click += new System.EventHandler(this.moveuUpObjectButton_Click);
            // 
            // moveDownObjectButton
            // 
            this.moveDownObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownObjectButton.Enabled = false;
            this.moveDownObjectButton.Image = global::CslaGenerator.Properties.Resources.Move_Down_Object;
            this.moveDownObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownObjectButton.Name = "moveDownObjectButton";
            this.moveDownObjectButton.Size = new System.Drawing.Size(36, 36);
            this.moveDownObjectButton.Text = "Move Down Object";
            this.moveDownObjectButton.Click += new System.EventHandler(this.moveDownObjectButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // newRelationsObjectButton
            // 
            this.newObjectRelationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newObjectRelationButton.Enabled = false;
            this.newObjectRelationButton.Image = global::CslaGenerator.Properties.Resources.New_Relations_Object;
            this.newObjectRelationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newObjectRelationButton.Name = "newRelationsObjectButton";
            this.newObjectRelationButton.Size = new System.Drawing.Size(36, 36);
            this.newObjectRelationButton.Text = "Add a new object relation";
            this.newObjectRelationButton.Click += new System.EventHandler(this.newRelationsObjectButton_Click);
            // 
            // addToRelationButton
            // 
            this.addToObjectRelationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToObjectRelationButton.Enabled = false;
            this.addToObjectRelationButton.Image = global::CslaGenerator.Properties.Resources.Add_To_Relation;
            this.addToObjectRelationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToObjectRelationButton.Name = "addToRelationButton";
            this.addToObjectRelationButton.Size = new System.Drawing.Size(36, 36);
            this.addToObjectRelationButton.Text = "Add to object relation as ...";
            this.addToObjectRelationButton.Click += new System.EventHandler(this.addToRelationButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // connectDatabaseButton
            // 
            this.connectDatabaseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectDatabaseButton.Enabled = false;
            this.connectDatabaseButton.Image = global::CslaGenerator.Properties.Resources.Connect_to_Database;
            this.connectDatabaseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectDatabaseButton.Name = "connectDatabaseButton";
            this.connectDatabaseButton.Size = new System.Drawing.Size(36, 36);
            this.connectDatabaseButton.Text = "Connect To Database";
            this.connectDatabaseButton.Click += new System.EventHandler(this.connectDatabaseButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbGenerate
            // 
            this.tsbGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGenerate.Enabled = false;
            this.tsbGenerate.Image = global::CslaGenerator.Properties.Resources.generate;
            this.tsbGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGenerate.Name = "tsbGenerate";
            this.tsbGenerate.Size = new System.Drawing.Size(36, 36);
            this.tsbGenerate.Tag = "Generate";
            this.tsbGenerate.Text = "Generate";
            this.tsbGenerate.Click += new System.EventHandler(this.tsbGenerate_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancel.Enabled = false;
            this.tsbCancel.Image = global::CslaGenerator.Properties.Resources.generateCancel;
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(36, 36);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 524);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 18);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(79, 13);
            this.statusLabel.Text = "Csla Generator";
            // 
            // progressBar
            // 
            this.progressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar.Name = "progressBar";
            this.progressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.Visible = false;
            // 
            // projectPanel
            // 
            this.projectPanel.Location = new System.Drawing.Point(0, 66);
            this.projectPanel.Name = "projectPanel";
            this.projectPanel.Objects = null;
            this.projectPanel.Size = new System.Drawing.Size(231, 431);
            this.projectPanel.TabIndex = 0;
            // 
            // CSLAgen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.objectRelationsBuilder);
            this.Controls.Add(this.projectPanel);
            this.Controls.Add(this.pgGrid);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "CSLAgen";
            this.Text = "CSLAGEN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CSLAgen_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

}
		private GeneratorController _controller = null;
		//private CslaGenerator.Util.FolderBrowser fbGenerate;
		private System.Windows.Forms.SaveFileDialog sfdSave;
		private System.Windows.Forms.OpenFileDialog ofdLoad;
        private DbSchemaPanel dbSchemaPanel = null;
        private System.Windows.Forms.PropertyGrid pgGrid;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveasToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem projectToolStripMenuItem;
        private ToolStripMenuItem propertiesToolStripMenuItem;
        private ToolStripMenuItem addAnewObjectToolStripMenuItem;
        private ToolStripMenuItem removeSelectedObjectToolStripMenuItem;
        private ToolStripMenuItem dataBaseToolStripMenuItem;
        private ToolStripSeparator fileMenuSeparator1;
        private ToolStripSeparator projectMenuSeparator1;
        private ToolStripSeparator projectMenuSeparator2;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem refreshSchemaToolStripMenuItem;
        private ToolStripMenuItem retrieveSummariesToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem duplicateObjectToolStripMenuItem;
        private ToolStripMenuItem newObjectRelationToolStripMenuItem;
        private ToolStripMenuItem addToObjectRelationToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ProjectPanel projectPanel;
        private WebBrowser webBrowser1;
        private ObjectRelationsBuilder objectRelationsBuilder;
        #endregion

        private ToolStripButton newProjectButton;
        private ToolStripButton openProjectButton;
        private ToolStripButton saveProjectButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton addObjectButton;
        private ToolStripButton deleteObjectButton;
        private ToolStripButton duplicateObjectButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton moveuUpObjectButton;
        private ToolStripButton moveDownObjectButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton newObjectRelationButton;
        private ToolStripButton addToObjectRelationButton;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton connectDatabaseButton;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton tsbGenerate;
        private ToolStripButton tsbCancel;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem projectPanelToolStripMenuItem;
        private ToolStripMenuItem mainPageToolStripMenuItem;
        private ToolStripMenuItem objectRelationsBuilderPageToolStripMenuItem;
        private ToolStripMenuItem objectPropertiesPanelToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem outputWindowToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private ToolStripProgressBar progressBar;
        private ToolStripMenuItem pluginsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem locateToolStripMenuItem;
        private ToolStripMenuItem codeSmithExtensionToolStripMenuItem;
    }
}