using System;
using System.Data;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H08_Region (editable child object).<br/>
    /// This is a generated base class of <see cref="H08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H09_CityObjects"/> of type <see cref="H09_CityColl"/> (1:M relation to <see cref="H10_City"/>)<br/>
    /// This class is an item of <see cref="H07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H08_Region : BusinessBase<H08_Region>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Region_IDProperty = RegisterProperty<int>(p => p.Region_ID, "4_Regions ID");
        /// <summary>
        /// Gets the 4_Regions ID.
        /// </summary>
        /// <value>The 4_Regions ID.</value>
        public int Region_ID
        {
            get { return GetProperty(Region_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Region_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_NameProperty = RegisterProperty<string>(p => p.Region_Name, "4_Regions Name");
        /// <summary>
        /// Gets or sets the 4_Regions Name.
        /// </summary>
        /// <value>The 4_Regions Name.</value>
        public string Region_Name
        {
            get { return GetProperty(Region_NameProperty); }
            set { SetProperty(Region_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H09_Region_Child> H09_Region_SingleObjectProperty = RegisterProperty<H09_Region_Child>(p => p.H09_Region_SingleObject, "H09 Region Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H09 Region Single Object ("self load" child property).
        /// </summary>
        /// <value>The H09 Region Single Object.</value>
        public H09_Region_Child H09_Region_SingleObject
        {
            get { return GetProperty(H09_Region_SingleObjectProperty); }
            private set { LoadProperty(H09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H09_Region_ReChild> H09_Region_ASingleObjectProperty = RegisterProperty<H09_Region_ReChild>(p => p.H09_Region_ASingleObject, "H09 Region ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H09 Region ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H09 Region ASingle Object.</value>
        public H09_Region_ReChild H09_Region_ASingleObject
        {
            get { return GetProperty(H09_Region_ASingleObjectProperty); }
            private set { LoadProperty(H09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H09_CityColl> H09_CityObjectsProperty = RegisterProperty<H09_CityColl>(p => p.H09_CityObjects, "H09 City Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H09 City Objects ("self load" child property).
        /// </summary>
        /// <value>The H09 City Objects.</value>
        public H09_CityColl H09_CityObjects
        {
            get { return GetProperty(H09_CityObjectsProperty); }
            private set { LoadProperty(H09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="H08_Region"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="H08_Region"/> object.</returns>
        internal static H08_Region NewH08_Region()
        {
            return DataPortal.CreateChild<H08_Region>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H08_Region"/> object.</returns>
        internal static H08_Region GetH08_Region(SafeDataReader dr)
        {
            H08_Region obj = new H08_Region();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H08_Region()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="H08_Region"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Region_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(H09_Region_SingleObjectProperty, DataPortal.CreateChild<H09_Region_Child>());
            LoadProperty(H09_Region_ASingleObjectProperty, DataPortal.CreateChild<H09_Region_ReChild>());
            LoadProperty(H09_CityObjectsProperty, DataPortal.CreateChild<H09_CityColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="H08_Region"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Region_IDProperty, dr.GetInt32("Region_ID"));
            LoadProperty(Region_NameProperty, dr.GetString("Region_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(H09_Region_SingleObjectProperty, H09_Region_Child.GetH09_Region_Child(Region_ID));
            LoadProperty(H09_Region_ASingleObjectProperty, H09_Region_ReChild.GetH09_Region_ReChild(Region_ID));
            LoadProperty(H09_CityObjectsProperty, H09_CityColl.GetH09_CityColl(Region_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="H08_Region"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(H06_Country parent)
        {
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IH08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    int region_ID = -1;
                    dal.Insert(
                        parent.Country_ID,
                        out region_ID,
                        Region_Name
                        );
                    LoadProperty(Region_IDProperty, region_ID);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="H08_Region"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            using (var dalManager = DalFactorySelfLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IH08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        Region_ID,
                        Region_Name
                        );
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="H08_Region"/> object from database.
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
                var dal = dalManager.GetProvider<IH08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(Region_IDProperty));
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
