using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

namespace CslaGenerator
{
	/// <summary>
	/// Summary description for GeneratorForm.
	/// </summary>
	public class GeneratorForm : System.Windows.Forms.Form
	{
		#region Constants
		private const int MIN_LAYOUT_WIDTH = 1024;
		private const int MIN_LAYOUT_HEIGHT = 749;
		#endregion

		#region Private Fields
		private GeneratorController _controller = null;
		private Size _currentLayoutSize = new Size(MIN_LAYOUT_WIDTH,MIN_LAYOUT_HEIGHT);
		#endregion

		#region Component Fields

		private System.Windows.Forms.Button btnNewObject;
		private System.Windows.Forms.Button btnLoadObject;
		private System.Windows.Forms.Button btnSaveObject;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.MenuItem mnuConnect;
		private System.Windows.Forms.TreeView tvwSchema;
		private System.Windows.Forms.Panel pnlSchema;
		private System.Windows.Forms.ListBox lstColumns;
		private System.Windows.Forms.Label lblColumns;
		private System.Windows.Forms.Label lblSchemaObjects;
		private System.Windows.Forms.Panel pnlSchemaContainer;
		private System.Windows.Forms.Button btnAddProperties;
		private System.Windows.Forms.SaveFileDialog sfdSave;
		private System.Windows.Forms.OpenFileDialog ofdLoad;
		private System.Windows.Forms.SaveFileDialog sfdGenerate;
		private System.Windows.Forms.ListBox lstObjects;
		private System.Windows.Forms.Label lblObjectHeader;
		private System.Windows.Forms.TextBox txtProjectName;
		private System.Windows.Forms.Label lblProject;
		private System.Windows.Forms.Button btnAddObject;
		private System.Windows.Forms.Button btnDeleteObject;
		private FolderBrowser fbGenerate;
		private System.Windows.Forms.Button btnDuplicate;
		private System.Windows.Forms.Label lblTargetDirectory;
		private System.Windows.Forms.TextBox txtTargetDirectory;
		private System.Windows.Forms.Button btnSelectDirectory;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Panel pnlObjects;
		private System.Windows.Forms.Panel pnlProjectButtons;
		private System.Windows.Forms.Panel pnlObjectButtons;
		private System.Windows.Forms.PropertyGrid pgGrid;
		private System.Windows.Forms.Label lblCurrentObject;
		private System.Windows.Forms.Panel pnlGrid;
		private System.Windows.Forms.Label lblDbSchema;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Constructors
		public GeneratorForm(GeneratorController controller)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Init();
			_controller = controller;
			
		}

		private void Init()
		{
			sfdSave.Filter = "CSLA Gen files (*.xml) | *.xml";
			sfdSave.DefaultExt = "xml";

			ofdLoad.Filter = sfdSave.Filter;
			ofdLoad.DefaultExt = sfdSave.DefaultExt;

			fbGenerate.OnlyFilesystem = true;

			Layout += new LayoutEventHandler(Form_Layout);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GeneratorForm));
			this.btnNewObject = new System.Windows.Forms.Button();
			this.btnLoadObject = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnAddProperties = new System.Windows.Forms.Button();
			this.pnlSchemaContainer = new System.Windows.Forms.Panel();
			this.pnlSchema = new System.Windows.Forms.Panel();
			this.tvwSchema = new System.Windows.Forms.TreeView();
			this.lstColumns = new System.Windows.Forms.ListBox();
			this.lblColumns = new System.Windows.Forms.Label();
			this.lblSchemaObjects = new System.Windows.Forms.Label();
			this.btnSaveObject = new System.Windows.Forms.Button();
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuConnect = new System.Windows.Forms.MenuItem();
			this.sfdSave = new System.Windows.Forms.SaveFileDialog();
			this.ofdLoad = new System.Windows.Forms.OpenFileDialog();
			this.sfdGenerate = new System.Windows.Forms.SaveFileDialog();
			this.lstObjects = new System.Windows.Forms.ListBox();
			this.lblObjectHeader = new System.Windows.Forms.Label();
			this.txtProjectName = new System.Windows.Forms.TextBox();
			this.lblProject = new System.Windows.Forms.Label();
			this.btnAddObject = new System.Windows.Forms.Button();
			this.btnDeleteObject = new System.Windows.Forms.Button();
			this.fbGenerate = new CslaGenerator.Util.FolderBrowser();
			this.btnDuplicate = new System.Windows.Forms.Button();
			this.lblTargetDirectory = new System.Windows.Forms.Label();
			this.txtTargetDirectory = new System.Windows.Forms.TextBox();
			this.btnSelectDirectory = new System.Windows.Forms.Button();
			this.pnlObjects = new System.Windows.Forms.Panel();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlProjectButtons = new System.Windows.Forms.Panel();
			this.pnlObjectButtons = new System.Windows.Forms.Panel();
			this.pgGrid = new System.Windows.Forms.PropertyGrid();
			this.lblCurrentObject = new System.Windows.Forms.Label();
			this.pnlGrid = new System.Windows.Forms.Panel();
			this.lblDbSchema = new System.Windows.Forms.Label();
			this.pnlSchemaContainer.SuspendLayout();
			this.pnlSchema.SuspendLayout();
			this.pnlObjects.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.pnlProjectButtons.SuspendLayout();
			this.pnlObjectButtons.SuspendLayout();
			this.pnlGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnNewObject
			// 
			this.btnNewObject.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnNewObject.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(192)));
			this.btnNewObject.ForeColor = System.Drawing.SystemColors.Window;
			this.btnNewObject.Location = new System.Drawing.Point(16, 0);
			this.btnNewObject.Name = "btnNewObject";
			this.btnNewObject.Size = new System.Drawing.Size(128, 40);
			this.btnNewObject.TabIndex = 1;
			this.btnNewObject.Text = "New CSLA Project";
			this.btnNewObject.Click += new System.EventHandler(this.btnNewObject_Click);
			// 
			// btnLoadObject
			// 
			this.btnLoadObject.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLoadObject.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(192)));
			this.btnLoadObject.ForeColor = System.Drawing.SystemColors.Window;
			this.btnLoadObject.Location = new System.Drawing.Point(160, 0);
			this.btnLoadObject.Name = "btnLoadObject";
			this.btnLoadObject.Size = new System.Drawing.Size(128, 40);
			this.btnLoadObject.TabIndex = 2;
			this.btnLoadObject.Text = "Load CSLA Project";
			this.btnLoadObject.Click += new System.EventHandler(this.btnLoadObject_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnConnect.BackColor = System.Drawing.Color.Orange;
			this.btnConnect.Enabled = false;
			this.btnConnect.Location = new System.Drawing.Point(16, 504);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(144, 40);
			this.btnConnect.TabIndex = 5;
			this.btnConnect.Text = "Connect to DB";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnAddProperties
			// 
			this.btnAddProperties.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAddProperties.BackColor = System.Drawing.Color.Orange;
			this.btnAddProperties.Enabled = false;
			this.btnAddProperties.Location = new System.Drawing.Point(296, 504);
			this.btnAddProperties.Name = "btnAddProperties";
			this.btnAddProperties.Size = new System.Drawing.Size(144, 40);
			this.btnAddProperties.TabIndex = 4;
			this.btnAddProperties.Text = "Add Properties for Selected Columns";
			this.btnAddProperties.Click += new System.EventHandler(this.btnAddProperties_Click);
			// 
			// pnlSchemaContainer
			// 
			this.pnlSchemaContainer.BackColor = System.Drawing.SystemColors.Control;
			this.pnlSchemaContainer.Controls.Add(this.pnlSchema);
			this.pnlSchemaContainer.Controls.Add(this.lstColumns);
			this.pnlSchemaContainer.Controls.Add(this.lblColumns);
			this.pnlSchemaContainer.Controls.Add(this.lblSchemaObjects);
			this.pnlSchemaContainer.Location = new System.Drawing.Point(0, 32);
			this.pnlSchemaContainer.Name = "pnlSchemaContainer";
			this.pnlSchemaContainer.Size = new System.Drawing.Size(488, 464);
			this.pnlSchemaContainer.TabIndex = 3;
			// 
			// pnlSchema
			// 
			this.pnlSchema.Controls.Add(this.tvwSchema);
			this.pnlSchema.Location = new System.Drawing.Point(8, 24);
			this.pnlSchema.Name = "pnlSchema";
			this.pnlSchema.Size = new System.Drawing.Size(216, 432);
			this.pnlSchema.TabIndex = 2;
			// 
			// tvwSchema
			// 
			this.tvwSchema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tvwSchema.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwSchema.ImageIndex = -1;
			this.tvwSchema.Location = new System.Drawing.Point(0, 0);
			this.tvwSchema.Name = "tvwSchema";
			this.tvwSchema.SelectedImageIndex = -1;
			this.tvwSchema.Size = new System.Drawing.Size(216, 432);
			this.tvwSchema.TabIndex = 1;
			// 
			// lstColumns
			// 
			this.lstColumns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstColumns.DisplayMember = "value";
			this.lstColumns.IntegralHeight = false;
			this.lstColumns.ItemHeight = 18;
			this.lstColumns.Location = new System.Drawing.Point(232, 24);
			this.lstColumns.Name = "lstColumns";
			this.lstColumns.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstColumns.Size = new System.Drawing.Size(216, 434);
			this.lstColumns.TabIndex = 3;
			this.lstColumns.ValueMember = "key";
			// 
			// lblColumns
			// 
			this.lblColumns.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblColumns.Location = new System.Drawing.Point(232, 8);
			this.lblColumns.Name = "lblColumns";
			this.lblColumns.Size = new System.Drawing.Size(120, 16);
			this.lblColumns.TabIndex = 4;
			this.lblColumns.Text = "Columns";
			// 
			// lblSchemaObjects
			// 
			this.lblSchemaObjects.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblSchemaObjects.Location = new System.Drawing.Point(8, 8);
			this.lblSchemaObjects.Name = "lblSchemaObjects";
			this.lblSchemaObjects.Size = new System.Drawing.Size(120, 16);
			this.lblSchemaObjects.TabIndex = 5;
			this.lblSchemaObjects.Text = "Schema Objects";
			// 
			// btnSaveObject
			// 
			this.btnSaveObject.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnSaveObject.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(192)));
			this.btnSaveObject.Enabled = false;
			this.btnSaveObject.ForeColor = System.Drawing.SystemColors.Window;
			this.btnSaveObject.Location = new System.Drawing.Point(304, 0);
			this.btnSaveObject.Name = "btnSaveObject";
			this.btnSaveObject.Size = new System.Drawing.Size(128, 40);
			this.btnSaveObject.TabIndex = 4;
			this.btnSaveObject.Text = "Save CSLA Project";
			this.btnSaveObject.Click += new System.EventHandler(this.btnSaveObject_Click);
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuConnect});
			this.menuItem1.Text = "File";
			// 
			// mnuConnect
			// 
			this.mnuConnect.Index = 0;
			this.mnuConnect.Text = "Connect...";
			this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
			// 
			// sfdSave
			// 
			this.sfdSave.FileName = "doc1";
			// 
			// lstObjects
			// 
			this.lstObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.lstObjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstObjects.DisplayMember = "value";
			this.lstObjects.IntegralHeight = false;
			this.lstObjects.ItemHeight = 18;
			this.lstObjects.Location = new System.Drawing.Point(0, 127);
			this.lstObjects.Name = "lstObjects";
			this.lstObjects.Size = new System.Drawing.Size(240, 430);
			this.lstObjects.TabIndex = 7;
			this.lstObjects.ValueMember = "key";
			// 
			// lblObjectHeader
			// 
			this.lblObjectHeader.BackColor = System.Drawing.Color.Orange;
			this.lblObjectHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblObjectHeader.ForeColor = System.Drawing.Color.Blue;
			this.lblObjectHeader.Location = new System.Drawing.Point(0, 104);
			this.lblObjectHeader.Name = "lblObjectHeader";
			this.lblObjectHeader.Size = new System.Drawing.Size(240, 24);
			this.lblObjectHeader.TabIndex = 8;
			this.lblObjectHeader.Text = "CSLA Objects";
			// 
			// txtProjectName
			// 
			this.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtProjectName.Location = new System.Drawing.Point(0, 30);
			this.txtProjectName.Name = "txtProjectName";
			this.txtProjectName.Size = new System.Drawing.Size(240, 23);
			this.txtProjectName.TabIndex = 10;
			this.txtProjectName.Text = "";
			// 
			// lblProject
			// 
			this.lblProject.BackColor = System.Drawing.Color.Orange;
			this.lblProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblProject.ForeColor = System.Drawing.Color.Blue;
			this.lblProject.Location = new System.Drawing.Point(0, 8);
			this.lblProject.Name = "lblProject";
			this.lblProject.Size = new System.Drawing.Size(240, 23);
			this.lblProject.TabIndex = 11;
			this.lblProject.Text = "Project Name";
			// 
			// btnAddObject
			// 
			this.btnAddObject.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(192)));
			this.btnAddObject.Enabled = false;
			this.btnAddObject.ForeColor = System.Drawing.SystemColors.Window;
			this.btnAddObject.Location = new System.Drawing.Point(8, 0);
			this.btnAddObject.Name = "btnAddObject";
			this.btnAddObject.Size = new System.Drawing.Size(104, 40);
			this.btnAddObject.TabIndex = 12;
			this.btnAddObject.Text = "Add Object";
			this.btnAddObject.Click += new System.EventHandler(this.btnAddObject_Click);
			// 
			// btnDeleteObject
			// 
			this.btnDeleteObject.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(192)));
			this.btnDeleteObject.Enabled = false;
			this.btnDeleteObject.ForeColor = System.Drawing.SystemColors.Window;
			this.btnDeleteObject.Location = new System.Drawing.Point(128, 0);
			this.btnDeleteObject.Name = "btnDeleteObject";
			this.btnDeleteObject.Size = new System.Drawing.Size(104, 40);
			this.btnDeleteObject.TabIndex = 13;
			this.btnDeleteObject.Text = "Delete Object";
			this.btnDeleteObject.Click += new System.EventHandler(this.btnDeleteObject_Click);
			// 
			// btnDuplicate
			// 
			this.btnDuplicate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(192)));
			this.btnDuplicate.Enabled = false;
			this.btnDuplicate.ForeColor = System.Drawing.SystemColors.Window;
			this.btnDuplicate.Location = new System.Drawing.Point(8, 48);
			this.btnDuplicate.Name = "btnDuplicate";
			this.btnDuplicate.Size = new System.Drawing.Size(104, 40);
			this.btnDuplicate.TabIndex = 15;
			this.btnDuplicate.Text = "Duplicate Object";
			this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
			// 
			// lblTargetDirectory
			// 
			this.lblTargetDirectory.BackColor = System.Drawing.Color.Orange;
			this.lblTargetDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTargetDirectory.ForeColor = System.Drawing.Color.Blue;
			this.lblTargetDirectory.Location = new System.Drawing.Point(0, 56);
			this.lblTargetDirectory.Name = "lblTargetDirectory";
			this.lblTargetDirectory.Size = new System.Drawing.Size(240, 23);
			this.lblTargetDirectory.TabIndex = 17;
			this.lblTargetDirectory.Text = "Output Directory";
			// 
			// txtTargetDirectory
			// 
			this.txtTargetDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTargetDirectory.Location = new System.Drawing.Point(0, 78);
			this.txtTargetDirectory.Name = "txtTargetDirectory";
			this.txtTargetDirectory.Size = new System.Drawing.Size(240, 23);
			this.txtTargetDirectory.TabIndex = 16;
			this.txtTargetDirectory.Text = "";
			// 
			// btnSelectDirectory
			// 
			this.btnSelectDirectory.Enabled = false;
			this.btnSelectDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectDirectory.Font = new System.Drawing.Font("Niagara Solid", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelectDirectory.Location = new System.Drawing.Point(216, 78);
			this.btnSelectDirectory.Name = "btnSelectDirectory";
			this.btnSelectDirectory.Size = new System.Drawing.Size(24, 23);
			this.btnSelectDirectory.TabIndex = 20;
			this.btnSelectDirectory.Text = "...";
			this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
			// 
			// pnlObjects
			// 
			this.pnlObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.pnlObjects.Controls.Add(this.btnSelectDirectory);
			this.pnlObjects.Controls.Add(this.lstObjects);
			this.pnlObjects.Controls.Add(this.lblObjectHeader);
			this.pnlObjects.Controls.Add(this.lblProject);
			this.pnlObjects.Controls.Add(this.txtProjectName);
			this.pnlObjects.Controls.Add(this.lblTargetDirectory);
			this.pnlObjects.Controls.Add(this.txtTargetDirectory);
			this.pnlObjects.Location = new System.Drawing.Point(8, 0);
			this.pnlObjects.Name = "pnlObjects";
			this.pnlObjects.Size = new System.Drawing.Size(240, 560);
			this.pnlObjects.TabIndex = 21;
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlSchemaContainer);
			this.pnlMain.Controls.Add(this.btnConnect);
			this.pnlMain.Controls.Add(this.btnAddProperties);
			this.pnlMain.Controls.Add(this.lblDbSchema);
			this.pnlMain.Location = new System.Drawing.Point(256, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(456, 560);
			this.pnlMain.TabIndex = 22;
			// 
			// pnlProjectButtons
			// 
			this.pnlProjectButtons.Controls.Add(this.btnNewObject);
			this.pnlProjectButtons.Controls.Add(this.btnLoadObject);
			this.pnlProjectButtons.Controls.Add(this.btnSaveObject);
			this.pnlProjectButtons.Location = new System.Drawing.Point(256, 568);
			this.pnlProjectButtons.Name = "pnlProjectButtons";
			this.pnlProjectButtons.Size = new System.Drawing.Size(456, 40);
			this.pnlProjectButtons.TabIndex = 24;
			// 
			// pnlObjectButtons
			// 
			this.pnlObjectButtons.Controls.Add(this.btnDeleteObject);
			this.pnlObjectButtons.Controls.Add(this.btnAddObject);
			this.pnlObjectButtons.Controls.Add(this.btnDuplicate);
			this.pnlObjectButtons.Location = new System.Drawing.Point(8, 568);
			this.pnlObjectButtons.Name = "pnlObjectButtons";
			this.pnlObjectButtons.Size = new System.Drawing.Size(240, 88);
			this.pnlObjectButtons.TabIndex = 25;
			// 
			// pgGrid
			// 
			this.pgGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pgGrid.BackColor = System.Drawing.Color.Gainsboro;
			this.pgGrid.CommandsBackColor = System.Drawing.Color.Gainsboro;
			this.pgGrid.CommandsForeColor = System.Drawing.Color.Blue;
			this.pgGrid.CommandsVisibleIfAvailable = true;
			this.pgGrid.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.pgGrid.LargeButtons = false;
			this.pgGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pgGrid.Location = new System.Drawing.Point(0, 32);
			this.pgGrid.Name = "pgGrid";
			this.pgGrid.Size = new System.Drawing.Size(288, 528);
			this.pgGrid.TabIndex = 0;
			this.pgGrid.Text = "PropertyGrid";
			this.pgGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.pgGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// lblCurrentObject
			// 
			this.lblCurrentObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentObject.BackColor = System.Drawing.Color.Orange;
			this.lblCurrentObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblCurrentObject.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCurrentObject.ForeColor = System.Drawing.Color.Blue;
			this.lblCurrentObject.Location = new System.Drawing.Point(0, 8);
			this.lblCurrentObject.Name = "lblCurrentObject";
			this.lblCurrentObject.Size = new System.Drawing.Size(288, 23);
			this.lblCurrentObject.TabIndex = 14;
			this.lblCurrentObject.Text = "Current CSLA Object Properties";
			// 
			// pnlGrid
			// 
			this.pnlGrid.Controls.Add(this.pgGrid);
			this.pnlGrid.Controls.Add(this.lblCurrentObject);
			this.pnlGrid.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.pnlGrid.Location = new System.Drawing.Point(720, 0);
			this.pnlGrid.Name = "pnlGrid";
			this.pnlGrid.Size = new System.Drawing.Size(288, 560);
			this.pnlGrid.TabIndex = 23;
			// 
			// lblDbSchema
			// 
			this.lblDbSchema.BackColor = System.Drawing.Color.Orange;
			this.lblDbSchema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDbSchema.ForeColor = System.Drawing.Color.Blue;
			this.lblDbSchema.Location = new System.Drawing.Point(0, 8);
			this.lblDbSchema.Name = "lblDbSchema";
			this.lblDbSchema.Size = new System.Drawing.Size(456, 23);
			this.lblDbSchema.TabIndex = 11;
			this.lblDbSchema.Text = "DbSchema";
			// 
			// GeneratorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(1016, 694);
			this.Controls.Add(this.pnlObjectButtons);
			this.Controls.Add(this.pnlProjectButtons);
			this.Controls.Add(this.pnlGrid);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlObjects);
			this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mnuMain;
			this.Name = "GeneratorForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "CSLA Object Generator v1.0";
			this.pnlSchemaContainer.ResumeLayout(false);
			this.pnlSchema.ResumeLayout(false);
			this.pnlObjects.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			this.pnlProjectButtons.ResumeLayout(false);
			this.pnlObjectButtons.ResumeLayout(false);
			this.pnlGrid.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Event Handlers
		private void btnAddProperties_Click(object sender, System.EventArgs e)
		{
			_controller.AddPropertiesForSelectedColumns();
		}

		private void btnAddObject_Click(object sender, System.EventArgs e)
		{
			_controller.AddNewObject();
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			_controller.Connect();
		}

		private void btnDeleteObject_Click(object sender, System.EventArgs e)
		{
			_controller.DeleteObject();
		}

		private void btnDuplicate_Click(object sender, System.EventArgs e)
		{
			_controller.DuplicateObject();
		}

		private void btnLoadObject_Click(object sender, System.EventArgs e)
		{
			DialogResult result = ofdLoad.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				Cursor.Current = Cursors.WaitCursor;
				_controller.Load(ofdLoad.FileName);
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnNewObject_Click(object sender, System.EventArgs e)
		{
			_controller.NewCslaUnit();
		}

		private void btnSaveObject_Click(object sender, System.EventArgs e)
		{
			DialogResult result = sfdSave.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				Cursor.Current = Cursors.WaitCursor;
				_controller.Save(sfdSave.FileName);
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSelectDirectory_Click(object sender, System.EventArgs e)
		{
			fbGenerate.StartLocation = FolderBrowser.FolderID.MyComputer;
			DialogResult result = fbGenerate.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				_controller.CurrentUnit.TargetDirectory = fbGenerate.DirectoryPath;
			}
		}

		private void mnuConnect_Click(object sender, System.EventArgs e)
		{
			_controller.Connect();
		}

		private void Form_Layout(object sender, LayoutEventArgs e)
		{
			SuspendLayout();
			Size newSize = new Size(0,0);
			if (this.Size.Width < MIN_LAYOUT_WIDTH) 
			{
				newSize.Width = MIN_LAYOUT_WIDTH;
			}
			else
			{
				newSize.Width = this.Size.Width;
			}

			if (this.Size.Height < MIN_LAYOUT_HEIGHT) 
			{
				newSize.Height = MIN_LAYOUT_HEIGHT;
			}
			else
			{
				newSize.Height = this.Size.Height;
			}

			if (!newSize.Equals(_currentLayoutSize))
			{
				LayoutPanels(newSize.Width - _currentLayoutSize.Width, newSize.Height - _currentLayoutSize.Height);
				_currentLayoutSize = newSize;
			}
			ResumeLayout();
		}

//		private void btnExecuteSelect_Click(object sender, System.EventArgs e)
//		{
//			Cursor.Current = Cursors.WaitCursor;
//			_controller.ExecuteSelect();
//			Cursor.Current = Cursors.WaitCursor;
//		}
//
//		private void btnExecuteDelete_Click(object sender, System.EventArgs e)
//		{
//			Cursor.Current = Cursors.WaitCursor;
//			_controller.ExecuteDelete();
//			Cursor.Current = Cursors.Default;
//		}
//
//		private void btnExecuteUpdate_Click(object sender, System.EventArgs e)
//		{
//			Cursor.Current = Cursors.WaitCursor;
//			_controller.ExecuteUpdate();
//			Cursor.Current = Cursors.Default;
//		}
//
//		private void btnExecuteInsert_Click(object sender, System.EventArgs e)
//		{
//			Cursor.Current = Cursors.WaitCursor;
//			_controller.ExecuteInsert();
//			Cursor.Current = Cursors.Default;
//		}
		#endregion

		#region Public Properties

		#endregion

		#region Internal Properties
		internal TreeView SchemaTree
		{
			get { return tvwSchema; }
		}

		internal ListBox ColumnList
		{
			get { return lstColumns; }
		}

		internal ListBox CslaObjectList
		{
			get { return lstObjects; }
		}

		internal TextBox ProjectNameTextBox
		{
			get { return txtProjectName; }
		}

		internal TextBox TargetDirectoryTextBox
		{
			get { return txtTargetDirectory; }
		}

		internal PropertyGrid PropertyGrid
		{
			get { return pgGrid; }
		}

		internal Button AddPropertiesButtton
		{
			get { return btnAddProperties; }
		}

		internal Button ConnectButton
		{
			get { return btnConnect; }
		}

		internal Button DuplicateButton
		{
			get { return btnDuplicate; }
		}

		internal Button SaveButton
		{
			get { return btnSaveObject; }
		}

		internal Button AddObjectButton
		{
			get { return btnAddObject; }
		}

		internal Button DeleteObjectButton
		{
			get { return btnDeleteObject; }
		}

		internal Button SelectDirectoryButton
		{
			get { return btnSelectDirectory; }
		}


		#endregion

		#region Private Methods
		private void LayoutPanels(int deltaWidth, int deltaHeight)
		{
			if (deltaWidth != 0)
			{  
				// split the width between main panel and grid panel
				deltaWidth /= 2;
				pnlGrid.Location = new Point(pnlGrid.Location.X + deltaWidth, pnlGrid.Location.Y);
				pnlGrid.Width += deltaWidth;

				pnlMain.Width += deltaWidth;
				lblDbSchema.Width += deltaWidth;
				pnlProjectButtons.Width += deltaWidth;

				pnlSchemaContainer.Width += deltaWidth;
				// split the diff between treeview and listview
				deltaWidth /= 2;
				pnlSchema.Width += deltaWidth;
				lstColumns.Location = new Point(lstColumns.Location.X + deltaWidth, lstColumns.Location.Y);
				lstColumns.Width += deltaWidth;
				lblColumns.Location = new Point(lblColumns.Location.X + deltaWidth, lblColumns.Location.Y);

			}

			if (deltaHeight != 0)
			{
				pnlObjectButtons.Location = new Point(pnlObjectButtons.Location.X, pnlObjectButtons.Location.Y + deltaHeight);
				pnlProjectButtons.Location = new Point(pnlProjectButtons.Location.X, pnlProjectButtons.Location.Y + deltaHeight);

				pnlMain.Height += deltaHeight;

				pnlSchemaContainer.Height += deltaHeight;
				pnlSchema.Height += deltaHeight;
				lstColumns.Height += deltaHeight;


				pnlGrid.Height += deltaHeight;

			}
		}
		#endregion



	}
}
