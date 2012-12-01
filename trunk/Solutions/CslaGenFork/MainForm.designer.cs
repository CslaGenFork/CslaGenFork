using CslaGenerator;
using CslaGenerator.Controls;
using System.Windows.Forms;
using System;

namespace CslaGenerator
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mruItem0 = new System.Windows.Forms.ToolStripMenuItem();
            this.mruItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mruItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mruItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mruItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mruSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitResetLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAnewObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.newObjectRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToObjectRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retrieveSummariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.convertDateTimeToSmartDate = new System.Windows.Forms.ToolStripMenuItem();
            this.forceBackingFieldSmartDate = new System.Windows.Forms.ToolStripMenuItem();
            this.convertPropertiesAndCriteriaToSilverlight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.locateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeSmithExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectRelationsBuilderPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectPropertiesPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schemaPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectPropertiesPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.globalStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.errors = new System.Windows.Forms.ToolStripStatusLabel();
            this.warnings = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadingTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.objects = new System.Windows.Forms.ToolStripStatusLabel();
            this.tables = new System.Windows.Forms.ToolStripStatusLabel();
            this.views = new System.Windows.Forms.ToolStripStatusLabel();
            this.sprocs = new System.Windows.Forms.ToolStripStatusLabel();
            this.generatingTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.formSizePosition = new System.Windows.Forms.FormSizePosition(this.components);
            this.newProjectButton = new System.Windows.Forms.ToolStripButton();
            this.openProjectButton = new System.Windows.Forms.ToolStripButton();
            this.saveProjectButton = new System.Windows.Forms.ToolStripButton();
            this.addObjectButton = new System.Windows.Forms.ToolStripButton();
            this.deleteObjectButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateObjectButton = new System.Windows.Forms.ToolStripButton();
            this.moveuUpObjectButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownObjectButton = new System.Windows.Forms.ToolStripButton();
            this.newObjectRelationButton = new System.Windows.Forms.ToolStripButton();
            this.addToObjectRelationButton = new System.Windows.Forms.ToolStripButton();
            this.connectDatabaseButton = new System.Windows.Forms.ToolStripButton();
            this.generateButton = new System.Windows.Forms.ToolStripButton();
            this.cancelButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formSizePosition)).BeginInit();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.DefaultFloatWindowSize = new System.Drawing.Size(600, 400);
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel.Location = new System.Drawing.Point(0, 63);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(798, 477);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel.Skin = dockPanelSkin1;
            this.dockPanel.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.dataBaseToolStripMenuItem,
            this.toolStripMenuItem4,
            this.viewToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 14;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveasToolStripMenuItem,
            this.fileMenuSeparator1,
            this.mruItem0,
            this.mruItem1,
            this.mruItem2,
            this.mruItem3,
            this.mruItem4,
            this.mruSeparator,
            this.exitResetLayoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveasToolStripMenuItem
            // 
            this.saveasToolStripMenuItem.Enabled = false;
            this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            this.saveasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.saveasToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveasToolStripMenuItem.Text = "Save &as";
            this.saveasToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // fileMenuSeparator1
            // 
            this.fileMenuSeparator1.Name = "fileMenuSeparator1";
            this.fileMenuSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // mruItem0
            // 
            this.mruItem0.Enabled = true;
            this.mruItem0.Name = "mruItem0";
            this.mruItem0.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.mruItem0.Size = new System.Drawing.Size(112, 22);
            this.mruItem0.Text = "mruItem0";
            this.mruItem0.Click += new System.EventHandler(this.MruItem0_Click);
            // 
            // mruItem1
            // 
            this.mruItem1.Enabled = true;
            this.mruItem1.Name = "mruItem1";
            this.mruItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.mruItem1.Size = new System.Drawing.Size(112, 22);
            this.mruItem1.Text = "mruItem1";
            this.mruItem1.Click += new System.EventHandler(this.MruItem1_Click);
            // 
            // mruItem2
            // 
            this.mruItem2.Enabled = true;
            this.mruItem2.Name = "mruItem2";
            this.mruItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.mruItem2.Size = new System.Drawing.Size(112, 22);
            this.mruItem2.Text = "mruItem2";
            this.mruItem2.Click += new System.EventHandler(this.MruItem2_Click);
            // 
            // mruItem3
            // 
            this.mruItem3.Enabled = true;
            this.mruItem3.Name = "mruItem3";
            this.mruItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.mruItem3.Size = new System.Drawing.Size(112, 22);
            this.mruItem3.Text = "mruItem3";
            this.mruItem3.Click += new System.EventHandler(this.MruItem3_Click);
            // 
            // mruItem4
            // 
            this.mruItem4.Enabled = true;
            this.mruItem4.Name = "mruItem4";
            this.mruItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.mruItem4.Size = new System.Drawing.Size(112, 22);
            this.mruItem4.Text = "mruItem4";
            this.mruItem4.Click += new System.EventHandler(this.MruItem4_Click);
            // 
            // mruSeparator
            // 
            this.mruSeparator.Name = "mruSeparator";
            this.mruSeparator.Size = new System.Drawing.Size(109, 6);
            // 
            // exitResetLayoutToolStripMenuItem
            // 
            this.exitResetLayoutToolStripMenuItem.Name = "exitResetLayoutToolStripMenuItem";
            this.exitResetLayoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitResetLayoutToolStripMenuItem.Text = "&Quick Exit (resets docking layout)";
            this.exitResetLayoutToolStripMenuItem.Click += new System.EventHandler(this.ExitResetLayoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAnewObjectToolStripMenuItem,
            this.removeSelectedObjectToolStripMenuItem,
            this.duplicateObjectToolStripMenuItem,
            this.projectMenuSeparator1,
            this.selectAllObjectsToolStripMenuItem,
            this.projectMenuSeparator2,
            this.newObjectRelationToolStripMenuItem,
            this.addToObjectRelationToolStripMenuItem,
            this.projectMenuSeparator3,
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
            this.addAnewObjectToolStripMenuItem.Click += new System.EventHandler(this.AddAnewObjectToolStripMenuItem_Click);
            // 
            // removeSelectedObjectToolStripMenuItem
            // 
            this.removeSelectedObjectToolStripMenuItem.Name = "removeSelectedObjectToolStripMenuItem";
            this.removeSelectedObjectToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.removeSelectedObjectToolStripMenuItem.Text = "&Remove Selected Object";
            this.removeSelectedObjectToolStripMenuItem.Click += new System.EventHandler(this.RemoveSelectedObjectToolStripMenuItem_Click);
            // 
            // duplicateObjectToolStripMenuItem
            // 
            this.duplicateObjectToolStripMenuItem.Name = "duplicateObjectToolStripMenuItem";
            this.duplicateObjectToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.duplicateObjectToolStripMenuItem.Text = "&Duplicate Selected Object";
            this.duplicateObjectToolStripMenuItem.Click += new System.EventHandler(this.DuplicateObjectToolStripMenuItem_Click);
            // 
            // projectMenuSeparator1
            // 
            this.projectMenuSeparator1.Name = "projectMenuSeparator1";
            this.projectMenuSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // selectAllObjectsToolStripMenuItem
            // 
            this.selectAllObjectsToolStripMenuItem.Name = "selectAllObjectsToolStripMenuItem";
            this.selectAllObjectsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.selectAllObjectsToolStripMenuItem.Text = "&Select All Objects";
            this.selectAllObjectsToolStripMenuItem.Click += new System.EventHandler(this.SelectAllObjectsToolStripMenuItem_Click);
            // 
            // projectMenuSeparator2
            // 
            this.projectMenuSeparator2.Name = "projectMenuSeparator2";
            this.projectMenuSeparator2.Size = new System.Drawing.Size(220, 6);
            // 
            // newObjectRelationToolStripMenuItem
            // 
            this.newObjectRelationToolStripMenuItem.Name = "newObjectRelationToolStripMenuItem";
            this.newObjectRelationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.newObjectRelationToolStripMenuItem.Text = "Add a new object relation";
            this.newObjectRelationToolStripMenuItem.Click += new System.EventHandler(this.NewObjectRelationToolStripMenuItem_Click);
            // 
            // addToObjectRelationToolStripMenuItem
            // 
            this.addToObjectRelationToolStripMenuItem.Name = "addToObjectRelationToolStripMenuItem";
            this.addToObjectRelationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.addToObjectRelationToolStripMenuItem.Text = "Add to object &relation as ...";
            this.addToObjectRelationToolStripMenuItem.Click += new System.EventHandler(this.AddToObjectRelationToolStripMenuItem_Click);
            // 
            // projectMenuSeparator3
            // 
            this.projectMenuSeparator3.Name = "projectMenuSeparator3";
            this.projectMenuSeparator3.Size = new System.Drawing.Size(220, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.propertiesToolStripMenuItem.Text = "&Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
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
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // refreshSchemaToolStripMenuItem
            // 
            this.refreshSchemaToolStripMenuItem.Name = "refreshSchemaToolStripMenuItem";
            this.refreshSchemaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.refreshSchemaToolStripMenuItem.Text = "&Refresh Schema";
            this.refreshSchemaToolStripMenuItem.Click += new System.EventHandler(this.RefreshSchemaToolStripMenuItem_Click);
            // 
            // retrieveSummariesToolStripMenuItem
            // 
            this.retrieveSummariesToolStripMenuItem.Name = "retrieveSummariesToolStripMenuItem";
            this.retrieveSummariesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.retrieveSummariesToolStripMenuItem.Text = "Retrieve Summaries";
            this.retrieveSummariesToolStripMenuItem.Click += new System.EventHandler(this.RetrieveSummariesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertDateTimeToSmartDate,
            this.forceBackingFieldSmartDate,
            this.convertPropertiesAndCriteriaToSilverlight,
            this.toolStripSeparator6,
            this.locateToolStripMenuItem,
            this.codeSmithExtensionToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem4.Text = "&Tools";
            // 
            // convertDateTimeToSmartDate
            // 
            this.convertDateTimeToSmartDate.Enabled = false;
            this.convertDateTimeToSmartDate.Name = "convertDateTimeToSmartDate";
            this.convertDateTimeToSmartDate.Size = new System.Drawing.Size(200, 22);
            this.convertDateTimeToSmartDate.Text = "Convert &DateTime to SmartDate properties";
            this.convertDateTimeToSmartDate.Click += new System.EventHandler(this.ConvertDateTimeToSmartDate_Click);
            // 
            // forceBackingFieldSmartDate
            // 
            this.forceBackingFieldSmartDate.Enabled = false;
            this.forceBackingFieldSmartDate.Name = "forceBackingFieldSmartDate";
            this.forceBackingFieldSmartDate.Size = new System.Drawing.Size(200, 22);
            this.forceBackingFieldSmartDate.Text = "Force backing field on &SmartDate properties";
            this.forceBackingFieldSmartDate.Click += new System.EventHandler(this.ForceBackingFieldSmartDate_Click);
            // 
            // convertPropertiesAndCriteriaToSilverlight
            // 
            this.convertPropertiesAndCriteriaToSilverlight.Enabled = false;
            this.convertPropertiesAndCriteriaToSilverlight.Name = "convertPropertiesAndCriteriaToSilverlight";
            this.convertPropertiesAndCriteriaToSilverlight.Size = new System.Drawing.Size(200, 22);
            this.convertPropertiesAndCriteriaToSilverlight.Text = "Convert Properties and Criteria to be &Silverlight compatible";
            this.convertPropertiesAndCriteriaToSilverlight.Click += new System.EventHandler(this.ConvertPropertiesAndCriteriaToSilverlight_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // locateToolStripMenuItem
            // 
            this.locateToolStripMenuItem.Name = "locateToolStripMenuItem";
            this.locateToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.locateToolStripMenuItem.Text = "&Locate Template Directory";
            this.locateToolStripMenuItem.Click += new System.EventHandler(this.LocateToolStripMenuItem_Click);
            // 
            // codeSmithExtensionToolStripMenuItem
            // 
            this.codeSmithExtensionToolStripMenuItem.Name = "codeSmithExtensionToolStripMenuItem";
            this.codeSmithExtensionToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.codeSmithExtensionToolStripMenuItem.Text = "&CodeSmith Extension...";
            this.codeSmithExtensionToolStripMenuItem.Click += new System.EventHandler(this.CodeSmithExtensionToolStripMenuItem_Click);
            this.codeSmithExtensionToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(ShieldBitmap);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Checked = true;
            this.viewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectPanelToolStripMenuItem,
            this.startPageToolStripMenuItem,
            this.objectRelationsBuilderPageToolStripMenuItem,
            this.projectPropertiesPageToolStripMenuItem,
            this.schemaPageToolStripMenuItem,
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
            this.projectPanelToolStripMenuItem.Click += new System.EventHandler(this.ProjectPanelToolStripMenuItem_Click);
            // 
            // startPageToolStripMenuItem
            // 
            this.startPageToolStripMenuItem.Checked = true;
            this.startPageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startPageToolStripMenuItem.Name = "startPageToolStripMenuItem";
            this.startPageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.startPageToolStripMenuItem.Text = "&Start Page";
            this.startPageToolStripMenuItem.Click += new System.EventHandler(this.StartPageToolStripMenuItem_Click);
            // 
            // objectRelationsBuilderPageToolStripMenuItem
            // 
            this.objectRelationsBuilderPageToolStripMenuItem.Name = "objectRelationsBuilderPageToolStripMenuItem";
            this.objectRelationsBuilderPageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.objectRelationsBuilderPageToolStripMenuItem.Text = "Object &Relations Builder Page";
            this.objectRelationsBuilderPageToolStripMenuItem.Click += new System.EventHandler(this.ObjectRelationsBuilderPageToolStripMenuItemClick);
            // 
            // projectPropertiesPageToolStripMenuItem
            // 
            this.projectPropertiesPageToolStripMenuItem.Name = "projectPropertiesPageToolStripMenuItem";
            this.projectPropertiesPageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.projectPropertiesPageToolStripMenuItem.Text = "Pro&ject Properties Page";
            this.projectPropertiesPageToolStripMenuItem.Click += new System.EventHandler(this.ProjectPropertiesPageToolStripMenuItemClick);
            // 
            // schemaPageToolStripMenuItem
            // 
            this.schemaPageToolStripMenuItem.Name = "schemaPageToolStripMenuItem";
            this.schemaPageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.schemaPageToolStripMenuItem.Text = "Sch&ema Page";
            this.schemaPageToolStripMenuItem.Click += new System.EventHandler(this.SchemaPageToolStripMenuItemClick);
            // 
            // objectPropertiesPanelToolStripMenuItem
            // 
            this.objectPropertiesPanelToolStripMenuItem.Checked = true;
            this.objectPropertiesPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objectPropertiesPanelToolStripMenuItem.Name = "objectPropertiesPanelToolStripMenuItem";
            this.objectPropertiesPanelToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.objectPropertiesPanelToolStripMenuItem.Text = "&Object Properties Panel";
            this.objectPropertiesPanelToolStripMenuItem.Click += new System.EventHandler(this.ObjectPropertiesPanelToolStripMenuItem_Click);
            // 
            // outputWindowToolStripMenuItem
            // 
            this.outputWindowToolStripMenuItem.Checked = true;
            this.outputWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.outputWindowToolStripMenuItem.Name = "outputWindowToolStripMenuItem";
            this.outputWindowToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.outputWindowToolStripMenuItem.Text = "Outpu&t Window";
            this.outputWindowToolStripMenuItem.Click += new System.EventHandler(this.OutputWindowToolStripMenuItem_Click);
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
            this.aboutToolStripMenuItem.Text = "&About Csla Generator Fork";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.generateButton,
            this.cancelButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 39);
            this.toolStrip.TabIndex = 15;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalStatus,
            this.errors,
            this.warnings,
            this.loadingTimer,
            this.objects,
            this.tables,
            this.views,
            this.sprocs,
            this.generatingTimer,
            this.progressBar});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip.Location = new System.Drawing.Point(0, 524);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(800, 18);
            this.statusStrip.TabIndex = 17;
            this.statusStrip.Text = "statusStrip";
            // 
            // globalStatus
            // 
            this.globalStatus.AutoSize = false;
            this.globalStatus.AutoToolTip = true;
            this.globalStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.globalStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.globalStatus.DoubleClickEnabled = true;
            this.globalStatus.Image = global::CslaGenerator.Properties.Resources.White;
            this.globalStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.globalStatus.Margin = new System.Windows.Forms.Padding(4, 4, 1, -1);
            this.globalStatus.Name = "globalStatus";
            this.globalStatus.Size = new System.Drawing.Size(80, 19);
            this.globalStatus.Text = "Status       ";
            this.globalStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.globalStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.globalStatus.ToolTipText = "No project loaded.";
            // 
            // errors
            // 
            this.errors.AutoSize = false;
            this.errors.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.errors.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.errors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.errors.Margin = new System.Windows.Forms.Padding(1, 4, 1, -1);
            this.errors.Name = "errors";
            this.errors.Size = new System.Drawing.Size(70, 19);
            this.errors.Text = "Errors";
            this.errors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.errors.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.errors.DoubleClick += new System.EventHandler(this.Errors_DoubleClick);
            // 
            // warnings
            // 
            this.warnings.AutoSize = false;
            this.warnings.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.warnings.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.warnings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.warnings.Margin = new System.Windows.Forms.Padding(1, 4, 1, -1);
            this.warnings.Name = "warnings";
            this.warnings.Size = new System.Drawing.Size(80, 19);
            this.warnings.Text = "Warnings";
            this.warnings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.warnings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.warnings.DoubleClick += new System.EventHandler(this.Warnings_DoubleClick);
            // 
            // loadingTimer
            // 
            this.loadingTimer.AutoSize = false;
            this.loadingTimer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.loadingTimer.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.loadingTimer.Margin = new System.Windows.Forms.Padding(1, 4, 1, -1);
            this.loadingTimer.Name = "loadingTimer";
            this.loadingTimer.Size = new System.Drawing.Size(102, 19);
            //this.loadingTimer.Text = "Loading: 00:00,000";
            this.loadingTimer.Text = "Loading:";
            this.loadingTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // objects
            // 
            this.objects.AutoSize = false;
            this.objects.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.objects.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.objects.Margin = new System.Windows.Forms.Padding(1, 4, 1, -1);
            this.objects.Name = "objects";
            this.objects.Size = new System.Drawing.Size(70, 19);
            //this.objects.Text = "Objects: 000";
            this.objects.Text = "Objects:";
            this.objects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tables
            // 
            this.tables.AutoSize = false;
            this.tables.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tables.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tables.Margin = new System.Windows.Forms.Padding(1, 4, 1, -1);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(70, 19);
            //this.tables.Text = "Tables: 0000";
            this.tables.Text = "Tables:";
            this.tables.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // views
            // 
            this.views.AutoSize = false;
            this.views.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.views.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.views.Margin = new System.Windows.Forms.Padding(1, 4, 1, -1);
            this.views.Name = "views";
            this.views.Size = new System.Drawing.Size(66, 19);
            //this.views.Text = "Views: 0000";
            this.views.Text = "Views:";
            this.views.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sprocs
            // 
            this.sprocs.AutoSize = false;
            this.sprocs.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.sprocs.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.sprocs.Margin = new System.Windows.Forms.Padding(1, 4, 1, -1);
            this.sprocs.Name = "sprocs";
            this.sprocs.Size = new System.Drawing.Size(71, 19);
            //this.sprocs.Text = "SProcs: 0000";
            this.sprocs.Text = "SProcs:";
            this.sprocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // generatingTimer
            // 
            this.generatingTimer.AutoSize = false;
            this.generatingTimer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.generatingTimer.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.generatingTimer.Margin = new System.Windows.Forms.Padding(1, 4, 1, -1);
            this.generatingTimer.Name = "generatingTimer";
            this.generatingTimer.Size = new System.Drawing.Size(118, 19);
            //this.generatingTimer.Text = "Generating: 00:00,000";
            this.generatingTimer.Text = "Generating:";
            this.generatingTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar.AutoSize = false;
            this.progressBar.Margin = new System.Windows.Forms.Padding(1, 4, 1, -1);
            this.progressBar.Name = "progressBar";
            this.progressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.progressBar.Size = new System.Drawing.Size(100, 18);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.Visible = false;
            // 
            // formSizePosition
            // 
            this.formSizePosition.Form = this;
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
            this.newProjectButton.Click += new System.EventHandler(this.NewProjectButton_Click);
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
            this.openProjectButton.Click += new System.EventHandler(this.OpenProjectButton_Click);
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
            this.saveProjectButton.Click += new System.EventHandler(this.SaveProjectButton_Click);
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
            this.addObjectButton.Click += new System.EventHandler(this.AddObjectButton_Click);
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
            this.deleteObjectButton.Click += new System.EventHandler(this.DeleteObjectButton_Click);
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
            this.duplicateObjectButton.Click += new System.EventHandler(this.DuplicateObjectButton_Click);
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
            this.moveuUpObjectButton.Click += new System.EventHandler(this.MoveuUpObjectButton_Click);
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
            this.moveDownObjectButton.Click += new System.EventHandler(this.MoveDownObjectButton_Click);
            // 
            // newObjectRelationButton
            // 
            this.newObjectRelationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newObjectRelationButton.Enabled = false;
            this.newObjectRelationButton.Image = global::CslaGenerator.Properties.Resources.New_Relations_Object;
            this.newObjectRelationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newObjectRelationButton.Name = "newObjectRelationButton";
            this.newObjectRelationButton.Size = new System.Drawing.Size(36, 36);
            this.newObjectRelationButton.Text = "Add a new object relation";
            this.newObjectRelationButton.Click += new System.EventHandler(this.NewObjectRelationButton_Click);
            // 
            // addToObjectRelationButton
            // 
            this.addToObjectRelationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToObjectRelationButton.Enabled = false;
            this.addToObjectRelationButton.Image = global::CslaGenerator.Properties.Resources.Add_To_Relation;
            this.addToObjectRelationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToObjectRelationButton.Name = "addToObjectRelationButton";
            this.addToObjectRelationButton.Size = new System.Drawing.Size(36, 36);
            this.addToObjectRelationButton.Text = "Add to object relation as ...";
            this.addToObjectRelationButton.Click += new System.EventHandler(this.AddToObjectRelationButton_Click);
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
            this.connectDatabaseButton.Click += new System.EventHandler(this.ConnectDatabaseButton_Click);
            // 
            // tsbGenerate
            // 
            this.generateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.generateButton.Enabled = false;
            this.generateButton.Image = global::CslaGenerator.Properties.Resources.generate;
            this.generateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generateButton.Name = "tsbGenerate";
            this.generateButton.Size = new System.Drawing.Size(36, 36);
            this.generateButton.Tag = "Generate";
            this.generateButton.Text = "Generate";
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // tsbCancel
            // 
            this.cancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cancelButton.Enabled = false;
            this.cancelButton.Image = global::CslaGenerator.Properties.Resources.generateCancel;
            this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelButton.Name = "tsbCancel";
            this.cancelButton.Size = new System.Drawing.Size(36, 36);
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "CslaGenFork";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formSizePosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

}
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveasToolStripMenuItem;
        private ToolStripMenuItem exitResetLayoutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem projectToolStripMenuItem;
        private ToolStripMenuItem propertiesToolStripMenuItem;
        private ToolStripMenuItem addAnewObjectToolStripMenuItem;
        private ToolStripMenuItem removeSelectedObjectToolStripMenuItem;
        private ToolStripMenuItem dataBaseToolStripMenuItem;
        private ToolStripSeparator fileMenuSeparator1;
        private ToolStripMenuItem mruItem0;
        private ToolStripMenuItem mruItem1;
        private ToolStripMenuItem mruItem2;
        private ToolStripMenuItem mruItem3;
        private ToolStripMenuItem mruItem4;
        private ToolStripSeparator mruSeparator;
        private ToolStripSeparator projectMenuSeparator1;
        private ToolStripSeparator projectMenuSeparator2;
        private ToolStripSeparator projectMenuSeparator3;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem refreshSchemaToolStripMenuItem;
        private ToolStripMenuItem retrieveSummariesToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem duplicateObjectToolStripMenuItem;
        private ToolStripMenuItem selectAllObjectsToolStripMenuItem;
        private ToolStripMenuItem newObjectRelationToolStripMenuItem;
        private ToolStripMenuItem addToObjectRelationToolStripMenuItem;
        private ToolStrip toolStrip;
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
        private ToolStripButton generateButton;
        private ToolStripButton cancelButton;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem projectPanelToolStripMenuItem;
        private ToolStripMenuItem startPageToolStripMenuItem;
        private ToolStripMenuItem objectRelationsBuilderPageToolStripMenuItem;
        private ToolStripMenuItem projectPropertiesPageToolStripMenuItem;
        private ToolStripMenuItem schemaPageToolStripMenuItem;
        private ToolStripMenuItem objectPropertiesPanelToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private ToolStripMenuItem outputWindowToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel globalStatus;
        private ToolStripStatusLabel errors;
        private ToolStripStatusLabel warnings;
        private ToolStripStatusLabel loadingTimer;
        private ToolStripStatusLabel objects;
        private ToolStripStatusLabel tables;
        private ToolStripStatusLabel views;
        private ToolStripStatusLabel sprocs;
        private ToolStripStatusLabel generatingTimer;
        private ToolStripProgressBar progressBar;
        private ToolStripMenuItem pluginsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem convertDateTimeToSmartDate;
        private ToolStripMenuItem forceBackingFieldSmartDate;
        private ToolStripMenuItem convertPropertiesAndCriteriaToSilverlight;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem locateToolStripMenuItem;
        private ToolStripMenuItem codeSmithExtensionToolStripMenuItem;
        internal FormSizePosition formSizePosition;
    }
}