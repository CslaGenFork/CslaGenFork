using System;
using Csla;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C08_Region (editable child object).<br/>
    /// This is a generated base class of <see cref="C08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C09_CityObjects"/> of type <see cref="C09_CityColl"/> (1:M relation to <see cref="C10_City"/>)<br/>
    /// This class is an item of <see cref="C07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C08_Region : BusinessBase<C08_Region>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Region_IDProperty = RegisterProperty<int>(p => p.Region_ID, "Regions ID");
        /// <summary>
        /// Gets the Regions ID.
        /// </summary>
        /// <value>The Regions ID.</value>
        public int Region_ID
        {
            get { return GetProperty(Region_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Region_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_NameProperty = RegisterProperty<string>(p => p.Region_Name, "Regions Name");
        /// <summary>
        /// Gets or sets the Regions Name.
        /// </summary>
        /// <value>The Regions Name.</value>
        public string Region_Name
        {
            get { return GetProperty(Region_NameProperty); }
            set { SetProperty(Region_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C09_Region_Child> C09_Region_SingleObjectProperty = RegisterProperty<C09_Region_Child>(p => p.C09_Region_SingleObject, "C09 Region Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C09 Region Single Object ("self load" child property).
        /// </summary>
        /// <value>The C09 Region Single Object.</value>
        public C09_Region_Child C09_Region_SingleObject
        {
            get { return GetProperty(C09_Region_SingleObjectProperty); }
            private set { LoadProperty(C09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C09_Region_ReChild> C09_Region_ASingleObjectProperty = RegisterProperty<C09_Region_ReChild>(p => p.C09_Region_ASingleObject, "C09 Region ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C09 Region ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C09 Region ASingle Object.</value>
        public C09_Region_ReChild C09_Region_ASingleObject
        {
            get { return GetProperty(C09_Region_ASingleObjectProperty); }
            private set { LoadProperty(C09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C09_CityColl> C09_CityObjectsProperty = RegisterProperty<C09_CityColl>(p => p.C09_CityObjects, "C09 City Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C09 City Objects ("self load" child property).
        /// </summary>
        /// <value>The C09 City Objects.</value>
        public C09_CityColl C09_CityObjects
        {
            get { return GetProperty(C09_CityObjectsProperty); }
            private set { LoadProperty(C09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C08_Region"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="C08_Region"/> object.</returns>
        internal static C08_Region NewC08_Region()
        {
            return DataPortal.CreateChild<C08_Region>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C08_Region"/> object from the given C08_RegionDto.
        /// </summary>
        /// <param name="data">The <see cref="C08_RegionDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="C08_Region"/> object.</returns>
        internal static C08_Region GetC08_Region(C08_RegionDto data)
        {
            C08_Region obj = new C08_Region();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C08_Region()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="C08_Region"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Region_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(C09_Region_SingleObjectProperty, DataPortal.CreateChild<C09_Region_Child>());
            LoadProperty(C09_Region_ASingleObjectProperty, DataPortal.CreateChild<C09_Region_ReChild>());
            LoadProperty(C09_CityObjectsProperty, DataPortal.CreateChild<C09_CityColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="C08_Region"/> object from the given <see cref="C08_RegionDto"/>.
        /// </summary>
        /// <param name="data">The C08_RegionDto to use.</param>
        private void Fetch(C08_RegionDto data)
        {
            // Value properties
            LoadProperty(Region_IDProperty, data.Region_ID);
            LoadProperty(Region_NameProperty, data.Region_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(C09_Region_SingleObjectProperty, C09_Region_Child.GetC09_Region_Child(Region_ID));
            LoadProperty(C09_Region_ASingleObjectProperty, C09_Region_ReChild.GetC09_Region_ReChild(Region_ID));
            LoadProperty(C09_CityObjectsProperty, C09_CityColl.GetC09_CityColl(Region_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="C08_Region"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(C06_Country parent)
        {
            var dto = new C08_RegionDto();
            dto.Parent_Country_ID = parent.Country_ID;
            dto.Region_Name = Region_Name;
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IC08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(Region_IDProperty, resultDto.Region_ID);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="C08_Region"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            var dto = new C08_RegionDto();
            dto.Region_ID = Region_ID;
            dto.Region_Name = Region_Name;
            using (var dalManager = DalFactorySelfLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IC08_RegionDal>();
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
        /// Self deletes the <see cref="C08_Region"/> object from database.
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
                var dal = dalManager.GetProvider<IC08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(Region_IDProperty));
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
