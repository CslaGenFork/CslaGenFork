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
            this.cmdUndo = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.tabGeneration = new System.Windows.Forms.TabPage();
            this.chkSaveGenerationGeneral = new System.Windows.Forms.CheckBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.cboTarget = new System.Windows.Forms.ComboBox();
            this.lblOutputLanguage = new System.Windows.Forms.Label();
            this.cboOutputLanguage = new System.Windows.Forms.ComboBox();
            this.lblUIEnvironment = new System.Windows.Forms.Label();
            this.cboUIEnvironment = new System.Windows.Forms.ComboBox();
            this.lblGenerateAuthorization = new System.Windows.Forms.Label();
            this.cboGenerateAuthorization = new System.Windows.Forms.ComboBox();
            this.lblHeaderVerbosity = new System.Windows.Forms.Label();
            this.cboHeaderVerbosity = new System.Windows.Forms.ComboBox();
            // this.lblPropertyMode = new System.Windows.Forms.Label();
            // this.cboPropertyMode = new System.Windows.Forms.ComboBox();
            this.chkNullableSupport = new System.Windows.Forms.CheckBox();
            this.chkUseChildDataPortal = new System.Windows.Forms.CheckBox();
            this.chkActiveObjects = new System.Windows.Forms.CheckBox();
            this.chkUseBypassPropertyChecks = new System.Windows.Forms.CheckBox();
            this.chkUseSingleCriteria = new System.Windows.Forms.CheckBox();
            this.chkForceReadOnlyProperties = new System.Windows.Forms.CheckBox();
            this.chkSaveGenerationFiles = new System.Windows.Forms.CheckBox();
            this.tabGenerationFiles = new System.Windows.Forms.TabPage();
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
            this.lblUtilitiesNamespace = new System.Windows.Forms.Label();
            this.txtUtilitiesNamespace = new System.Windows.Forms.TextBox();
            this.lblUtilitiesFolder = new System.Windows.Forms.Label();
            this.txtUtilitiesFolder = new System.Windows.Forms.TextBox();
            this.chkGenerateStoredProcedures = new System.Windows.Forms.CheckBox();
            this.chkSpOneFile = new System.Windows.Forms.CheckBox();
            this.chkOnlyNeededSprocs = new System.Windows.Forms.CheckBox();
            this.chkGenerateDatabaseClass = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdLoad = new System.Windows.Forms.OpenFileDialog();
            this.projectParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.generationParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabDefaultsGeneral.SuspendLayout();
            this.tabDefaultsDatabase.SuspendLayout();
            this.tabStoredProcs.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.tabGeneration.SuspendLayout();
            this.tabGenerationFiles.SuspendLayout();
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
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
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
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
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
            this.cmdGetDefault.Click += new System.EventHandler(this.cmdGetDefault_Click);
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
            this.cmdSetDefault.Click += new System.EventHandler(this.cmdSetDefault_Click);
            // 
            // cmdUndo
            // 
            this.cmdUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUndo.Location = new System.Drawing.Point(391, 396);
            this.cmdUndo.Name = "cmdUndo";
            this.cmdUndo.Size = new System.Drawing.Size(72, 24);
            this.cmdUndo.TabIndex = 21;
            this.cmdUndo.Text = "&Undo";
            this.cmdUndo.Click += new System.EventHandler(this.cmdUndo_Click);
            // 
            // cmdApply
            // 
            this.cmdApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdApply.Location = new System.Drawing.Point(469, 396);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(72, 24);
            this.cmdApply.TabIndex = 22;
            this.cmdApply.Text = "&Apply";
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDefaultsGeneral);
            this.tabControl1.Controls.Add(this.tabDefaultsDatabase);
            this.tabControl1.Controls.Add(this.tabStoredProcs);
            this.tabControl1.Controls.Add(this.tabAdvanced);
            this.tabControl1.Controls.Add(this.tabGeneration);
            this.tabControl1.Controls.Add(this.tabGenerationFiles);
            this.tabControl1.Location = new System.Drawing.Point(12, 16);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 378);
            this.tabControl1.TabIndex = 3;
            // 
            // tabDefaultsGeneral
            // 
            this.tabDefaultsGeneral.Controls.Add(this.lblAlertNewDefaultsGeneral);
            this.tabDefaultsGeneral.Controls.Add(this.lblNamespace);
            this.tabDefaultsGeneral.Controls.Add(this.txtNamespace);
            this.tabDefaultsGeneral.Controls.Add(this.lblFolder);
            this.tabDefaultsGeneral.Controls.Add(this.txtFolder);
            this.tabDefaultsGeneral.Controls.Add(this.chkSmartDateDefault);
            this.tabDefaultsGeneral.Controls.Add(this.chkDatesDefaultStringWithTypeConversion);
            this.tabDefaultsGeneral.Controls.Add(this.chkAutoCriteria);
            this.tabDefaultsGeneral.Controls.Add(this.chkAutoTimestampCriteria);
            this.tabDefaultsGeneral.Controls.Add(this.groupBoxReadOnlyObjects);
            this.tabDefaultsGeneral.Controls.Add(this.lblCreateTimestampPropertyMode);
            this.tabDefaultsGeneral.Controls.Add(this.cboCreateTimestampPropertyMode);
            this.tabDefaultsGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabDefaultsGeneral.Name = "tabDefaultsGeneral";
            this.tabDefaultsGeneral.Size = new System.Drawing.Size(525, 329);
            this.tabDefaultsGeneral.TabIndex = 1;
            this.tabDefaultsGeneral.Text = "Creation Defaults General";
            this.tabDefaultsGeneral.UseVisualStyleBackColor = true;
            // 
            // lblAlertNewDefaultsGeneral
            // 
            this.lblAlertNewDefaultsGeneral.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertNewDefaultsGeneral.Location = new System.Drawing.Point(12, 10);
            this.lblAlertNewDefaultsGeneral.Name = "lblAlertNewDefaultsGeneral";
            this.lblAlertNewDefaultsGeneral.Size = new System.Drawing.Size(412, 16);
            this.lblAlertNewDefaultsGeneral.TabIndex = 26;
            this.lblAlertNewDefaultsGeneral.Text = "Note: These settings only affect how new objects are created.";
            // 
            // lblNamespace
            // 
            this.lblNamespace.Location = new System.Drawing.Point(15, 40);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(112, 16);
            this.lblNamespace.TabIndex = 6;
            this.lblNamespace.Text = "Namespace:";
            // 
            // txtNamespace
            // 
            this.txtNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultNamespace", true));
            this.txtNamespace.Location = new System.Drawing.Point(15, 56);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(177, 20);
            this.txtNamespace.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtNamespace, "Specify the default namespace to be set on created objects.");
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(15, 84);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(200, 16);
            this.lblFolder.TabIndex = 7;
            this.lblFolder.Text = "Folder: (like: \"Module\\SubModule\"):";
            // 
            // txtFolder
            // 
            this.txtFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultFolder", true));
            this.txtFolder.Location = new System.Drawing.Point(15, 100);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(177, 20);
            this.txtFolder.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtFolder, "Specify the default folder to be set on created objects." +
                "\r\nThis is relative to the project\'s output folder and is used only when namespaces aren't separated in folders.");
            // 
            // lblCreateTimestampPropertyMode
            // 
            this.lblCreateTimestampPropertyMode.Location = new System.Drawing.Point(15, 128);
            this.lblCreateTimestampPropertyMode.Name = "lblCreateTimestampPropertyMode";
            this.lblCreateTimestampPropertyMode.Size = new System.Drawing.Size(200, 16);
            this.lblCreateTimestampPropertyMode.TabIndex = 2;
            this.lblCreateTimestampPropertyMode.Text = "Property Mode for timestamp column:";
            // 
            // cboCreateTimestampPropertyMode
            // 
            this.cboCreateTimestampPropertyMode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "CreateTimestampPropertyMode", true));
            this.cboCreateTimestampPropertyMode.Location = new System.Drawing.Point(15, 144);
            this.cboCreateTimestampPropertyMode.Name = "cboCreateTimestampPropertyMode";
            this.cboCreateTimestampPropertyMode.Size = new System.Drawing.Size(177, 21);
            this.cboCreateTimestampPropertyMode.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cboCreateTimestampPropertyMode, "Select the PropertyMode for timestamp Value Property creation.");
            // 
            // chkSmartDateDefault
            // 
            this.chkSmartDateDefault.AutoSize = true;
            this.chkSmartDateDefault.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "SmartDateDefault", true));
            this.chkSmartDateDefault.Location = new System.Drawing.Point(15, 176);
            this.chkSmartDateDefault.Name = "chkSmartDateDefault";
            this.chkSmartDateDefault.Size = new System.Drawing.Size(336, 17);
            this.chkSmartDateDefault.TabIndex = 6;
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
            this.chkDatesDefaultStringWithTypeConversion.TabIndex = 7;
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
            this.chkAutoCriteria.TabIndex = 7;
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
            this.chkAutoTimestampCriteria.TabIndex = 7;
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
            this.groupBoxReadOnlyObjects.Location = new System.Drawing.Point(240, 46);
            this.groupBoxReadOnlyObjects.Name = "groupBoxReadOnlyObjects";
            this.groupBoxReadOnlyObjects.Size = new System.Drawing.Size(200, 125);
            this.groupBoxReadOnlyObjects.TabIndex = 3;
            this.groupBoxReadOnlyObjects.TabStop = false;
            this.groupBoxReadOnlyObjects.Text = "ReadOnly Objects";
            // 
            // chkReadOnlyObjectsCopyAuditing
            // 
            this.chkReadOnlyObjectsCopyAuditing.AutoSize = true;
            this.chkReadOnlyObjectsCopyAuditing.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "ReadOnlyObjectsCopyAuditing", true));
            this.chkReadOnlyObjectsCopyAuditing.Location = new System.Drawing.Point(8, 24);
            this.chkReadOnlyObjectsCopyAuditing.Name = "chkReadOnlyObjectsCopyAuditing";
            this.chkReadOnlyObjectsCopyAuditing.Size = new System.Drawing.Size(450, 17);
            this.chkReadOnlyObjectsCopyAuditing.TabIndex = 7;
            this.chkReadOnlyObjectsCopyAuditing.Text = "Copy auditing columns.";
            this.chkReadOnlyObjectsCopyAuditing.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkReadOnlyObjectsCopyAuditing, "If checked, creates ReadOnly Objects with auditing columns.");
            // 
            // chkReadOnlyObjectsCopyTimestamp
            // 
            this.chkReadOnlyObjectsCopyTimestamp.AutoSize = true;
            this.chkReadOnlyObjectsCopyTimestamp.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "ReadOnlyObjectsCopyTimestamp", true));
            this.chkReadOnlyObjectsCopyTimestamp.Location = new System.Drawing.Point(8, 48);
            this.chkReadOnlyObjectsCopyTimestamp.Name = "chkReadOnlyObjectsCopyTimestamp";
            this.chkReadOnlyObjectsCopyTimestamp.Size = new System.Drawing.Size(450, 17);
            this.chkReadOnlyObjectsCopyTimestamp.TabIndex = 7;
            this.chkReadOnlyObjectsCopyTimestamp.Text = "Copy timestamp column.";
            this.chkReadOnlyObjectsCopyTimestamp.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkReadOnlyObjectsCopyTimestamp, "If checked, creates ReadOnly Objects with timestamp column.");
            // 
            // lblCreateReadOnlyObjectsPropertyMode
            // 
            this.lblCreateReadOnlyObjectsPropertyMode.Location = new System.Drawing.Point(8, 78);
            this.lblCreateReadOnlyObjectsPropertyMode.Name = "lblCreateReadOnlyObjectsPropertyMode";
            this.lblCreateReadOnlyObjectsPropertyMode.Size = new System.Drawing.Size(170, 16);
            this.lblCreateReadOnlyObjectsPropertyMode.TabIndex = 2;
            this.lblCreateReadOnlyObjectsPropertyMode.Text = "Property Mode for columns:";
            // 
            // cboCreateReadOnlyObjectsPropertyMode
            // 
            this.cboCreateReadOnlyObjectsPropertyMode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "CreateReadOnlyObjectsPropertyMode", true));
            this.cboCreateReadOnlyObjectsPropertyMode.Location = new System.Drawing.Point(8, 94);
            this.cboCreateReadOnlyObjectsPropertyMode.Name = "cboCreateReadOnlyObjectsPropertyMode";
            this.cboCreateReadOnlyObjectsPropertyMode.Size = new System.Drawing.Size(177, 21);
            this.cboCreateReadOnlyObjectsPropertyMode.TabIndex = 2;
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
            this.tabDefaultsDatabase.TabIndex = 0;
            this.tabDefaultsDatabase.Text = "Creation Defaults Database";
            this.tabDefaultsDatabase.UseVisualStyleBackColor = true;
            // 
            // lblAlertNewDefaultsDatabase
            // 
            this.lblAlertNewDefaultsDatabase.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertNewDefaultsDatabase.Location = new System.Drawing.Point(12, 10);
            this.lblAlertNewDefaultsDatabase.Name = "lblAlertNewDefaultsDatabase";
            this.lblAlertNewDefaultsDatabase.Size = new System.Drawing.Size(412, 16);
            this.lblAlertNewDefaultsDatabase.TabIndex = 26;
            this.lblAlertNewDefaultsDatabase.Text = "Note: These settings only affect how new objects are created.";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(15, 40);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(170, 16);
            this.lblDatabase.TabIndex = 1;
            this.lblDatabase.Text = "Database:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultDataBase", true));
            this.txtDatabase.Location = new System.Drawing.Point(15, 56);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(177, 20);
            this.txtDatabase.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtDatabase, "Specify the default database to be set on created objects.");
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.Location = new System.Drawing.Point(15, 88);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(170, 16);
            this.lblTransactionType.TabIndex = 2;
            this.lblTransactionType.Text = "Transaction Type:";
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultTransactionType", true));
            this.cboTransactionType.Location = new System.Drawing.Point(15, 104);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(177, 21);
            this.cboTransactionType.TabIndex = 2;
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
            this.lblPersistenceType.TabIndex = 2;
            this.lblPersistenceType.Text = "Persistence Type:";
            // 
            // cboPersistenceType
            // 
            this.cboPersistenceType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultPersistenceType", true));
            this.cboPersistenceType.Location = new System.Drawing.Point(15, 152);
            this.cboPersistenceType.Name = "cboPersistenceType";
            this.cboPersistenceType.Size = new System.Drawing.Size(177, 21);
            this.cboPersistenceType.TabIndex = 2;
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
            this.lblDatabaseContextObject.TabIndex = 1;
            this.lblDatabaseContextObject.Text = "Database Context Object:";
            // 
            // txtDatabaseContextObject
            // 
            this.txtDatabaseContextObject.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DefaultDatabaseContextObject", true));
            this.txtDatabaseContextObject.Location = new System.Drawing.Point(15, 200);
            this.txtDatabaseContextObject.Name = "txtDatabaseContextObject";
            this.txtDatabaseContextObject.Size = new System.Drawing.Size(177, 20);
            this.txtDatabaseContextObject.TabIndex = 1;
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
            this.groupBoxObjectRelationsBuilder.Location = new System.Drawing.Point(240, 46);
            this.groupBoxObjectRelationsBuilder.Name = "groupBoxObjectRelationsBuilder";
            this.groupBoxObjectRelationsBuilder.Size = new System.Drawing.Size(202, 178);
            this.groupBoxObjectRelationsBuilder.TabIndex = 24;
            this.groupBoxObjectRelationsBuilder.TabStop = false;
            this.groupBoxObjectRelationsBuilder.Text = "Object Relations Builder";
            // 
            // lblChildPropertySuffix
            // 
            this.lblChildPropertySuffix.Location = new System.Drawing.Point(6, 20);
            this.lblChildPropertySuffix.Name = "lblChildPropertySuffix";
            this.lblChildPropertySuffix.Size = new System.Drawing.Size(110, 16);
            this.lblChildPropertySuffix.TabIndex = 5;
            this.lblChildPropertySuffix.Text = "Property Name suffix";
            // 
            // txtChildPropertySuffix
            // 
            this.txtChildPropertySuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ORBChildPropertySuffix", true));
            this.txtChildPropertySuffix.Location = new System.Drawing.Point(6, 36);
            this.txtChildPropertySuffix.Name = "txtChildPropertySuffix";
            this.txtChildPropertySuffix.Size = new System.Drawing.Size(104, 20);
            this.txtChildPropertySuffix.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtChildPropertySuffix, "Specify a suffix to be used on Primary and Secondary Property Name.");
            // 
            // lblCollectionSuffix
            // 
            this.lblCollectionSuffix.Location = new System.Drawing.Point(6, 64);
            this.lblCollectionSuffix.Name = "lblCollectionSuffix";
            this.lblCollectionSuffix.Size = new System.Drawing.Size(124, 16);
            this.lblCollectionSuffix.TabIndex = 5;
            this.lblCollectionSuffix.Text = "Collection Name suffix";
            // 
            // txtCollectionSuffix
            // 
            this.txtCollectionSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ORBCollectionSuffix", true));
            this.txtCollectionSuffix.Location = new System.Drawing.Point(6, 80);
            this.txtCollectionSuffix.Name = "txtCollectionSuffix";
            this.txtCollectionSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtCollectionSuffix.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtCollectionSuffix, "Specify a suffix to be used on Primary and Secondary Collection Type Name.");
            // 
            // lblSingleSPSuffix
            // 
            this.lblSingleSPSuffix.Location = new System.Drawing.Point(6, 108);
            this.lblSingleSPSuffix.Name = "lblSingleSPSuffix";
            this.lblSingleSPSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblSingleSPSuffix.TabIndex = 5;
            this.lblSingleSPSuffix.Text = "Single SP suffix";
            // 
            // txtSingleSPSuffix
            // 
            this.txtSingleSPSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ORBSingleSPSuffix", true));
            this.txtSingleSPSuffix.Location = new System.Drawing.Point(6, 124);
            this.txtSingleSPSuffix.Name = "txtSingleSPSuffix";
            this.txtSingleSPSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtSingleSPSuffix.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtSingleSPSuffix, "Specify a suffix to be used on single set of stored procedure's name.");
            // 
            // chkItemsUseSingleSP
            // 
            this.chkItemsUseSingleSP.AutoSize = false;
            this.chkItemsUseSingleSP.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "ORBItemsUseSingleSP", true));
            this.chkItemsUseSingleSP.Location = new System.Drawing.Point(6, 152);
            this.chkItemsUseSingleSP.Name = "chkItemsUseSingleSP";
            this.chkItemsUseSingleSP.Size = new System.Drawing.Size(193, 20);
            this.chkItemsUseSingleSP.TabIndex = 22;
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
            this.tabStoredProcs.TabIndex = 0;
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
            this.groupBoxPrefixSuffix.Size = new System.Drawing.Size(264, 250);
            this.groupBoxPrefixSuffix.TabIndex = 24;
            this.groupBoxPrefixSuffix.TabStop = false;
            this.groupBoxPrefixSuffix.Text = "Prefixes && Suffixes";
            // 
            // lblGeneralSpPrefix
            // 
            this.lblGeneralSpPrefix.Location = new System.Drawing.Point(6, 20);
            this.lblGeneralSpPrefix.Name = "lblGeneralSpPrefix";
            this.lblGeneralSpPrefix.Size = new System.Drawing.Size(107, 16);
            this.lblGeneralSpPrefix.TabIndex = 5;
            this.lblGeneralSpPrefix.Text = "General SP prefix";
            // 
            // txtGeneralSpPrefix
            // 
            this.txtGeneralSpPrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpGeneralPrefix", true));
            this.txtGeneralSpPrefix.Location = new System.Drawing.Point(6, 36);
            this.txtGeneralSpPrefix.Name = "txtGeneralSpPrefix";
            this.txtGeneralSpPrefix.Size = new System.Drawing.Size(104, 20);
            this.txtGeneralSpPrefix.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtGeneralSpPrefix, "Specify a prefix to be used on all stored procedure's name.");
            // 
            // lblSelectPrefix
            // 
            this.lblSelectPrefix.Location = new System.Drawing.Point(6, 72);
            this.lblSelectPrefix.Name = "lblSelectPrefix";
            this.lblSelectPrefix.Size = new System.Drawing.Size(104, 16);
            this.lblSelectPrefix.TabIndex = 7;
            this.lblSelectPrefix.Text = "Select prefix";
            // 
            // txtSelectPrefix
            // 
            this.txtSelectPrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpGetPrefix", true));
            this.txtSelectPrefix.Location = new System.Drawing.Point(6, 88);
            this.txtSelectPrefix.Name = "txtSelectPrefix";
            this.txtSelectPrefix.Size = new System.Drawing.Size(104, 20);
            this.txtSelectPrefix.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtSelectPrefix, "Specify a prefix to be used on SELECT stored procedure's name.");
            // 
            // lblInsertPrefix
            // 
            this.lblInsertPrefix.Location = new System.Drawing.Point(6, 116);
            this.lblInsertPrefix.Name = "lblInsertPrefix";
            this.lblInsertPrefix.Size = new System.Drawing.Size(104, 16);
            this.lblInsertPrefix.TabIndex = 6;
            this.lblInsertPrefix.Text = "Insert prefix";
            // 
            // txtInsertPrefix
            // 
            this.txtInsertPrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpAddPrefix", true));
            this.txtInsertPrefix.Location = new System.Drawing.Point(6, 132);
            this.txtInsertPrefix.Name = "txtInsertPrefix";
            this.txtInsertPrefix.Size = new System.Drawing.Size(104, 20);
            this.txtInsertPrefix.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtInsertPrefix, "Specify a prefix to be used on INSERT stored procedure's name.");
            // 
            // lblUpdatePrefix
            // 
            this.lblUpdatePrefix.Location = new System.Drawing.Point(6, 160);
            this.lblUpdatePrefix.Name = "lblUpdatePrefix";
            this.lblUpdatePrefix.Size = new System.Drawing.Size(104, 16);
            this.lblUpdatePrefix.TabIndex = 8;
            this.lblUpdatePrefix.Text = "Update prefix";
            // 
            // txtUpdatePrefix
            // 
            this.txtUpdatePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpUpdatePrefix", true));
            this.txtUpdatePrefix.Location = new System.Drawing.Point(6, 176);
            this.txtUpdatePrefix.Name = "txtUpdatePrefix";
            this.txtUpdatePrefix.Size = new System.Drawing.Size(104, 20);
            this.txtUpdatePrefix.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtUpdatePrefix, "Specify a prefix to be used on UPDATE stored procedure's name.");
            // 
            // lblDeletePrefix
            // 
            this.lblDeletePrefix.Location = new System.Drawing.Point(6, 204);
            this.lblDeletePrefix.Name = "lblDeletePrefix";
            this.lblDeletePrefix.Size = new System.Drawing.Size(104, 16);
            this.lblDeletePrefix.TabIndex = 9;
            this.lblDeletePrefix.Text = "Delete prefix";
            // 
            // txtDeletePrefix
            // 
            this.txtDeletePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpDeletePrefix", true));
            this.txtDeletePrefix.Location = new System.Drawing.Point(6, 220);
            this.txtDeletePrefix.Name = "txtDeletePrefix";
            this.txtDeletePrefix.Size = new System.Drawing.Size(104, 20);
            this.txtDeletePrefix.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtDeletePrefix, "Specify a prefix to be used on DELETE stored procedure's name.");
            // 
            // lblGeneralSpSuffix
            // 
            this.lblGeneralSpSuffix.Location = new System.Drawing.Point(150, 20);
            this.lblGeneralSpSuffix.Name = "lblGeneralSpSuffix";
            this.lblGeneralSpSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblGeneralSpSuffix.TabIndex = 15;
            this.lblGeneralSpSuffix.Text = "General SP suffix";
            // 
            // txtGeneralSpSuffix
            // 
            this.txtGeneralSpSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpGeneralSuffix", true));
            this.txtGeneralSpSuffix.Location = new System.Drawing.Point(150, 36);
            this.txtGeneralSpSuffix.Name = "txtGeneralSpSuffix";
            this.txtGeneralSpSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtGeneralSpSuffix.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtGeneralSpSuffix, "Specify a suffix to be used on all stored procedure's name.");
            // 
            // lblSelectSuffix
            // 
            this.lblSelectSuffix.Location = new System.Drawing.Point(150, 72);
            this.lblSelectSuffix.Name = "lblSelectSuffix";
            this.lblSelectSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblSelectSuffix.TabIndex = 17;
            this.lblSelectSuffix.Text = "Select suffix";
            // 
            // txtSelectSuffix
            // 
            this.txtSelectSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpGetSuffix", true));
            this.txtSelectSuffix.Location = new System.Drawing.Point(150, 88);
            this.txtSelectSuffix.Name = "txtSelectSuffix";
            this.txtSelectSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtSelectSuffix.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtSelectSuffix, "Specify a suffix to be used on SELECT stored procedure's name.");
            // 
            // lblInsertSuffix
            // 
            this.lblInsertSuffix.Location = new System.Drawing.Point(150, 116);
            this.lblInsertSuffix.Name = "lblInsertSuffix";
            this.lblInsertSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblInsertSuffix.TabIndex = 16;
            this.lblInsertSuffix.Text = "Insert suffix";
            // 
            // txtInsertSuffix
            // 
            this.txtInsertSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpAddSuffix", true));
            this.txtInsertSuffix.Location = new System.Drawing.Point(150, 132);
            this.txtInsertSuffix.Name = "txtInsertSuffix";
            this.txtInsertSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtInsertSuffix.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtInsertSuffix, "Specify a suffix to be used on INSERT stored procedure's name.");
            // 
            // lblUpdateSuffix
            // 
            this.lblUpdateSuffix.Location = new System.Drawing.Point(150, 160);
            this.lblUpdateSuffix.Name = "lblUpdateSuffix";
            this.lblUpdateSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblUpdateSuffix.TabIndex = 18;
            this.lblUpdateSuffix.Text = "Update suffix";
            // 
            // txtUpdateSuffix
            // 
            this.txtUpdateSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpUpdateSuffix", true));
            this.txtUpdateSuffix.Location = new System.Drawing.Point(150, 176);
            this.txtUpdateSuffix.Name = "txtUpdateSuffix";
            this.txtUpdateSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtUpdateSuffix.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtUpdateSuffix, "Specify a suffix to be used on UPDATE stored procedure's name.");
            // 
            // lblDeleteSuffix
            // 
            this.lblDeleteSuffix.Location = new System.Drawing.Point(150, 204);
            this.lblDeleteSuffix.Name = "lblDeleteSuffix";
            this.lblDeleteSuffix.Size = new System.Drawing.Size(104, 16);
            this.lblDeleteSuffix.TabIndex = 19;
            this.lblDeleteSuffix.Text = "Delete suffix";
            // 
            // txtDeleteSuffix
            // 
            this.txtDeleteSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpDeleteSuffix", true));
            this.txtDeleteSuffix.Location = new System.Drawing.Point(150, 220);
            this.txtDeleteSuffix.Name = "txtDeleteSuffix";
            this.txtDeleteSuffix.Size = new System.Drawing.Size(104, 20);
            this.txtDeleteSuffix.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtDeleteSuffix, "Specify a suffix to be used on DELETE stored procedure's name.");
            // 
            // lblBoolSoftDelete
            // 
            this.lblBoolSoftDelete.Location = new System.Drawing.Point(289, 12);
            this.lblBoolSoftDelete.Name = "lblBoolSoftDelete";
            this.lblBoolSoftDelete.Size = new System.Drawing.Size(130, 16);
            this.lblBoolSoftDelete.TabIndex = 21;
            this.lblBoolSoftDelete.Text = "Bool soft delete column";
            // 
            // txtBoolSoftDelete
            // 
            this.txtBoolSoftDelete.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpBoolSoftDeleteColumn", true));
            this.txtBoolSoftDelete.Location = new System.Drawing.Point(289, 28);
            this.txtBoolSoftDelete.Name = "txtBoolSoftDelete";
            this.txtBoolSoftDelete.Size = new System.Drawing.Size(130, 20);
            this.txtBoolSoftDelete.TabIndex = 20;
            this.toolTip1.SetToolTip(this.txtBoolSoftDelete, "Specify the column name to be recognized as a \"Boolean\" soft delete column.");
            // 
            // lblIntSoftDelete
            // 
            this.lblIntSoftDelete.Location = new System.Drawing.Point(289, 56);
            this.lblIntSoftDelete.Name = "lblIntSoftDelete";
            this.lblIntSoftDelete.Size = new System.Drawing.Size(130, 16);
            this.lblIntSoftDelete.TabIndex = 23;
            this.lblIntSoftDelete.Text = "Int soft delete column";
            // 
            // txtIntSoftDelete
            // 
            this.txtIntSoftDelete.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "SpIntSoftDeleteColumn", true));
            this.txtIntSoftDelete.Location = new System.Drawing.Point(289, 72);
            this.txtIntSoftDelete.Name = "txtIntSoftDelete";
            this.txtIntSoftDelete.Size = new System.Drawing.Size(130, 20);
            this.txtIntSoftDelete.TabIndex = 22;
            this.toolTip1.SetToolTip(this.txtIntSoftDelete, "CTP - Not implemented.\r\n\r\n" + 
                "Specify the column name to be recognized as an \"integer\" soft delete column.");
            // 
            // chkIgnoreFilterWhenSoftDeleteIsParam
            // 
            this.chkIgnoreFilterWhenSoftDeleteIsParam.AutoSize = true;
            this.chkIgnoreFilterWhenSoftDeleteIsParam.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "SpIgnoreFilterWhenSoftDeleteIsParam", true));
            this.chkIgnoreFilterWhenSoftDeleteIsParam.Location = new System.Drawing.Point(289, 104);
            this.chkIgnoreFilterWhenSoftDeleteIsParam.Name = "chkIgnoreFilterWhenSoftDeleteIsParam";
            this.chkIgnoreFilterWhenSoftDeleteIsParam.Size = new System.Drawing.Size(130, 20);
            this.chkIgnoreFilterWhenSoftDeleteIsParam.TabIndex = 22;
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
            this.chkRemoveChildBeforeParent.Location = new System.Drawing.Point(289, 132);
            this.chkRemoveChildBeforeParent.Name = "chkRemoveChildBeforeParent";
            this.chkRemoveChildBeforeParent.Size = new System.Drawing.Size(130, 20);
            this.chkRemoveChildBeforeParent.TabIndex = 22;
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
            this.groupBoxPKDefaultValues.Size = new System.Drawing.Size(222, 136);
            this.groupBoxPKDefaultValues.TabIndex = 0;
            this.groupBoxPKDefaultValues.TabStop = false;
            this.groupBoxPKDefaultValues.Text = "PK Property Default Values";
            // 
            // lblIDGuidDefaultValue
            // 
            this.lblIDGuidDefaultValue.Location = new System.Drawing.Point(8, 24);
            this.lblIDGuidDefaultValue.Name = "lblIDGuidDefaultValue";
            this.lblIDGuidDefaultValue.Size = new System.Drawing.Size(98, 16);
            this.lblIDGuidDefaultValue.TabIndex = 3;
            this.lblIDGuidDefaultValue.Text = "Guid:";
            // 
            // txtIDGuidDefaultValue
            // 
            this.txtIDGuidDefaultValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "IDGuidDefaultValue", true));
            this.txtIDGuidDefaultValue.Location = new System.Drawing.Point(108, 22);
            this.txtIDGuidDefaultValue.Name = "txtIDGuidDefaultValue";
            this.txtIDGuidDefaultValue.Size = new System.Drawing.Size(100, 20);
            this.txtIDGuidDefaultValue.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtIDGuidDefaultValue,
                                     "Specify the value to be assigned on new object creation by DataPortal_Create.");
            // 
            // lblIDInt16DefaultValue
            // 
            this.lblIDInt16DefaultValue.Location = new System.Drawing.Point(8, 52);
            this.lblIDInt16DefaultValue.Name = "lblIDInt16DefaultValue";
            this.lblIDInt16DefaultValue.Size = new System.Drawing.Size(98, 16);
            this.lblIDInt16DefaultValue.TabIndex = 5;
            this.lblIDInt16DefaultValue.Text = "Int16 Identity:";
            // 
            // txtIDInt16DefaultValue
            // 
            this.txtIDInt16DefaultValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "IDInt16DefaultValue", true));
            this.txtIDInt16DefaultValue.Location = new System.Drawing.Point(108, 50);
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
            this.lblIDInt32DefaultValue.Location = new System.Drawing.Point(8, 80);
            this.lblIDInt32DefaultValue.Name = "lblIDInt32DefaultValue";
            this.lblIDInt32DefaultValue.Size = new System.Drawing.Size(98, 16);
            this.lblIDInt32DefaultValue.TabIndex = 8;
            this.lblIDInt32DefaultValue.Text = "Int32 Identity:";
            // 
            // txtIDInt32DefaultValue
            // 
            this.txtIDInt32DefaultValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "IDInt32DefaultValue", true));
            this.txtIDInt32DefaultValue.Location = new System.Drawing.Point(108, 78);
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
            this.lblIDInt64DefaultValue.Location = new System.Drawing.Point(8, 108);
            this.lblIDInt64DefaultValue.Name = "lblIDInt64DefaultValue";
            this.lblIDInt64DefaultValue.Size = new System.Drawing.Size(98, 16);
            this.lblIDInt64DefaultValue.TabIndex = 10;
            this.lblIDInt64DefaultValue.Text = "Int64 Identity:";
            // 
            // txtIDInt64DefaultValue
            // 
            this.txtIDInt64DefaultValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "IDInt64DefaultValue", true));
            this.txtIDInt64DefaultValue.Location = new System.Drawing.Point(108, 106);
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
            this.groupBoxOtherParameters.Size = new System.Drawing.Size(222, 80);
            this.groupBoxOtherParameters.TabIndex = 3;
            this.groupBoxOtherParameters.TabStop = false;
            this.groupBoxOtherParameters.Text = "Other Parameters";
            // 
            // lblFieldNamePrefix
            // 
            this.lblFieldNamePrefix.Location = new System.Drawing.Point(8, 24);
            this.lblFieldNamePrefix.Name = "lblFieldNamePrefix";
            this.lblFieldNamePrefix.Size = new System.Drawing.Size(100, 16);
            this.lblFieldNamePrefix.TabIndex = 3;
            this.lblFieldNamePrefix.Text = "Field Prefix:";
            // 
            // txtFieldNamePrefix
            // 
            this.txtFieldNamePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "FieldNamePrefix", true));
            this.txtFieldNamePrefix.Location = new System.Drawing.Point(108, 22);
            this.txtFieldNamePrefix.Name = "txtFieldNamePrefix";
            this.txtFieldNamePrefix.Size = new System.Drawing.Size(100, 20);
            this.txtFieldNamePrefix.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtFieldNamePrefix, "Specify a prefix to be used on field's name.");
            // 
            // lblDelegateNamePrefix
            // 
            this.lblDelegateNamePrefix.Location = new System.Drawing.Point(8, 52);
            this.lblDelegateNamePrefix.Name = "lblDelegateNamePrefix";
            this.lblDelegateNamePrefix.Size = new System.Drawing.Size(100, 16);
            this.lblDelegateNamePrefix.TabIndex = 5;
            this.lblDelegateNamePrefix.Text = "Delegate Prefix:";
            // 
            // txtDelegateNamePrefix
            // 
            this.txtDelegateNamePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "DelegateNamePrefix", true));
            this.txtDelegateNamePrefix.Location = new System.Drawing.Point(108, 50);
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
            this.groupBoxSimpleAuditing.Location = new System.Drawing.Point(240, 12);
            this.groupBoxSimpleAuditing.Name = "groupBoxSimpleAuditing";
            this.groupBoxSimpleAuditing.Size = new System.Drawing.Size(245, 226);
            this.groupBoxSimpleAuditing.TabIndex = 3;
            this.groupBoxSimpleAuditing.TabStop = false;
            this.groupBoxSimpleAuditing.Text = "Simple Auditing";
            // 
            // lblCreationDateColumn
            // 
            this.lblCreationDateColumn.Location = new System.Drawing.Point(8, 24);
            this.lblCreationDateColumn.Name = "lblCreationDateColumn";
            this.lblCreationDateColumn.Size = new System.Drawing.Size(123, 16);
            this.lblCreationDateColumn.TabIndex = 3;
            this.lblCreationDateColumn.Text = "Creation Date Column:";
            // 
            // txtCreationDateColumn
            // 
            this.txtCreationDateColumn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "CreationDateColumn", true));
            this.txtCreationDateColumn.Location = new System.Drawing.Point(131, 22);
            this.txtCreationDateColumn.Name = "txtCreationDateColumn";
            this.txtCreationDateColumn.Size = new System.Drawing.Size(100, 20);
            this.txtCreationDateColumn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtCreationDateColumn,
                                     "Specify the column name to be recognized as a \"creation date\" column.");
            // 
            // lblCreationUserColumn
            // 
            this.lblCreationUserColumn.Location = new System.Drawing.Point(8, 52);
            this.lblCreationUserColumn.Name = "lblCreationUserColumn";
            this.lblCreationUserColumn.Size = new System.Drawing.Size(123, 16);
            this.lblCreationUserColumn.TabIndex = 3;
            this.lblCreationUserColumn.Text = "Creation User Column:";
            // 
            // txtCreationUserColumn
            // 
            this.txtCreationUserColumn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "CreationUserColumn", true));
            this.txtCreationUserColumn.Location = new System.Drawing.Point(131, 50);
            this.txtCreationUserColumn.Name = "txtCreationUserColumn";
            this.txtCreationUserColumn.Size = new System.Drawing.Size(100, 20);
            this.txtCreationUserColumn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtCreationUserColumn,
                                     "Specify the column name to be recognized as a \"creation user\" column.");
            // 
            // lblChangedDateColumn
            // 
            this.lblChangedDateColumn.Location = new System.Drawing.Point(8, 80);
            this.lblChangedDateColumn.Name = "lblChangedDateColumn";
            this.lblChangedDateColumn.Size = new System.Drawing.Size(123, 16);
            this.lblChangedDateColumn.TabIndex = 3;
            this.lblChangedDateColumn.Text = "Changed Date Column:";
            // 
            // txtChangedDateColumn
            // 
            this.txtChangedDateColumn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ChangedDateColumn", true));
            this.txtChangedDateColumn.Location = new System.Drawing.Point(131, 78);
            this.txtChangedDateColumn.Name = "txtChangedDateColumn";
            this.txtChangedDateColumn.Size = new System.Drawing.Size(100, 20);
            this.txtChangedDateColumn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtChangedDateColumn,
                                     "Specify the column name to be recognized as a \"changed date\" column.");
            // 
            // lblChangedUserColumn
            // 
            this.lblChangedUserColumn.Location = new System.Drawing.Point(8, 108);
            this.lblChangedUserColumn.Name = "lblChangedUserColumn";
            this.lblChangedUserColumn.Size = new System.Drawing.Size(123, 16);
            this.lblChangedUserColumn.TabIndex = 3;
            this.lblChangedUserColumn.Text = "Changed User Column:";
            // 
            // txtChangedUserColumn
            // 
            this.txtChangedUserColumn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "ChangedUserColumn", true));
            this.txtChangedUserColumn.Location = new System.Drawing.Point(131, 106);
            this.txtChangedUserColumn.Name = "txtChangedUserColumn";
            this.txtChangedUserColumn.Size = new System.Drawing.Size(100, 20);
            this.txtChangedUserColumn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtChangedUserColumn,
                                     "Specify the column name to be recognized as a \"changed user\" column.");
            // 
            // chkLogDateAndTime
            // 
            this.chkLogDateAndTime.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.projectParametersBindingSource, "LogDateAndTime", true));
            this.chkLogDateAndTime.Location = new System.Drawing.Point(8, 150);
            this.chkLogDateAndTime.Name = "chkLogDateAndTime";
            this.chkLogDateAndTime.Size = new System.Drawing.Size(200, 20);
            this.chkLogDateAndTime.TabIndex = 5;
            this.chkLogDateAndTime.Text = "Log Date and also Time";
            this.toolTip1.SetToolTip(this.chkLogDateAndTime, "If checked, date auditing uses time precision up to seconds.");
            // 
            // lblGetUserMethod
            // 
            this.lblGetUserMethod.Location = new System.Drawing.Point(8, 180);
            this.lblGetUserMethod.Name = "lblGetUserMethod";
            this.lblGetUserMethod.Size = new System.Drawing.Size(100, 16);
            this.lblGetUserMethod.TabIndex = 3;
            this.lblGetUserMethod.Text = "Get user method:";
            // 
            // txtGetUserMethod
            // 
            this.txtGetUserMethod.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectParametersBindingSource, "GetUserMethod", true));
            this.txtGetUserMethod.Location = new System.Drawing.Point(8, 196);
            this.txtGetUserMethod.Name = "txtGetUserMethod";
            this.txtGetUserMethod.Size = new System.Drawing.Size(223, 20);
            this.txtGetUserMethod.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtGetUserMethod,
                                     "Specify the method to be used to get a user value (ID or name or whatever) for auditing purposes.");
            // 
            // tabGeneration
            // 
            this.tabGeneration.Controls.Add(this.chkSaveGenerationGeneral);
            this.tabGeneration.Controls.Add(this.lblTarget);
            this.tabGeneration.Controls.Add(this.cboTarget);
            this.tabGeneration.Controls.Add(this.lblOutputLanguage);
            this.tabGeneration.Controls.Add(this.cboOutputLanguage);
            this.tabGeneration.Controls.Add(this.lblUIEnvironment);
            this.tabGeneration.Controls.Add(this.cboUIEnvironment);
            this.tabGeneration.Controls.Add(this.lblGenerateAuthorization);
            this.tabGeneration.Controls.Add(this.cboGenerateAuthorization);
            this.tabGeneration.Controls.Add(this.lblHeaderVerbosity);
            this.tabGeneration.Controls.Add(this.cboHeaderVerbosity);
            // this.tabGeneration.Controls.Add(this.lblPropertyMode);
            // this.tabGeneration.Controls.Add(this.cboPropertyMode);
            this.tabGeneration.Controls.Add(this.chkUseChildDataPortal);
            this.tabGeneration.Controls.Add(this.chkNullableSupport);
            this.tabGeneration.Controls.Add(this.chkActiveObjects);
            this.tabGeneration.Controls.Add(this.chkUseBypassPropertyChecks);
            this.tabGeneration.Controls.Add(this.chkUseSingleCriteria);
            this.tabGeneration.Controls.Add(this.chkForceReadOnlyProperties);
            this.tabGeneration.Location = new System.Drawing.Point(4, 22);
            this.tabGeneration.Name = "tabGeneration";
            this.tabGeneration.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneration.Size = new System.Drawing.Size(525, 329);
            this.tabGeneration.TabIndex = 3;
            this.tabGeneration.Text = "Generation";
            this.tabGeneration.UseVisualStyleBackColor = true;
            // 
            // chkSaveGenerationGeneral
            // 
            this.chkSaveGenerationGeneral.Checked = true;
            this.chkSaveGenerationGeneral.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveGenerationGeneral.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SaveBeforeGenerate", true));
            this.chkSaveGenerationGeneral.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaveGenerationGeneral.Location = new System.Drawing.Point(15, 10);
            this.chkSaveGenerationGeneral.Name = "chkSaveGenerationGeneral";
            this.chkSaveGenerationGeneral.Size = new System.Drawing.Size(225, 21);
            this.chkSaveGenerationGeneral.TabIndex = 1;
            this.chkSaveGenerationGeneral.Text = "Save project before generating";
            this.toolTip1.SetToolTip(this.chkSaveGenerationGeneral,
                                     "If checked, projects are silently saved before code generation.");
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(15, 50);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(101, 16);
            this.lblTarget.TabIndex = 21;
            this.lblTarget.Text = "Target Framework:";
            // 
            // cboTarget
            // 
            this.cboTarget.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "TargetFramework", true));
            this.cboTarget.Location = new System.Drawing.Point(116, 47);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Size = new System.Drawing.Size(118, 21);
            this.cboTarget.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cboTarget,
                                     "Select the target CSLA.NET framework version.\r\n" +
                                     "Using \"CSLA40\" hides \"Add Parent Reference\" property in Csla Object Info panel.");
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
            this.cboOutputLanguage.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cboOutputLanguage,
                                     "Select the language for the generated code: C# or Visual Basic.\r\n" +
                                     "\r\nN.B. - JScript is deprecated since v.4.0.");
            // 
            // lblUIEnvironment
            // 
            this.lblUIEnvironment.Location = new System.Drawing.Point(15, 106);
            this.lblUIEnvironment.Name = "lblUIEnvironment";
            this.lblUIEnvironment.Size = new System.Drawing.Size(101, 16);
            this.lblUIEnvironment.TabIndex = 39;
            this.lblUIEnvironment.Text = "UI Environment:";
            // 
            // cboUIEnvironment
            // 
            this.cboUIEnvironment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "GeneratedUIEnvironment", true));
            this.cboUIEnvironment.Location = new System.Drawing.Point(116, 103);
            this.cboUIEnvironment.Name = "cboUIEnvironment";
            this.cboUIEnvironment.Size = new System.Drawing.Size(118, 21);
            this.cboUIEnvironment.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cboUIEnvironment,
                                     "CSLA40 - Specify whether code must be generate for Windows Forms, WPF or both.\r\n" +
                                     "<WinForms_WPF> means \"Windows Forms first\" or \"defaults to Windows Forms.\r\n" +
                                     "This will build BusinessBindingListBase usable on WinForms DataGridView.\r\n" +
                                     "Use the \"WPF\" compiler directive to build BusinessListBase/ObservableCollection.");
            // 
            // lblGenerateAuthorization
            // 
            this.lblGenerateAuthorization.Location = new System.Drawing.Point(15, 134);
            this.lblGenerateAuthorization.Name = "lblGenerateAuthorization";
            this.lblGenerateAuthorization.Size = new System.Drawing.Size(101, 16);
            this.lblGenerateAuthorization.TabIndex = 39;
            this.lblGenerateAuthorization.Text = "Authorization code:";
            // 
            // cboGenerateAuthorization
            // 
            this.cboGenerateAuthorization.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "GenerateAuthorization", true));
            this.cboGenerateAuthorization.Location = new System.Drawing.Point(116, 131);
            this.cboGenerateAuthorization.Name = "cboGenerateAuthorization";
            this.cboGenerateAuthorization.Size = new System.Drawing.Size(118, 21);
            this.cboGenerateAuthorization.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cboGenerateAuthorization,
                                     "Authorization level to generate. Use \"None\" for no implementation at all.\r\n" +
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
            this.lblHeaderVerbosity.Location = new System.Drawing.Point(15, 162);
            this.lblHeaderVerbosity.Name = "lblHeaderVerbosity";
            this.lblHeaderVerbosity.Size = new System.Drawing.Size(101, 16);
            this.lblHeaderVerbosity.TabIndex = 39;
            this.lblHeaderVerbosity.Text = "Header verbosity:";
            // 
            // cboHeaderVerbosity
            // 
            this.cboHeaderVerbosity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "HeaderVerbosity", true));
            this.cboHeaderVerbosity.Location = new System.Drawing.Point(116, 159);
            this.cboHeaderVerbosity.Name = "cboHeaderVerbosity";
            this.cboHeaderVerbosity.Size = new System.Drawing.Size(118, 21);
            this.cboHeaderVerbosity.TabIndex = 5;
            this.toolTip1.SetToolTip(this.cboHeaderVerbosity, "Header verbosity level.");
            // 
            // lblPropertyMode
            // 
            // this.lblPropertyMode.Location = new System.Drawing.Point(15, 63);
            // this.lblPropertyMode.Name = "lblPropertyMode";
            // this.lblPropertyMode.Size = new System.Drawing.Size(100, 16);
            // this.lblPropertyMode.TabIndex = 36;
            // this.lblPropertyMode.Text = "Property Mode:";
            // 
            // cboPropertyMode
            // 
            // this.cboPropertyMode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "PropertyMode", true));
            // this.cboPropertyMode.Location = new System.Drawing.Point(115, 60);
            // this.cboPropertyMode.Name = "cboPropertyMode";
            // this.cboPropertyMode.Size = new System.Drawing.Size(118, 21);
            // this.cboPropertyMode.TabIndex = 4;
            // this.toolTip1.SetToolTip(this.cboPropertyMode, "DEPRECATED on v. 4 (Select the property mode for all Value Properties).");
            // 
            // chkNullableSupport
            // 
            this.chkNullableSupport.AutoSize = true;
            this.chkNullableSupport.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "NullableSupport", true));
            this.chkNullableSupport.Location = new System.Drawing.Point(255, 50);
            this.chkNullableSupport.Name = "chkNullableSupport";
            this.chkNullableSupport.Size = new System.Drawing.Size(157, 17);
            this.chkNullableSupport.TabIndex = 15;
            this.chkNullableSupport.Text = "Enable Nullable<T> support";
            this.chkNullableSupport.UseVisualStyleBackColor = true;
            this.toolTip1.SetToolTip(this.chkNullableSupport, "If checked, enables Nullable<T> support.");
            // 
            // chkUseChildDataPortal
            // 
            this.chkUseChildDataPortal.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "UseChildDataPortal", true));
            this.chkUseChildDataPortal.Location = new System.Drawing.Point(255, 78);
            this.chkUseChildDataPortal.Name = "chkUseChildDataPortal";
            this.chkUseChildDataPortal.Size = new System.Drawing.Size(216, 17);
            this.chkUseChildDataPortal.TabIndex = 10;
            this.chkUseChildDataPortal.Text = "Use child DataPortal methods";
            this.toolTip1.SetToolTip(this.chkUseChildDataPortal,
                                     "If checked, child DataPortal methods are used.\r\n" +
                                     "Otherwise standard DataPortal methods are generated.");
            //
            // chkActiveObjects
            // 
            this.chkActiveObjects.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "ActiveObjects", true));
            this.chkActiveObjects.Location = new System.Drawing.Point(255, 106);
            this.chkActiveObjects.Name = "chkActiveObjects";
            this.chkActiveObjects.Size = new System.Drawing.Size(216, 17);
            this.chkActiveObjects.TabIndex = 14;
            this.chkActiveObjects.Text = "Generate Active Objects code";
            this.toolTip1.SetToolTip(this.chkActiveObjects,
                                     "If checked, outputs ActiveObjects code instead of plain CSLA.\r\n" +
                                     "If unchecked hides \"11. Active Objects\" properties in Csla Object Info panel.");
            //
            // chkUseBypassPropertyChecks
            // 
            this.chkUseBypassPropertyChecks.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "UseBypassPropertyChecks", true));
            this.chkUseBypassPropertyChecks.Location = new System.Drawing.Point(255, 134);
            this.chkUseBypassPropertyChecks.Name = "chkUseBypassPropertyChecks";
            this.chkUseBypassPropertyChecks.Size = new System.Drawing.Size(260, 17);
            this.chkUseBypassPropertyChecks.TabIndex = 14;
            this.chkUseBypassPropertyChecks.Text = "Generate BypassPropertyChecks code blocks";
            this.toolTip1.SetToolTip(this.chkUseBypassPropertyChecks,
                                     "CTP - Not implemented.\r\n\r\n" +
                                     "If checked, improves code readability by using BypassPropertyChecks blocks\r\n" +
                                     "and assign values using .NET properties.\r\n" +
                                     "Otherwise uses LoadProperty() to assign values.");
            //
            // chkUseSingleCriteria
            // 
            this.chkUseSingleCriteria.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "UseSingleCriteria", true));
            this.chkUseSingleCriteria.Location = new System.Drawing.Point(255, 162);
            this.chkUseSingleCriteria.Name = "chkUseSingleCriteria";
            this.chkUseSingleCriteria.Size = new System.Drawing.Size(260, 17);
            this.chkUseSingleCriteria.TabIndex = 14;
            this.chkUseSingleCriteria.Text = "Generate SingleCriteria parameter passing";
            this.toolTip1.SetToolTip(this.chkUseSingleCriteria,
                                     "If unchecked, single native type parameter will be passed to DataPortal methods as native type.\r\n" +
                                     "Otherwise generates SingleCriteria for single parameter passing to DataPortal methods.");
            //
            // chkForceReadOnlyProperties
            // 
            this.chkForceReadOnlyProperties.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "ForceReadOnlyProperties", true));
            this.chkForceReadOnlyProperties.Location = new System.Drawing.Point(255, 190);
            this.chkForceReadOnlyProperties.Name = "chkForceReadOnlyProperties";
            this.chkForceReadOnlyProperties.Size = new System.Drawing.Size(216, 17);
            this.chkForceReadOnlyProperties.TabIndex = 7;
            this.chkForceReadOnlyProperties.Text = "Force ReadOnly Properties";
            this.toolTip1.SetToolTip(this.chkForceReadOnlyProperties,
                                     "If checked, all ReadOnlyObject's properties are ReadOnly.\r\n" +
                                     "Otherwise allows all kinds of accessibility for ReadOnlyObject's properties.\r\n\r\n" +
                                     "Note - ReadOnlyObject's managed and unmanaged properties are always ReadOnly properties.");
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
            this.tabGenerationFiles.Controls.Add(this.lblUtilitiesNamespace);
            this.tabGenerationFiles.Controls.Add(this.txtUtilitiesNamespace);
            this.tabGenerationFiles.Controls.Add(this.lblUtilitiesFolder);
            this.tabGenerationFiles.Controls.Add(this.txtUtilitiesFolder);
            this.tabGenerationFiles.Controls.Add(this.chkGenerateStoredProcedures);
            this.tabGenerationFiles.Controls.Add(this.chkSpOneFile);
            this.tabGenerationFiles.Controls.Add(this.chkOnlyNeededSprocs);
            this.tabGenerationFiles.Controls.Add(this.chkGenerateDatabaseClass);
            this.tabGenerationFiles.Location = new System.Drawing.Point(4, 22);
            this.tabGenerationFiles.Name = "tabGenerationFiles";
            this.tabGenerationFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerationFiles.Size = new System.Drawing.Size(525, 329);
            this.tabGenerationFiles.TabIndex = 4;
            this.tabGenerationFiles.Text = "Gen. Files & SP";
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
            this.chkSaveGenerationFiles.TabIndex = 1;
            this.chkSaveGenerationFiles.Text = "Save project before generating";
            this.toolTip1.SetToolTip(this.chkSaveGenerationFiles, "If checked, projects are silently saved before code generation.");
            // 
            // lblBaseFilenameSuffix
            // 
            this.lblBaseFilenameSuffix.Location = new System.Drawing.Point(15, 50);
            this.lblBaseFilenameSuffix.Name = "lblBaseFilenameSuffix";
            this.lblBaseFilenameSuffix.Size = new System.Drawing.Size(150, 16);
            this.lblBaseFilenameSuffix.TabIndex = 28;
            this.lblBaseFilenameSuffix.Text = "Suffix for base files:";
            // 
            // txtBaseFilenameSuffix
            // 
            this.txtBaseFilenameSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "BaseFilenameSuffix", true));
            this.txtBaseFilenameSuffix.Location = new System.Drawing.Point(15, 66);
            this.txtBaseFilenameSuffix.Name = "txtBaseFilenameSuffix";
            this.txtBaseFilenameSuffix.Size = new System.Drawing.Size(164, 17);
            this.txtBaseFilenameSuffix.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtBaseFilenameSuffix,
                                     "If specified, base classes use \"<object><suffix>\" in file names instead of \"<object>Base\" file name." +
                                     "\r\nN.B. - For generated filename compatibility with previous versions, use \".Designer\" suffix.");
            // 
            // lblExtendedFilenameSuffix
            // 
            this.lblExtendedFilenameSuffix.Location = new System.Drawing.Point(15, 94);
            this.lblExtendedFilenameSuffix.Name = "lblExtendedFilenameSuffix";
            this.lblExtendedFilenameSuffix.Size = new System.Drawing.Size(164, 16);
            this.lblExtendedFilenameSuffix.TabIndex = 28;
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
            this.txtExtendedFilenameSuffix.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtExtendedFilenameSuffix,
                                     "If specified, extended classes use \"<object><suffix>\" in file names instead of \"<object>\" file name." +
                                     "\r\nN.B. - For generated filename compatibility with previous versions, use an empty suffix.");
            // 
            // lblClassCommentFilenameSuffix
            // 
            this.lblClassCommentFilenameSuffix.Location = new System.Drawing.Point(15, 138);
            this.lblClassCommentFilenameSuffix.Name = "lblClassCommentFilenameSuffix";
            this.lblClassCommentFilenameSuffix.Size = new System.Drawing.Size(164, 16);
            this.lblClassCommentFilenameSuffix.TabIndex = 28;
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
            this.txtClassCommentFilenameSuffix.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtClassCommentFilenameSuffix,
                                     "If specified, class comments are separated on its own file with file names \"<object><suffix>\". If blank, class comments are inserted on base class files.");
            // 
            // chkBackupOldSource
            // 
            this.chkBackupOldSource.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "BackupOldSource", true));
            this.chkBackupOldSource.Location = new System.Drawing.Point(15, 186);
            this.chkBackupOldSource.Name = "chkBackupOldSource";
            this.chkBackupOldSource.Size = new System.Drawing.Size(216, 17);
            this.chkBackupOldSource.TabIndex = 6;
            this.chkBackupOldSource.Text = "Backup old source files";
            this.toolTip1.SetToolTip(this.chkBackupOldSource, "If checked, replaced files are backed up as \"<filename>.old\"");
            // 
            // chkSeparateBaseClasses
            // 
            this.chkSeparateBaseClasses.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SeparateBaseClasses", true));
            this.chkSeparateBaseClasses.Location = new System.Drawing.Point(15, 210);
            this.chkSeparateBaseClasses.Name = "chkSeparateBaseClasses";
            this.chkSeparateBaseClasses.Size = new System.Drawing.Size(216, 17);
            this.chkSeparateBaseClasses.TabIndex = 10;
            this.chkSeparateBaseClasses.Text = "Separate base classes in a folder";
            this.toolTip1.SetToolTip(this.chkSeparateBaseClasses, "If checked, generated base classes go to \"<output path>\\Base\"");
            // 
            // chkSeparateNamespaces
            // 
            this.chkSeparateNamespaces.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SeparateNamespaces", true));
            this.chkSeparateNamespaces.Location = new System.Drawing.Point(15, 234);
            this.chkSeparateNamespaces.Name = "chkSeparateNamespaces";
            this.chkSeparateNamespaces.Size = new System.Drawing.Size(216, 17);
            this.chkSeparateNamespaces.TabIndex = 12;
            this.chkSeparateNamespaces.Text = "Separate Namespaces in folders";
            this.toolTip1.SetToolTip(this.chkSeparateNamespaces, "If checked, generated codes is distributed in folders according to their namespaces.");
            // 
            // chkSeparateClassComment
            // 
            this.chkSeparateClassComment.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "SeparateClassComment", true));
            this.chkSeparateClassComment.Location = new System.Drawing.Point(15, 258);
            this.chkSeparateClassComment.Name = "chkSeparateClassComment";
            this.chkSeparateClassComment.Size = new System.Drawing.Size(216, 17);
            this.chkSeparateClassComment.TabIndex = 12;
            this.chkSeparateClassComment.Text = "Separate class comments in a folder";
            this.toolTip1.SetToolTip(this.chkSeparateClassComment, "If checked, generated class comments files go to \"<output path>\\Comment\"");
            // 
            // lblUtilitiesNamespace
            // 
            this.lblUtilitiesNamespace.Location = new System.Drawing.Point(255, 50);
            this.lblUtilitiesNamespace.Name = "lblUtilitiesNamespace";
            this.lblUtilitiesNamespace.Size = new System.Drawing.Size(150, 16);
            this.lblUtilitiesNamespace.TabIndex = 28;
            this.lblUtilitiesNamespace.Text = "Utility classes namespace:";
            // 
            // txtUtilitiesNamespace
            // 
            this.txtUtilitiesNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "UtilitiesNamespace", true));
            this.txtUtilitiesNamespace.Location = new System.Drawing.Point(255, 66);
            this.txtUtilitiesNamespace.Name = "txtUtilitiesNamespace";
            this.txtUtilitiesNamespace.Size = new System.Drawing.Size(177, 20);
            this.txtUtilitiesNamespace.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtUtilitiesNamespace, "Specify the namespace where the <Database> and <DataPortalHookArgs> files will be created.");
            // 
            // lblUtilitiesFolder
            // 
            this.lblUtilitiesFolder.Location = new System.Drawing.Point(255, 94);
            this.lblUtilitiesFolder.Name = "lblUtilitiesFolder";
            this.lblUtilitiesFolder.Size = new System.Drawing.Size(150, 16);
            this.lblUtilitiesFolder.TabIndex = 28;
            this.lblUtilitiesFolder.Text = "Utility classes folder:";
            // 
            // txtUtilitiesFolder
            // 
            this.txtUtilitiesFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.generationParametersBindingSource, "UtilitiesFolder", true));
            this.txtUtilitiesFolder.Location = new System.Drawing.Point(255, 110);
            this.txtUtilitiesFolder.Name = "txtUtilitiesFolder";
            this.txtUtilitiesFolder.Size = new System.Drawing.Size(177, 20);
            this.txtUtilitiesFolder.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtUtilitiesFolder, "Specify the folder where the <Database> and <DataPortalHookArgs> files will be created." +
                "\r\nThis is relative to the project\'s output folder and is used only when namespaces aren't separated in folders.");
            //
            // chkGenerateStoredProcedures
            // 
            this.chkGenerateStoredProcedures.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateSprocs", true));
            this.chkGenerateStoredProcedures.Location = new System.Drawing.Point(255, 186);
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
            this.chkSpOneFile.Location = new System.Drawing.Point(255, 210);
            this.chkSpOneFile.Name = "chkSpOneFile";
            this.chkSpOneFile.Size = new System.Drawing.Size(216, 17);
            this.chkSpOneFile.TabIndex = 9;
            this.chkSpOneFile.Text = "Generate only one SP file per object";
            this.toolTip1.SetToolTip(this.chkSpOneFile,
                                     "If checked, creates only one file that contains all the\r\n" +
                                     "generated stored procedures for the business object");
            // 
            // chkOnlyNeededSprocs
            // 
            this.chkOnlyNeededSprocs.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "OnlyNeededSprocs", true));
            this.chkOnlyNeededSprocs.Location = new System.Drawing.Point(255, 234);
            this.chkOnlyNeededSprocs.Name = "chkOnlyNeededSprocs";
            this.chkOnlyNeededSprocs.Size = new System.Drawing.Size(216, 17);
            this.chkOnlyNeededSprocs.TabIndex = 9;
            this.chkOnlyNeededSprocs.Text = "Generate only needed SP";
            this.toolTip1.SetToolTip(this.chkOnlyNeededSprocs,
                                     "If checked, generates only stored procedures that are needed by the object stereotype,\r\n" +
                                     "ignoring criteria settings.");
            // 
            // chkGenerateDatabaseClass
            // 
            this.chkGenerateDatabaseClass.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.generationParametersBindingSource, "GenerateDatabaseClass", true));
            this.chkGenerateDatabaseClass.Location = new System.Drawing.Point(255, 258);
            this.chkGenerateDatabaseClass.Name = "chkGenerateDatabaseClass";
            this.chkGenerateDatabaseClass.Size = new System.Drawing.Size(216, 17);
            this.chkGenerateDatabaseClass.TabIndex = 11;
            this.chkGenerateDatabaseClass.Text = "Generate Database class";
            this.toolTip1.SetToolTip(this.chkGenerateDatabaseClass,
                                     "If checked, generates a \"Database.cs\" or \"Database.vb\" file.");
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
            this.projectParametersBindingSource.CurrentItemChanged += new System.EventHandler(this.generationParametersBindingSource_CurrentItemChanged);
            // 
            // generationParametersBindingSource
            // 
            this.generationParametersBindingSource.DataSource = typeof(CslaGenerator.Metadata.GenerationParameters);
            this.generationParametersBindingSource.CurrentItemChanged += new System.EventHandler(this.generationParametersBindingSource_CurrentItemChanged);
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
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.tabControl1);
            this.Name = "ProjectProperties";
            this.TabText = "Project Properties";
            this.Text = "Project Properties";
            this.tabControl1.ResumeLayout(false);
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
            this.tabGeneration.ResumeLayout(false);
            this.tabGeneration.PerformLayout();
            this.tabGenerationFiles.ResumeLayout(false);
            this.tabGenerationFiles.PerformLayout();
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
        private System.Windows.Forms.Button cmdSetDefault;
        private System.Windows.Forms.Button cmdUndo;
        internal System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.TabControl tabControl1;
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
        private System.Windows.Forms.TabPage tabGeneration;
        private System.Windows.Forms.TabPage tabGenerationFiles;
        private System.Windows.Forms.CheckBox chkSaveGenerationGeneral;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cboTarget;
        private System.Windows.Forms.Label lblOutputLanguage;
        private System.Windows.Forms.ComboBox cboOutputLanguage;
        private System.Windows.Forms.Label lblUIEnvironment;
        private System.Windows.Forms.ComboBox cboUIEnvironment;
        private System.Windows.Forms.Label lblGenerateAuthorization;
        private System.Windows.Forms.ComboBox cboGenerateAuthorization;
        private System.Windows.Forms.Label lblHeaderVerbosity;
        private System.Windows.Forms.ComboBox cboHeaderVerbosity;
        // private System.Windows.Forms.Label lblPropertyMode;
        // private System.Windows.Forms.ComboBox cboPropertyMode;
        private System.Windows.Forms.CheckBox chkNullableSupport;
        private System.Windows.Forms.CheckBox chkUseChildDataPortal;
        private System.Windows.Forms.CheckBox chkActiveObjects;
        private System.Windows.Forms.CheckBox chkUseBypassPropertyChecks;
        private System.Windows.Forms.CheckBox chkUseSingleCriteria;
        private System.Windows.Forms.CheckBox chkForceReadOnlyProperties;
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
        private System.Windows.Forms.Label lblUtilitiesNamespace;
        private System.Windows.Forms.TextBox txtUtilitiesNamespace;
        private System.Windows.Forms.Label lblUtilitiesFolder;
        private System.Windows.Forms.TextBox txtUtilitiesFolder;
        private System.Windows.Forms.CheckBox chkGenerateStoredProcedures;
        private System.Windows.Forms.CheckBox chkSpOneFile;
        private System.Windows.Forms.CheckBox chkOnlyNeededSprocs;
        private System.Windows.Forms.CheckBox chkGenerateDatabaseClass;
        private System.Windows.Forms.BindingSource generationParametersBindingSource;
        private System.Windows.Forms.BindingSource projectParametersBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdLoad;
    }
}
