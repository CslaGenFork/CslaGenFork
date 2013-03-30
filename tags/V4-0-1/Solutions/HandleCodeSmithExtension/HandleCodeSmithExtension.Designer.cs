namespace HandleCodeSmithExtension
{
    partial class HandleCodeSmithExtension
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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.InstallLbl1 = new System.Windows.Forms.Label();
            this.InstallLbl2 = new System.Windows.Forms.Label();
            this.InstallCodeSmith = new System.Windows.Forms.Button();
            this.UninstallLbl1 = new System.Windows.Forms.Label();
            this.UninstallLbl2 = new System.Windows.Forms.Label();
            this.UninstallCodeSmith = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(12, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(32, 32);
            this.PictureBox.TabIndex = 2;
            this.PictureBox.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(50, 20);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(279, 24);
            this.Title.TabIndex = 1;
            this.Title.Text = "CodeSmith installer && uninstaller";
            // 
            // InstallLbl1
            // 
            this.InstallLbl1.AutoSize = true;
            this.InstallLbl1.Location = new System.Drawing.Point(12, 81);
            this.InstallLbl1.Name = "InstallLbl1";
            this.InstallLbl1.Size = new System.Drawing.Size(0, 13);
            this.InstallLbl1.TabIndex = 5;
            // 
            // InstallLbl2
            // 
            this.InstallLbl2.AutoSize = true;
            this.InstallLbl2.Location = new System.Drawing.Point(12, 97);
            this.InstallLbl2.Name = "InstallLbl2";
            this.InstallLbl2.Size = new System.Drawing.Size(0, 13);
            this.InstallLbl2.TabIndex = 5;
            // 
            // InstallCodeSmith
            // 
            this.InstallCodeSmith.Location = new System.Drawing.Point(12, 115);
            this.InstallCodeSmith.Name = "InstallCodeSmith";
            this.InstallCodeSmith.Size = new System.Drawing.Size(75, 23);
            this.InstallCodeSmith.TabIndex = 0;
            this.InstallCodeSmith.Text = "Install";
            this.InstallCodeSmith.UseVisualStyleBackColor = true;
            this.InstallCodeSmith.Click += new System.EventHandler(this.InstallCodeSmithClick);
            // 
            // UninstallLbl1
            // 
            this.UninstallLbl1.AutoSize = true;
            this.UninstallLbl1.Location = new System.Drawing.Point(12, 156);
            this.UninstallLbl1.Name = "UninstallLbl1";
            this.UninstallLbl1.Size = new System.Drawing.Size(0, 13);
            this.UninstallLbl1.TabIndex = 6;
            // 
            // UninstallLbl2
            // 
            this.UninstallLbl2.AutoSize = true;
            this.UninstallLbl2.Location = new System.Drawing.Point(12, 172);
            this.UninstallLbl2.Name = "UninstallLbl2";
            this.UninstallLbl2.Size = new System.Drawing.Size(0, 13);
            this.UninstallLbl2.TabIndex = 6;
            // 
            // UninstallCodeSmith
            // 
            this.UninstallCodeSmith.Location = new System.Drawing.Point(12, 190);
            this.UninstallCodeSmith.Name = "UninstallCodeSmith";
            this.UninstallCodeSmith.Size = new System.Drawing.Size(75, 23);
            this.UninstallCodeSmith.TabIndex = 3;
            this.UninstallCodeSmith.Text = "Uninstall";
            this.UninstallCodeSmith.UseVisualStyleBackColor = true;
            this.UninstallCodeSmith.Click += new System.EventHandler(this.UninstallCodeSmithClick);
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(159, 235);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // HandleCodeSmithExtension
            // 
            this.AcceptButton = this.ExitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(392, 273);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.UninstallCodeSmith);
            this.Controls.Add(this.UninstallLbl2);
            this.Controls.Add(this.UninstallLbl1);
            this.Controls.Add(this.InstallCodeSmith);
            this.Controls.Add(this.InstallLbl2);
            this.Controls.Add(this.InstallLbl1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.PictureBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "HandleCodeSmithExtension";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeSmith Extension Handler";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label InstallLbl1;
        private System.Windows.Forms.Label InstallLbl2;
        private System.Windows.Forms.Label UninstallLbl1;
        private System.Windows.Forms.Label UninstallLbl2;
        private System.Windows.Forms.Button InstallCodeSmith;
        private System.Windows.Forms.Button UninstallCodeSmith;
        private System.Windows.Forms.Button ExitButton;
    }
}

