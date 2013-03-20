using System;
using Csla;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F10_City (editable child object).<br/>
    /// This is a generated base class of <see cref="F10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F11_CityRoadObjects"/> of type <see cref="F11_CityRoadColl"/> (1:M relation to <see cref="F12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="F09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F10_City : BusinessBase<F10_City>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_Region_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="City_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> City_IDProperty = RegisterProperty<int>(p => p.City_ID, "Cities ID");
        /// <summary>
        /// Gets the Cities ID.
        /// </summary>
        /// <value>The Cities ID.</value>
        public int City_ID
        {
            get { return GetProperty(City_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="City_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> City_NameProperty = RegisterProperty<string>(p => p.City_Name, "Cities Name");
        /// <summary>
        /// Gets or sets the Cities Name.
        /// </summary>
        /// <value>The Cities Name.</value>
        public string City_Name
        {
            get { return GetProperty(City_NameProperty); }
            set { SetProperty(City_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F11_City_Child> F11_City_SingleObjectProperty = RegisterProperty<F11_City_Child>(p => p.F11_City_SingleObject, "F11 City Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the F11 City Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F11 City Single Object.</value>
        public F11_City_Child F11_City_SingleObject
        {
            get { return GetProperty(F11_City_SingleObjectProperty); }
            private set { LoadProperty(F11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F11_City_ReChild> F11_City_ASingleObjectProperty = RegisterProperty<F11_City_ReChild>(p => p.F11_City_ASingleObject, "F11 City ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the F11 City ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F11 City ASingle Object.</value>
        public F11_City_ReChild F11_City_ASingleObject
        {
            get { return GetProperty(F11_City_ASingleObjectProperty); }
            private set { LoadProperty(F11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F11_CityRoadColl> F11_CityRoadObjectsProperty = RegisterProperty<F11_CityRoadColl>(p => p.F11_CityRoadObjects, "F11 CityRoad Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the F11 City Road Objects ("parent load" child property).
        /// </summary>
        /// <value>The F11 City Road Objects.</value>
        public F11_CityRoadColl F11_CityRoadObjects
        {
            get { return GetProperty(F11_CityRoadObjectsProperty); }
            private set { LoadProperty(F11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="F10_City"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="F10_City"/> object.</returns>
        internal static F10_City NewF10_City()
        {
            return DataPortal.CreateChild<F10_City>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="F10_City"/> object from the given F10_CityDto.
        /// </summary>
        /// <param name="data">The <see cref="F10_CityDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F10_City"/> object.</returns>
        internal static F10_City GetF10_City(F10_CityDto data)
        {
            F10_City obj = new F10_City();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.LoadProperty(F11_CityRoadObjectsProperty, F11_CityRoadColl.NewF11_CityRoadColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F10_City()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="F10_City"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(City_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(F11_City_SingleObjectProperty, DataPortal.CreateChild<F11_City_Child>());
            LoadProperty(F11_City_ASingleObjectProperty, DataPortal.CreateChild<F11_City_ReChild>());
            LoadProperty(F11_CityRoadObjectsProperty, DataPortal.CreateChild<F11_CityRoadColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="F10_City"/> object from the given <see cref="F10_CityDto"/>.
        /// </summary>
        /// <param name="data">The F10_CityDto to use.</param>
        private void Fetch(F10_CityDto data)
        {
            // Value properties
            LoadProperty(City_IDProperty, data.City_ID);
            LoadProperty(City_NameProperty, data.City_Name);
            // parent properties
            parent_Region_ID = data.Parent_Region_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="F11_City_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F11_City_Child child)
        {
            LoadProperty(F11_City_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="F11_City_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F11_City_ReChild child)
        {
            LoadProperty(F11_City_ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="F10_City"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(F08_Region parent)
        {
            var dto = new F10_CityDto();
            dto.Parent_Region_ID = parent.Region_ID;
            dto.City_Name = City_Name;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IF10_CityDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(City_IDProperty, resultDto.City_ID);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="F10_City"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            var dto = new F10_CityDto();
            dto.City_ID = City_ID;
            dto.City_Name = City_Name;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IF10_CityDal>();
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
        /// Self deletes the <see cref="F10_City"/> object from database.
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
                var dal = dalManager.GetProvider<IF10_CityDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(City_IDProperty));
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
