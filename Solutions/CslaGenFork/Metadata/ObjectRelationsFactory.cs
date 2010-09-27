using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CslaGenerator.Controls;
using DBSchemaInfo.Base;

namespace CslaGenerator.Metadata
{
    public class ObjectRelationsFactory
    {
        #region Nested type: PrimaryKeyInfo

        private class PrimaryKeyInfo
        {
            public string PKTable { get; set; }
            public string PKColumn { get; set; }
        }

        #endregion

        #region Quick and dirty DB objects class implementation

        #region Nested type: TableDataBaseObject

        private class TableDataBaseObject : IDataBaseObject
        {
            public TableDataBaseObject(string objectCatalog, string objectName, string objectSchema, ICatalog catalog)
            {
                ObjectCatalog = objectCatalog;
                ObjectName = objectName;
                ObjectSchema = objectSchema;
                Catalog = catalog;
            }

            #region IDataBaseObject Members

            public string ObjectCatalog { get; private set; }

            public string ObjectName { get; private set; }

            public string ObjectSchema { get; private set; }

            public ICatalog Catalog { get; private set; }

            public void Reload(bool throwOnError)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        #endregion

        #region Nested type: TableResultSet

        private class TableResultSet : IResultSet
        {
            public TableResultSet(int resultIndex, ColumnInfoCollection columns, ResultType type)
            {
                ResultIndex = resultIndex;
                Columns = columns;
                Type = type;
            }

            #region IResultSet Members

            public int ResultIndex { get; private set; }

            public ColumnInfoCollection Columns { get; private set; }

            public ResultType Type { get; private set; }

            #endregion
        }

        #endregion

        #endregion

        #region Private fields

        private readonly ITableInfo _associatieveTable;
        private readonly CslaObjectInfoCollection _cslaObjects;
        private readonly CslaGeneratorUnit _currentUnit;
        private readonly IDataBaseObject _dbObject;
        private readonly AssociativeEntity _entity;
        private readonly CslaObjectInfo _mainObjectInfo;
        private readonly PropertyCollection _mainRootCriteriaProperties;
        private readonly IResultSet _resultSet;
        private readonly CslaObjectInfo _secondaryObjectInfo;
        private readonly PropertyCollection _secondaryRootCriteriaProperties;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ObjectFactory class.
        /// </summary>
        /// <param name="currentUnit">The current unit.</param>
        /// <param name="entity">The associative entity.</param>
        public ObjectRelationsFactory(CslaGeneratorUnit currentUnit, AssociativeEntity entity)
        {
            _currentUnit = currentUnit;
            _cslaObjects = _currentUnit.CslaObjects;
            _entity = entity;
            _mainObjectInfo = _cslaObjects.Find(_entity.MainObject);
            _mainRootCriteriaProperties = GetCriteriaProperties(_mainObjectInfo);

            if (entity.RelationType == ObjectRelationType.MultipleToMultiple)
            {
                _secondaryObjectInfo = _cslaObjects.Find(_entity.SecondaryObject);
                _secondaryRootCriteriaProperties = GetCriteriaProperties(_secondaryObjectInfo);

                _associatieveTable = FindAssociativeTable(_mainObjectInfo, _secondaryObjectInfo);

                _resultSet = new TableResultSet(
                    _associatieveTable.ResultIndex,
                    _associatieveTable.Columns,
                    _associatieveTable.Type);

                _dbObject = new TableDataBaseObject(
                    _associatieveTable.ObjectCatalog,
                    _associatieveTable.ObjectName,
                    _associatieveTable.ObjectSchema,
                    _associatieveTable.Catalog);
            }
        }

        #endregion

        #region Object building

        public void BuildOneToMultipleObjects()
        {
            StringBuilder sb;

            // make property if needed
            ChildProperty child;
            if (_mainObjectInfo.ChildCollectionProperties.Contains(_entity.MainPropertyName))
                child = _mainObjectInfo.ChildCollectionProperties.Find(_entity.MainPropertyName);
            else
            {
                child = new ChildProperty {Name = _entity.MainPropertyName};
                _mainObjectInfo.ChildCollectionProperties.Add(child);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added ChildProperty {0} to {1} object.",
                                _entity.MainPropertyName,
                                _mainObjectInfo.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }
            child.ParameterName = _entity.MainPropertyName;
            child.TypeName = _entity.MainCollectionTypeName;
            child.DeclarationMode = PropertyDeclaration.Managed;
            child.ReadOnly = true;
            child.Nullable = false;
            child.LazyLoad = _entity.MainLazyLoad;
            child.LoadingScheme = _entity.MainLoadingScheme;
            child.LoadParameters = _entity.MainLoadParameters;
            child.Access = PropertyAccess.IsPublic;
            child.Undoable = true;

            // make collection if needed
            var coll = _cslaObjects.Find(_entity.MainCollectionTypeName);
            if (coll == null)
            {
                coll = new CslaObjectInfo(_currentUnit)
                           {
                               ObjectType = CslaObjectType.EditableChildCollection,
                               ObjectName = _entity.MainCollectionTypeName
                           };
                _currentUnit.CslaObjects.Add(coll);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added {0} collection object.", _entity.MainCollectionTypeName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // populate collection
            coll.LazyLoad = _entity.MainLazyLoad;
            coll.ParentProperties = _mainRootCriteriaProperties;
            coll.ParentType = _entity.MainObject;
            coll.ItemType = _entity.MainItemTypeName;

            var item = _cslaObjects.Find(_entity.MainItemTypeName);
            if (item == null)
            {
                item = new CslaObjectInfo(_currentUnit)
                           {
                               ObjectType = CslaObjectType.EditableChild,
                               ObjectName = _entity.MainItemTypeName
                           };
                _currentUnit.CslaObjects.Add(item);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added {0} collection item object.", _entity.MainItemTypeName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // populate collection item
            item.LazyLoad = _entity.MainLazyLoad;
            item.ParentInsertOnly = true;
            item.ParentProperties = _mainRootCriteriaProperties;
            item.ParentType = _entity.MainCollectionTypeName;
        }

        public void BuildMultipleToMultipleObjects()
        {
            BuildOneToMultipleObjects();
            StringBuilder sb;

            ChildProperty child;
            if (_secondaryObjectInfo.ChildCollectionProperties.Contains(_entity.SecondaryPropertyName))
                child = _secondaryObjectInfo.ChildCollectionProperties.Find(_entity.SecondaryPropertyName);
            else
            {
                child = new ChildProperty {Name = _entity.SecondaryPropertyName};
                _secondaryObjectInfo.ChildCollectionProperties.Add(child);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added ChildProperty {0} to {1} object.",
                                _entity.SecondaryPropertyName,
                                _secondaryObjectInfo.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }
            child.ParameterName = _entity.SecondaryPropertyName;
            child.TypeName = _entity.SecondaryCollectionTypeName;
            child.DeclarationMode = PropertyDeclaration.Managed;
            child.ReadOnly = true;
            child.Nullable = false;
            child.LazyLoad = _entity.SecondaryLazyLoad;
            child.LoadingScheme = _entity.SecondaryLoadingScheme;
            child.LoadParameters = _entity.SecondaryLoadParameters;
            child.Access = PropertyAccess.IsPublic;
            child.Undoable = true;

            // make collection if needed
            var coll = _cslaObjects.Find(_entity.SecondaryCollectionTypeName);
            if (coll == null)
            {
                coll = new CslaObjectInfo(_currentUnit)
                           {
                               ObjectType = CslaObjectType.EditableChildCollection,
                               ObjectName = _entity.SecondaryCollectionTypeName
                           };
                _currentUnit.CslaObjects.Add(coll);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added {0} collection object.", _entity.SecondaryCollectionTypeName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // populate collection
            coll.LazyLoad = _entity.SecondaryLazyLoad;
            coll.ParentProperties = _secondaryRootCriteriaProperties;
            coll.ParentType = _entity.SecondaryObject;
            coll.ItemType = _entity.SecondaryItemTypeName;

            var item = _cslaObjects.Find(_entity.SecondaryItemTypeName);
            if (item == null)
            {
                item = new CslaObjectInfo(_currentUnit)
                           {
                               ObjectType = CslaObjectType.EditableChild,
                               ObjectName = _entity.SecondaryItemTypeName
                           };
                _currentUnit.CslaObjects.Add(item);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added {0} collection item object.", _entity.SecondaryItemTypeName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // populate collection item
            item.LazyLoad = _entity.SecondaryLazyLoad;
            item.ParentInsertOnly = true;
            item.ParentProperties = _secondaryRootCriteriaProperties;
            item.ParentType = _entity.SecondaryCollectionTypeName;
        }

        private static PropertyCollection GetCriteriaProperties(CslaObjectInfo objectInfo)
        {
            var secondaryCriteriaInfo = typeof (CslaObjectInfo).GetProperty("CriteriaObjects");
            var secondaryCriteriaObjects = secondaryCriteriaInfo.GetValue(objectInfo, null);
            var propertyCollection = new PropertyCollection();
            foreach (var crit in (CriteriaCollection) secondaryCriteriaObjects)
            {
                foreach (var prop in crit.Properties)
                {
                    propertyCollection.Add(prop);
                }
            }

            return propertyCollection;
        }

        public static ITableInfo FindAssociativeTable(CslaObjectInfo main, CslaObjectInfo secondary)
        {
            var associativeTableCandidates = new List<string>();
            var mainPKInfos = new List<PrimaryKeyInfo>();
            var secondaryPKInfos = new List<PrimaryKeyInfo>();

            foreach (var property in main.ValueProperties)
            {
                if (property.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                    property.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.UserProvidedPK)
                {
                    mainPKInfos.Add(new PrimaryKeyInfo
                                        {
                                            PKTable = property.DbBindColumn.ObjectName,
                                            PKColumn = property.DbBindColumn.ColumnName
                                        });
                }
            }

            foreach (var property in secondary.ValueProperties)
            {
                if (property.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                    property.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.UserProvidedPK)
                {
                    secondaryPKInfos.Add(new PrimaryKeyInfo
                                             {
                                                 PKTable = property.DbBindColumn.ObjectName,
                                                 PKColumn = property.DbBindColumn.ColumnName
                                             });
                }
            }

            foreach (var constraint in GeneratorController.Catalog.ForeignKeyConstraints)
            {
                foreach (var pkInfo in mainPKInfos)
                {
                    if (pkInfo.PKTable == constraint.PKTable.ObjectName &&
                        pkInfo.PKColumn == constraint.Columns[0].FKColumn.ColumnName &&
                        constraint.Columns[0].FKColumn.IsPrimaryKey)
                    {
                        associativeTableCandidates.Add(constraint.ConstraintTable.ObjectName);
                    }
                }
            }

            foreach (var constraint in GeneratorController.Catalog.ForeignKeyConstraints)
            {
                foreach (var pkInfo in secondaryPKInfos)
                {
                    if (pkInfo.PKTable == constraint.PKTable.ObjectName &&
                        pkInfo.PKColumn == constraint.Columns[0].FKColumn.ColumnName &&
                        constraint.Columns[0].FKColumn.IsPrimaryKey)
                    {
                        foreach (var table in associativeTableCandidates)
                        {
                            if (table == constraint.ConstraintTable.ObjectName)
                            {
                                // return the first FK table common to both PK tables
                                return constraint.ConstraintTable;
                            }
                        }
                    }
                }
            }

            return null;
        }

        #endregion

        #region ValueProperty building

        public void PopulateMainObject()
        {
            var currentCslaObject = _cslaObjects.Find(_entity.MainItemTypeName);
            var selectedColumns = FilterOutSelectedColumns(currentCslaObject, _mainRootCriteriaProperties);
            if (selectedColumns.Count > 0)
            {
                var currentFactory = new ObjectFactory(_currentUnit, currentCslaObject);

                currentFactory.AddProperties(currentCslaObject, _dbObject, _resultSet, selectedColumns, true);
            }

            var removeList = FindInvalidProperties(currentCslaObject, _mainRootCriteriaProperties);
            if (removeList.Count > 0)
            {
                // ask user confirmation
                var msg = new StringBuilder();
                msg.Append(
                    "The properties listed below are \"Parent Properties\" and should be removed.\r\n\r\n"+
                    "Do you want to remove the following properties:" +
                    Environment.NewLine);
                foreach (var valueProperty in removeList)
                {
                    msg.AppendFormat(" - {0}.{1}\r\n", currentCslaObject.ObjectName, valueProperty.Name);
                }

                var response = MessageBox.Show(msg.ToString(),
                                                        @"Invalid ValueProperty found.",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Error);
                if (response == DialogResult.Yes)
                {
                    var sb = new StringBuilder();
                    sb.Append("Successfully removed the following properties:" + Environment.NewLine);

                    foreach (var valueProperty in removeList)
                    {
                        currentCslaObject.ValueProperties.Remove(valueProperty);
                        sb.AppendFormat("\t{0}.{1}\r\n", currentCslaObject.ObjectName, valueProperty.Name);
                    }

                    // display message to the user
                    OutputWindow.Current.AddOutputInfo(sb.ToString());
                }
            }
        }

        public void PopulateSecondaryObject()
        {
            var currentCslaObject = _cslaObjects.Find(_entity.SecondaryItemTypeName);
            var selectedColumns = FilterOutSelectedColumns(currentCslaObject, _secondaryRootCriteriaProperties);
            if (selectedColumns.Count == 0)
                return;

            var currentFactory = new ObjectFactory(_currentUnit, currentCslaObject);
            currentFactory.AddProperties(currentCslaObject, _dbObject, _resultSet, selectedColumns, true);
        }

        private List<IColumnInfo> FilterOutSelectedColumns(CslaObjectInfo currentCslaObject, PropertyCollection rootCriteriaProperties)
        {
            var selectedColumns = new List<IColumnInfo>();
            foreach (var column in _associatieveTable.Columns)
            {
                var filter = false;
                // filter out SoftDelete column
                if (GeneratorController.Current.CurrentUnit.Params.SpBoolSoftDeleteColumn == column.ColumnName)
                    filter = true;

                if (!filter)
                {
                    foreach (var property in rootCriteriaProperties)
                    {
                        // filter out properties the root's Criteria properties (used as Parent Properties)
                        if (column.ColumnName == property.Name)
                        {
                            filter = true;
                            break;
                        }
                    }
                }

                if (!filter)
                {
                    foreach (var valueProperty in currentCslaObject.ValueProperties)
                    {
                        // filter out existing properties
                        if (column.ColumnName == valueProperty.Name)
                        {
                            filter = true;
                            break;
                        }
                    }
                }

                if (!filter)
                    selectedColumns.Add(column);
            }
            return selectedColumns;
        }

        private static List<ValueProperty> FindInvalidProperties(CslaObjectInfo currentCslaObject, PropertyCollection rootCriteriaProperties)
        {
            /*
             * 1. An object value property is invalid when it matches a parent property.
             * 2. For the time being, an associative object's parent properties are the root object's criteria properties.
             * 3. Matches are found by property name only.
             */

            var invalidValueProperties = new List<ValueProperty>();
            foreach (var property in rootCriteriaProperties)
            {
                foreach (var valueProperty in currentCslaObject.ValueProperties)
                {
                    // filter out properties in Criteria properties / Parent properties
                    if (property.Name == valueProperty.Name)
                    {
                        invalidValueProperties.Add(valueProperty);
                    }
                }
            }
            return invalidValueProperties;
        }

        #endregion
    }
}