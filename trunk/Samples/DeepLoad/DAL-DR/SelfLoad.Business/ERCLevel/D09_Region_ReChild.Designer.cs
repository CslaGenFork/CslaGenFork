using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess.ERCLevel;
using SelfLoad.DataAccess;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D09_Region_ReChild (editable child object).<br/>
    /// This is a generated base class of <see cref="D09_Region_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="D08_Region"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D09_Region_ReChild : BusinessBase<D09_Region_ReChild>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_Child_NameProperty = RegisterProperty<string>(p => p.Region_Child_Name, "5_Cities Child Name");
        /// <summary>
        /// Gets or sets the 5_Cities Child Name.
        /// </summary>
        /// <value>The 5_Cities Child Name.</value>
        public string Region_Child_Name
        {
            get { return GetProperty(Region_Child_NameProperty); }
            set { SetProperty(Region_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D09_Region_ReChild"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="D09_Region_ReChild"/> object.</returns>
        internal static D09_Region_ReChild NewD09_Region_ReChild()
        {
            return DataPortal.CreateChild<D09_Region_ReChild>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D09_Region_ReChild"/> object, based on given parameters.
        /// </summary>
        /// <param name="region_ID2">The Region_ID2 parameter of the D09_Region_ReChild to fetch.</param>
        /// <returns>A reference to the fetched <see cref="D09_Region_ReChild"/> object.</returns>
        internal static D09_Region_ReChild GetD09_Region_ReChild(int region_ID2)
        {
            return DataPortal.FetchChild<D09_Region_ReChild>(region_ID2);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D09_Region_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D09_Region_ReChild()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="D09_Region_ReChild"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="D09_Region_ReChild"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="region_ID2">The Region ID2.</param>
        protected void Child_Fetch(int region_ID2)
        {
            var args = new DataPortalHookArgs(region_ID2);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<ID09_Region_ReChildDal>();
                var data = dal.Fetch(region_ID2);
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
                BusinessRules.CheckRules();
            }
        }

        /// <summary>
        /// Loads a <see cref="D09_Region_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Region_Child_NameProperty, dr.GetString("Region_Child_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="D09_Region_ReChild"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(D08_Region parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnInsertPre(args);
                var dal = dalManager.GetProvider<ID09_Region_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Insert(
                        parent.Region_ID,
                        Region_Child_Name
                        );
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="D09_Region_ReChild"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(D08_Region parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<ID09_Region_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        parent.Region_ID,
                        Region_Child_Name
                        );
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="D09_Region_ReChild"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(D08_Region parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnDeletePre(args);
                var dal = dalManager.GetProvider<ID09_Region_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.Region_ID);
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
