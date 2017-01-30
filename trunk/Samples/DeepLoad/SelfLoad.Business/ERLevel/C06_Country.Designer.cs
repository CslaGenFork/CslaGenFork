using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C06_Country (editable child object).<br/>
    /// This is a generated base class of <see cref="C06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C07_RegionObjects"/> of type <see cref="C07_RegionColl"/> (1:M relation to <see cref="C08_Region"/>)<br/>
    /// This class is an item of <see cref="C05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C06_Country : BusinessBase<C06_Country>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

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
        /// Maintains metadata about <see cref="ParentSubContinentID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ParentSubContinentIDProperty = RegisterProperty<int>(p => p.ParentSubContinentID, "ParentSubContinentID");
        /// <summary>
        /// Gets or sets the ParentSubContinentID.
        /// </summary>
        /// <value>The ParentSubContinentID.</value>
        public int ParentSubContinentID
        {
            get { return GetProperty(ParentSubContinentIDProperty); }
            set { SetProperty(ParentSubContinentIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C07_Country_Child> C07_Country_SingleObjectProperty = RegisterProperty<C07_Country_Child>(p => p.C07_Country_SingleObject, "C07 Country Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C07 Country Single Object ("self load" child property).
        /// </summary>
        /// <value>The C07 Country Single Object.</value>
        public C07_Country_Child C07_Country_SingleObject
        {
            get { return GetProperty(C07_Country_SingleObjectProperty); }
            private set { LoadProperty(C07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C07_Country_ReChild> C07_Country_ASingleObjectProperty = RegisterProperty<C07_Country_ReChild>(p => p.C07_Country_ASingleObject, "C07 Country ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C07 Country ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C07 Country ASingle Object.</value>
        public C07_Country_ReChild C07_Country_ASingleObject
        {
            get { return GetProperty(C07_Country_ASingleObjectProperty); }
            private set { LoadProperty(C07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C07_RegionColl> C07_RegionObjectsProperty = RegisterProperty<C07_RegionColl>(p => p.C07_RegionObjects, "C07 Region Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C07 Region Objects ("self load" child property).
        /// </summary>
        /// <value>The C07 Region Objects.</value>
        public C07_RegionColl C07_RegionObjects
        {
            get { return GetProperty(C07_RegionObjectsProperty); }
            private set { LoadProperty(C07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C06_Country"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="C06_Country"/> object.</returns>
        internal static C06_Country NewC06_Country()
        {
            return DataPortal.CreateChild<C06_Country>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="C06_Country"/> object.</returns>
        internal static C06_Country GetC06_Country(SafeDataReader dr)
        {
            C06_Country obj = new C06_Country();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C06_Country()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="C06_Country"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Country_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(C07_Country_SingleObjectProperty, DataPortal.CreateChild<C07_Country_Child>());
            LoadProperty(C07_Country_ASingleObjectProperty, DataPortal.CreateChild<C07_Country_ReChild>());
            LoadProperty(C07_RegionObjectsProperty, DataPortal.CreateChild<C07_RegionColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="C06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_IDProperty, dr.GetInt32("Country_ID"));
            LoadProperty(Country_NameProperty, dr.GetString("Country_Name"));
            LoadProperty(ParentSubContinentIDProperty, dr.GetInt32("Parent_SubContinent_ID"));
            _rowVersion = dr.GetValue("RowVersion") as byte[];
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(C07_Country_SingleObjectProperty, C07_Country_Child.GetC07_Country_Child(Country_ID));
            LoadProperty(C07_Country_ASingleObjectProperty, C07_Country_ReChild.GetC07_Country_ReChild(Country_ID));
            LoadProperty(C07_RegionObjectsProperty, C07_RegionColl.GetC07_RegionColl(Country_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="C06_Country"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(C04_SubContinent parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", parent.SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", ReadProperty(Country_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", ReadProperty(Country_NameProperty)).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Country_IDProperty, (int) cmd.Parameters["@Country_ID"].Value);
                    _rowVersion = (byte[]) cmd.Parameters["@NewRowVersion"].Value;
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="C06_Country"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", ReadProperty(Country_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", ReadProperty(Country_NameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", ReadProperty(ParentSubContinentIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", _rowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                    _rowVersion = (byte[]) cmd.Parameters["@NewRowVersion"].Value;
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="C06_Country"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteC06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", ReadProperty(Country_IDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(C07_Country_SingleObjectProperty, DataPortal.CreateChild<C07_Country_Child>());
            LoadProperty(C07_Country_ASingleObjectProperty, DataPortal.CreateChild<C07_Country_ReChild>());
            LoadProperty(C07_RegionObjectsProperty, DataPortal.CreateChild<C07_RegionColl>());
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
