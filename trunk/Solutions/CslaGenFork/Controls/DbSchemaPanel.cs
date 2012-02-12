using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using CslaGenerator.CodeGen;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using DBSchemaInfo.Base;
using DBSchemaInfo.MsSql;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator.Controls
{
    /// <summary>
    /// Summary description for DbSchemaPanel.
    /// </summary>
    public partial class DbSchemaPanel : DockContent
    {
        #region Fix for form flicker

        // http://www.angryhacker.com/blog/archive/2010/07/21/how-to-get-rid-of-flicker-on-windows-forms-applications.aspx

        int _originalExStyle = -1;
        private bool _enableFormLevelDoubleBuffering = true;

        protected override CreateParams CreateParams
        {
            get
            {
                if (_originalExStyle == -1)
                    _originalExStyle = base.CreateParams.ExStyle;
                CreateParams cp = base.CreateParams;
                if (_enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                else
                    cp.ExStyle = _originalExStyle;
                return cp;
            }
        }

        internal void TurnOnFormLevelDoubleBuffering()
        {
            _enableFormLevelDoubleBuffering = true;
        }

        internal void TurnOffFormLevelDoubleBuffering()
        {
            _enableFormLevelDoubleBuffering = false;
            MaximizeBox = true;
        }

        private void DbSchemaPanel_Shown(object sender, EventArgs e)
        {
            TurnOffFormLevelDoubleBuffering();
        }

        private void DbSchemaPanel_ResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
            TurnOnFormLevelDoubleBuffering();
        }

        private void DbSchemaPanel_ResizeEnd(object sender, EventArgs e)
        {
            TurnOffFormLevelDoubleBuffering();
            ResumeLayout(true);
        }

        #endregion

        private CslaGeneratorUnit _currentUnit;
        private CslaObjectInfo _currentCslaObject;
        private CslaObjectInfoCollection _objectsAdded = new CslaObjectInfoCollection();
        private ObjectFactory _currentFactory;
        private string _cn = string.Empty;
        private ICatalog _catalog;
        bool _isDBItemSelected;
        TreeNode _currentTreeNode;

        public DbSchemaPanel(CslaGeneratorUnit cslagenunit, CslaObjectInfo cslaobject, string connection)
        {
            _currentUnit = cslagenunit;
            _cn = connection;
            _currentCslaObject = cslaobject;
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        private void DbSchemaPanel_Load(object sender, EventArgs e)
        {
            // hookup event handler for treeview select
            dbTreeView.TreeViewAfterSelect += dbTreeView1_TreeViewAfterSelect;
            // hookup event handler for treeview mouseup
            dbTreeView.TreeViewMouseUp += dbTreeView1_TreeViewMouseUp;
            // set default width
            dbTreeView.Width = (int)((double)0.5 * (double)Width);
            copySoftDeleteToolStripMenuItem.Checked = false;
        }

        private void DbSchemaPanel_Resize(object sender, EventArgs e)
        {
            // keep treeview and listbox equal widths of 50% of panel body
            // when panel resized
            dbTreeView.Width = (int)((double)0.5 * (double)Width);
        }

        #region Properties

        internal CslaGeneratorUnit CurrentUnit
        {
            get { return _currentUnit; }
            set { _currentUnit = value; }
        }

        internal CslaObjectInfo CslaObjectInfo
        {
            get { return _currentCslaObject; }
            set
            {
                _currentCslaObject = value;
                _currentFactory = new ObjectFactory(_currentUnit, _currentCslaObject);
            }
        }

        internal string ConnectionString
        {
            get { return _cn; }
            set { _cn = value; }
        }

        internal TreeView TreeViewSchema
        {
            get { return dbTreeView.TreeViewSchema; }
        }

        internal ListBox DbColumns
        {
            get { return dbColumns.ListColumns; }
        }

        internal PropertyGrid PropertyGridColumn
        {
            get { return dbColumns.PropertyGridColumn; }
        }

        internal PropertyGrid PropertyGridDbObjects
        {
            get { return dbTreeView.PropertyGridDbObjects; }
        }

        internal Dictionary<string, IColumnInfo> SelectedColumns
        {
            get { return dbColumns.SelectedIndices; }
        }

        internal int ColumnsCount
        {
            get { return dbColumns.ListColumns.Items.Count; }
        }

        internal int SelectedColumnsCount
        {
            get { return dbColumns.SelectedIndicesCount; }
        }

        internal bool UseBoolSoftDelete
        {
            get
            {
                return !string.IsNullOrEmpty(_currentUnit.Params.SpBoolSoftDeleteColumn) &&
                    !copySoftDeleteToolStripMenuItem.Checked;
            }
        }

        #endregion

        #region Methods

        internal void SetDbColumnsPctHeight(double pct)
        {
            dbColumns.SetDbColumnsPctHeight(pct);
        }

        internal void SetDbTreeViewPctHeight(double pct)
        {
            dbTreeView.SetDbTreeViewPctHeight(pct);
        }

        #endregion

        // called to populate treeview from provided database connection

        public void BuildSchemaTree()
        {
            TreeViewSchema.Nodes.Clear();
            TreeViewSchema.ImageList = schemaImages;
            string catalogName = null;
            string[] cnparts = _cn.ToLower().Split(';');
            foreach (string cnpart in cnparts)
            {
                if (cnpart.Contains("initial catalog=") || cnpart.Contains("database="))
                {
                    catalogName = cnpart.Substring(cnpart.IndexOf("=") + 1).Trim();
                }
            }

            OutputWindow.Current.ClearOutput();
            _catalog = new SqlCatalog(_cn, catalogName);
            DateTime start = DateTime.Now;
            _catalog.LoadStaticObjects();
            DateTime end = DateTime.Now;
            OutputWindow.Current.AddOutputInfo(string.Format("Loaded {0} tables and {1} views in {2:0.00} seconds...", _catalog.Tables.Count, _catalog.Views.Count, end.Subtract(start).TotalSeconds));
            start = DateTime.Now;
            _catalog.LoadProcedures();
            end = DateTime.Now;
            OutputWindow.Current.AddOutputInfo(string.Format("Found {0} sprocs in {1:0.00} seconds...", _catalog.Procedures.Count, end.Subtract(start).TotalSeconds), 2);
            GeneratorController.Current.Tables = _catalog.Tables.Count;
            GeneratorController.Current.Views = _catalog.Views.Count;
            GeneratorController.Current.Sprocs = _catalog.Procedures.Count;
            SprocName[] requiredSprocs = GetRequiredProcedureList();
            if (requiredSprocs.Length > 0)
                OutputWindow.Current.AddOutputInfo("Loading required procedures:");
            foreach (SprocName sp in requiredSprocs)
            {
                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(sp.Schema))
                    sb.Append(sp.Schema).Append(".");
                sb.Append(sp.Name);
                sb.Append(": ");
                try
                {
                    var sproc = _catalog.Procedures[null, sp.Schema == "" ? null : sp.Schema, sp.Name];
                    if (sproc != null)
                    {
                        start = DateTime.Now;
                        sproc.Reload(true);
                        end = DateTime.Now;
                        sb.AppendFormat("Loaded in {0:0.00} seconds...", end.Subtract(start).TotalSeconds);
                    }
                    else
                        sb.Append("Not Found!");
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ex.Message);
                    sb.AppendLine("Stack Trace:");
                    sb.AppendLine();
                    sb.AppendLine(ex.StackTrace);
                    sb.AppendLine();
                }
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }
            GeneratorController.Catalog = _catalog;
            if (!String.IsNullOrEmpty(_catalog.CatalogName))
                paneDbName.Caption = _catalog.CatalogName;
            else
                paneDbName.Caption = "Database Schema";

            if (_currentUnit != null)
            {
                _currentUnit.ConnectionString = _cn;
            }

            dbTreeView.BuildSchemaTree(_catalog);

            if (_currentUnit != null)
            {
                foreach (var info in _currentUnit.CslaObjects)
                {
                    if (_catalog != null)
                    {
                        info.LoadColumnInfo(_catalog);
                    }
                }
            }
        }

        private class SprocName : IEquatable<SprocName>
        {
            public string Schema { get; private set; }

            public string Name { get; private set; }

            /// <summary>
            /// Initializes a new instance of the Pair class.
            /// </summary>
            /// <param name="schema"></param>
            /// <param name="name"></param>
            public SprocName(string schema, string name)
            {
                Schema = schema == null ? string.Empty : schema;
                Name = name == null ? string.Empty : name;
            }

            #region IEquatable<SprocName> Members

            public bool Equals(SprocName other)
            {
                return (Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase) &&
                    Schema.Equals(other.Schema, StringComparison.CurrentCultureIgnoreCase));
            }

            #endregion

        }

        private SprocName[] GetRequiredProcedureList()
        {
            var list = new List<SprocName>();
            foreach (var obj in _currentUnit.CslaObjects)
            {
                foreach (var prop in obj.GetAllValueProperties())
                {
                    if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.StoredProcedure)
                    {
                        var sp = new SprocName(prop.DbBindColumn.SchemaName, prop.DbBindColumn.ObjectName);
                        if (!list.Contains(sp))
                            list.Add(sp);
                    }
                }
                foreach (var crit in obj.CriteriaObjects)
                {
                    foreach (var prop in crit.Properties)
                    {
                        if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.StoredProcedure)
                        {
                            var sp = new SprocName(prop.DbBindColumn.SchemaName, prop.DbBindColumn.ObjectName);
                            if (!list.Contains(sp))
                                list.Add(sp);
                        }
                    }
                }
            }
            return list.ToArray();
        }

        private void dbTreeView1_TreeViewMouseUp(object sender, MouseEventArgs e)
        {
            TreeNode node = TreeViewSchema.GetNodeAt(e.X, e.Y);
            if (TreeViewSchema.GetNodeAt(e.X, e.Y) == null)
            {
                _isDBItemSelected = false;
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                TreeViewSchema.SelectedNode = node;
            }
            TreeNodeSelected(node);
        }

        private void dbTreeView1_TreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNodeSelected(e.Node);
        }

        private void TreeNodeSelected(TreeNode node)
        {
            _currentTreeNode = node;
            dbColumns.Clear();
            _isDBItemSelected = false;
            PropertyGridColumn.SelectedObject = null;
            SetDbColumnsPctHeight(73);

            if (node != null)
            {
                if (node.Tag != null)
                {
                    _isDBItemSelected = true;
                    if (node.Tag is IResultSet)
                    {
                        PropertyGridDbObjects.SelectedObject = node.Tag;
                        foreach (IColumnInfo col in ((IResultSet)node.Tag).Columns)
                        {
                            DbColumns.Items.Add(col);
                        }
                    }
                    else
                    {
                        _isDBItemSelected = false;
                    }
                }
            }
        }

        private int GetCurrentResultSetIndex()
        {
            // this is a hack because the CommandResultColumnSchema does not store a reference to its  CommandResult
            //return frmGenerator.TreeViewSchema.SelectedNode.Index;
            return TreeViewSchema.SelectedNode.Index;
        }

        private void SetDbBindColumn(IColumnInfo p, DbBindColumn dbc)
        {
            SetDbBindColumn(TreeViewSchema.SelectedNode, p, dbc);
        }

        public static void SetDbBindColumn(TreeNode node, IColumnInfo p, DbBindColumn dbc)
        {
            var rs = (IResultSet)node.Tag;
            IStoredProcedureInfo sp = null;
            if (node.Parent.Tag != null)
                sp = (IStoredProcedureInfo)node.Parent.Tag;
            IDataBaseObject obj;
            if (sp != null)
            {
                obj = sp;
                dbc.SpResultIndex = sp.ResultSets.IndexOf(rs);
            }
            else
                obj = (IDataBaseObject)rs;

            switch (rs.Type)
            {
                case ResultType.Table:
                    dbc.ColumnOriginType = ColumnOriginType.Table;
                    break;
                case ResultType.View:
                    dbc.ColumnOriginType = ColumnOriginType.View;
                    break;
                case ResultType.StoredProcedure:
                    dbc.ColumnOriginType = ColumnOriginType.StoredProcedure;
                    break;
            }

            dbc.CatalogName = obj.ObjectCatalog;
            dbc.SchemaName = obj.ObjectSchema;
            dbc.ObjectName = obj.ObjectName;
            dbc.ColumnName = p.ColumnName;
            dbc.LoadColumn(GeneratorController.Catalog);
        }

        #region Schema Objects Context Menu handlers

        private void createEditableRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isDBItemSelected)
            {
                dbColumns.SelectAll(UseBoolSoftDelete ? _currentUnit.Params.SpBoolSoftDeleteColumn : "");
                NewObject(CslaObjectType.EditableRoot, dbTreeView.TreeViewSchema.SelectedNode.Text, "");
                AddPropertiesForSelectedColumns();
            }
        }

        private void createReadOnlyRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isDBItemSelected)
            {
                dbColumns.SelectAll(UseBoolSoftDelete ? _currentUnit.Params.SpBoolSoftDeleteColumn : "");
                NewObject(CslaObjectType.ReadOnlyObject, dbTreeView.TreeViewSchema.SelectedNode.Text, "");
                AddPropertiesForSelectedColumns();
            }
        }

        private void createEditableRootCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_isDBItemSelected)
                return;

            dbColumns.SelectAll(UseBoolSoftDelete ? _currentUnit.Params.SpBoolSoftDeleteColumn : "");
            editableRootCollectionToolStripMenuItem_Click(sender, e);
        }

        private void createReadOnlyRootCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_isDBItemSelected)
                return;

            dbColumns.SelectAll(this, _currentUnit);
            readOnlyRootCollectionToolStripMenuItem_Click(sender, e);
        }

        private void createDynamicEditableRootCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_isDBItemSelected)
                return;

            dbColumns.SelectAll(UseBoolSoftDelete ? _currentUnit.Params.SpBoolSoftDeleteColumn : "");
            dynamicEditableRootCollectionToolStripMenuItem_Click(sender, e);
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataBaseObject obj = _currentTreeNode.Tag as IDataBaseObject;
            if (obj != null)
            {
                try
                {
                    obj.Reload(true);
                    dbTreeView.LoadNode(_currentTreeNode, obj);
                    TreeNodeSelected(_currentTreeNode);
                }
                catch (Exception ex)
                {
                    OutputWindow.Current.ClearOutput();
                    OutputWindow.Current.AddOutputInfo(ex.Message, 2);
                    //OutputWindow.Current.AddOutputInfo(ex.StackTrace, 2);
                }
            }
        }

        #endregion

        #region Columns Context Menu handlers

        private void columnsContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            var objSelected = (_currentCslaObject != null);
            var rowPresent = (ColumnsCount > 0);
            var rowSelected = (SelectedColumnsCount > 0);
            selectAllToolStripMenuItem.Enabled = rowPresent;
            unselectAllToolStripMenuItem.Enabled = rowSelected;
            addToCslaObjectToolStripMenuItem.Enabled = objSelected && rowSelected;
            newCriteriaToolStripMenuItem.Enabled = objSelected && rowSelected;
            createEditableToolStripMenuItem.Enabled = rowSelected;
            createReadOnlyToolStripMenuItem.Enabled = rowSelected;
            while (addInheritedValuePropertyToolStripMenuItem.DropDownItems.Count > 0)
            {
                ToolStripItem mnu = addInheritedValuePropertyToolStripMenuItem.DropDownItems[0];
                mnu.Click -= addInheritedValuePropertyToolStripMenuItem_DropDownItemClicked;
                addInheritedValuePropertyToolStripMenuItem.DropDownItems.RemoveAt(0);
            }
            addInheritedValuePropertyToolStripMenuItem.Enabled = false;
            if (dbColumns.SelectedIndicesCount != 1)
                return;
            if (_currentCslaObject != null)
                foreach (ValueProperty prop in _currentCslaObject.InheritedValueProperties)
                {
                    var mnu = new ToolStripMenuItem();
                    mnu.Text = prop.Name;
                    if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
                        mnu.Text += @" (ASSIGN)";
                    else
                        mnu.Text += @" (UPDATE)";
                    mnu.Click += addInheritedValuePropertyToolStripMenuItem_DropDownItemClicked;
                    mnu.Checked = (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None);
                    mnu.Tag = prop.Name;
                    addInheritedValuePropertyToolStripMenuItem.DropDownItems.Add(mnu);
                }
            addInheritedValuePropertyToolStripMenuItem.Enabled = (addInheritedValuePropertyToolStripMenuItem.DropDownItems.Count > 0);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbColumns.SelectAll();
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbColumns.UnSelectAll();
        }

        private void addToCslaObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPropertiesForSelectedColumns();
        }

        private void addInheritedValuePropertyToolStripMenuItem_DropDownItemClicked(object sender, EventArgs e)
        {
            string name = (string)((ToolStripMenuItem)sender).Tag;
            foreach (IColumnInfo col in SelectedColumns.Values)
            {
                // use name of column to see if a property of the same name exists
                foreach (ValueProperty valProp in _currentCslaObject.InheritedValueProperties)
                {
                    if (valProp.Name.Equals(name))
                    {
                        _currentFactory.SetValuePropertyInfo(GetCurrentDBObject(), GetCurrentResultSet(), col, valProp);
                    }
                }
            }
        }

        private void editableRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObjectProperties frm = NewObjectProperties.NewRootObjectProperties("Editable Root");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string objectName = frm.GetPropertyValue("ObjectName");
                NewObject(CslaObjectType.EditableRoot, objectName, "");
                AddPropertiesForSelectedColumns();
            }
        }

        private void editableChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObjectProperties frm = NewObjectProperties.NewEditableChildProperties();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var objectName = frm.GetPropertyValue("ObjectName");
                var parentName = frm.GetPropertyValue("ParentType");
                var propertyName = frm.GetPropertyValue("PropertyNameInParentType");
                var parentProperties = frm.GetPropertyValue("ParentProperties");
                var parent = _currentUnit.CslaObjects.Find(parentName);
                if (parent == null)
                {
                    MessageBox.Show(@"Parent type not found", @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NewObject(CslaObjectType.EditableChild, objectName, parentName);
                AddParentProperties(parent, parentProperties);
                AddPropertiesForSelectedColumns(parent);
                AddChildToParent(parent, objectName, propertyName);
            }
        }

        private void editableRootCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObjectProperties frm = NewObjectProperties.NewRootListProperties("Editable Root Collection");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string collectionName = frm.GetPropertyValue("CollectionName");
                string itemName = frm.GetPropertyValue("ItemName");
                NewRootCollection(CslaObjectType.EditableRootCollection, collectionName, itemName);
                NewObject(CslaObjectType.EditableChild, itemName, collectionName);
                AddPropertiesForSelectedColumns();
            }
        }

        private void editableChildCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObjectProperties frm = NewObjectProperties.NewEditableChildListProperties();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var collectionName = frm.GetPropertyValue("CollectionName");
                var itemName = frm.GetPropertyValue("ItemName");
                var parentName = frm.GetPropertyValue("ParentType");
                var propertyName = frm.GetPropertyValue("PropertyNameInParentType");
                var parentProperties = frm.GetPropertyValue("ParentProperties");
                var parent = _currentUnit.CslaObjects.Find(parentName);
                if (parent == null)
                {
                    MessageBox.Show(@"Parent type not found", @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NewCollection(CslaObjectType.EditableChildCollection, collectionName, itemName, parentName);
                NewObject(CslaObjectType.EditableChild, itemName, collectionName);
                AddParentProperties(parent, parentProperties);
                AddPropertiesForSelectedColumns(parent);
                AddChildCollectionToParent(parent, collectionName, propertyName);
            }
        }

        private void dynamicEditableRootCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObjectProperties frm = NewObjectProperties.NewRootListProperties("Dynamic Editable Root Collection");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string collectionName = frm.GetPropertyValue("CollectionName");
                string itemName = frm.GetPropertyValue("ItemName");
                NewRootCollection(CslaObjectType.DynamicEditableRootCollection, collectionName, itemName);
                NewObject(CslaObjectType.DynamicEditableRoot, itemName, collectionName);
                AddPropertiesForSelectedColumns();
            }
        }

        private void readOnlyRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObjectProperties frm = NewObjectProperties.NewRootObjectProperties(@"Read Only Root Object");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string objectName = frm.GetPropertyValue("ObjectName");
                NewObject(CslaObjectType.ReadOnlyObject, objectName, "");
                AddPropertiesForSelectedColumns();
            }
        }

        private void readOnlyChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObjectProperties frm = NewObjectProperties.NewReadOnlyChildProperties();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var objectName = frm.GetPropertyValue("ObjectName");
                var parentName = frm.GetPropertyValue("ParentType");
                var propertyName = frm.GetPropertyValue("PropertyNameInParentType");
                var parentProperties = frm.GetPropertyValue("ParentProperties");
                var parent = _currentUnit.CslaObjects.Find(parentName);
                if (parent == null)
                {
                    MessageBox.Show(@"Parent type not found", @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NewObject(CslaObjectType.ReadOnlyObject, objectName, parentName);
                AddParentProperties(parent, parentProperties);
                AddPropertiesForSelectedColumns(parent);
                AddChildToParent(parent, objectName, propertyName);

                /*var child = new ChildProperty();
                child.TypeName = objectName;
                if (!string.IsNullOrEmpty(propertyName))
                    child.Name = propertyName;
                else
                    child.Name = objectName;
                child.ReadOnly = true;
                foreach (var crit in parent.CriteriaObjects)
                {
                    if (crit.GetOptions.Factory || crit.GetOptions.AddRemove || crit.GetOptions.DataPortal)
                    {
                        foreach (var prop in crit.Properties)
                        {
                            child.LoadParameters.Add(new Parameter(crit, prop));
                        }
                    }
                }
                parent.ChildProperties.Add(child);*/
            }
        }

        private void readOnlyRootCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObjectProperties frm = NewObjectProperties.NewRootListProperties("Read Only Root Collection");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string collectionName = frm.GetPropertyValue("CollectionName");
                string itemName = frm.GetPropertyValue("ItemName");
                NewRootCollection(CslaObjectType.ReadOnlyCollection, collectionName, itemName);
                NewObject(CslaObjectType.ReadOnlyObject, itemName, collectionName);
                AddPropertiesForSelectedColumns();
            }
        }

        private void readOnlyChildCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewObjectProperties frm = NewObjectProperties.NewReadOnlyChildListProperties();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var collectionName = frm.GetPropertyValue("CollectionName");
                var itemName = frm.GetPropertyValue("ItemName");
                var parentName = frm.GetPropertyValue("ParentType");
                var propertyName = frm.GetPropertyValue("PropertyNameInParentType");
                var parentProperties = frm.GetPropertyValue("ParentProperties");
                var parent = _currentUnit.CslaObjects.Find(parentName);
                if (parent == null)
                {
                    MessageBox.Show(@"Parent type not found", @"CslaGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NewCollection(CslaObjectType.ReadOnlyCollection, collectionName, itemName, parentName);
                NewObject(CslaObjectType.ReadOnlyObject, itemName, collectionName);
                AddParentProperties(parent, parentProperties);
                AddPropertiesForSelectedColumns(parent);
                AddChildCollectionToParent(parent, collectionName, propertyName);

                /*var coll = new ChildProperty();
                coll.TypeName = collectionName;
                if (!string.IsNullOrEmpty(propertyName))
                    coll.Name = propertyName;
                else
                    coll.Name = collectionName;
                coll.ReadOnly = true;
                foreach (var crit in parent.CriteriaObjects)
                {
                    if (crit.GetOptions.Factory || crit.GetOptions.AddRemove || crit.GetOptions.DataPortal)
                    {
                        foreach (var prop in crit.Properties)
                        {
                            coll.LoadParameters.Add(new Parameter(crit, prop));
                        }
                    }
                }
                parent.ChildCollectionProperties.Add(coll);*/
            }
        }

        private void nameValueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IColumnInfo pkColumn = null;
            IColumnInfo valueColumn = null;
            foreach (IColumnInfo info in dbColumns.ListColumns.SelectedItems)
            {
                if (info.IsPrimaryKey)
                    pkColumn = info;
                else
                    valueColumn = info;
            }
            if (pkColumn != null && valueColumn != null && dbColumns.ListColumns.SelectedItems.Count == 2)
            {
                NewObjectProperties frm = NewObjectProperties.NewNVLProperties();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string collectionName = frm.GetPropertyValue("CollectionName");
                    NewNVL(collectionName);
                    AddPropertiesForSelectedColumns();
                    _currentCslaObject.NameColumn = valueColumn.ColumnName;
                    _currentCslaObject.ValueColumn = pkColumn.ColumnName;
                }
            }
            else
                MessageBox.Show(@"You must select a PK column and a non PK column in order to automatically create a name value list. If you need to create a NVL and can't meet this requirement, create a new object manually through the toolbar.", @"New NVL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void newCriteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentCslaObject == null)
                return;
            var colNames = string.Empty;
            var cols = new List<CriteriaProperty>();
            for (var i = 0; i < SelectedColumns.Count; i++)
            {
                var info = (IColumnInfo)dbColumns.ListColumns.SelectedItems[i];
                var prop = new CriteriaProperty(info.ColumnName, TypeHelper.GetTypeCodeEx(info.ManagedType), info.ColumnName);
                SetDbBindColumn(info, prop.DbBindColumn);
                cols.Add(prop);
                colNames += prop.Name;
            }
            if (cols.Count == 0)
                return;

            var name = "Criteria" + colNames;
            var num = 0;
            while (true)
            {
                if (_currentCslaObject.CriteriaObjects.Contains(name))
                {
                    num++;
                    name = "Criteria" + colNames + num;
                }
                else
                    break;
            }
            var c = new Criteria(_currentCslaObject);
            c.Name = name;
            c.Properties.AddRange(cols);
            c.SetSprocNames();
            var frm = new Design.ObjectEditorForm();
            frm.ObjectToEdit = c;
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
                _currentCslaObject.CriteriaObjects.Add(c);
        }

        #endregion

        #region New Object creation

        private void NewRootCollection(CslaObjectType type, string name, string item)
        {
            NewCollection(type, name, item, String.Empty);
        }

        private void NewCollection(CslaObjectType type, string name, string item, string parent)
        {
            var obj = new CslaObjectInfo(_currentUnit);
            obj.ObjectType = type;
            obj.ObjectName = ParseObjectName(name);
            obj.ParentType = parent;
            obj.ItemType = item;
            _currentFactory.AddDefaultCriteriaAndParameters(obj);
            _objectsAdded.Add(obj);
        }

        private void NewNVL(string name)
        {
            var obj = new CslaObjectInfo(_currentUnit);
            obj.ObjectType = CslaObjectType.NameValueList;
            obj.ObjectName = ParseObjectName(name);
            _objectsAdded.Insert(0, obj);
            GeneratorController.Current.MainForm.ProjectPanel.AddCreatedObject(_objectsAdded);
            _objectsAdded = new CslaObjectInfoCollection();
            _currentCslaObject = obj;
            _currentFactory.AddDefaultCriteriaAndParameters();
        }

        private string ParseObjectName(string name)
        {
            if (name != null)
            {
                int idx = name.LastIndexOf(".");
                idx++;
                if (idx > 0)
                    return name.Substring(idx);

                return name;
            }
            return string.Empty;
        }

        private void NewObject(CslaObjectType type, string name, string parent)
        {
            var dbObject = GetCurrentDBObject();

            var obj = new CslaObjectInfo(_currentUnit);
            obj.ObjectName = ParseObjectName(name);
            obj.ObjectType = type;
            if (type == CslaObjectType.EditableChild)
            {
                obj.DeleteUseTimestamp = CurrentUnit.Params.AutoTimestampCriteria;
                obj.RemoveItem = true;
            }
            else if (type == CslaObjectType.ReadOnlyObject)
                obj.CheckRulesOnFetch = false;
            if (dbObject.ObjectDescription != null)
                obj.ClassSummary = dbObject.ObjectDescription;
            obj.ParentType = parent;
            obj.ParentInsertOnly = true;
            _objectsAdded.Insert(0, obj);
            GeneratorController.Current.MainForm.ProjectPanel.AddCreatedObject(_objectsAdded);
            _objectsAdded = new CslaObjectInfoCollection();
            _currentCslaObject = obj;
        }

        #endregion

        private void AddParentProperties(CslaObjectInfo parent, string parentProperties)
        {
            var propList = new ArrayList();
            if (string.IsNullOrEmpty(parentProperties))
            {
                OutputWindow.Current.AddOutputInfo(
                    string.Format("No Parent Properties specified for {0}. All parent Primary Key properties will be used.\r\n",
                                _currentCslaObject.ObjectName));

                foreach (var prop in parent.ValueProperties)
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                        propList.Add(prop);
            }
            else
            {
                string[] userParams = parentProperties.Split(',');

                foreach (var prop in parent.ValueProperties)
                    foreach (var param in userParams)
                        if (prop.Name == param)
                            propList.Add(prop);
            }

            var sb = new StringBuilder();
            foreach (Property prop in propList)
            {
                _currentCslaObject.ParentProperties.Add(prop);
                sb.AppendFormat("\t{0}.{1}.\r\n",
                                parent.ObjectName, prop.Name);
            }

            if (sb.Length > 0)
            {
                OutputWindow.Current.AddOutputInfo(
                    string.Format("Successfully added the following Parent Properties to {0}:", _currentCslaObject.ObjectName));
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }
        }

        private void AddPropertiesForSelectedColumns()
        {
            if (_currentCslaObject == null)
                return;
            if (SelectedColumnsCount == 0)
            {
                MessageBox.Show(this, @"You must first select a column to add.", @"Warning");
                return;
            }

            var columns = new List<IColumnInfo>();
            for (int i = 0; i < SelectedColumns.Count; i++)
            {
                columns.Add((IColumnInfo)dbColumns.ListColumns.SelectedItems[i]);
            }

            var dbObject = GetCurrentDBObject();
            var resultSet = GetCurrentResultSet();
            _currentFactory.AddProperties(_currentCslaObject, dbObject, resultSet, columns, true, false);
        }

        private void AddPropertiesForSelectedColumns(CslaObjectInfo parent)
        {
            if (_currentCslaObject == null)
                return;
            if (SelectedColumnsCount == 0)
            {
                MessageBox.Show(this, @"You must first select a column to add.", @"Warning");
                return;
            }

            var columns = new List<IColumnInfo>();
            var sb = new StringBuilder();
            for (var index = 0; index < SelectedColumns.Count; index++)
            {
                var column = (IColumnInfo)dbColumns.ListColumns.SelectedItems[index];

                var nameTypeMatch = CslaTemplateHelperCS.ColumnNameMatchesParentProperty(parent, _currentCslaObject, column);
                var fkMatch = CslaTemplateHelperCS.ColumnFKMatchesParentProperty(parent, _currentCslaObject, column);

                if (string.IsNullOrEmpty(nameTypeMatch) && string.IsNullOrEmpty(fkMatch))
                    columns.Add(column);
                else
                {
                    if (!string.IsNullOrEmpty(nameTypeMatch))
                        sb.AppendFormat("\t{0}.\r\n", fkMatch);
                    else if (CslaTemplateHelperCS.MultipleColumnFKMatchesParent(parent, _currentCslaObject, column))
                        columns.Add(column);
                    else
                        sb.AppendFormat("\t{0}.\r\n", fkMatch);
                }
            }

            if (sb.Length > 0)
            {
                OutputWindow.Current.AddOutputInfo(string.Format(
                        "The following columns match {0} Parent Properties and were not added to the Value Property collection:",
                        _currentCslaObject.ObjectName));
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            var dbObject = GetCurrentDBObject();
            var resultSet = GetCurrentResultSet();
            _currentFactory.AddProperties(_currentCslaObject, dbObject, resultSet, columns, true, false);
        }

        private void AddChildToParent(CslaObjectInfo parent, string objectName, string propertyName)
        {
            var isItem = false;
            var grandParent = _currentUnit.CslaObjects.Find(parent.ParentType);
            if (grandParent != null)
            {
                if (CslaTemplateHelperCS.IsCollectionType(grandParent.ObjectType))
                    isItem = true;
            }
            var child = new ChildProperty();
            child.TypeName = objectName;
            if (!string.IsNullOrEmpty(propertyName))
                child.Name = propertyName;
            else
                child.Name = objectName;
            child.ReadOnly = true;

            if (isItem)
            {
                foreach (var prop in parent.GetAllValueProperties())
                {
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                        child.ParentLoadProperties.Add(prop);
                }
            }
            else
            {
                foreach (var crit in parent.CriteriaObjects)
                {
                    if (crit.GetOptions.Factory || crit.GetOptions.AddRemove || crit.GetOptions.DataPortal)
                    {
                        foreach (var prop in crit.Properties)
                        {
                            child.LoadParameters.Add(new Parameter(crit, prop));
                        }
                    }
                }
            }
            parent.ChildProperties.Add(child);
        }

        private void AddChildCollectionToParent(CslaObjectInfo parent, string collectionName, string propertyName)
        {
            var isItem = false;
            var grandParent = _currentUnit.CslaObjects.Find(parent.ParentType);
            if (grandParent != null)
            {
                if (CslaTemplateHelperCS.IsCollectionType(grandParent.ObjectType))
                    isItem = true;
            }
            var coll = new ChildProperty();
            coll.TypeName = collectionName;
            if (!string.IsNullOrEmpty(propertyName))
                coll.Name = propertyName;
            else
                coll.Name = collectionName;
            coll.ReadOnly = true;

            if (isItem)
            {
                foreach (var prop in parent.GetAllValueProperties())
                {
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                        coll.ParentLoadProperties.Add(prop);
                }
            }
            else
            {
                foreach (var crit in parent.CriteriaObjects)
                {
                    if (crit.GetOptions.Factory || crit.GetOptions.AddRemove || crit.GetOptions.DataPortal)
                    {
                        foreach (var prop in crit.Properties)
                        {
                            coll.LoadParameters.Add(new Parameter(crit, prop));
                        }
                    }
                }
            }
            parent.ChildCollectionProperties.Add(coll);
        }

        private IResultSet GetCurrentResultSet()
        {
            if (_currentTreeNode == null)
                return null;

            return _currentTreeNode.Tag as IResultSet;
        }

        private IDataBaseObject GetCurrentDBObject()
        {
            if (_currentTreeNode.Parent.Tag != null)
                return _currentTreeNode.Parent.Tag as IDataBaseObject;

            return GetCurrentResultSet() as IDataBaseObject;
        }

        #region Manage state

        internal void GetState()
        {
            GeneratorController.Current.CurrentUnitLayout.SchemaSelectedTree = string.Empty;
            GeneratorController.Current.CurrentUnitLayout.SchemaSelectedNode = string.Empty;
            GeneratorController.Current.CurrentUnitLayout.SchemaSelectedSprocSubNode = string.Empty;
            GeneratorController.Current.CurrentUnitLayout.SchemaExpandedTrees.Clear();
            GeneratorController.Current.CurrentUnitLayout.SchemaExpandedNodes.Clear();
            foreach (var item in TreeViewSchema.Nodes)
            {
                var treeNode = item as TreeNode;
                if (treeNode != null && treeNode.IsExpanded)
                {
                    GeneratorController.Current.CurrentUnitLayout.SchemaExpandedTrees.Add(treeNode.Text);
                    foreach (var subItem in treeNode.Nodes)
                    {
                        var treeSubNode = subItem as TreeNode;
                        if (treeSubNode != null)
                        {
                            if (treeSubNode.IsExpanded)
                                GeneratorController.Current.CurrentUnitLayout.SchemaExpandedNodes.Add(treeNode.Text + "/" + treeSubNode.Text);

                            if (treeSubNode.IsSelected)
                            {
                                GeneratorController.Current.CurrentUnitLayout.SchemaSelectedTree = treeNode.Text;
                                GeneratorController.Current.CurrentUnitLayout.SchemaSelectedNode = treeSubNode.Text;
                            }
                            else
                            {
                                foreach (var subSubItem in treeSubNode.Nodes)
                                {
                                    var treeSubSubNode = subSubItem as TreeNode;
                                    if (treeSubSubNode != null && treeSubSubNode.IsSelected)
                                    {
                                        GeneratorController.Current.CurrentUnitLayout.SchemaSelectedTree = treeNode.Text;
                                        GeneratorController.Current.CurrentUnitLayout.SchemaSelectedNode =
                                            treeSubNode.Text;
                                        GeneratorController.Current.CurrentUnitLayout.SchemaSelectedSprocSubNode =
                                            treeSubSubNode.Text;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal void SetState()
        {
            foreach (var item in TreeViewSchema.Nodes)
            {
                var treeNode = item as TreeNode;
                if (treeNode != null)
                {
                    foreach (var expandedTree in GeneratorController.Current.CurrentUnitLayout.SchemaExpandedTrees)
                    {
                        if (treeNode.Text == expandedTree)
                            treeNode.Expand();
                    }

                    if (treeNode.Text == GeneratorController.Current.CurrentUnitLayout.SchemaSelectedTree)
                    {
                        TreeViewSchema.SelectedNode = treeNode;
                    }

                    foreach (var subItem in treeNode.Nodes)
                    {
                        var treeSubNode = subItem as TreeNode;
                        if (treeSubNode != null)
                        {
                            foreach (var expandedNode in GeneratorController.Current.CurrentUnitLayout.SchemaExpandedNodes)
                            {
                                var expandedStructure = expandedNode.Split('/');
                                if (treeNode.Text == expandedStructure[0] && treeSubNode.Text == expandedStructure[1])
                                    treeSubNode.Expand();
                            }

                            if (treeSubNode.Text == GeneratorController.Current.CurrentUnitLayout.SchemaSelectedNode)
                            {
                                TreeViewSchema.SelectedNode = treeSubNode;
                                foreach (var subSubItem in treeSubNode.Nodes)
                                {
                                    var treeSubSubNode = subSubItem as TreeNode;
                                    if (treeSubSubNode != null &&
                                        treeSubSubNode.Text ==
                                        GeneratorController.Current.CurrentUnitLayout.SchemaSelectedSprocSubNode)
                                    {
                                        TreeViewSchema.SelectedNode = treeSubSubNode;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
