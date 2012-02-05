namespace CslaGenerator.Controls
{
    partial class TextboxPlusBtn
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
            this.button.Click += new System.EventHandler(this.Button_Click);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button;
    }
}
