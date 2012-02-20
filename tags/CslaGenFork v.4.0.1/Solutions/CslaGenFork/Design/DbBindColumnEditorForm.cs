using System;
using System.Windows.Forms;
using DBSchemaInfo.Base;
namespace CslaGenerator.Design
{
    public partial class DbBindColumnEditorForm : Form
    {
        TreeView tree;
        public DbBindColumnEditorForm()
        {
            InitializeComponent();
            tree = dbTreeView1.TreeViewSchema;
            tree.HideSelection = false;
            tree.NodeMouseDoubleClick += TreeViewSchemaNodeMouseDoubleClick;
            tree.NodeMouseClick += TreeViewSchemaNodeMouseClick;
            dbTreeView1.BuildSchemaTree(GeneratorController.Catalog, true);
        }

        void TreeViewSchemaNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == dbTreeView1.TreeViewSchema.Nodes[0] ||
                (e.Node.Tag != null && e.Node.Tag is IColumnInfo))
            {
                cmdOK.Enabled = true;
            }
            else
            {
                cmdOK.Enabled = false;
            }
        }

        void TreeViewSchemaNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (cmdOK.Enabled)
                cmdOK.PerformClick();
        }

        public IColumnInfo ColumnInfo
        {
            get
            {
                if (tree.SelectedNode == null)
                    return null;
                return tree.SelectedNode.Tag as IColumnInfo;
            }
            set
            {
                if (value == null || !FindNode(tree.Nodes, value))
                    tree.SelectedNode = tree.Nodes[0];
            }
        }

        public TreeNode SelectedNode
        {
            get { return tree.SelectedNode; }
        }

        public bool NoneSelected
        {
            get
            {
                return (tree.SelectedNode == null || tree.SelectedNode == tree.Nodes[0] || ColumnInfo == null);
            }
        }

        private bool FindNode(TreeNodeCollection nodes, IColumnInfo col)
        {
            foreach (TreeNode node in nodes)
            {
                if (FindNode(node.Nodes, col))
                    return true;
                IColumnInfo dbCol = node.Tag as IColumnInfo;
                if (dbCol != null && col.Equals(dbCol))
                {
                    dbTreeView1.TreeViewSchema.SelectedNode = node;
                    return true;
                }
            }
            return false;
        }

        private void CmdOkClick(object sender, EventArgs e)
        {
            if (ColumnInfo == null && tree.SelectedNode != tree.Nodes[0])
                MessageBox.Show(@"Invalid Selection");
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void DbBindColumnEditorFormActivated(object sender, EventArgs e)
        {
            tree.Focus();
        }

    }
}