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
        private TreeView tvwSchema;
        private Splitter splitMiddle;
        private PropertyGrid pgdDbObjects;
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
            this.pgdDbObjects = new System.Windows.Forms.PropertyGrid();
            this.splitMiddle = new System.Windows.Forms.Splitter();
            this.tvwSchema = new System.Windows.Forms.TreeView();
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
            this.panelBody.Controls.Add(this.pgdDbObjects);
            this.panelBody.Controls.Add(this.splitMiddle);
            this.panelBody.Controls.Add(this.tvwSchema);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(3, 3);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(2);
            this.panelBody.Size = new System.Drawing.Size(250, 372);
            this.panelBody.TabIndex = 11;
            // 
            // pgdDbObjects
            // 
            this.pgdDbObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdDbObjects.HelpVisible = false;
            this.pgdDbObjects.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.pgdDbObjects.Location = new System.Drawing.Point(2, 221);
            this.pgdDbObjects.Name = "pgdDbObjects";
            this.pgdDbObjects.Size = new System.Drawing.Size(246, 149);
            this.pgdDbObjects.TabIndex = 5;
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
            // tvwSchema
            // 
            this.tvwSchema.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvwSchema.HideSelection = false;
            this.tvwSchema.Location = new System.Drawing.Point(2, 2);
            this.tvwSchema.Name = "tvwSchema";
            this.tvwSchema.Size = new System.Drawing.Size(246, 214);
            this.tvwSchema.TabIndex = 7;
            this.tvwSchema.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.TvwSchemaControlAdded);
            this.tvwSchema.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TvwSchemaMouseUp);
            this.tvwSchema.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvwSchemaAfterSelect);
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
            tvwSchema.Height = (int)((double)0.75 * (double)this.panelBody.Height);

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
                tvwSchema.Height = (int)((double)pct / 100 * (double)this.panelBody.Height);
                Invalidate();
            }
        }
        private void TvwSchemaAfterSelect(object sender, TreeViewEventArgs e)
        {
            PropertyGridDbObjects.SelectedObject = e.Node.Tag;
            if (TreeViewAfterSelect != null)
                TreeViewAfterSelect(sender, e);
        }

        private void TvwSchemaMouseUp(object sender, MouseEventArgs e)
        {
            if (TreeViewMouseUp != null)
                TreeViewMouseUp(sender, e);
        }

        #region Properties

        internal TreeView TreeViewSchema
        {
            get { return tvwSchema; }
        }

        internal PropertyGrid PropertyGridDbObjects
        {
            get { return pgdDbObjects; }
        }

        #endregion

        private void TvwSchemaControlAdded(object sender, ControlEventArgs e)
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
            tvwSchema.ImageList = schemaImages;
            if (showColumns)
            {
                TreeNode emptyNode = new TreeNode("None");
                emptyNode.ImageIndex = (int)TvwIcons.field;
                emptyNode.SelectedImageIndex = (int)TvwIcons.field;
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
            tableBaseNode.ImageIndex = (int)TvwIcons.db;
            tableBaseNode.SelectedImageIndex = (int)TvwIcons.db;
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
            viewBaseNode.ImageIndex = (int)TvwIcons.db;
            viewBaseNode.SelectedImageIndex = (int)TvwIcons.db;

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
            spBaseNode.ImageIndex = (int)TvwIcons.db;
            spBaseNode.SelectedImageIndex = (int)TvwIcons.db;

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
            node.ImageIndex = (int)TvwIcons.table;
            node.SelectedImageIndex = (int)TvwIcons.table;
            if (_showColumns)
                AddColumns(node, obj.Columns);
        }

        public void LoadViewNode(TreeNode node, IViewInfo obj)
        {
            node.Tag = obj;
            node.Text = GetObjectName(obj);
            node.ImageIndex = (int)TvwIcons.view;
            node.SelectedImageIndex = (int)TvwIcons.view;
            if (_showColumns)
                AddColumns(node, obj.Columns);
        }

        public void LoadStoredProcedureNode(TreeNode node, IStoredProcedureInfo obj)
        {
            TreeNode[] resultNodes = new TreeNode[obj.ResultSets.Count];
            if (obj.ResultSets.Count > 0)
            {
                // Add result nodes
                for (int j = 0; j < obj.ResultSets.Count; j++)
                {

                    TreeNode rNode = new TreeNode("Result Set " + (j + 1).ToString());
                    resultNodes[j] = rNode;
                    rNode.Tag = obj.ResultSets[j];
                    rNode.ImageIndex = (int)TvwIcons.resultset;
                    rNode.SelectedImageIndex = (int)TvwIcons.resultset;
                    if (_showColumns)
                        AddColumns(rNode, obj.ResultSets[j].Columns);
                }
            }
            string procName = string.Empty;
            node.Nodes.Clear();
            node.Text = GetObjectName(obj);
            node.Tag = obj;
            node.ImageIndex = (int)TvwIcons.other;
            node.SelectedImageIndex = (int)TvwIcons.other;
            node.Nodes.AddRange(resultNodes);
        }

        void AddColumns(TreeNode node, ColumnInfoCollection cols)
        {
            node.Nodes.Clear();
            foreach (IColumnInfo c in cols)
            {
                TreeNode n = new TreeNode(c.ColumnName);
                n.Tag = c;
                n.SelectedImageIndex = (int)TvwIcons.field;
                n.ImageIndex = (int)TvwIcons.field;
                if (c.IsPrimaryKey)
                {
                    n.SelectedImageIndex = (int)TvwIcons.goldkey;
                    n.ImageIndex = (int)TvwIcons.goldkey;
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

        private enum TvwIcons
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
