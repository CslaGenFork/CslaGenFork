using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Rules;
using Csla.Rules.CommonRules;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// Folder where this document is archived (editable child object).<br/>
    /// This is a generated <see cref="DocFolder"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="DocFolderColl"/> collection.
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocFolder : MyBusinessBase<DocFolder>, IHaveInterface
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="FolderID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> FolderIDProperty = RegisterProperty<int>(p => p.FolderID, "Folder ID");
        /// <summary>
        /// Gets the Folder ID.
        /// </summary>
        /// <value>The Folder ID.</value>
        public int FolderID
        {
            get { return GetProperty(FolderIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FolderRef"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FolderRefProperty = RegisterProperty<string>(p => p.FolderRef, "Folder Ref");
        /// <summary>
        /// Gets the Folder Ref.
        /// </summary>
        /// <value>The Folder Ref.</value>
        public string FolderRef
        {
            get { return GetProperty(FolderRefProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Year"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> YearProperty = RegisterProperty<int>(p => p.Year, "Folder Year");
        /// <summary>
        /// Gets the Folder Year.
        /// </summary>
        /// <value>The Folder Year.</value>
        public int Year
        {
            get { return GetProperty(YearProperty); }
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

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocFolder"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocFolder()
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
            BusinessRules.AddRule(typeof (DocFolder), new IsInRole(AuthorizationActions.CreateObject, "Archivist"));
            BusinessRules.AddRule(typeof (DocFolder), new IsInRole(AuthorizationActions.GetObject, "User"));
            BusinessRules.AddRule(typeof (DocFolder), new IsInRole(AuthorizationActions.EditObject, "Author"));
            BusinessRules.AddRule(typeof (DocFolder), new IsInRole(AuthorizationActions.DeleteObject, "Admin", "Manager"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new DocFolder object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(DocFolder));
        }

        /// <summary>
        /// Checks if the current user can retrieve DocFolder's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(DocFolder));
        }

        /// <summary>
        /// Checks if the current user can change DocFolder's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(DocFolder));
        }

        /// <summary>
        /// Checks if the current user can delete a DocFolder object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(DocFolder));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="DocFolder"/> object properties, based on given criteria.
        /// </summary>
        /// <param name="folderID">The create criteria.</param>
        protected void DataPortal_Create(int folderID)
        {
            LoadProperty(FolderIDProperty, folderID);
            var args = new DataPortalHookArgs(folderID);
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="DocFolder"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(FolderIDProperty, dr.GetInt32("FolderID"));
            LoadProperty(FolderRefProperty, dr.GetString("FolderRef"));
            LoadProperty(YearProperty, dr.GetInt32("Year"));
            LoadProperty(SubjectProperty, dr.GetString("Subject"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Inserts a new <see cref="DocFolder"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        private void Child_Insert(Doc parent)
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("AddDocFolderRelation", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DocFolder"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        private void Child_Update(Doc parent)
        {
            if (!IsDirty)
                return;

            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateDocFolderRelation", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
            }
        }

        /// <summary>
        /// Self deletes the <see cref="DocFolder"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        private void Child_DeleteSelf(Doc parent)
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("DeleteDocFolderRelation", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).DbType = DbType.Int32;
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
