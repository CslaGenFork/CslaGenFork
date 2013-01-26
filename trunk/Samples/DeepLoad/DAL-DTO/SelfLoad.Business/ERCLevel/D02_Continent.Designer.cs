using System;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.Business.ERCLevel
{

    /// <summary>
    /// D02_Continent (editable child object).<br/>
    /// This is a generated base class of <see cref="D02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D03_SubContinentObjects"/> of type <see cref="D03_SubContinentColl"/> (1:M relation to <see cref="D04_SubContinent"/>)<br/>
    /// This class is an item of <see cref="D01_ContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D02_Continent : BusinessBase<D02_Continent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Continent_IDProperty = RegisterProperty<int>(p => p.Continent_ID, "1_Continents ID");
        /// <summary>
        /// Gets the 1_Continents ID.
        /// </summary>
        /// <value>The 1_Continents ID.</value>
        public int Continent_ID
        {
            get { return GetProperty(Continent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_NameProperty = RegisterProperty<string>(p => p.Continent_Name, "1_Continents Name");
        /// <summary>
        /// Gets or sets the 1_Continents Name.
        /// </summary>
        /// <value>The 1_Continents Name.</value>
        public string Continent_Name
        {
            get { return GetProperty(Continent_NameProperty); }
            set { SetProperty(Continent_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D03_Continent_Child> D03_Continent_SingleObjectProperty = RegisterProperty<D03_Continent_Child>(p => p.D03_Continent_SingleObject, "D03 Continent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D03 Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The D03 Continent Single Object.</value>
        public D03_Continent_Child D03_Continent_SingleObject
        {
            get { return GetProperty(D03_Continent_SingleObjectProperty); }
            private set { LoadProperty(D03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D03_Continent_ReChild> D03_Continent_ASingleObjectProperty = RegisterProperty<D03_Continent_ReChild>(p => p.D03_Continent_ASingleObject, "D03 Continent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D03 Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D03 Continent ASingle Object.</value>
        public D03_Continent_ReChild D03_Continent_ASingleObject
        {
            get { return GetProperty(D03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(D03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D03_SubContinentColl> D03_SubContinentObjectsProperty = RegisterProperty<D03_SubContinentColl>(p => p.D03_SubContinentObjects, "D03 SubContinent Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the D03 Sub Continent Objects ("self load" child property).
        /// </summary>
        /// <value>The D03 Sub Continent Objects.</value>
        public D03_SubContinentColl D03_SubContinentObjects
        {
            get { return GetProperty(D03_SubContinentObjectsProperty); }
            private set { LoadProperty(D03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="D02_Continent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="D02_Continent"/> object.</returns>
        internal static D02_Continent NewD02_Continent()
        {
            return DataPortal.CreateChild<D02_Continent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="D02_Continent"/> object from the given D02_ContinentDto.
        /// </summary>
        /// <param name="data">The <see cref="D02_ContinentDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="D02_Continent"/> object.</returns>
        internal static D02_Continent GetD02_Continent(D02_ContinentDto data)
        {
            D02_Continent obj = new D02_Continent();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D02_Continent()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="D02_Continent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Continent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(D03_Continent_SingleObjectProperty, DataPortal.CreateChild<D03_Continent_Child>());
            LoadProperty(D03_Continent_ASingleObjectProperty, DataPortal.CreateChild<D03_Continent_ReChild>());
            LoadProperty(D03_SubContinentObjectsProperty, DataPortal.CreateChild<D03_SubContinentColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="D02_Continent"/> object from the given <see cref="D02_ContinentDto"/>.
        /// </summary>
        /// <param name="data">The D02_ContinentDto to use.</param>
        private void Fetch(D02_ContinentDto data)
        {
            // Value properties
            LoadProperty(Continent_IDProperty, data.Continent_ID);
            LoadProperty(Continent_NameProperty, data.Continent_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(D03_Continent_SingleObjectProperty, D03_Continent_Child.GetD03_Continent_Child(Continent_ID));
            LoadProperty(D03_Continent_ASingleObjectProperty, D03_Continent_ReChild.GetD03_Continent_ReChild(Continent_ID));
            LoadProperty(D03_SubContinentObjectsProperty, D03_SubContinentColl.GetD03_SubContinentColl(Continent_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="D02_Continent"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert()
        {
            var dto = new D02_ContinentDto();
            dto.Continent_Name = Continent_Name;
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<ID02_ContinentDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(Continent_IDProperty, resultDto.Continent_ID);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="D02_Continent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            var dto = new D02_ContinentDto();
            dto.Continent_ID = Continent_ID;
            dto.Continent_Name = Continent_Name;
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<ID02_ContinentDal>();
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
        /// Self deletes the <see cref="D02_Continent"/> object from database.
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
                var dal = dalManager.GetProvider<ID02_ContinentDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(Continent_IDProperty));
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
