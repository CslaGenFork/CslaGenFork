using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G04_SubContinent (editable child object).<br/>
    /// This is a generated base class of <see cref="G04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G05_CountryObjects"/> of type <see cref="G05_CountryColl"/> (1:M relation to <see cref="G06_Country"/>)<br/>
    /// This class is an item of <see cref="G03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G04_SubContinent : BusinessBase<G04_SubContinent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_IDProperty = RegisterProperty<int>(p => p.SubContinent_ID, "SubContinents ID");
        /// <summary>
        /// Gets the SubContinents ID.
        /// </summary>
        /// <value>The SubContinents ID.</value>
        public int SubContinent_ID
        {
            get { return GetProperty(SubContinent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_NameProperty = RegisterProperty<string>(p => p.SubContinent_Name, "SubContinents Name");
        /// <summary>
        /// Gets or sets the SubContinents Name.
        /// </summary>
        /// <value>The SubContinents Name.</value>
        public string SubContinent_Name
        {
            get { return GetProperty(SubContinent_NameProperty); }
            set { SetProperty(SubContinent_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G05_SubContinent_Child> G05_SubContinent_SingleObjectProperty = RegisterProperty<G05_SubContinent_Child>(p => p.G05_SubContinent_SingleObject, "G05 SubContinent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the G05 Sub Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The G05 Sub Continent Single Object.</value>
        public G05_SubContinent_Child G05_SubContinent_SingleObject
        {
            get { return GetProperty(G05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(G05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G05_SubContinent_ReChild> G05_SubContinent_ASingleObjectProperty = RegisterProperty<G05_SubContinent_ReChild>(p => p.G05_SubContinent_ASingleObject, "G05 SubContinent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the G05 Sub Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G05 Sub Continent ASingle Object.</value>
        public G05_SubContinent_ReChild G05_SubContinent_ASingleObject
        {
            get { return GetProperty(G05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(G05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G05_CountryColl> G05_CountryObjectsProperty = RegisterProperty<G05_CountryColl>(p => p.G05_CountryObjects, "G05 Country Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the G05 Country Objects ("self load" child property).
        /// </summary>
        /// <value>The G05 Country Objects.</value>
        public G05_CountryColl G05_CountryObjects
        {
            get { return GetProperty(G05_CountryObjectsProperty); }
            private set { LoadProperty(G05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="G04_SubContinent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="G04_SubContinent"/> object.</returns>
        internal static G04_SubContinent NewG04_SubContinent()
        {
            return DataPortal.CreateChild<G04_SubContinent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="G04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="G04_SubContinent"/> object.</returns>
        internal static G04_SubContinent GetG04_SubContinent(SafeDataReader dr)
        {
            G04_SubContinent obj = new G04_SubContinent();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G04_SubContinent()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="G04_SubContinent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(SubContinent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(G05_SubContinent_SingleObjectProperty, DataPortal.CreateChild<G05_SubContinent_Child>());
            LoadProperty(G05_SubContinent_ASingleObjectProperty, DataPortal.CreateChild<G05_SubContinent_ReChild>());
            LoadProperty(G05_CountryObjectsProperty, DataPortal.CreateChild<G05_CountryColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="G04_SubContinent"/> object from the given SafeDataReader.
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
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(G05_SubContinent_SingleObjectProperty, G05_SubContinent_Child.GetG05_SubContinent_Child(SubContinent_ID));
            LoadProperty(G05_SubContinent_ASingleObjectProperty, G05_SubContinent_ReChild.GetG05_SubContinent_ReChild(SubContinent_ID));
            LoadProperty(G05_CountryObjectsProperty, G05_CountryColl.GetG05_CountryColl(SubContinent_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="G04_SubContinent"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(G02_Continent parent)
        {
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IG04_SubContinentDal>();
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
        /// Updates in the database all changes made to the <see cref="G04_SubContinent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IG04_SubContinentDal>();
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
        /// Self deletes the <see cref="G04_SubContinent"/> object from database.
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
                var dal = dalManager.GetProvider<IG04_SubContinentDal>();
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
