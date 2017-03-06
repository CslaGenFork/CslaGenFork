using System.Windows.Forms;

namespace CslaGenerator.Controls
{
    internal partial class GlobalSettings
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.globalParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdResetToFactory = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.GenerationTab = new System.Windows.Forms.TabPage();
            this.btnEditDbProviders = new System.Windows.Forms.Button();
            this.chkRecompileTemplates = new System.Windows.Forms.CheckBox();
            this.chkOverwriteExtendedFile = new System.Windows.Forms.CheckBox();
            this.cboCodeEncoding = new System.Windows.Forms.ComboBox();
            this.cboSprocEncoding = new System.Windows.Forms.ComboBox();
            this.lblCodeEncoding = new System.Windows.Forms.Label();
            this.lblSprocEncoding = new System.Windows.Forms.Label();
            this.lblCodeEncodingDisplayName = new System.Windows.Forms.Label();
            this.lblSprocEncodingDisplayName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.globalParametersBindingSource)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.GenerationTab.SuspendLayout();
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
            // globalParametersBindingSource
            // 
            this.globalParametersBindingSource.DataSource = typeof(CslaGenerator.Metadata.GlobalParameters);
            this.globalParametersBindingSource.CurrentItemChanged += new System.EventHandler(this.GlobalParametersBindingSourceCurrentItemChanged);
            // 
            // cmdImport
            // 
            this.cmdImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdImport.Location = new System.Drawing.Point(16, 396);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(75, 23);
            this.cmdImport.TabIndex = 20;
            this.cmdImport.Text = "&Import...";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.CmdImportClick);
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdExport.Location = new System.Drawing.Point(94, 396);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(75, 23);
            this.cmdExport.TabIndex = 20;
            this.cmdExport.Text = "&Export...";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.CmdExportClick);
            // 
            // CmdResetToFactory
            // 
            this.cmdResetToFactory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdResetToFactory.Location = new System.Drawing.Point(344, 396);
            this.cmdResetToFactory.Name = "cmdResetToFactory";
            this.cmdResetToFactory.Size = new System.Drawing.Size(100, 23);
            this.cmdResetToFactory.TabIndex = 20;
            this.cmdResetToFactory.Text = "&Factory default";
            this.cmdResetToFactory.UseVisualStyleBackColor = true;
            this.cmdResetToFactory.Click += new System.EventHandler(this.CmdResetToFactoryClick);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(391, 396);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(72, 24);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.CmdCancelClick);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(469, 396);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(72, 24);
            this.cmdSave.TabIndex = 22;
            this.cmdSave.Text = "&Save";
            this.cmdSave.Click += new System.EventHandler(this.CmdSaveClick);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.GenerationTab);
            this.MainTabControl.Location = new System.Drawing.Point(12, 16);
            this.MainTabControl.Multiline = true;
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(533, 378);
            this.MainTabControl.TabIndex = 3;
            // 
            // GenerationTab
            // 
            this.GenerationTab.Controls.Add(this.lblSprocEncodingDisplayName);
            this.GenerationTab.Controls.Add(this.lblCodeEncodingDisplayName);
            this.GenerationTab.Controls.Add(this.lblSprocEncoding);
            this.GenerationTab.Controls.Add(this.lblCodeEncoding);
            this.GenerationTab.Controls.Add(this.cboSprocEncoding);
            this.GenerationTab.Controls.Add(this.cboCodeEncoding);
            this.GenerationTab.Controls.Add(this.chkOverwriteExtendedFile);
            this.GenerationTab.Controls.Add(this.chkRecompileTemplates);
            this.GenerationTab.Controls.Add(this.btnEditDbProviders);
            this.GenerationTab.Location = new System.Drawing.Point(4, 22);
            this.GenerationTab.Name = "GenerationTab";
            this.GenerationTab.Size = new System.Drawing.Size(525, 352);
            this.GenerationTab.TabIndex = 1;
            this.GenerationTab.Text = "Generation";
            this.GenerationTab.UseVisualStyleBackColor = true;
            // 
            // lblCodeEncoding
            // 
            this.lblCodeEncoding.Location = new System.Drawing.Point(15, 17);
            this.lblCodeEncoding.Name = "lblCodeEncoding";
            this.lblCodeEncoding.Size = new System.Drawing.Size(100, 20);
            this.lblCodeEncoding.TabIndex = 3;
            this.lblCodeEncoding.Text = "Code encoding:";
            // 
            // lblSprocEncoding
            // 
            this.lblSprocEncoding.Location = new System.Drawing.Point(15, 45);
            this.lblSprocEncoding.Name = "lblSprocEncoding";
            this.lblSprocEncoding.Size = new System.Drawing.Size(100, 20);
            this.lblSprocEncoding.TabIndex = 4;
            this.lblSprocEncoding.Text = "SProc encoding:";
            // 
            // chkOverwriteExtendedFile
            // 
            this.chkOverwriteExtendedFile.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.globalParametersBindingSource, "OverwriteExtendedFile", true, DataSourceUpdateMode.OnPropertyChanged));
            this.chkOverwriteExtendedFile.AutoSize = true;
            this.chkOverwriteExtendedFile.Location = new System.Drawing.Point(15, 71);
            this.chkOverwriteExtendedFile.Name = "chkOverwriteExtendedFile";
            this.chkOverwriteExtendedFile.Size = new System.Drawing.Size(138, 17);
            this.chkOverwriteExtendedFile.TabIndex = 0;
            this.chkOverwriteExtendedFile.Text = "Overwrite Extended File";
            this.chkOverwriteExtendedFile.UseVisualStyleBackColor = true;
            this.toolTip.SetToolTip(this.chkOverwriteExtendedFile, "If checked, extended files will be overwritten.\r\n" +
                "Unless you use source control, you should backup the extended files before using this option.");
            // 
            // chkRecompileTemplates
            // 
            this.chkRecompileTemplates.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.globalParametersBindingSource, "RecompileTemplates", true, DataSourceUpdateMode.OnPropertyChanged));
            this.chkRecompileTemplates.AutoSize = true;
            this.chkRecompileTemplates.Location = new System.Drawing.Point(15, 97);
            this.chkRecompileTemplates.Name = "chkRecompileTemplates";
            this.chkRecompileTemplates.Size = new System.Drawing.Size(138, 17);
            this.chkRecompileTemplates.TabIndex = 0;
            this.chkRecompileTemplates.Text = "Recompile templates (template development)";
            this.chkRecompileTemplates.UseVisualStyleBackColor = true;
            this.toolTip.SetToolTip(this.chkRecompileTemplates, "If checked, templates will be recompiled on every generation.\r\n" +
                "Unless you are changing the templates, you should uncheck this option.");
            // 
            // btnEditDbProviders
            // 
            this.btnEditDbProviders.AutoSize = true;
            this.btnEditDbProviders.Location = new System.Drawing.Point(15, 123);
            this.btnEditDbProviders.Name = "btnEditDbProviders";
            this.btnEditDbProviders.Size = new System.Drawing.Size(138, 17);
            this.btnEditDbProviders.TabIndex = 0;
            this.btnEditDbProviders.Text = "Edit DB Providers";
            this.btnEditDbProviders.UseVisualStyleBackColor = true;
            this.btnEditDbProviders.Click += new System.EventHandler(this.EditDbProvidersClick);
            // 
            // cboCodeEncoding
            // 
            this.cboCodeEncoding.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCodeEncoding.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCodeEncoding.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.globalParametersBindingSource, "CodeEncoding", true, DataSourceUpdateMode.OnPropertyChanged));
            this.cboCodeEncoding.FormattingEnabled = true;
            this.cboCodeEncoding.Location = new System.Drawing.Point(115, 15);
            this.cboCodeEncoding.Name = "cboCodeEncoding";
            this.cboCodeEncoding.Size = new System.Drawing.Size(155, 21);
            this.cboCodeEncoding.TabIndex = 1;
            this.toolTip.SetToolTip(this.cboCodeEncoding, "Select the encoding to use for code generation (.cs or .vb files).");
            // 
            // cboSprocEncoding
            // 
            this.cboSprocEncoding.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSprocEncoding.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSprocEncoding.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.globalParametersBindingSource, "SprocEncoding", true, DataSourceUpdateMode.OnPropertyChanged));
            this.cboSprocEncoding.FormattingEnabled = true;
            this.cboSprocEncoding.Location = new System.Drawing.Point(115, 43);
            this.cboSprocEncoding.Name = "cboSprocEncoding";
            this.cboSprocEncoding.Size = new System.Drawing.Size(155, 21);
            this.cboSprocEncoding.TabIndex = 2;
            this.toolTip.SetToolTip(this.cboSprocEncoding, "Select the encoding to use for stored procedures generation (.sql files).");
            // 
            // lblCodeEncodingDisplayName
            // 
            this.lblCodeEncodingDisplayName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.globalParametersBindingSource, "CodeEncodingDisplayName", true, DataSourceUpdateMode.OnPropertyChanged));
            this.lblCodeEncodingDisplayName.Location = new System.Drawing.Point(290, 17);
            this.lblCodeEncodingDisplayName.Name = "lblCodeEncodingDisplayName";
            this.lblCodeEncodingDisplayName.Size = new System.Drawing.Size(300, 20);
            this.lblCodeEncodingDisplayName.TabIndex = 5;
            // 
            // lblSprocEncodingDisplayName
            // 
            this.lblSprocEncodingDisplayName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.globalParametersBindingSource, "SprocEncodingDisplayName", true, DataSourceUpdateMode.OnPropertyChanged));
            this.lblSprocEncodingDisplayName.Location = new System.Drawing.Point(290, 45);
            this.lblSprocEncodingDisplayName.Name = "lblSprocEncodingDisplayName";
            this.lblSprocEncodingDisplayName.Size = new System.Drawing.Size(300, 20);
            this.lblSprocEncodingDisplayName.TabIndex = 6;
            // 
            // GlobalSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 425);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdResetToFactory);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.MainTabControl);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GlobalSettings";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Global Settings";
            this.Text = "Global Settings";
            this.Shown += new System.EventHandler(this.GlobalSettings_Shown);
            this.ResizeBegin += new System.EventHandler(this.GlobalSettings_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.GlobalSettings_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.globalParametersBindingSource)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.GenerationTab.ResumeLayout(false);
            this.GenerationTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Button cmdExport;
        internal System.Windows.Forms.Button cmdResetToFactory;
        private System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage GenerationTab;
        private System.Windows.Forms.BindingSource globalParametersBindingSource;
        private Label lblSprocEncodingDisplayName;
        private Label lblCodeEncodingDisplayName;
        private Label lblSprocEncoding;
        private Label lblCodeEncoding;
        private ComboBox cboSprocEncoding;
        private ComboBox cboCodeEncoding;
        private CheckBox chkOverwriteExtendedFile;
        private CheckBox chkRecompileTemplates;
        private Button btnEditDbProviders;
    }
}
