using System;
using Csla;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E05_SubContinent_ReChild (editable child object).<br/>
    /// This is a generated base class of <see cref="E05_SubContinent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="E04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E05_SubContinent_ReChild : BusinessBase<E05_SubContinent_ReChild>
    {

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

        [NotUndoable]
        [NonSerialized]
        internal int subContinent_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "Countries Child Name");
        /// <summary>
        /// Gets or sets the Countries Child Name.
        /// </summary>
        /// <value>The Countries Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
            set { SetProperty(SubContinent_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="E05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="E05_SubContinent_ReChild"/> object.</returns>
        internal static E05_SubContinent_ReChild NewE05_SubContinent_ReChild()
        {
            return DataPortal.CreateChild<E05_SubContinent_ReChild>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="E05_SubContinent_ReChild"/> object from the given E05_SubContinent_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="E05_SubContinent_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="E05_SubContinent_ReChild"/> object.</returns>
        internal static E05_SubContinent_ReChild GetE05_SubContinent_ReChild(E05_SubContinent_ReChildDto data)
        {
            E05_SubContinent_ReChild obj = new E05_SubContinent_ReChild();
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
        /// Initializes a new instance of the <see cref="E05_SubContinent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E05_SubContinent_ReChild()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="E05_SubContinent_ReChild"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="E05_SubContinent_ReChild"/> object from the given <see cref="E05_SubContinent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The E05_SubContinent_ReChildDto to use.</param>
        private void Fetch(E05_SubContinent_ReChildDto data)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, data.SubContinent_Child_Name);
            _rowVersion = data.RowVersion;
            // parent properties
            subContinent_ID2 = data.Parent_SubContinent_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="E05_SubContinent_ReChild"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(E04_SubContinent parent)
        {
            var dto = new E05_SubContinent_ReChildDto();
            dto.Parent_SubContinent_ID = parent.SubContinent_ID;
            dto.SubContinent_Child_Name = SubContinent_Child_Name;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IE05_SubContinent_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    _rowVersion = resultDto.RowVersion;
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="E05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(E04_SubContinent parent)
        {
            var dto = new E05_SubContinent_ReChildDto();
            dto.Parent_SubContinent_ID = parent.SubContinent_ID;
            dto.SubContinent_Child_Name = SubContinent_Child_Name;
            dto.RowVersion = _rowVersion;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IE05_SubContinent_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    _rowVersion = resultDto.RowVersion;
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="E05_SubContinent_ReChild"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(E04_SubContinent parent)
        {
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IE05_SubContinent_ReChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.SubContinent_ID);
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
