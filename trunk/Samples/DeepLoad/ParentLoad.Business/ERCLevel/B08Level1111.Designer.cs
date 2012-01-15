using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B08Level1111 (editable child object).<br/>
    /// This is a generated base class of <see cref="B08Level1111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B09Level11111Objects"/> of type <see cref="B09Level11111Coll"/> (1:M relation to <see cref="B10Level11111"/>)<br/>
    /// This class is an item of <see cref="B07Level1111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B08Level1111 : BusinessBase<B08Level1111>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int larentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_1_1_ID, "Level_1_1_1_1 ID");
        /// <summary>
        /// Gets the Level_1_1_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1_1_1 ID.</value>
        public int Level_1_1_1_1_ID
        {
            get { return GetProperty(Level_1_1_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_1_Name, "Level_1_1_1_1 Name");
        /// <summary>
        /// Gets or sets the Level_1_1_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1_1_1 Name.</value>
        public string Level_1_1_1_1_Name
        {
            get { return GetProperty(Level_1_1_1_1_NameProperty); }
            set { SetProperty(Level_1_1_1_1_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B09Level11111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B09Level11111Child> B09Level11111SingleObjectProperty = RegisterProperty<B09Level11111Child>(p => p.B09Level11111SingleObject, "B09 Level11111 Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B09 Level11111 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B09 Level11111 Single Object.</value>
        public B09Level11111Child B09Level11111SingleObject
        {
            get { return GetProperty(B09Level11111SingleObjectProperty); }
            private set { LoadProperty(B09Level11111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B09Level11111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B09Level11111ReChild> B09Level11111ASingleObjectProperty = RegisterProperty<B09Level11111ReChild>(p => p.B09Level11111ASingleObject, "B09 Level11111 ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B09 Level11111 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B09 Level11111 ASingle Object.</value>
        public B09Level11111ReChild B09Level11111ASingleObject
        {
            get { return GetProperty(B09Level11111ASingleObjectProperty); }
            private set { LoadProperty(B09Level11111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B09Level11111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B09Level11111Coll> B09Level11111ObjectsProperty = RegisterProperty<B09Level11111Coll>(p => p.B09Level11111Objects, "B09 Level11111 Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B09 Level11111 Objects ("parent load" child property).
        /// </summary>
        /// <value>The B09 Level11111 Objects.</value>
        public B09Level11111Coll B09Level11111Objects
        {
            get { return GetProperty(B09Level11111ObjectsProperty); }
            private set { LoadProperty(B09Level11111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B08Level1111"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="B08Level1111"/> object.</returns>
        internal static B08Level1111 NewB08Level1111()
        {
            return DataPortal.CreateChild<B08Level1111>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B08Level1111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B08Level1111"/> object.</returns>
        internal static B08Level1111 GetB08Level1111(SafeDataReader dr)
        {
            B08Level1111 obj = new B08Level1111();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.LoadProperty(B09Level11111ObjectsProperty, B09Level11111Coll.NewB09Level11111Coll());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B08Level1111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B08Level1111()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="B08Level1111"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Level_1_1_1_1_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(B09Level11111SingleObjectProperty, DataPortal.CreateChild<B09Level11111Child>());
            LoadProperty(B09Level11111ASingleObjectProperty, DataPortal.CreateChild<B09Level11111ReChild>());
            LoadProperty(B09Level11111ObjectsProperty, DataPortal.CreateChild<B09Level11111Coll>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="B08Level1111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_1_ID"));
            LoadProperty(Level_1_1_1_1_NameProperty, dr.GetString("Level_1_1_1_1_Name"));
            larentID1 = dr.GetInt32("LarentID1");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B09Level11111Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B09Level11111Child child)
        {
            LoadProperty(B09Level11111SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B09Level11111ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B09Level11111ReChild child)
        {
            LoadProperty(B09Level11111ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="B08Level1111"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(B06Level111 parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB08Level1111", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_ID", parent.Level_1_1_1_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_ID", ReadProperty(Level_1_1_1_1_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_Name", ReadProperty(Level_1_1_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Level_1_1_1_1_IDProperty, (int) cmd.Parameters["@Level_1_1_1_1_ID"].Value);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B08Level1111"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB08Level1111", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_ID", ReadProperty(Level_1_1_1_1_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_Name", ReadProperty(Level_1_1_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="B08Level1111"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteB08Level1111", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_1_ID", ReadProperty(Level_1_1_1_1_IDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(B09Level11111SingleObjectProperty, DataPortal.CreateChild<B09Level11111Child>());
            LoadProperty(B09Level11111ASingleObjectProperty, DataPortal.CreateChild<B09Level11111ReChild>());
            LoadProperty(B09Level11111ObjectsProperty, DataPortal.CreateChild<B09Level11111Coll>());
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
