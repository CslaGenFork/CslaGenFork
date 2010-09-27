using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CslaGenerator.Metadata;
using CslaGenerator.Util;

using CslaGenerator.Templates;
namespace CslaGenerator

{
	/// <summary>
	/// Summary description for GeneratorForm.
	/// </summary>
	public class GeneratorForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox chkActiveObjects;
		private System.Windows.Forms.CheckBox chkBackUpOldSource;
		private System.Windows.Forms.CheckBox chkSeparateNamespaces;
		private System.Windows.Forms.CheckBox chkGenerateStoredProcedures;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkSpOneFile;
		private System.Windows.Forms.ComboBox cboTarget;
		private System.Windows.Forms.CheckBox chkSeparateBaseClasses;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.CheckedListBox clbObjects;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabGeneration;
		private System.Windows.Forms.TabPage tabOutPut;
		private System.Windows.Forms.CheckBox chkSave;
		private System.Windows.Forms.MenuItem mnuAll;
		private System.Windows.Forms.MenuItem mnuNone;
		private System.Windows.Forms.ContextMenu selectionMenu;
		private System.Windows.Forms.Button cmdClose;
        private CheckBox chkUseDotDesignerFileNameConvention;
		private System.ComponentModel.IContainer components;
	
		#region Constructors
		public GeneratorForm(CslaGeneratorUnit unit)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			_unit = unit;
			
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorForm));
            this.chkActiveObjects = new System.Windows.Forms.CheckBox();
            this.chkBackUpOldSource = new System.Windows.Forms.CheckBox();
            this.chkSeparateNamespaces = new System.Windows.Forms.CheckBox();
            this.cboTarget = new System.Windows.Forms.ComboBox();
            this.chkGenerateStoredProcedures = new System.Windows.Forms.CheckBox();
            this.chkSpOneFile = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSeparateBaseClasses = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.clbObjects = new System.Windows.Forms.CheckedListBox();
            this.selectionMenu = new System.Windows.Forms.ContextMenu();
            this.mnuAll = new System.Windows.Forms.MenuItem();
            this.mnuNone = new System.Windows.Forms.MenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneration = new System.Windows.Forms.TabPage();
            this.chkUseDotDesignerFileNameConvention = new System.Windows.Forms.CheckBox();
            this.tabOutPut = new System.Windows.Forms.TabPage();
            this.cmdClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabGeneration.SuspendLayout();
            this.tabOutPut.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkActiveObjects
            // 
            this.chkActiveObjects.Location = new System.Drawing.Point(9, 68);
            this.chkActiveObjects.Name = "chkActiveObjects";
            this.chkActiveObjects.Size = new System.Drawing.Size(224, 24);
            this.chkActiveObjects.TabIndex = 0;
            this.chkActiveObjects.Text = "Generate Active Objects Code";
            this.toolTip1.SetToolTip(this.chkActiveObjects, "If checked it will output ActiveObjects code instead of plain CSLA.");
            // 
            // chkBackUpOldSource
            // 
            this.chkBackUpOldSource.Location = new System.Drawing.Point(9, 98);
            this.chkBackUpOldSource.Name = "chkBackUpOldSource";
            this.chkBackUpOldSource.Size = new System.Drawing.Size(216, 24);
            this.chkBackUpOldSource.TabIndex = 1;
            this.chkBackUpOldSource.Text = "BackUp old source files";
            this.toolTip1.SetToolTip(this.chkBackUpOldSource, "Replaced files will be backed up as \"<filename>.old\"");
            // 
            // chkSeparateNamespaces
            // 
            this.chkSeparateNamespaces.Location = new System.Drawing.Point(9, 186);
            this.chkSeparateNamespaces.Name = "chkSeparateNamespaces";
            this.chkSeparateNamespaces.Size = new System.Drawing.Size(272, 24);
            this.chkSeparateNamespaces.TabIndex = 2;
            this.chkSeparateNamespaces.Text = "Separate Namespaces in folders";
            this.toolTip1.SetToolTip(this.chkSeparateNamespaces, "Generated codes is distributed in folders according to their namespaces.");
            // 
            // cboTarget
            // 
            this.cboTarget.Location = new System.Drawing.Point(128, 36);
            this.cboTarget.Name = "cboTarget";
            this.cboTarget.Size = new System.Drawing.Size(144, 26);
            this.cboTarget.TabIndex = 3;
            this.cboTarget.Text = "cboTarget";
            // 
            // chkGenerateStoredProcedures
            // 
            this.chkGenerateStoredProcedures.Location = new System.Drawing.Point(9, 216);
            this.chkGenerateStoredProcedures.Name = "chkGenerateStoredProcedures";
            this.chkGenerateStoredProcedures.Size = new System.Drawing.Size(272, 24);
            this.chkGenerateStoredProcedures.TabIndex = 5;
            this.chkGenerateStoredProcedures.Text = "Generate Stored Procedures";
            this.toolTip1.SetToolTip(this.chkGenerateStoredProcedures, "Check this if you want to generate stored procedures for the objects that can gen" +
                    "erate them.");
            // 
            // chkSpOneFile
            // 
            this.chkSpOneFile.Location = new System.Drawing.Point(9, 246);
            this.chkSpOneFile.Name = "chkSpOneFile";
            this.chkSpOneFile.Size = new System.Drawing.Size(264, 24);
            this.chkSpOneFile.TabIndex = 6;
            this.chkSpOneFile.Text = "Generate only one SP file per object";
            this.toolTip1.SetToolTip(this.chkSpOneFile, "Check this if you want to create only one file that contains all the generated st" +
                    "ored procedures for the business object");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Target Framework:";
            // 
            // chkSeparateBaseClasses
            // 
            this.chkSeparateBaseClasses.Location = new System.Drawing.Point(9, 156);
            this.chkSeparateBaseClasses.Name = "chkSeparateBaseClasses";
            this.chkSeparateBaseClasses.Size = new System.Drawing.Size(248, 24);
            this.chkSeparateBaseClasses.TabIndex = 8;
            this.chkSeparateBaseClasses.Text = "Separate base classes in a folder";
            this.toolTip1.SetToolTip(this.chkSeparateBaseClasses, "Generated code goes to \"<output path>\\Base\"");
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(456, 329);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(88, 32);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // clbObjects
            // 
            this.clbObjects.CheckOnClick = true;
            this.clbObjects.ContextMenu = this.selectionMenu;
            this.clbObjects.Location = new System.Drawing.Point(315, 38);
            this.clbObjects.Name = "clbObjects";
            this.clbObjects.Size = new System.Drawing.Size(296, 238);
            this.clbObjects.TabIndex = 10;
            this.clbObjects.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbObjects_ItemCheck);
            // 
            // selectionMenu
            // 
            this.selectionMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAll,
            this.mnuNone});
            // 
            // mnuAll
            // 
            this.mnuAll.Index = 0;
            this.mnuAll.Text = "Select All";
            this.mnuAll.Click += new System.EventHandler(this.mnuAll_Click);
            // 
            // mnuNone
            // 
            this.mnuNone.Index = 1;
            this.mnuNone.Text = "Select None";
            this.mnuNone.Click += new System.EventHandler(this.mnuNone_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(312, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Objects to generate:";
            // 
            // chkSave
            // 
            this.chkSave.Checked = true;
            this.chkSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSave.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSave.Location = new System.Drawing.Point(8, 14);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(272, 21);
            this.chkSave.TabIndex = 12;
            this.chkSave.Text = "Save project before generating";
            this.toolTip1.SetToolTip(this.chkSave, "This is enabled by default every time you open the generation form.");
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(16, 329);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(432, 32);
            this.progressBar1.TabIndex = 12;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(15, 8);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(590, 267);
            this.txtOutput.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGeneration);
            this.tabControl1.Controls.Add(this.tabOutPut);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 315);
            this.tabControl1.TabIndex = 15;
            // 
            // tabGeneration
            // 
            this.tabGeneration.Controls.Add(this.chkUseDotDesignerFileNameConvention);
            this.tabGeneration.Controls.Add(this.chkSave);
            this.tabGeneration.Controls.Add(this.chkActiveObjects);
            this.tabGeneration.Controls.Add(this.chkBackUpOldSource);
            this.tabGeneration.Controls.Add(this.chkSeparateNamespaces);
            this.tabGeneration.Controls.Add(this.cboTarget);
            this.tabGeneration.Controls.Add(this.chkGenerateStoredProcedures);
            this.tabGeneration.Controls.Add(this.chkSpOneFile);
            this.tabGeneration.Controls.Add(this.label1);
            this.tabGeneration.Controls.Add(this.chkSeparateBaseClasses);
            this.tabGeneration.Controls.Add(this.clbObjects);
            this.tabGeneration.Controls.Add(this.label2);
            this.tabGeneration.Location = new System.Drawing.Point(4, 27);
            this.tabGeneration.Name = "tabGeneration";
            this.tabGeneration.Size = new System.Drawing.Size(616, 284);
            this.tabGeneration.TabIndex = 0;
            this.tabGeneration.Text = "Generation Parameters";
            // 
            // chkUseDotDesignerFileNameConvention
            // 
            this.chkUseDotDesignerFileNameConvention.AutoSize = true;
            this.chkUseDotDesignerFileNameConvention.Location = new System.Drawing.Point(9, 128);
            this.chkUseDotDesignerFileNameConvention.Name = "chkUseDotDesignerFileNameConvention";
            this.chkUseDotDesignerFileNameConvention.Size = new System.Drawing.Size(198, 22);
            this.chkUseDotDesignerFileNameConvention.TabIndex = 14;
            this.chkUseDotDesignerFileNameConvention.Text = "Use \".Designer\" in file names";
            this.chkUseDotDesignerFileNameConvention.UseVisualStyleBackColor = true;
            // 
            // tabOutPut
            // 
            this.tabOutPut.Controls.Add(this.txtOutput);
            this.tabOutPut.Location = new System.Drawing.Point(4, 27);
            this.tabOutPut.Name = "tabOutPut";
            this.tabOutPut.Size = new System.Drawing.Size(616, 284);
            this.tabOutPut.TabIndex = 1;
            this.tabOutPut.Text = "Output";
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(552, 329);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(80, 32);
            this.cmdClose.TabIndex = 16;
            this.cmdClose.Text = "&Close";
            // 
            // GeneratorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(642, 369);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnGenerate);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GeneratorForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSLA Object Generator v1.0";
            this.Load += new System.EventHandler(this.GeneratorForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneration.ResumeLayout(false);
            this.tabGeneration.PerformLayout();
            this.tabOutPut.ResumeLayout(false);
            this.tabOutPut.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private CslaGeneratorUnit _unit;
		private CodeGenerator _generatorInstance;
		
		private bool _generating=false;
        public event EventHandler RequestSave;

		#region OnRequestSave
		/// <summary>
		/// Triggers the RequestSave event.
		/// </summary>
		public virtual void OnRequestSave(EventArgs ea)
		{
			if (RequestSave != null)
				RequestSave(this, ea);
		}
		#endregion
        		
		#region properties...
		
        //private CodeGenerator GeneratorInstance1
        //{
        //    get
        //    {
        //        if (_generatorInstance == null)
        //        {
        //            _generatorInstance = new CodeGenerator(_unit.TargetDirectory);
        //            _generatorInstance.Step +=new CslaGenerator.Templates.CodeGenerator.GenerationInformationDelegate(_generatorInstance_Step);
        //            _generatorInstance.Finilized += new EventHandler(_generatorInstance_Finilized);
        //            _generatorInstance.GenerationInformation += new CslaGenerator.Templates.CodeGenerator.GenerationInformationDelegate(_generatorInstance_GenerationInformation);
        //        }
        //        return _generatorInstance;
        //    }
        //}

		
		#endregion

		#region event handlers...
		
		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			btnGenerate.Enabled=false;
			if (!_generating)
			{
				SaveInfo();
                if (chkSave.Checked)
                {
                    try
                    {
                        OnRequestSave(new EventArgs());
                    }
                    catch (Exception ex)
                    {
                        DialogResult dr;
                        dr = MessageBox.Show("The project failed to save. Would you like to continue anyway?" +
                             Environment.NewLine + Environment.NewLine + "Exception Details:" +
                             Environment.NewLine + ex.Message, "Cslagen", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (dr == DialogResult.No)
                        {
                            btnGenerate.Enabled = true;
                            return;
                        }
                    }
                }
				try
				{
					System.Threading.Thread thd;
					System.Threading.ThreadStart start = new System.Threading.ThreadStart(Start);
					thd = new System.Threading.Thread(start);
					btnGenerate.Text = "&Abort";
					txtOutput.Clear();
					progressBar1.Maximum = clbObjects.CheckedItems.Count;
					tabControl1.SelectedIndex = 1;
					cmdClose.Enabled = false;
					thd.Start();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error Generating Code:" + Environment.NewLine + Environment.NewLine + ex.Message);
				}
			}
			else
			{
				this._generatorInstance.Abort();
			}
		}

		private void clbObjects_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			CslaObjectInfo item = (CslaObjectInfo)clbObjects.Items[e.Index];
			item.Generate = (e.NewValue == CheckState.Checked) ? true : false;
		}

		private void GeneratorForm_Load(object sender, System.EventArgs e)
		{
			foreach (string str in Enum.GetNames(typeof(TargetFramework)))
			{
				cboTarget.Items.Add(str);
			}
			
			LoadInfo();
			LoadObjects();
			clbObjects.Focus();
		}

		private void mnuAll_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < clbObjects.Items.Count; i++)
			{
				clbObjects.SetItemChecked(i,true);
			}
		}
		private void mnuNone_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < clbObjects.Items.Count; i++)
			{
				clbObjects.SetItemChecked(i,false);
			}
		}

		#endregion
		
		#region Thread Safe Handlers

        delegate void MessageDelegate(string message);
		private void _generatorInstance_Step(string e)
		{
			this.Invoke(new MessageDelegate(DoStep), new object[] {e});
		}

		private void _generatorInstance_Finilized(object sender, EventArgs e)
		{
			this.Invoke(new MethodInvoker(DoFinalize));
		}

		private void _generatorInstance_GenerationInformation(string e)
		{
			this.Invoke(new MessageDelegate(DisplayInfo), new object[] {e});
		}

		#endregion
		
		#region Private Methods
        void Start()
        {
            int index = 0;
            CslaObjectInfo[] GenerateObjects = new CslaObjectInfo[clbObjects.CheckedItems.Count];
            foreach (CslaObjectInfo obj in clbObjects.CheckedItems)
            {
                GenerateObjects[index] = obj;
                index++;
            }
            string targetDir = _unit.TargetDirectory;
            if (targetDir.StartsWith(".") || targetDir.StartsWith(".."))
            {
                targetDir = targetDir + @"\" + targetDir;
            }
            _generatorInstance = new CodeGenerator(targetDir);
            _generatorInstance.Step += new CslaGenerator.Templates.CodeGenerator.GenerationInformationDelegate(_generatorInstance_Step);
            _generatorInstance.Finilized += new EventHandler(_generatorInstance_Finilized);
            _generatorInstance.GenerationInformation += new CslaGenerator.Templates.CodeGenerator.GenerationInformationDelegate(_generatorInstance_GenerationInformation);
            _generatorInstance.GenerateProject(_unit, GeneratorController.Current.CurrentFilePath);
        }
	
		void DoStep(string objectName)
		{
			txtOutput.AppendText(new String('=',70) + Environment.NewLine 
                + objectName + ":" + Environment.NewLine);
			if (_generating)
				progressBar1.Value++;
			else
				progressBar1.Value = progressBar1.Minimum;
			_generating=true;
			btnGenerate.Enabled=true;
		}
		void DoFinalize()
		{
            txtOutput.AppendText(Environment.NewLine + "Done!");
			progressBar1.Value=progressBar1.Maximum;
			_generating=false;
			btnGenerate.Text = "&Generate";
			btnGenerate.Enabled=true;
			cmdClose.Enabled = true;
            
            _generatorInstance.Step -= new CslaGenerator.Templates.CodeGenerator.GenerationInformationDelegate(_generatorInstance_Step);
            _generatorInstance.Finilized -= new EventHandler(_generatorInstance_Finilized);
            _generatorInstance.GenerationInformation -= new CslaGenerator.Templates.CodeGenerator.GenerationInformationDelegate(_generatorInstance_GenerationInformation);
            _generatorInstance = null;
		}
		void DisplayInfo(string msg)
		{
            txtOutput.AppendText(msg + Environment.NewLine);
			txtOutput.SelectionStart= txtOutput.Text.Length;
		}


		void LoadObjects()
		{
			foreach (CslaObjectInfo obj in _unit.CslaObjects)
			{
				clbObjects.Items.Add(obj, obj.Generate);
			}
		}

		void LoadInfo()
		{
			GenerationParameters p = _unit.GenerationParams;
			cboTarget.SelectedItem = p.TargetFramework.ToString();
			chkActiveObjects.Checked = p.ActiveObjects;
			chkBackUpOldSource.Checked = p.BackupOldSource;
			chkGenerateStoredProcedures.Checked = p.GenerateSprocs;
			chkSpOneFile.Checked = p.OneSpFilePerObject;
			chkSeparateBaseClasses.Checked = p.SeparateBaseClasses;
			chkSeparateNamespaces.Checked = p.SeparateNamespaces;
            chkUseDotDesignerFileNameConvention.Checked = p.UseDotDesignerFileNameConvention;
		}

		void SaveInfo()
		{
			GenerationParameters p = _unit.GenerationParams;
			p.TargetFramework = (TargetFramework)Enum.Parse(typeof(TargetFramework),(string)cboTarget.SelectedItem);
			p.ActiveObjects = chkActiveObjects.Checked; 
			p.BackupOldSource = chkBackUpOldSource.Checked;
			p.GenerateSprocs = chkGenerateStoredProcedures.Checked;
			p.OneSpFilePerObject = chkSpOneFile.Checked;
			p.SeparateBaseClasses = chkSeparateBaseClasses.Checked;
			p.SeparateNamespaces = chkSeparateNamespaces.Checked;
            p.UseDotDesignerFileNameConvention = chkUseDotDesignerFileNameConvention.Checked;
		}
		
		#endregion


	}
}
