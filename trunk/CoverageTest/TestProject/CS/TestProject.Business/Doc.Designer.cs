using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Rules;
using Csla.Rules.CommonRules;
using System.ComponentModel.DataAnnotations;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// Documents (editable root object).<br/>
    /// This is a generated base class of <see cref="Doc"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="Folders"/> of type <see cref="DocFolderColl"/> (1:M relation to <see cref="DocFolder"/>)
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class Doc : MyBusinessBase<Doc>, IHaveInterface
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> DocIDProperty = RegisterProperty<int>(p => p.DocID, "Doc ID");
        /// <summary>
        /// Gets or sets the Document ID.
        /// </summary>
        /// <value>The Doc ID.</value>
        public int DocID
        {
            get { return GetProperty(DocIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocTypeID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> DocTypeIDProperty = RegisterProperty<int>(p => p.DocTypeID, "Doc Type ID");
        /// <summary>
        /// Gets or sets the Document Type ID.
        /// </summary>
        /// <value>The Doc Type ID.</value>
        public int DocTypeID
        {
            get { return GetProperty(DocTypeIDProperty); }
            set { SetProperty(DocTypeIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocRef"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocRefProperty = RegisterProperty<string>(p => p.DocRef, "Doc Ref");
        /// <summary>
        /// Gets or sets the Doc Ref.
        /// </summary>
        /// <value>The Doc Ref.</value>
        public string DocRef
        {
            get { return GetProperty(DocRefProperty); }
            set { SetProperty(DocRefProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> DocDateProperty = RegisterProperty<SmartDate>(p => p.DocDate, "Doc Date");
        /// <summary>
        /// Gets or sets the Doc Date.
        /// </summary>
        /// <value>The Doc Date.</value>
        [Required]
        public string DocDate
        {
            get { return GetPropertyConvert<SmartDate, string>(DocDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(DocDateProperty, value); }
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
        /// Maintains metadata about child <see cref="Folders"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocFolderColl> FoldersProperty = RegisterProperty<DocFolderColl>(p => p.Folders, "Folders", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Folders ("parent load" child property).
        /// </summary>
        /// <value>The Folders.</value>
        public DocFolderColl Folders
        {
            get { return GetProperty(FoldersProperty); }
            private set { LoadProperty(FoldersProperty, value); }
        }

        #endregion

        #region BusinessBase<T> overrides

        /// <summary>
        /// Returns a string that represents the current <see cref="Doc"/>
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            // Return the Primary Key as a string
            return DocID.ToString() + ", " + DocRef.ToString();
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="Doc"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="Doc"/> object.</returns>
        public static Doc NewDoc()
        {
            return DataPortal.Create<Doc>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="Doc"/> object, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the Doc to fetch.</param>
        /// <returns>A reference to the fetched <see cref="Doc"/> object.</returns>
        public static Doc GetDoc(int docID)
        {
            return DataPortal.Fetch<Doc>(docID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Doc"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Doc()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnDocSaved;
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (Doc), new IsInRole(AuthorizationActions.CreateObject, "Author"));
            BusinessRules.AddRule(typeof (Doc), new IsInRole(AuthorizationActions.GetObject, "User"));
            BusinessRules.AddRule(typeof (Doc), new IsInRole(AuthorizationActions.EditObject, "Author"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new Doc object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(Doc));
        }

        /// <summary>
        /// Checks if the current user can retrieve Doc's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(Doc));
        }

        /// <summary>
        /// Checks if the current user can change Doc's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(Doc));
        }

        /// <summary>
        /// Checks if the current user can delete a Doc object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(Doc));
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

            // DocTypeID
            BusinessRules.AddRule(new Required(DocTypeIDProperty));
            // DocRef
            BusinessRules.AddRule(new MaxLength(DocRefProperty, 35));
            // DocDate
            BusinessRules.AddRule(new Required(DocDateProperty));
            // Subject
            BusinessRules.AddRule(new Required(SubjectProperty));
            BusinessRules.AddRule(new MaxLength(SubjectProperty, 255));

            AddBusinessRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom shared business rules.
        /// </summary>
        partial void AddBusinessRulesExtend();

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="Doc"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(DocIDProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            LoadProperty(DocRefProperty, null);
            LoadProperty(DocDateProperty, new SmartDate(DateTime.Today));
            LoadProperty(FoldersProperty, DataPortal.CreateChild<DocFolderColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="Doc"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="docID">The Doc ID.</param>
        protected void DataPortal_Fetch(int docID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("GetDoc", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", docID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, docID);
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
        /// Loads a <see cref="Doc"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocIDProperty, dr.GetInt32("DocID"));
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"));
            LoadProperty(DocRefProperty, dr.IsDBNull("DocRef") ? null : dr.GetString("DocRef"));
            LoadProperty(DocDateProperty, dr.GetSmartDate("DocDate", true));
            LoadProperty(SubjectProperty, dr.GetString("Subject"));
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
            LoadProperty(FoldersProperty, DataPortal.FetchChild<DocFolderColl>(dr));
        }

        /// <summary>
        /// Inserts a new <see cref="Doc"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("AddDoc", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocRef", ReadProperty(DocRefProperty) == null ? (object)DBNull.Value : ReadProperty(DocRefProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocDate", ReadProperty(DocDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(DocIDProperty, (int) cmd.Parameters["@DocID"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="Doc"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateDoc", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocRef", ReadProperty(DocRefProperty) == null ? (object)DBNull.Value : ReadProperty(DocRefProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocDate", ReadProperty(DocDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                ctx.Commit();
            }
        }

        #endregion

        #region Saved Event

        private void OnDocSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (DocSaved != null)
                DocSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="Doc"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> DocSaved;

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

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
