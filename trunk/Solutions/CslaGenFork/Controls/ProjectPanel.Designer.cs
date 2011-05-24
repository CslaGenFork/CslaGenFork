using System.Windows.Forms;

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
            this.pnlProjectName = new System.Windows.Forms.Panel();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.pnlOutputDir = new System.Windows.Forms.Panel();
            this.textboxPlusBtn = new CslaGenerator.Controls.TextboxPlusBtn();
            this.pnlLstObjects = new System.Windows.Forms.Panel();
            this.lstObjects = new System.Windows.Forms.ListBox();
            this.cslaObjectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.newObjectRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToObjectRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.optType = new System.Windows.Forms.RadioButton();
            this.optName = new System.Windows.Forms.RadioButton();
            this.optNone = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            // pnlProjectName
            // 
            this.pnlProjectName.Controls.Add(this.txtProjectName);
            this.pnlProjectName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProjectName.Location = new System.Drawing.Point(0, 23);
            this.pnlProjectName.Name = "pnlProjectName";
            this.pnlProjectName.Padding = new System.Windows.Forms.Padding(4);
            this.pnlProjectName.Size = new System.Drawing.Size(220, 28);
            this.pnlProjectName.TabIndex = 42;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectName.Location = new System.Drawing.Point(4, 4);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(212, 20);
            this.txtProjectName.TabIndex = 42;
            // 
            // pnlOutputDir
            // 
            this.pnlOutputDir.Controls.Add(this.textboxPlusBtn);
            this.pnlOutputDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOutputDir.Location = new System.Drawing.Point(0, 74);
            this.pnlOutputDir.Name = "pnlOutputDir";
            this.pnlOutputDir.Padding = new System.Windows.Forms.Padding(4);
            this.pnlOutputDir.Size = new System.Drawing.Size(220, 28);
            this.pnlOutputDir.TabIndex = 43;
            // 
            // textboxPlusBtn
            // 
            this.textboxPlusBtn.BackColor = System.Drawing.SystemColors.Control;
            this.textboxPlusBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxPlusBtn.Location = new System.Drawing.Point(4, 4);
            this.textboxPlusBtn.Name = "textboxPlusBtn";
            this.textboxPlusBtn.Size = new System.Drawing.Size(212, 20);
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
            this.pnlLstObjects.Size = new System.Drawing.Size(220, 371);
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
            this.lstObjects.Size = new System.Drawing.Size(212, 269);
            this.lstObjects.TabIndex = 22;
            this.lstObjects.ValueMember = "key";
            this.lstObjects.SelectedIndexChanged += new System.EventHandler(this.ListObjects_SelectedIndexChanged);
            this.lstObjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstObjects_KeyDown);
            // 
            // cslaObjectContextMenuStrip
            // 
            this.cslaObjectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.toolStripMenuItem1,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.toolStripMenuItem2,
            this.newObjectRelationToolStripMenuItem,
            this.addToObjectRelationToolStripMenuItem});
            this.cslaObjectContextMenuStrip.Name = "cslaObjectContextMenuStrip";
            this.cslaObjectContextMenuStrip.Size = new System.Drawing.Size(224, 170);
            this.cslaObjectContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cslaObjectContextMenuStrip_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.addToolStripMenuItem.Text = "&Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.duplicateToolStripMenuItem.Text = "D&uplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.moveUpToolStripMenuItem.Text = "Move U&p";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.moveDownToolStripMenuItem.Text = "Move Dow&n";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 6);
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
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.optType);
            this.grpFilters.Controls.Add(this.optName);
            this.grpFilters.Controls.Add(this.optNone);
            this.grpFilters.Controls.Add(this.label3);
            this.grpFilters.Controls.Add(this.label2);
            this.grpFilters.Controls.Add(this.label1);
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sort:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
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
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(50, 17);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(156, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
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
            this.paneCaption3.Size = new System.Drawing.Size(220, 23);
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
            this.paneCaption2.Size = new System.Drawing.Size(220, 23);
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
            this.paneCaption1.Size = new System.Drawing.Size(220, 23);
            this.paneCaption1.TabIndex = 28;
            // 
            // ProjectPanel
            // 
            this.Controls.Add(this.pnlLstObjects);
            this.Controls.Add(this.paneCaption3);
            this.Controls.Add(this.pnlOutputDir);
            this.Controls.Add(this.paneCaption2);
            this.Controls.Add(this.pnlProjectName);
            this.Controls.Add(this.paneCaption1);
            this.Name = "ProjectPanel";
            this.Size = new System.Drawing.Size(220, 496);
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
        private ContextMenuStrip cslaObjectContextMenuStrip;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem duplicateToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem moveUpToolStripMenuItem;
        private ToolStripMenuItem moveDownToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem newObjectRelationToolStripMenuItem;
        private ToolStripMenuItem addToObjectRelationToolStripMenuItem;
        private GroupBox grpFilters;
        private ComboBox cboObjectType;
        private TextBox txtFilter;
        private RadioButton optType;
        private RadioButton optName;
        private RadioButton optNone;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}