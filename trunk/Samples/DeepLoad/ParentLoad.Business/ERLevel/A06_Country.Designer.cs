using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A06_Country (editable child object).<br/>
    /// This is a generated base class of <see cref="A06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A07_RegionObjects"/> of type <see cref="A07_RegionColl"/> (1:M relation to <see cref="A08_Region"/>)<br/>
    /// This class is an item of <see cref="A05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A06_Country : BusinessBase<A06_Country>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

        [NotUndoable]
        [NonSerialized]
        internal int parent_SubContinent_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Country_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Country_IDProperty = RegisterProperty<int>(p => p.Country_ID, "Country ID");
        /// <summary>
        /// Gets the Country ID.
        /// </summary>
        /// <value>The Country ID.</value>
        public int Country_ID
        {
            get { return GetProperty(Country_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Country_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_NameProperty = RegisterProperty<string>(p => p.Country_Name, "Country Name");
        /// <summary>
        /// Gets or sets the Country Name.
        /// </summary>
        /// <value>The Country Name.</value>
        public string Country_Name
        {
            get { return GetProperty(Country_NameProperty); }
            set { SetProperty(Country_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ParentSubContinentID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ParentSubContinentIDProperty = RegisterProperty<int>(p => p.ParentSubContinentID, "Parent Sub Continent ID");
        /// <summary>
        /// Gets or sets the Parent Sub Continent ID.
        /// </summary>
        /// <value>The Parent Sub Continent ID.</value>
        public int ParentSubContinentID
        {
            get { return GetProperty(ParentSubContinentIDProperty); }
            set { SetProperty(ParentSubContinentIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A07_Country_Child> A07_Country_SingleObjectProperty = RegisterProperty<A07_Country_Child>(p => p.A07_Country_SingleObject, "A07 Country Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A07 Country Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A07 Country Single Object.</value>
        public A07_Country_Child A07_Country_SingleObject
        {
            get { return GetProperty(A07_Country_SingleObjectProperty); }
            private set { LoadProperty(A07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A07_Country_ReChild> A07_Country_ASingleObjectProperty = RegisterProperty<A07_Country_ReChild>(p => p.A07_Country_ASingleObject, "A07 Country ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A07 Country ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A07 Country ASingle Object.</value>
        public A07_Country_ReChild A07_Country_ASingleObject
        {
            get { return GetProperty(A07_Country_ASingleObjectProperty); }
            private set { LoadProperty(A07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A07_RegionColl> A07_RegionObjectsProperty = RegisterProperty<A07_RegionColl>(p => p.A07_RegionObjects, "A07 Region Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A07 Region Objects ("parent load" child property).
        /// </summary>
        /// <value>The A07 Region Objects.</value>
        public A07_RegionColl A07_RegionObjects
        {
            get { return GetProperty(A07_RegionObjectsProperty); }
            private set { LoadProperty(A07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="A06_Country"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="A06_Country"/> object.</returns>
        internal static A06_Country NewA06_Country()
        {
            return DataPortal.CreateChild<A06_Country>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A06_Country"/> object.</returns>
        internal static A06_Country GetA06_Country(SafeDataReader dr)
        {
            A06_Country obj = new A06_Country();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.LoadProperty(A07_RegionObjectsProperty, A07_RegionColl.NewA07_RegionColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A06_Country()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="A06_Country"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Country_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(A07_Country_SingleObjectProperty, DataPortal.CreateChild<A07_Country_Child>());
            LoadProperty(A07_Country_ASingleObjectProperty, DataPortal.CreateChild<A07_Country_ReChild>());
            LoadProperty(A07_RegionObjectsProperty, DataPortal.CreateChild<A07_RegionColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="A06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_IDProperty, dr.GetInt32("Country_ID"));
            LoadProperty(Country_NameProperty, dr.GetString("Country_Name"));
            LoadProperty(ParentSubContinentIDProperty, dr.GetInt32("Parent_SubContinent_ID"));
            _rowVersion = dr.GetValue("RowVersion") as byte[];
            // parent properties
            parent_SubContinent_ID = dr.GetInt32("Parent_SubContinent_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="A07_Country_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A07_Country_Child child)
        {
            LoadProperty(A07_Country_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="A07_Country_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A07_Country_ReChild child)
        {
            LoadProperty(A07_Country_ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="A06_Country"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(A04_SubContinent parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", parent.SubContinent_ID).DbType = DbType.Int32;
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
        /// Updates in the database all changes made to the <see cref="A06_Country"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA06_Country", ctx.Connection))
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
        /// Self deletes the <see cref="A06_Country"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteA06_Country", ctx.Connection))
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
            LoadProperty(A07_Country_SingleObjectProperty, DataPortal.CreateChild<A07_Country_Child>());
            LoadProperty(A07_Country_ASingleObjectProperty, DataPortal.CreateChild<A07_Country_ReChild>());
            LoadProperty(A07_RegionObjectsProperty, DataPortal.CreateChild<A07_RegionColl>());
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
