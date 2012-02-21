using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess.ERCLevel;
using SelfLoad.DataAccess;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D10_City (editable child object).<br/>
    /// This is a generated base class of <see cref="D10_City"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D11_CityRoadObjects"/> of type <see cref="D11_CityRoadColl"/> (1:M relation to <see cref="D12_CityRoad"/>)<br/>
    /// This class is an item of <see cref="D09_CityColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D10_City : BusinessBase<D10_City>
    {

        #region Static Fields

        private static int _lastID;

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
        /// Maintains metadata about child <see cref="D11_City_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D11_City_Child> D11_City_SingleObjectProperty = RegisterProperty<D11_City_Child>(p => p.D11_City_SingleObject, "D11 City Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D11 City Single Object ("self load" child property).
        /// </summary>
        /// <value>The D11 City Single Object.</value>
        public D11_City_Child D11_City_SingleObject
        {
            get { return GetProperty(D11_City_SingleObjectProperty); }
            private set { LoadProperty(D11_City_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D11_City_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D11_City_ReChild> D11_City_ASingleObjectProperty = RegisterProperty<D11_City_ReChild>(p => p.D11_City_ASingleObject, "D11 City ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D11 City ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D11 City ASingle Object.</value>
        public D11_City_ReChild D11_City_ASingleObject
        {
            get { return GetProperty(D11_City_ASingleObjectProperty); }
            private set { LoadProperty(D11_City_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D11_CityRoadObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D11_CityRoadColl> D11_CityRoadObjectsProperty = RegisterProperty<D11_CityRoadColl>(p => p.D11_CityRoadObjects, "D11 CityRoad Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D11 City Road Objects ("self load" child property).
        /// </summary>
        /// <value>The D11 City Road Objects.</value>
        public D11_CityRoadColl D11_CityRoadObjects
        {
            get { return GetProperty(D11_CityRoadObjectsProperty); }
            private set { LoadProperty(D11_CityRoadObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D10_City"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="D10_City"/> object.</returns>
        internal static D10_City NewD10_City()
        {
            return DataPortal.CreateChild<D10_City>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D10_City"/> object.</returns>
        internal static D10_City GetD10_City(SafeDataReader dr)
        {
            D10_City obj = new D10_City();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D10_City"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D10_City()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="D10_City"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(City_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(D11_City_SingleObjectProperty, DataPortal.CreateChild<D11_City_Child>());
            LoadProperty(D11_City_ASingleObjectProperty, DataPortal.CreateChild<D11_City_ReChild>());
            LoadProperty(D11_CityRoadObjectsProperty, DataPortal.CreateChild<D11_CityRoadColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="D10_City"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(City_IDProperty, dr.GetInt32("City_ID"));
            LoadProperty(City_NameProperty, dr.GetString("City_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(D11_City_SingleObjectProperty, D11_City_Child.GetD11_City_Child(City_ID));
            LoadProperty(D11_City_ASingleObjectProperty, D11_City_ReChild.GetD11_City_ReChild(City_ID));
            LoadProperty(D11_CityRoadObjectsProperty, D11_CityRoadColl.GetD11_CityRoadColl(City_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="D10_City"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(D08_Region parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnInsertPre(args);
                var dal = dalManager.GetProvider<ID10_CityDal>();
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
        /// Updates in the database all changes made to the <see cref="D10_City"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<ID10_CityDal>();
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
        /// Self deletes the <see cref="D10_City"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<ID10_CityDal>();
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
