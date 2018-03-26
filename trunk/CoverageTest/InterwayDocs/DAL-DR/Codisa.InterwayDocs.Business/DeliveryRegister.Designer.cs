using System;
using System.Data;
using Csla;
using Csla.Data;
using Codisa.InterwayDocs.Business.Properties;
using Codisa.InterwayDocs.Rules;
using Csla.Rules;
using Codisa.InterwayDocs.DataAccess;

namespace Codisa.InterwayDocs.Business
{

    /// <summary>
    /// DeliveryRegister (editable root object).<br/>
    /// This is a generated <see cref="DeliveryRegister"/> business object.
    /// </summary>
    [Serializable]
    public partial class DeliveryRegister : EditOnDemandBase<DeliveryRegister>, IHaveAudit
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="RegisterId"/> property.
        /// </summary>
        [NotUndoable]
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
        public static readonly PropertyInfo<SmartDate> RegisterDateProperty = RegisterProperty<SmartDate>(p => p.RegisterDate, "Data de registo");
        /// <summary>
        /// Gets or sets the Data de registo.
        /// </summary>
        /// <value>The Data de registo.</value>
        public string RegisterDate
        {
            get { return GetPropertyConvert<SmartDate, string>(RegisterDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(RegisterDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentType"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentTypeProperty = RegisterProperty<string>(p => p.DocumentType, "Tipo");
        /// <summary>
        /// Gets or sets the Tipo.
        /// </summary>
        /// <value>The Tipo.</value>
        public string DocumentType
        {
            get { return GetProperty(DocumentTypeProperty); }
            set { SetProperty(DocumentTypeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentReference"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentReferenceProperty = RegisterProperty<string>(p => p.DocumentReference, "Número");
        /// <summary>
        /// Gets or sets the Número.
        /// </summary>
        /// <value>The Número.</value>
        public string DocumentReference
        {
            get { return GetProperty(DocumentReferenceProperty); }
            set { SetProperty(DocumentReferenceProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentEntity"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentEntityProperty = RegisterProperty<string>(p => p.DocumentEntity, "Entidade");
        /// <summary>
        /// Gets or sets the Entidade.
        /// </summary>
        /// <value>The Entidade.</value>
        public string DocumentEntity
        {
            get { return GetProperty(DocumentEntityProperty); }
            set { SetProperty(DocumentEntityProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentDept"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentDeptProperty = RegisterProperty<string>(p => p.DocumentDept, "Departamento");
        /// <summary>
        /// Gets or sets the Departamento.
        /// </summary>
        /// <value>The Departamento.</value>
        public string DocumentDept
        {
            get { return GetProperty(DocumentDeptProperty); }
            set { SetProperty(DocumentDeptProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentClass"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentClassProperty = RegisterProperty<string>(p => p.DocumentClass, "Classificação");
        /// <summary>
        /// Gets or sets the Classificação.
        /// </summary>
        /// <value>The Classificação.</value>
        public string DocumentClass
        {
            get { return GetProperty(DocumentClassProperty); }
            set { SetProperty(DocumentClassProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> DocumentDateProperty = RegisterProperty<SmartDate>(p => p.DocumentDate, "Data do documento");
        /// <summary>
        /// Gets or sets the Data do documento.
        /// </summary>
        /// <value>The Data do documento.</value>
        public string DocumentDate
        {
            get { return GetPropertyConvert<SmartDate, string>(DocumentDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(DocumentDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RecipientName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> RecipientNameProperty = RegisterProperty<string>(p => p.RecipientName, "Destinatário");
        /// <summary>
        /// Gets or sets the Destinatário.
        /// </summary>
        /// <value>The Destinatário.</value>
        public string RecipientName
        {
            get { return GetProperty(RecipientNameProperty); }
            set { SetProperty(RecipientNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ExpeditorName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ExpeditorNameProperty = RegisterProperty<string>(p => p.ExpeditorName, "Nome de quem expediu");
        /// <summary>
        /// Gets or sets the Nome de quem expediu.
        /// </summary>
        /// <value>The Nome de quem expediu.</value>
        public string ExpeditorName
        {
            get { return GetProperty(ExpeditorNameProperty); }
            set { SetProperty(ExpeditorNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ReceptionName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ReceptionNameProperty = RegisterProperty<string>(p => p.ReceptionName, "Nome de quem recebeu");
        /// <summary>
        /// Gets or sets the Nome de quem recebeu.
        /// </summary>
        /// <value>The Nome de quem recebeu.</value>
        public string ReceptionName
        {
            get { return GetProperty(ReceptionNameProperty); }
            set { SetProperty(ReceptionNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ReceptionDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> ReceptionDateProperty = RegisterProperty<SmartDate>(p => p.ReceptionDate, "Data de recepção");
        /// <summary>
        /// Gets or sets the Data de recepção.
        /// </summary>
        /// <value>The Data de recepção.</value>
        public string ReceptionDate
        {
            get { return GetPropertyConvert<SmartDate, string>(ReceptionDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(ReceptionDateProperty, value); }
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

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DeliveryRegister"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="DeliveryRegister"/> object.</returns>
        public static DeliveryRegister NewDeliveryRegister()
        {
            return DataPortal.Create<DeliveryRegister>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DeliveryRegister"/> object, based on given parameters.
        /// </summary>
        /// <param name="registerId">The RegisterId parameter of the DeliveryRegister to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DeliveryRegister"/> object.</returns>
        public static DeliveryRegister GetDeliveryRegister(int registerId)
        {
            return DataPortal.Fetch<DeliveryRegister>(registerId);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryRegister"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DeliveryRegister()
        {
            // Use factory methods and do not use direct creation.
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

            // RegisterDate
            BusinessRules.AddRule(new DateNotInFuture(RegisterDateProperty) { MessageDelegate = () => Resources.DateNotInFuture, Priority = 1 });
            // DocumentType
            BusinessRules.AddRule(new CollapseWhiteSpace(DocumentTypeProperty) { Priority = 1 });
            // DocumentReference
            BusinessRules.AddRule(new CollapseWhiteSpace(DocumentReferenceProperty) { Priority = 1 });
            // DocumentEntity
            BusinessRules.AddRule(new CollapseWhiteSpace(DocumentEntityProperty) { Priority = 1 });
            // DocumentDept
            BusinessRules.AddRule(new CollapseWhiteSpace(DocumentDeptProperty));
            // DocumentClass
            BusinessRules.AddRule(new ClassificationFormat(DocumentClassProperty) { Priority = 1 });
            // DocumentDate
            BusinessRules.AddRule(new DateNotInFuture(DocumentDateProperty) { MessageDelegate = () => Resources.DateNotInFuture, Priority = 1 });
            // RecipientName
            BusinessRules.AddRule(new CollapseWhiteSpace(RecipientNameProperty) { Priority = 1 });
            // ExpeditorName
            BusinessRules.AddRule(new CollapseWhiteSpace(ExpeditorNameProperty) { Priority = 1 });
            // ReceptionName
            BusinessRules.AddRule(new CollapseWhiteSpace(ReceptionNameProperty) { Priority = 1 });
            // ReceptionDate
            BusinessRules.AddRule(new DateNotInFuture(ReceptionDateProperty) { Severity = RuleSeverity.Information, MessageDelegate = () => Resources.DateNotInFuture, Priority = 1 });

            AddBusinessRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom shared business rules.
        /// </summary>
        partial void AddBusinessRulesExtend();

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="DeliveryRegister"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(RegisterIdProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            LoadProperty(RegisterDateProperty, new SmartDate(DateTime.Today));
            LoadProperty(DocumentTypeProperty, string.Empty);
            LoadProperty(DocumentReferenceProperty, string.Empty);
            LoadProperty(DocumentEntityProperty, string.Empty);
            LoadProperty(DocumentDeptProperty, string.Empty);
            LoadProperty(DocumentClassProperty, string.Empty);
            LoadProperty(RecipientNameProperty, string.Empty);
            LoadProperty(ExpeditorNameProperty, string.Empty);
            LoadProperty(ReceptionNameProperty, string.Empty);
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="DeliveryRegister"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        protected void DataPortal_Fetch(int registerId)
        {
            var args = new DataPortalHookArgs(registerId);
            OnFetchPre(args);
            using (var dalManager = DalFactoryGetManager())
            {
                var dal = dalManager.GetProvider<IDeliveryRegisterDal>();
                var data = dal.Fetch(registerId);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        private void Fetch(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="DeliveryRegister"/> object from the given SafeDataReader.
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
            LoadProperty(RecipientNameProperty, dr.GetString("RecipientName"));
            LoadProperty(ExpeditorNameProperty, dr.GetString("ExpeditorName"));
            LoadProperty(ReceptionNameProperty, dr.GetString("ReceptionName"));
            LoadProperty(ReceptionDateProperty, dr.GetSmartDate("ReceptionDate", true));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="DeliveryRegister"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var dalManager = DalFactoryGetManager())
            {
                var args = new DataPortalHookArgs();
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IDeliveryRegisterDal>();
                using (BypassPropertyChecks)
                {
                    int registerId = -1;
                    dal.Insert(
                        out registerId,
                        ReadProperty(RegisterDateProperty),
                        DocumentType,
                        DocumentReference,
                        DocumentEntity,
                        DocumentDept,
                        DocumentClass,
                        ReadProperty(DocumentDateProperty),
                        RecipientName,
                        ExpeditorName,
                        ReceptionName,
                        ReadProperty(ReceptionDateProperty),
                        CreateDate,
                        ChangeDate
                        );
                    LoadProperty(RegisterIdProperty, registerId);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DeliveryRegister"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var dalManager = DalFactoryGetManager())
            {
                var args = new DataPortalHookArgs();
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IDeliveryRegisterDal>();
                using (BypassPropertyChecks)
                {
                    dal.Update(
                        RegisterId,
                        ReadProperty(RegisterDateProperty),
                        DocumentType,
                        DocumentReference,
                        DocumentEntity,
                        DocumentDept,
                        DocumentClass,
                        ReadProperty(DocumentDateProperty),
                        RecipientName,
                        ExpeditorName,
                        ReceptionName,
                        ReadProperty(ReceptionDateProperty),
                        ChangeDate
                        );
                }
                OnUpdatePost(args);
            }
        }

        private void SimpleAuditTrail()
        {
            LoadProperty(ChangeDateProperty, DateTime.Now);
            if (IsNew)
            {
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty));
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
