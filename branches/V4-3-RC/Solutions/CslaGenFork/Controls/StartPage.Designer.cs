namespace CslaGenerator.Controls
{
    partial class StartPage
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(292, 273);
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.ScrollBarsEnabled = false;
            this.webBrowser.TabIndex = 0;
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.webBrowser);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.DockAreas = (WeifenLuo.WinFormsUI.Docking.DockAreas)
                             WeifenLuo.WinFormsUI.Docking.DockAreas.Document |
                             WeifenLuo.WinFormsUI.Docking.DockAreas.Float;
            this.TabText = "Output";
            this.Text = "Output";
            this.Name = "StartPage";
            this.TabText = "Start Page";
            this.Text = "Start Page";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.WebBrowser webBrowser;
    }
}
