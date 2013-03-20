using System;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D06_Country (editable child object).<br/>
    /// This is a generated base class of <see cref="D06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D07_RegionObjects"/> of type <see cref="D07_RegionColl"/> (1:M relation to <see cref="D08_Region"/>)<br/>
    /// This class is an item of <see cref="D05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D06_Country : BusinessBase<D06_Country>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Country_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Country_IDProperty = RegisterProperty<int>(p => p.Country_ID, "Countries ID");
        /// <summary>
        /// Gets the Countries ID.
        /// </summary>
        /// <value>The Countries ID.</value>
        public int Country_ID
        {
            get { return GetProperty(Country_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Country_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_NameProperty = RegisterProperty<string>(p => p.Country_Name, "Countries Name");
        /// <summary>
        /// Gets or sets the Countries Name.
        /// </summary>
        /// <value>The Countries Name.</value>
        public string Country_Name
        {
            get { return GetProperty(Country_NameProperty); }
            set { SetProperty(Country_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D07_Country_Child> D07_Country_SingleObjectProperty = RegisterProperty<D07_Country_Child>(p => p.D07_Country_SingleObject, "D07 Country Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D07 Country Single Object ("self load" child property).
        /// </summary>
        /// <value>The D07 Country Single Object.</value>
        public D07_Country_Child D07_Country_SingleObject
        {
            get { return GetProperty(D07_Country_SingleObjectProperty); }
            private set { LoadProperty(D07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D07_Country_ReChild> D07_Country_ASingleObjectProperty = RegisterProperty<D07_Country_ReChild>(p => p.D07_Country_ASingleObject, "D07 Country ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D07 Country ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D07 Country ASingle Object.</value>
        public D07_Country_ReChild D07_Country_ASingleObject
        {
            get { return GetProperty(D07_Country_ASingleObjectProperty); }
            private set { LoadProperty(D07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D07_RegionColl> D07_RegionObjectsProperty = RegisterProperty<D07_RegionColl>(p => p.D07_RegionObjects, "D07 Region Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D07 Region Objects ("self load" child property).
        /// </summary>
        /// <value>The D07 Region Objects.</value>
        public D07_RegionColl D07_RegionObjects
        {
            get { return GetProperty(D07_RegionObjectsProperty); }
            private set { LoadProperty(D07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D06_Country"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="D06_Country"/> object.</returns>
        internal static D06_Country NewD06_Country()
        {
            return DataPortal.CreateChild<D06_Country>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D06_Country"/> object from the given D06_CountryDto.
        /// </summary>
        /// <param name="data">The <see cref="D06_CountryDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="D06_Country"/> object.</returns>
        internal static D06_Country GetD06_Country(D06_CountryDto data)
        {
            D06_Country obj = new D06_Country();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D06_Country()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="D06_Country"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Country_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(D07_Country_SingleObjectProperty, DataPortal.CreateChild<D07_Country_Child>());
            LoadProperty(D07_Country_ASingleObjectProperty, DataPortal.CreateChild<D07_Country_ReChild>());
            LoadProperty(D07_RegionObjectsProperty, DataPortal.CreateChild<D07_RegionColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="D06_Country"/> object from the given <see cref="D06_CountryDto"/>.
        /// </summary>
        /// <param name="data">The D06_CountryDto to use.</param>
        private void Fetch(D06_CountryDto data)
        {
            // Value properties
            LoadProperty(Country_IDProperty, data.Country_ID);
            LoadProperty(Country_NameProperty, data.Country_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(D07_Country_SingleObjectProperty, D07_Country_Child.GetD07_Country_Child(Country_ID));
            LoadProperty(D07_Country_ASingleObjectProperty, D07_Country_ReChild.GetD07_Country_ReChild(Country_ID));
            LoadProperty(D07_RegionObjectsProperty, D07_RegionColl.GetD07_RegionColl(Country_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="D06_Country"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(D04_SubContinent parent)
        {
            var dto = new D06_CountryDto();
            dto.Parent_SubContinent_ID = parent.SubContinent_ID;
            dto.Country_Name = Country_Name;
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<ID06_CountryDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(Country_IDProperty, resultDto.Country_ID);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="D06_Country"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            var dto = new D06_CountryDto();
            dto.Country_ID = Country_ID;
            dto.Country_Name = Country_Name;
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<ID06_CountryDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="D06_Country"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<ID06_CountryDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(Country_IDProperty));
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
