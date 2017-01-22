using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.ComponentModel.DataAnnotations;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// Types of document (editable child object).<br/>
    /// This is a generated base class of <see cref="DocTypeEdit"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="DocTypeEditColl"/> collection.
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocTypeEdit : BusinessBase<DocTypeEdit>, IHaveInterface
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocTypeID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> DocTypeIDProperty = RegisterProperty<int>(p => p.DocTypeID, "Doc Type ID");
        /// <summary>
        /// Gets the Doc Type ID.
        /// </summary>
        /// <value>The Doc Type ID.</value>
        public int DocTypeID
        {
            get { return GetProperty(DocTypeIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocTypeName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocTypeNameProperty = RegisterProperty<string>(p => p.DocTypeName, "Doc Type Name");
        /// <summary>
        /// Gets or sets the Doc Type Name.
        /// </summary>
        /// <value>The Doc Type Name.</value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Must fill.")]
        public string DocTypeName
        {
            get { return GetProperty(DocTypeNameProperty); }
            set { SetProperty(DocTypeNameProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocTypeEdit"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocTypeEdit()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="DocTypeEdit"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(DocTypeIDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="DocTypeEdit"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"));
            LoadProperty(DocTypeNameProperty, dr.GetString("DocTypeName"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Inserts a new <see cref="DocTypeEdit"/> object in the database.
        /// </summary>
        private void Child_Insert()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("AddDocTypeEdit", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@DocTypeName", ReadProperty(DocTypeNameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(DocTypeIDProperty, (int) cmd.Parameters["@DocTypeID"].Value);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DocTypeEdit"/> object.
        /// </summary>
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateDocTypeEdit", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocTypeName", ReadProperty(DocTypeNameProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
            }
        }

        /// <summary>
        /// Self deletes the <see cref="DocTypeEdit"/> object from database.
        /// </summary>
        private void Child_DeleteSelf()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("DeleteDocTypeEdit", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
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
