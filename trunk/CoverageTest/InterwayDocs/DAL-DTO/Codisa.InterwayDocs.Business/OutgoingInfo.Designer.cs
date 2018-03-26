using System;
using Csla;
using Codisa.InterwayDocs.DataAccess;

namespace Codisa.InterwayDocs.Business
{

    /// <summary>
    /// OutgoingInfo (read only object).<br/>
    /// This is a generated <see cref="OutgoingInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="OutgoingBook"/> collection.
    /// </remarks>
    [Serializable]
    public partial class OutgoingInfo : ReadOnlyBase<OutgoingInfo>
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
        /// Maintains metadata about <see cref="SendDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> SendDateProperty = RegisterProperty<SmartDate>(p => p.SendDate, "Send Date");
        /// <summary>
        /// Gets the Send Date.
        /// </summary>
        /// <value>The Send Date.</value>
        public string SendDate
        {
            get { return GetPropertyConvert<SmartDate, string>(SendDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RecipientName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> RecipientNameProperty = RegisterProperty<string>(p => p.RecipientName, "Recipient Name");
        /// <summary>
        /// Gets the Recipient Name.
        /// </summary>
        /// <value>The Recipient Name.</value>
        public string RecipientName
        {
            get { return GetProperty(RecipientNameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RecipientTown"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> RecipientTownProperty = RegisterProperty<string>(p => p.RecipientTown, "Recipient Town");
        /// <summary>
        /// Gets the Recipient Town.
        /// </summary>
        /// <value>The Recipient Town.</value>
        public string RecipientTown
        {
            get { return GetProperty(RecipientTownProperty); }
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
        /// Factory method. Loads a <see cref="OutgoingInfo"/> object from the given OutgoingInfoDto.
        /// </summary>
        /// <param name="data">The <see cref="OutgoingInfoDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="OutgoingInfo"/> object.</returns>
        internal static OutgoingInfo GetOutgoingInfo(OutgoingInfoDto data)
        {
            OutgoingInfo obj = new OutgoingInfo();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OutgoingInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public OutgoingInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="OutgoingInfo"/> object from the given <see cref="OutgoingInfoDto"/>.
        /// </summary>
        /// <param name="data">The OutgoingInfoDto to use.</param>
        private void Fetch(OutgoingInfoDto data)
        {
            // Value properties
            LoadProperty(RegisterIdProperty, data.RegisterId);
            LoadProperty(RegisterDateProperty, data.RegisterDate);
            LoadProperty(DocumentTypeProperty, data.DocumentType);
            LoadProperty(DocumentReferenceProperty, data.DocumentReference);
            LoadProperty(DocumentEntityProperty, data.DocumentEntity);
            LoadProperty(DocumentDeptProperty, data.DocumentDept);
            LoadProperty(DocumentClassProperty, data.DocumentClass);
            LoadProperty(DocumentDateProperty, data.DocumentDate);
            LoadProperty(SubjectProperty, data.Subject);
            LoadProperty(SendDateProperty, data.SendDate);
            LoadProperty(RecipientNameProperty, data.RecipientName);
            LoadProperty(RecipientTownProperty, data.RecipientTown);
            LoadProperty(NotesProperty, data.Notes);
            LoadProperty(ArchiveLocationProperty, data.ArchiveLocation);
            var args = new DataPortalHookArgs(data);
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
