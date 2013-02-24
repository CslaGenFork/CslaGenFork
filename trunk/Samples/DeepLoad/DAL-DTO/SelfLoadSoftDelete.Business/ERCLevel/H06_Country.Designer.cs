using System;
using Csla;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H06_Country (editable child object).<br/>
    /// This is a generated base class of <see cref="H06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H07_RegionObjects"/> of type <see cref="H07_RegionColl"/> (1:M relation to <see cref="H08_Region"/>)<br/>
    /// This class is an item of <see cref="H05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H06_Country : BusinessBase<H06_Country>
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
        /// Maintains metadata about child <see cref="H07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H07_Country_Child> H07_Country_SingleObjectProperty = RegisterProperty<H07_Country_Child>(p => p.H07_Country_SingleObject, "H07 Country Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H07 Country Single Object ("self load" child property).
        /// </summary>
        /// <value>The H07 Country Single Object.</value>
        public H07_Country_Child H07_Country_SingleObject
        {
            get { return GetProperty(H07_Country_SingleObjectProperty); }
            private set { LoadProperty(H07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H07_Country_ReChild> H07_Country_ASingleObjectProperty = RegisterProperty<H07_Country_ReChild>(p => p.H07_Country_ASingleObject, "H07 Country ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H07 Country ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H07 Country ASingle Object.</value>
        public H07_Country_ReChild H07_Country_ASingleObject
        {
            get { return GetProperty(H07_Country_ASingleObjectProperty); }
            private set { LoadProperty(H07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H07_RegionColl> H07_RegionObjectsProperty = RegisterProperty<H07_RegionColl>(p => p.H07_RegionObjects, "H07 Region Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H07 Region Objects ("self load" child property).
        /// </summary>
        /// <value>The H07 Region Objects.</value>
        public H07_RegionColl H07_RegionObjects
        {
            get { return GetProperty(H07_RegionObjectsProperty); }
            private set { LoadProperty(H07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="H06_Country"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="H06_Country"/> object.</returns>
        internal static H06_Country NewH06_Country()
        {
            return DataPortal.CreateChild<H06_Country>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H06_Country"/> object from the given H06_CountryDto.
        /// </summary>
        /// <param name="data">The <see cref="H06_CountryDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="H06_Country"/> object.</returns>
        internal static H06_Country GetH06_Country(H06_CountryDto data)
        {
            H06_Country obj = new H06_Country();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H06_Country()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="H06_Country"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Country_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(H07_Country_SingleObjectProperty, DataPortal.CreateChild<H07_Country_Child>());
            LoadProperty(H07_Country_ASingleObjectProperty, DataPortal.CreateChild<H07_Country_ReChild>());
            LoadProperty(H07_RegionObjectsProperty, DataPortal.CreateChild<H07_RegionColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="H06_Country"/> object from the given <see cref="H06_CountryDto"/>.
        /// </summary>
        /// <param name="data">The H06_CountryDto to use.</param>
        private void Fetch(H06_CountryDto data)
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
            LoadProperty(H07_Country_SingleObjectProperty, H07_Country_Child.GetH07_Country_Child(Country_ID));
            LoadProperty(H07_Country_ASingleObjectProperty, H07_Country_ReChild.GetH07_Country_ReChild(Country_ID));
            LoadProperty(H07_RegionObjectsProperty, H07_RegionColl.GetH07_RegionColl(Country_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="H06_Country"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(H04_SubContinent parent)
        {
            var dto = new H06_CountryDto();
            dto.Parent_SubContinent_ID = parent.SubContinent_ID;
            dto.Country_Name = Country_Name;
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IH06_CountryDal>();
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
        /// Updates in the database all changes made to the <see cref="H06_Country"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            var dto = new H06_CountryDto();
            dto.Country_ID = Country_ID;
            dto.Country_Name = Country_Name;
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IH06_CountryDal>();
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
        /// Self deletes the <see cref="H06_Country"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IH06_CountryDal>();
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
