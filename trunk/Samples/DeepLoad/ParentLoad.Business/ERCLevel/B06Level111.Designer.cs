using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B06Level111 (editable child object).<br/>
    /// This is a generated base class of <see cref="B06Level111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B07Level1111Objects"/> of type <see cref="B07Level1111Coll"/> (1:M relation to <see cref="B08Level1111"/>)<br/>
    /// This class is an item of <see cref="B05Level111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B06Level111 : BusinessBase<B06Level111>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int marentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_1_ID, "Level_1_1_1 ID");
        /// <summary>
        /// Gets the Level_1_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1_1 ID.</value>
        public int Level_1_1_1_ID
        {
            get { return GetProperty(Level_1_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_Name, "Level_1_1_1 Name");
        /// <summary>
        /// Gets or sets the Level_1_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1_1 Name.</value>
        public string Level_1_1_1_Name
        {
            get { return GetProperty(Level_1_1_1_NameProperty); }
            set { SetProperty(Level_1_1_1_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B07Level1111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B07Level1111Child> B07Level1111SingleObjectProperty = RegisterProperty<B07Level1111Child>(p => p.B07Level1111SingleObject, "B7 Level1111 Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B07 Level1111 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B07 Level1111 Single Object.</value>
        public B07Level1111Child B07Level1111SingleObject
        {
            get { return GetProperty(B07Level1111SingleObjectProperty); }
            private set { LoadProperty(B07Level1111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B07Level1111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B07Level1111ReChild> B07Level1111ASingleObjectProperty = RegisterProperty<B07Level1111ReChild>(p => p.B07Level1111ASingleObject, "B7 Level1111 ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B07 Level1111 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B07 Level1111 ASingle Object.</value>
        public B07Level1111ReChild B07Level1111ASingleObject
        {
            get { return GetProperty(B07Level1111ASingleObjectProperty); }
            private set { LoadProperty(B07Level1111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B07Level1111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B07Level1111Coll> B07Level1111ObjectsProperty = RegisterProperty<B07Level1111Coll>(p => p.B07Level1111Objects, "B7 Level1111 Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B07 Level1111 Objects ("parent load" child property).
        /// </summary>
        /// <value>The B07 Level1111 Objects.</value>
        public B07Level1111Coll B07Level1111Objects
        {
            get { return GetProperty(B07Level1111ObjectsProperty); }
            private set { LoadProperty(B07Level1111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B06Level111"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="B06Level111"/> object.</returns>
        internal static B06Level111 NewB06Level111()
        {
            return DataPortal.CreateChild<B06Level111>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B06Level111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B06Level111"/> object.</returns>
        internal static B06Level111 GetB06Level111(SafeDataReader dr)
        {
            B06Level111 obj = new B06Level111();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.LoadProperty(B07Level1111ObjectsProperty, B07Level1111Coll.NewB07Level1111Coll());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B06Level111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B06Level111()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="B06Level111"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Level_1_1_1_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(B07Level1111SingleObjectProperty, DataPortal.CreateChild<B07Level1111Child>());
            LoadProperty(B07Level1111ASingleObjectProperty, DataPortal.CreateChild<B07Level1111ReChild>());
            LoadProperty(B07Level1111ObjectsProperty, DataPortal.CreateChild<B07Level1111Coll>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="B06Level111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_ID"));
            LoadProperty(Level_1_1_1_NameProperty, dr.GetString("Level_1_1_1_Name"));
            marentID1 = dr.GetInt32("MarentID1");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B07Level1111Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B07Level1111Child child)
        {
            LoadProperty(B07Level1111SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B07Level1111ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B07Level1111ReChild child)
        {
            LoadProperty(B07Level1111ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="B06Level111"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(B04Level11 parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB06Level111", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", parent.Level_1_1_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_ID", ReadProperty(Level_1_1_1_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_Name", ReadProperty(Level_1_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Level_1_1_1_IDProperty, (int) cmd.Parameters["@Level_1_1_1_ID"].Value);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B06Level111"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB06Level111", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_ID", ReadProperty(Level_1_1_1_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_Name", ReadProperty(Level_1_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="B06Level111"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteB06Level111", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_ID", ReadProperty(Level_1_1_1_IDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(B07Level1111SingleObjectProperty, DataPortal.CreateChild<B07Level1111Child>());
            LoadProperty(B07Level1111ASingleObjectProperty, DataPortal.CreateChild<B07Level1111ReChild>());
            LoadProperty(B07Level1111ObjectsProperty, DataPortal.CreateChild<B07Level1111Coll>());
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
