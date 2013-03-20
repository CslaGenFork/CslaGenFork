using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B12_CityRoad (editable child object).<br/>
    /// This is a generated base class of <see cref="B12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B12_CityRoad : BusinessBase<B12_CityRoad>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_City_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="CityRoad_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CityRoad_IDProperty = RegisterProperty<int>(p => p.CityRoad_ID, "City Road ID");
        /// <summary>
        /// Gets the City Road ID.
        /// </summary>
        /// <value>The City Road ID.</value>
        public int CityRoad_ID
        {
            get { return GetProperty(CityRoad_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CityRoad_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CityRoad_NameProperty = RegisterProperty<string>(p => p.CityRoad_Name, "City Road Name");
        /// <summary>
        /// Gets or sets the City Road Name.
        /// </summary>
        /// <value>The City Road Name.</value>
        public string CityRoad_Name
        {
            get { return GetProperty(CityRoad_NameProperty); }
            set { SetProperty(CityRoad_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B12_CityRoad"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="B12_CityRoad"/> object.</returns>
        internal static B12_CityRoad NewB12_CityRoad()
        {
            return DataPortal.CreateChild<B12_CityRoad>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B12_CityRoad"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B12_CityRoad"/> object.</returns>
        internal static B12_CityRoad GetB12_CityRoad(SafeDataReader dr)
        {
            B12_CityRoad obj = new B12_CityRoad();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B12_CityRoad()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="B12_CityRoad"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(CityRoad_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="B12_CityRoad"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(CityRoad_IDProperty, dr.GetInt32("CityRoad_ID"));
            LoadProperty(CityRoad_NameProperty, dr.GetString("CityRoad_Name"));
            // parent properties
            parent_City_ID = dr.GetInt32("Parent_City_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="B12_CityRoad"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(B10_City parent)
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IB12_CityRoadDal>();
                using (BypassPropertyChecks)
                {
                    int cityRoad_ID = -1;
                    dal.Insert(
                        parent.City_ID,
                        out cityRoad_ID,
                        CityRoad_Name
                        );
                    LoadProperty(CityRoad_IDProperty, cityRoad_ID);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B12_CityRoad"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IB12_CityRoadDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        CityRoad_ID,
                        CityRoad_Name
                        );
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="B12_CityRoad"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IB12_CityRoadDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(CityRoad_IDProperty));
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
