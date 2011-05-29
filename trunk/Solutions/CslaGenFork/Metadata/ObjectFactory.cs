using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CslaGenerator.CodeGen;
using CslaGenerator.Controls;
using CslaGenerator.Util;
using DBSchemaInfo.Base;

namespace CslaGenerator.Metadata
{
    public class ObjectFactory
    {
        CslaGeneratorUnit _currentUnit;
        CslaObjectInfo _currentCslaObject;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ObjectFactory class.
        /// </summary>
        /// <param name="currentUnit"></param>
        /// <param name="currentCslaObject"></param>
        public ObjectFactory(CslaGeneratorUnit currentUnit, CslaObjectInfo currentCslaObject)
        {
            _currentUnit = currentUnit;
            _currentCslaObject = currentCslaObject;
        }

        /// <summary>
        /// Initializes a new instance of the ObjectFactory class.
        /// </summary>
        /// <param name="currentUnit"></param>
        /// <param name="type"></param>
        public ObjectFactory(CslaGeneratorUnit currentUnit, CslaObjectType type)
        {
            _currentUnit = currentUnit;
            _currentCslaObject = new CslaObjectInfo(_currentUnit);
            _currentCslaObject.ObjectType = type;
        }

        #endregion

        #region AddProperties overloads

        /// <summary>
        /// Adds all table columns to the current object.
        /// </summary>
        /// <param name="table"></param>
        public void AddProperties(ITableInfo table)
        {
            AddProperties(table, table, table.Columns, false, false);
        }

        /// <summary>
        /// Adds all view columns to the current object.
        /// </summary>
        /// <param name="view"></param>
        public void AddProperties(IViewInfo view)
        {
            AddProperties(view, view, view.Columns, false, false);
        }

        /// <summary>
        /// Adds the specified list of columns from the specified table to the current object.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="selectedColumns"></param>
        public void AddProperties(ITableInfo table, IList<IColumnInfo> selectedColumns)
        {
            AddProperties(table, table, selectedColumns, false, false);
        }

        /// <summary>
        /// Adds the specified list of columns from the specified view to the current object.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="selectedColumns"></param>
        public void AddProperties(IViewInfo view, IList<IColumnInfo> selectedColumns)
        {
            AddProperties(view, view, selectedColumns, false, false);
        }

        /// <summary>
        /// Adds the specified list of columns from the specified resultset and database object to the current object.
        /// </summary>
        /// <param name="currentCslaObject">The current csla object.</param>
        /// <param name="obj">The database object.</param>
        /// <param name="rs">The result set.</param>
        /// <param name="selectedColumns">The selected columns.</param>
        /// <param name="createDefaultCriteria">If true, it calls AddDefaultCriteriaAndParameters() automatically</param>
        public void AddProperties(CslaObjectInfo currentCslaObject, IDataBaseObject obj, IResultSet rs, IList<IColumnInfo> selectedColumns, bool createDefaultCriteria, bool askConfirmation)
        {
            _currentCslaObject = currentCslaObject;
            AddProperties(obj, rs, selectedColumns, createDefaultCriteria, askConfirmation);
        }

        /// <summary>
        /// Adds the specified list of columns from the specified resultset and database object to the current object.
        /// </summary>
        /// <param name="obj">The database object.</param>
        /// <param name="rs">The result set.</param>
        /// <param name="selectedColumns"></param>
        /// <param name="createDefaultCriteria">If true, it calls AddDefaultCriteriaAndParameters() automatically</param>
        public void AddProperties(IDataBaseObject obj, IResultSet rs, IList<IColumnInfo> selectedColumns, bool createDefaultCriteria, bool askConfirmation)
        {
            if (_currentCslaObject == null || selectedColumns.Count == 0)
                return;

            var added = false;
            List<ValueProperty> addedProps = new List<ValueProperty>();
            StringCollection notaddedProps = new StringCollection();
            ColumnOriginType origin = ColumnOriginType.Table;
            IColumnInfo col;
            for (int i = 0; i < selectedColumns.Count; i++)
            {
                col = selectedColumns[i];
                // use name of column to see if a property of the same name exists
                string propertyName = col.ColumnName;
                if (PropertyExists(propertyName))
                {
                    int count = 1;
                    while (PropertyExists(propertyName + count))
                    {
                        count += 1;
                    }
                    propertyName += count.ToString();
                }

                ValueProperty newProp = new ValueProperty();

                newProp.Name = propertyName;
                newProp.PropertyType = TypeHelper.GetTypeCodeEx(col.ManagedType);
                SetValuePropertyInfo(obj, rs, col, newProp);
                if (newProp.DbBindColumn.ColumnOriginType != ColumnOriginType.Table)
                    origin = newProp.DbBindColumn.ColumnOriginType;
                if (!askConfirmation)
                {
                    _currentCslaObject.ValueProperties.Add(newProp);
                    added = true;
                }
                addedProps.Add(newProp);
            }

            if (addedProps.Count > 0 && askConfirmation)
            {
                var msg = new StringBuilder();
                msg.Append(
                    "The properties listed below are missing.\r\n\r\n" +
                    "Do you want to add the following properties:" +
                    Environment.NewLine);
                foreach (var valueProperty in addedProps)
                {
                    msg.AppendFormat(" - {0}.{1}\r\n", _currentCslaObject.ObjectName, valueProperty.Name);
                }

                var response = MessageBox.Show(msg.ToString(),
                                                        @"Missing ValueProperty found.",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Error);
                if (response == DialogResult.Yes)
                {
                    foreach (var valueProperty in addedProps)
                    {
                        _currentCslaObject.ValueProperties.Add(valueProperty);
                    }
                    added = true;
                }
            }

            // Add Get-, New- and DeleteObjectCriteria and linked parameters
            if (createDefaultCriteria)
            {
                AddDefaultCriteriaAndParameters();
            }

            // Display message to the user
            StringBuilder sb = new StringBuilder();
            if (addedProps.Count > 0 && added)
            {
                sb.Append("Successfully added the following Value Properties:" + Environment.NewLine);
                foreach (var propName in addedProps)
                {
                    sb.AppendFormat("\t{0}.{1}\r\n", _currentCslaObject.ObjectName, propName.Name);
                }
            }

            if (notaddedProps.Count > 0)
            {
                sb.Append("The following properties already exist:" + Environment.NewLine);
                foreach (string propName in notaddedProps)
                {
                    sb.Append("\t" + propName + Environment.NewLine);
                }
            }

            if (origin != ColumnOriginType.Table)
            {
                _currentCslaObject.GenerateSprocs = false;
                sb.Append(Environment.NewLine);
                sb.Append("Note: \"Generate stored procedures\" was set to false because the origins of the columns are not tables.");
            }

            if (sb.ToString().Length > 0)
                OutputWindow.Current.AddOutputInfo(sb.ToString());
        }

        #endregion

        #region ValueProperty & DbBindColumn

        private bool PropertyExists(string name)
        {
            if (_currentCslaObject == null)
                return false;

            if (_currentCslaObject.InheritedValueProperties.Contains(name) ||
                _currentCslaObject.InheritedChildProperties.Contains(name) ||
                _currentCslaObject.InheritedChildCollectionProperties.Contains(name) ||
                _currentCslaObject.ValueProperties.Contains(name) ||
                _currentCslaObject.ChildProperties.Contains(name) ||
                _currentCslaObject.ChildCollectionProperties.Contains(name))
            {
                return true;
            }

            return false;
        }

        public void SetValuePropertyInfo(ITableInfo table, IColumnInfo p, ValueProperty destination)
        {
            SetValuePropertyInfo(table, table, p, destination);
        }

        public void SetValuePropertyInfo(IViewInfo view, IColumnInfo p, ValueProperty destination)
        {
            SetValuePropertyInfo(view, view, p, destination);
        }

        public void SetValuePropertyInfo(IDataBaseObject obj, IResultSet rs, IColumnInfo prop, ValueProperty destination)
        {
            IColumnInfo p = prop;
            SetDbBindColumn(obj, rs, p, destination.DbBindColumn);
            destination.Nullable = (p.IsNullable);

            if (p.NativeType == "timestamp")
            {
                destination.ReadOnly = true;
                destination.MarkDirtyOnChange = false;
                destination.Undoable = false;
                destination.DeclarationMode = _currentUnit.Params.CreateTimestampPropertyMode;
            }

            if (_currentCslaObject.ObjectType == CslaObjectType.ReadOnlyObject)
            {
                destination.DeclarationMode = _currentUnit.Params.CreateReadOnlyObjectsPropertyMode;
            }

            if (p.IsPrimaryKey)
            {
                if (p.IsIdentity)
                {
                    destination.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK;
                    destination.ReadOnly = true;
                    destination.PropSetAccessibility = AccessorVisibility.Default;
                }
                else
                {
                    destination.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.UserProvidedPK;
                }

                if (destination.PropertyType == TypeCodeEx.Guid)
                    destination.DefaultValue = _currentUnit.Params.IDGuidDefaultValue;
                else if (p.IsIdentity)
                {
                    switch (p.DbType)
                    {
                        case DbType.Int16:
                            destination.DefaultValue = _currentUnit.Params.IDInt16DefaultValue;
                            break;
                        case DbType.Int32:
                            destination.DefaultValue = _currentUnit.Params.IDInt32DefaultValue;
                            break;
                        case DbType.Int64:
                            destination.DefaultValue = _currentUnit.Params.IDInt64DefaultValue;
                            break;
                    }
                }
            }

            if (_currentUnit.Params.CreationDateColumn == p.ColumnName)
            {
                destination.ReadOnly = true;
                destination.PropSetAccessibility = AccessorVisibility.Default;
                destination.DataAccess = ValueProperty.DataAccessBehaviour.CreateOnly;
                if (destination.PropertyType == TypeCodeEx.SmartDate)
                {
                    destination.DefaultValue = _currentUnit.Params.LogDateAndTime
                                                   ? "new SmartDate(DateTime.Now)"
                                                   : "new SmartDate(DateTime.Today)";
                }
                else
                {
                    destination.DefaultValue = _currentUnit.Params.LogDateAndTime
                                                   ? "DateTime.Now"
                                                   : "DateTime.Today";
                }
            }
            else if (_currentUnit.Params.CreationUserColumn == p.ColumnName)
            {
                destination.ReadOnly = true;
                destination.PropSetAccessibility = AccessorVisibility.Default;
                destination.DataAccess = ValueProperty.DataAccessBehaviour.CreateOnly;
                destination.DefaultValue = _currentUnit.Params.GetUserMethod;
            }
            else if (_currentUnit.Params.ChangedDateColumn == p.ColumnName)
            {
                destination.ReadOnly = true;
                destination.PropSetAccessibility = AccessorVisibility.Default;
                if (CslaTemplateHelperCS.IsCreationDateColumnPresent(_currentCslaObject))
                {
                    destination.DefaultValue = "$" + _currentUnit.Params.CreationDateColumn;
                }
                else
                {
                    destination.DefaultValue = _currentUnit.Params.LogDateAndTime
                                                   ? "new SmartDate(DateTime.Now)"
                                                   : "new SmartDate(DateTime.Today)";
                }
            }
            else if (_currentUnit.Params.ChangedUserColumn == p.ColumnName)
            {
                destination.ReadOnly = true;
                destination.PropSetAccessibility = AccessorVisibility.Default;
                if (CslaTemplateHelperCS.IsCreationUserColumnPresent(_currentCslaObject))
                {
                    destination.DefaultValue = "$" + _currentUnit.Params.CreationUserColumn;
                }
                else
                {
                    destination.DefaultValue = _currentUnit.Params.GetUserMethod;
                }
            }
            else if (_currentUnit.Params.DatesDefaultStringWithTypeConversion &&
                (destination.PropertyType == TypeCodeEx.SmartDate ||
                destination.PropertyType == TypeCodeEx.DateTime))
            {
                destination.BackingFieldType = destination.PropertyType;
                destination.PropertyType = TypeCodeEx.String;
                destination.DeclarationMode = PropertyDeclaration.ManagedWithTypeConversion;
            }

            return;
        }

        public static void SetDbBindColumn(ITableInfo table, IColumnInfo p, DbBindColumn dbc)
        {
            SetDbBindColumn(table, table, p, dbc);
        }

        public static void SetDbBindColumn(IViewInfo view, IColumnInfo p, DbBindColumn dbc)
        {
            SetDbBindColumn(view, view, p, dbc);
        }

        public static void SetDbBindColumn(IDataBaseObject obj, IResultSet rs, IColumnInfo p, DbBindColumn dbc)
        {

            IStoredProcedureInfo sp = obj as IStoredProcedureInfo;

            if (sp != null)
            {
                obj = sp;
                dbc.SpResultIndex = sp.ResultSets.IndexOf(rs);
            }

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

        #endregion

        #region Criteria

        /// <summary>
        /// Should be called after the object has all it's properties (if applicable).
        /// It creates the default criteria classes depending on the object type.
        /// </summary>
        public void AddDefaultCriteriaAndParameters(CslaObjectInfo objectInfo)
        {
            _currentCslaObject = objectInfo;
            AddDefaultCriteriaAndParameters();
        }

        /// <summary>
        /// Should be called after the object has all it's properties (if applicable).
        /// It creates the default criteria classes depending on the object type.
        /// </summary>
        public void AddDefaultCriteriaAndParameters()
        {
            if (_currentCslaObject.CriteriaObjects.Count != 0)
                return;

            if (_currentCslaObject.ObjectType == CslaObjectType.NameValueList ||
                (_currentCslaObject.ObjectType == CslaObjectType.ReadOnlyCollection &&
                _currentCslaObject.ParentType == string.Empty) ||
                _currentCslaObject.ObjectType == CslaObjectType.EditableRootCollection ||
                _currentCslaObject.ObjectType == CslaObjectType.DynamicEditableRootCollection)
            {
                if (_currentUnit.Params.AutoCriteria)
                {
                    Criteria crit = CreateEmptyFetchCriteria();
                    _currentCslaObject.CriteriaObjects.Add(crit);
                    crit.SetSprocNames();
                }
                //no need to go through the properties here.
                return;
            }

            List<ValueProperty> primaryKeyProperties = new List<ValueProperty>();
            ValueProperty timestampProperty = null;
            bool UseForCreate = false;

            // retrieve all primary key and timestamp properties
            foreach (ValueProperty prop in _currentCslaObject.ValueProperties)
            {
                if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                {
                    primaryKeyProperties.Add(prop);
                    if (!(prop.DbBindColumn.IsIdentity || prop.PropertyType == TypeCodeEx.Guid))
                        UseForCreate = true;
                }
                else if (prop.DbBindColumn.NativeType == "timestamp")
                {
                    timestampProperty = prop;
                }
            }

            if (primaryKeyProperties.Count > 0 || timestampProperty != null)
            {
                // Try to find default Criteria object
                Criteria defaultCriteria = _currentCslaObject.CriteriaObjects.Find("Criteria");
                Criteria timestampCriteria = _currentCslaObject.CriteriaObjects.Find("CriteriaTS");

                // If criteria objects are not set
                if (_currentCslaObject.CriteriaObjects.Count == 0)
                {
                    // If default criteria doesn't exists, create a new criteria
                    if (defaultCriteria == null)
                    {
                        if (!(_currentCslaObject.ObjectType == CslaObjectType.ReadOnlyObject &&
                            _currentCslaObject.ParentType != string.Empty))
                        {
                            defaultCriteria = new Criteria(_currentCslaObject);
                            defaultCriteria.Name = _currentCslaObject.ObjectType == CslaObjectType.ReadOnlyObject
                                                       ? "CriteriaGet"
                                                       : "Criteria";
                            defaultCriteria.GetOptions.Enable();
                            if (_currentCslaObject.ObjectType == CslaObjectType.EditableRoot ||
                                _currentCslaObject.ObjectType == CslaObjectType.EditableSwitchable ||
                                _currentCslaObject.ObjectType == CslaObjectType.EditableChild ||
                                _currentCslaObject.ObjectType == CslaObjectType.DynamicEditableRoot)
                            {
                                defaultCriteria.DeleteOptions.Enable();
                                if (defaultCriteria.Properties.Count > 0 && UseForCreate)
                                {
                                    defaultCriteria.CreateOptions.Factory = true;
                                    defaultCriteria.CreateOptions.DataPortal = true;
                                    defaultCriteria.CreateOptions.RunLocal = true;
                                }
                                else
                                {
                                    Criteria createCriteria = _currentCslaObject.CriteriaObjects.Find("CriteriaNew");
                                    if (createCriteria == null)
                                    {
                                        createCriteria = new Criteria(_currentCslaObject);
                                        createCriteria.Name = "CriteriaNew";
                                        createCriteria.CreateOptions.DataPortal = true;
                                        createCriteria.CreateOptions.Factory = true;
                                        createCriteria.CreateOptions.RunLocal = true;
                                        _currentCslaObject.CriteriaObjects.Add(createCriteria);
                                    }
                                }
                            }

                            defaultCriteria.SetSprocNames();

                            if ((_currentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40 ||
                                 _currentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL) &&
                                _currentCslaObject.ObjectType != CslaObjectType.EditableRoot &&
                                _currentCslaObject.ObjectType != CslaObjectType.EditableSwitchable &&
                                _currentCslaObject.ObjectType != CslaObjectType.ReadOnlyObject)
                            {
                                defaultCriteria.Name = "CriteriaDelete";
                                defaultCriteria.GetOptions.Factory = false;
                                defaultCriteria.GetOptions.DataPortal = false;
                                defaultCriteria.GetOptions.Procedure = false;
                                defaultCriteria.GetOptions.ProcedureName = string.Empty;
                                defaultCriteria.DeleteOptions.Factory = false;
                                defaultCriteria.DeleteOptions.DataPortal = false;
                            }

                            _currentCslaObject.CriteriaObjects.Add(defaultCriteria);
                            AddPropertiesToCriteria(primaryKeyProperties, defaultCriteria);

                            if (_currentUnit.Params.AutoTimestampCriteria && timestampProperty != null &&
                                timestampCriteria == null)
                                AddTimestampProperty(defaultCriteria, timestampProperty);
                        }
                    }
                }
            }
        }

        private void AddDefaultCriteria()
        {

        }

        private void AddTimestampProperty(Criteria defaultCriteria, ValueProperty timeStampProperty)
        {
            var timestampCriteria = new Criteria(_currentCslaObject);
            timestampCriteria.Name = "CriteriaTS";
            foreach (CriteriaProperty p in defaultCriteria.Properties)
            {
                CriteriaProperty newProp = (CriteriaProperty)ObjectCloner.CloneShallow(p);
                newProp.DbBindColumn = (DbBindColumn)p.DbBindColumn.Clone();
                timestampCriteria.Properties.Add(newProp);

            }
            AddPropertiesToCriteria(new ValueProperty[] { timeStampProperty }, timestampCriteria);
            timestampCriteria.DeleteOptions.Enable();
            timestampCriteria.SetSprocNames();
            _currentCslaObject.CriteriaObjects.Add(timestampCriteria);
        }

        public void AddPropertiesToCriteria(IEnumerable<ValueProperty> primaryKeyProperties, Criteria crit)
        {
            // Add all primary key properties to critera if they dont already exist
            foreach (ValueProperty col in primaryKeyProperties)
            {
                if (!crit.Properties.Contains(col.Name))
                {
                    CriteriaProperty p = new CriteriaProperty(col.Name, col.PropertyType);
                    p.DbBindColumn = (DbBindColumn)col.DbBindColumn.Clone();
                    crit.Properties.Add(p);
                }
            }
        }

        private static Criteria CreateEmptyFetchCriteria()
        {
            Criteria c = new Criteria();
            c.Name = "CriteriaGet";
            c.GetOptions.Enable();
            return c;
        }

        #endregion
    }
}
