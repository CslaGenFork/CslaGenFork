using System;
using System.Windows.Forms;


namespace CslaGenerator.Controls
{
	/// <summary>
	/// Summary description for TextboxPlusBtn.
	/// </summary>
	public class TextboxPlusBtn : System.Windows.Forms.UserControl
	{
		// public events
		public delegate void ButtonClickedEventHandler(object sender, System.EventArgs e);
		public virtual event ButtonClickedEventHandler ButtonClicked;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.Button button;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TextboxPlusBtn()
		{
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button = new System.Windows.Forms.Button();
			this.textBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button
			// 
			this.button.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button.Location = new System.Drawing.Point(192, 0);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(27, 20);
			this.button.TabIndex = 29;
			this.button.Text = "...";
			this.button.Click += new System.EventHandler(this.button_Click);
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.AutoSize = false;
			this.textBox.BackColor = System.Drawing.SystemColors.Window;
			this.textBox.Location = new System.Drawing.Point(0, 0);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(190, 20);
			this.textBox.TabIndex = 28;
			this.textBox.Text = "";
			// 
			// TextboxPlusBtn
			// 
			this.Controls.Add(this.button);
			this.Controls.Add(this.textBox);
			this.Name = "TextboxPlusBtn";
			this.Size = new System.Drawing.Size(220, 20);
			this.ResumeLayout(false);

		}
		#endregion

		internal TextBox TextBox
		{
			get { return this.textBox; }
		}

		internal bool TextBoxEnabled
		{
			get { return this.textBox.Enabled; }
			set { this.textBox.Enabled = value; }
		}

		private void button_Click(object sender, System.EventArgs e)
		{
			ButtonClicked(sender, e);
		}	
	}
}
