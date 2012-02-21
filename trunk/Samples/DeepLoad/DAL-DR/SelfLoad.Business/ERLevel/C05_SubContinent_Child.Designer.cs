using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess.ERLevel;
using SelfLoad.DataAccess;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C05_SubContinent_Child (editable child object).<br/>
    /// This is a generated base class of <see cref="C05_SubContinent_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="C04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C05_SubContinent_Child : BusinessBase<C05_SubContinent_Child>
    {

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "3_Countries Child Name");
        /// <summary>
        /// Gets or sets the 3_Countries Child Name.
        /// </summary>
        /// <value>The 3_Countries Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
            set { SetProperty(SubContinent_Child_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID1"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_ID1Property = RegisterProperty<int>(p => p.SubContinent_ID1, "CMarent ID1");
        /// <summary>
        /// Gets or sets the CMarent ID1.
        /// </summary>
        /// <value>The CMarent ID1.</value>
        public int SubContinent_ID1
        {
            get { return GetProperty(SubContinent_ID1Property); }
            set { SetProperty(SubContinent_ID1Property, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C05_SubContinent_Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="C05_SubContinent_Child"/> object.</returns>
        internal static C05_SubContinent_Child NewC05_SubContinent_Child()
        {
            return DataPortal.CreateChild<C05_SubContinent_Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C05_SubContinent_Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="subContinent_ID1">The SubContinent_ID1 parameter of the C05_SubContinent_Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C05_SubContinent_Child"/> object.</returns>
        internal static C05_SubContinent_Child GetC05_SubContinent_Child(int subContinent_ID1)
        {
            return DataPortal.FetchChild<C05_SubContinent_Child>(subContinent_ID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C05_SubContinent_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C05_SubContinent_Child()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="C05_SubContinent_Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="C05_SubContinent_Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        protected void Child_Fetch(int subContinent_ID1)
        {
            var args = new DataPortalHookArgs(subContinent_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var dal = dalManager.GetProvider<IC05_SubContinent_ChildDal>();
                var data = dal.Fetch(subContinent_ID1);
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
        /// Loads a <see cref="C05_SubContinent_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, dr.GetString("SubContinent_Child_Name"));
            LoadProperty(SubContinent_ID1Property, dr.GetInt32("SubContinent_ID1"));
            _rowVersion = (dr.GetValue("RowVersion")) as byte[];
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="C05_SubContinent_Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(C04_SubContinent parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IC05_SubContinent_ChildDal>();
                using (BypassPropertyChecks)
                {
                    _rowVersion = dal.Insert(
                        parent.SubContinent_ID,
                        SubContinent_Child_Name
                        );
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="C05_SubContinent_Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(C04_SubContinent parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IC05_SubContinent_ChildDal>();
                using (BypassPropertyChecks)
                {
                    _rowVersion = dal.Update(
                        parent.SubContinent_ID,
                        SubContinent_Child_Name,
                        SubContinent_ID1,
                        _rowVersion
                        );
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="C05_SubContinent_Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(C04_SubContinent parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IC05_SubContinent_ChildDal>();
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
