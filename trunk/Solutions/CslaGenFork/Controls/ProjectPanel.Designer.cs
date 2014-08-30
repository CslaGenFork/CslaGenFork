namespace CslaGenerator.Controls
{
    partial class ProjectPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectPanel));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlProjectName = new System.Windows.Forms.Panel();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.pnlOutputDir = new System.Windows.Forms.Panel();
            this.textboxPlusBtn = new CslaGenerator.Controls.TextboxPlusBtn();
            this.pnlLstObjects = new System.Windows.Forms.Panel();
            this.lstObjects = new System.Windows.Forms.ListBox();
            this.cslaObjectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.newObjectRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToObjectRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.optType = new System.Windows.Forms.RadioButton();
            this.optName = new System.Windows.Forms.RadioButton();
            this.optNone = new System.Windows.Forms.RadioButton();
            this.lblSort = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cboObjectType = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.paneCaption3 = new CslaGenerator.Controls.PaneCaption();
            this.paneCaption2 = new CslaGenerator.Controls.PaneCaption();
            this.paneCaption1 = new CslaGenerator.Controls.PaneCaption();
            this.pnlProjectName.SuspendLayout();
            this.pnlOutputDir.SuspendLayout();
            this.pnlLstObjects.SuspendLayout();
            this.cslaObjectContextMenuStrip.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            //this.toolTip.AutomaticDelay = 500;//500
            this.toolTip.AutoPopDelay = 15000;//5000
            //this.toolTip.InitialDelay = 500;//500
            //this.toolTip.ReshowDelay = 100;//100
            // 
            // pnlProjectName
            // 
            this.pnlProjectName.Controls.Add(this.txtProjectName);
            this.pnlProjectName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProjectName.Location = new System.Drawing.Point(0, 23);
            this.pnlProjectName.Name = "pnlProjectName";
            this.pnlProjectName.Padding = new System.Windows.Forms.Padding(4);
            this.pnlProjectName.Size = new System.Drawing.Size(212, 28);
            this.pnlProjectName.TabIndex = 42;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectName.Location = new System.Drawing.Point(4, 4);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(204, 20);
            this.txtProjectName.TabIndex = 42;
            this.toolTip.SetToolTip(this.txtProjectName, "Specify the project name.");
            // 
            // pnlOutputDir
            // 
            this.pnlOutputDir.Controls.Add(this.textboxPlusBtn);
            this.pnlOutputDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOutputDir.Location = new System.Drawing.Point(0, 74);
            this.pnlOutputDir.Name = "pnlOutputDir";
            this.pnlOutputDir.Padding = new System.Windows.Forms.Padding(4);
            this.pnlOutputDir.Size = new System.Drawing.Size(212, 28);
            this.pnlOutputDir.TabIndex = 43;
            // 
            // textboxPlusBtn
            // 
            this.textboxPlusBtn.BackColor = System.Drawing.SystemColors.Control;
            this.textboxPlusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxPlusBtn.Location = new System.Drawing.Point(4, 4);
            this.textboxPlusBtn.Name = "textboxPlusBtn";
            this.textboxPlusBtn.Size = new System.Drawing.Size(204, 20);
            this.textboxPlusBtn.TabIndex = 32;
            // 
            // pnlLstObjects
            // 
            this.pnlLstObjects.Controls.Add(this.lstObjects);
            this.pnlLstObjects.Controls.Add(this.grpFilters);
            this.pnlLstObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLstObjects.Location = new System.Drawing.Point(0, 125);
            this.pnlLstObjects.Name = "pnlLstObjects";
            this.pnlLstObjects.Padding = new System.Windows.Forms.Padding(4);
            this.pnlLstObjects.Size = new System.Drawing.Size(212, 344);
            this.pnlLstObjects.TabIndex = 44;
            // 
            // lstObjects
            // 
            this.lstObjects.BackColor = System.Drawing.SystemColors.Window;
            this.lstObjects.ContextMenuStrip = this.cslaObjectContextMenuStrip;
            this.lstObjects.DisplayMember = "ObjectName";
            this.lstObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstObjects.IntegralHeight = false;
            this.lstObjects.Location = new System.Drawing.Point(4, 98);
            this.lstObjects.Name = "lstObjects";
            this.lstObjects.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstObjects.Size = new System.Drawing.Size(204, 242);
            this.lstObjects.TabIndex = 22;
            this.lstObjects.ValueMember = "key";
            this.lstObjects.SelectedIndexChanged += new System.EventHandler(this.ListObjects_SelectedIndexChanged);
            // 
            // cslaObjectContextMenuStrip
            // 
            this.cslaObjectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.toolStripMenuItem1,
            this.selectAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.toolStripMenuItem3,
            this.newObjectRelationToolStripMenuItem,
            this.addToObjectRelationToolStripMenuItem});
            this.cslaObjectContextMenuStrip.Name = "cslaObjectContextMenuStrip";
            this.cslaObjectContextMenuStrip.Size = new System.Drawing.Size(224, 170);
            this.cslaObjectContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cslaObjectContextMenuStrip_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Plus";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Minus";
            this.removeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(232, 6);
            // 
            // newObjectRelationToolStripMenuItem
            // 
            this.newObjectRelationToolStripMenuItem.Name = "newObjectRelationToolStripMenuItem";
            this.newObjectRelationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.newObjectRelationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.newObjectRelationToolStripMenuItem.Text = "Add a new object relation";
            this.newObjectRelationToolStripMenuItem.Click += new System.EventHandler(this.newObjectRelationToolStripMenuItem_Click);
            // 
            // addToObjectRelationToolStripMenuItem
            // 
            this.addToObjectRelationToolStripMenuItem.Name = "addToObjectRelationToolStripMenuItem";
            this.addToObjectRelationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.addToObjectRelationToolStripMenuItem.Text = "Add to object relation as ...";
            this.addToObjectRelationToolStripMenuItem.Click += new System.EventHandler(this.addToObjectRelationToolStripMenuItem_Click);
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.optType);
            this.grpFilters.Controls.Add(this.optName);
            this.grpFilters.Controls.Add(this.optNone);
            this.grpFilters.Controls.Add(this.lblSort);
            this.grpFilters.Controls.Add(this.lblType);
            this.grpFilters.Controls.Add(this.lblName);
            this.grpFilters.Controls.Add(this.cboObjectType);
            this.grpFilters.Controls.Add(this.txtFilter);
            this.grpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilters.Location = new System.Drawing.Point(4, 4);
            this.grpFilters.MinimumSize = new System.Drawing.Size(212, 94);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(212, 94);
            this.grpFilters.TabIndex = 23;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filter / Sort";
            // 
            // optType
            // 
            this.optType.AutoSize = true;
            this.optType.Location = new System.Drawing.Point(157, 67);
            this.optType.Name = "optType";
            this.optType.Size = new System.Drawing.Size(49, 17);
            this.optType.TabIndex = 7;
            this.optType.Text = "Type";
            this.optType.UseVisualStyleBackColor = true;
            this.optType.CheckedChanged += new System.EventHandler(this.Sort_CheckedChanged);
            this.toolTip.SetToolTip(this.optType, "Sort by object stereotype.");
            // 
            // optName
            // 
            this.optName.AutoSize = true;
            this.optName.Location = new System.Drawing.Point(98, 67);
            this.optName.Name = "optName";
            this.optName.Size = new System.Drawing.Size(53, 17);
            this.optName.TabIndex = 6;
            this.optName.Text = "Name";
            this.optName.UseVisualStyleBackColor = true;
            this.optName.CheckedChanged += new System.EventHandler(this.Sort_CheckedChanged);
            this.toolTip.SetToolTip(this.optName, "Sort by object name.");
            // 
            // optNone
            // 
            this.optNone.AutoSize = true;
            this.optNone.Checked = true;
            this.optNone.Location = new System.Drawing.Point(41, 67);
            this.optNone.Name = "optNone";
            this.optNone.Size = new System.Drawing.Size(51, 17);
            this.optNone.TabIndex = 5;
            this.optNone.TabStop = true;
            this.optNone.Text = "None";
            this.optNone.UseVisualStyleBackColor = true;
            this.optNone.CheckedChanged += new System.EventHandler(this.Sort_CheckedChanged);
            this.toolTip.SetToolTip(this.optNone, "Do not sort.");
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(6, 69);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(29, 13);
            this.lblSort.TabIndex = 4;
            this.lblSort.Text = "Sort:";
            this.toolTip.SetToolTip(this.lblSort, "Specify how to sort the Csla objects list.");
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 44);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // cboObjectType
            // 
            this.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectType.FormattingEnabled = true;
            this.cboObjectType.Location = new System.Drawing.Point(50, 41);
            this.cboObjectType.MaxDropDownItems = 15;
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(156, 21);
            this.cboObjectType.TabIndex = 1;
            this.cboObjectType.SelectedIndexChanged += new System.EventHandler(this.cboObjectType_SelectedIndexChanged);
            this.toolTip.SetToolTip(this.cboObjectType, "Show all objects or filter by object stereotype.");
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(50, 17);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(156, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.toolTip.SetToolTip(this.txtFilter, "Case insensitive object filter. Type here full or partial object names.\r\nTyping \"list info\" shows all objects that have \"list\" or \"info\" in their names.");
            // 
            // paneCaption3
            // 
            this.paneCaption3.AllowActive = false;
            this.paneCaption3.AntiAlias = false;
            this.paneCaption3.Caption = "Csla Objects";
            this.paneCaption3.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paneCaption3.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(92)))), ((int)(((byte)(181)))));
            this.paneCaption3.InactiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(184)))), ((int)(((byte)(245)))));
            this.paneCaption3.Location = new System.Drawing.Point(0, 102);
            this.paneCaption3.Name = "paneCaption3";
            this.paneCaption3.Size = new System.Drawing.Size(212, 23);
            this.paneCaption3.TabIndex = 30;
            // 
            // paneCaption2
            // 
            this.paneCaption2.AllowActive = false;
            this.paneCaption2.AntiAlias = false;
            this.paneCaption2.Caption = "Output Directory";
            this.paneCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paneCaption2.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(92)))), ((int)(((byte)(181)))));
            this.paneCaption2.InactiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(184)))), ((int)(((byte)(245)))));
            this.paneCaption2.Location = new System.Drawing.Point(0, 51);
            this.paneCaption2.Name = "paneCaption2";
            this.paneCaption2.Size = new System.Drawing.Size(212, 23);
            this.paneCaption2.TabIndex = 29;
            // 
            // paneCaption1
            // 
            this.paneCaption1.AllowActive = false;
            this.paneCaption1.AntiAlias = false;
            this.paneCaption1.Caption = "Project Name";
            this.paneCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paneCaption1.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(92)))), ((int)(((byte)(181)))));
            this.paneCaption1.InactiveGradientLowColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(184)))), ((int)(((byte)(245)))));
            this.paneCaption1.Location = new System.Drawing.Point(0, 0);
            this.paneCaption1.Name = "paneCaption1";
            this.paneCaption1.Size = new System.Drawing.Size(212, 23);
            this.paneCaption1.TabIndex = 28;
            // 
            // ProjectPanel
            // 
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.ClientSize = new System.Drawing.Size(212, 469);
            this.Controls.Add(this.pnlLstObjects);
            this.Controls.Add(this.paneCaption3);
            this.Controls.Add(this.pnlOutputDir);
            this.Controls.Add(this.paneCaption2);
            this.Controls.Add(this.pnlProjectName);
            this.Controls.Add(this.paneCaption1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectPanel";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabPageContextMenuStrip = this.cslaObjectContextMenuStrip;
            this.TabText = "CslaGenFork Project";
            this.Text = "CslaGenFork Project";
            this.Load += new System.EventHandler(this.ProjectPanel_Load);
            this.pnlProjectName.ResumeLayout(false);
            this.pnlProjectName.PerformLayout();
            this.pnlOutputDir.ResumeLayout(false);
            this.pnlLstObjects.ResumeLayout(false);
            this.cslaObjectContextMenuStrip.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public delegate void TargetDirChangedEventHandler(string path);
        public virtual event TargetDirChangedEventHandler TargetDirChanged;
        private System.Windows.Forms.ToolTip toolTip;
        private CslaGenerator.Controls.PaneCaption paneCaption1;
        private CslaGenerator.Controls.PaneCaption paneCaption2;
        private CslaGenerator.Controls.PaneCaption paneCaption3;
        private bool onlyfilesystem = true;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Panel pnlProjectName;
        private System.Windows.Forms.Panel pnlOutputDir;
        private CslaGenerator.Controls.TextboxPlusBtn textboxPlusBtn;
        private System.Windows.Forms.Panel pnlLstObjects;
        private System.Windows.Forms.ListBox lstObjects;
        private System.Windows.Forms.ContextMenuStrip cslaObjectContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem newObjectRelationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToObjectRelationToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.ComboBox cboObjectType;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.RadioButton optType;
        private System.Windows.Forms.RadioButton optName;
        private System.Windows.Forms.RadioButton optNone;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
    }
}