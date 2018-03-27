using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// Documents (read only object).<br/>
    /// This is a generated <see cref="DocRO"/> business object.
    /// This class is a root object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="Folders"/> of type <see cref="DocFolderCollRO"/> (1:M relation to <see cref="DocFolderRO"/>)
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocRO : ReadOnlyBase<DocRO>, IHaveInterface
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> DocIDProperty = RegisterProperty<int>(p => p.DocID, "Doc ID", -1);
        /// <summary>
        /// Document ID
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
        /// Document Type ID
        /// </summary>
        /// <value>The Doc Type ID.</value>
        public int DocTypeID
        {
            get { return GetProperty(DocTypeIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocRef"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocRefProperty = RegisterProperty<string>(p => p.DocRef, "Doc Ref", null);
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
        public static readonly PropertyInfo<SmartDate> DocDateProperty = RegisterProperty<SmartDate>(p => p.DocDate, "Doc Date");
        /// <summary>
        /// Gets the Doc Date.
        /// </summary>
        /// <value>The Doc Date.</value>
        public string DocDate
        {
            get { return GetPropertyConvert<SmartDate, string>(DocDateProperty); }
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
        /// Maintains metadata about child <see cref="Folders"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocFolderCollRO> FoldersProperty = RegisterProperty<DocFolderCollRO>(p => p.Folders, "Folders");
        /// <summary>
        /// Gets the Folders ("parent load" child property).
        /// </summary>
        /// <value>The Folders.</value>
        public DocFolderCollRO Folders
        {
            get { return GetProperty(FoldersProperty); }
            private set { LoadProperty(FoldersProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="DocRO"/> object, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the DocRO to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DocRO"/> object.</returns>
        public static DocRO GetDocRO(int docID)
        {
            return DataPortal.Fetch<DocRO>(docID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocRO"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocRO()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocRO"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="docID">The Doc ID.</param>
        protected void DataPortal_Fetch(int docID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.TestProjectConnection, false))
            {
                using (var cmd = new SqlCommand("GetDocRO", ctx.Connection))
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
        /// Loads a <see cref="DocRO"/> object from the given SafeDataReader.
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
            LoadProperty(FoldersProperty, DataPortal.FetchChild<DocFolderCollRO>(dr));
        }

        #endregion

        #region DataPortal Hooks

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

        #endregion

    }
}
