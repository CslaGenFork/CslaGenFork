using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B04Level11 (editable child object).<br/>
    /// This is a generated base class of <see cref="B04Level11"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B05Level111Objects"/> of type <see cref="B05Level111Coll"/> (1:M relation to <see cref="B06Level111"/>)<br/>
    /// This class is an item of <see cref="B03Level11Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B04Level11 : BusinessBase<B04Level11>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_ID, "Level_1_1 ID");
        /// <summary>
        /// Gets the Level_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1 ID.</value>
        public int Level_1_1_ID
        {
            get { return GetProperty(Level_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_Name, "Level_1_1 Name");
        /// <summary>
        /// Gets or sets the Level_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1 Name.</value>
        public string Level_1_1_Name
        {
            get { return GetProperty(Level_1_1_NameProperty); }
            set { SetProperty(Level_1_1_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B05Level111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B05Level111ReChild> B05Level111ASingleObjectProperty = RegisterProperty<B05Level111ReChild>(p => p.B05Level111ASingleObject, "B5 Level111 ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B05 Level111 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B05 Level111 ASingle Object.</value>
        public B05Level111ReChild B05Level111ASingleObject
        {
            get { return GetProperty(B05Level111ASingleObjectProperty); }
            private set { LoadProperty(B05Level111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B05Level111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B05Level111Child> B05Level111SingleObjectProperty = RegisterProperty<B05Level111Child>(p => p.B05Level111SingleObject, "B5 Level111 Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B05 Level111 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B05 Level111 Single Object.</value>
        public B05Level111Child B05Level111SingleObject
        {
            get { return GetProperty(B05Level111SingleObjectProperty); }
            private set { LoadProperty(B05Level111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B05Level111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B05Level111Coll> B05Level111ObjectsProperty = RegisterProperty<B05Level111Coll>(p => p.B05Level111Objects, "B5 Level111 Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B05 Level111 Objects ("parent load" child property).
        /// </summary>
        /// <value>The B05 Level111 Objects.</value>
        public B05Level111Coll B05Level111Objects
        {
            get { return GetProperty(B05Level111ObjectsProperty); }
            private set { LoadProperty(B05Level111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B04Level11"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="B04Level11"/> object.</returns>
        internal static B04Level11 NewB04Level11()
        {
            return DataPortal.CreateChild<B04Level11>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B04Level11"/> object.</returns>
        internal static B04Level11 GetB04Level11(SafeDataReader dr)
        {
            B04Level11 obj = new B04Level11();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.LoadProperty(B05Level111ObjectsProperty, B05Level111Coll.NewB05Level111Coll());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B04Level11"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B04Level11()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="B04Level11"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Level_1_1_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(B05Level111ASingleObjectProperty, DataPortal.CreateChild<B05Level111ReChild>());
            LoadProperty(B05Level111SingleObjectProperty, DataPortal.CreateChild<B05Level111Child>());
            LoadProperty(B05Level111ObjectsProperty, DataPortal.CreateChild<B05Level111Coll>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="B04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_IDProperty, dr.GetInt32("Level_1_1_ID"));
            LoadProperty(Level_1_1_NameProperty, dr.GetString("Level_1_1_Name"));
            parentID1 = dr.GetInt32("ParentID1");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B05Level111ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B05Level111ReChild child)
        {
            LoadProperty(B05Level111ASingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B05Level111Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B05Level111Child child)
        {
            LoadProperty(B05Level111SingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="B04Level11"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(B02Level1 parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB04Level11", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", parent.Level_1_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", ReadProperty(Level_1_1_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Level_1_1_Name", ReadProperty(Level_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Level_1_1_IDProperty, (int) cmd.Parameters["@Level_1_1_ID"].Value);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B04Level11"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB04Level11", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", ReadProperty(Level_1_1_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_Name", ReadProperty(Level_1_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="B04Level11"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteB04Level11", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", ReadProperty(Level_1_1_IDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(B05Level111ASingleObjectProperty, DataPortal.CreateChild<B05Level111ReChild>());
            LoadProperty(B05Level111SingleObjectProperty, DataPortal.CreateChild<B05Level111Child>());
            LoadProperty(B05Level111ObjectsProperty, DataPortal.CreateChild<B05Level111Coll>());
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
