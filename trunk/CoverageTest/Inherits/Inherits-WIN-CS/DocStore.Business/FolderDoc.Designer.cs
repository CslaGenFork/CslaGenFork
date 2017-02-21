//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    FolderDoc
// ObjectType:  FolderDoc
// CSLAType:    EditableChild

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
    /// Document archived in this folder (editable child object).<br/>
    /// This is a generated base class of <see cref="FolderDoc"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="FolderDocColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class FolderDoc : BusinessBase<FolderDoc>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> DocIDProperty = RegisterProperty<int>(p => p.DocID, "Doc ID");
        /// <summary>
        /// Gets the Doc ID.
        /// </summary>
        /// <value>The Doc ID.</value>
        public int DocID
        {
            get { return GetProperty(DocIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocRef"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocRefProperty = RegisterProperty<string>(p => p.DocRef, "Doc Ref");
        /// <summary>
        /// Gets the Doc Ref.
        /// </summary>
        /// <value>The Doc Ref.</value>
        public string DocRef
        {
            get { return GetProperty(DocRefProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<DateTime> DocDateProperty = RegisterProperty<DateTime>(p => p.DocDate, "Doc Date");
        /// <summary>
        /// Gets the Doc Date.
        /// </summary>
        /// <value>The Doc Date.</value>
        public DateTime DocDate
        {
            get { return GetProperty(DocDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Subject"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubjectProperty = RegisterProperty<string>(p => p.Subject, "Subject");
        /// <summary>
        /// Gets the Subject.
        /// </summary>
        /// <value>The Subject.</value>
        public string Subject
        {
            get { return GetProperty(SubjectProperty); }
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

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="FolderDoc"/> object, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID of the FolderDoc to create.</param>
        /// <returns>A reference to the created <see cref="FolderDoc"/> object.</returns>
        internal static FolderDoc NewFolderDoc(int docID)
        {
            return DataPortal.Create<FolderDoc>(docID);
        }

        /// <summary>
        /// Factory method. Loads a <see cref="FolderDoc"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="FolderDoc"/> object.</returns>
        internal static FolderDoc GetFolderDoc(SafeDataReader dr)
        {
            FolderDoc obj = new FolderDoc();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="FolderDoc"/> object, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID of the FolderDoc to create.</param>
        /// <param name="callback">The completion callback method.</param>
        internal static void NewFolderDoc(int docID, EventHandler<DataPortalResult<FolderDoc>> callback)
        {
            DataPortal.BeginCreate<FolderDoc>(docID, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderDoc"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FolderDoc()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (FolderDoc), new IsInRole(AuthorizationActions.CreateObject, "Archivist"));
            BusinessRules.AddRule(typeof (FolderDoc), new IsInRole(AuthorizationActions.GetObject, "User"));
            BusinessRules.AddRule(typeof (FolderDoc), new IsInRole(AuthorizationActions.EditObject, "Author"));
            BusinessRules.AddRule(typeof (FolderDoc), new IsInRole(AuthorizationActions.DeleteObject, "Admin", "Manager"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new FolderDoc object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(FolderDoc));
        }

        /// <summary>
        /// Checks if the current user can retrieve FolderDoc's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(FolderDoc));
        }

        /// <summary>
        /// Checks if the current user can change FolderDoc's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(FolderDoc));
        }

        /// <summary>
        /// Checks if the current user can delete a FolderDoc object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(FolderDoc));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="FolderDoc"/> object properties, based on given criteria.
        /// </summary>
        /// <param name="docID">The create criteria.</param>
        protected void DataPortal_Create(int docID)
        {
            LoadProperty(DocRefProperty, null);
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(CreateUserIDProperty, UserInformation.UserId);
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty));
            LoadProperty(DocIDProperty, docID);
            var args = new DataPortalHookArgs(docID);
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="FolderDoc"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocIDProperty, dr.GetInt32("DocID"));
            LoadProperty(DocRefProperty, dr.IsDBNull("DocRef") ? null : dr.GetString("DocRef"));
            LoadProperty(DocDateProperty, dr.GetDateTime("DocDate"));
            LoadProperty(SubjectProperty, dr.GetString("Subject"));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="FolderDoc"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        private void Child_Insert(Folder parent)
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("AddDocFolderRelation", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderID", parent.FolderID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="FolderDoc"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        private void Child_Update(Folder parent)
        {
            if (!IsDirty)
                return;

            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateDocFolderRelation", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderID", parent.FolderID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).DbType = DbType.Int32;
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
        /// Self deletes the <see cref="FolderDoc"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        private void Child_DeleteSelf(Folder parent)
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("DeleteDocFolderRelation", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderID", parent.FolderID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).DbType = DbType.Int32;
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
