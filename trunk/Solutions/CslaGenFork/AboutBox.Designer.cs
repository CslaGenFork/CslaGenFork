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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblAppDescription = new System.Windows.Forms.Label();
            this.lblAppCopyright = new System.Windows.Forms.Label();
            this.lblAssyVersion = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAppTitle.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.Location = new System.Drawing.Point(10, 10);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(321, 30);
            this.lblAppTitle.TabIndex = 1;
            this.lblAppTitle.Text = "<Title>";
            // 
            // lblAppDescription
            // 
            this.lblAppDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblAppDescription.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDescription.Location = new System.Drawing.Point(10, 45);
            this.lblAppDescription.Name = "lblAppDescription";
            this.lblAppDescription.Size = new System.Drawing.Size(321, 40);
            this.lblAppDescription.TabIndex = 1;
            this.lblAppDescription.Text = "<Description>";
            // 
            // lblAppCopyright
            // 
            this.lblAppCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblAppCopyright.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppCopyright.Location = new System.Drawing.Point(10, 90);
            this.lblAppCopyright.Name = "lblAppCopyright";
            this.lblAppCopyright.Size = new System.Drawing.Size(321, 40);
            this.lblAppCopyright.TabIndex = 1;
            this.lblAppCopyright.Text = "<Copyright>";
            // 
            // lblAssyVersion
            // 
            this.lblAssyVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblAssyVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssyVersion.Location = new System.Drawing.Point(10, 140);
            this.lblAssyVersion.Name = "lblAssyVersion";
            this.lblAssyVersion.Size = new System.Drawing.Size(321, 25);
            this.lblAssyVersion.TabIndex = 1;
            this.lblAssyVersion.Text = "<Version>";
            this.lblAssyVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button.Location = new System.Drawing.Point(280, 214);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 0;
            this.button.Text = "Close";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.lblAppTitle);
            this.panel.Controls.Add(this.lblAppDescription);
            this.panel.Controls.Add(this.lblAppCopyright);
            this.panel.Controls.Add(this.lblAssyVersion);
            this.panel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel.Location = new System.Drawing.Point(18, 15);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(337, 176);
            this.panel.TabIndex = 1;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button;
            this.ClientSize = new System.Drawing.Size(374, 249);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Csla Generator Fork";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblAppDescription;
        private System.Windows.Forms.Label lblAppCopyright;
        private System.Windows.Forms.Label lblAssyVersion;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Panel panel;

    }
}
