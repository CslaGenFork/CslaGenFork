using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G02_Continent (editable root object).<br/>
    /// This is a generated base class of <see cref="G02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G03_SubContinentObjects"/> of type <see cref="G03_SubContinentColl"/> (1:M relation to <see cref="G04_SubContinent"/>)
    /// </remarks>
    [Serializable]
    public partial class G02_Continent : BusinessBase<G02_Continent>
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
        /// Maintains metadata about child <see cref="G03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G03_Continent_Child> G03_Continent_SingleObjectProperty = RegisterProperty<G03_Continent_Child>(p => p.G03_Continent_SingleObject, "G03 Continent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the G03 Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The G03 Continent Single Object.</value>
        public G03_Continent_Child G03_Continent_SingleObject
        {
            get { return GetProperty(G03_Continent_SingleObjectProperty); }
            private set { LoadProperty(G03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G03_Continent_ReChild> G03_Continent_ASingleObjectProperty = RegisterProperty<G03_Continent_ReChild>(p => p.G03_Continent_ASingleObject, "G03 Continent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the G03 Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G03 Continent ASingle Object.</value>
        public G03_Continent_ReChild G03_Continent_ASingleObject
        {
            get { return GetProperty(G03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(G03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G03_SubContinentColl> G03_SubContinentObjectsProperty = RegisterProperty<G03_SubContinentColl>(p => p.G03_SubContinentObjects, "G03 SubContinent Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the G03 Sub Continent Objects ("self load" child property).
        /// </summary>
        /// <value>The G03 Sub Continent Objects.</value>
        public G03_SubContinentColl G03_SubContinentObjects
        {
            get { return GetProperty(G03_SubContinentObjectsProperty); }
            private set { LoadProperty(G03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="G02_Continent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="G02_Continent"/> object.</returns>
        public static G02_Continent NewG02_Continent()
        {
            return DataPortal.Create<G02_Continent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="G02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID parameter of the G02_Continent to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G02_Continent"/> object.</returns>
        public static G02_Continent GetG02_Continent(int continent_ID)
        {
            return DataPortal.Fetch<G02_Continent>(continent_ID);
        }

        /// <summary>
        /// Factory method. Marks the <see cref="G02_Continent"/> object for deletion.
        /// The object will be deleted as part of the next save operation.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID of the G02_Continent to delete.</param>
        public static void DeleteG02_Continent(int continent_ID)
        {
            DataPortal.Delete<G02_Continent>(continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G02_Continent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="G02_Continent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(Continent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(G03_Continent_SingleObjectProperty, DataPortal.CreateChild<G03_Continent_Child>());
            LoadProperty(G03_Continent_ASingleObjectProperty, DataPortal.CreateChild<G03_Continent_ReChild>());
            LoadProperty(G03_SubContinentObjectsProperty, DataPortal.CreateChild<G03_SubContinentColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="G02_Continent"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        protected void DataPortal_Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, continent_ID);
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
        /// Loads a <see cref="G02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Continent_IDProperty, dr.GetInt32("Continent_ID"));
            LoadProperty(Continent_NameProperty, dr.GetString("Continent_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        private void FetchChildren()
        {
            LoadProperty(G03_Continent_SingleObjectProperty, G03_Continent_Child.GetG03_Continent_Child(Continent_ID));
            LoadProperty(G03_Continent_ASingleObjectProperty, G03_Continent_ReChild.GetG03_Continent_ReChild(Continent_ID));
            LoadProperty(G03_SubContinentObjectsProperty, G03_SubContinentColl.GetG03_SubContinentColl(Continent_ID));
        }

        /// <summary>
        /// Inserts a new <see cref="G02_Continent"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", ReadProperty(Continent_IDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", ReadProperty(Continent_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(Continent_IDProperty, (int) cmd.Parameters["@Continent_ID"].Value);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="G02_Continent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", ReadProperty(Continent_IDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", ReadProperty(Continent_NameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="G02_Continent"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(Continent_ID);
        }

        /// <summary>
        /// Deletes the <see cref="G02_Continent"/> object from database.
        /// </summary>
        /// <param name="continent_ID">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, continent_ID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(G03_Continent_SingleObjectProperty, DataPortal.CreateChild<G03_Continent_Child>());
            LoadProperty(G03_Continent_ASingleObjectProperty, DataPortal.CreateChild<G03_Continent_ReChild>());
            LoadProperty(G03_SubContinentObjectsProperty, DataPortal.CreateChild<G03_SubContinentColl>());
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
