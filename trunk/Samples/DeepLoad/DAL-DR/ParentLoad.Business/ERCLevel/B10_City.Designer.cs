using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess.ERCLevel;
using ParentLoad.DataAccess;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B10_City (editable child object).<br/>
    /// This is a generated base class of <see cref="B10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B11_CityRoadObjects"/> of type <see cref="B11_CityRoadColl"/> (1:M relation to <see cref="B12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="B09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B10_City : BusinessBase<B10_City>
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
        public static readonly PropertyInfo<int> City_IDProperty = RegisterProperty<int>(p => p.City_ID, "5_Cities ID");
        /// <summary>
        /// Gets the 5_Cities ID.
        /// </summary>
        /// <value>The 5_Cities ID.</value>
        public int City_ID
        {
            get { return GetProperty(City_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="City_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> City_NameProperty = RegisterProperty<string>(p => p.City_Name, "5_Cities Name");
        /// <summary>
        /// Gets or sets the 5_Cities Name.
        /// </summary>
        /// <value>The 5_Cities Name.</value>
        public string City_Name
        {
            get { return GetProperty(City_NameProperty); }
            set { SetProperty(City_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B11_City_Child> B11_City_SingleObjectProperty = RegisterProperty<B11_City_Child>(p => p.B11_City_SingleObject, "B11 City Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B11 City Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B11 City Single Object.</value>
        public B11_City_Child B11_City_SingleObject
        {
            get { return GetProperty(B11_City_SingleObjectProperty); }
            private set { LoadProperty(B11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B11_City_ReChild> B11_City_ASingleObjectProperty = RegisterProperty<B11_City_ReChild>(p => p.B11_City_ASingleObject, "B11 City ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B11 City ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B11 City ASingle Object.</value>
        public B11_City_ReChild B11_City_ASingleObject
        {
            get { return GetProperty(B11_City_ASingleObjectProperty); }
            private set { LoadProperty(B11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B11_CityRoadColl> B11_CityRoadObjectsProperty = RegisterProperty<B11_CityRoadColl>(p => p.B11_CityRoadObjects, "B11 CityRoad Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B11 City Road Objects ("parent load" child property).
        /// </summary>
        /// <value>The B11 City Road Objects.</value>
        public B11_CityRoadColl B11_CityRoadObjects
        {
            get { return GetProperty(B11_CityRoadObjectsProperty); }
            private set { LoadProperty(B11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B10_City"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="B10_City"/> object.</returns>
        internal static B10_City NewB10_City()
        {
            return DataPortal.CreateChild<B10_City>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B10_City"/> object.</returns>
        internal static B10_City GetB10_City(SafeDataReader dr)
        {
            B10_City obj = new B10_City();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.LoadProperty(B11_CityRoadObjectsProperty, B11_CityRoadColl.NewB11_CityRoadColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B10_City()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="B10_City"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(City_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(B11_City_SingleObjectProperty, DataPortal.CreateChild<B11_City_Child>());
            LoadProperty(B11_City_ASingleObjectProperty, DataPortal.CreateChild<B11_City_ReChild>());
            LoadProperty(B11_CityRoadObjectsProperty, DataPortal.CreateChild<B11_CityRoadColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="B10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(City_IDProperty, dr.GetInt32("City_ID"));
            LoadProperty(City_NameProperty, dr.GetString("City_Name"));
            parent_Region_ID = dr.GetInt32("Parent_Region_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B11_City_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B11_City_Child child)
        {
            LoadProperty(B11_City_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B11_City_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B11_City_ReChild child)
        {
            LoadProperty(B11_City_ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="B10_City"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(B08_Region parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IB10_CityDal>();
                using (BypassPropertyChecks)
                {
                    int city_ID = -1;
                    dal.Insert(
                        parent.Region_ID,
                        out city_ID,
                        City_Name
                        );
                    LoadProperty(City_IDProperty, city_ID);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B10_City"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IB10_CityDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        City_ID,
                        City_Name
                        );
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="B10_City"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IB10_CityDal>();
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
