using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CslaGenerator.CodeGen;
using CslaGenerator.Controls;
using CslaGenerator.Util;
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

        private readonly ITableInfo _associativeTable;
        private readonly ITableInfo _associatedTable;
        private readonly CslaObjectInfoCollection _cslaObjects;
        private readonly CslaGeneratorUnit _currentUnit;
        private readonly IDataBaseObject _dbObject;
        private readonly AssociativeEntity _entity;
        private readonly IResultSet _resultSet;
        public CslaObjectInfo MainObjectInfo;
        public CriteriaPropertyCollection MainRootCriteriaProperties;
        public CslaObjectInfo SecondaryObjectInfo;
        public CriteriaPropertyCollection SecondaryRootCriteriaProperties;
        public CslaObjectInfo FacadeObjectInfo;
        public CriteriaPropertyCollection FacadeRootCriteriaProperties;

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
            MainObjectInfo = _cslaObjects.Find(_entity.MainObject);
            MainRootCriteriaProperties = GetCriteriaProperties(MainObjectInfo);

            if (entity.RelationType == ObjectRelationType.MultipleToMultiple)
            {
                SecondaryObjectInfo = _cslaObjects.Find(_entity.SecondaryObject);
                SecondaryRootCriteriaProperties = GetCriteriaProperties(SecondaryObjectInfo);

                _associativeTable = FindAssociativeTable(MainObjectInfo, SecondaryObjectInfo);

                _resultSet = new TableResultSet(
                    _associativeTable.ResultIndex,
                    _associativeTable.Columns,
                    _associativeTable.Type);

                _dbObject = new TableDataBaseObject(
                    _associativeTable.ObjectCatalog,
                    _associativeTable.ObjectName,
                    _associativeTable.ObjectSchema,
                    _associativeTable.Catalog);
            }
            else
            {
                var mainItemObjectInfo = _cslaObjects.Find(_entity.MainItemTypeName);

                _associatedTable = FindAssociatedTable(MainObjectInfo, mainItemObjectInfo);

                _resultSet = new TableResultSet(
                    _associatedTable.ResultIndex,
                    _associatedTable.Columns,
                    _associatedTable.Type);

                _dbObject = new TableDataBaseObject(
                    _associatedTable.ObjectCatalog,
                    _associatedTable.ObjectName,
                    _associatedTable.ObjectSchema,
                    _associatedTable.Catalog);
            }
        }

        #endregion

        #region Object builder

        public void BuildRelationObjects(AssociativeEntity.EntityFacade entity)
        {
            StringBuilder sb;
            var isMultipleToMultiple = (_entity.RelationType == ObjectRelationType.MultipleToMultiple);

            // make property if needed
            ChildProperty child;
            if (FacadeObjectInfo.ChildCollectionProperties.Contains(entity.PropertyName))
                child = FacadeObjectInfo.ChildCollectionProperties.Find(entity.PropertyName);
            else
            {
                child = new ChildProperty { Name = entity.PropertyName };
                FacadeObjectInfo.ChildCollectionProperties.Add(child);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added ChildProperty {0} to {1} object.",
                                entity.PropertyName,
                                FacadeObjectInfo.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }
            child.ParameterName = entity.PropertyName;
            child.TypeName = entity.CollectionTypeName;
            child.DeclarationMode = PropertyDeclaration.Managed;
            child.ReadOnly = FacadeObjectInfo.ObjectType == CslaObjectType.ReadOnlyObject;
            child.Nullable = false;
            child.LazyLoad = entity.LazyLoad;
            child.LoadingScheme = entity.LoadingScheme;

            // LoadParameters might be re-filled by BuildCollectionCriteriaGet
            child.LoadParameters = entity.LoadParameters;
            child.Access = PropertyAccess.IsPublic;
            child.Undoable = true;

            // make collection if needed
            var coll = _cslaObjects.Find(entity.CollectionTypeName);
            if (coll == null)
            {
                coll = new CslaObjectInfo(_currentUnit)
                           {
                               ObjectType = CslaObjectType.EditableChildCollection,
                               ObjectName = entity.CollectionTypeName
                           };
                _currentUnit.CslaObjects.Add(coll);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added {0} collection object.", entity.CollectionTypeName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // populate collection
            coll.ParentType = entity.ObjectName;
            coll.ParentProperties = BuildParentProperties(coll);
            coll.ItemType = entity.ItemTypeName;

            // handle collection criteria
            BuildCollectionCriteriaGet(coll, entity, child);

            /* handle item */
            var item = _cslaObjects.Find(entity.ItemTypeName);
            if (item == null)
            {
                item = new CslaObjectInfo(_currentUnit)
                           {
                               ObjectType = CslaObjectType.EditableChild,
                               ObjectName = entity.ItemTypeName
                           };
                _currentUnit.CslaObjects.Add(item);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added {0} collection item object.", entity.ItemTypeName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // populate collection item
            if (!isMultipleToMultiple)
                item.ParentInsertOnly = true;
            else
                item.ParentInsertOnly = false;
            item.ParentType = entity.CollectionTypeName;
            item.ParentProperties = BuildParentProperties(item);
            var suffix = string.Empty;
            var objectName = entity.ItemTypeName;
            if (isMultipleToMultiple &&
                !_entity.MainLazyLoad &&
                !_entity.SecondaryLazyLoad &&
                _entity.Parent.Params.ORBItemsUseSingleSP)
            {
                suffix = _entity.Parent.Params.ORBSingleSPSuffix;
                objectName = _entity.MainItemTypeName;
            }
            if (item.ObjectType != CslaObjectType.ReadOnlyObject)
            {
                if (item.GenerateDataPortalInsert)
                    item.InsertProcedureName = _entity.Parent.Params.GetAddProcName(objectName) + suffix;
                if (item.GenerateDataPortalUpdate)
                    item.UpdateProcedureName = _entity.Parent.Params.GetUpdateProcName(objectName) + suffix;
            }
            else
            {
                item.InsertProcedureName = string.Empty;
                item.UpdateProcedureName = string.Empty;
            }

            // prepare for deprecate
            item.DeleteProcedureName = string.Empty;

            // handle collection item CriteriaNew
            if (!isMultipleToMultiple)
            {
                BuildCollectionItemCriteriaNew(item, null, null, false);
            }
            else
            {
                if (FacadeObjectInfo == MainObjectInfo)
                    BuildCollectionItemCriteriaNew(item, null, SecondaryObjectInfo, true);
                else
                    BuildCollectionItemCriteriaNew(item, null, MainObjectInfo, true);
            }

            // handle collection item Criteria
            if (!isMultipleToMultiple)
            {
                BuildCollectionItemCriteriaDelete(item, null, null, false);
            }
            else
            {
                if (FacadeObjectInfo == MainObjectInfo)
                    BuildCollectionItemCriteriaDelete(item, MainObjectInfo, SecondaryObjectInfo, true);
                else
                    BuildCollectionItemCriteriaDelete(item, SecondaryObjectInfo, MainObjectInfo, true);
            }
        }

        #endregion

        #region Collection CriteriaGet

        private void BuildCollectionCriteriaGet(CslaObjectInfo info, AssociativeEntity.EntityFacade entity, ChildProperty child)
        {
            const string critName = "CriteriaGet";

            var selfLoad = CslaTemplateHelperCS.GetSelfLoad(info);
            if (!selfLoad)
            {
                DeleteDefaultCollectionCriteria(info, critName);
                return;
            }

            StringBuilder sb;

            // make collection criteria if needed
            var collCriteria = info.CriteriaObjects;
            Criteria criteria = null;
            foreach (var crit in collCriteria)
            {
                if (CheckAndSetCollectionCriteriaGet(crit, info, critName))
                {
                    criteria = crit;
                    break;
                }
            }

            if (criteria == null)
            {
                criteria = new Criteria();
                criteria.Name = critName;
                SetCollectionCriteriaGet(criteria, info, critName);
                info.CriteriaObjects.Add(criteria);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added criteria {0} to {1} collection object.", critName, info.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            if (criteria.Name != critName)
                return;

            if (criteria.Properties.Count > 0)
            {
                // clear CriteriaGet properties
                criteria.Properties.Clear();

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully removed all criteria properties of {0} on {1} collection object.",
                                critName, info.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // populate collection criteria properties
            var addedProps = new List<string>();
            if (entity.LoadProperties.Count == 0)
            {
                criteria.Properties.AddRange(CriteriaPropertyCollection.Clone(FacadeRootCriteriaProperties));
                foreach (var property in FacadeRootCriteriaProperties)
                    addedProps.Add(property.Name);
            }
            else
            {
                criteria.Properties.AddRange(CriteriaPropertyCollection.Clone(entity.LoadProperties));
                foreach (var property in entity.LoadProperties)
                    addedProps.Add(property.Name);
            }

            if (addedProps.Count > 0)
            {
                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added the following properties to criteria {0}:" + Environment.NewLine, criteria.Name);
                foreach (var propName in addedProps)
                {
                    sb.AppendFormat("\t{0}.{1}.{2}" + Environment.NewLine, critName, info.ObjectName, propName);
                }
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // is it non-root?
            var entityCslaObject = _cslaObjects.Find(entity.ObjectName);
            if (entityCslaObject != null)
            {
                if (CslaTemplateHelperCS.IsNotRootType(entityCslaObject))
                {
                    // re-fill LoadParameters with child criteria
                    child.LoadParameters.Clear();
                    foreach (var property in criteria.Properties)
                    {
                        child.LoadParameters.Add(new Parameter(criteria, property));
                    }
                }
            }
        }

        private void DeleteDefaultCollectionCriteria(CslaObjectInfo info, string critName)
        {
            StringBuilder sb;

            var collCriteria = info.CriteriaObjects;
            foreach (var crit in collCriteria)
            {
                if (crit.Name != critName)
                {
                    if (crit.Properties.Count > 0)
                    {
                        // clear CriteriaGet properties
                        crit.Properties.Clear();

                        // display message to the user
                        sb = new StringBuilder();
                        sb.AppendFormat("Not SelfLoad - successfully removed all criteria properties of {0} on {1} collection object.", critName, info.ObjectName);
                        OutputWindow.Current.AddOutputInfo(sb.ToString());
                    }
                }
                collCriteria.Remove(crit);
                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Not SelfLoad - successfully removed criteria {0} to {1} collection object.", critName, info.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
                break;
            }
        }

        private bool CheckAndSetCollectionCriteriaGet(Criteria crit, CslaObjectInfo info, string critName)
        {
            if (crit.Name != critName)
            {
                if (crit.GetOptions.Factory)
                {
                    if (crit.GetOptions.Procedure || crit.GetOptions.DataPortal)
                        return crit.GetOptions.ProcedureName != string.Empty;

                    return true;
                }
            }
            else
            {
                SetCollectionCriteriaGet(crit, info, critName);
                return true;
            }
            return false;
        }

        private void SetCollectionCriteriaGet(Criteria crit, CslaObjectInfo info, string critName)
        {
            if (crit.Name != critName)
                crit.GetOptions.Factory = true;
            else
            {
                crit.CreateOptions.Factory = false;
                crit.CreateOptions.AddRemove = false;
                crit.CreateOptions.DataPortal = false;
                crit.CreateOptions.RunLocal = false;
                crit.CreateOptions.Procedure = false;
                crit.CreateOptions.ProcedureName = string.Empty;

                crit.GetOptions.Factory = true;
                crit.GetOptions.AddRemove = false;
                crit.GetOptions.DataPortal = true;
                crit.GetOptions.RunLocal = false;
                crit.GetOptions.Procedure = true;
                crit.GetOptions.ProcedureName = _entity.Parent.Params.GetGetProcName(info.ObjectName);

                crit.DeleteOptions.Factory = false;
                crit.DeleteOptions.AddRemove = false;
                crit.DeleteOptions.DataPortal = false;
                crit.DeleteOptions.RunLocal = false;
                crit.DeleteOptions.Procedure = false;
                crit.DeleteOptions.ProcedureName = string.Empty;
            }
        }

        #endregion

        #region Collection Item CriteriaNew

        private void BuildCollectionItemCriteriaNew(CslaObjectInfo info, CslaObjectInfo myRootInfo, CslaObjectInfo otherRootInfo, bool isMultipleToMultiple)
        {
            const string critName = "CriteriaNew";

            // don't generate CriteriaNew for read-only objects
            if (info.ObjectType == CslaObjectType.ReadOnlyObject)
            {
                RemoveDefaultItemCriteria(info, critName);
                return;
            }

            StringBuilder sb;

            // make collection item criteria if needed
            var itemCriteria = info.CriteriaObjects;
            Criteria criteria = null;
            foreach (var crit in itemCriteria)
            {
                if (CheckCollectionItemCriteriaNew(crit, critName))
                {
                    criteria = crit;
                    break;
                }
            }

            if (criteria == null)
            {
                criteria = new Criteria { Name = critName };
                SetCollectionItemCriteriaNew(criteria, critName);
                info.CriteriaObjects.Add(criteria);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added criteria {0} to {1} item object.", critName, info.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            if (criteria.Name != critName)
                return;

            if (criteria.Properties.Count > 0)
            {
                // clear CriteriaNew properties
                criteria.Properties.Clear();

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully removed all criteria properties of {0} on {1} item object.", critName, info.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // this is a 1 to N relation; no criteria properties needed
            if (!isMultipleToMultiple)
                return;

            // populate collection CriteriaNew properties
            var addedProps = AddCriteriaProperties(info, criteria, myRootInfo, otherRootInfo, true, true);

            if (addedProps.Count > 0)
            {
                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added the following properties to criteria {0}:" + Environment.NewLine, criteria.Name);
                foreach (var propName in addedProps)
                {
                    sb.AppendFormat("\t{0}.{1}.{2}" + Environment.NewLine, critName, info.ObjectName, propName);
                }
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }
        }

        private static void RemoveDefaultItemCriteria(CslaObjectInfo info, string critName)
        {
            StringBuilder sb;

            var itemCriteria = info.CriteriaObjects;
            foreach (var crit in itemCriteria)
            {
                if (crit.Name != critName)
                {
                    if (crit.Properties.Count > 0)
                    {
                        // clear CriteriaGet properties
                        crit.Properties.Clear();

                        // display message to the user
                        sb = new StringBuilder();
                        sb.AppendFormat("ReadOnly object - successfully removed all criteria properties of {0} on {1} item object.", critName, info.ObjectName);
                        OutputWindow.Current.AddOutputInfo(sb.ToString());
                    }
                }
                itemCriteria.Remove(crit);
                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("ReadOnly object - successfully removed criteria {0} to {1} item object.", critName, info.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
                break;
            }
        }

        private bool CheckCollectionItemCriteriaNew(Criteria crit, string critName)
        {
            if (crit.Name != critName)
            {
                if (crit.CreateOptions.Factory)
                {
                    return true;
                }
            }
            else
            {
                SetCollectionItemCriteriaNew(crit, critName);
                return true;
            }
            return false;
        }

        private void SetCollectionItemCriteriaNew(Criteria crit, string critName)
        {
            if (crit.Name != critName)
            {
                crit.CreateOptions.Factory = true;
            }
            else
            {
                crit.CreateOptions.Factory = true;
                crit.CreateOptions.AddRemove = true;
                crit.CreateOptions.DataPortal = true;
                crit.CreateOptions.RunLocal = true;
                crit.CreateOptions.Procedure = false;
                crit.CreateOptions.ProcedureName = string.Empty;

                crit.GetOptions.Factory = false;
                crit.GetOptions.AddRemove = false;
                crit.GetOptions.DataPortal = false;
                crit.GetOptions.RunLocal = false;
                crit.CreateOptions.Procedure = false;
                crit.GetOptions.ProcedureName = string.Empty;

                crit.DeleteOptions.Factory = false;
                crit.DeleteOptions.AddRemove = _entity.RelationType == ObjectRelationType.MultipleToMultiple;
                crit.DeleteOptions.DataPortal = false;
                crit.DeleteOptions.RunLocal = false;
                crit.CreateOptions.Procedure = false;
                crit.DeleteOptions.ProcedureName = string.Empty;
            }
        }

        #endregion

        #region Collection Item CriteriaDelete

        private void BuildCollectionItemCriteriaDelete(CslaObjectInfo info, CslaObjectInfo myRootInfo, CslaObjectInfo otherRootInfo, bool isMultipleToMultiple)
        {
            const string critName = "CriteriaDelete";

            // don't generate CriteriaNew for read-only objects
            if (info.ObjectType == CslaObjectType.ReadOnlyObject)
            {
                RemoveDefaultItemCriteria(info, critName);
                return;
            }

            StringBuilder sb;

            // make collection item criteria if needed
            var itemCriteria = info.CriteriaObjects;
            Criteria criteria = null;
            foreach (var crit in itemCriteria)
            {
                if (CheckCollectionItemCriteriaDelete(crit, info, myRootInfo, critName))
                {
                    criteria = crit;
                    break;
                }
            }

            if (criteria == null)
            {
                criteria = new Criteria { Name = critName };
                SetCollectionItemCriteriaDelete(criteria, info, myRootInfo == MainObjectInfo, critName);
                info.CriteriaObjects.Add(criteria);

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added criteria {0} to {1} item object.", critName, info.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            if (criteria.Name != critName)
                return;

            if (criteria.Properties.Count > 0)
            {
                // clear CriteriaDelete properties
                criteria.Properties.Clear();

                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully removed all criteria properties of {0} on {1} item object.", critName, info.ObjectName);
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }

            // populate collection Criteria properties
            var addedProps = AddCriteriaProperties(info, criteria, myRootInfo, otherRootInfo, false, isMultipleToMultiple);

            if (addedProps.Count > 0)
            {
                // display message to the user
                sb = new StringBuilder();
                sb.AppendFormat("Successfully added the following properties to criteria {0}:" + Environment.NewLine, criteria.Name);
                foreach (var propName in addedProps)
                {
                    sb.AppendFormat("\t{0}.{1}.{2}" + Environment.NewLine, critName, info.ObjectName, propName);
                }
                OutputWindow.Current.AddOutputInfo(sb.ToString());
            }
        }

        private bool CheckCollectionItemCriteriaDelete(Criteria crit, CslaObjectInfo info, CslaObjectInfo myRootInfo, string critName)
        {
            if (crit.Name != critName)
            {
                var accept = false;
                if (crit.DeleteOptions.Factory)
                {
                    if (crit.DeleteOptions.Procedure || crit.DeleteOptions.DataPortal)
                        accept = crit.DeleteOptions.ProcedureName != string.Empty;
                    else
                        accept = true;
                }
                if (!crit.DeleteOptions.Factory)
                    accept = false;

                return accept;
            }

            SetCollectionItemCriteriaDelete(crit, info, myRootInfo == MainObjectInfo, critName);
            return true;
        }

        private void SetCollectionItemCriteriaDelete(Criteria crit, CslaObjectInfo info, bool isMain, string critName)
        {
            if (crit.Name != critName)
            {
                crit.DeleteOptions.Factory = true;
            }
            else
            {
                var useSameProcedure = _entity.RelationType == ObjectRelationType.MultipleToMultiple &&
                                       !_entity.MainLazyLoad &&
                                       !_entity.SecondaryLazyLoad &&
                                       _entity.Parent.Params.ORBItemsUseSingleSP;
                var suffix = string.Empty;
                var objectName = info.ObjectName;
                if (useSameProcedure)
                {
                    suffix = _entity.Parent.Params.ORBSingleSPSuffix;
                    objectName = _entity.MainItemTypeName;
                }

                crit.CreateOptions.Factory = false;
                crit.CreateOptions.AddRemove = false;
                crit.CreateOptions.DataPortal = false;
                crit.CreateOptions.RunLocal = false;
                crit.CreateOptions.Procedure = false;
                crit.CreateOptions.ProcedureName = string.Empty;

                crit.GetOptions.Factory = false;
                crit.GetOptions.AddRemove = false;
                crit.GetOptions.DataPortal = false;
                crit.GetOptions.RunLocal = false;
                crit.GetOptions.Procedure = false;
                crit.GetOptions.ProcedureName = string.Empty;

                crit.DeleteOptions.Factory = false;
                crit.DeleteOptions.AddRemove = _entity.RelationType == ObjectRelationType.OneToMultiple;
                crit.DeleteOptions.DataPortal = false;
                crit.DeleteOptions.RunLocal = false;
                crit.DeleteOptions.Procedure = !useSameProcedure || isMain;
                crit.DeleteOptions.ProcedureName = _entity.Parent.Params.GetDeleteProcName(objectName) + suffix;
            }
        }

        #endregion

        #region Criteria and Property helpers

        private List<string> AddCriteriaProperties(CslaObjectInfo info, Criteria crit, CslaObjectInfo myRootInfo, CslaObjectInfo otherRootInfo, bool isGet, bool isMultipleToMultiple)
        {
            List<string> addedProperties = new List<string>();
            List<ValueProperty> primaryKeyProperties = new List<ValueProperty>();

            // for 1 to N relations use object ValueProperty instead of root's
            if (!isMultipleToMultiple)
                myRootInfo = info;

            if (!isGet)
            {
                // retrieve own primary key properties
                foreach (ValueProperty prop in myRootInfo.ValueProperties)
                {
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                        primaryKeyProperties.Add(prop);
                }
            }

            if (isMultipleToMultiple || isGet)
            {
                // retrieve related primary key properties
                foreach (ValueProperty prop in otherRootInfo.ValueProperties)
                {
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                        primaryKeyProperties.Add(prop);
                }
            }

            foreach (ValueProperty rootProp in primaryKeyProperties)
            {
                ValueProperty prop = null;
                if (isMultipleToMultiple)
                    prop = GetRelatedValueProperty(rootProp);

                if (prop == null)
                    prop = rootProp;

                if (!crit.Properties.Contains(prop.Name))
                {
                    CriteriaProperty p = new CriteriaProperty(prop.Name, prop.PropertyType);
                    p.DbBindColumn = (DbBindColumn)prop.DbBindColumn.Clone();
                    crit.Properties.Add(p);
                    addedProperties.Add(prop.Name);
                }
            }

            return addedProperties;
        }

        private ValueProperty GetRelatedValueProperty(ValueProperty prop)
        {
            foreach (var constraint in _associativeTable.Catalog.ForeignKeyConstraints)
            {
                if (constraint.ConstraintTable.ObjectName == _associativeTable.ObjectName)
                {
                    if (constraint.PKTable.ObjectName == prop.DbBindColumn.DatabaseObject.ObjectName)
                    {
                        if (constraint.Columns[0].PKColumn.ColumnName == prop.DbBindColumn.ColumnName)
                        {
                            IColumnInfo col = constraint.Columns[0].PKColumn;
                            var info = new CslaObjectInfo();
                            var newProp = new ValueProperty();
                            newProp.Name = prop.Name;
                            newProp.PropertyType = TypeHelper.GetTypeCodeEx(col.ManagedType);
                            var currentFactory = new ObjectFactory(_currentUnit, info);
                            currentFactory.SetValuePropertyInfo(_dbObject, _resultSet, col, newProp);
                            return newProp;
                        }
                    }
                }
            }

            return null;
        }

        private static CriteriaPropertyCollection GetCriteriaProperties(CslaObjectInfo objectInfo)
        {
            var criteriaInfo = typeof(CslaObjectInfo).GetProperty("CriteriaObjects");
            var criteriaObjects = criteriaInfo.GetValue(objectInfo, null);
            var criteriaPropertyCollection = new CriteriaPropertyCollection();
            foreach (var crit in (CriteriaCollection)criteriaObjects)
            {
                foreach (var prop in crit.Properties)
                {
                    if (crit.GetOptions.Factory)
                        criteriaPropertyCollection.Add(prop);
                }
            }

            return criteriaPropertyCollection;
        }

        private static PropertyCollection BuildParentProperties(CslaObjectInfo info)
        {
            var propertyCollection = new PropertyCollection();

            CslaObjectInfo parent = info.FindParent(info);
            if (parent != null)
            {
                foreach (Property pvp in parent.ValueProperties)
                {
                    ValueProperty prop = parent.GetAllValueProperties().Find(pvp.Name);
                    if (prop != null && prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                        propertyCollection.Add(prop);
                }
            }

            return propertyCollection;
        }

        #endregion

        #region Table helpers

        public static ITableInfo FindAssociativeTable(CslaObjectInfo main, CslaObjectInfo secondary)
        {
            if (main == null)
                return null;
            if (secondary == null)
                return null;

            var associativeTableCandidates = new List<string>();
            var mainPKInfos = new List<PrimaryKeyInfo>();
            var secondaryPKInfos = new List<PrimaryKeyInfo>();

            // get all PK of main CslaObjectInfo
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

            // get all PK of secondary CslaObjectInfo
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

            // get FK tables from constraints with a PK that match main PKs
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

            // check FK tables with two constraints that match main PKs and secondary PKs
            // and return the first matching table found
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

        public static ITableInfo FindAssociatedTable(CslaObjectInfo main, CslaObjectInfo item)
        {
            if (main == null)
                return null;
            if (item == null)
                return null;

            var associatedConstraintCandidates = new List<IForeignKeyConstraint>();
            var mainPKInfos = new List<PrimaryKeyInfo>();
            var itemPKInfos = new List<PrimaryKeyInfo>();

            // get all PK of main CslaObjectInfo
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

            // if there is an explicit FK Constraint, use it (in fact use the first found that matches)
            foreach (var property in item.ValueProperties)
            {
                if (property.FKConstraint != string.Empty)
                {
                    // check the FK Constraint exists on the catalog
                    foreach (var constraint in GeneratorController.Catalog.ForeignKeyConstraints)
                    {
                        if (constraint.ConstraintName == property.FKConstraint)
                        {
                            // check the constraint's PK matches root's PK
                            if (constraint.PKTable.ObjectName == mainPKInfos[0].PKTable &&
                                constraint.Columns[0].PKColumn.ColumnName == mainPKInfos[0].PKColumn)
                            {
                                return constraint.ConstraintTable;
                            }
                        }
                    }
                }
            }

            // get all PK of item CslaObjectInfo
            foreach (var property in item.ValueProperties)
            {
                if (property.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                    property.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.UserProvidedPK)
                {
                    itemPKInfos.Add(new PrimaryKeyInfo
                    {
                        PKTable = property.DbBindColumn.ObjectName,
                        PKColumn = property.DbBindColumn.ColumnName
                    });
                }
            }

            // get constraint definitions with a PK that match main PKs
            foreach (var constraint in GeneratorController.Catalog.ForeignKeyConstraints)
            {
                foreach (var pkInfo in mainPKInfos)
                {
                    if (pkInfo.PKTable == constraint.PKTable.ObjectName &&
                        pkInfo.PKColumn == constraint.Columns[0].FKColumn.ColumnName &&
                        constraint.Columns[0].PKColumn.IsPrimaryKey)
                    {
                        associatedConstraintCandidates.Add(constraint);
                    }
                }
            }

            // check constraints with an FK that matches item PKs tables
            // and return the first table where found
            foreach (var constraint in associatedConstraintCandidates)
            {
                foreach (var itempkInfo in itemPKInfos)
                {
                    if (itempkInfo.PKTable == constraint.ConstraintTable.ObjectName &&
                        constraint.Columns[0].FKColumn.ColumnName == constraint.Columns[0].PKColumn.ColumnName &&
                        constraint.Columns[0].PKColumn.IsPrimaryKey)
                    {
                        // return the first FK table common to both PK tables
                        return constraint.ConstraintTable;
                    }
                }
            }

            return null;
        }

        #endregion

        #region ValueProperty building

        public void PopulateRelationObjects(string itemTypeName, CriteriaPropertyCollection rootCriteriaProperties)
        {
            var currentCslaObject = _cslaObjects.Find(itemTypeName);
            var selectedColumns = FilterOutSelectedColumns(currentCslaObject, rootCriteriaProperties);
            if (selectedColumns.Count > 0)
            {
                var currentFactory = new ObjectFactory(_currentUnit, currentCslaObject);
                currentFactory.AddProperties(currentCslaObject, _dbObject, _resultSet, selectedColumns, true, true);
            }

            var removeList = FindInvalidProperties(currentCslaObject, BuildParentProperties(currentCslaObject));
            if (removeList.Count > 0)
            {
                // ask user confirmation
                var msg = new StringBuilder();
                msg.Append(
                    "The properties listed below are \"Parent Properties\" and should be removed.\r\n\r\n" +
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

        private List<IColumnInfo> FilterOutSelectedColumns(CslaObjectInfo currentCslaObject, CriteriaPropertyCollection rootCriteriaProperties)
        {
            ColumnInfoCollection columnInfoCollection;
            var selectedColumns = new List<IColumnInfo>();
            if (_entity.RelationType == ObjectRelationType.OneToMultiple)
            {
                columnInfoCollection = _associatedTable.Columns;
            }
            else
            {
                columnInfoCollection = _associativeTable.Columns;
            }

            foreach (var column in columnInfoCollection)
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
            }//
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