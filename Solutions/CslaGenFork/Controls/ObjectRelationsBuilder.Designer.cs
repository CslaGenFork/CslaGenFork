namespace CslaGenerator.Controls
{
    partial class ObjectRelationsBuilder
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
            this.components = new System.ComponentModel.Container();
            this.formPanel = new System.Windows.Forms.Panel();
            this.listEntities1 = new System.Windows.Forms.ListBox();
            this.listEntities2 = new System.Windows.Forms.ListBox();
            this.listEntities3 = new System.Windows.Forms.ListBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.AllObjectsTab = new System.Windows.Forms.TabPage();
            this.addButton1 = new System.Windows.Forms.Button();
            this.removeButton1 = new System.Windows.Forms.Button();
            this.upButton1 = new System.Windows.Forms.Button();
            this.downButton1 = new System.Windows.Forms.Button();
            this.buildButton1 = new System.Windows.Forms.Button();
            this.buildAllButton1 = new System.Windows.Forms.Button();
            this.propGrid1 = new System.Windows.Forms.PropertyGrid();
            this.OneToMultipleTab = new System.Windows.Forms.TabPage();
            this.addButton2 = new System.Windows.Forms.Button();
            this.removeButton2 = new System.Windows.Forms.Button();
            this.upButton2 = new System.Windows.Forms.Button();
            this.downButton2 = new System.Windows.Forms.Button();
            this.buildButton2 = new System.Windows.Forms.Button();
            this.buildAllButton2 = new System.Windows.Forms.Button();
            this.propGrid2 = new System.Windows.Forms.PropertyGrid();
            this.MultipleToMultipleTab = new System.Windows.Forms.TabPage();
            this.addButton3 = new System.Windows.Forms.Button();
            this.removeButton3 = new System.Windows.Forms.Button();
            this.upButton3 = new System.Windows.Forms.Button();
            this.downButton3 = new System.Windows.Forms.Button();
            this.buildButton3 = new System.Windows.Forms.Button();
            this.buildAllButton3 = new System.Windows.Forms.Button();
            this.propGrid3 = new System.Windows.Forms.PropertyGrid();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TabControl.SuspendLayout();
            this.AllObjectsTab.SuspendLayout();
            this.OneToMultipleTab.SuspendLayout();
            this.MultipleToMultipleTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // formPanel
            // 
            this.formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.formPanel.Location = new System.Drawing.Point(0, 358);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(554, 36);
            this.formPanel.TabIndex = 0;
            // 
            // listEntities1
            // 
            this.listEntities1.FormattingEnabled = true;
            this.listEntities1.Location = new System.Drawing.Point(6, 6);
            this.listEntities1.Name = "listEntities1";
            this.listEntities1.Size = new System.Drawing.Size(215, 303);
            this.listEntities1.TabIndex = 1;
            this.listEntities1.SelectedIndexChanged += new System.EventHandler(this.ListEntities1_SelectedIndexChanged);
            // 
            // listEntities2
            // 
            this.listEntities2.FormattingEnabled = true;
            this.listEntities2.Location = new System.Drawing.Point(6, 6);
            this.listEntities2.Name = "listEntities2";
            this.listEntities2.Size = new System.Drawing.Size(215, 303);
            this.listEntities2.TabIndex = 1;
            this.listEntities2.SelectedIndexChanged += new System.EventHandler(this.ListEntities2_SelectedIndexChanged);
            // 
            // listEntities3
            // 
            this.listEntities3.FormattingEnabled = true;
            this.listEntities3.Location = new System.Drawing.Point(6, 6);
            this.listEntities3.Name = "listEntities3";
            this.listEntities3.Size = new System.Drawing.Size(215, 303);
            this.listEntities3.TabIndex = 1;
            this.listEntities3.SelectedIndexChanged += new System.EventHandler(this.ListEntities3_SelectedIndexChanged);
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.AllObjectsTab);
            this.TabControl.Controls.Add(this.OneToMultipleTab);
            this.TabControl.Controls.Add(this.MultipleToMultipleTab);
            this.TabControl.Location = new System.Drawing.Point(13, 13);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(529, 341);
            this.TabControl.TabIndex = 5;
            this.TabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
            // 
            // AllObjectsTab
            // 
            this.AllObjectsTab.Controls.Add(this.addButton1);
            this.AllObjectsTab.Controls.Add(this.removeButton1);
            this.AllObjectsTab.Controls.Add(this.upButton1);
            this.AllObjectsTab.Controls.Add(this.downButton1);
            this.AllObjectsTab.Controls.Add(this.buildButton1);
            this.AllObjectsTab.Controls.Add(this.buildAllButton1);
            this.AllObjectsTab.Controls.Add(this.listEntities1);
            this.AllObjectsTab.Controls.Add(this.propGrid1);
            this.AllObjectsTab.Location = new System.Drawing.Point(4, 22);
            this.AllObjectsTab.Name = "AllObjectsTab";
            this.AllObjectsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AllObjectsTab.Size = new System.Drawing.Size(521, 315);
            this.AllObjectsTab.TabIndex = 0;
            this.AllObjectsTab.Text = "All Object Relations";
            this.AllObjectsTab.UseVisualStyleBackColor = true;
            // 
            // addButton1
            // 
            this.addButton1.Image = global::CslaGenerator.Properties.Resources.plus_sign;
            this.addButton1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.addButton1.Location = new System.Drawing.Point(228, 7);
            this.addButton1.Name = "addButton1";
            this.addButton1.Size = new System.Drawing.Size(23, 23);
            this.addButton1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.addButton1, "Add a new object relation (Multiple to Multiple).");
            this.addButton1.UseVisualStyleBackColor = true;
            this.addButton1.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton1
            // 
            this.removeButton1.Image = global::CslaGenerator.Properties.Resources.minus_sign;
            this.removeButton1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.removeButton1.Location = new System.Drawing.Point(228, 36);
            this.removeButton1.Name = "removeButton1";
            this.removeButton1.Size = new System.Drawing.Size(23, 23);
            this.removeButton1.TabIndex = 3;
            this.removeButton1.UseVisualStyleBackColor = true;
            this.removeButton1.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // upButton1
            // 
            this.upButton1.Image = global::CslaGenerator.Properties.Resources.arrow_up;
            this.upButton1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.upButton1.Location = new System.Drawing.Point(228, 75);
            this.upButton1.Name = "upButton1";
            this.upButton1.Size = new System.Drawing.Size(23, 23);
            this.upButton1.TabIndex = 6;
            this.upButton1.UseVisualStyleBackColor = true;
            this.upButton1.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton1
            // 
            this.downButton1.Image = global::CslaGenerator.Properties.Resources.arrow_down;
            this.downButton1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.downButton1.Location = new System.Drawing.Point(228, 104);
            this.downButton1.Name = "downButton1";
            this.downButton1.Size = new System.Drawing.Size(23, 23);
            this.downButton1.TabIndex = 7;
            this.downButton1.UseVisualStyleBackColor = true;
            this.downButton1.Click += new System.EventHandler(this.downButton_Click);
            // 
            // buildButton1
            // 
            this.buildButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buildButton1.Image = global::CslaGenerator.Properties.Resources.build;
            this.buildButton1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buildButton1.Location = new System.Drawing.Point(228, 250);
            this.buildButton1.Name = "buildButton1";
            this.buildButton1.Size = new System.Drawing.Size(23, 23);
            this.buildButton1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buildButton1, "Check and build the selected object relation. You will be asked to confirm the build.");
            this.buildButton1.UseVisualStyleBackColor = true;
            this.buildButton1.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // buildAllButton1
            // 
            this.buildAllButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buildAllButton1.Image = global::CslaGenerator.Properties.Resources.build_all;
            this.buildAllButton1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buildAllButton1.Location = new System.Drawing.Point(228, 286);
            this.buildAllButton1.Name = "buildAllButton1";
            this.buildAllButton1.Size = new System.Drawing.Size(23, 23);
            this.buildAllButton1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buildAllButton1, "Check and build all object relations. You will be asked to confirm the build.");
            this.buildAllButton1.UseVisualStyleBackColor = true;
            this.buildAllButton1.Click += new System.EventHandler(this.buildAllButton_Click);
            // 
            // propGrid1
            // 
            this.propGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propGrid1.Location = new System.Drawing.Point(263, 10);
            this.propGrid1.Name = "propGrid1";
            this.propGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propGrid1.Size = new System.Drawing.Size(252, 299);
            this.propGrid1.TabIndex = 4;
            // 
            // OneToMultipleTab
            // 
            this.OneToMultipleTab.Controls.Add(this.addButton2);
            this.OneToMultipleTab.Controls.Add(this.removeButton2);
            this.OneToMultipleTab.Controls.Add(this.upButton2);
            this.OneToMultipleTab.Controls.Add(this.downButton2);
            this.OneToMultipleTab.Controls.Add(this.buildButton2);
            this.OneToMultipleTab.Controls.Add(this.buildAllButton2);
            this.OneToMultipleTab.Controls.Add(this.listEntities2);
            this.OneToMultipleTab.Controls.Add(this.propGrid2);
            this.OneToMultipleTab.Location = new System.Drawing.Point(4, 22);
            this.OneToMultipleTab.Name = "OneToMultipleTab";
            this.OneToMultipleTab.Padding = new System.Windows.Forms.Padding(3);
            this.OneToMultipleTab.Size = new System.Drawing.Size(521, 315);
            this.OneToMultipleTab.TabIndex = 1;
            this.OneToMultipleTab.Text = "1 to N Relations";
            this.OneToMultipleTab.UseVisualStyleBackColor = true;
            // 
            // addButton2
            // 
            this.addButton2.Image = global::CslaGenerator.Properties.Resources.plus_sign;
            this.addButton2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.addButton2.Location = new System.Drawing.Point(228, 7);
            this.addButton2.Name = "addButton2";
            this.addButton2.Size = new System.Drawing.Size(23, 23);
            this.addButton2.TabIndex = 2;
            this.toolTip1.SetToolTip(this.addButton2, "Add a new object relation (One to Multiple).");
            this.addButton2.UseVisualStyleBackColor = true;
            this.addButton2.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton2
            // 
            this.removeButton2.Image = global::CslaGenerator.Properties.Resources.minus_sign;
            this.removeButton2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.removeButton2.Location = new System.Drawing.Point(228, 36);
            this.removeButton2.Name = "removeButton2";
            this.removeButton2.Size = new System.Drawing.Size(23, 23);
            this.removeButton2.TabIndex = 3;
            this.removeButton2.UseVisualStyleBackColor = true;
            this.removeButton2.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // upButton2
            // 
            this.upButton2.Image = global::CslaGenerator.Properties.Resources.arrow_up;
            this.upButton2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.upButton2.Location = new System.Drawing.Point(228, 75);
            this.upButton2.Name = "upButton2";
            this.upButton2.Size = new System.Drawing.Size(23, 23);
            this.upButton2.TabIndex = 6;
            this.upButton2.UseVisualStyleBackColor = true;
            this.upButton2.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton2
            // 
            this.downButton2.Image = global::CslaGenerator.Properties.Resources.arrow_down;
            this.downButton2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.downButton2.Location = new System.Drawing.Point(228, 104);
            this.downButton2.Name = "downButton2";
            this.downButton2.Size = new System.Drawing.Size(23, 23);
            this.downButton2.TabIndex = 7;
            this.downButton2.UseVisualStyleBackColor = true;
            this.downButton2.Click += new System.EventHandler(this.downButton_Click);
            // 
            // buildButton2
            // 
            this.buildButton2.Image = global::CslaGenerator.Properties.Resources.build;
            this.buildButton2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buildButton2.Location = new System.Drawing.Point(228, 250);
            this.buildButton2.Name = "buildButton2";
            this.buildButton2.Size = new System.Drawing.Size(23, 23);
            this.buildButton2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buildButton2, "Check and build the selected object relation. You will be asked to confirm the build.");
            this.buildButton2.UseVisualStyleBackColor = true;
            this.buildButton2.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // buildAllButton2
            // 
            this.buildAllButton2.Image = global::CslaGenerator.Properties.Resources.build_all;
            this.buildAllButton2.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buildAllButton2.Location = new System.Drawing.Point(228, 286);
            this.buildAllButton2.Name = "buildAllButton2";
            this.buildAllButton2.Size = new System.Drawing.Size(23, 23);
            this.buildAllButton2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buildAllButton2, "Check and build all object relations. You will be asked to confirm the build.");
            this.buildAllButton2.UseVisualStyleBackColor = true;
            this.buildAllButton2.Click += new System.EventHandler(this.buildAllButton_Click);
            // 
            // propGrid2
            // 
            this.propGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propGrid2.Location = new System.Drawing.Point(263, 10);
            this.propGrid2.Name = "propGrid2";
            this.propGrid2.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propGrid2.Size = new System.Drawing.Size(252, 299);
            this.propGrid2.TabIndex = 4;
            // 
            // MultipleToMultipleTab
            // 
            this.MultipleToMultipleTab.Controls.Add(this.addButton3);
            this.MultipleToMultipleTab.Controls.Add(this.removeButton3);
            this.MultipleToMultipleTab.Controls.Add(this.upButton3);
            this.MultipleToMultipleTab.Controls.Add(this.downButton3);
            this.MultipleToMultipleTab.Controls.Add(this.buildButton3);
            this.MultipleToMultipleTab.Controls.Add(this.buildAllButton3);
            this.MultipleToMultipleTab.Controls.Add(this.listEntities3);
            this.MultipleToMultipleTab.Controls.Add(this.propGrid3);
            this.MultipleToMultipleTab.Location = new System.Drawing.Point(4, 22);
            this.MultipleToMultipleTab.Name = "MultipleToMultipleTab";
            this.MultipleToMultipleTab.Padding = new System.Windows.Forms.Padding(3);
            this.MultipleToMultipleTab.Size = new System.Drawing.Size(521, 315);
            this.MultipleToMultipleTab.TabIndex = 2;
            this.MultipleToMultipleTab.Text = "N to N Relations";
            this.MultipleToMultipleTab.UseVisualStyleBackColor = true;
            // 
            // addButton3
            // 
            this.addButton3.Image = global::CslaGenerator.Properties.Resources.plus_sign;
            this.addButton3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.addButton3.Location = new System.Drawing.Point(228, 7);
            this.addButton3.Name = "addButton3";
            this.addButton3.Size = new System.Drawing.Size(23, 23);
            this.addButton3.TabIndex = 2;
            this.toolTip1.SetToolTip(this.addButton3, "Add a new object relation (Multiple to Multiple).");
            this.addButton3.UseVisualStyleBackColor = true;
            this.addButton3.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton3
            // 
            this.removeButton3.Image = global::CslaGenerator.Properties.Resources.minus_sign;
            this.removeButton3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.removeButton3.Location = new System.Drawing.Point(228, 36);
            this.removeButton3.Name = "removeButton3";
            this.removeButton3.Size = new System.Drawing.Size(23, 23);
            this.removeButton3.TabIndex = 3;
            this.removeButton3.UseVisualStyleBackColor = true;
            this.removeButton3.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // upButton3
            // 
            this.upButton3.Image = global::CslaGenerator.Properties.Resources.arrow_up;
            this.upButton3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.upButton3.Location = new System.Drawing.Point(228, 75);
            this.upButton3.Name = "upButton3";
            this.upButton3.Size = new System.Drawing.Size(23, 23);
            this.upButton3.TabIndex = 6;
            this.upButton3.UseVisualStyleBackColor = true;
            this.upButton3.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton3
            // 
            this.downButton3.Image = global::CslaGenerator.Properties.Resources.arrow_down;
            this.downButton3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.downButton3.Location = new System.Drawing.Point(228, 104);
            this.downButton3.Name = "downButton3";
            this.downButton3.Size = new System.Drawing.Size(23, 23);
            this.downButton3.TabIndex = 7;
            this.downButton3.UseVisualStyleBackColor = true;
            this.downButton3.Click += new System.EventHandler(this.downButton_Click);
            // 
            // buildButton3
            // 
            this.buildButton3.Image = global::CslaGenerator.Properties.Resources.build;
            this.buildButton3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buildButton3.Location = new System.Drawing.Point(228, 250);
            this.buildButton3.Name = "buildButton3";
            this.buildButton3.Size = new System.Drawing.Size(23, 23);
            this.buildButton3.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buildButton3, "Check and build the selected object relation. You will be asked to confirm the build.");
            this.buildButton3.UseVisualStyleBackColor = true;
            this.buildButton3.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // buildAllButton3
            // 
            this.buildAllButton3.Image = global::CslaGenerator.Properties.Resources.build_all;
            this.buildAllButton3.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buildAllButton3.Location = new System.Drawing.Point(228, 286);
            this.buildAllButton3.Name = "buildAllButton3";
            this.buildAllButton3.Size = new System.Drawing.Size(23, 23);
            this.buildAllButton3.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buildAllButton3, "Check and build all object relations. You will be asked to confirm the build.");
            this.buildAllButton3.UseVisualStyleBackColor = true;
            this.buildAllButton3.Click += new System.EventHandler(this.buildAllButton_Click);
            // 
            // propGrid3
            // 
            this.propGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propGrid3.Location = new System.Drawing.Point(263, 10);
            this.propGrid3.Name = "propGrid3";
            this.propGrid3.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propGrid3.Size = new System.Drawing.Size(252, 299);
            this.propGrid3.TabIndex = 4;
            // 
            // ObjectRelationsBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.formPanel);
            this.MinimumSize = new System.Drawing.Size(500, 416);
            this.Name = "ObjectRelationsBuilder";
            this.Size = new System.Drawing.Size(554, 416);
            this.TabControl.ResumeLayout(false);
            this.AllObjectsTab.ResumeLayout(false);
            this.OneToMultipleTab.ResumeLayout(false);
            this.MultipleToMultipleTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.ListBox listEntities1;
        private System.Windows.Forms.ListBox listEntities2;
        private System.Windows.Forms.ListBox listEntities3;
        public System.Windows.Forms.TabControl TabControl;
        public System.Windows.Forms.TabPage AllObjectsTab;
        public System.Windows.Forms.TabPage OneToMultipleTab;
        public System.Windows.Forms.TabPage MultipleToMultipleTab;
        private System.Windows.Forms.PropertyGrid propGrid1;
        private System.Windows.Forms.PropertyGrid propGrid2;
        private System.Windows.Forms.PropertyGrid propGrid3;
        private System.Windows.Forms.Button addButton1;
        private System.Windows.Forms.Button removeButton1;
        private System.Windows.Forms.Button upButton1;
        private System.Windows.Forms.Button downButton1;
        private System.Windows.Forms.Button buildButton1;
        private System.Windows.Forms.Button buildAllButton1;
        private System.Windows.Forms.Button addButton2;
        private System.Windows.Forms.Button removeButton2;
        private System.Windows.Forms.Button upButton2;
        private System.Windows.Forms.Button downButton2;
        private System.Windows.Forms.Button buildButton2;
        private System.Windows.Forms.Button buildAllButton2;
        private System.Windows.Forms.Button addButton3;
        private System.Windows.Forms.Button removeButton3;
        private System.Windows.Forms.Button upButton3;
        private System.Windows.Forms.Button downButton3;
        private System.Windows.Forms.Button buildButton3;
        private System.Windows.Forms.Button buildAllButton3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}