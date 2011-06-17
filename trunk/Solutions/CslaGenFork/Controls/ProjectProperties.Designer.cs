namespace CslaGenerator.Controls
{
    partial class ProjectProperties
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdGetDefault = new System.Windows.Forms.Button();
            this.cmdSetDefault = new System.Windows.Forms.Button();
            this.CmdResetToFactory = new System.Windows.Forms.Button();
            this.cmdUndo = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabCreation = new System.Windows.Forms.TabPage();
            this.tabControlCreation = new System.Windows.Forms.TabControl();
            this.tabGeneration = new System.Windows.Forms.TabPage();
            this.tabControlGeneration = new System.Windows.Forms.TabControl();
            this.tabDefaultsGeneral = new System.Windows.Forms.TabPage();
            this.lblAlertNewDefaultsGeneral = new System.Windows.Forms.Label();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.chkSmartDateDefault = new System.Windows.Forms.CheckBox();
            this.chkDatesDefaultStringWithTypeConversion = new System.Windows.Forms.CheckBox();
            this.chkAutoCriteria = new System.Windows.Forms.CheckBox();
            this.chkAutoTimestampCriteria = new System.Windows.Forms.CheckBox();
            this.groupBoxReadOnlyObjects = new System.Windows.Forms.GroupBox();
            this.chkReadOnlyObjectsCopyAuditing = new System.Windows.Forms.CheckBox();
            this.chkReadOnlyObjectsCopyTimestamp = new System.Windows.Forms.CheckBox();
            this.lblCreateReadOnlyObjectsPropertyMode = new System.Windows.Forms.Label();
            this.cboCreateReadOnlyObjectsPropertyMode = new System.Windows.Forms.ComboBox();
            this.lblCreateTimestampPropertyMode = new System.Windows.Forms.Label();
            this.cboCreateTimestampPropertyMode = new System.Windows.Forms.ComboBox();
            this.tabDefaultsDatabase = new System.Windows.Forms.TabPage();
            this.lblAlertNewDefaultsDatabase = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.lblPersistenceType = new System.Windows.Forms.Label();
            this.cboPersistenceType = new System.Windows.Forms.ComboBox();
            this.lblDatabaseContextObject = new System.Windows.Forms.Label();
            this.txtDatabaseContextObject = new System.Windows.Forms.TextBox();
            this.groupBoxObjectRelationsBuilder = new System.Windows.Forms.GroupBox();
            this.lblChildPropertySuffix = new System.Windows.Forms.Label();
            this.txtChildPropertySuffix = new System.Windows.Forms.TextBox();
            this.lblCollectionSuffix = new System.Windows.Forms.Label();
            this.lblSingleSPSuffix = new System.Windows.Forms.Label();
            this.txtSingleSPSuffix = new System.Windows.Forms.TextBox();
            this.txtCollectionSuffix = new System.Windows.Forms.TextBox();
            this.chkItemsUseSingleSP = new System.Windows.Forms.CheckBox();
            this.tabStoredProcs = new System.Windows.Forms.TabPage();
            this.groupBoxPrefixSuffix = new System.Windows.Forms.GroupBox();
            this.lblGeneralSpPrefix = new System.Windows.Forms.Label();
            this.txtGeneralSpPrefix = new System.Windows.Forms.TextBox();
            this.lblSelectPrefix = new System.Windows.Forms.Label();
            this.txtSelectPrefix = new System.Windows.Forms.TextBox();
            this.lblInsertPrefix = new System.Windows.Forms.Label();
            this.txtInsertPrefix = new System.Windows.Forms.TextBox();
            this.lblUpdatePrefix = new System.Windows.Forms.Label();
            this.txtUpdatePrefix = new System.Windows.Forms.TextBox();
            this.lblDeletePrefix = new System.Windows.Forms.Label();
            this.txtDeletePrefix = new System.Windows.Forms.TextBox();           
            this.lblGeneralSpSuffix = new System.Windows.Forms.Label();
            this.txtGeneralSpSuffix = new System.Windows.Forms.TextBox();
            this.lblSelectSuffix = new System.Windows.Forms.Label();
            this.txtSelectSuffix = new System.Windows.Forms.TextBox();
            this.lblInsertSuffix = new System.Windows.Forms.Label();
            this.txtInsertSuffix = new System.Windows.Forms.TextBox();
            this.lblUpdateSuffix = new System.Windows.Forms.Label();
            this.txtUpdateSuffix = new System.Windows.Forms.TextBox();
            this.lblDeleteSuffix = new System.Windows.Forms.Label();
            this.txtDeleteSuffix = new System.Windows.Forms.TextBox();
            this.lblIntSoftDelete = new System.Windows.Forms.Label();
            this.txtIntSoftDelete = new System.Windows.Forms.TextBox();
            this.lblBoolSoftDelete = new System.Windows.Forms.Label();
            this.txtBoolSoftDelete = new System.Windows.Forms.TextBox();
            this.chkIgnoreFilterWhenSoftDeleteIsParam = new System.Windows.Forms.CheckBox();
            this.chkRemoveChildBeforeParent = new System.Windows.Forms.CheckBox();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.groupBoxPKDefaultValues = new System.Windows.Forms.GroupBox();
            this.lblIDGuidDefaultValue = new System.Windows.Forms.Label();
            this.txtIDGuidDefaultValue = new System.Windows.Forms.TextBox();
            this.lblIDInt16DefaultValue = new System.Windows.Forms.Label();
            this.txtIDInt16DefaultValue = new System.Windows.Forms.TextBox();
            this.lblIDInt32DefaultValue = new System.Windows.Forms.Label();
            this.txtIDInt32DefaultValue = new System.Windows.Forms.TextBox();
            this.lblIDInt64DefaultValue = new System.Windows.Forms.Label();
            this.txtIDInt64DefaultValue = new System.Windows.Forms.TextBox();
            this.groupBoxOtherParameters = new System.Windows.Forms.GroupBox();
            this.lblFieldNamePrefix = new System.Windows.Forms.Label();
            this.txtFieldNamePrefix = new System.Windows.Forms.TextBox();
            this.lblDelegateNamePrefix = new System.Windows.Forms.Label();
            this.txtDelegateNamePrefix = new System.Windows.Forms.TextBox();
            this.groupBoxSimpleAuditing = new System.Windows.Forms.GroupBox();
            this.lblCreationDateColumn = new System.Windows.Forms.Label();
            this.txtCreationDateColumn = new System.Windows.Forms.TextBox();
            this.lblCreationUserColumn = new System.Windows.Forms.Label();
            this.txtCreationUserColumn = new System.Windows.Forms.TextBox();
            this.lblChangedDateColumn = new System.Windows.Forms.Label();
            this.txtChangedDateColumn = new System.Windows.Forms.TextBox();
            this.lblChangedUserColumn = new System.Windows.Forms.Label();
            this.txtChangedUserColumn = new System.Windows.Forms.TextBox();
            this.chkLogDateAndTime = new System.Windows.Forms.CheckBox();
            this.lblGetUserMethod = new System.Windows.Forms.Label();
            this.txtGetUserMethod = new System.Windows.Forms.TextBox();
            this.tabGenerationTarget = new System.Windows.Forms.TabPage();
            this.chkSaveGenerationTarget = new System.Windows.Forms.CheckBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.cboTarget = new System.Windows.Forms.ComboBox();
            this.lblOutputLanguage = new System.Windows.Forms.Label();
            this.cboOutputLanguage = new System.Windows.Forms.ComboBox();
            this.groupBoxUIEnvironment = new System.Windows.Forms.GroupBox();
            this.chkWinForms = new System.Windows.Forms.CheckBox();
            this.chkWPF = new System.Windows.Forms.CheckBox();
            this.chkSilverlight = new System.Windows.Forms.CheckBox();
            this.chkSilverlightUseServices = new System.Windows.Forms.CheckBox();
            this.groupBoxDataAccessLayer = new System.Windows.Forms.GroupBox();
            this.lblTargetDAL = new System.Windows.Forms.Label();
            this.cboTargetDAL = new System.Windows.Forms.ComboBox();
            this.chkGenerateDAL = new System.Windows.Forms.CheckBox();
            this.groupBoxServerInvocation = new System.Windows.Forms.GroupBox();
            this.chkSynchronous = new System.Windows.Forms.CheckBox();
            this.chkAsynchronous = new System.Windows.Forms.CheckBox();
            this.tabGenerationFiles = new System.Windows.Forms.TabPage();
            this.chkSaveGenerationFiles = new System.Windows.Forms.CheckBox();
            this.lblBaseFilenameSuffix = new System.Windows.Forms.Label();
            this.txtBaseFilenameSuffix = new System.Windows.Forms.TextBox();
            this.lblExtendedFilenameSuffix = new System.Windows.Forms.Label();
            this.txtExtendedFilenameSuffix = new System.Windows.Forms.TextBox();
            this.lblClassCommentFilenameSuffix = new System.Windows.Forms.Label();
            this.txtClassCommentFilenameSuffix = new System.Windows.Forms.TextBox();
            this.chkBackupOldSource = new System.Windows.Forms.CheckBox();
            this.chkSeparateBaseClasses = new System.Windows.Forms.CheckBox();
            this.chkSeparateNamespaces = new System.Windows.Forms.CheckBox();
            this.chkSeparateClassComment = new System.Windows.Forms.CheckBox();
            this.lblBaseNamespace = new System.Windows.Forms.Label();
            this.txtBaseNamespace = new System.Windows.Forms.TextBox();
            this.lblUtilitiesNamespace = new System.Windows.Forms.Label();
            this.txtUtilitiesNamespace = new System.Windows.Forms.TextBox();
            this.lblUtilitiesFolder = new System.Windows.Forms.Label();
            this.txtUtilitiesFolder = new System.Windows.Forms.TextBox();
            this.lblInterfaceDALNamespace = new System.Windows.Forms.Label();
            this.txtInterfaceDALNamespace = new System.Windows.Forms.TextBox();
            this.lblDALNamespace = new System.Windows.Forms.Label();
            this.txtDALNamespace = new System.Windows.Forms.TextBox();
            this.tabGenerationMisc = new System.Windows.Forms.TabPage();
            this.chkSaveGenerationMisc = new System.Windows.Forms.CheckBox();
            this.lblGenerateAuthorization = new System.Windows.Forms.Label();
            this.cboGenerateAuthorization = new System.Windows.Forms.ComboBox();
            this.lblHeaderVerbosity = new System.Windows.Forms.Label();
            this.cboHeaderVerbosity = new System.Windows.Forms.ComboBox();
            this.chkGenerateStoredProcedures = new System.Windows.Forms.CheckBox();
            this.chkSpOneFile = new System.Windows.Forms.CheckBox();
            this.chkGenerateInlineQueries = new System.Windows.Forms.CheckBox();
            this.chkGenerateQueriesWithSchema = new System.Windows.Forms.CheckBox();
            this.chkGenerateDatabaseClass = new System.Windows.Forms.CheckBox();
            this.chkUseBypassPropertyChecks = new System.Windows.Forms.CheckBox();
            this.chkNullableSupport = new System.Windows.Forms.CheckBox();
            this.groupBoxLegacy = new System.Windows.Forms.GroupBox();
            this.chkActiveObjects = new System.Windows.Forms.CheckBox();
            this.chkUsePublicPropertyInfo = new System.Windows.Forms.CheckBox();
            this.chkForceReadOnlyProperties = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdLoad = new System.Windows.Forms.OpenFileDialog();
            this.projectParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.generationParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControlMain.SuspendLayout();
            this.tabCreation.SuspendLayout();
            this.tabControlCreation.SuspendLayout();
            this.tabGeneration.SuspendLayout();
            this.tabControlGeneration.SuspendLayout();
            this.tabDefaultsGeneral.SuspendLayout();
            this.tabDefaultsDatabase.SuspendLayout();
            this.tabStoredProcs.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.tabGenerationTarget.SuspendLayout();
            this.groupBoxUIEnvironment.SuspendLayout();
            this.groupBoxDataAccessLayer.SuspendLayout();
            this.groupBoxServerInvocation.SuspendLayout();
            this.tabGenerationFiles.SuspendLayout();
            this.groupBoxLegacy.SuspendLayout();
            this.tabGenerationMisc.SuspendLayout();
            this.groupBoxReadOnlyObjects.SuspendLayout();
            this.groupBoxObjectRelationsBuilder.SuspendLayout();
            this.groupBoxPrefixSuffix.SuspendLayout();
            this.groupBoxPKDefaultValues.SuspendLayout();
            this.groupBoxOtherParameters.SuspendLayout();
            this.groupBoxSimpleAuditing.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectParametersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationParametersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            //this.toolTip1.AutomaticDelay = 500;//500
            this.toolTip1.AutoPopDelay = 15000;//5000
            //this.toolTip1.InitialDelay = 500;//500
            //this.toolTip1.ReshowDelay = 100;//100
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
            // cmdGetDefault
            // 
            this.cmdGetDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdGetDefault.Location = new System.Drawing.Point(180, 396);
            this.cmdGetDefault.Name = "cmdGetDefault";
            this.cmdGetDefault.Size = new System.Drawing.Size(75, 23);
            this.cmdGetDefault.TabIndex = 20;
            this.cmdGetDefault.Text = "&Get default";
            this.cmdGetDefault.UseVisualStyleBackColor = true;
            this.cmdGetDefault.Click += new System.EventHandler(this.CmdGetDefaultClick);
            // 
            // cmdSetDefault
            // 
            this.cmdSetDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSetDefault.Location = new System.Drawing.Point(258, 396);
            this.cmdSetDefault.Name = "cmdSetDefault";
            this.cmdSetDefault.Size = new System.Drawing.Size(75, 23);
            this.cmdSetDefault.TabIndex = 20;
            this.cmdSetDefault.Text = "&Set default";
            this.cmdSetDefault.UseVisualStyleBackColor = true;
            this.cmdSetDefault.Click += new System.EventHandler(this.CmdSetDefaultClick);
            // 
            // CmdResetToFactory
            // 
            this.CmdResetToFactory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdResetToFactory.Location = new System.Drawing.Point(344, 396);
            this.CmdResetToFactory.Name = "CmdResetToFactory";
            this.CmdResetToFactory.Size = new System.Drawing.Size(100, 23);
            this.CmdResetToFactory.TabIndex = 20;
            this.CmdResetToFactory.Text = "&Factory default";
            this.CmdResetToFactory.UseVisualStyleBackColor = true;
            this.CmdResetToFactory.Click += new System.EventHandler(this.CmdResetToFactoryClick);
            // 
            // cmdUndo
            // 
            this.cmdUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUndo.Location = new System.Drawing.Point(391, 396);
            this.cmdUndo.Name = "cmdUndo";
            this.cmdUndo.Size = new System.Drawing.Size(72, 24);
            this.cmdUndo.TabIndex = 21;
            this.cmdUndo.Text = "&Undo";
            this.cmdUndo.Click += new System.EventHandler(this.CmdUndoClick);
            // 
            // cmdApply
            // 
            this.cmdApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdApply.Location = new System.Drawing.Point(469, 396);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(72, 24);
            this.cmdApply.TabIndex = 22;
            this.cmdApply.Text = "&Apply";
            this.cmdApply.Click += new System.EventHandler(this.CmdApplyClick);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabCreation);
            this.tabControlMain.Controls.Add(this.tabStoredProcs);
            this.tabControlMain.Controls.Add(this.tabAdvanced);
            this.tabControlMain.Controls.Add(this.tabGeneration);
            this.tabControlMain.Location = new System.Drawing.Point(12, 16);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControl1";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(533, 378);
            this.tabControlMain.TabIndex = 3;
            // 
            // tabCreation
            // 
            this.tabCreation.Controls.Add(this.tabControlCreation);
            this.tabCreation.Location = new System.Drawing.Point(4, 22);
            this.tabCreation.Name = "tabCreation";
            this.tabCreation.Size = new System.Drawing.Size(525, 329);
            this.tabCreation.TabIndex = 1;
            this.tabCreation.Text = "Creation";
            this.tabCreation.UseVisualStyleBackColor = true;
            // 
            // tabControlCreation
            // 
            this.tabControlCreation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlCreation.Controls.Add(this.tabDefaultsGeneral);
            this.tabControlCreation.Controls.Add(this.tabDefaultsDatabase);
            this.tabControlCreation.Location = new System.Drawing.Point(0, 0);
            this.tabControlCreation.Name = "tabControlCreation";
            this.tabControlCreation.SelectedIndex = 0;
            this.tabControlCreation.Size = new System.Drawing.Size(525, 334);
            this.tabControlCreation.TabIndex = 2;
            // 
            // tabDefaultsGeneral
            // 
            this.tabDefaultsGeneral.Controls.Add(this.lblAlertNewDefaultsGeneral);
            this.tabDefaultsGeneral.Controls.Add(this.lblNamespace);
            this.tabDefaultsGeneral.Controls.Add(this.txtNamespace);
            this.tabDefaultsGeneral.Controls.Add(this.lblFolder);
            this.tabDefaultsGeneral.Controls.Add(this.txtFolder);
            this.tabDefaultsGeneral.Controls.Add(this.lblCreateTimestampPropertyMode);
            this.tabDefaultsGeneral.Controls.Add(this.cboCreateTimestampPropertyMode);
            this.tabDefaultsGeneral.Controls.Add(this.chkSmartDateDefault);
            this.tabDefaultsGeneral.Controls.Add(this.chkDatesDefaultStringWithTypeConversion);
            this.tabDefaultsGeneral.Controls.Add(this.chkAutoCriteria);
            this.tabDefaultsGeneral.Controls.Add(this.chkAutoTimestampCriteria);
            this.tabDefaultsGeneral.Controls.Add(this.groupBoxReadOnlyObjects);
            this.tabDefaultsGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabDefaultsGeneral.Name = "tabDefaultsGeneral";
            this.tabDefaultsGeneral.Size = new System.Drawing.Size(525, 329);
            this.tabDefaultsGeneral.TabIndex = 3;
            this.tabDefaultsGeneral.Text = "General Defaults";
            this.tabDefaultsGeneral.UseVisualStyleBackColor = true;
            // 
            // lblAlertNewDefaultsGeneral
            // 
            this.lblAlertNewDefaultsGeneral.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertNewDefaultsGeneral.Location = new System.Drawing.Point(12, 10);
            this.lblAlertNewDefaultsGeneral.Name = "lblAlertNewDefaultsGeneral";
            this.lblAlertNewDefaultsGeneral.Size = new System.Drawing.Size(412, 16);
            this.lblAlertNewDefaultsGeneral.TabIndex = 36;
            this.lblAlertNewDefaultsGeneral.Text = "Note: These settings only affect how new objects are created.";
            // 
            // lblNamespace
            // 
            this.lblNamespace.Location = new System.Drawing.Point(15, 40);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(177, 16);
            this.lblNamespace.TabIndex = 4;
            this.lblNamespace.Text = "Namespace for Business Objects:";
            // 
            // txtNamespace
            // 
            this.txtNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultNamespace", true));
            this.txtNamespace.Location = new System.Drawing.Point(15, 56);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(177, 20);
            this.txtNamespace.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtNamespace, "Specify the default namespace to be set on created objects.");
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(15, 84);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(200, 16);
            this.lblFolder.TabIndex = 37;
            this.lblFolder.Text = "Folder: (like: \"Module\\SubModule\"):";
            // 
            // txtFolder
            // 
            this.txtFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultFolder", true));
            this.txtFolder.Location = new System.Drawing.Point(15, 100);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(177, 20);
            this.txtFolder.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtFolder, "Specify the default folder to be set on created objects." +
                "\r\nThis is relative to the project\'s output folder and is used only when namespaces aren't separated in folders.");
            // 
            // lblCreateTimestampPropertyMode
            // 
            this.lblCreateTimestampPropertyMode.Location = new System.Drawing.Point(15, 128);
            this.lblCreateTimestampPropertyMode.Name = "lblCreateTimestampPropertyMode";
            this.lblCreateTimestampPropertyMode.Size = new System.Drawing.Size(200, 16);
            this.lblCreateTimestampPropertyMode.TabIndex = 32;
            this.lblCreateTimestampPropertyMode.Text = "Property Mode for timestamp column:";
            // 
            // cboCreateTimestampPropertyMode
            // 
            this.cboCreateTimestampPropertyMode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "CreateTimestampPropertyMode", true));
            this.cboCreateTimestampPropertyMode.Location = new System.Drawing.Point(15, 144);
            this.cboCreateTimestampPropertyMode.Name = "cboCreateTimestampPropertyMode";
            this.cboCreateTimestampPropertyMode.Size = new System.Drawing.Size(177, 21);
            this.cboCreateTimestampPropertyMode.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cboCreateTimestampPropertyMode, "Select the PropertyMode for timestamp Value Property creation.");
            // 
            // chkSmartDateDefault
            // 
            this.chkSmartDateDefault.AutoSize = true;
            this.chkSmartDateDefault.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "SmartDateDefault", true));
            this.chkSmartDateDefault.Location = new System.Drawing.Point(15, 176);
            this.chkSmartDateDefault.Name = "chkSmartDateDefault";
            this.chkSmartDateDefault.Size = new System.Drawing.Size(336, 17);
            this.chkSmartDateDefault.TabIndex = 8;
            this.chkSmartDateDefault.Text = "Use SmartDate instead of DateTime for date properties.";
            this.chkSmartDateDefault.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkSmartDateDefault, "If checked, date properties are created with SmartDate type instead of DateTime.");
            // 
            // chkDatesDefaultStringWithTypeConversion
            // 
            this.chkDatesDefaultStringWithTypeConversion.AutoSize = true;
            this.chkDatesDefaultStringWithTypeConversion.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "DatesDefaultStringWithTypeConversion", true));
            this.chkDatesDefaultStringWithTypeConversion.Location = new System.Drawing.Point(15, 200);
            this.chkDatesDefaultStringWithTypeConversion.Name = "chkDatesDefaultStringWithTypeConversion";
            this.chkDatesDefaultStringWithTypeConversion.Size = new System.Drawing.Size(450, 17);
            this.chkDatesDefaultStringWithTypeConversion.TabIndex = 9;
            this.chkDatesDefaultStringWithTypeConversion.Text = "Use String with TypeConversion to DateTime or SmartDate for date properties.";
            this.chkDatesDefaultStringWithTypeConversion.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkDatesDefaultStringWithTypeConversion, "If checked, date properties are created with String type and backing field TypeConversion to DateTime or SmartDate.");
            // 
            // chkAutoCriteria
            // 
            this.chkAutoCriteria.AutoSize = true;
            this.chkAutoCriteria.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "AutoCriteria", true));
            this.chkAutoCriteria.Location = new System.Drawing.Point(15, 224);
            this.chkAutoCriteria.Name = "chkAutoCriteria";
            this.chkAutoCriteria.Size = new System.Drawing.Size(450, 17);
            this.chkAutoCriteria.TabIndex = 10;
            this.chkAutoCriteria.Text = "Add a parameterless Get criteria to ReadOnlyCollection and NameValueList.";
            this.chkAutoCriteria.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkAutoCriteria, "If checked, ReadOnly Collections and Name Value Lists are created with a parameterless Get criteria.");
            // 
            // chkAutoTimestampCriteria
            // 
            this.chkAutoTimestampCriteria.AutoSize = true;
            this.chkAutoTimestampCriteria.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "AutoTimestampCriteria", true));
            this.chkAutoTimestampCriteria.Location = new System.Drawing.Point(15, 248);
            this.chkAutoTimestampCriteria.Name = "chkAutoTimestampCriteria";
            this.chkAutoTimestampCriteria.Size = new System.Drawing.Size(450, 17);
            this.chkAutoTimestampCriteria.TabIndex = 11;
            this.chkAutoTimestampCriteria.Text = "Add a Delete CriteriaTS whem DB type \"timestamp\" is found.";
            this.chkAutoTimestampCriteria.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkAutoCriteria, "If checked, whem DB type \"timestamp\" is found on EditableRoot, EditableChild and DynamicRoot objects are created with a Delete CriteriaTS.");
            // 
            // groupBoxReadOnlyObjects
            // 
            this.groupBoxReadOnlyObjects.Controls.Add(this.chkReadOnlyObjectsCopyAuditing);
            this.groupBoxReadOnlyObjects.Controls.Add(this.chkReadOnlyObjectsCopyTimestamp);
            this.groupBoxReadOnlyObjects.Controls.Add(this.lblCreateReadOnlyObjectsPropertyMode);
            this.groupBoxReadOnlyObjects.Controls.Add(this.cboCreateReadOnlyObjectsPropertyMode);
            this.groupBoxReadOnlyObjects.Location = new System.Drawing.Point(220, 46);
            this.groupBoxReadOnlyObjects.Name = "groupBoxReadOnlyObjects";
            this.groupBoxReadOnlyObjects.Size = new System.Drawing.Size(220, 125);
            this.groupBoxReadOnlyObjects.TabIndex = 12;
            this.groupBoxReadOnlyObjects.TabStop = false;
            this.groupBoxReadOnlyObjects.Text = "ReadOnly Objects";
            // 
            // chkReadOnlyObjectsCopyAuditing
            // 
            this.chkReadOnlyObjectsCopyAuditing.AutoSize = true;
            this.chkReadOnlyObjectsCopyAuditing.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "ReadOnlyObjectsCopyAuditing", true));
            this.chkReadOnlyObjectsCopyAuditing.Location = new System.Drawing.Point(12, 24);
            this.chkReadOnlyObjectsCopyAuditing.Name = "chkReadOnlyObjectsCopyAuditing";
            this.chkReadOnlyObjectsCopyAuditing.Size = new System.Drawing.Size(450, 17);
            this.chkReadOnlyObjectsCopyAuditing.TabIndex = 13;
            this.chkReadOnlyObjectsCopyAuditing.Text = "Copy auditing columns.";
            this.chkReadOnlyObjectsCopyAuditing.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkReadOnlyObjectsCopyAuditing, "If checked, creates ReadOnly Objects with auditing columns.");
            // 
            // chkReadOnlyObjectsCopyTimestamp
            // 
            this.chkReadOnlyObjectsCopyTimestamp.AutoSize = true;
            this.chkReadOnlyObjectsCopyTimestamp.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "ReadOnlyObjectsCopyTimestamp", true));
            this.chkReadOnlyObjectsCopyTimestamp.Location = new System.Drawing.Point(12, 48);
            this.chkReadOnlyObjectsCopyTimestamp.Name = "chkReadOnlyObjectsCopyTimestamp";
            this.chkReadOnlyObjectsCopyTimestamp.Size = new System.Drawing.Size(450, 17);
            this.chkReadOnlyObjectsCopyTimestamp.TabIndex = 14;
            this.chkReadOnlyObjectsCopyTimestamp.Text = "Copy timestamp column.";
            this.chkReadOnlyObjectsCopyTimestamp.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkReadOnlyObjectsCopyTimestamp, "If checked, creates ReadOnly Objects with timestamp column.");
            // 
            // lblCreateReadOnlyObjectsPropertyMode
            // 
            this.lblCreateReadOnlyObjectsPropertyMode.Location = new System.Drawing.Point(12, 78);
            this.lblCreateReadOnlyObjectsPropertyMode.Name = "lblCreateReadOnlyObjectsPropertyMode";
            this.lblCreateReadOnlyObjectsPropertyMode.Size = new System.Drawing.Size(170, 16);
            this.lblCreateReadOnlyObjectsPropertyMode.TabIndex = 32;
            this.lblCreateReadOnlyObjectsPropertyMode.Text = "Property Mode for columns:";
            // 
            // cboCreateReadOnlyObjectsPropertyMode
            // 
            this.cboCreateReadOnlyObjectsPropertyMode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "CreateReadOnlyObjectsPropertyMode", true));
            this.cboCreateReadOnlyObjectsPropertyMode.Location = new System.Drawing.Point(12, 94);
            this.cboCreateReadOnlyObjectsPropertyMode.Name = "cboCreateReadOnlyObjectsPropertyMode";
            this.cboCreateReadOnlyObjectsPropertyMode.Size = new System.Drawing.Size(177, 21);
            this.cboCreateReadOnlyObjectsPropertyMode.TabIndex = 15;
            this.toolTip1.SetToolTip(this.cboCreateReadOnlyObjectsPropertyMode,
                                     "Select the Value Property's PropertyMode for creation  of ReadOnly Objects." +
                                     "\r\nNote - PropertyMode for \"timestamp\" DbType columns is specified below.");
            // 
            // tabDefaultsDatabase
            // 
            this.tabDefaultsDatabase.Controls.Add(this.lblAlertNewDefaultsDatabase);
            this.tabDefaultsDatabase.Controls.Add(this.lblDatabase);
            this.tabDefaultsDatabase.Controls.Add(this.txtDatabase);
            this.tabDefaultsDatabase.Controls.Add(this.lblTransactionType);
            this.tabDefaultsDatabase.Controls.Add(this.cboTransactionType);
            this.tabDefaultsDatabase.Controls.Add(this.lblPersistenceType);
            this.tabDefaultsDatabase.Controls.Add(this.cboPersistenceType);
            this.tabDefaultsDatabase.Controls.Add(this.lblDatabaseContextObject);
            this.tabDefaultsDatabase.Controls.Add(this.txtDatabaseContextObject);
            this.tabDefaultsDatabase.Controls.Add(this.groupBoxObjectRelationsBuilder);
            this.tabDefaultsDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDefaultsDatabase.Name = "tabDefaultsDatabase";
            this.tabDefaultsDatabase.Size = new System.Drawing.Size(525, 329);
            this.tabDefaultsDatabase.TabIndex = 3;
            this.tabDefaultsDatabase.Text = "Database Defaults";
            this.tabDefaultsDatabase.UseVisualStyleBackColor = true;
            // 
            // lblAlertNewDefaultsDatabase
            // 
            this.lblAlertNewDefaultsDatabase.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertNewDefaultsDatabase.Location = new System.Drawing.Point(12, 10);
            this.lblAlertNewDefaultsDatabase.Name = "lblAlertNewDefaultsDatabase";
            this.lblAlertNewDefaultsDatabase.Size = new System.Drawing.Size(412, 16);
            this.lblAlertNewDefaultsDatabase.TabIndex = 36;
            this.lblAlertNewDefaultsDatabase.Text = "Note: These settings only affect how new objects are created.";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(15, 40);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(170, 16);
            this.lblDatabase.TabIndex = 37;
            this.lblDatabase.Text = "Database name:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultDataBase", true));
            this.txtDatabase.Location = new System.Drawing.Point(15, 56);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(177, 20);
            this.txtDatabase.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtDatabase, "Specify the default database to be set on created objects.");
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.Location = new System.Drawing.Point(15, 88);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(170, 16);
            this.lblTransactionType.TabIndex = 38;
            this.lblTransactionType.Text = "Transaction Type:";
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultTransactionType", true));
            this.cboTransactionType.Location = new System.Drawing.Point(15, 104);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(177, 21);
            this.cboTransactionType.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cboTransactionType,
                                     "Select the transaction model to be used by the DataPortal." +
                                     "\r\nSince version 4.0.0 TransactionalAttribute is deprecated in favour of TransactionScope." +
                                     "\r\nReferences to TransactionalAttribute are automatically converted to TransactionScope.");
            // 
            // lblPersistenceType
            // 
            this.lblPersistenceType.Location = new System.Drawing.Point(15, 136);
            this.lblPersistenceType.Name = "lblPersistenceType";
            this.lblPersistenceType.Size = new System.Drawing.Size(170, 16);
            this.lblPersistenceType.TabIndex = 32;
            this.lblPersistenceType.Text = "Persistence Type:";
            // 
            // cboPersistenceType
            // 
            this.cboPersistenceType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultPersistenceType", true));
            this.cboPersistenceType.Location = new System.Drawing.Point(15, 152);
            this.cboPersistenceType.Name = "cboPersistenceType";
            this.cboPersistenceType.Size = new System.Drawing.Size(177, 21);
            this.cboPersistenceType.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cboPersistenceType,
                                     "Select the type of persistence to be used by the DataPortal:" +
                                     "\r\n- SqlConnectionManager for SQL Server, using ConnectionManager/TransactionManager" +
                                     "\r\n- SqlConnectionUnshared for SQL Server, using classic SqlConnection object (no transactions available)" +
                                     "\r\n- LinqContext for LINQ to SQL" +
                                     "\r\n- EFContext for Entity Framework object");
            // 
            // lblDatabaseContextObject
            // 
            this.lblDatabaseContextObject.Location = new System.Drawing.Point(15, 184);
            this.lblDatabaseContextObject.Name = "lblDatabaseContextObject";
            this.lblDatabaseContextObject.Size = new System.Drawing.Size(170, 16);
            this.lblDatabaseContextObject.TabIndex = 33;
            this.lblDatabaseContextObject.Text = "Database Context Object:";
            // 
            // txtDatabaseContextObject
            // 
            this.txtDatabaseContextObject.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultDatabaseContextObject", true));
            this.txtDatabaseContextObject.Location = new System.Drawing.Point(15, 200);
            this.txtDatabaseContextObject.Name = "txtDatabaseContextObject";
            this.txtDatabaseContextObject.Size = new System.Drawing.Size(177, 20);
            this.txtDatabaseContextObject.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtDatabaseContextObject, "Specify the default database context object to be set on created objects."+
                "\r\nThis is needed for LINQ to SQL and Entity Framework persistence.");
            // 
            // groupBoxObjectRelationsBuilder
            // 
            this.groupBoxObjectRelationsBuilder.Controls.Add(this.lblChildPropertySuffix);
            this.groupBoxObjectRelationsBuilder.Controls.Add(this.txtChildPropertySuffix);
            this.groupBoxObjectRelationsBuilder.Controls.Add(this.lblCollectionSuffix);
            this.groupBoxObjectRelationsBuilder.Controls.Add(this.txtCollectionSuffix);
            this.groupBoxObjectRelationsBuilder.Controls.Add(this.lblSingleSPSuffix);
            this.groupBoxObjectRelationsBuilder.Controls.Add(this.txtSingleSPSuffix);
            this.groupBoxObjectRelationsBuilder.Controls.Add(this.chkItemsUseSingleSP);
            this.groupBoxObjectRelationsBuilder.Location = new System.Drawing.Point(220, 46);
            this.groupBoxObjectRelationsBuilder.Name = "groupBoxObjectRelationsBuilder";
            this.groupBoxObjectRelationsBuilder.Size = new System.Drawing.Size(220, 178);
            this.groupBoxObjectRelationsBuilder.TabIndex = 8;
            this.groupBoxObjectRelationsBuilder.TabStop = false;
            this.groupBoxObjectRelationsBuilder.Text = "Object Relations Builder";
            // 
            // lblChildPropertySuffix
            // 
            this.lblChildPropertySuffix.Location = new System.Drawing.Point(12, 20);
            this.lblChildPropertySuffix.Name = "lblChildPropertySuffix";
            this.lblChildPropertySuffix.Size = new System.Drawing.Size(110, 16);
            this.lblChildPropertySuffix.TabIndex = 31;
            this.lblChildPropertySuffix.Text = "Property Name suffix";
            // 
            // txtChildPropertySuffix
            // 
            this.txtChildPropertySuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ORBChildPropertySuffix", true));
            this.txtChildPropertySuffix.Location = new System.Drawing.Point(12, 36);
            this.txtChildPropertySuffix.Name = "txtChildPropertySuffix";
            this.txtChildPropertySuffix.Size = new System.Drawing.Size(104, 20);
            this.txtChildPropertySuffix.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtChildPropertySuffix, "Specify a suffix to be used on Primary and Secondary Property Name.");
            // 
            // lblCollectionSuffix
            // 
            this.lblCollectionSuffix.Location = new System.Drawing.Point(12, 64);
            this.lblCollectionSuffix.Name = "lblCollectionSuffix";
            this.lblCollectionSuffix.Size = new System.Drawing.Size(124, 16);
            this.lblCollectionSuffix.TabIndex = 32;
            this.lblCollectionSuffix.Text = "Collection Name suffix";
            // 
            // txtCollectionSuffix
            // 
            this.txtCollectionSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ORBCollectionSuffix", true));
            this.txtCollectionSuffix.Location = new System.Drawing.Point(12, 80);
            this.txtCollectionSuffix.Name = "txtCollectionSuffix";
            this.txtCollectionSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtCollectionSuffix.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtCollectionSuffix, "Specify a suffix to be used on Primary and Secondary Collection Type Name.");
            // 
            // lblSingleSPSuffix
            // 
            this.lblSingleSPSuffix.Location = new System.Drawing.Point(12, 108);
            this.lblSingleSPSuffix.Name = "lblSingleSPSuffix";
            this.lblSingleSPSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblSingleSPSuffix.TabIndex = 33;
            this.lblSingleSPSuffix.Text = "Single SP suffix";
            // 
            // txtSingleSPSuffix
            // 
            this.txtSingleSPSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ORBSingleSPSuffix", true));
            this.txtSingleSPSuffix.Location = new System.Drawing.Point(12, 124);
            this.txtSingleSPSuffix.Name = "txtSingleSPSuffix";
            this.txtSingleSPSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtSingleSPSuffix.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtSingleSPSuffix, "Specify a suffix to be used on single set of stored procedure's name.");
            // 
            // chkItemsUseSingleSP
            // 
            this.chkItemsUseSingleSP.AutoSize = false;
            this.chkItemsUseSingleSP.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "ORBItemsUseSingleSP", true));
            this.chkItemsUseSingleSP.Location = new System.Drawing.Point(12, 152);
            this.chkItemsUseSingleSP.Name = "chkItemsUseSingleSP";
            this.chkItemsUseSingleSP.Size = new System.Drawing.Size(193, 20);
            this.chkItemsUseSingleSP.TabIndex = 12;
            this.chkItemsUseSingleSP.Text = "Use single SP set for N to N items";
            this.chkItemsUseSingleSP.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkItemsUseSingleSP,
                                     "If checked, on N to N relations, a single set of stored procedures is generated\r\n" +
                                     "for relation items.");
            // 
            // tabStoredProcs
            // 
            this.tabStoredProcs.Controls.Add(this.groupBoxPrefixSuffix);
            this.tabStoredProcs.Controls.Add(this.lblIntSoftDelete);
            this.tabStoredProcs.Controls.Add(this.txtIntSoftDelete);
            this.tabStoredProcs.Controls.Add(this.lblBoolSoftDelete);
            this.tabStoredProcs.Controls.Add(this.txtBoolSoftDelete);
            this.tabStoredProcs.Controls.Add(this.chkIgnoreFilterWhenSoftDeleteIsParam);
            this.tabStoredProcs.Controls.Add(this.chkRemoveChildBeforeParent);
            this.tabStoredProcs.Location = new System.Drawing.Point(4, 22);
            this.tabStoredProcs.Name = "tabStoredProcs";
            this.tabStoredProcs.Size = new System.Drawing.Size(525, 329);
            this.tabStoredProcs.TabIndex = 2;
            this.tabStoredProcs.Text = "Stored Procedures";
            this.tabStoredProcs.UseVisualStyleBackColor = true;
            // 
            // groupBoxPrefixSuffix
            // 
            this.groupBoxPrefixSuffix.Controls.Add(this.lblGeneralSpPrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtGeneralSpPrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.lblSelectPrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtSelectPrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.lblInsertPrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtInsertPrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.lblUpdatePrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtUpdatePrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtDeletePrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.lblDeletePrefix);
            this.groupBoxPrefixSuffix.Controls.Add(this.lblGeneralSpSuffix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtGeneralSpSuffix);
            this.groupBoxPrefixSuffix.Controls.Add(this.lblSelectSuffix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtSelectSuffix);
            this.groupBoxPrefixSuffix.Controls.Add(this.lblInsertSuffix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtInsertSuffix);
            this.groupBoxPrefixSuffix.Controls.Add(this.lblUpdateSuffix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtUpdateSuffix);
            this.groupBoxPrefixSuffix.Controls.Add(this.lblDeleteSuffix);
            this.groupBoxPrefixSuffix.Controls.Add(this.txtDeleteSuffix);
            this.groupBoxPrefixSuffix.Location = new System.Drawing.Point(10, 12);
            this.groupBoxPrefixSuffix.Name = "groupBoxPrefixSuffix";
            this.groupBoxPrefixSuffix.Size = new System.Drawing.Size(268, 250);
            this.groupBoxPrefixSuffix.TabIndex = 3;
            this.groupBoxPrefixSuffix.TabStop = false;
            this.groupBoxPrefixSuffix.Text = "Prefixes && Suffixes";
            // 
            // lblGeneralSpPrefix
            // 
            this.lblGeneralSpPrefix.Location = new System.Drawing.Point(12, 20);
            this.lblGeneralSpPrefix.Name = "lblGeneralSpPrefix";
            this.lblGeneralSpPrefix.Size = new System.Drawing.Size(107, 16);
            this.lblGeneralSpPrefix.TabIndex = 34;
            this.lblGeneralSpPrefix.Text = "General SP prefix";
            // 
            // txtGeneralSpPrefix
            // 
            this.txtGeneralSpPrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpGeneralPrefix", true));
            this.txtGeneralSpPrefix.Location = new System.Drawing.Point(12, 36);
            this.txtGeneralSpPrefix.Name = "txtGeneralSpPrefix";
            this.txtGeneralSpPrefix.Size = new System.Drawing.Size(104, 20);
            this.txtGeneralSpPrefix.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtGeneralSpPrefix, "Specify a prefix to be used on all stored procedure's name.");
            // 
            // lblSelectPrefix
            // 
            this.lblSelectPrefix.Location = new System.Drawing.Point(12, 72);
            this.lblSelectPrefix.Name = "lblSelectPrefix";
            this.lblSelectPrefix.Size = new System.Drawing.Size(104, 16);
            this.lblSelectPrefix.TabIndex = 37;
            this.lblSelectPrefix.Text = "Select prefix";
            // 
            // txtSelectPrefix
            // 
            this.txtSelectPrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpGetPrefix", true));
            this.txtSelectPrefix.Location = new System.Drawing.Point(12, 88);
            this.txtSelectPrefix.Name = "txtSelectPrefix";
            this.txtSelectPrefix.Size = new System.Drawing.Size(104, 20);
            this.txtSelectPrefix.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtSelectPrefix, "Specify a prefix to be used on SELECT stored procedure's name.");
            // 
            // lblInsertPrefix
            // 
            this.lblInsertPrefix.Location = new System.Drawing.Point(12, 116);
            this.lblInsertPrefix.Name = "lblInsertPrefix";
            this.lblInsertPrefix.Size = new System.Drawing.Size(104, 16);
            this.lblInsertPrefix.TabIndex = 36;
            this.lblInsertPrefix.Text = "Insert prefix";
            // 
            // txtInsertPrefix
            // 
            this.txtInsertPrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpAddPrefix", true));
            this.txtInsertPrefix.Location = new System.Drawing.Point(12, 132);
            this.txtInsertPrefix.Name = "txtInsertPrefix";
            this.txtInsertPrefix.Size = new System.Drawing.Size(104, 20);
            this.txtInsertPrefix.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtInsertPrefix, "Specify a prefix to be used on INSERT stored procedure's name.");
            // 
            // lblUpdatePrefix
            // 
            this.lblUpdatePrefix.Location = new System.Drawing.Point(12, 160);
            this.lblUpdatePrefix.Name = "lblUpdatePrefix";
            this.lblUpdatePrefix.Size = new System.Drawing.Size(104, 16);
            this.lblUpdatePrefix.TabIndex = 38;
            this.lblUpdatePrefix.Text = "Update prefix";
            // 
            // txtUpdatePrefix
            // 
            this.txtUpdatePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpUpdatePrefix", true));
            this.txtUpdatePrefix.Location = new System.Drawing.Point(12, 176);
            this.txtUpdatePrefix.Name = "txtUpdatePrefix";
            this.txtUpdatePrefix.Size = new System.Drawing.Size(104, 20);
            this.txtUpdatePrefix.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtUpdatePrefix, "Specify a prefix to be used on UPDATE stored procedure's name.");
            // 
            // lblDeletePrefix
            // 
            this.lblDeletePrefix.Location = new System.Drawing.Point(12, 204);
            this.lblDeletePrefix.Name = "lblDeletePrefix";
            this.lblDeletePrefix.Size = new System.Drawing.Size(104, 16);
            this.lblDeletePrefix.TabIndex = 39;
            this.lblDeletePrefix.Text = "Delete prefix";
            // 
            // txtDeletePrefix
            // 
            this.txtDeletePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpDeletePrefix", true));
            this.txtDeletePrefix.Location = new System.Drawing.Point(12, 220);
            this.txtDeletePrefix.Name = "txtDeletePrefix";
            this.txtDeletePrefix.Size = new System.Drawing.Size(104, 20);
            this.txtDeletePrefix.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtDeletePrefix, "Specify a prefix to be used on DELETE stored procedure's name.");
            // 
            // lblGeneralSpSuffix
            // 
            this.lblGeneralSpSuffix.Location = new System.Drawing.Point(150, 20);
            this.lblGeneralSpSuffix.Name = "lblGeneralSpSuffix";
            this.lblGeneralSpSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblGeneralSpSuffix.TabIndex = 35;
            this.lblGeneralSpSuffix.Text = "General SP suffix";
            // 
            // txtGeneralSpSuffix
            // 
            this.txtGeneralSpSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpGeneralSuffix", true));
            this.txtGeneralSpSuffix.Location = new System.Drawing.Point(150, 36);
            this.txtGeneralSpSuffix.Name = "txtGeneralSpSuffix";
            this.txtGeneralSpSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtGeneralSpSuffix.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtGeneralSpSuffix, "Specify a suffix to be used on all stored procedure's name.");
            // 
            // lblSelectSuffix
            // 
            this.lblSelectSuffix.Location = new System.Drawing.Point(150, 72);
            this.lblSelectSuffix.Name = "lblSelectSuffix";
            this.lblSelectSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblSelectSuffix.TabIndex = 37;
            this.lblSelectSuffix.Text = "Select suffix";
            // 
            // txtSelectSuffix
            // 
            this.txtSelectSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpGetSuffix", true));
            this.txtSelectSuffix.Location = new System.Drawing.Point(150, 88);
            this.txtSelectSuffix.Name = "txtSelectSuffix";
            this.txtSelectSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtSelectSuffix.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtSelectSuffix, "Specify a suffix to be used on SELECT stored procedure's name.");
            // 
            // lblInsertSuffix
            // 
            this.lblInsertSuffix.Location = new System.Drawing.Point(150, 116);
            this.lblInsertSuffix.Name = "lblInsertSuffix";
            this.lblInsertSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblInsertSuffix.TabIndex = 36;
            this.lblInsertSuffix.Text = "Insert suffix";
            // 
            // txtInsertSuffix
            // 
            this.txtInsertSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpAddSuffix", true));
            this.txtInsertSuffix.Location = new System.Drawing.Point(150, 132);
            this.txtInsertSuffix.Name = "txtInsertSuffix";
            this.txtInsertSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtInsertSuffix.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtInsertSuffix, "Specify a suffix to be used on INSERT stored procedure's name.");
            // 
            // lblUpdateSuffix
            // 
            this.lblUpdateSuffix.Location = new System.Drawing.Point(150, 160);
            this.lblUpdateSuffix.Name = "lblUpdateSuffix";
            this.lblUpdateSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblUpdateSuffix.TabIndex = 38;
            this.lblUpdateSuffix.Text = "Update suffix";
            // 
            // txtUpdateSuffix
            // 
            this.txtUpdateSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpUpdateSuffix", true));
            this.txtUpdateSuffix.Location = new System.Drawing.Point(150, 176);
            this.txtUpdateSuffix.Name = "txtUpdateSuffix";
            this.txtUpdateSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtUpdateSuffix.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtUpdateSuffix, "Specify a suffix to be used on UPDATE stored procedure's name.");
            // 
            // lblDeleteSuffix
            // 
            this.lblDeleteSuffix.Location = new System.Drawing.Point(150, 204);
            this.lblDeleteSuffix.Name = "lblDeleteSuffix";
            this.lblDeleteSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblDeleteSuffix.TabIndex = 39;
            this.lblDeleteSuffix.Text = "Delete suffix";
            // 
            // txtDeleteSuffix
            // 
            this.txtDeleteSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpDeleteSuffix", true));
            this.txtDeleteSuffix.Location = new System.Drawing.Point(150, 220);
            this.txtDeleteSuffix.Name = "txtDeleteSuffix";
            this.txtDeleteSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtDeleteSuffix.TabIndex = 13;
            this.toolTip1.SetToolTip(this.txtDeleteSuffix, "Specify a suffix to be used on DELETE stored procedure's name.");
            // 
            // lblBoolSoftDelete
            // 
            this.lblBoolSoftDelete.Location = new System.Drawing.Point(294, 12);
            this.lblBoolSoftDelete.Name = "lblBoolSoftDelete";
            this.lblBoolSoftDelete.Size = new System.Drawing.Size(130, 16);
            this.lblBoolSoftDelete.TabIndex = 31;
            this.lblBoolSoftDelete.Text = "Bool soft delete column";
            // 
            // txtBoolSoftDelete
            // 
            this.txtBoolSoftDelete.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpBoolSoftDeleteColumn", true));
            this.txtBoolSoftDelete.Location = new System.Drawing.Point(294, 28);
            this.txtBoolSoftDelete.Name = "txtBoolSoftDelete";
            this.txtBoolSoftDelete.Size = new System.Drawing.Size(130, 20);
            this.txtBoolSoftDelete.TabIndex = 14;
            this.toolTip1.SetToolTip(this.txtBoolSoftDelete, "Specify the column name to be recognized as a \"Boolean\" soft delete column.");
            // 
            // lblIntSoftDelete
            // 
            this.lblIntSoftDelete.Location = new System.Drawing.Point(294, 56);
            this.lblIntSoftDelete.Name = "lblIntSoftDelete";
            this.lblIntSoftDelete.Size = new System.Drawing.Size(130, 16);
            this.lblIntSoftDelete.TabIndex = 32;
            this.lblIntSoftDelete.Text = "Int soft delete column";
            // 
            // txtIntSoftDelete
            // 
            this.txtIntSoftDelete.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpIntSoftDeleteColumn", true));
            this.txtIntSoftDelete.Location = new System.Drawing.Point(294, 72);
            this.txtIntSoftDelete.Name = "txtIntSoftDelete";
            this.txtIntSoftDelete.Size = new System.Drawing.Size(130, 20);
            this.txtIntSoftDelete.TabIndex = 15;
            this.toolTip1.SetToolTip(this.txtIntSoftDelete, "CTP - Not implemented.\r\n\r\n" + 
                "Specify the column name to be recognized as an \"integer\" soft delete column.");
            // 
            // chkIgnoreFilterWhenSoftDeleteIsParam
            // 
            this.chkIgnoreFilterWhenSoftDeleteIsParam.AutoSize = true;
            this.chkIgnoreFilterWhenSoftDeleteIsParam.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "SpIgnoreFilterWhenSoftDeleteIsParam", true));
            this.chkIgnoreFilterWhenSoftDeleteIsParam.Location = new System.Drawing.Point(294, 104);
            this.chkIgnoreFilterWhenSoftDeleteIsParam.Name = "chkIgnoreFilterWhenSoftDeleteIsParam";
            this.chkIgnoreFilterWhenSoftDeleteIsParam.Size = new System.Drawing.Size(130, 20);
            this.chkIgnoreFilterWhenSoftDeleteIsParam.TabIndex = 16;
            this.chkIgnoreFilterWhenSoftDeleteIsParam.Text = "Ignore filter when soft delete column is a ValueProperty";
            this.chkIgnoreFilterWhenSoftDeleteIsParam.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkIgnoreFilterWhenSoftDeleteIsParam,
                                     "If checked, when the soft delete column is a ValueProperty," +
                                     "\r\nthe Stored Procedure won't filter out rows based on soft delete status.");
            // 
            // chkRemoveChildBeforeParent
            // 
            this.chkRemoveChildBeforeParent.AutoSize = true;
            this.chkRemoveChildBeforeParent.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "SpRemoveChildBeforeParent", true));
            this.chkRemoveChildBeforeParent.Location = new System.Drawing.Point(294, 132);
            this.chkRemoveChildBeforeParent.Name = "chkRemoveChildBeforeParent";
            this.chkRemoveChildBeforeParent.Size = new System.Drawing.Size(130, 20);
            this.chkRemoveChildBeforeParent.TabIndex = 17;
            this.chkRemoveChildBeforeParent.Text = "Remove all child before removing the parent";
            this.chkRemoveChildBeforeParent.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkRemoveChildBeforeParent,
                                     "If checked, the Stored Procedure will delete (or soft delete) all child rows\r\n" +
                                     "before deleting (or soft deleting) the parent row." +
                                     "\r\n\r\nCTP - Not implemented.\r\n" +
                                     "If unchecked, the database child removal must be handle by an override to RemoveItem.");
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.Controls.Add(this.groupBoxPKDefaultValues);
            this.tabAdvanced.Controls.Add(this.groupBoxOtherParameters);
            this.tabAdvanced.Controls.Add(this.groupBoxSimpleAuditing);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Size = new System.Drawing.Size(525, 329);
            this.tabAdvanced.TabIndex = 2;
            this.tabAdvanced.Text = "Advanced";
            this.tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // groupBoxPKDefaultValues
            // 
            this.groupBoxPKDefaultValues.Controls.Add(this.lblIDGuidDefaultValue);
            this.groupBoxPKDefaultValues.Controls.Add(this.txtIDGuidDefaultValue);
            this.groupBoxPKDefaultValues.Controls.Add(this.lblIDInt16DefaultValue);
            this.groupBoxPKDefaultValues.Controls.Add(this.txtIDInt16DefaultValue);
            this.groupBoxPKDefaultValues.Controls.Add(this.lblIDInt32DefaultValue);
            this.groupBoxPKDefaultValues.Controls.Add(this.txtIDInt32DefaultValue);
            this.groupBoxPKDefaultValues.Controls.Add(this.lblIDInt64DefaultValue);
            this.groupBoxPKDefaultValues.Controls.Add(this.txtIDInt64DefaultValue);
            this.groupBoxPKDefaultValues.Location = new System.Drawing.Point(10, 12);
            this.groupBoxPKDefaultValues.Name = "groupBoxPKDefaultValues";
            this.groupBoxPKDefaultValues.Size = new System.Drawing.Size(224, 136);
            this.groupBoxPKDefaultValues.TabIndex = 0;
            this.groupBoxPKDefaultValues.TabStop = false;
            this.groupBoxPKDefaultValues.Text = "PK Property Default Values";
            // 
            // lblIDGuidDefaultValue
            // 
            this.lblIDGuidDefaultValue.Location = new System.Drawing.Point(12, 24);
            this.lblIDGuidDefaultValue.Name = "lblIDGuidDefaultValue";
            this.lblIDGuidDefaultValue.Size = new System.Drawing.Size(98, 16);
            this.lblIDGuidDefaultValue.TabIndex = 3;
            this.lblIDGuidDefaultValue.Text = "Guid:";
            // 
            // txtIDGuidDefaultValue
            // 
            this.txtIDGuidDefaultValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "IDGuidDefaultValue", true));
            this.txtIDGuidDefaultValue.Location = new System.Drawing.Point(112, 22);
            this.txtIDGuidDefaultValue.Name = "txtIDGuidDefaultValue";
            this.txtIDGuidDefaultValue.Size = new System.Drawing.Size(100, 20);
            this.txtIDGuidDefaultValue.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtIDGuidDefaultValue,
                                     "Specify the value to be assigned on new object creation by DataPortal_Create.");
            // 
            // lblIDInt16DefaultValue
            // 
            this.lblIDInt16DefaultValue.Location = new System.Drawing.Point(12, 52);
            this.lblIDInt16DefaultValue.Name = "lblIDInt16DefaultValue";
            this.lblIDInt16DefaultValue.Size = new System.Drawing.Size(98, 16);
            this.lblIDInt16DefaultValue.TabIndex = 5;
            this.lblIDInt16DefaultValue.Text = "Int16 Identity:";
            // 
            // txtIDInt16DefaultValue
            // 
            this.txtIDInt16DefaultValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "IDInt16DefaultValue", true));
            this.txtIDInt16DefaultValue.Location = new System.Drawing.Point(112, 50);
            this.txtIDInt16DefaultValue.Name = "txtIDInt16DefaultValue";
            this.txtIDInt16DefaultValue.Size = new System.Drawing.Size(100, 20);
            this.txtIDInt16DefaultValue.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtIDInt16DefaultValue,
                                     "Specify the value to be assigned on new object creation by DataPortal_Create." +
                                     "\r\nUse case insensitive \"_lastID\" to generate the assignement:" +
                                     "\r\nSystem.Threading.Interlocked.Decrement(ref _lastID)");
            // 
            // lblIDInt32DefaultValue
            // 
            this.lblIDInt32DefaultValue.Location = new System.Drawing.Point(12, 80);
            this.lblIDInt32DefaultValue.Name = "lblIDInt32DefaultValue";
            this.lblIDInt32DefaultValue.Size = new System.Drawing.Size(98, 16);
            this.lblIDInt32DefaultValue.TabIndex = 8;
            this.lblIDInt32DefaultValue.Text = "Int32 Identity:";
            // 
            // txtIDInt32DefaultValue
            // 
            this.txtIDInt32DefaultValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "IDInt32DefaultValue", true));
            this.txtIDInt32DefaultValue.Location = new System.Drawing.Point(112, 78);
            this.txtIDInt32DefaultValue.Name = "txtIDInt32DefaultValue";
            this.txtIDInt32DefaultValue.Size = new System.Drawing.Size(100, 20);
            this.txtIDInt32DefaultValue.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtIDInt32DefaultValue,
                                     "Specify the value to be assigned on new object creation by DataPortal_Create." +
                                     "\r\nUse case insensitive \"_lastID\" to generate the assignement:" +
                                     "\r\nSystem.Threading.Interlocked.Decrement(ref _lastID)");
            // 
            // lblIDInt64DefaultValue
            // 
            this.lblIDInt64DefaultValue.Location = new System.Drawing.Point(12, 108);
            this.lblIDInt64DefaultValue.Name = "lblIDInt64DefaultValue";
            this.lblIDInt64DefaultValue.Size = new System.Drawing.Size(98, 16);
            this.lblIDInt64DefaultValue.TabIndex = 10;
            this.lblIDInt64DefaultValue.Text = "Int64 Identity:";
            // 
            // txtIDInt64DefaultValue
            // 
            this.txtIDInt64DefaultValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "IDInt64DefaultValue", true));
            this.txtIDInt64DefaultValue.Location = new System.Drawing.Point(112, 106);
            this.txtIDInt64DefaultValue.Name = "txtIDInt64DefaultValue";
            this.txtIDInt64DefaultValue.Size = new System.Drawing.Size(100, 20);
            this.txtIDInt64DefaultValue.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtIDInt64DefaultValue,
                                     "Specify the value to be assigned on new object creation by DataPortal_Create." +
                                     "\r\nUse case insensitive \"_lastID\" to generate the assignement:" +
                                     "\r\nSystem.Threading.Interlocked.Decrement(ref _lastID)");
            // 
            // groupBoxOtherParameters
            // 
            this.groupBoxOtherParameters.Controls.Add(this.lblFieldNamePrefix);
            this.groupBoxOtherParameters.Controls.Add(this.txtFieldNamePrefix);
            this.groupBoxOtherParameters.Controls.Add(this.lblDelegateNamePrefix);
            this.groupBoxOtherParameters.Controls.Add(this.txtDelegateNamePrefix);
            this.groupBoxOtherParameters.Location = new System.Drawing.Point(10, 158);
            this.groupBoxOtherParameters.Name = "groupBoxOtherParameters";
            this.groupBoxOtherParameters.Size = new System.Drawing.Size(224, 80);
            this.groupBoxOtherParameters.TabIndex = 3;
            this.groupBoxOtherParameters.TabStop = false;
            this.groupBoxOtherParameters.Text = "Other Parameters";
            // 
            // lblFieldNamePrefix
            // 
            this.lblFieldNamePrefix.Location = new System.Drawing.Point(12, 24);
            this.lblFieldNamePrefix.Name = "lblFieldNamePrefix";
            this.lblFieldNamePrefix.Size = new System.Drawing.Size(100, 16);
            this.lblFieldNamePrefix.TabIndex = 3;
            this.lblFieldNamePrefix.Text = "Field Prefix:";
            // 
            // txtFieldNamePrefix
            // 
            this.txtFieldNamePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "FieldNamePrefix", true));
            this.txtFieldNamePrefix.Location = new System.Drawing.Point(112, 22);
            this.txtFieldNamePrefix.Name = "txtFieldNamePrefix";
            this.txtFieldNamePrefix.Size = new System.Drawing.Size(100, 20);
            this.txtFieldNamePrefix.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtFieldNamePrefix, "Specify a prefix to be used on field's name.");
            // 
            // lblDelegateNamePrefix
            // 
            this.lblDelegateNamePrefix.Location = new System.Drawing.Point(12, 52);
            this.lblDelegateNamePrefix.Name = "lblDelegateNamePrefix";
            this.lblDelegateNamePrefix.Size = new System.Drawing.Size(100, 16);
            this.lblDelegateNamePrefix.TabIndex = 5;
            this.lblDelegateNamePrefix.Text = "Delegate Prefix:";
            // 
            // txtDelegateNamePrefix
            // 
            this.txtDelegateNamePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DelegateNamePrefix", true));
            this.txtDelegateNamePrefix.Location = new System.Drawing.Point(112, 50);
            this.txtDelegateNamePrefix.Name = "txtDelegateNamePrefix";
            this.txtDelegateNamePrefix.Size = new System.Drawing.Size(100, 20);
            this.txtDelegateNamePrefix.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtDelegateNamePrefix, "Specify a prefix to be used on delegate's name.");
            // 
            // groupBoxSimpleAuditing
            // 
            this.groupBoxSimpleAuditing.Controls.Add(this.lblCreationDateColumn);
            this.groupBoxSimpleAuditing.Controls.Add(this.txtCreationDateColumn);
            this.groupBoxSimpleAuditing.Controls.Add(this.lblCreationUserColumn);
            this.groupBoxSimpleAuditing.Controls.Add(this.txtCreationUserColumn);
            this.groupBoxSimpleAuditing.Controls.Add(this.lblChangedDateColumn);
            this.groupBoxSimpleAuditing.Controls.Add(this.txtChangedDateColumn);
            this.groupBoxSimpleAuditing.Controls.Add(this.lblChangedUserColumn);
            this.groupBoxSimpleAuditing.Controls.Add(this.txtChangedUserColumn);
            this.groupBoxSimpleAuditing.Controls.Add(this.chkLogDateAndTime);
            this.groupBoxSimpleAuditing.Controls.Add(this.lblGetUserMethod);
            this.groupBoxSimpleAuditing.Controls.Add(this.txtGetUserMethod);
            this.groupBoxSimpleAuditing.Location = new System.Drawing.Point(244, 12);
            this.groupBoxSimpleAuditing.Name = "groupBoxSimpleAuditing";
            this.groupBoxSimpleAuditing.Size = new System.Drawing.Size(248, 226);
            this.groupBoxSimpleAuditing.TabIndex = 3;
            this.groupBoxSimpleAuditing.TabStop = false;
            this.groupBoxSimpleAuditing.Text = "Simple Auditing";
            // 
            // lblCreationDateColumn
            // 
            this.lblCreationDateColumn.Location = new System.Drawing.Point(12, 24);
            this.lblCreationDateColumn.Name = "lblCreationDateColumn";
            this.lblCreationDateColumn.Size = new System.Drawing.Size(122, 16);
            this.lblCreationDateColumn.TabIndex = 3;
            this.lblCreationDateColumn.Text = "Creation Date Column:";
            // 
            // txtCreationDateColumn
            // 
            this.txtCreationDateColumn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "CreationDateColumn", true));
            this.txtCreationDateColumn.Location = new System.Drawing.Point(134, 22);
            this.txtCreationDateColumn.Name = "txtCreationDateColumn";
            this.txtCreationDateColumn.Size = new System.Drawing.Size(100, 20);
            this.txtCreationDateColumn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtCreationDateColumn,
                                     "Specify the column name to be recognized as a \"creation date\" column.");
            // 
            // lblCreationUserColumn
            // 
            this.lblCreationUserColumn.Location = new System.Drawing.Point(12, 52);
            this.lblCreationUserColumn.Name = "lblCreationUserColumn";
            this.lblCreationUserColumn.Size = new System.Drawing.Size(122, 16);
            this.lblCreationUserColumn.TabIndex = 3;
            this.lblCreationUserColumn.Text = "Creation User Column:";
            // 
            // txtCreationUserColumn
            // 
            this.txtCreationUserColumn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "CreationUserColumn", true));
            this.txtCreationUserColumn.Location = new System.Drawing.Point(134, 50);
            this.txtCreationUserColumn.Name = "txtCreationUserColumn";
            this.txtCreationUserColumn.Size = new System.Drawing.Size(100, 20);
            this.txtCreationUserColumn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtCreationUserColumn,
                                     "Specify the column name to be recognized as a \"creation user\" column.");
            // 
            // lblChangedDateColumn
            // 
            this.lblChangedDateColumn.Location = new System.Drawing.Point(12, 80);
            this.lblChangedDateColumn.Name = "lblChangedDateColumn";
            this.lblChangedDateColumn.Size = new System.Drawing.Size(122, 16);
            this.lblChangedDateColumn.TabIndex = 3;
            this.lblChangedDateColumn.Text = "Changed Date Column:";
            // 
            // txtChangedDateColumn
            // 
            this.txtChangedDateColumn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ChangedDateColumn", true));
            this.txtChangedDateColumn.Location = new System.Drawing.Point(134, 78);
            this.txtChangedDateColumn.Name = "txtChangedDateColumn";
            this.txtChangedDateColumn.Size = new System.Drawing.Size(100, 20);
            this.txtChangedDateColumn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtChangedDateColumn,
                                     "Specify the column name to be recognized as a \"changed date\" column.");
            // 
            // lblChangedUserColumn
            // 
            this.lblChangedUserColumn.Location = new System.Drawing.Point(12, 108);
            this.lblChangedUserColumn.Name = "lblChangedUserColumn";
            this.lblChangedUserColumn.Size = new System.Drawing.Size(122, 16);
            this.lblChangedUserColumn.TabIndex = 3;
            this.lblChangedUserColumn.Text = "Changed User Column:";
            // 
            // txtChangedUserColumn
            // 
            this.txtChangedUserColumn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ChangedUserColumn", true));
            this.txtChangedUserColumn.Location = new System.Drawing.Point(134, 106);
            this.txtChangedUserColumn.Name = "txtChangedUserColumn";
            this.txtChangedUserColumn.Size = new System.Drawing.Size(100, 20);
            this.txtChangedUserColumn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtChangedUserColumn,
                                     "Specify the column name to be recognized as a \"changed user\" column.");
            // 
            // chkLogDateAndTime
            // 
            this.chkLogDateAndTime.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "LogDateAndTime", true));
            this.chkLogDateAndTime.Location = new System.Drawing.Point(12, 150);
            this.chkLogDateAndTime.Name = "chkLogDateAndTime";
            this.chkLogDateAndTime.Size = new System.Drawing.Size(200, 20);
            this.chkLogDateAndTime.TabIndex = 5;
            this.chkLogDateAndTime.Text = "Log Date and also Time";
            this.toolTip1.SetToolTip(this.chkLogDateAndTime, "If checked, date auditing uses time precision up to seconds.");
            // 
            // lblGetUserMethod
            // 
            this.lblGetUserMethod.Location = new System.Drawing.Point(12, 180);
            this.lblGetUserMethod.Name = "lblGetUserMethod";
            this.lblGetUserMethod.Size = new System.Drawing.Size(100, 16);
            this.lblGetUserMethod.TabIndex = 3;
            this.lblGetUserMethod.Text = "Get user method:";
            // 
            // txtGetUserMethod
            // 
            this.txtGetUserMethod.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "GetUserMethod", true));
            this.txtGetUserMethod.Location = new System.Drawing.Point(12, 196);
            this.txtGetUserMethod.Name = "txtGetUserMethod";
            this.txtGetUserMethod.Size = new System.Drawing.Size(223, 20);
            this.txtGetUserMethod.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtGetUserMethod,
                                     "Specify the method to be used to get a user value (ID or name or whatever) for auditing purposes.");
            // 
            // tabGeneration
            // 
            this.tabGeneration.Controls.Add(this.tabControlGeneration);
            this.tabGeneration.Location = new System.Drawing.Point(4, 22);
            this.tabGeneration.Name = "tabGeneration";
            this.tabGeneration.Size = new System.Drawing.Size(525, 329);
            this.tabGeneration.TabIndex = 1;
            this.tabGeneration.Text = "Generation";
            this.tabGeneration.UseVisualStyleBackColor = true;
            // 
            // tabControlGeneration
            // 
            this.tabControlGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlGeneration.Controls.Add(this.tabGenerationTarget);
            this.tabControlGeneration.Controls.Add(this.tabGenerationFiles);
            this.tabControlGeneration.Controls.Add(this.tabGenerationMisc);
            this.tabControlGeneration.Location = new System.Drawing.Point(0, 0);
            this.tabControlGeneration.Name = "tabControlGeneration";
            this.tabControlGeneration.SelectedIndex = 0;
            this.tabControlGeneration.Size = new System.Drawing.Size(525, 334);
            this.tabControlGeneration.TabIndex = 2;
            // 
            // tabGenerationTarget
            // 
            this.tabGenerationTarget.Controls.Add(this.chkSaveGenerationTarget);
            this.tabGenerationTarget.Controls.Add(this.lblTarget);
            this.tabGenerationTarget.Controls.Add(this.cboTarget);
            this.tabGenerationTarget.Controls.Add(this.lblOutputLanguage);
            this.tabGenerationTarget.Controls.Add(this.cboOutputLanguage);
            this.tabGenerationTarget.Controls.Add(this.groupBoxUIEnvironment);
            this.tabGenerationTarget.Controls.Add(this.groupBoxDataAccessLayer);
            this.tabGenerationTarget.Controls.Add(this.groupBoxServerInvocation);
            this.tabGenerationTarget.Location = new System.Drawing.Point(4, 22);
            this.tabGenerationTarget.Name = "tabGenerationTarget";
            this.tabGenerationTarget.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerationTarget.Size = new System.Drawing.Size(525, 329);
            this.tabGenerationTarget.TabIndex = 3;
            this.tabGenerationTarget.Text = "Target";
            this.tabGenerationTarget.UseVisualStyleBackColor = true;
            // 
            // chkSaveGenerationTarget
            // 
            this.chkSaveGenerationTarget.Checked = true;
            this.chkSaveGenerationTarget.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveGenerationTarget.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SaveBeforeGenerate", true));
            this.chkSaveGenerationTarget.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaveGenerationTarget.Location = new System.Drawing.Point(15, 10);
            this.chkSaveGenerationTarget.Name = "chkSaveGenerationTarget";
            this.chkSaveGenerationTarget.Size = new System.Drawing.Size(225, 21);
            this.chkSaveGenerationTarget.TabIndex = 4;
            this.chkSaveGenerationTarget.Text = "Save project before generating";
            this.toolTip1.SetToolTip(this.chkSaveGenerationTarget,
                                     "If checked, projects are silently saved before code generation.");
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(15, 50);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(101, 16);
            this.lblTarget.TabIndex = 31;
            this.lblTarget.Text = "Target Framework:";
            // 
            // cboTarget
            // 
            this.cboTarget.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "TargetFramework", true));
            this.cboTarget.Location = new System.Drawing.Point(116, 47);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Size = new System.Drawing.Size(118, 21);
            this.cboTarget.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cboTarget,
                                     "Select the target CSLA.NET framework version.\r\n" +
                                     "Use \"CSLA40DAL\" for generating a separate Data Access Layer.");
            // 
            // lblOutputLanguage
            // 
            this.lblOutputLanguage.Location = new System.Drawing.Point(15, 78);
            this.lblOutputLanguage.Name = "lblOutputLanguage";
            this.lblOutputLanguage.Size = new System.Drawing.Size(101, 16);
            this.lblOutputLanguage.TabIndex = 34;
            this.lblOutputLanguage.Text = "Output Language:";
            // 
            // cboOutputLanguage
            // 
            this.cboOutputLanguage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "OutputLanguage", true));
            this.cboOutputLanguage.Location = new System.Drawing.Point(116, 75);
            this.cboOutputLanguage.Name = "cboOutputLanguage";
            this.cboOutputLanguage.Size = new System.Drawing.Size(118, 21);
            this.cboOutputLanguage.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cboOutputLanguage,
                                     "Select the language for the generated code: C# or Visual Basic.\r\n" +
                                     "\r\nN.B. - JScript is deprecated since v.4.0.");
            // 
            // groupBoxUIEnvironment
            // 
            this.groupBoxUIEnvironment.Controls.Add(this.chkWinForms);
            this.groupBoxUIEnvironment.Controls.Add(this.chkWPF);
            this.groupBoxUIEnvironment.Controls.Add(this.chkSilverlight);
            this.groupBoxUIEnvironment.Controls.Add(this.chkSilverlightUseServices);
            this.groupBoxUIEnvironment.Location = new System.Drawing.Point(15, 118);
            this.groupBoxUIEnvironment.Name = "groupBoxUIEnvironment";
            this.groupBoxUIEnvironment.Size = new System.Drawing.Size(240, 132);
            this.groupBoxUIEnvironment.TabIndex = 7;
            this.groupBoxUIEnvironment.TabStop = false;
            this.groupBoxUIEnvironment.Text = "UI Environment";
            // 
            // chkWinForms
            // 
            this.chkWinForms.AutoSize = true;
            this.chkWinForms.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateWinForms", true));
            this.chkWinForms.Location = new System.Drawing.Point(12, 18);
            this.chkWinForms.Name = "chkWinForms";
            this.chkWinForms.Size = new System.Drawing.Size(287, 17);
            this.chkWinForms.TabIndex = 7;
            this.chkWinForms.Text = "Generate Windows Forms";
            this.chkWinForms.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkWinForms, "If checked, will generate Windows Forms code with conditional compilation symbol WINFORMS.");
            // 
            // chkWPF
            // 
            this.chkWPF.AutoSize = true;
            this.chkWPF.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateWPF", true));
            this.chkWPF.Location = new System.Drawing.Point(12, 46);
            this.chkWPF.Name = "chkWPF";
            this.chkWPF.Size = new System.Drawing.Size(74, 17);
            this.chkWPF.TabIndex = 8;
            this.chkWPF.Text = "Generate WPF, etc.";
            this.chkWPF.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkWPF, "If checked, will generate WPF code with no conditional compilation symbol.\r\n" +
                                     "\r\nN.B. - Check this option also for ASP.NET and ASP.NET MVC.");
            // 
            // chkSilverlight
            // 
            this.chkSilverlight.AutoSize = true;
            this.chkSilverlight.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateSilverlight4", true));
            this.chkSilverlight.Location = new System.Drawing.Point(12, 74);
            this.chkSilverlight.Name = "chkSilverlight";
            this.chkSilverlight.Size = new System.Drawing.Size(71, 17);
            this.chkSilverlight.TabIndex = 9;
            this.chkSilverlight.Text = "Generate Silverlight";
            this.chkSilverlight.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkSilverlight, "If checked, Silverlight will use CSLA MobileObject to interact with the DataPortal.\r\n" +
                "Generates code with conditional compilation symbol SILVERLIGHT.");
            // 
            // chkSilverlightUseServices
            // 
            this.chkSilverlightUseServices.AutoSize = true;
            this.chkSilverlightUseServices.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SilverlightUsingServices", true));
            this.chkSilverlightUseServices.Location = new System.Drawing.Point(12, 102);
            this.chkSilverlightUseServices.Name = "chkSilverlightUseServices";
            this.chkSilverlightUseServices.Size = new System.Drawing.Size(71, 17);
            this.chkSilverlightUseServices.TabIndex = 9;
            this.chkSilverlightUseServices.Text = "Generate Silverlight using services";
            this.chkSilverlightUseServices.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkSilverlightUseServices, "If checked, Silverlight DataPortal methods will call a partial method\r\n" +
                "that should handle the service interaction.\r\n" +
                "Generates code with conditional compilation symbol SILVERLIGHT.");
            // 
            // groupBoxDataAccessLayer
            // 
            this.groupBoxDataAccessLayer.Controls.Add(this.lblTargetDAL);
            this.groupBoxDataAccessLayer.Controls.Add(this.cboTargetDAL);
            this.groupBoxDataAccessLayer.Controls.Add(this.chkGenerateDAL);
            this.groupBoxDataAccessLayer.Location = new System.Drawing.Point(268, 30);
            this.groupBoxDataAccessLayer.Name = "groupBoxDataAccessLayer";
            this.groupBoxDataAccessLayer.Size = new System.Drawing.Size(240, 76);
            this.groupBoxDataAccessLayer.TabIndex = 37;
            this.groupBoxDataAccessLayer.TabStop = false;
            this.groupBoxDataAccessLayer.Text = "Data Access Layer";
            // 
            // lblTargetDAL
            // 
            this.lblTargetDAL.Location = new System.Drawing.Point(12, 18);
            this.lblTargetDAL.Name = "lblTargetDAL";
            this.lblTargetDAL.Size = new System.Drawing.Size(98, 16);
            this.lblTargetDAL.TabIndex = 36;
            this.lblTargetDAL.Text = "DAL type:";
            // 
            // cboTargetDAL
            // 
            this.cboTargetDAL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "TargetDAL", true));
            this.cboTargetDAL.Location = new System.Drawing.Point(113, 15);
            this.cboTargetDAL.Name = "cboTargetDAL";
            this.cboTargetDAL.Size = new System.Drawing.Size(118, 21);
            this.cboTargetDAL.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cboTargetDAL, "Select the type of DAL:\r\n" +
                " - Simple DAL generates Encapsulated Invoke - Data Access code is on its own project\r\n" +
                " - Interface DAL generates Encapsulated Invoke using an interface - DAL interface and DAL are on their own projects.\r\n" +
                "\r\nN.B. - This option is disabled for targets other than CSLA40DAL.");
            // 
            // chkGenerateDAL
            // 
            this.chkGenerateDAL.AutoSize = true;
            this.chkGenerateDAL.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateDAL", true));
            this.chkGenerateDAL.Location = new System.Drawing.Point(12, 46);
            this.chkGenerateDAL.Name = "chkGenerateDAL";
            this.chkGenerateDAL.Size = new System.Drawing.Size(50, 17);
            this.chkGenerateDAL.TabIndex = 12;
            this.chkGenerateDAL.Text = "Generate DAL";
            this.chkGenerateDAL.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkGenerateDAL, "If checked, will generate DAL code.\r\n" +
                                     "Otherwise DAL settings are honoured in Business Objects but no DAl code is generated.");
            // 
            // groupBoxServerInvocation
            // 
            this.groupBoxServerInvocation.Controls.Add(this.chkSynchronous);
            this.groupBoxServerInvocation.Controls.Add(this.chkAsynchronous);
            this.groupBoxServerInvocation.Location = new System.Drawing.Point(268, 118);
            this.groupBoxServerInvocation.Name = "groupBoxServerInvocation";
            this.groupBoxServerInvocation.Size = new System.Drawing.Size(240, 76);
            this.groupBoxServerInvocation.TabIndex = 37;
            this.groupBoxServerInvocation.TabStop = false;
            this.groupBoxServerInvocation.Text = "Server Invocation";
            // 
            // chkSynchronous
            // 
            this.chkSynchronous.AutoSize = true;
            this.chkSynchronous.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateSynchronous", true));
            this.chkSynchronous.Location = new System.Drawing.Point(12, 18);
            this.chkSynchronous.Name = "chkSynchronous";
            this.chkSynchronous.Size = new System.Drawing.Size(88, 17);
            this.chkSynchronous.TabIndex = 13;
            this.chkSynchronous.Text = "Generate Synchronous";
            this.chkSynchronous.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkSynchronous, "If checked, will generate synchronous server invocation.");
            // 
            // chkAsynchronous
            // 
            this.chkAsynchronous.AutoSize = true;
            this.chkAsynchronous.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateAsynchronous", true));
            this.chkAsynchronous.Location = new System.Drawing.Point(12, 46);
            this.chkAsynchronous.Name = "chkAsynchronous";
            this.chkAsynchronous.Size = new System.Drawing.Size(93, 17);
            this.chkAsynchronous.TabIndex = 14;
            this.chkAsynchronous.Text = "Generate Asynchronous";
            this.chkAsynchronous.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkAsynchronous, "If checked, will generate asynchronous server invocation.");
            // 
            // tabGenerationFiles
            // 
            this.tabGenerationFiles.Controls.Add(this.chkSaveGenerationFiles);
            this.tabGenerationFiles.Controls.Add(this.lblBaseFilenameSuffix);
            this.tabGenerationFiles.Controls.Add(this.txtBaseFilenameSuffix);
            this.tabGenerationFiles.Controls.Add(this.lblExtendedFilenameSuffix);
            this.tabGenerationFiles.Controls.Add(this.txtExtendedFilenameSuffix);
            this.tabGenerationFiles.Controls.Add(this.lblClassCommentFilenameSuffix);
            this.tabGenerationFiles.Controls.Add(this.txtClassCommentFilenameSuffix);
            this.tabGenerationFiles.Controls.Add(this.chkBackupOldSource);
            this.tabGenerationFiles.Controls.Add(this.chkSeparateBaseClasses);
            this.tabGenerationFiles.Controls.Add(this.chkSeparateNamespaces);
            this.tabGenerationFiles.Controls.Add(this.chkSeparateClassComment);
            this.tabGenerationFiles.Controls.Add(this.lblBaseNamespace);
            this.tabGenerationFiles.Controls.Add(this.txtBaseNamespace);
            this.tabGenerationFiles.Controls.Add(this.lblUtilitiesNamespace);
            this.tabGenerationFiles.Controls.Add(this.txtUtilitiesNamespace);
            this.tabGenerationFiles.Controls.Add(this.lblUtilitiesFolder);
            this.tabGenerationFiles.Controls.Add(this.txtUtilitiesFolder);
            this.tabGenerationFiles.Controls.Add(this.lblInterfaceDALNamespace);
            this.tabGenerationFiles.Controls.Add(this.txtInterfaceDALNamespace);
            this.tabGenerationFiles.Controls.Add(this.lblDALNamespace);
            this.tabGenerationFiles.Controls.Add(this.txtDALNamespace);
            this.tabGenerationFiles.Location = new System.Drawing.Point(4, 22);
            this.tabGenerationFiles.Name = "tabGenerationFiles";
            this.tabGenerationFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerationFiles.Size = new System.Drawing.Size(525, 329);
            this.tabGenerationFiles.TabIndex = 3;
            this.tabGenerationFiles.Text = "Files";
            this.tabGenerationFiles.UseVisualStyleBackColor = true;
            // 
            // chkSaveGenerationFiles
            // 
            this.chkSaveGenerationFiles.Checked = true;
            this.chkSaveGenerationFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveGenerationFiles.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SaveBeforeGenerate", true));
            this.chkSaveGenerationFiles.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaveGenerationFiles.Location = new System.Drawing.Point(15, 10);
            this.chkSaveGenerationFiles.Name = "chkSaveGenerationFiles";
            this.chkSaveGenerationFiles.Size = new System.Drawing.Size(225, 21);
            this.chkSaveGenerationFiles.TabIndex = 4;
            this.chkSaveGenerationFiles.Text = "Save project before generating";
            this.toolTip1.SetToolTip(this.chkSaveGenerationFiles, "If checked, projects are silently saved before code generation.");
            // 
            // lblBaseFilenameSuffix
            // 
            this.lblBaseFilenameSuffix.Location = new System.Drawing.Point(15, 50);
            this.lblBaseFilenameSuffix.Name = "lblBaseFilenameSuffix";
            this.lblBaseFilenameSuffix.Size = new System.Drawing.Size(150, 16);
            this.lblBaseFilenameSuffix.TabIndex = 38;
            this.lblBaseFilenameSuffix.Text = "Suffix for base files:";
            // 
            // txtBaseFilenameSuffix
            // 
            this.txtBaseFilenameSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "BaseFilenameSuffix", true));
            this.txtBaseFilenameSuffix.Location = new System.Drawing.Point(15, 66);
            this.txtBaseFilenameSuffix.Name = "txtBaseFilenameSuffix";
            this.txtBaseFilenameSuffix.Size = new System.Drawing.Size(164, 17);
            this.txtBaseFilenameSuffix.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtBaseFilenameSuffix,
                                     "If specified, base classes use \"<object><suffix>\" in file names instead of \"<object>Base\" file name." +
                                     "\r\nN.B. - For generated filename compatibility with previous versions, use \".Designer\" suffix.");
            // 
            // lblExtendedFilenameSuffix
            // 
            this.lblExtendedFilenameSuffix.Location = new System.Drawing.Point(15, 94);
            this.lblExtendedFilenameSuffix.Name = "lblExtendedFilenameSuffix";
            this.lblExtendedFilenameSuffix.Size = new System.Drawing.Size(164, 16);
            this.lblExtendedFilenameSuffix.TabIndex = 39;
            this.lblExtendedFilenameSuffix.Text = "Suffix for extended files:";
            // 
            // 
            // txtExtendedFilenameSuffix
            // 
            this.txtExtendedFilenameSuffix.AutoSize = true;
            this.txtExtendedFilenameSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "ExtendedFilenameSuffix", true));
            this.txtExtendedFilenameSuffix.Location = new System.Drawing.Point(15, 110);
            this.txtExtendedFilenameSuffix.Name = "txtExtendedFilenameSuffix";
            this.txtExtendedFilenameSuffix.Size = new System.Drawing.Size(164, 17);
            this.txtExtendedFilenameSuffix.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtExtendedFilenameSuffix,
                                     "If specified, extended classes use \"<object><suffix>\" in file names instead of \"<object>\" file name." +
                                     "\r\nN.B. - For generated filename compatibility with previous versions, use an empty suffix.");
            // 
            // lblClassCommentFilenameSuffix
            // 
            this.lblClassCommentFilenameSuffix.Location = new System.Drawing.Point(15, 138);
            this.lblClassCommentFilenameSuffix.Name = "lblClassCommentFilenameSuffix";
            this.lblClassCommentFilenameSuffix.Size = new System.Drawing.Size(164, 16);
            this.lblClassCommentFilenameSuffix.TabIndex = 32;
            this.lblClassCommentFilenameSuffix.Text = "Suffix for class comment files:";
            // 
            // 
            // txtClassCommentFilenameSuffix
            // 
            this.txtClassCommentFilenameSuffix.AutoSize = true;
            this.txtClassCommentFilenameSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "ClassCommentFilenameSuffix", true));
            this.txtClassCommentFilenameSuffix.Location = new System.Drawing.Point(15, 154);
            this.txtClassCommentFilenameSuffix.Name = "txtClassCommentFilenameSuffix";
            this.txtClassCommentFilenameSuffix.Size = new System.Drawing.Size(164, 17);
            this.txtClassCommentFilenameSuffix.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtClassCommentFilenameSuffix,
                                     "If specified, class comments are separated on its own file with file names \"<object><suffix>\". If blank, class comments are inserted on base class files.");
            // 
            // chkBackupOldSource
            // 
            this.chkBackupOldSource.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "BackupOldSource", true));
            this.chkBackupOldSource.Location = new System.Drawing.Point(15, 186);
            this.chkBackupOldSource.Name = "chkBackupOldSource";
            this.chkBackupOldSource.Size = new System.Drawing.Size(216, 17);
            this.chkBackupOldSource.TabIndex = 8;
            this.chkBackupOldSource.Text = "Backup old source files";
            this.toolTip1.SetToolTip(this.chkBackupOldSource, "If checked, replaced files are backed up as \"<filename>.old\"");
            // 
            // chkSeparateBaseClasses
            // 
            this.chkSeparateBaseClasses.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SeparateBaseClasses", true));
            this.chkSeparateBaseClasses.Location = new System.Drawing.Point(15, 210);
            this.chkSeparateBaseClasses.Name = "chkSeparateBaseClasses";
            this.chkSeparateBaseClasses.Size = new System.Drawing.Size(216, 17);
            this.chkSeparateBaseClasses.TabIndex = 9;
            this.chkSeparateBaseClasses.Text = "Separate base classes in a folder";
            this.toolTip1.SetToolTip(this.chkSeparateBaseClasses, "If checked, generated base classes go to \"<output path>\\Base\"");
            // 
            // chkSeparateNamespaces
            // 
            this.chkSeparateNamespaces.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SeparateNamespaces", true));
            this.chkSeparateNamespaces.Location = new System.Drawing.Point(15, 234);
            this.chkSeparateNamespaces.Name = "chkSeparateNamespaces";
            this.chkSeparateNamespaces.Size = new System.Drawing.Size(216, 17);
            this.chkSeparateNamespaces.TabIndex = 10;
            this.chkSeparateNamespaces.Text = "Separate Namespaces in folders";
            this.toolTip1.SetToolTip(this.chkSeparateNamespaces, "If checked, generated codes is distributed in folders according to their namespaces.");
            // 
            // chkSeparateClassComment
            // 
            this.chkSeparateClassComment.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SeparateClassComment", true));
            this.chkSeparateClassComment.Location = new System.Drawing.Point(15, 258);
            this.chkSeparateClassComment.Name = "chkSeparateClassComment";
            this.chkSeparateClassComment.Size = new System.Drawing.Size(216, 17);
            this.chkSeparateClassComment.TabIndex = 11;
            this.chkSeparateClassComment.Text = "Separate class comments in a folder";
            this.toolTip1.SetToolTip(this.chkSeparateClassComment, "If checked, generated class comments files go to \"<output path>\\Comment\"");
            // 
            // lblBaseNamespace
            // 
            this.lblBaseNamespace.Location = new System.Drawing.Point(255, 50);
            this.lblBaseNamespace.Name = "lblBaseNamespace";
            this.lblBaseNamespace.Size = new System.Drawing.Size(150, 16);
            this.lblBaseNamespace.TabIndex = 31;
            this.lblBaseNamespace.Text = "Base namespace:";
            // 
            // txtBaseNamespace
            // 
            this.txtBaseNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "BaseNamespace", true));
            this.txtBaseNamespace.Location = new System.Drawing.Point(255, 66);
            this.txtBaseNamespace.Name = "txtBaseNamespace";
            this.txtBaseNamespace.Size = new System.Drawing.Size(177, 20);
            this.txtBaseNamespace.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtBaseNamespace, "Specify the base namespace for the project.\r\n" +
                                                            "When separating namespaces in folders, do not create a folder for this namespace.");
            // 
            // lblUtilitiesNamespace
            // 
            this.lblUtilitiesNamespace.Location = new System.Drawing.Point(255, 94);
            this.lblUtilitiesNamespace.Name = "lblUtilitiesNamespace";
            this.lblUtilitiesNamespace.Size = new System.Drawing.Size(150, 16);
            this.lblUtilitiesNamespace.TabIndex = 31;
            this.lblUtilitiesNamespace.Text = "Utility classes namespace:";
            // 
            // txtUtilitiesNamespace
            // 
            this.txtUtilitiesNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "UtilitiesNamespace", true));
            this.txtUtilitiesNamespace.Location = new System.Drawing.Point(255, 110);
            this.txtUtilitiesNamespace.Name = "txtUtilitiesNamespace";
            this.txtUtilitiesNamespace.Size = new System.Drawing.Size(177, 20);
            this.txtUtilitiesNamespace.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtUtilitiesNamespace, "Specify the namespace where the <Database> and <DataPortalHookArgs> files will be created.");
            // 
            // lblUtilitiesFolder
            // 
            this.lblUtilitiesFolder.Location = new System.Drawing.Point(255, 138);
            this.lblUtilitiesFolder.Name = "lblUtilitiesFolder";
            this.lblUtilitiesFolder.Size = new System.Drawing.Size(150, 16);
            this.lblUtilitiesFolder.TabIndex = 35;
            this.lblUtilitiesFolder.Text = "Utility classes folder:";
            // 
            // txtUtilitiesFolder
            // 
            this.txtUtilitiesFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "UtilitiesFolder", true));
            this.txtUtilitiesFolder.Location = new System.Drawing.Point(255, 154);
            this.txtUtilitiesFolder.Name = "txtUtilitiesFolder";
            this.txtUtilitiesFolder.Size = new System.Drawing.Size(177, 20);
            this.txtUtilitiesFolder.TabIndex = 13;
            this.toolTip1.SetToolTip(this.txtUtilitiesFolder, "Specify the folder where the <Database> and <DataPortalHookArgs> files will be created." +
                "\r\nThis is relative to the project\'s output folder and is used only when namespaces aren't separated in folders.");
            // 
            // lblInterfaceDALNamespace
            // 
            this.lblInterfaceDALNamespace.Location = new System.Drawing.Point(255, 182);
            this.lblInterfaceDALNamespace.Name = "lblInterfaceDALNamespace";
            this.lblInterfaceDALNamespace.Size = new System.Drawing.Size(150, 16);
            this.lblInterfaceDALNamespace.TabIndex = 31;
            this.lblInterfaceDALNamespace.Text = "Interface DAL namespace:";
            // 
            // txtInterfaceDALNamespace
            // 
            this.txtInterfaceDALNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "InterfaceDALNamespace", true));
            this.txtInterfaceDALNamespace.Location = new System.Drawing.Point(255, 198);
            this.txtInterfaceDALNamespace.Name = "txtInterfaceDALNamespace";
            this.txtInterfaceDALNamespace.Size = new System.Drawing.Size(177, 20);
            this.txtInterfaceDALNamespace.TabIndex = 14;
            this.toolTip1.SetToolTip(this.txtInterfaceDALNamespace, "Specify the namespace where the DAL interface will be created." +
                "\r\nThis will be also used as a folder path relative to the project\'s output folder.");
            // 
            // lblDALNamespace
            // 
            this.lblDALNamespace.Location = new System.Drawing.Point(255, 226);
            this.lblDALNamespace.Name = "lblDALNamespace";
            this.lblDALNamespace.Size = new System.Drawing.Size(150, 16);
            this.lblDALNamespace.TabIndex = 31;
            this.lblDALNamespace.Text = "DAL namespace:";
            // 
            // txtDALNamespace
            // 
            this.txtDALNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "DALNamespace", true));
            this.txtDALNamespace.Location = new System.Drawing.Point(255, 242);
            this.txtDALNamespace.Name = "txtDALNamespace";
            this.txtDALNamespace.Size = new System.Drawing.Size(177, 20);
            this.txtDALNamespace.TabIndex = 15;
            this.toolTip1.SetToolTip(this.txtDALNamespace, "Specify the namespace where the DAL will be created." +
                "\r\nThis will be also used as a folder path relative to the project\'s output folder.");
            // 
            // tabGenerationMisc
            // 
            this.tabGenerationMisc.Controls.Add(this.chkSaveGenerationMisc);
            this.tabGenerationMisc.Controls.Add(this.lblGenerateAuthorization);
            this.tabGenerationMisc.Controls.Add(this.cboGenerateAuthorization);
            this.tabGenerationMisc.Controls.Add(this.lblHeaderVerbosity);
            this.tabGenerationMisc.Controls.Add(this.cboHeaderVerbosity);
            this.tabGenerationMisc.Controls.Add(this.chkGenerateStoredProcedures);
            this.tabGenerationMisc.Controls.Add(this.chkSpOneFile);
            this.tabGenerationMisc.Controls.Add(this.chkGenerateInlineQueries);
            this.tabGenerationMisc.Controls.Add(this.chkGenerateQueriesWithSchema);
            this.tabGenerationMisc.Controls.Add(this.chkGenerateDatabaseClass);
            this.tabGenerationMisc.Controls.Add(this.chkUseBypassPropertyChecks);
            this.tabGenerationMisc.Controls.Add(this.chkNullableSupport);
            this.tabGenerationMisc.Controls.Add(this.chkUsePublicPropertyInfo);
            this.tabGenerationMisc.Controls.Add(this.chkForceReadOnlyProperties);
            this.tabGenerationMisc.Controls.Add(this.groupBoxLegacy);
            this.tabGenerationMisc.Location = new System.Drawing.Point(4, 22);
            this.tabGenerationMisc.Name = "tabGenerationMisc";
            this.tabGenerationMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerationMisc.Size = new System.Drawing.Size(525, 329);
            this.tabGenerationMisc.TabIndex = 3;
            this.tabGenerationMisc.Text = "Misc.";
            this.tabGenerationMisc.UseVisualStyleBackColor = true;
            // 
            // chkSaveGenerationMisc
            // 
            this.chkSaveGenerationMisc.Checked = true;
            this.chkSaveGenerationMisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveGenerationMisc.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SaveBeforeGenerate", true));
            this.chkSaveGenerationMisc.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaveGenerationMisc.Location = new System.Drawing.Point(15, 10);
            this.chkSaveGenerationMisc.Name = "chkSaveGenerationMisc";
            this.chkSaveGenerationMisc.Size = new System.Drawing.Size(225, 21);
            this.chkSaveGenerationMisc.TabIndex = 4;
            this.chkSaveGenerationMisc.Text = "Save project before generating";
            this.toolTip1.SetToolTip(this.chkSaveGenerationMisc, "If checked, projects are silently saved before code generation.");
            // 
            // lblGenerateAuthorization
            // 
            this.lblGenerateAuthorization.Location = new System.Drawing.Point(15, 50);
            this.lblGenerateAuthorization.Name = "lblGenerateAuthorization";
            this.lblGenerateAuthorization.Size = new System.Drawing.Size(101, 16);
            this.lblGenerateAuthorization.TabIndex = 39;
            this.lblGenerateAuthorization.Text = "Authorization code:";
            // 
            // cboGenerateAuthorization
            // 
            this.cboGenerateAuthorization.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "GenerateAuthorization", true));
            this.cboGenerateAuthorization.Location = new System.Drawing.Point(116, 47);
            this.cboGenerateAuthorization.Name = "cboGenerateAuthorization";
            this.cboGenerateAuthorization.Size = new System.Drawing.Size(118, 21);
            this.cboGenerateAuthorization.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cboGenerateAuthorization,
                                     "CSLA40 - Authorization level to generate. Use \"None\" for no implementation at all.\r\n" +
                                     "In Csla Object Info panel and in all value properties panels,\r\n" +
                                     "the authz options will be shown or hidden according to this setting.\r\n" +
                                     "\r\nN.B. - \"Custom\" shows all authz options because it generates\r\n" +
                                     "Authorization code only for objects with at least one authz option filled.\r\n" +
                                     "Authorization code is generated as follows:\r\n" +
                                     "-  \"Can-\" methods are generated on the \".Designer\" file.\r\n" +
                                     "- \"AddObjectAuthorizationRules()\" method is generated on the extended file.\r\n" +
                                     "- until Rules 4 are implemented \"AddBusinessRules()\" method isn't generated.\r\n" +
                                     "  So it's up to you to write this method on the extended file.");
            // 
            // lblHeaderVerbosity
            // 
            this.lblHeaderVerbosity.Location = new System.Drawing.Point(15, 78);
            this.lblHeaderVerbosity.Name = "lblHeaderVerbosity";
            this.lblHeaderVerbosity.Size = new System.Drawing.Size(101, 16);
            this.lblHeaderVerbosity.TabIndex = 39;
            this.lblHeaderVerbosity.Text = "Header verbosity:";
            // 
            // cboHeaderVerbosity
            // 
            this.cboHeaderVerbosity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "HeaderVerbosity", true));
            this.cboHeaderVerbosity.Location = new System.Drawing.Point(116, 75);
            this.cboHeaderVerbosity.Name = "cboHeaderVerbosity";
            this.cboHeaderVerbosity.Size = new System.Drawing.Size(118, 21);
            this.cboHeaderVerbosity.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cboHeaderVerbosity, "Header verbosity level.");
            //
            // chkGenerateStoredProcedures
            // 
            this.chkGenerateStoredProcedures.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateSprocs", true));
            this.chkGenerateStoredProcedures.Location = new System.Drawing.Point(15, 106);
            this.chkGenerateStoredProcedures.Name = "chkGenerateStoredProcedures";
            this.chkGenerateStoredProcedures.Size = new System.Drawing.Size(216, 17);
            this.chkGenerateStoredProcedures.TabIndex = 7;
            this.chkGenerateStoredProcedures.Text = "Generate Stored Procedures";
            this.toolTip1.SetToolTip(this.chkGenerateStoredProcedures,
                                     "If checked, generates stored procedures for the objects that can generate them.");
            // 
            // chkSpOneFile
            // 
            this.chkSpOneFile.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "OneSpFilePerObject", true));
            this.chkSpOneFile.Location = new System.Drawing.Point(15, 134);
            this.chkSpOneFile.Name = "chkSpOneFile";
            this.chkSpOneFile.Size = new System.Drawing.Size(216, 17);
            this.chkSpOneFile.TabIndex = 8;
            this.chkSpOneFile.Text = "Generate only one SP file per object";
            this.toolTip1.SetToolTip(this.chkSpOneFile,
                                     "If checked, creates only one file that contains all the\r\n" +
                                     "generated stored procedures for the business object.");
            // 
            // chkGenerateInlineQueries
            // 
            this.chkGenerateInlineQueries.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateInlineQueries", true));
            this.chkGenerateInlineQueries.Location = new System.Drawing.Point(15, 162);
            this.chkGenerateInlineQueries.Name = "chkGenerateInlineQueries";
            this.chkGenerateInlineQueries.Size = new System.Drawing.Size(216, 17);
            this.chkGenerateInlineQueries.TabIndex = 9;
            this.chkGenerateInlineQueries.Text = "Generate Inline SQL Queries";
            this.toolTip1.SetToolTip(this.chkGenerateInlineQueries,
                                     "If checked, generates inline SQL queries\r\n" +
                                     "making stored procedures useless.");
            // 
            // chkGenerateQueriesWithSchema
            // 
            this.chkGenerateQueriesWithSchema.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateQueriesWithSchema", true));
            this.chkGenerateQueriesWithSchema.Location = new System.Drawing.Point(15, 190);
            this.chkGenerateQueriesWithSchema.Name = "chkGenerateQueriesWithSchema";
            this.chkGenerateQueriesWithSchema.Size = new System.Drawing.Size(216, 17);
            this.chkGenerateQueriesWithSchema.TabIndex = 10;
            this.chkGenerateQueriesWithSchema.Text = "Use Schema on queries";
            this.toolTip1.SetToolTip(this.chkGenerateQueriesWithSchema,
                                     "If checked, generates queries with Schema.");
            // 
            // chkGenerateDatabaseClass
            // 
            this.chkGenerateDatabaseClass.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateDatabaseClass", true));
            this.chkGenerateDatabaseClass.Location = new System.Drawing.Point(15, 218);
            this.chkGenerateDatabaseClass.Name = "chkGenerateDatabaseClass";
            this.chkGenerateDatabaseClass.Size = new System.Drawing.Size(216, 17);
            this.chkGenerateDatabaseClass.TabIndex = 10;
            this.chkGenerateDatabaseClass.Text = "Generate Database class";
            this.toolTip1.SetToolTip(this.chkGenerateDatabaseClass,
                                     "If checked, generates a \"Database.cs\" or \"Database.vb\" file.");
            //
            // chkUseBypassPropertyChecks
            // 
            this.chkUseBypassPropertyChecks.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "UseBypassPropertyChecks", true));
            this.chkUseBypassPropertyChecks.Location = new System.Drawing.Point(255, 50);
            this.chkUseBypassPropertyChecks.Name = "chkUseBypassPropertyChecks";
            this.chkUseBypassPropertyChecks.Size = new System.Drawing.Size(216, 17);
            this.chkUseBypassPropertyChecks.TabIndex = 12;
            this.chkUseBypassPropertyChecks.Text = "Generate BypassPropertyChecks";
            this.toolTip1.SetToolTip(this.chkUseBypassPropertyChecks,
                                     "CTP - Not implemented.\r\n\r\n" +
                                     "If checked, improves code readability by using BypassPropertyChecks blocks\r\n" +
                                     "and assign values using .NET properties.\r\n" +
                                     "Otherwise uses LoadProperty() to assign values.");            // 
            // chkNullableSupport
            // 
            this.chkNullableSupport.AutoSize = true;
            this.chkNullableSupport.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "NullableSupport", true));
            this.chkNullableSupport.Location = new System.Drawing.Point(255, 78);
            this.chkNullableSupport.Name = "chkNullableSupport";
            this.chkNullableSupport.Size = new System.Drawing.Size(157, 17);
            this.chkNullableSupport.TabIndex = 11;
            this.chkNullableSupport.Text = "Enable Nullable<T> support";
            this.chkNullableSupport.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkNullableSupport, "If checked, enables Nullable<T> support.");
            //
            // chkUsePublicPropertyInfo
            // 
            this.chkUsePublicPropertyInfo.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "UsePublicPropertyInfo", true));
            this.chkUsePublicPropertyInfo.Location = new System.Drawing.Point(255, 106);
            this.chkUsePublicPropertyInfo.Name = "chkUsePublicPropertyInfo";
            this.chkUsePublicPropertyInfo.Size = new System.Drawing.Size(260, 17);
            this.chkUsePublicPropertyInfo.TabIndex = 12;
            this.chkUsePublicPropertyInfo.Text = "Use public PropertyInfo";
            this.toolTip1.SetToolTip(this.chkUsePublicPropertyInfo,
                                     "CTP - Not implemented.");
            //
            // chkForceReadOnlyProperties
            // 
            this.chkForceReadOnlyProperties.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "ForceReadOnlyProperties", true));
            this.chkForceReadOnlyProperties.Location = new System.Drawing.Point(255, 134);
            this.chkForceReadOnlyProperties.Name = "chkForceReadOnlyProperties";
            this.chkForceReadOnlyProperties.Size = new System.Drawing.Size(216, 17);
            this.chkForceReadOnlyProperties.TabIndex = 13;
            this.chkForceReadOnlyProperties.Text = "Force ReadOnly Properties";
            this.toolTip1.SetToolTip(this.chkForceReadOnlyProperties,
                                     "If checked, all ReadOnlyObject's properties are ReadOnly.\r\n" +
                                     "Otherwise allows all kinds of accessibility for ReadOnlyObject's properties.\r\n\r\n" +
                                     "Note - ReadOnlyObject's managed and unmanaged properties are always ReadOnly properties.");
            // 
            // groupBoxLegacy
            // 
            this.groupBoxLegacy.Controls.Add(this.chkActiveObjects);
            this.groupBoxLegacy.Location = new System.Drawing.Point(255, 161);
            this.groupBoxLegacy.Name = "groupBoxLegacy";
            this.groupBoxLegacy.Size = new System.Drawing.Size(240, 76);
            this.groupBoxLegacy.TabIndex = 35;
            this.groupBoxLegacy.TabStop = false;
            this.groupBoxLegacy.Text = "Legacy Support";
            //
            // chkActiveObjects
            // 
            this.chkActiveObjects.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "ActiveObjects", true));
            this.chkActiveObjects.Location = new System.Drawing.Point(12, 18);
            this.chkActiveObjects.Name = "chkActiveObjects";
            this.chkActiveObjects.Size = new System.Drawing.Size(216, 17);
            this.chkActiveObjects.TabIndex = 14;
            this.chkActiveObjects.Text = "Use Active Objects";
            this.toolTip1.SetToolTip(this.chkActiveObjects,
                                     "If checked, outputs ActiveObjects code instead of plain CSLA.\r\n" +
                                     "If unchecked hides \"11. Active Objects\" properties in Csla Object Info panel.\r\n" +
                                     "\r\nN.B. - This option is disabled for target CSLA40DAL.");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 48);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.selectNoneToolStripMenuItem.Text = "Select None";
            // 
            // projectParametersBindingSource
            // 
            this.projectParametersBindingSource.DataSource = typeof(CslaGenerator.Metadata.ProjectParameters);
            this.projectParametersBindingSource.CurrentItemChanged += new System.EventHandler(this.GenerationParametersBindingSourceCurrentItemChanged);
            // 
            // generationParametersBindingSource
            // 
            this.generationParametersBindingSource.DataSource = typeof(CslaGenerator.Metadata.GenerationParameters);
            this.generationParametersBindingSource.CurrentItemChanged += new System.EventHandler(this.GenerationParametersBindingSourceCurrentItemChanged);
            // 
            // ProjectProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 425);
            this.Controls.Add(this.cmdApply);
            this.Controls.Add(this.cmdUndo);
            this.Controls.Add(this.cmdGetDefault);
            this.Controls.Add(this.cmdSetDefault);
            this.Controls.Add(this.CmdResetToFactory);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.tabControlMain);
            this.Name = "ProjectProperties";
            this.TabText = "Project Properties";
            this.Text = "Project Properties";
            this.tabControlMain.ResumeLayout(false);
            this.tabCreation.ResumeLayout(false);
            this.tabControlCreation.ResumeLayout(false);
            this.tabGeneration.ResumeLayout(false);
            this.tabControlGeneration.ResumeLayout(false);
            this.tabDefaultsGeneral.ResumeLayout(false);
            this.tabDefaultsGeneral.PerformLayout();
            this.tabDefaultsDatabase.ResumeLayout(false);
            this.tabDefaultsDatabase.PerformLayout();
            this.groupBoxObjectRelationsBuilder.ResumeLayout(false);
            this.groupBoxObjectRelationsBuilder.PerformLayout();
            this.tabStoredProcs.ResumeLayout(false);
            this.tabStoredProcs.PerformLayout();
            this.groupBoxPrefixSuffix.ResumeLayout(false);
            this.groupBoxPrefixSuffix.PerformLayout();
            this.tabAdvanced.ResumeLayout(false);
            this.groupBoxOtherParameters.ResumeLayout(false);
            this.groupBoxOtherParameters.PerformLayout();
            this.groupBoxSimpleAuditing.ResumeLayout(false);
            this.groupBoxSimpleAuditing.PerformLayout();
            this.groupBoxPKDefaultValues.ResumeLayout(false);
            this.groupBoxPKDefaultValues.PerformLayout();
            this.groupBoxReadOnlyObjects.ResumeLayout(false);
            this.groupBoxReadOnlyObjects.PerformLayout();
            this.tabGenerationTarget.ResumeLayout(false);
            this.tabGenerationTarget.PerformLayout();
            this.tabGenerationFiles.ResumeLayout(false);
            this.tabGenerationFiles.PerformLayout();
            this.tabGenerationMisc.ResumeLayout(false);
            this.tabGenerationMisc.PerformLayout();
            this.groupBoxUIEnvironment.ResumeLayout(false);
            this.groupBoxUIEnvironment.PerformLayout();
            this.groupBoxDataAccessLayer.ResumeLayout(false);
            this.groupBoxDataAccessLayer.PerformLayout();
            this.groupBoxServerInvocation.ResumeLayout(false);
            this.groupBoxServerInvocation.PerformLayout();
            this.groupBoxLegacy.ResumeLayout(false);
            this.groupBoxLegacy.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectParametersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generationParametersBindingSource)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Button cmdExport;
        internal System.Windows.Forms.Button cmdGetDefault;
        internal System.Windows.Forms.Button cmdSetDefault;
        internal System.Windows.Forms.Button CmdResetToFactory;
        private System.Windows.Forms.Button cmdUndo;
        internal System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabControl tabControlCreation;
        private System.Windows.Forms.TabControl tabControlGeneration;
        private System.Windows.Forms.TabPage tabCreation;
        private System.Windows.Forms.TabPage tabGeneration;
        private System.Windows.Forms.TabPage tabDefaultsGeneral;
        private System.Windows.Forms.Label lblAlertNewDefaultsGeneral;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.CheckBox chkSmartDateDefault;
        private System.Windows.Forms.CheckBox chkDatesDefaultStringWithTypeConversion;
        private System.Windows.Forms.CheckBox chkAutoCriteria;
        private System.Windows.Forms.CheckBox chkAutoTimestampCriteria;
        private System.Windows.Forms.GroupBox groupBoxReadOnlyObjects;
        private System.Windows.Forms.CheckBox chkReadOnlyObjectsCopyAuditing;
        private System.Windows.Forms.CheckBox chkReadOnlyObjectsCopyTimestamp;
        private System.Windows.Forms.Label lblCreateReadOnlyObjectsPropertyMode;
        private System.Windows.Forms.ComboBox cboCreateReadOnlyObjectsPropertyMode;
        private System.Windows.Forms.Label lblCreateTimestampPropertyMode;
        private System.Windows.Forms.ComboBox cboCreateTimestampPropertyMode;
        private System.Windows.Forms.TabPage tabDefaultsDatabase;
        private System.Windows.Forms.Label lblAlertNewDefaultsDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.Label lblPersistenceType;
        private System.Windows.Forms.ComboBox cboPersistenceType;
        private System.Windows.Forms.Label lblDatabaseContextObject;
        private System.Windows.Forms.TextBox txtDatabaseContextObject;
        private System.Windows.Forms.GroupBox groupBoxObjectRelationsBuilder;
        private System.Windows.Forms.Label lblChildPropertySuffix;
        private System.Windows.Forms.TextBox txtChildPropertySuffix;
        private System.Windows.Forms.Label lblCollectionSuffix;
        private System.Windows.Forms.TextBox txtCollectionSuffix;
        private System.Windows.Forms.Label lblSingleSPSuffix;
        private System.Windows.Forms.TextBox txtSingleSPSuffix;
        private System.Windows.Forms.CheckBox chkItemsUseSingleSP;
        private System.Windows.Forms.TabPage tabStoredProcs;
        private System.Windows.Forms.GroupBox groupBoxPrefixSuffix;
        private System.Windows.Forms.Label lblGeneralSpPrefix;
        private System.Windows.Forms.TextBox txtGeneralSpPrefix;
        private System.Windows.Forms.Label lblSelectPrefix;
        private System.Windows.Forms.TextBox txtSelectPrefix;
        private System.Windows.Forms.Label lblInsertPrefix;
        private System.Windows.Forms.TextBox txtInsertPrefix;
        private System.Windows.Forms.Label lblUpdatePrefix;
        private System.Windows.Forms.TextBox txtUpdatePrefix;
        private System.Windows.Forms.Label lblDeletePrefix;
        private System.Windows.Forms.TextBox txtDeletePrefix;
        private System.Windows.Forms.Label lblGeneralSpSuffix;
        private System.Windows.Forms.TextBox txtGeneralSpSuffix;
        private System.Windows.Forms.Label lblSelectSuffix;
        private System.Windows.Forms.TextBox txtSelectSuffix;
        private System.Windows.Forms.Label lblInsertSuffix;
        private System.Windows.Forms.TextBox txtInsertSuffix;
        private System.Windows.Forms.Label lblUpdateSuffix;
        private System.Windows.Forms.TextBox txtUpdateSuffix;
        private System.Windows.Forms.Label lblDeleteSuffix;
        private System.Windows.Forms.TextBox txtDeleteSuffix;
        private System.Windows.Forms.Label lblBoolSoftDelete;
        private System.Windows.Forms.TextBox txtBoolSoftDelete;
        private System.Windows.Forms.Label lblIntSoftDelete;
        private System.Windows.Forms.TextBox txtIntSoftDelete;
        private System.Windows.Forms.CheckBox chkIgnoreFilterWhenSoftDeleteIsParam;
        private System.Windows.Forms.CheckBox chkRemoveChildBeforeParent;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.GroupBox groupBoxPKDefaultValues;
        private System.Windows.Forms.Label lblIDGuidDefaultValue;
        private System.Windows.Forms.TextBox txtIDGuidDefaultValue;
        private System.Windows.Forms.Label lblIDInt16DefaultValue;
        private System.Windows.Forms.TextBox txtIDInt16DefaultValue;
        private System.Windows.Forms.Label lblIDInt32DefaultValue;
        private System.Windows.Forms.TextBox txtIDInt32DefaultValue;
        private System.Windows.Forms.Label lblIDInt64DefaultValue;
        private System.Windows.Forms.TextBox txtIDInt64DefaultValue;
        private System.Windows.Forms.GroupBox groupBoxOtherParameters;
        private System.Windows.Forms.Label lblFieldNamePrefix;
        private System.Windows.Forms.TextBox txtFieldNamePrefix;
        private System.Windows.Forms.Label lblDelegateNamePrefix;
        private System.Windows.Forms.TextBox txtDelegateNamePrefix;
        private System.Windows.Forms.GroupBox groupBoxSimpleAuditing;
        private System.Windows.Forms.Label lblCreationDateColumn;
        private System.Windows.Forms.TextBox txtCreationDateColumn;
        private System.Windows.Forms.Label lblCreationUserColumn;
        private System.Windows.Forms.TextBox txtCreationUserColumn;
        private System.Windows.Forms.Label lblChangedDateColumn;
        private System.Windows.Forms.TextBox txtChangedDateColumn;
        private System.Windows.Forms.Label lblChangedUserColumn;
        private System.Windows.Forms.TextBox txtChangedUserColumn;
        private System.Windows.Forms.CheckBox chkLogDateAndTime;
        private System.Windows.Forms.Label lblGetUserMethod;
        private System.Windows.Forms.TextBox txtGetUserMethod;
        private System.Windows.Forms.TabPage tabGenerationTarget;
        private System.Windows.Forms.TabPage tabGenerationMisc;
        private System.Windows.Forms.TabPage tabGenerationFiles;
        private System.Windows.Forms.CheckBox chkSaveGenerationTarget;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cboTarget;
        private System.Windows.Forms.Label lblOutputLanguage;
        private System.Windows.Forms.ComboBox cboOutputLanguage;
        private System.Windows.Forms.GroupBox groupBoxUIEnvironment;
        private System.Windows.Forms.CheckBox chkWinForms;
        private System.Windows.Forms.CheckBox chkWPF;
        private System.Windows.Forms.CheckBox chkSilverlight;
        private System.Windows.Forms.CheckBox chkSilverlightUseServices;
        private System.Windows.Forms.GroupBox groupBoxDataAccessLayer;
        private System.Windows.Forms.Label lblTargetDAL;
        private System.Windows.Forms.ComboBox cboTargetDAL;
        private System.Windows.Forms.CheckBox chkGenerateDAL;
        private System.Windows.Forms.GroupBox groupBoxServerInvocation;
        private System.Windows.Forms.CheckBox chkSynchronous;
        private System.Windows.Forms.CheckBox chkAsynchronous;
        private System.Windows.Forms.CheckBox chkSaveGenerationFiles;
        private System.Windows.Forms.Label lblBaseFilenameSuffix;
        private System.Windows.Forms.TextBox txtBaseFilenameSuffix;
        private System.Windows.Forms.Label lblExtendedFilenameSuffix;
        private System.Windows.Forms.TextBox txtExtendedFilenameSuffix;
        private System.Windows.Forms.Label lblClassCommentFilenameSuffix;
        private System.Windows.Forms.TextBox txtClassCommentFilenameSuffix;
        private System.Windows.Forms.CheckBox chkBackupOldSource;
        private System.Windows.Forms.CheckBox chkSeparateBaseClasses;
        private System.Windows.Forms.CheckBox chkSeparateNamespaces;
        private System.Windows.Forms.CheckBox chkSeparateClassComment;
        private System.Windows.Forms.Label lblBaseNamespace;
        private System.Windows.Forms.TextBox txtBaseNamespace;
        private System.Windows.Forms.Label lblUtilitiesNamespace;
        private System.Windows.Forms.TextBox txtUtilitiesNamespace;
        private System.Windows.Forms.Label lblUtilitiesFolder;
        private System.Windows.Forms.TextBox txtUtilitiesFolder;
        private System.Windows.Forms.Label lblInterfaceDALNamespace;
        private System.Windows.Forms.TextBox txtInterfaceDALNamespace;
        private System.Windows.Forms.Label lblDALNamespace;
        private System.Windows.Forms.TextBox txtDALNamespace;
        private System.Windows.Forms.CheckBox chkSaveGenerationMisc;
        private System.Windows.Forms.Label lblGenerateAuthorization;
        private System.Windows.Forms.ComboBox cboGenerateAuthorization;
        private System.Windows.Forms.Label lblHeaderVerbosity;
        private System.Windows.Forms.ComboBox cboHeaderVerbosity;
        private System.Windows.Forms.CheckBox chkGenerateStoredProcedures;
        private System.Windows.Forms.CheckBox chkSpOneFile;
        private System.Windows.Forms.CheckBox chkGenerateInlineQueries;
        private System.Windows.Forms.CheckBox chkGenerateQueriesWithSchema;
        private System.Windows.Forms.CheckBox chkGenerateDatabaseClass;
        private System.Windows.Forms.CheckBox chkUseBypassPropertyChecks;
        private System.Windows.Forms.CheckBox chkNullableSupport;
        private System.Windows.Forms.CheckBox chkUsePublicPropertyInfo;
        private System.Windows.Forms.CheckBox chkForceReadOnlyProperties;
        private System.Windows.Forms.GroupBox groupBoxLegacy;
        private System.Windows.Forms.CheckBox chkActiveObjects;
        private System.Windows.Forms.BindingSource generationParametersBindingSource;
        private System.Windows.Forms.BindingSource projectParametersBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdLoad;
    }
}
