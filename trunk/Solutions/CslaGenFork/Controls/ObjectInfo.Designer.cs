namespace CslaGenerator.Controls
{
    partial class ObjectInfo
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
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid.Location = new System.Drawing.Point(0, 3);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(208, 283);
            this.propertyGrid.TabIndex = 0;
            // 
            // ObjectInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(208, 289);
            this.Controls.Add(this.propertyGrid);
            this.HideOnClose = true;
            this.Name = "ObjectInfo";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.DockAreas = (WeifenLuo.WinFormsUI.Docking.DockAreas)
                             WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft |
                             WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight |
                             WeifenLuo.WinFormsUI.Docking.DockAreas.Float;
            this.TabText = "Csla Object Info";
            this.Text = "Csla Object Info";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PropertyGrid propertyGrid;
    }
}