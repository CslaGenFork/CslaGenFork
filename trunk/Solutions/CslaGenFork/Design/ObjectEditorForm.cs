using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CslaGenerator.Design
{
	/// <summary>
	/// Summary description for ObjectEditorForm.
	/// </summary>
	public class ObjectEditorForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid pgEditor;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private object _object;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ObjectEditorForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pgEditor = new System.Windows.Forms.PropertyGrid();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pgEditor
			// 
			this.pgEditor.CommandsVisibleIfAvailable = true;
			this.pgEditor.Dock = System.Windows.Forms.DockStyle.Top;
			this.pgEditor.LargeButtons = false;
			this.pgEditor.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pgEditor.Name = "pgEditor";
			this.pgEditor.Size = new System.Drawing.Size(368, 312);
			this.pgEditor.TabIndex = 0;
			this.pgEditor.Text = "pgEditor";
			this.pgEditor.ViewBackColor = System.Drawing.SystemColors.Window;
			this.pgEditor.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(104, 336);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(192, 336);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ObjectEditorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 374);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnOK,
																		  this.pgEditor});
			this.Name = "ObjectEditorForm";
			this.Text = "Edit";
			this.ResumeLayout(false);

		}
		#endregion

		public object ObjectToEdit
		{
			get { return _object; }
			set 
			{ 
				_object = value;
				pgEditor.SelectedObject = _object;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
