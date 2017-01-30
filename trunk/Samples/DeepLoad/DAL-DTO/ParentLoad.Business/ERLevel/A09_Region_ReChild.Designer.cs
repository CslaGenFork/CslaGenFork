using System;
using Csla;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A09_Region_ReChild (editable child object).<br/>
    /// This is a generated base class of <see cref="A09_Region_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A08_Region"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A09_Region_ReChild : BusinessBase<A09_Region_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int region_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_Child_NameProperty = RegisterProperty<string>(p => p.Region_Child_Name, "Region Child Name");
        /// <summary>
        /// Gets or sets the Region Child Name.
        /// </summary>
        /// <value>The Region Child Name.</value>
        public string Region_Child_Name
        {
            get { return GetProperty(Region_Child_NameProperty); }
            set { SetProperty(Region_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="A09_Region_ReChild"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="A09_Region_ReChild"/> object.</returns>
        internal static A09_Region_ReChild NewA09_Region_ReChild()
        {
            return DataPortal.CreateChild<A09_Region_ReChild>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A09_Region_ReChild"/> object from the given A09_Region_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="A09_Region_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="A09_Region_ReChild"/> object.</returns>
        internal static A09_Region_ReChild GetA09_Region_ReChild(A09_Region_ReChildDto data)
        {
            A09_Region_ReChild obj = new A09_Region_ReChild();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.MarkOld();
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A09_Region_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public A09_Region_ReChild()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="A09_Region_ReChild"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="A09_Region_ReChild"/> object from the given <see cref="A09_Region_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The A09_Region_ReChildDto to use.</param>
        private void Fetch(A09_Region_ReChildDto data)
        {
            // Value properties
            LoadProperty(Region_Child_NameProperty, data.Region_Child_Name);
            // parent properties
            region_ID2 = data.Parent_Region_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="A09_Region_ReChild"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(A08_Region parent)
        {
            var dto = new A09_Region_ReChildDto();
            dto.Parent_Region_ID = parent.Region_ID;
            dto.Region_Child_Name = Region_Child_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IA09_Region_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="A09_Region_ReChild"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(A08_Region parent)
        {
            if (!IsDirty)
                return;

            var dto = new A09_Region_ReChildDto();
            dto.Parent_Region_ID = parent.Region_ID;
            dto.Region_Child_Name = Region_Child_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IA09_Region_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="A09_Region_ReChild"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(A08_Region parent)
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IA09_Region_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.Region_ID);
                }
                OnDeletePost(args);
            }
        }

        #endregion

        #region DataPortal Hooks

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
