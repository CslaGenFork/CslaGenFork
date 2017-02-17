//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    FolderType
// ObjectType:  FolderType
// CSLAType:    EditableRoot

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using Csla.Rules;
using Csla.Rules.CommonRules;
using DocStore.Business.Security;

namespace DocStore.Business
{

    /// <summary>
    /// Folder type (editable root object).<br/>
    /// This is a generated base class of <see cref="FolderType"/> business object.
    /// </summary>
    [Serializable]
    public partial class FolderType : BusinessBase<FolderType>
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="FolderTypeID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> FolderTypeIDProperty = RegisterProperty<int>(p => p.FolderTypeID, "Folder Type ID");
        /// <summary>
        /// Gets the Folder Type ID.
        /// </summary>
        /// <value>The Folder Type ID.</value>
        public int FolderTypeID
        {
            get { return GetProperty(FolderTypeIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FolderTypeName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FolderTypeNameProperty = RegisterProperty<string>(p => p.FolderTypeName, "Folder Type Name");
        /// <summary>
        /// Gets or sets the Folder Type Name.
        /// </summary>
        /// <value>The Folder Type Name.</value>
        public string FolderTypeName
        {
            get { return GetProperty(FolderTypeNameProperty); }
            set { SetProperty(FolderTypeNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(p => p.CreateDate, "Create Date");
        /// <summary>
        /// Gets the Create Date.
        /// </summary>
        /// <value>The Create Date.</value>
        public SmartDate CreateDate
        {
            get { return GetProperty(CreateDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CreateUserIDProperty = RegisterProperty<int>(p => p.CreateUserID, "Create User ID");
        /// <summary>
        /// Gets the Create User ID.
        /// </summary>
        /// <value>The Create User ID.</value>
        public int CreateUserID
        {
            get { return GetProperty(CreateUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> ChangeDateProperty = RegisterProperty<SmartDate>(p => p.ChangeDate, "Change Date");
        /// <summary>
        /// Gets the Change Date.
        /// </summary>
        /// <value>The Change Date.</value>
        public SmartDate ChangeDate
        {
            get { return GetProperty(ChangeDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ChangeUserIDProperty = RegisterProperty<int>(p => p.ChangeUserID, "Change User ID");
        /// <summary>
        /// Gets the Change User ID.
        /// </summary>
        /// <value>The Change User ID.</value>
        public int ChangeUserID
        {
            get { return GetProperty(ChangeUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RowVersion"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<byte[]> RowVersionProperty = RegisterProperty<byte[]>(p => p.RowVersion, "Row Version");
        /// <summary>
        /// Gets the Row Version.
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion
        {
            get { return GetProperty(RowVersionProperty); }
        }

        /// <summary>
        /// Gets the Create User Name.
        /// </summary>
        /// <value>The Create User Name.</value>
        public string CreateUserName
        {
            get
            {
                var result = string.Empty;
                if (Admin.UserNVL.GetUserNVL().ContainsKey(CreateUserID))
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(CreateUserID).Value;
                return result;
            }
        }

        /// <summary>
        /// Gets the Change User Name.
        /// </summary>
        /// <value>The Change User Name.</value>
        public string ChangeUserName
        {
            get
            {
                var result = string.Empty;
                if (Admin.UserNVL.GetUserNVL().ContainsKey(ChangeUserID))
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(ChangeUserID).Value;
                return result;
            }
        }

        #endregion

        #region BusinessBase<T> overrides

        /// <summary>
        /// Returns a string that represents the current <see cref="FolderType"/>
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            // Return the Primary Key as a string
            return FolderTypeName.ToString();
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="FolderType"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="FolderType"/> object.</returns>
        public static FolderType NewFolderType()
        {
            return DataPortal.Create<FolderType>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="FolderType"/> object, based on given parameters.
        /// </summary>
        /// <param name="folderTypeID">The FolderTypeID parameter of the FolderType to fetch.</param>
        /// <returns>A reference to the fetched <see cref="FolderType"/> object.</returns>
        public static FolderType GetFolderType(int folderTypeID)
        {
            return DataPortal.Fetch<FolderType>(folderTypeID);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="FolderType"/> object, based on given parameters.
        /// </summary>
        /// <param name="folderTypeID">The FolderTypeID of the FolderType to delete.</param>
        public static void DeleteFolderType(int folderTypeID)
        {
            DataPortal.Delete<FolderType>(folderTypeID);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="FolderType"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewFolderType(EventHandler<DataPortalResult<FolderType>> callback)
        {
            DataPortal.BeginCreate<FolderType>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="FolderType"/> object, based on given parameters.
        /// </summary>
        /// <param name="folderTypeID">The FolderTypeID parameter of the FolderType to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetFolderType(int folderTypeID, EventHandler<DataPortalResult<FolderType>> callback)
        {
            DataPortal.BeginFetch<FolderType>(folderTypeID, callback);
        }

        /// <summary>
        /// Factory method. Asynchronously deletes a <see cref="FolderType"/> object, based on given parameters.
        /// </summary>
        /// <param name="folderTypeID">The FolderTypeID of the FolderType to delete.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void DeleteFolderType(int folderTypeID, EventHandler<DataPortalResult<FolderType>> callback)
        {
            DataPortal.BeginDelete<FolderType>(folderTypeID, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderType"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FolderType()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (FolderType), new IsInRole(AuthorizationActions.CreateObject, "Manager"));
            BusinessRules.AddRule(typeof (FolderType), new IsInRole(AuthorizationActions.GetObject, "User"));
            BusinessRules.AddRule(typeof (FolderType), new IsInRole(AuthorizationActions.EditObject, "Manager"));
            BusinessRules.AddRule(typeof (FolderType), new IsInRole(AuthorizationActions.DeleteObject, "Admin"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new FolderType object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(FolderType));
        }

        /// <summary>
        /// Checks if the current user can retrieve FolderType's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(FolderType));
        }

        /// <summary>
        /// Checks if the current user can change FolderType's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(FolderType));
        }

        /// <summary>
        /// Checks if the current user can delete a FolderType object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(FolderType));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="FolderType"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(FolderTypeIDProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(CreateUserIDProperty, UserInformation.UserId);
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="FolderType"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="folderTypeID">The Folder Type ID.</param>
        protected void DataPortal_Fetch(int folderTypeID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetFolderType", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderTypeID", folderTypeID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, folderTypeID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
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
        /// Loads a <see cref="FolderType"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(FolderTypeIDProperty, dr.GetInt32("FolderTypeID"));
            LoadProperty(FolderTypeNameProperty, dr.GetString("FolderTypeName"));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="FolderType"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("AddFolderType", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderTypeID", ReadProperty(FolderTypeIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@FolderTypeName", ReadProperty(FolderTypeNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(FolderTypeIDProperty, (int) cmd.Parameters["@FolderTypeID"].Value);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="FolderType"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateFolderType", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderTypeID", ReadProperty(FolderTypeIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FolderTypeName", ReadProperty(FolderTypeNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                ctx.Commit();
            }
        }

        private void SimpleAuditTrail()
        {
            LoadProperty(ChangeDateProperty, DateTime.Now);
            LoadProperty(ChangeUserIDProperty, UserInformation.UserId);
            OnPropertyChanged("ChangeUserName");
            if (IsNew)
            {
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty));
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty));
                OnPropertyChanged("CreateUserName");
            }
        }

        /// <summary>
        /// Self deletes the <see cref="FolderType"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(FolderTypeID);
        }

        /// <summary>
        /// Deletes the <see cref="FolderType"/> object from database.
        /// </summary>
        /// <param name="folderTypeID">The delete criteria.</param>
        protected void DataPortal_Delete(int folderTypeID)
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("DeleteFolderType", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderTypeID", folderTypeID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, folderTypeID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
                ctx.Commit();
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
