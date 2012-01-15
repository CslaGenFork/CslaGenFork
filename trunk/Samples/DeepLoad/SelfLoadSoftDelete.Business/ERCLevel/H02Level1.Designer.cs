using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H02Level1 (editable child object).<br/>
    /// This is a generated base class of <see cref="H02Level1"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H03Level11Objects"/> of type <see cref="H03Level11Coll"/> (1:M relation to <see cref="H04Level11"/>)<br/>
    /// This class is an item of <see cref="H01Level1Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H02Level1 : BusinessBase<H02Level1>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_IDProperty = RegisterProperty<int>(p => p.Level_1_ID, "Level_1 ID");
        /// <summary>
        /// Gets the Level_1 ID.
        /// </summary>
        /// <value>The Level_1 ID.</value>
        public int Level_1_ID
        {
            get { return GetProperty(Level_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_NameProperty = RegisterProperty<string>(p => p.Level_1_Name, "Level_1 Name");
        /// <summary>
        /// Gets or sets the Level_1 Name.
        /// </summary>
        /// <value>The Level_1 Name.</value>
        public string Level_1_Name
        {
            get { return GetProperty(Level_1_NameProperty); }
            set { SetProperty(Level_1_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H03Level11SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H03Level11Child> H03Level11SingleObjectProperty = RegisterProperty<H03Level11Child>(p => p.H03Level11SingleObject, "B3 Level11 Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H03 Level11 Single Object ("self load" child property).
        /// </summary>
        /// <value>The H03 Level11 Single Object.</value>
        public H03Level11Child H03Level11SingleObject
        {
            get { return GetProperty(H03Level11SingleObjectProperty); }
            private set { LoadProperty(H03Level11SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H03Level11ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H03Level11ReChild> H03Level11ASingleObjectProperty = RegisterProperty<H03Level11ReChild>(p => p.H03Level11ASingleObject, "B3 Level11 ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H03 Level11 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H03 Level11 ASingle Object.</value>
        public H03Level11ReChild H03Level11ASingleObject
        {
            get { return GetProperty(H03Level11ASingleObjectProperty); }
            private set { LoadProperty(H03Level11ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H03Level11Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H03Level11Coll> H03Level11ObjectsProperty = RegisterProperty<H03Level11Coll>(p => p.H03Level11Objects, "B3 Level11 Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the H03 Level11 Objects ("self load" child property).
        /// </summary>
        /// <value>The H03 Level11 Objects.</value>
        public H03Level11Coll H03Level11Objects
        {
            get { return GetProperty(H03Level11ObjectsProperty); }
            private set { LoadProperty(H03Level11ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="H02Level1"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="H02Level1"/> object.</returns>
        internal static H02Level1 NewH02Level1()
        {
            return DataPortal.CreateChild<H02Level1>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="H02Level1"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H02Level1"/> object.</returns>
        internal static H02Level1 GetH02Level1(SafeDataReader dr)
        {
            H02Level1 obj = new H02Level1();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H02Level1"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H02Level1()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="H02Level1"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Level_1_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(H03Level11SingleObjectProperty, DataPortal.CreateChild<H03Level11Child>());
            LoadProperty(H03Level11ASingleObjectProperty, DataPortal.CreateChild<H03Level11ReChild>());
            LoadProperty(H03Level11ObjectsProperty, DataPortal.CreateChild<H03Level11Coll>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="H02Level1"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_IDProperty, dr.GetInt32("Level_1_ID"));
            LoadProperty(Level_1_NameProperty, dr.GetString("Level_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(H03Level11SingleObjectProperty, H03Level11Child.GetH03Level11Child(Level_1_ID));
            LoadProperty(H03Level11ASingleObjectProperty, H03Level11ReChild.GetH03Level11ReChild(Level_1_ID));
            LoadProperty(H03Level11ObjectsProperty, H03Level11Coll.GetH03Level11Coll(Level_1_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="H02Level1"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH02Level1", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", ReadProperty(Level_1_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Level_1_Name", ReadProperty(Level_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Level_1_IDProperty, (int) cmd.Parameters["@Level_1_ID"].Value);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="H02Level1"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH02Level1", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", ReadProperty(Level_1_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_Name", ReadProperty(Level_1_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="H02Level1"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteH02Level1", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", ReadProperty(Level_1_IDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(H03Level11SingleObjectProperty, DataPortal.CreateChild<H03Level11Child>());
            LoadProperty(H03Level11ASingleObjectProperty, DataPortal.CreateChild<H03Level11ReChild>());
            LoadProperty(H03Level11ObjectsProperty, DataPortal.CreateChild<H03Level11Coll>());
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
