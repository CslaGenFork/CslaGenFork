using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G05Level111Child (editable child object).<br/>
    /// This is a generated base class of <see cref="G05Level111Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="G04Level11"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G05Level111Child : BusinessBase<G05Level111Child>
    {

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_Child_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_Child_Name, "Level_1_1_1 Child Name");
        /// <summary>
        /// Gets or sets the Level_1_1_1 Child Name.
        /// </summary>
        /// <value>The Level_1_1_1 Child Name.</value>
        public string Level_1_1_1_Child_Name
        {
            get { return GetProperty(Level_1_1_1_Child_NameProperty); }
            set { SetProperty(Level_1_1_1_Child_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CMarentID1"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CMarentID1Property = RegisterProperty<int>(p => p.CMarentID1, "CMarent ID1");
        /// <summary>
        /// Gets or sets the CMarent ID1.
        /// </summary>
        /// <value>The CMarent ID1.</value>
        public int CMarentID1
        {
            get { return GetProperty(CMarentID1Property); }
            set { SetProperty(CMarentID1Property, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="G05Level111Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="G05Level111Child"/> object.</returns>
        internal static G05Level111Child NewG05Level111Child()
        {
            return DataPortal.CreateChild<G05Level111Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="G05Level111Child"/> object, based on given parameters.
        /// </summary>
        /// <param name="cMarentID1">The CMarentID1 parameter of the G05Level111Child to fetch.</param>
        /// <returns>A reference to the fetched <see cref="G05Level111Child"/> object.</returns>
        internal static G05Level111Child GetG05Level111Child(int cMarentID1)
        {
            return DataPortal.FetchChild<G05Level111Child>(cMarentID1);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G05Level111Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G05Level111Child()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="G05Level111Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="G05Level111Child"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="cMarentID1">The CMarent ID1.</param>
        protected void Child_Fetch(int cMarentID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG05Level111Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CMarentID1", cMarentID1).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, cMarentID1);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="G05Level111Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_Child_NameProperty, dr.GetString("Level_1_1_1_Child_Name"));
            LoadProperty(CMarentID1Property, dr.GetInt32("CMarentID1"));
            _rowVersion = (dr.GetValue("RowVersion")) as byte[];
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="G05Level111Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(G04Level11 parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG05Level111Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", parent.Level_1_1_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_Child_Name", ReadProperty(Level_1_1_1_Child_NameProperty)).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    _rowVersion = (byte[]) cmd.Parameters["@NewRowVersion"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="G05Level111Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(G04Level11 parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG05Level111Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", parent.Level_1_1_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Level_1_1_1_Child_Name", ReadProperty(Level_1_1_1_Child_NameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CMarentID1", ReadProperty(CMarentID1Property)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", _rowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                    _rowVersion = (byte[]) cmd.Parameters["@NewRowVersion"].Value;
                }
            }
        }

        /// <summary>
        /// Self deletes the <see cref="G05Level111Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(G04Level11 parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG05Level111Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level_1_1_ID", parent.Level_1_1_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
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
