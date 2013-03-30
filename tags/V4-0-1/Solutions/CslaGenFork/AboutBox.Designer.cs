namespace CslaGenerator
{
    partial class AboutBox
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
            this.lblAssyVersion = new System.Windows.Forms.Label();
            this.lblAppCopyright = new System.Windows.Forms.Label();
            this.lblAppDescription = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAssyVersion
            // 
            this.lblAssyVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssyVersion.Location = new System.Drawing.Point(15, 166);
            this.lblAssyVersion.Name = "lblAssyVersion";
            this.lblAssyVersion.Size = new System.Drawing.Size(347, 25);
            this.lblAssyVersion.TabIndex = 1;
            this.lblAssyVersion.Text = "<Version>";
            this.lblAssyVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAppCopyright
            // 
            this.lblAppCopyright.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppCopyright.Location = new System.Drawing.Point(15, 116);
            this.lblAppCopyright.Name = "lblAppCopyright";
            this.lblAppCopyright.Size = new System.Drawing.Size(347, 50);
            this.lblAppCopyright.TabIndex = 6;
            this.lblAppCopyright.Text = "<Copyright>";
            // 
            // lblAppDescription
            // 
            this.lblAppDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDescription.Location = new System.Drawing.Point(15, 41);
            this.lblAppDescription.Name = "lblAppDescription";
            this.lblAppDescription.Size = new System.Drawing.Size(347, 75);
            this.lblAppDescription.TabIndex = 5;
            this.lblAppDescription.Text = "<Description>";
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(347, 25);
            this.lblAppTitle.TabIndex = 4;
            this.lblAppTitle.Text = "<Title>";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(287, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(374, 249);
            this.Controls.Add(this.lblAppCopyright);
            this.Controls.Add(this.lblAppDescription);
            this.Controls.Add(this.lblAppTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblAssyVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Csla Generator Fork";
            this.Load += new System.EventHandler(this.AboutBoxLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAssyVersion;
        private System.Windows.Forms.Label lblAppCopyright;
        private System.Windows.Forms.Label lblAppDescription;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Button button1;

    }
}
