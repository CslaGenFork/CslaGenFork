using System;
using Csla;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G09_Region_Child (editable child object).<br/>
    /// This is a generated base class of <see cref="G09_Region_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="G08_Region"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G09_Region_Child : BusinessBase<G09_Region_Child>
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
        /// Factory method. Creates a new <see cref="G09_Region_Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="G09_Region_Child"/> object.</returns>
        internal static G09_Region_Child NewG09_Region_Child()
        {
            return DataPortal.CreateChild<G09_Region_Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="G09_Region_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="region_ID1">The Region_ID1 parameter of the G09_Region_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G09_Region_Child"/> object.</returns>
        internal static G09_Region_Child GetG09_Region_Child(int region_ID1)
        {
            return DataPortal.FetchChild<G09_Region_Child>(region_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G09_Region_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G09_Region_Child()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="G09_Region_Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="G09_Region_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="region_ID1">The Region ID1.</param>
        protected void Child_Fetch(int region_ID1)
        {
            var args = new DataPortalHookArgs(region_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG09_Region_ChildDal>();
                var data = dal.Fetch(region_ID1);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads a <see cref="G09_Region_Child"/> object from the given <see cref="G09_Region_ChildDto"/>.
        /// </summary>
        /// <param name="data">The G09_Region_ChildDto to use.</param>
        private void Fetch(G09_Region_ChildDto data)
        {
            // Value properties
            LoadProperty(Region_Child_NameProperty, data.Region_Child_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="G09_Region_Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(G08_Region parent)
        {
            var dto = new G09_Region_ChildDto();
            dto.Parent_Region_ID = parent.Region_ID;
            dto.Region_Child_Name = Region_Child_Name;
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IG09_Region_ChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="G09_Region_Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(G08_Region parent)
        {
            var dto = new G09_Region_ChildDto();
            dto.Parent_Region_ID = parent.Region_ID;
            dto.Region_Child_Name = Region_Child_Name;
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IG09_Region_ChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="G09_Region_Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(G08_Region parent)
        {
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IG09_Region_ChildDal>();
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
