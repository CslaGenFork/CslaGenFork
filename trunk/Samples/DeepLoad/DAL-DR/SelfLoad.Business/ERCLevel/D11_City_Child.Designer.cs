using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess.ERCLevel;
using SelfLoad.DataAccess;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D11_City_Child (editable child object).<br/>
    /// This is a generated base class of <see cref="D11_City_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="D10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D11_City_Child : BusinessBase<D11_City_Child>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="City_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> City_Child_NameProperty = RegisterProperty<string>(p => p.City_Child_Name, "6_CityRoads Child Name");
        /// <summary>
        /// Gets or sets the 6_CityRoads Child Name.
        /// </summary>
        /// <value>The 6_CityRoads Child Name.</value>
        public string City_Child_Name
        {
            get { return GetProperty(City_Child_NameProperty); }
            set { SetProperty(City_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D11_City_Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="D11_City_Child"/> object.</returns>
        internal static D11_City_Child NewD11_City_Child()
        {
            return DataPortal.CreateChild<D11_City_Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D11_City_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="city_ID1">The City_ID1 parameter of the D11_City_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D11_City_Child"/> object.</returns>
        internal static D11_City_Child GetD11_City_Child(int city_ID1)
        {
            return DataPortal.FetchChild<D11_City_Child>(city_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D11_City_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D11_City_Child()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="D11_City_Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="D11_City_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        protected void Child_Fetch(int city_ID1)
        {
            var args = new DataPortalHookArgs(city_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<ID11_City_ChildDal>();
                var data = dal.Fetch(city_ID1);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        private void Fetch(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="D11_City_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(City_Child_NameProperty, dr.GetString("City_Child_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="D11_City_Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(D10_City parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnInsertPre(args);
                var dal = dalManager.GetProvider<ID11_City_ChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Insert(
                        parent.City_ID,
                        City_Child_Name
                        );
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="D11_City_Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(D10_City parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<ID11_City_ChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        parent.City_ID,
                        City_Child_Name
                        );
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="D11_City_Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(D10_City parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnDeletePre(args);
                var dal = dalManager.GetProvider<ID11_City_ChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.City_ID);
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
