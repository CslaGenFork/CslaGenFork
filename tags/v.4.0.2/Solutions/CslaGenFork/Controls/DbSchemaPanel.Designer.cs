using System.Windows.Forms;

namespace CslaGenerator.Controls
{
    partial class DbSchemaPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbSchemaPanel));
            this.splitMiddle = new System.Windows.Forms.Splitter();
            this.schemaImages = new System.Windows.Forms.ImageList(this.components);
            this.columnsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToCslaObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addInheritedValuePropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEditableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editableRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editableRootCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editableChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editableChildCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynamicEditableRootCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createReadOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOnlyRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOnlyChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOnlyRootCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOnlyChildCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameValueListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCriteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schemaContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createEditableRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createReadOnlyRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEditableRootCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createReadOnlyRootCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDynamicEditableRootCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbColumns1 = new CslaGenerator.Controls.DbColumns();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copySoftDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbTreeView1 = new CslaGenerator.Controls.DbTreeView();
            this.paneDbName = new CslaGenerator.Controls.PaneCaption();
            this.columnsContextMenuStrip.SuspendLayout();
            this.schemaContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMiddle
            // 
            this.splitMiddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitMiddle.Location = new System.Drawing.Point(168, 26);
            this.splitMiddle.Name = "splitMiddle";
            this.splitMiddle.Size = new System.Drawing.Size(6, 446);
            this.splitMiddle.TabIndex = 8;
            this.splitMiddle.TabStop = false;
            // 
            // schemaImages
            // 
            this.schemaImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("schemaImages.ImageStream")));
            this.schemaImages.TransparentColor = System.Drawing.Color.Black;
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
            this.columnsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.addToCslaObjectToolStripMenuItem,
            this.addInheritedValuePropertyToolStripMenuItem,
            this.createEditableToolStripMenuItem,
            this.createReadOnlyToolStripMenuItem,
            this.createDynamicEditableRootCollectionToolStripMenuItem,
            this.newCriteriaToolStripMenuItem});
            this.columnsContextMenuStrip.Name = "columnsContextMenuStrip";
            this.columnsContextMenuStrip.Size = new System.Drawing.Size(226, 136);
            this.columnsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.columnsContextMenuStrip_Opening);
            // 
            // addToCslaObjectToolStripMenuItem
            // 
            this.addToCslaObjectToolStripMenuItem.Name = "addToCslaObjectToolStripMenuItem";
            this.addToCslaObjectToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.addToCslaObjectToolStripMenuItem.Text = "&Add to CSLA Object";
            this.addToCslaObjectToolStripMenuItem.Click += new System.EventHandler(this.addToCslaObjectToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.selectAllToolStripMenuItem.Text = "&Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.unselectAllToolStripMenuItem.Text = "&Unselect All";
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // addInheritedValuePropertyToolStripMenuItem
            // 
            this.addInheritedValuePropertyToolStripMenuItem.Enabled = false;
            this.addInheritedValuePropertyToolStripMenuItem.Name = "addInheritedValuePropertyToolStripMenuItem";
            this.addInheritedValuePropertyToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.addInheritedValuePropertyToolStripMenuItem.Text = "Add Inherited Value Property";
            // 
            // createEditableToolStripMenuItem
            // 
            this.createEditableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editableRootToolStripMenuItem,
            this.editableChildToolStripMenuItem,
            this.editableRootCollectionToolStripMenuItem,
            this.editableChildCollectionToolStripMenuItem,
            this.dynamicEditableRootCollectionToolStripMenuItem});
            this.createEditableToolStripMenuItem.Name = "createEditableToolStripMenuItem";
            this.createEditableToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.createEditableToolStripMenuItem.Text = "&Create Editable";
            // 
            // editableRootToolStripMenuItem
            // 
            this.editableRootToolStripMenuItem.Name = "editableRootToolStripMenuItem";
            this.editableRootToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.editableRootToolStripMenuItem.Text = "&Editable Root";
            this.editableRootToolStripMenuItem.Click += new System.EventHandler(this.editableRootToolStripMenuItem_Click);
            // 
            // editableChildToolStripMenuItem
            // 
            this.editableChildToolStripMenuItem.Name = "editableChildToolStripMenuItem";
            this.editableChildToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.editableChildToolStripMenuItem.Text = "Editable C&hild";
            this.editableChildToolStripMenuItem.Click += new System.EventHandler(this.editableChildToolStripMenuItem_Click);
            // 
            // editableRootCollectionToolStripMenuItem
            // 
            this.editableRootCollectionToolStripMenuItem.Name = "editableRootCollectionToolStripMenuItem";
            this.editableRootCollectionToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.editableRootCollectionToolStripMenuItem.Text = "&Editable Root Collection";
            this.editableRootCollectionToolStripMenuItem.Click += new System.EventHandler(this.editableRootCollectionToolStripMenuItem_Click);
            // 
            // editableChildCollectionToolStripMenuItem
            // 
            this.editableChildCollectionToolStripMenuItem.Name = "editableChildCollectionToolStripMenuItem";
            this.editableChildCollectionToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.editableChildCollectionToolStripMenuItem.Text = "Editable C&hild Collection";
            this.editableChildCollectionToolStripMenuItem.Click += new System.EventHandler(this.editableChildCollectionToolStripMenuItem_Click);
            // 
            // dynamicEditableRootCollectionToolStripMenuItem
            // 
            this.dynamicEditableRootCollectionToolStripMenuItem.Name = "dynamicEditableRootCollectionToolStripMenuItem";
            this.dynamicEditableRootCollectionToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.dynamicEditableRootCollectionToolStripMenuItem.Text = "Dynamic Editable Root &Collection";
            this.dynamicEditableRootCollectionToolStripMenuItem.Click += new System.EventHandler(this.dynamicEditableRootCollectionToolStripMenuItem_Click);
            // 
            // createReadOnlyToolStripMenuItem
            // 
            this.createReadOnlyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readOnlyRootToolStripMenuItem,
            this.readOnlyChildToolStripMenuItem,
            this.readOnlyRootCollectionToolStripMenuItem,
            this.readOnlyChildCollectionToolStripMenuItem,
            this.nameValueListToolStripMenuItem});
            this.createReadOnlyToolStripMenuItem.Name = "createReadOnlyToolStripMenuItem";
            this.createReadOnlyToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.createReadOnlyToolStripMenuItem.Text = "&Create Read Only";
            // 
            // readOnlyRootToolStripMenuItem
            // 
            this.readOnlyRootToolStripMenuItem.Name = "readOnlyRootToolStripMenuItem";
            this.readOnlyRootToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.readOnlyRootToolStripMenuItem.Text = "&Read Only Root";
            this.readOnlyRootToolStripMenuItem.Click += new System.EventHandler(this.readOnlyRootToolStripMenuItem_Click);
            // 
            // readOnlyChildToolStripMenuItem
            // 
            this.readOnlyChildToolStripMenuItem.Name = "readOnlyChildToolStripMenuItem";
            this.readOnlyChildToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.readOnlyChildToolStripMenuItem.Text = "&Read Only Child";
            this.readOnlyChildToolStripMenuItem.Click += new System.EventHandler(this.readOnlyChildToolStripMenuItem_Click);
            // 
            // readOnlyRootCollectionToolStripMenuItem
            // 
            this.readOnlyRootCollectionToolStripMenuItem.Name = "readOnlyRootCollectionToolStripMenuItem";
            this.readOnlyRootCollectionToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.readOnlyRootCollectionToolStripMenuItem.Text = "&Read Only Root Collection";
            this.readOnlyRootCollectionToolStripMenuItem.Click += new System.EventHandler(this.readOnlyRootCollectionToolStripMenuItem_Click);
            // 
            // readOnlyChildCollectionToolStripMenuItem
            // 
            this.readOnlyChildCollectionToolStripMenuItem.Name = "readOnlyChildCollectionToolStripMenuItem";
            this.readOnlyChildCollectionToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.readOnlyChildCollectionToolStripMenuItem.Text = "Read Only &Child Collection";
            this.readOnlyChildCollectionToolStripMenuItem.Click += new System.EventHandler(this.readOnlyChildCollectionToolStripMenuItem_Click);
            // 
            // nameValueListToolStripMenuItem
            // 
            this.nameValueListToolStripMenuItem.Name = "nameValueListToolStripMenuItem";
            this.nameValueListToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.nameValueListToolStripMenuItem.Text = "Name &Value List";
            this.nameValueListToolStripMenuItem.Click += new System.EventHandler(this.nameValueListToolStripMenuItem_Click);
            // 
            // newCriteriaToolStripMenuItem
            // 
            this.newCriteriaToolStripMenuItem.Name = "newCriteriaToolStripMenuItem";
            this.newCriteriaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newCriteriaToolStripMenuItem.Text = "New Criteria";
            this.newCriteriaToolStripMenuItem.Click += new System.EventHandler(this.newCriteriaToolStripMenuItem_Click);
            // 
            // schemaContextMenuStrip
            // 
            this.schemaContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.schemaContextMenuStrip.Size = new System.Drawing.Size(226, 192);
            // 
            // createEditableRootToolStripMenuItem
            // 
            this.createEditableRootToolStripMenuItem.Name = "createEditableRootToolStripMenuItem";
            this.createEditableRootToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.createEditableRootToolStripMenuItem.Text = "Create Editable Root";
            this.createEditableRootToolStripMenuItem.Click += new System.EventHandler(this.createEditableRootToolStripMenuItem_Click);
            // 
            // createReadOnlyRootToolStripMenuItem
            // 
            this.createReadOnlyRootToolStripMenuItem.Name = "createReadOnlyRootToolStripMenuItem";
            this.createReadOnlyRootToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.createReadOnlyRootToolStripMenuItem.Text = "Create Read Only Root";
            this.createReadOnlyRootToolStripMenuItem.Click += new System.EventHandler(this.createReadOnlyRootToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // createEditableRootCollectionToolStripMenuItem
            // 
            this.createEditableRootCollectionToolStripMenuItem.Name = "createEditableRootCollectionToolStripMenuItem";
            this.createEditableRootCollectionToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.createEditableRootCollectionToolStripMenuItem.Text = "Create Editable Root Collection";
            this.createEditableRootCollectionToolStripMenuItem.Click += new System.EventHandler(this.createEditableRootCollectionToolStripMenuItem_Click);
            // 
            // createReadOnlyRootCollectionToolStripMenuItem
            // 
            this.createReadOnlyRootCollectionToolStripMenuItem.Name = "createReadOnlyRootCollectionToolStripMenuItem";
            this.createReadOnlyRootCollectionToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.createReadOnlyRootCollectionToolStripMenuItem.Text = "Create Read Only Root Collection";
            this.createReadOnlyRootCollectionToolStripMenuItem.Click += new System.EventHandler(this.createReadOnlyRootCollectionToolStripMenuItem_Click);
            // 
            // createDynamicEditableRootCollectionToolStripMenuItem
            // 
            this.createDynamicEditableRootCollectionToolStripMenuItem.Name = "createDynamicEditableRootCollectionToolStripMenuItem";
            this.createDynamicEditableRootCollectionToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.createDynamicEditableRootCollectionToolStripMenuItem.Text = "Create Dynamic Editable Root Collection";
            this.createDynamicEditableRootCollectionToolStripMenuItem.Click += new System.EventHandler(this.createDynamicEditableRootCollectionToolStripMenuItem_Click);
            // 
            // dbColumns1
            // 
            this.dbColumns1.BackColor = System.Drawing.SystemColors.Control;
            this.dbColumns1.ContextMenuStrip = this.columnsContextMenuStrip;
            this.dbColumns1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbColumns1.Location = new System.Drawing.Point(174, 26);
            this.dbColumns1.Name = "dbColumns1";
            this.dbColumns1.Size = new System.Drawing.Size(210, 446);
            this.dbColumns1.TabIndex = 10;
            // 
            // dbTreeView1
            // 
            this.dbTreeView1.ContextMenuStrip = this.schemaContextMenuStrip;
            this.dbTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dbTreeView1.Location = new System.Drawing.Point(0, 26);
            this.dbTreeView1.Name = "dbTreeView1";
            this.dbTreeView1.Size = new System.Drawing.Size(168, 446);
            this.dbTreeView1.TabIndex = 9;
            // 
            // paneDbName
            // 
            this.paneDbName.AllowActive = false;
            this.paneDbName.AntiAlias = false;
            this.paneDbName.Caption = "Database Schema";
            this.paneDbName.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneDbName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paneDbName.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(92)))), ((int)(((byte)(181)))));
            this.paneDbName.InactiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(184)))), ((int)(((byte)(245)))));
            this.paneDbName.Location = new System.Drawing.Point(0, 0);
            this.paneDbName.Name = "paneDbName";
            this.paneDbName.Size = new System.Drawing.Size(384, 26);
            this.paneDbName.TabIndex = 0;
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(222, 6);
            // 
            // copySoftDeleteToolStripMenuItem
            // 
            this.copySoftDeleteToolStripMenuItem.CheckOnClick = true;
            this.copySoftDeleteToolStripMenuItem.Name = "copySoftDeleteToolStripMenuItem";
            this.copySoftDeleteToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.copySoftDeleteToolStripMenuItem.Text = "Copy soft delete column";
            this.copySoftDeleteToolStripMenuItem.ToolTipText = "Check this option if you want to force copying\r\nof the soft delete column to the created object of any kind.";
            // 
            // DbSchemaPanel
            // 
            this.Controls.Add(this.dbColumns1);
            this.Controls.Add(this.splitMiddle);
            this.Controls.Add(this.dbTreeView1);
            this.Controls.Add(this.paneDbName);
            this.Name = "DbSchemaPanel";
            this.Size = new System.Drawing.Size(384, 472);
            this.Load += new System.EventHandler(this.DbSchemaPanel_Load);
            this.Resize += new System.EventHandler(this.DbSchemaPanel_Resize);
            this.columnsContextMenuStrip.ResumeLayout(false);
            this.schemaContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitMiddle;
        private CslaGenerator.Controls.DbTreeView dbTreeView1;
        private CslaGenerator.Controls.DbColumns dbColumns1;
        private CslaGenerator.Controls.PaneCaption paneDbName;
        internal System.Windows.Forms.ImageList schemaImages;
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
