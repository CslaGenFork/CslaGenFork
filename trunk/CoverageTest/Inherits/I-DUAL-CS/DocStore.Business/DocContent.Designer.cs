//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocContent
// ObjectType:  DocContent
// CSLAType:    EditableChild

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using DocStore.Business.Security;
using UsingLibrary;

namespace DocStore.Business
{

    /// <summary>
    /// Document files (editable child object).<br/>
    /// This is a generated base class of <see cref="DocContent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="Doc"/> collection.
    /// </remarks>
    [Serializable]
    public partial class DocContent : MyBusinessBase<DocContent>, IHaveInterface, IHaveGenericInterface<DocContent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocContentID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> DocContentIDProperty = RegisterProperty<int>(p => p.DocContentID, "Doc Content ID");
        /// <summary>
        /// Gets the Doc Content ID.
        /// </summary>
        /// <value>The Doc Content ID.</value>
        public int DocContentID
        {
            get { return GetProperty(DocContentIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Version"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> VersionProperty = RegisterProperty<short>(p => p.Version, "Version");
        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        /// <value>The Version.</value>
        public short Version
        {
            get { return GetProperty(VersionProperty); }
            set { SetProperty(VersionProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FileContent"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte[]> FileContentProperty = RegisterProperty<byte[]>(p => p.FileContent, "File Content");
        /// <summary>
        /// Gets or sets the File Content.
        /// </summary>
        /// <value>The File Content.</value>
        public byte[] FileContent
        {
            get { return GetProperty(FileContentProperty); }
            set { SetProperty(FileContentProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FileSize"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> FileSizeProperty = RegisterProperty<int>(p => p.FileSize, "File Size");
        /// <summary>
        /// Gets or sets the File Size.
        /// </summary>
        /// <value>The File Size.</value>
        public int FileSize
        {
            get { return GetProperty(FileSizeProperty); }
            set { SetProperty(FileSizeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FileType"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FileTypeProperty = RegisterProperty<string>(p => p.FileType, "File Type");
        /// <summary>
        /// Gets or sets the File Type.
        /// </summary>
        /// <value>The File Type.</value>
        public string FileType
        {
            get { return GetProperty(FileTypeProperty); }
            set { SetProperty(FileTypeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckInDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CheckInDateProperty = RegisterProperty<SmartDate>(p => p.CheckInDate, "Check In Date");
        /// <summary>
        /// Check-in date
        /// </summary>
        /// <value>The Check In Date.</value>
        public string CheckInDate
        {
            get { return GetPropertyConvert<SmartDate, string>(CheckInDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(CheckInDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckInUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CheckInUserIDProperty = RegisterProperty<int>(p => p.CheckInUserID, "Check In User ID");
        /// <summary>
        /// Check-in user ID
        /// </summary>
        /// <value>The Check In User ID.</value>
        public int CheckInUserID
        {
            get { return GetProperty(CheckInUserIDProperty); }
            set
            {
                SetProperty(CheckInUserIDProperty, value);
                OnPropertyChanged("CheckInUserName");
            }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckInComment"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CheckInCommentProperty = RegisterProperty<string>(p => p.CheckInComment, "Check In Comment");
        /// <summary>
        /// Check-in comment
        /// </summary>
        /// <value>The Check In Comment.</value>
        public string CheckInComment
        {
            get { return GetProperty(CheckInCommentProperty); }
            set { SetProperty(CheckInCommentProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckOutDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CheckOutDateProperty = RegisterProperty<SmartDate>(p => p.CheckOutDate, "Check Out Date");
        /// <summary>
        /// Check-out date
        /// </summary>
        /// <value>The Check Out Date.</value>
        public string CheckOutDate
        {
            get { return GetPropertyConvert<SmartDate, string>(CheckOutDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(CheckOutDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CheckOutUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int?> CheckOutUserIDProperty = RegisterProperty<int?>(p => p.CheckOutUserID, "Check Out User ID");
        /// <summary>
        /// Check-out user ID
        /// </summary>
        /// <value>The Check Out User ID.</value>
        public int? CheckOutUserID
        {
            get { return GetProperty(CheckOutUserIDProperty); }
            set
            {
                SetProperty(CheckOutUserIDProperty, value);
                OnPropertyChanged("CheckOutUserName");
            }
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
        /// Gets the Check In User Name.
        /// </summary>
        /// <value>The Check In User Name.</value>
        public string CheckInUserName
        {
            get
            {
                var result = string.Empty;
                if (Admin.UserNVL.GetUserNVL().ContainsKey(CheckInUserID))
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(CheckInUserID).Value;
                return result;
            }
        }

        /// <summary>
        /// Gets the Check Out User Name.
        /// </summary>
        /// <value>The Check Out User Name.</value>
        public string CheckOutUserName
        {
            get
            {
                var result = string.Empty;
                if (CheckOutUserID.HasValue && Admin.UserNVL.GetUserNVL().ContainsKey(CheckOutUserID.Value))
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(CheckOutUserID.Value).Value;
                return result;
            }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocContent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocContent"/> object.</returns>
        internal static DocContent NewDocContent()
        {
            return DataPortal.CreateChild<DocContent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocContent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="DocContent"/> object.</returns>
        internal static DocContent GetDocContent(SafeDataReader dr)
        {
            DocContent obj = new DocContent();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="DocContent"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        internal static void NewDocContent(EventHandler<DataPortalResult<DocContent>> callback)
        {
            DataPortal.BeginCreate<DocContent>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocContent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocContent()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="DocContent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(DocContentIDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(VersionProperty, (short)1);
            LoadProperty(FileContentProperty, new byte[0]);
            LoadProperty(FileSizeProperty, 0);
            LoadProperty(FileTypeProperty, "");
            LoadProperty(CheckInDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(CheckInUserIDProperty, UserInformation.UserId);
            LoadProperty(CheckInCommentProperty, "Main content");
            LoadProperty(CheckOutDateProperty, null);
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="DocContent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocContentIDProperty, dr.GetInt32("DocContentID"));
            LoadProperty(VersionProperty, dr.GetInt16("Version"));
            LoadProperty(FileSizeProperty, dr.GetInt32("FileSize"));
            LoadProperty(FileTypeProperty, dr.GetString("FileType"));
            LoadProperty(CheckInDateProperty, dr.GetSmartDate("CheckInDate", true));
            LoadProperty(CheckInUserIDProperty, dr.GetInt32("CheckInUserID"));
            LoadProperty(CheckInCommentProperty, dr.GetString("CheckInComment"));
            LoadProperty(CheckOutDateProperty, dr.IsDBNull("CheckOutDate") ? null : dr.GetSmartDate("CheckOutDate", true));
            LoadProperty(CheckOutUserIDProperty, (int?)dr.GetValue("CheckOutUserID"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="DocContent"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        private void Child_Insert(Doc parent)
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("AddDocContent", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocContentID", ReadProperty(DocContentIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@FileSize", ReadProperty(FileSizeProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FileType", ReadProperty(FileTypeProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CheckInDate", ReadProperty(CheckInDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CheckInUserID", ReadProperty(CheckInUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CheckInComment", ReadProperty(CheckInCommentProperty)).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(DocContentIDProperty, (int) cmd.Parameters["@DocContentID"].Value);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DocContent"/> object.
        /// </summary>
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateDocContent", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocContentID", ReadProperty(DocContentIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CheckOutDate", ReadProperty(CheckOutDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CheckOutUserID", ReadProperty(CheckOutUserIDProperty) == null ? (object)DBNull.Value : ReadProperty(CheckOutUserIDProperty).Value).DbType = DbType.Int32;
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
