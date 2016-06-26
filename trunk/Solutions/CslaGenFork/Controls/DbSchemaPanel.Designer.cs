using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using DBSchemaInfo.Base;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator.Controls
{
    partial class DbSchemaPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DbSchemaPanel));
            this.splitMiddle = new Splitter();
            this.schemaImages = new ImageList(this.components);
            this.columnsContextMenuStrip = new ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new ToolStripMenuItem();
            this.addToCslaObjectToolStripMenuItem = new ToolStripMenuItem();
            this.addInheritedValuePropertyToolStripMenuItem = new ToolStripMenuItem();
            this.createEditableToolStripMenuItem = new ToolStripMenuItem();
            this.editableRootToolStripMenuItem = new ToolStripMenuItem();
            this.editableRootCollectionToolStripMenuItem = new ToolStripMenuItem();
            this.editableChildToolStripMenuItem = new ToolStripMenuItem();
            this.editableChildCollectionToolStripMenuItem = new ToolStripMenuItem();
            this.dynamicEditableRootCollectionToolStripMenuItem = new ToolStripMenuItem();
            this.createReadOnlyToolStripMenuItem = new ToolStripMenuItem();
            this.readOnlyRootToolStripMenuItem = new ToolStripMenuItem();
            this.readOnlyChildToolStripMenuItem = new ToolStripMenuItem();
            this.readOnlyRootCollectionToolStripMenuItem = new ToolStripMenuItem();
            this.readOnlyChildCollectionToolStripMenuItem = new ToolStripMenuItem();
            this.nameValueListToolStripMenuItem = new ToolStripMenuItem();
            this.newCriteriaToolStripMenuItem = new ToolStripMenuItem();
            this.schemaContextMenuStrip = new ContextMenuStrip(this.components);
            this.createEditableRootToolStripMenuItem = new ToolStripMenuItem();
            this.createReadOnlyRootToolStripMenuItem = new ToolStripMenuItem();
            this.createEditableRootCollectionToolStripMenuItem = new ToolStripMenuItem();
            this.createReadOnlyRootCollectionToolStripMenuItem = new ToolStripMenuItem();
            this.createDynamicEditableRootCollectionToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.reloadToolStripMenuItem = new ToolStripMenuItem();
            this.dbColumns = new DbColumns();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.copySoftDeleteToolStripMenuItem = new ToolStripMenuItem();
            this.dbTreeView = new DbTreeView();
            this.paneDbName = new PaneCaption();
            this.columnsContextMenuStrip.SuspendLayout();
            this.schemaContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMiddle
            // 
            this.splitMiddle.BorderStyle = BorderStyle.Fixed3D;
            this.splitMiddle.Location = new Point(168, 26);
            this.splitMiddle.Name = "splitMiddle";
            this.splitMiddle.Size = new Size(6, 446);
            this.splitMiddle.TabIndex = 8;
            this.splitMiddle.TabStop = false;
            // 
            // schemaImages
            // 
            this.schemaImages.ImageStream = ((ImageListStreamer)(resources.GetObject("schemaImages.ImageStream")));
            this.schemaImages.TransparentColor = Color.Black;
            this.schemaImages.Images.SetKeyName(0, "0db.png");
            this.schemaImages.Images.SetKeyName(1, "1.png");
            this.schemaImages.Images.SetKeyName(2, "2.png");
            this.schemaImages.Images.SetKeyName(3, "3.png");
            this.schemaImages.Images.SetKeyName(4, "4.png");
            this.schemaImages.Images.SetKeyName(5, "5.png");
            this.schemaImages.Images.SetKeyName(6, "6.png");
            this.schemaImages.Images.SetKeyName(7, "7.png");
            this.schemaImages.Images.SetKeyName(8, "8.png");
            this.schemaImages.Images.SetKeyName(9, "9.png");
            // 
            // columnsContextMenuStrip
            // 
            this.columnsContextMenuStrip.Items.AddRange(new ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.addToCslaObjectToolStripMenuItem,
            this.addInheritedValuePropertyToolStripMenuItem,
            this.createEditableToolStripMenuItem,
            this.createReadOnlyToolStripMenuItem,
            this.createDynamicEditableRootCollectionToolStripMenuItem,
            this.newCriteriaToolStripMenuItem});
            this.columnsContextMenuStrip.Name = "columnsContextMenuStrip";
            this.columnsContextMenuStrip.Size = new Size(226, 136);
            this.columnsContextMenuStrip.Opening += new CancelEventHandler(this.columnsContextMenuStrip_Opening);
            // 
            // addToCslaObjectToolStripMenuItem
            // 
            this.addToCslaObjectToolStripMenuItem.Name = "addToCslaObjectToolStripMenuItem";
            this.addToCslaObjectToolStripMenuItem.Size = new Size(225, 22);
            this.addToCslaObjectToolStripMenuItem.Text = "&Add to CSLA Object";
            this.addToCslaObjectToolStripMenuItem.Click += new EventHandler(this.addToCslaObjectToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new Size(225, 22);
            this.selectAllToolStripMenuItem.Text = "&Select All";
            this.selectAllToolStripMenuItem.Click += new EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.Size = new Size(225, 22);
            this.unselectAllToolStripMenuItem.Text = "&Unselect All";
            this.unselectAllToolStripMenuItem.Click += new EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // addInheritedValuePropertyToolStripMenuItem
            // 
            this.addInheritedValuePropertyToolStripMenuItem.Enabled = false;
            this.addInheritedValuePropertyToolStripMenuItem.Name = "addInheritedValuePropertyToolStripMenuItem";
            this.addInheritedValuePropertyToolStripMenuItem.Size = new Size(225, 22);
            this.addInheritedValuePropertyToolStripMenuItem.Text = "Add Inherited Value Property";
            // 
            // createEditableToolStripMenuItem
            // 
            this.createEditableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.editableRootToolStripMenuItem,
            this.editableChildToolStripMenuItem,
            this.editableRootCollectionToolStripMenuItem,
            this.editableChildCollectionToolStripMenuItem,
            this.dynamicEditableRootCollectionToolStripMenuItem});
            this.createEditableToolStripMenuItem.Name = "createEditableToolStripMenuItem";
            this.createEditableToolStripMenuItem.Size = new Size(225, 22);
            this.createEditableToolStripMenuItem.Text = "&Create Editable";
            // 
            // editableRootToolStripMenuItem
            // 
            this.editableRootToolStripMenuItem.Name = "editableRootToolStripMenuItem";
            this.editableRootToolStripMenuItem.Size = new Size(198, 22);
            this.editableRootToolStripMenuItem.Text = "&Editable Root";
            this.editableRootToolStripMenuItem.Click += new EventHandler(this.editableRootToolStripMenuItem_Click);
            // 
            // editableChildToolStripMenuItem
            // 
            this.editableChildToolStripMenuItem.Name = "editableChildToolStripMenuItem";
            this.editableChildToolStripMenuItem.Size = new Size(198, 22);
            this.editableChildToolStripMenuItem.Text = "Editable C&hild";
            this.editableChildToolStripMenuItem.Click += new EventHandler(this.editableChildToolStripMenuItem_Click);
            // 
            // editableRootCollectionToolStripMenuItem
            // 
            this.editableRootCollectionToolStripMenuItem.Name = "editableRootCollectionToolStripMenuItem";
            this.editableRootCollectionToolStripMenuItem.Size = new Size(198, 22);
            this.editableRootCollectionToolStripMenuItem.Text = "&Editable Root Collection";
            this.editableRootCollectionToolStripMenuItem.Click += new EventHandler(this.editableRootCollectionToolStripMenuItem_Click);
            // 
            // editableChildCollectionToolStripMenuItem
            // 
            this.editableChildCollectionToolStripMenuItem.Name = "editableChildCollectionToolStripMenuItem";
            this.editableChildCollectionToolStripMenuItem.Size = new Size(198, 22);
            this.editableChildCollectionToolStripMenuItem.Text = "Editable C&hild Collection";
            this.editableChildCollectionToolStripMenuItem.Click += new EventHandler(this.editableChildCollectionToolStripMenuItem_Click);
            // 
            // dynamicEditableRootCollectionToolStripMenuItem
            // 
            this.dynamicEditableRootCollectionToolStripMenuItem.Name = "dynamicEditableRootCollectionToolStripMenuItem";
            this.dynamicEditableRootCollectionToolStripMenuItem.Size = new Size(198, 22);
            this.dynamicEditableRootCollectionToolStripMenuItem.Text = "Dynamic Editable Root &Collection";
            this.dynamicEditableRootCollectionToolStripMenuItem.Click += new EventHandler(this.dynamicEditableRootCollectionToolStripMenuItem_Click);
            // 
            // createReadOnlyToolStripMenuItem
            // 
            this.createReadOnlyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.readOnlyRootToolStripMenuItem,
            this.readOnlyChildToolStripMenuItem,
            this.readOnlyRootCollectionToolStripMenuItem,
            this.readOnlyChildCollectionToolStripMenuItem,
            this.nameValueListToolStripMenuItem});
            this.createReadOnlyToolStripMenuItem.Name = "createReadOnlyToolStripMenuItem";
            this.createReadOnlyToolStripMenuItem.Size = new Size(225, 22);
            this.createReadOnlyToolStripMenuItem.Text = "&Create Read Only";
            // 
            // readOnlyRootToolStripMenuItem
            // 
            this.readOnlyRootToolStripMenuItem.Name = "readOnlyRootToolStripMenuItem";
            this.readOnlyRootToolStripMenuItem.Size = new Size(198, 22);
            this.readOnlyRootToolStripMenuItem.Text = "&Read Only Root";
            this.readOnlyRootToolStripMenuItem.Click += new EventHandler(this.readOnlyRootToolStripMenuItem_Click);
            // 
            // readOnlyChildToolStripMenuItem
            // 
            this.readOnlyChildToolStripMenuItem.Name = "readOnlyChildToolStripMenuItem";
            this.readOnlyChildToolStripMenuItem.Size = new Size(198, 22);
            this.readOnlyChildToolStripMenuItem.Text = "&Read Only Child";
            this.readOnlyChildToolStripMenuItem.Click += new EventHandler(this.readOnlyChildToolStripMenuItem_Click);
            // 
            // readOnlyRootCollectionToolStripMenuItem
            // 
            this.readOnlyRootCollectionToolStripMenuItem.Name = "readOnlyRootCollectionToolStripMenuItem";
            this.readOnlyRootCollectionToolStripMenuItem.Size = new Size(198, 22);
            this.readOnlyRootCollectionToolStripMenuItem.Text = "&Read Only Root Collection";
            this.readOnlyRootCollectionToolStripMenuItem.Click += new EventHandler(this.readOnlyRootCollectionToolStripMenuItem_Click);
            // 
            // readOnlyChildCollectionToolStripMenuItem
            // 
            this.readOnlyChildCollectionToolStripMenuItem.Name = "readOnlyChildCollectionToolStripMenuItem";
            this.readOnlyChildCollectionToolStripMenuItem.Size = new Size(198, 22);
            this.readOnlyChildCollectionToolStripMenuItem.Text = "Read Only &Child Collection";
            this.readOnlyChildCollectionToolStripMenuItem.Click += new EventHandler(this.readOnlyChildCollectionToolStripMenuItem_Click);
            // 
            // nameValueListToolStripMenuItem
            // 
            this.nameValueListToolStripMenuItem.Name = "nameValueListToolStripMenuItem";
            this.nameValueListToolStripMenuItem.Size = new Size(198, 22);
            this.nameValueListToolStripMenuItem.Text = "Name &Value List";
            this.nameValueListToolStripMenuItem.Click += new EventHandler(this.nameValueListToolStripMenuItem_Click);
            // 
            // newCriteriaToolStripMenuItem
            // 
            this.newCriteriaToolStripMenuItem.Name = "newCriteriaToolStripMenuItem";
            this.newCriteriaToolStripMenuItem.Size = new Size(225, 22);
            this.newCriteriaToolStripMenuItem.Text = "New Criteria";
            this.newCriteriaToolStripMenuItem.Click += new EventHandler(this.newCriteriaToolStripMenuItem_Click);
            // 
            // schemaContextMenuStrip
            // 
            this.schemaContextMenuStrip.Items.AddRange(new ToolStripItem[] {
            this.createEditableRootToolStripMenuItem,
            this.createReadOnlyRootToolStripMenuItem,
            this.createEditableRootCollectionToolStripMenuItem,
            this.createReadOnlyRootCollectionToolStripMenuItem,
            this.createDynamicEditableRootCollectionToolStripMenuItem,
            this.toolStripSeparator1,
            this.reloadToolStripMenuItem,
            this.toolStripSeparator2,
            this.copySoftDeleteToolStripMenuItem});
            this.schemaContextMenuStrip.Name = "schemaContextMenuStrip";
            this.schemaContextMenuStrip.Size = new Size(226, 192);
            // 
            // createEditableRootToolStripMenuItem
            // 
            this.createEditableRootToolStripMenuItem.Name = "createEditableRootToolStripMenuItem";
            this.createEditableRootToolStripMenuItem.Size = new Size(234, 22);
            this.createEditableRootToolStripMenuItem.Text = "Create Editable Root";
            this.createEditableRootToolStripMenuItem.Click += new EventHandler(this.createEditableRootToolStripMenuItem_Click);
            // 
            // createReadOnlyRootToolStripMenuItem
            // 
            this.createReadOnlyRootToolStripMenuItem.Name = "createReadOnlyRootToolStripMenuItem";
            this.createReadOnlyRootToolStripMenuItem.Size = new Size(234, 22);
            this.createReadOnlyRootToolStripMenuItem.Text = "Create Read Only Root";
            this.createReadOnlyRootToolStripMenuItem.Click += new EventHandler(this.createReadOnlyRootToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(231, 6);
            // 
            // createEditableRootCollectionToolStripMenuItem
            // 
            this.createEditableRootCollectionToolStripMenuItem.Name = "createEditableRootCollectionToolStripMenuItem";
            this.createEditableRootCollectionToolStripMenuItem.Size = new Size(234, 22);
            this.createEditableRootCollectionToolStripMenuItem.Text = "Create Editable Root Collection";
            this.createEditableRootCollectionToolStripMenuItem.Click += new EventHandler(this.createEditableRootCollectionToolStripMenuItem_Click);
            // 
            // createReadOnlyRootCollectionToolStripMenuItem
            // 
            this.createReadOnlyRootCollectionToolStripMenuItem.Name = "createReadOnlyRootCollectionToolStripMenuItem";
            this.createReadOnlyRootCollectionToolStripMenuItem.Size = new Size(234, 22);
            this.createReadOnlyRootCollectionToolStripMenuItem.Text = "Create Read Only Root Collection";
            this.createReadOnlyRootCollectionToolStripMenuItem.Click += new EventHandler(this.createReadOnlyRootCollectionToolStripMenuItem_Click);
            // 
            // createDynamicEditableRootCollectionToolStripMenuItem
            // 
            this.createDynamicEditableRootCollectionToolStripMenuItem.Name = "createDynamicEditableRootCollectionToolStripMenuItem";
            this.createDynamicEditableRootCollectionToolStripMenuItem.Size = new Size(234, 22);
            this.createDynamicEditableRootCollectionToolStripMenuItem.Text = "Create Dynamic Editable Root Collection";
            this.createDynamicEditableRootCollectionToolStripMenuItem.Click += new EventHandler(this.createDynamicEditableRootCollectionToolStripMenuItem_Click);
            // 
            // dbColumns
            // 
            this.dbColumns.BackColor = SystemColors.Control;
            this.dbColumns.ContextMenuStrip = this.columnsContextMenuStrip;
            this.dbColumns.Dock = DockStyle.Fill;
            this.dbColumns.Location = new Point(174, 26);
            this.dbColumns.Name = "dbColumns";
            this.dbColumns.Size = new Size(210, 446);
            this.dbColumns.TabIndex = 10;
            // 
            // dbTreeView
            // 
            this.dbTreeView.ContextMenuStrip = this.schemaContextMenuStrip;
            this.dbTreeView.Dock = DockStyle.Left;
            this.dbTreeView.Location = new Point(0, 26);
            this.dbTreeView.Name = "dbTreeView";
            this.dbTreeView.Size = new Size(168, 446);
            this.dbTreeView.TabIndex = 9;
            // 
            // paneDbName
            // 
            this.paneDbName.AllowActive = false;
            this.paneDbName.AntiAlias = false;
            this.paneDbName.Caption = "Database Schema";
            this.paneDbName.Dock = DockStyle.Top;
            this.paneDbName.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.paneDbName.InactiveGradientHighColor = Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(92)))), ((int)(((byte)(181)))));
            this.paneDbName.InactiveGradientLowColor = Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(184)))), ((int)(((byte)(245)))));
            this.paneDbName.Location = new Point(0, 0);
            this.paneDbName.Name = "paneDbName";
            this.paneDbName.Size = new Size(384, 26);
            this.paneDbName.TabIndex = 0;
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new Size(234, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(222, 6);
            // 
            // copySoftDeleteToolStripMenuItem
            // 
            this.copySoftDeleteToolStripMenuItem.CheckOnClick = true;
            this.copySoftDeleteToolStripMenuItem.Name = "copySoftDeleteToolStripMenuItem";
            this.copySoftDeleteToolStripMenuItem.Size = new Size(225, 22);
            this.copySoftDeleteToolStripMenuItem.Text = "Copy soft delete column";
            this.copySoftDeleteToolStripMenuItem.ToolTipText = "Check this option if you want to force copying\r\nof the soft delete column to the created object of any kind.";
            // 
            // DbSchemaPanel
            // 
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.dbColumns);
            this.Controls.Add(this.splitMiddle);
            this.Controls.Add(this.dbTreeView);
            this.Controls.Add(this.paneDbName);
            this.ShowHint = DockState.Document;
            this.DockAreas = (DockAreas)
                             DockAreas.Document |
                             DockAreas.Float;
            this.Name = "DbSchemaPanel";
            this.TabText = "Schema";
            this.Text = "Schema";
            this.Shown += new EventHandler(this.DbSchemaPanel_Shown);
            this.ResizeBegin += new EventHandler(this.DbSchemaPanel_ResizeBegin);
            this.ResizeEnd += new EventHandler(this.DbSchemaPanel_ResizeEnd);
            this.Size = new Size(384, 472);
            this.Load += new EventHandler(this.DbSchemaPanel_Load);
            this.Resize += new EventHandler(this.DbSchemaPanel_Resize);
            this.columnsContextMenuStrip.ResumeLayout(false);
            this.schemaContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Splitter splitMiddle;
        private DbTreeView dbTreeView;
        private DbColumns dbColumns;
        private PaneCaption paneDbName;
        internal ImageList schemaImages;
        private ContextMenuStrip columnsContextMenuStrip;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem unselectAllToolStripMenuItem;
        private ToolStripMenuItem addToCslaObjectToolStripMenuItem;
        private ToolStripMenuItem addInheritedValuePropertyToolStripMenuItem;
        private ToolStripMenuItem createEditableToolStripMenuItem;
        private ToolStripMenuItem editableRootToolStripMenuItem;
        private ToolStripMenuItem editableRootCollectionToolStripMenuItem;
        private ToolStripMenuItem editableChildToolStripMenuItem;
        private ToolStripMenuItem editableChildCollectionToolStripMenuItem;
        private ToolStripMenuItem dynamicEditableRootCollectionToolStripMenuItem;
        private ToolStripMenuItem createReadOnlyToolStripMenuItem;
        private ToolStripMenuItem readOnlyRootToolStripMenuItem;
        private ToolStripMenuItem readOnlyChildToolStripMenuItem;
        private ToolStripMenuItem readOnlyRootCollectionToolStripMenuItem;
        private ToolStripMenuItem readOnlyChildCollectionToolStripMenuItem;
        private ToolStripMenuItem nameValueListToolStripMenuItem;
        private ToolStripMenuItem newCriteriaToolStripMenuItem;
        private ContextMenuStrip schemaContextMenuStrip;
        private ToolStripMenuItem createEditableRootToolStripMenuItem;
        private ToolStripMenuItem createReadOnlyRootToolStripMenuItem;
        private ToolStripMenuItem createEditableRootCollectionToolStripMenuItem;
        private ToolStripMenuItem createReadOnlyRootCollectionToolStripMenuItem;
        private ToolStripMenuItem createDynamicEditableRootCollectionToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem copySoftDeleteToolStripMenuItem;
    }
}
