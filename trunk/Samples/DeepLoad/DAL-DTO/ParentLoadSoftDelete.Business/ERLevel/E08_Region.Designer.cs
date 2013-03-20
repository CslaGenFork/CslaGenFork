using System;
using Csla;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E08_Region (editable child object).<br/>
    /// This is a generated base class of <see cref="E08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E09_CityObjects"/> of type <see cref="E09_CityColl"/> (1:M relation to <see cref="E10_City"/>)<br/>
    /// This class is an item of <see cref="E07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E08_Region : BusinessBase<E08_Region>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_Country_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Region_IDProperty = RegisterProperty<int>(p => p.Region_ID, "Regions ID");
        /// <summary>
        /// Gets the Regions ID.
        /// </summary>
        /// <value>The Regions ID.</value>
        public int Region_ID
        {
            get { return GetProperty(Region_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Region_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_NameProperty = RegisterProperty<string>(p => p.Region_Name, "Regions Name");
        /// <summary>
        /// Gets or sets the Regions Name.
        /// </summary>
        /// <value>The Regions Name.</value>
        public string Region_Name
        {
            get { return GetProperty(Region_NameProperty); }
            set { SetProperty(Region_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E09_Region_Child> E09_Region_SingleObjectProperty = RegisterProperty<E09_Region_Child>(p => p.E09_Region_SingleObject, "E09 Region Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the E09 Region Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E09 Region Single Object.</value>
        public E09_Region_Child E09_Region_SingleObject
        {
            get { return GetProperty(E09_Region_SingleObjectProperty); }
            private set { LoadProperty(E09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E09_Region_ReChild> E09_Region_ASingleObjectProperty = RegisterProperty<E09_Region_ReChild>(p => p.E09_Region_ASingleObject, "E09 Region ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the E09 Region ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E09 Region ASingle Object.</value>
        public E09_Region_ReChild E09_Region_ASingleObject
        {
            get { return GetProperty(E09_Region_ASingleObjectProperty); }
            private set { LoadProperty(E09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E09_CityColl> E09_CityObjectsProperty = RegisterProperty<E09_CityColl>(p => p.E09_CityObjects, "E09 City Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the E09 City Objects ("parent load" child property).
        /// </summary>
        /// <value>The E09 City Objects.</value>
        public E09_CityColl E09_CityObjects
        {
            get { return GetProperty(E09_CityObjectsProperty); }
            private set { LoadProperty(E09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="E08_Region"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="E08_Region"/> object.</returns>
        internal static E08_Region NewE08_Region()
        {
            return DataPortal.CreateChild<E08_Region>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="E08_Region"/> object from the given E08_RegionDto.
        /// </summary>
        /// <param name="data">The <see cref="E08_RegionDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="E08_Region"/> object.</returns>
        internal static E08_Region GetE08_Region(E08_RegionDto data)
        {
            E08_Region obj = new E08_Region();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.LoadProperty(E09_CityObjectsProperty, E09_CityColl.NewE09_CityColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E08_Region()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="E08_Region"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Region_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(E09_Region_SingleObjectProperty, DataPortal.CreateChild<E09_Region_Child>());
            LoadProperty(E09_Region_ASingleObjectProperty, DataPortal.CreateChild<E09_Region_ReChild>());
            LoadProperty(E09_CityObjectsProperty, DataPortal.CreateChild<E09_CityColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="E08_Region"/> object from the given <see cref="E08_RegionDto"/>.
        /// </summary>
        /// <param name="data">The E08_RegionDto to use.</param>
        private void Fetch(E08_RegionDto data)
        {
            // Value properties
            LoadProperty(Region_IDProperty, data.Region_ID);
            LoadProperty(Region_NameProperty, data.Region_Name);
            // parent properties
            parent_Country_ID = data.Parent_Country_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="E09_Region_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E09_Region_Child child)
        {
            LoadProperty(E09_Region_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="E09_Region_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E09_Region_ReChild child)
        {
            LoadProperty(E09_Region_ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="E08_Region"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(E06_Country parent)
        {
            var dto = new E08_RegionDto();
            dto.Parent_Country_ID = parent.Country_ID;
            dto.Region_Name = Region_Name;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IE08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(Region_IDProperty, resultDto.Region_ID);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="E08_Region"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            var dto = new E08_RegionDto();
            dto.Region_ID = Region_ID;
            dto.Region_Name = Region_Name;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IE08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="E08_Region"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IE08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(Region_IDProperty));
                }
                OnDeletePost(args);
            }
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
