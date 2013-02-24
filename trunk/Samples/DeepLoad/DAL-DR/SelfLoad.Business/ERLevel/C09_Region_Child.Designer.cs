using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C09_Region_Child (editable child object).<br/>
    /// This is a generated base class of <see cref="C09_Region_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="C08_Region"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C09_Region_Child : BusinessBase<C09_Region_Child>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_Child_NameProperty = RegisterProperty<string>(p => p.Region_Child_Name, "Cities Child Name");
        /// <summary>
        /// Gets or sets the Cities Child Name.
        /// </summary>
        /// <value>The Cities Child Name.</value>
        public string Region_Child_Name
        {
            get { return GetProperty(Region_Child_NameProperty); }
            set { SetProperty(Region_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C09_Region_Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="C09_Region_Child"/> object.</returns>
        internal static C09_Region_Child NewC09_Region_Child()
        {
            return DataPortal.CreateChild<C09_Region_Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C09_Region_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="region_ID1">The Region_ID1 parameter of the C09_Region_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C09_Region_Child"/> object.</returns>
        internal static C09_Region_Child GetC09_Region_Child(int region_ID1)
        {
            return DataPortal.FetchChild<C09_Region_Child>(region_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C09_Region_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C09_Region_Child()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="C09_Region_Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="C09_Region_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="region_ID1">The Region ID1.</param>
        protected void Child_Fetch(int region_ID1)
        {
            var args = new DataPortalHookArgs(region_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<IC09_Region_ChildDal>();
                var data = dal.Fetch(region_ID1);
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
        /// Loads a <see cref="C09_Region_Child"/> object from the given SafeDataReader.
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
        /// Inserts a new <see cref="C09_Region_Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(C08_Region parent)
        {
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IC09_Region_ChildDal>();
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
        /// Updates in the database all changes made to the <see cref="C09_Region_Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(C08_Region parent)
        {
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IC09_Region_ChildDal>();
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
        /// Self deletes the <see cref="C09_Region_Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(C08_Region parent)
        {
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IC09_Region_ChildDal>();
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
