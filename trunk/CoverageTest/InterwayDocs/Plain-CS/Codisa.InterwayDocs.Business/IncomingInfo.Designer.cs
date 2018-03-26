using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Codisa.InterwayDocs.Business
{

    /// <summary>
    /// IncomingInfo (read only object).<br/>
    /// This is a generated <see cref="IncomingInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="IncomingBook"/> collection.
    /// </remarks>
    [Serializable]
    public partial class IncomingInfo : ReadOnlyBase<IncomingInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="RegisterId"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> RegisterIdProperty = RegisterProperty<int>(p => p.RegisterId, "Register Id");
        /// <summary>
        /// Gets the Register Id.
        /// </summary>
        /// <value>The Register Id.</value>
        public int RegisterId
        {
            get { return GetProperty(RegisterIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RegisterDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> RegisterDateProperty = RegisterProperty<SmartDate>(p => p.RegisterDate, "Register Date");
        /// <summary>
        /// Gets the Register Date.
        /// </summary>
        /// <value>The Register Date.</value>
        public string RegisterDate
        {
            get { return GetPropertyConvert<SmartDate, string>(RegisterDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentType"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentTypeProperty = RegisterProperty<string>(p => p.DocumentType, "Document Type");
        /// <summary>
        /// Gets the Document Type.
        /// </summary>
        /// <value>The Document Type.</value>
        public string DocumentType
        {
            get { return GetProperty(DocumentTypeProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentReference"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentReferenceProperty = RegisterProperty<string>(p => p.DocumentReference, "Document Reference");
        /// <summary>
        /// Gets the Document Reference.
        /// </summary>
        /// <value>The Document Reference.</value>
        public string DocumentReference
        {
            get { return GetProperty(DocumentReferenceProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentEntity"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentEntityProperty = RegisterProperty<string>(p => p.DocumentEntity, "Document Entity");
        /// <summary>
        /// Gets the Document Entity.
        /// </summary>
        /// <value>The Document Entity.</value>
        public string DocumentEntity
        {
            get { return GetProperty(DocumentEntityProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentDept"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentDeptProperty = RegisterProperty<string>(p => p.DocumentDept, "Document Dept");
        /// <summary>
        /// Gets the Document Dept.
        /// </summary>
        /// <value>The Document Dept.</value>
        public string DocumentDept
        {
            get { return GetProperty(DocumentDeptProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentClass"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentClassProperty = RegisterProperty<string>(p => p.DocumentClass, "Document Class");
        /// <summary>
        /// Gets the Document Class.
        /// </summary>
        /// <value>The Document Class.</value>
        public string DocumentClass
        {
            get { return GetProperty(DocumentClassProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> DocumentDateProperty = RegisterProperty<SmartDate>(p => p.DocumentDate, "Document Date");
        /// <summary>
        /// Gets the Document Date.
        /// </summary>
        /// <value>The Document Date.</value>
        public string DocumentDate
        {
            get { return GetPropertyConvert<SmartDate, string>(DocumentDateProperty); }
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
        /// Maintains metadata about <see cref="SenderName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SenderNameProperty = RegisterProperty<string>(p => p.SenderName, "Sender Name");
        /// <summary>
        /// Gets the Sender Name.
        /// </summary>
        /// <value>The Sender Name.</value>
        public string SenderName
        {
            get { return GetProperty(SenderNameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ReceptionDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> ReceptionDateProperty = RegisterProperty<SmartDate>(p => p.ReceptionDate, "Reception Date");
        /// <summary>
        /// Gets the Reception Date.
        /// </summary>
        /// <value>The Reception Date.</value>
        public string ReceptionDate
        {
            get { return GetPropertyConvert<SmartDate, string>(ReceptionDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RoutedTo"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> RoutedToProperty = RegisterProperty<string>(p => p.RoutedTo, "Routed To");
        /// <summary>
        /// Gets the Routed To.
        /// </summary>
        /// <value>The Routed To.</value>
        public string RoutedTo
        {
            get { return GetProperty(RoutedToProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Notes"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> NotesProperty = RegisterProperty<string>(p => p.Notes, "Notes");
        /// <summary>
        /// Gets the Notes.
        /// </summary>
        /// <value>The Notes.</value>
        public string Notes
        {
            get { return GetProperty(NotesProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ArchiveLocation"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ArchiveLocationProperty = RegisterProperty<string>(p => p.ArchiveLocation, "Archive Location");
        /// <summary>
        /// Gets the Archive Location.
        /// </summary>
        /// <value>The Archive Location.</value>
        public string ArchiveLocation
        {
            get { return GetProperty(ArchiveLocationProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="IncomingInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="IncomingInfo"/> object.</returns>
        internal static IncomingInfo GetIncomingInfo(SafeDataReader dr)
        {
            IncomingInfo obj = new IncomingInfo();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomingInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public IncomingInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="IncomingInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(RegisterIdProperty, dr.GetInt32("RegisterId"));
            LoadProperty(RegisterDateProperty, dr.GetSmartDate("RegisterDate", true));
            LoadProperty(DocumentTypeProperty, dr.GetString("DocumentType"));
            LoadProperty(DocumentReferenceProperty, dr.GetString("DocumentReference"));
            LoadProperty(DocumentEntityProperty, dr.GetString("DocumentEntity"));
            LoadProperty(DocumentDeptProperty, dr.GetString("DocumentDept"));
            LoadProperty(DocumentClassProperty, dr.GetString("DocumentClass"));
            LoadProperty(DocumentDateProperty, dr.GetSmartDate("DocumentDate", true));
            LoadProperty(SubjectProperty, dr.GetString("Subject"));
            LoadProperty(SenderNameProperty, dr.GetString("SenderName"));
            LoadProperty(ReceptionDateProperty, dr.GetSmartDate("ReceptionDate", true));
            LoadProperty(RoutedToProperty, dr.GetString("RoutedTo"));
            LoadProperty(NotesProperty, dr.GetString("Notes"));
            LoadProperty(ArchiveLocationProperty, dr.GetString("ArchiveLocation"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
