using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CslaGenerator.Util;
using DBSchemaInfo.Base;

namespace CslaGenerator.Controls
{
    /// <summary>
    /// Summary description for DbTreeView.
    /// </summary>
    public class DbTreeView : UserControl
    {
        private Panel panelTop;
        private Panel panel2;
        private Panel panel3;
        private PaneCaption paneCaption1;
        private Panel panelBottom;
        private Panel panelTrim;
        private Panel panel4;
        private Panel panelBody;
        private TreeView treeViewSchema;
        private Splitter splitMiddle;
        private PropertyGrid propertyGridDbObjects;
        internal ImageList schemaImages;
        private IContainer components;

        public delegate void TreeViewAfterSelectEventHandler(object sender, TreeViewEventArgs e);
        public virtual event TreeViewAfterSelectEventHandler TreeViewAfterSelect;
        public delegate void TreeViewMouseUpEventHandler(object sender, MouseEventArgs e);
        public virtual event TreeViewMouseUpEventHandler TreeViewMouseUp;

        public DbTreeView()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbTreeView));
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.paneCaption1 = new CslaGenerator.Controls.PaneCaption();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTrim = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.propertyGridDbObjects = new System.Windows.Forms.PropertyGrid();
            this.splitMiddle = new System.Windows.Forms.Splitter();
            this.treeViewSchema = new System.Windows.Forms.TreeView();
            this.schemaImages = new System.Windows.Forms.ImageList(this.components);
            this.panelTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTrim.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panel2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(3);
            this.panelTop.Size = new System.Drawing.Size(264, 32);
            this.panelTop.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1);
            this.panel2.Size = new System.Drawing.Size(258, 26);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.paneCaption1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(256, 24);
            this.panel3.TabIndex = 13;
            // 
            // paneCaption1
            // 
            this.paneCaption1.AllowActive = false;
            this.paneCaption1.AntiAlias = false;
            this.paneCaption1.Caption = "Schema Objects";
            this.paneCaption1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneCaption1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paneCaption1.InactiveGradientHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(184)))), ((int)(((byte)(245)))));
            this.paneCaption1.InactiveGradientLowColor = System.Drawing.Color.White;
            this.paneCaption1.Location = new System.Drawing.Point(3, 3);
            this.paneCaption1.Name = "paneCaption1";
            this.paneCaption1.Size = new System.Drawing.Size(250, 18);
            this.paneCaption1.TabIndex = 11;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelTrim);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 32);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.panelBottom.Size = new System.Drawing.Size(264, 384);
            this.panelBottom.TabIndex = 13;
            // 
            // panelTrim
            // 
            this.panelTrim.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelTrim.Controls.Add(this.panel4);
            this.panelTrim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTrim.Location = new System.Drawing.Point(3, 1);
            this.panelTrim.Name = "panelTrim";
            this.panelTrim.Padding = new System.Windows.Forms.Padding(1);
            this.panelTrim.Size = new System.Drawing.Size(258, 380);
            this.panelTrim.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.panelBody);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(256, 378);
            this.panel4.TabIndex = 11;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.SystemColors.Control;
            this.panelBody.Controls.Add(this.propertyGridDbObjects);
            this.panelBody.Controls.Add(this.splitMiddle);
            this.panelBody.Controls.Add(this.treeViewSchema);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(3, 3);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(2);
            this.panelBody.Size = new System.Drawing.Size(250, 372);
            this.panelBody.TabIndex = 11;
            // 
            // pgdDbObjects
            // 
            this.propertyGridDbObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridDbObjects.HelpVisible = false;
            this.propertyGridDbObjects.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGridDbObjects.Location = new System.Drawing.Point(2, 221);
            this.propertyGridDbObjects.Name = "pgdDbObjects";
            this.propertyGridDbObjects.Size = new System.Drawing.Size(246, 149);
            this.propertyGridDbObjects.PropertySort = PropertySort.NoSort;
            this.propertyGridDbObjects.TabIndex = 5;
            // 
            // splitMiddle
            // 
            this.splitMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitMiddle.Location = new System.Drawing.Point(2, 216);
            this.splitMiddle.Name = "splitMiddle";
            this.splitMiddle.Size = new System.Drawing.Size(246, 5);
            this.splitMiddle.TabIndex = 6;
            this.splitMiddle.TabStop = false;
            // 
            // treeViewSchema
            // 
            this.treeViewSchema.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeViewSchema.HideSelection = false;
            this.treeViewSchema.Location = new System.Drawing.Point(2, 2);
            this.treeViewSchema.Name = "treeViewSchema";
            this.treeViewSchema.Size = new System.Drawing.Size(246, 214);
            this.treeViewSchema.TabIndex = 7;
            this.treeViewSchema.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.treeViewSchema_ControlAdded);
            this.treeViewSchema.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewSchema_MouseUp);
            this.treeViewSchema.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSchema_AfterSelect);
            // 
            // schemaImages
            // 
            this.schemaImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("schemaImages.ImageStream")));
            this.schemaImages.TransparentColor = System.Drawing.Color.Black;
            this.schemaImages.Images.SetKeyName(0, "0db.png");
            this.schemaImages.Images.SetKeyName(1, "1.png");
            this.schemaImages.Images.SetKeyName(2, "2.png");
            this.schemaImages.Images.SetKeyName(3, "3.png");
            this.schemaImages.Images.SetKeyName(4, "4.png");
            this.schemaImages.Images.SetKeyName(5, "5.png");
            this.schemaImages.Images.SetKeyName(6, "6.png");
            this.schemaImages.Images.SetKeyName(7, "7.png");
            this.schemaImages.Images.SetKeyName(8, "8.png");
            this.schemaImages.Images.SetKeyName(9, "9.png");
            this.schemaImages.Images.SetKeyName(10, "field.png");
            // 
            // DbTreeView
            // 
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "DbTreeView";
            this.Size = new System.Drawing.Size(264, 416);
            this.Load += new System.EventHandler(this.DbTreeView_Load);
            this.panelTop.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelTrim.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void DbTreeView_Load(object sender, EventArgs e)
        {
            treeViewSchema.Height = (int)((double)0.75 * (double)this.panelBody.Height);

        }

        Image Convert(Image orig)
        {
            Bitmap n = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            using (Graphics g = Graphics.FromImage(n))
            {
                g.DrawImage(orig, 0, 0);
            }
            return n;
        }
        internal void SetDbTreeViewPctHeight(double pct)
        {
            if (pct > 0 && pct < 100)
            {
                treeViewSchema.Height = (int)((double)pct / 100 * (double)this.panelBody.Height);
                Invalidate();
            }
        }
        private void treeViewSchema_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PropertyGridDbObjects.SelectedObject = e.Node.Tag;
            if (TreeViewAfterSelect != null)
                TreeViewAfterSelect(sender, e);
        }

        private void treeViewSchema_MouseUp(object sender, MouseEventArgs e)
        {
            if (TreeViewMouseUp != null)
                TreeViewMouseUp(sender, e);
        }

        #region Properties

        internal TreeView TreeViewSchema
        {
            get { return treeViewSchema; }
        }

        internal PropertyGrid PropertyGridDbObjects
        {
            get { return propertyGridDbObjects; }
        }

        #endregion

        private void treeViewSchema_ControlAdded(object sender, ControlEventArgs e)
        {
            Console.Write(e.Control.Name + " " + e.Control.Text);
        }

        bool _showColumns;

        public void BuildSchemaTree(ICatalog catalog)
        {
            BuildSchemaTree(catalog, false);
        }

        public void BuildSchemaTree(ICatalog catalog, bool showColumns)
        {
            _showColumns = showColumns;
            TreeViewSchema.Nodes.Clear();
            treeViewSchema.ImageList = schemaImages;
            if (showColumns)
            {
                TreeNode emptyNode = new TreeNode("None");
                emptyNode.ImageIndex = (int)TreeViewIcons.field;
                emptyNode.SelectedImageIndex = (int)TreeViewIcons.field;
                TreeViewSchema.Nodes.Add(emptyNode);
            }
            TreeNode tableBaseNode = null;

            #region  Add Tables
            TreeNode[] tableNodes = new TreeNode[catalog.Tables.Count];
            TreeNode node;
            for (int i = 0; i < catalog.Tables.Count; i++)
            {
                node = new TreeNode();
                tableNodes[i] = node;
                LoadTableNode(node, catalog.Tables[i]);
            }

            if (catalog.Tables.Count > 0)
            {
                Array.Sort(tableNodes, new TreeNodeComparer());
                tableBaseNode = new TreeNode("Tables", tableNodes);
            }
            else
            {
                tableBaseNode = new TreeNode("Tables");
            }
            tableBaseNode.ImageIndex = (int)TreeViewIcons.db;
            tableBaseNode.SelectedImageIndex = (int)TreeViewIcons.db;
            TreeViewSchema.Nodes.Add(tableBaseNode);

            #endregion

            #region Add Views

            TreeNode viewBaseNode;
            TreeNode[] viewNodes = new TreeNode[catalog.Views.Count];

            for (int i = 0; i < catalog.Views.Count; i++)
            {
                node = new TreeNode();
                viewNodes[i] = node;
                LoadViewNode(node, catalog.Views[i]);
            }
            if (catalog.Views.Count > 0)
            {
                Array.Sort(viewNodes, new TreeNodeComparer());
                viewBaseNode = new TreeNode("Views", viewNodes);
            }
            else
            {
                viewBaseNode = new TreeNode("Views");
            }
            viewBaseNode.ImageIndex = (int)TreeViewIcons.db;
            viewBaseNode.SelectedImageIndex = (int)TreeViewIcons.db;

            TreeViewSchema.Nodes.Add(viewBaseNode);

            #endregion

            #region Add Stored Procs

            TreeNode spBaseNode;
            List<TreeNode> spNodes = new List<TreeNode>();
            for (int i = 0; i < catalog.Procedures.Count; i++)
            {
                node = new TreeNode();
                LoadStoredProcedureNode(node, catalog.Procedures[i]);
                spNodes.Add(node);
            }
            if (catalog.Procedures.Count > 0)
            {
                spNodes.Sort(new TreeNodeComparer());
                spBaseNode = new TreeNode("Stored Procedures", spNodes.ToArray());
            }
            else
            {
                spBaseNode = new TreeNode("Stored Procedures");
            }
            spBaseNode.ImageIndex = (int)TreeViewIcons.db;
            spBaseNode.SelectedImageIndex = (int)TreeViewIcons.db;

            TreeViewSchema.Nodes.Add(spBaseNode);

            #endregion
        }

        public void LoadNode(TreeNode node, IDataBaseObject obj)
        {
            if (obj is IStoredProcedureInfo)
                LoadStoredProcedureNode(node, (IStoredProcedureInfo)obj);
            else if (obj is IViewInfo)
                LoadViewNode(node, (IViewInfo)obj);
            else if (obj is ITableInfo)
                LoadTableNode(node, (ITableInfo)obj);
        }

        public void LoadTableNode(TreeNode node, ITableInfo obj)
        {
            node.Tag = obj;
            node.Text = GetObjectName(obj);
            node.ImageIndex = (int)TreeViewIcons.table;
            node.SelectedImageIndex = (int)TreeViewIcons.table;
            if (_showColumns)
                AddColumns(node, obj.Columns);
        }

        public void LoadViewNode(TreeNode node, IViewInfo obj)
        {
            node.Tag = obj;
            node.Text = GetObjectName(obj);
            node.ImageIndex = (int)TreeViewIcons.view;
            node.SelectedImageIndex = (int)TreeViewIcons.view;
            if (_showColumns)
                AddColumns(node, obj.Columns);
        }

        public void LoadStoredProcedureNode(TreeNode node, IStoredProcedureInfo obj)
        {
            var parameterNodes = new TreeNode[obj.Parameters.Count];
            if (obj.Parameters.Count > 0)
            {
                // Add parameter nodes
                for (int j = 0; j < obj.Parameters.Count; j++)
                {

                    var pNode = new TreeNode(obj.Parameters[j].ParameterName);
                    parameterNodes[j] = pNode;
                    pNode.Tag = obj.Parameters[j];
                    pNode.ImageIndex = (int)TreeViewIcons.resultset;
                    pNode.SelectedImageIndex = (int)TreeViewIcons.resultset;
                }
            }
            var resultNodes = new TreeNode[obj.ResultSets.Count];
            if (obj.ResultSets.Count > 0)
            {
                // Add result nodes
                for (int j = 0; j < obj.ResultSets.Count; j++)
                {

                    var rNode = new TreeNode("Result Set " + (j + 1));
                    resultNodes[j] = rNode;
                    rNode.Tag = obj.ResultSets[j];
                    rNode.ImageIndex = (int)TreeViewIcons.resultset;
                    rNode.SelectedImageIndex = (int)TreeViewIcons.resultset;
                    if (_showColumns)
                        AddColumns(rNode, obj.ResultSets[j].Columns);
                }
            }
            var procName = string.Empty;
            node.Nodes.Clear();
            node.Text = GetObjectName(obj);
            node.Tag = obj;
            node.ImageIndex = (int)TreeViewIcons.other;
            node.SelectedImageIndex = (int)TreeViewIcons.other;
            node.Nodes.AddRange(parameterNodes);
            node.Nodes.AddRange(resultNodes);
        }

        void AddColumns(TreeNode node, ColumnInfoCollection cols)
        {
            node.Nodes.Clear();
            foreach (IColumnInfo c in cols)
            {
                TreeNode n = new TreeNode(c.ColumnName);
                n.Tag = c;
                n.SelectedImageIndex = (int)TreeViewIcons.field;
                n.ImageIndex = (int)TreeViewIcons.field;
                if (c.IsPrimaryKey)
                {
                    n.SelectedImageIndex = (int)TreeViewIcons.goldkey;
                    n.ImageIndex = (int)TreeViewIcons.goldkey;
                }
                node.Nodes.Add(n);
            }
        }

        private string GetObjectName(IDataBaseObject obj)
        {

            if (obj.ObjectCatalog != null && obj.ObjectSchema != null)
                return obj.ObjectSchema + "." + obj.ObjectName;

            return obj.ObjectName;
        }

        private enum TreeViewIcons
        {
            db = 0,
            dbx = 1,
            fldr = 2,
            table = 3,
            view = 4,
            sp = 5,
            resultset = 6,
            other = 7,
            goldkey = 8,
            silverkey = 9,
            field = 10
        }
    }
}
