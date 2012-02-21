using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess.ERCLevel;
using SelfLoadSoftDelete.DataAccess;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H07_Country_Child (editable child object).<br/>
    /// This is a generated base class of <see cref="H07_Country_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="H06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H07_Country_Child : BusinessBase<H07_Country_Child>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Country_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_Child_NameProperty = RegisterProperty<string>(p => p.Country_Child_Name, "4_Regions Child Name");
        /// <summary>
        /// Gets or sets the 4_Regions Child Name.
        /// </summary>
        /// <value>The 4_Regions Child Name.</value>
        public string Country_Child_Name
        {
            get { return GetProperty(Country_Child_NameProperty); }
            set { SetProperty(Country_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="H07_Country_Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="H07_Country_Child"/> object.</returns>
        internal static H07_Country_Child NewH07_Country_Child()
        {
            return DataPortal.CreateChild<H07_Country_Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H07_Country_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="country_ID1">The Country_ID1 parameter of the H07_Country_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="H07_Country_Child"/> object.</returns>
        internal static H07_Country_Child GetH07_Country_Child(int country_ID1)
        {
            return DataPortal.FetchChild<H07_Country_Child>(country_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H07_Country_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H07_Country_Child()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="H07_Country_Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="H07_Country_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="country_ID1">The Country ID1.</param>
        protected void Child_Fetch(int country_ID1)
        {
            var args = new DataPortalHookArgs(country_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IH07_Country_ChildDal>();
                var data = dal.Fetch(country_ID1);
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
        /// Loads a <see cref="H07_Country_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, dr.GetString("Country_Child_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="H07_Country_Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(H06_Country parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IH07_Country_ChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Insert(
                        parent.Country_ID,
                        Country_Child_Name
                        );
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="H07_Country_Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(H06_Country parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IH07_Country_ChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        parent.Country_ID,
                        Country_Child_Name
                        );
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="H07_Country_Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(H06_Country parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IH07_Country_ChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.Country_ID);
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
