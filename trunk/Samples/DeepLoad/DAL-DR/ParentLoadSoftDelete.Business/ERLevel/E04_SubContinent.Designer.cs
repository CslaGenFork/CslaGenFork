using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess.ERLevel;
using ParentLoadSoftDelete.DataAccess;

namespace ParentLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E04_SubContinent (editable child object).<br/>
    /// This is a generated base class of <see cref="E04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E05_CountryObjects"/> of type <see cref="E05_CountryColl"/> (1:M relation to <see cref="E06_Country"/>)<br/>
    /// This class is an item of <see cref="E03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E04_SubContinent : BusinessBase<E04_SubContinent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_IDProperty = RegisterProperty<int>(p => p.SubContinent_ID, "2_SubContinents ID");
        /// <summary>
        /// Gets the 2_SubContinents ID.
        /// </summary>
        /// <value>The 2_SubContinents ID.</value>
        public int SubContinent_ID
        {
            get { return GetProperty(SubContinent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_NameProperty = RegisterProperty<string>(p => p.SubContinent_Name, "2_SubContinents Name");
        /// <summary>
        /// Gets or sets the 2_SubContinents Name.
        /// </summary>
        /// <value>The 2_SubContinents Name.</value>
        public string SubContinent_Name
        {
            get { return GetProperty(SubContinent_NameProperty); }
            set { SetProperty(SubContinent_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E05_SubContinent_Child> E05_SubContinent_SingleObjectProperty = RegisterProperty<E05_SubContinent_Child>(p => p.E05_SubContinent_SingleObject, "E05 SubContinent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the E05 Sub Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E05 Sub Continent Single Object.</value>
        public E05_SubContinent_Child E05_SubContinent_SingleObject
        {
            get { return GetProperty(E05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(E05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E05_SubContinent_ReChild> E05_SubContinent_ASingleObjectProperty = RegisterProperty<E05_SubContinent_ReChild>(p => p.E05_SubContinent_ASingleObject, "E05 SubContinent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the E05 Sub Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E05 Sub Continent ASingle Object.</value>
        public E05_SubContinent_ReChild E05_SubContinent_ASingleObject
        {
            get { return GetProperty(E05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(E05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E05_CountryColl> E05_CountryObjectsProperty = RegisterProperty<E05_CountryColl>(p => p.E05_CountryObjects, "E05 Country Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the E05 Country Objects ("parent load" child property).
        /// </summary>
        /// <value>The E05 Country Objects.</value>
        public E05_CountryColl E05_CountryObjects
        {
            get { return GetProperty(E05_CountryObjectsProperty); }
            private set { LoadProperty(E05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="E04_SubContinent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="E04_SubContinent"/> object.</returns>
        internal static E04_SubContinent NewE04_SubContinent()
        {
            return DataPortal.CreateChild<E04_SubContinent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="E04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E04_SubContinent"/> object.</returns>
        internal static E04_SubContinent GetE04_SubContinent(SafeDataReader dr)
        {
            E04_SubContinent obj = new E04_SubContinent();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.LoadProperty(E05_CountryObjectsProperty, E05_CountryColl.NewE05_CountryColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E04_SubContinent()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="E04_SubContinent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(SubContinent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(E05_SubContinent_SingleObjectProperty, DataPortal.CreateChild<E05_SubContinent_Child>());
            LoadProperty(E05_SubContinent_ASingleObjectProperty, DataPortal.CreateChild<E05_SubContinent_ReChild>());
            LoadProperty(E05_CountryObjectsProperty, DataPortal.CreateChild<E05_CountryColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="E04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SubContinent_IDProperty, dr.GetInt32("SubContinent_ID"));
            LoadProperty(SubContinent_NameProperty, dr.GetString("SubContinent_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="E05_SubContinent_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E05_SubContinent_Child child)
        {
            LoadProperty(E05_SubContinent_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="E05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E05_SubContinent_ReChild child)
        {
            LoadProperty(E05_SubContinent_ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="E04_SubContinent"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(E02_Continent parent)
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IE04_SubContinentDal>();
                using (BypassPropertyChecks)
                {
                    int subContinent_ID = -1;
                    dal.Insert(
                        parent.Continent_ID,
                        out subContinent_ID,
                        SubContinent_Name
                        );
                    LoadProperty(SubContinent_IDProperty, subContinent_ID);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="E04_SubContinent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IE04_SubContinentDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        SubContinent_ID,
                        SubContinent_Name
                        );
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="E04_SubContinent"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            var args = new DataPortalHookArgs();
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IE04_SubContinentDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(SubContinent_IDProperty));
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
