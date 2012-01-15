using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoad.Business.ERLevel
{

    /// <summary>
    /// C02Level1 (editable root object).<br/>
    /// This is a generated base class of <see cref="C02Level1"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C03Level11Objects"/> of type <see cref="C03Level11Coll"/> (1:M relation to <see cref="C04Level11"/>)
    /// </remarks>
    [Serializable]
    public partial class C02Level1 : BusinessBase<C02Level1>
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
        /// Maintains metadata about child <see cref="C03Level11SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C03Level11Child> C03Level11SingleObjectProperty = RegisterProperty<C03Level11Child>(p => p.C03Level11SingleObject, "A3 Level11 Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C03 Level11 Single Object ("self load" child property).
        /// </summary>
        /// <value>The C03 Level11 Single Object.</value>
        public C03Level11Child C03Level11SingleObject
        {
            get { return GetProperty(C03Level11SingleObjectProperty); }
            private set { LoadProperty(C03Level11SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C03Level11ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C03Level11ReChild> C03Level11ASingleObjectProperty = RegisterProperty<C03Level11ReChild>(p => p.C03Level11ASingleObject, "A3 Level11 ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C03 Level11 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C03 Level11 ASingle Object.</value>
        public C03Level11ReChild C03Level11ASingleObject
        {
            get { return GetProperty(C03Level11ASingleObjectProperty); }
            private set { LoadProperty(C03Level11ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C03Level11Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C03Level11Coll> C03Level11ObjectsProperty = RegisterProperty<C03Level11Coll>(p => p.C03Level11Objects, "A3 Level11 Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the C03 Level11 Objects ("self load" child property).
        /// </summary>
        /// <value>The C03 Level11 Objects.</value>
        public C03Level11Coll C03Level11Objects
        {
            get { return GetProperty(C03Level11ObjectsProperty); }
            private set { LoadProperty(C03Level11ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="C02Level1"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="C02Level1"/> object.</returns>
        public static C02Level1 NewC02Level1()
        {
            return DataPortal.Create<C02Level1>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="C02Level1"/> object, based on given parameters.
        /// </summary>
        /// <param name="level_1_ID">The Level_1_ID parameter of the C02Level1 to fetch.</param>
        /// <returns>A reference to the fetched <see cref="C02Level1"/> object.</returns>
        public static C02Level1 GetC02Level1(int level_1_ID)
        {
            return DataPortal.Fetch<C02Level1>(level_1_ID);
        }

        /// <summary>
        /// Factory method. Marks the <see cref="C02Level1"/> object for deletion.
        /// The object will be deleted as part of the next save operation.
        /// </summary>
        /// <param name="level_1_ID">The Level_1_ID of the C02Level1 to delete.</param>
        public static void DeleteC02Level1(int level_1_ID)
        {
            DataPortal.Delete<C02Level1>(level_1_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C02Level1"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private C02Level1()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="C02Level1"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(Level_1_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(C03Level11SingleObjectProperty, DataPortal.CreateChild<C03Level11Child>());
            LoadProperty(C03Level11ASingleObjectProperty, DataPortal.CreateChild<C03Level11ReChild>());
            LoadProperty(C03Level11ObjectsProperty, DataPortal.CreateChild<C03Level11Coll>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="C02Level1"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="level_1_ID">The Level_1 ID.</param>
        protected void DataPortal_Fetch(int level_1_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC02Level1", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", level_1_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, level_1_ID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            FetchChildren();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
                BusinessRules.CheckRules();
            }
        }

        /// <summary>
        /// Loads a <see cref="C02Level1"/> object from the given SafeDataReader.
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
        private void FetchChildren()
        {
            LoadProperty(C03Level11SingleObjectProperty, C03Level11Child.GetC03Level11Child(Level_1_ID));
            LoadProperty(C03Level11ASingleObjectProperty, C03Level11ReChild.GetC03Level11ReChild(Level_1_ID));
            LoadProperty(C03Level11ObjectsProperty, C03Level11Coll.GetC03Level11Coll(Level_1_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="C02Level1"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC02Level1", ctx.Connection))
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
        /// Updates in the database all changes made to the <see cref="C02Level1"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC02Level1", ctx.Connection))
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
        /// Self deletes the <see cref="C02Level1"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(Level_1_ID);
        }

        /// <summary>
        /// Deletes the <see cref="C02Level1"/> object from database.
        /// </summary>
        /// <param name="level_1_ID">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(int level_1_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteC02Level1", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_ID", level_1_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, level_1_ID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(C03Level11SingleObjectProperty, DataPortal.CreateChild<C03Level11Child>());
            LoadProperty(C03Level11ASingleObjectProperty, DataPortal.CreateChild<C03Level11ReChild>());
            LoadProperty(C03Level11ObjectsProperty, DataPortal.CreateChild<C03Level11Coll>());
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
