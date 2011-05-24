using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using DBSchemaInfo.Base;
using DBSchemaInfo.MsSql;

namespace CslaGenerator.Controls
{
    /// <summary>
    /// Summary description for DbSchemaPanel.
    /// </summary>
    public partial class DbSchemaPanel : UserControl
    {
        private CslaGeneratorUnit _currentUnit = null;
        private CslaObjectInfo _currentCslaObject = null;
        private ObjectFactory _currentFactory = null;
        private string cn = "";

        public DbSchemaPanel(CslaGeneratorUnit cslagenunit, CslaObjectInfo cslaobject, string connection)
        {
            _currentUnit = cslagenunit;
            cn = connection;
            _currentCslaObject = cslaobject;
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        private void DbSchemaPanel_Load(object sender, EventArgs e)
        {
            // hookup event handler for treeview select
            dbTreeView1.TreeViewAfterSelect += dbTreeView1_TreeViewAfterSelect;
            // hookup event handler for treeview mouseup
            dbTreeView1.TreeViewMouseUp += dbTreeView1_TreeViewMouseUp;
            // set default width
            dbTreeView1.Width = (int)((double)0.5 * (double)Width);
            copySoftDeleteToolStripMenuItem.Checked = false;
        }

        private void DbSchemaPanel_Resize(object sender, EventArgs e)
        {
            // keep treeview and listbox equal widths of 50% of panel body
            // when panel resized
            dbTreeView1.Width = (int)((double)0.5 * (double)Width);
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
            get { return cn; }
            set { cn = value; }
        }

        internal TreeView TreeViewSchema
        {
            get { return dbTreeView1.TreeViewSchema; }
        }

        internal ListBox DbColumns
        {
            get { return dbColumns1.ListColumns; }
        }

        internal PropertyGrid PropertyGridColumn
        {
            get { return dbColumns1.PropertyGridColumn; }
        }

        internal PropertyGrid PropertyGridDbObjects
        {
            get { return dbTreeView1.PropertyGridDbObjects; }
        }

        internal Dictionary<string, IColumnInfo> SelectedColumns
        {
            get { return dbColumns1.SelectedIndices; }
        }

        internal int ColumnsCount
        {
            get { return dbColumns1.ListColumns.Items.Count; }
        }

        internal int SelectedColumnsCount
        {
            get { return dbColumns1.SelectedIndicesCount; }
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
            dbColumns1.SetDbColumnsPctHeight(pct);
        }

        internal void SetDbTreeViewPctHeight(double pct)
        {
            dbTreeView1.SetDbTreeViewPctHeight(pct);
        }

        #endregion

        // called to populate treeview from provided database connection
        ICatalog catalog = null;

        public void BuildSchemaTree()
        {
            TreeViewSchema.Nodes.Clear();
            TreeViewSchema.ImageList = schemaImages;
            string catalogName = null;
            string[] cnparts = cn.ToLower().Split(';');
            foreach (string cnpart in cnparts)
            {
                if (cnpart.Contains("initial catalog=") || cnpart.Contains("database="))
                {
                    catalogName = cnpart.Substring(cnpart.IndexOf("=") + 1).Trim();
                }
            }

            OutputWindow.Current.ClearOutput();
            catalog = new SqlCatalog(cn, catalogName);
            DateTime start;
            DateTime end;
            //OutputWindow.Current.AddOutputInfo("Load Tables & Views Start:" + DateTime.Now.ToLongTimeString());
            start = DateTime.Now;
            catalog.LoadStaticObjects();
            end = DateTime.Now;
            //OutputWindow.Current.AddOutputInfo("Load Tables & Views End:" + end.ToLongTimeString());
            OutputWindow.Current.AddOutputInfo(string.Format("Loaded {0} tables and {1} views in {2:0.00} seconds...", catalog.Tables.Count.ToString(), catalog.Views.Count.ToString(), end.Subtract(start).TotalSeconds));
            //OutputWindow.Current.AddOutputInfo("Load Procedures Start:" + DateTime.Now.ToLongTimeString());
            start = DateTime.Now;
            catalog.LoadProcedures();
            end = DateTime.Now;
            //OutputWindow.Current.AddOutputInfo("Load Procedures End:" + end.ToLongTimeString());
            OutputWindow.Current.AddOutputInfo(string.Format("Found {0} sprocs in {1:0.00} seconds...", catalog.Procedures.Count.ToString(), end.Subtract(start).TotalSeconds), 2);
            SprocName[] requiredSprocs = GetRequiredProcedureList();
            if (requiredSprocs.Length > 0)
                OutputWindow.Current.AddOutputInfo("Loading required procedures:");
            foreach (SprocName sp in requiredSprocs)
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(sp.Schema))
                    sb.Append(sp.Schema).Append(".");
                sb.Append(sp.Name);
                sb.Append(": ");
                try
                {
                    IStoredProcedureInfo sproc = catalog.Procedures[null, sp.Schema == "" ? null : sp.Schema, sp.Name];
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
            GeneratorController.Catalog = catalog;
            if (!String.IsNullOrEmpty(catalog.CatalogName))
                paneDbName.Caption = catalog.CatalogName;
            else
                paneDbName.Caption = "Database Schema";

            if (_currentUnit != null)
            {
                _currentUnit.ConnectionString = cn;
            }

            dbTreeView1.BuildSchemaTree(catalog);

            foreach (CslaObjectInfo info in _currentUnit.CslaObjects)
            {
                if (catalog != null)
                {
                    info.LoadColumnInfo(catalog);
                }
            }
        }

        private class SprocName : IEquatable<SprocName>
        {
            private string _Schema;

            public string Schema
            {
                get { return _Schema; }
            }

            private string _Name;

            public string Name
            {
                get { return _Name; }
            }

            /// <summary>
            /// Initializes a new instance of the Pair class.
            /// </summary>
            /// <param name="schema"></param>
            /// <param name="name"></param>
            public SprocName(string schema, string name)
            {
                _Schema = schema == null ? string.Empty : schema;
                _Name = name == null ? string.Empty : name;
            }

            #region IEquatable<SprocName> Members

            public bool Equals(SprocName other)
            {
                return (_Name.Equals(other._Name, StringComparison.CurrentCultureIgnoreCase) &&
                    _Schema.Equals(other._Schema, StringComparison.CurrentCultureIgnoreCase));
            }

            #endregion

        }

        private SprocName[] GetRequiredProcedureList()
        {
            List<SprocName> list = new List<SprocName>();
            foreach (CslaObjectInfo obj in _currentUnit.CslaObjects)
            {
                foreach (ValueProperty prop in obj.GetAllValueProperties())
                {
                    if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.StoredProcedure)
                    {
                        SprocName sp = new SprocName(prop.DbBindColumn.SchemaName, prop.DbBindColumn.ObjectName);
                        if (!list.Contains(sp))
                            list.Add(sp);
                    }
                }
                foreach (Criteria crit in obj.CriteriaObjects)
                {
                    foreach (CriteriaProperty prop in crit.Properties)
                    {
                        if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.StoredProcedure)
                        {
                            SprocName sp = new SprocName(prop.DbBindColumn.SchemaName, prop.DbBindColumn.ObjectName);
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
                isDBItemSelected = false;
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

        bool isDBItemSelected;
        TreeNode currentTreeNode = null;

        private void TreeNodeSelected(TreeNode node)
        {
            currentTreeNode = node;
            dbColumns1.Clear();
            isDBItemSelected = false;
            PropertyGridColumn.SelectedObject = null;
            SetDbColumnsPctHeight(73);

            if (node != null)
            {
                if (node.Tag != null)
                {
                    isDBItemSelected = true;
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
                        isDBItemSelected = false;
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
            //TreeNode node = TreeViewSchema.SelectedNode;
            IResultSet rs = (IResultSet)node.Tag;
            IStoredProcedureInfo sp = null;
            if (node.Parent.Tag != null)
                sp = (IStoredProcedureInfo)node.Parent.Tag;
            IDataBaseObject obj = null;
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

            //dbc.ColumnOriginType=
            dbc.CatalogName = obj.ObjectCatalog;
            dbc.SchemaName = obj.ObjectSchema;
            dbc.ObjectName = obj.ObjectName;
            dbc.ColumnName = p.ColumnName;
            dbc.LoadColumn(GeneratorController.Catalog);
        }

        #region Schema Objects Context Menu handlers

        private void createEditableRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDBItemSelected)
            {
                dbColumns1.SelectAll(UseBoolSoftDelete ? _currentUnit.Params.SpBoolSoftDeleteColumn : "");
                NewObject(CslaObjectType.EditableRoot, dbTreeView1.TreeViewSchema.SelectedNode.Text, "");
                AddPropertiesForSelectedColumns();
            }
        }

        private void createReadOnlyRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDBItemSelected)
            {
                dbColumns1.SelectAll(UseBoolSoftDelete ? _currentUnit.Params.SpBoolSoftDeleteColumn : "");
                NewObject(CslaObjectType.ReadOnlyObject, dbTreeView1.TreeViewSchema.SelectedNode.Text, "");
                AddPropertiesForSelectedColumns();
            }
        }

        private void createEditableRootCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isDBItemSelected)
                return;

            dbColumns1.SelectAll(UseBoolSoftDelete ? _currentUnit.Params.SpBoolSoftDeleteColumn : "");
            editableRootCollectionToolStripMenuItem_Click(sender, e);
        }

        private void createReadOnlyRootCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isDBItemSelected)
                return;

            dbColumns1.SelectAll(this, _currentUnit);
            readOnlyRootCollectionToolStripMenuItem_Click(sender, e);
        }

        private void createDynamicEditableRootCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isDBItemSelected)
                return;

            dbColumns1.SelectAll(UseBoolSoftDelete ? _currentUnit.Params.SpBoolSoftDeleteColumn : "");
            dynamicEditableRootCollectionToolStripMenuItem_Click(sender, e);
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataBaseObject obj = currentTreeNode.Tag as IDataBaseObject;
            if (obj != null)
            {
                try
                {
                    obj.Reload(true);
                    dbTreeView1.LoadNode(currentTreeNode, obj);
                    TreeNodeSelected(currentTreeNode);
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
            if (dbColumns1.SelectedIndicesCount != 1)
                return;
            if (_currentCslaObject != null)
                foreach (ValueProperty prop in _currentCslaObject.InheritedValueProperties)
                {
                    ToolStripMenuItem mnu = new ToolStripMenuItem();
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
            dbColumns1.SelectAll();
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbColumns1.UnSelectAll();
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
            foreach (IColumnInfo info in dbColumns1.ListColumns.SelectedItems)
            {
                if (info.IsPrimaryKey)
                    pkColumn = info;
                else
                    valueColumn = info;
            }
            if (pkColumn != null && valueColumn != null && dbColumns1.ListColumns.SelectedItems.Count == 2)
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
                MessageBox.Show(@"You must select a PK column and a non PK column in order to automatically create a name value list. If you need to create a NVL and can't meet this requirement, create a new object manually through the toolbar.", "New NVL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void newCriteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentCslaObject == null)
                return;
            var colNames = string.Empty;
            var cols = new List<CriteriaProperty>();
            for (var i = 0; i < SelectedColumns.Count; i++)
            {
                var info = (IColumnInfo)dbColumns1.ListColumns.SelectedItems[i];
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
            _currentUnit.CslaObjects.Add(obj);
            _currentFactory.AddDefaultCriteriaAndParameters(obj);
        }

        private void NewNVL(string name)
        {
            var obj = new CslaObjectInfo(_currentUnit);
            obj.ObjectType = CslaObjectType.NameValueList;
            obj.ObjectName = ParseObjectName(name);
            _currentUnit.CslaObjects.Add(obj);
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
            var obj = new CslaObjectInfo(_currentUnit);
            obj.ObjectType = type;
            obj.ObjectName = ParseObjectName(name);
            obj.ParentType = parent;
            obj.ParentInsertOnly = true;
            _currentUnit.CslaObjects.Add(obj);
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
                columns.Add((IColumnInfo)dbColumns1.ListColumns.SelectedItems[i]);
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
                var isParent = false;
                foreach (var prop in _currentCslaObject.ParentProperties)
                {
                    if (prop.Name == ((IColumnInfo)dbColumns1.ListColumns.SelectedItems[index]).ColumnName &&
                        prop.PropertyType ==
                        TypeHelper.GetTypeCodeEx(((IColumnInfo)dbColumns1.ListColumns.SelectedItems[index]).ManagedType))
                    {
                        sb.AppendFormat("\t{0}.{1}.\r\n", parent.ObjectName, prop.Name);
                        isParent = true;
                        break;
                    }
                }
                if (!isParent)
                    columns.Add((IColumnInfo)dbColumns1.ListColumns.SelectedItems[index]);
            }

            if (sb.Length > 0)
            {
                OutputWindow.Current.AddOutputInfo(
                    string.Format("The following columns match {0} Parent Properties and weren't added to the Value Property collection:",
                        _currentCslaObject.ObjectName));
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            var dbObject = GetCurrentDBObject();
            var resultSet = GetCurrentResultSet();
            _currentFactory.AddProperties(_currentCslaObject, dbObject, resultSet, columns, true, false);
        }

        private static void AddChildToParent(CslaObjectInfo parent, string objectName, string propertyName)
        {
            var child = new ChildProperty();
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
            parent.ChildProperties.Add(child);
        }

        private static void AddChildCollectionToParent(CslaObjectInfo parent, string collectionName, string propertyName)
        {
            var coll = new ChildProperty();
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
            parent.ChildCollectionProperties.Add(coll);
        }

        private IResultSet GetCurrentResultSet()
        {
            if (currentTreeNode == null)
                return null;

            return currentTreeNode.Tag as IResultSet;
        }

        private IDataBaseObject GetCurrentDBObject()
        {
            if (currentTreeNode.Parent.Tag != null)
                return currentTreeNode.Parent.Tag as IDataBaseObject;

            return GetCurrentResultSet() as IDataBaseObject;
        }

    }
}
