using System;
using Csla;
using Codisa.InterwayDocs.DataAccess;

namespace Codisa.InterwayDocs.Business
{

    /// <summary>
    /// DeliveryInfo (read only object).<br/>
    /// This is a generated <see cref="DeliveryInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="DeliveryBook"/> collection.
    /// </remarks>
    [Serializable]
    public partial class DeliveryInfo : ReadOnlyBase<DeliveryInfo>
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
        /// Maintains metadata about <see cref="ExpeditorName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ExpeditorNameProperty = RegisterProperty<string>(p => p.ExpeditorName, "Expeditor Name");
        /// <summary>
        /// Gets the Expeditor Name.
        /// </summary>
        /// <value>The Expeditor Name.</value>
        public string ExpeditorName
        {
            get { return GetProperty(ExpeditorNameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ReceptionName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ReceptionNameProperty = RegisterProperty<string>(p => p.ReceptionName, "Reception Name");
        /// <summary>
        /// Gets the Reception Name.
        /// </summary>
        /// <value>The Reception Name.</value>
        public string ReceptionName
        {
            get { return GetProperty(ReceptionNameProperty); }
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

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="DeliveryInfo"/> object from the given DeliveryInfoDto.
        /// </summary>
        /// <param name="data">The <see cref="DeliveryInfoDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="DeliveryInfo"/> object.</returns>
        internal static DeliveryInfo GetDeliveryInfo(DeliveryInfoDto data)
        {
            DeliveryInfo obj = new DeliveryInfo();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DeliveryInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DeliveryInfo"/> object from the given <see cref="DeliveryInfoDto"/>.
        /// </summary>
        /// <param name="data">The DeliveryInfoDto to use.</param>
        private void Fetch(DeliveryInfoDto data)
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
            LoadProperty(RecipientNameProperty, data.RecipientName);
            LoadProperty(ExpeditorNameProperty, data.ExpeditorName);
            LoadProperty(ReceptionNameProperty, data.ReceptionName);
            LoadProperty(ReceptionDateProperty, data.ReceptionDate);
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
