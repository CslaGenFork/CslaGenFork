using System;
using Csla;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B05_SubContinent_Child (editable child object).<br/>
    /// This is a generated base class of <see cref="B05_SubContinent_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B05_SubContinent_Child : BusinessBase<B05_SubContinent_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int subContinent_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "Sub Continent Child Name");
        /// <summary>
        /// Gets or sets the Sub Continent Child Name.
        /// </summary>
        /// <value>The Sub Continent Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
            set { SetProperty(SubContinent_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B05_SubContinent_Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="B05_SubContinent_Child"/> object.</returns>
        internal static B05_SubContinent_Child NewB05_SubContinent_Child()
        {
            return DataPortal.CreateChild<B05_SubContinent_Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B05_SubContinent_Child"/> object from the given B05_SubContinent_ChildDto.
        /// </summary>
        /// <param name="data">The <see cref="B05_SubContinent_ChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B05_SubContinent_Child"/> object.</returns>
        internal static B05_SubContinent_Child GetB05_SubContinent_Child(B05_SubContinent_ChildDto data)
        {
            B05_SubContinent_Child obj = new B05_SubContinent_Child();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B05_SubContinent_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B05_SubContinent_Child()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="B05_SubContinent_Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="B05_SubContinent_Child"/> object from the given <see cref="B05_SubContinent_ChildDto"/>.
        /// </summary>
        /// <param name="data">The B05_SubContinent_ChildDto to use.</param>
        private void Fetch(B05_SubContinent_ChildDto data)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, data.SubContinent_Child_Name);
            // parent properties
            subContinent_ID1 = data.Parent_SubContinent_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="B05_SubContinent_Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(B04_SubContinent parent)
        {
            var dto = new B05_SubContinent_ChildDto();
            dto.Parent_SubContinent_ID = parent.SubContinent_ID;
            dto.SubContinent_Child_Name = SubContinent_Child_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IB05_SubContinent_ChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B05_SubContinent_Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(B04_SubContinent parent)
        {
            if (!IsDirty)
                return;

            var dto = new B05_SubContinent_ChildDto();
            dto.Parent_SubContinent_ID = parent.SubContinent_ID;
            dto.SubContinent_Child_Name = SubContinent_Child_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IB05_SubContinent_ChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="B05_SubContinent_Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(B04_SubContinent parent)
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IB05_SubContinent_ChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.SubContinent_ID);
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
