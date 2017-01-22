//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    Folder
// ObjectType:  Folder
// CSLAType:    EditableRoot

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using Csla.Rules;
using Csla.Rules.CommonRules;
using CslaGenFork.Rules.CompareFieldsRules;
using CslaGenFork.Rules.TransformationRules;
using DocStore.Business.Circulations;
using DocStore.Business.Security;

namespace DocStore.Business
{

    /// <summary>
    /// Folder (editable root object).<br/>
    /// This is a generated base class of <see cref="Folder"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains two child collections:<br/>
    /// - <see cref="Docs"/> of type <see cref="FolderDocColl"/> (M:M relation to <see cref="Doc"/>)<br/>
    /// - <see cref="Circulations"/> of type <see cref="FolderCircColl"/> (1:M relation to <see cref="FolderCirc"/>)
    /// </remarks>
    [Serializable]
    public partial class Folder : BusinessBase<Folder>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

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
        /// Maintains metadata about <see cref="FolderTypeID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> FolderTypeIDProperty = RegisterProperty<int>(p => p.FolderTypeID, "Folder Type ID");
        /// <summary>
        /// Gets or sets the Folder Type ID.
        /// </summary>
        /// <value>The Folder Type ID.</value>
        public int FolderTypeID
        {
            get { return GetProperty(FolderTypeIDProperty); }
            set { SetProperty(FolderTypeIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FolderRef"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FolderRefProperty = RegisterProperty<string>(p => p.FolderRef, "Folder Ref");
        /// <summary>
        /// Gets or sets the Folder Ref.
        /// </summary>
        /// <value>The Folder Ref.</value>
        public string FolderRef
        {
            get { return GetProperty(FolderRefProperty); }
            set { SetProperty(FolderRefProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Year"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> YearProperty = RegisterProperty<int>(p => p.Year, "Folder Year");
        /// <summary>
        /// Gets or sets the Folder Year.
        /// </summary>
        /// <value>The Folder Year.</value>
        public int Year
        {
            get { return GetProperty(YearProperty); }
            set { SetProperty(YearProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Subject"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubjectProperty = RegisterProperty<string>(p => p.Subject, "Subject");
        /// <summary>
        /// Gets or sets the Subject.
        /// </summary>
        /// <value>The Subject.</value>
        public string Subject
        {
            get { return GetProperty(SubjectProperty); }
            set { SetProperty(SubjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FolderStatusID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> FolderStatusIDProperty = RegisterProperty<int>(p => p.FolderStatusID, "Folder Status ID");
        /// <summary>
        /// Gets or sets the Folder Status ID.
        /// </summary>
        /// <value>The Folder Status ID.</value>
        public int FolderStatusID
        {
            get { return GetProperty(FolderStatusIDProperty); }
            set { SetProperty(FolderStatusIDProperty, value); }
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

        /// <summary>
        /// Maintains metadata about child <see cref="Docs"/> property.
        /// </summary>
        public static readonly PropertyInfo<FolderDocColl> DocsProperty = RegisterProperty<FolderDocColl>(p => p.Docs, "Docs", RelationshipTypes.Child | RelationshipTypes.LazyLoad);
        /// <summary>
        /// Gets the Docs ("lazy load" child property).
        /// </summary>
        /// <value>The Docs.</value>
        public FolderDocColl Docs
        {
            get
            {
#if ASYNC
                if (!FieldManager.FieldExists(DocsProperty))
                {
                    LoadProperty(DocsProperty, null);
                    if (this.IsNew)
                    {
                        FolderDocColl.NewFolderDocColl((o, e) =>
                            {
                                if (e.Error != null)
                                    throw e.Error;
                                else
                                {
                                    // set the property so OnPropertyChanged is raised
                                    Docs = e.Object;
                                }
                            });
                        return null;
                    }
                    else
                    {
                        FolderDocColl.GetFolderDocColl(ReadProperty(FolderIDProperty), (o, e) =>
                            {
                                if (e.Error != null)
                                    throw e.Error;
                                else
                                {
                                    // set the property so OnPropertyChanged is raised
                                    Docs = e.Object;
                                }
                            });
                        return null;
                    }
                }
                else
                {
                    return GetProperty(DocsProperty);
                }
#else
                if (!FieldManager.FieldExists(DocsProperty))
                    if (this.IsNew)
                        Docs = FolderDocColl.NewFolderDocColl();
                    else
                        Docs = FolderDocColl.GetFolderDocColl(ReadProperty(FolderIDProperty));

                return GetProperty(DocsProperty);
#endif
            }
            private set
            {
                LoadProperty(DocsProperty, value);
                OnPropertyChanged(DocsProperty);
            }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="Circulations"/> property.
        /// </summary>
        public static readonly PropertyInfo<FolderCircColl> CirculationsProperty = RegisterProperty<FolderCircColl>(p => p.Circulations, "Circulations", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Circulations ("parent load" child property).
        /// </summary>
        /// <value>The Circulations.</value>
        public FolderCircColl Circulations
        {
            get { return GetProperty(CirculationsProperty); }
            private set { LoadProperty(CirculationsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="Folder"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="Folder"/> object.</returns>
        public static Folder NewFolder()
        {
            return DataPortal.Create<Folder>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="Folder"/> object, based on given parameters.
        /// </summary>
        /// <param name="folderID">The FolderID parameter of the Folder to fetch.</param>
        /// <returns>A reference to the fetched <see cref="Folder"/> object.</returns>
        public static Folder GetFolder(int folderID)
        {
            return DataPortal.Fetch<Folder>(folderID);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="Folder"/> object, based on given parameters.
        /// </summary>
        /// <param name="folderID">The FolderID of the Folder to delete.</param>
        public static void DeleteFolder(int folderID)
        {
            DataPortal.Delete<Folder>(folderID);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="Folder"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewFolder(EventHandler<DataPortalResult<Folder>> callback)
        {
            DataPortal.BeginCreate<Folder>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="Folder"/> object, based on given parameters.
        /// </summary>
        /// <param name="folderID">The FolderID parameter of the Folder to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetFolder(int folderID, EventHandler<DataPortalResult<Folder>> callback)
        {
            DataPortal.BeginFetch<Folder>(folderID, callback);
        }

        /// <summary>
        /// Factory method. Asynchronously deletes a <see cref="Folder"/> object, based on given parameters.
        /// </summary>
        /// <param name="folderID">The FolderID of the Folder to delete.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void DeleteFolder(int folderID, EventHandler<DataPortalResult<Folder>> callback)
        {
            DataPortal.BeginDelete<Folder>(folderID, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Folder"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Folder()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnFolderSaved;
        }

        #endregion

        #region Cache Invalidation

        private void OnFolderSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            FolderList.InvalidateCache();
        }

        /// <summary>
        /// Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        /// </summary>
        /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        protected override void DataPortal_OnDataPortalInvokeComplete(Csla.DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server &&
                e.Operation == DataPortalOperations.Update)
            {
                // this runs on the server
                FolderList.InvalidateCache();
            }
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (Folder), new IsInRole(AuthorizationActions.CreateObject, "Archivist"));
            BusinessRules.AddRule(typeof (Folder), new IsInRole(AuthorizationActions.GetObject, "User"));
            BusinessRules.AddRule(typeof (Folder), new IsInRole(AuthorizationActions.EditObject, "Archivist"));
            BusinessRules.AddRule(typeof (Folder), new IsInRole(AuthorizationActions.DeleteObject, "Admin", "Manager"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new Folder object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(Folder));
        }

        /// <summary>
        /// Checks if the current user can retrieve Folder's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(Folder));
        }

        /// <summary>
        /// Checks if the current user can change Folder's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(Folder));
        }

        /// <summary>
        /// Checks if the current user can delete a Folder object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(Folder));
        }

        #endregion

        #region Business Rules and Property Authorization

        /// <summary>
        /// Override this method in your business class to be notified when you need to set up shared business rules.
        /// </summary>
        /// <remarks>
        /// This method is automatically called by CSLA.NET when your object should associate
        /// per-type validation rules with its properties.
        /// </remarks>
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            // Property Business Rules

            // FolderTypeID
            BusinessRules.AddRule(new Required(FolderTypeIDProperty));
            // FolderRef
            BusinessRules.AddRule(new CollapseWhiteSpace(FolderRefProperty) { Priority = -1 });
            BusinessRules.AddRule(new Required(FolderRefProperty) { Severity = RuleSeverity.Warning });
            BusinessRules.AddRule(new MaxLength(FolderRefProperty, 25));
            // Year
            BusinessRules.AddRule(new Required(YearProperty));
            BusinessRules.AddRule(new Range<int, int>(YearProperty, 2005, 2010) { Severity = RuleSeverity.Information, MessageText = "N�o pode ser antes de 2005 nem depois de 2010" });
            // Subject
            BusinessRules.AddRule(new CollapseWhiteSpace(SubjectProperty) { Priority = -1 });
            BusinessRules.AddRule(new Required(SubjectProperty));
            BusinessRules.AddRule(new MaxLength(SubjectProperty, 255));
            // FolderStatusID
            BusinessRules.AddRule(new Required(FolderStatusIDProperty));

            AddBusinessRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom shared business rules.
        /// </summary>
        partial void AddBusinessRulesExtend();

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="Folder"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(FolderIDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(FolderTypeIDProperty, -1);
            LoadProperty(YearProperty, DateTime.Today.Year);
            LoadProperty(FolderStatusIDProperty, -1);
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(CreateUserIDProperty, UserInformation.UserId);
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty));
            LoadProperty(CirculationsProperty, DataPortal.CreateChild<FolderCircColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="Folder"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="folderID">The Folder ID.</param>
        protected void DataPortal_Fetch(int folderID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetFolder", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderID", folderID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, folderID);
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
                    FetchChildren(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="Folder"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(FolderIDProperty, dr.GetInt32("FolderID"));
            LoadProperty(FolderTypeIDProperty, dr.GetInt32("FolderTypeID"));
            LoadProperty(FolderRefProperty, dr.GetString("FolderRef"));
            LoadProperty(YearProperty, dr.GetInt32("Year"));
            LoadProperty(SubjectProperty, dr.GetString("Subject"));
            LoadProperty(FolderStatusIDProperty, dr.GetInt32("FolderStatusID"));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            LoadProperty(CirculationsProperty, FolderCircColl.GetFolderCircColl(dr));
        }

        /// <summary>
        /// Inserts a new <see cref="Folder"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("AddFolder", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@FolderTypeID", ReadProperty(FolderTypeIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FolderRef", ReadProperty(FolderRefProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Year", ReadProperty(YearProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@FolderStatusID", ReadProperty(FolderStatusIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(FolderIDProperty, (int) cmd.Parameters["@FolderID"].Value);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="Folder"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateFolder", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FolderTypeID", ReadProperty(FolderTypeIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FolderRef", ReadProperty(FolderRefProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Year", ReadProperty(YearProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@FolderStatusID", ReadProperty(FolderStatusIDProperty)).DbType = DbType.Int32;
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
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
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
        /// Self deletes the <see cref="Folder"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(FolderID);
        }

        /// <summary>
        /// Deletes the <see cref="Folder"/> object from database.
        /// </summary>
        /// <param name="folderID">The delete criteria.</param>
        protected void DataPortal_Delete(int folderID)
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("DeleteFolder", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderID", folderID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, folderID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
                ctx.Commit();
            }
            // removes all previous references to children
            LoadProperty(DocsProperty, DataPortal.CreateChild<FolderDocColl>());
            LoadProperty(CirculationsProperty, DataPortal.CreateChild<FolderCircColl>());
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
