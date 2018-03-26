using System;
using Csla;
using Codisa.InterwayDocs.Business.Properties;
using Codisa.InterwayDocs.Rules;
using Csla.Rules;
using Codisa.InterwayDocs.DataAccess;

namespace Codisa.InterwayDocs.Business
{

    /// <summary>
    /// OutgoingRegister (editable root object).<br/>
    /// This is a generated <see cref="OutgoingRegister"/> business object.
    /// </summary>
    [Serializable]
    public partial class OutgoingRegister : EditOnDemandBase<OutgoingRegister>, IHaveAudit
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
        public static readonly PropertyInfo<string> DocumentClassProperty = RegisterProperty<string>(p => p.DocumentClass, "Document Class");
        /// <summary>
        /// Gets or sets the Document Class.
        /// </summary>
        /// <value>The Document Class.</value>
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
        /// Maintains metadata about <see cref="Subject"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubjectProperty = RegisterProperty<string>(p => p.Subject, "Assunto");
        /// <summary>
        /// Gets or sets the Assunto.
        /// </summary>
        /// <value>The Assunto.</value>
        public string Subject
        {
            get { return GetProperty(SubjectProperty); }
            set { SetProperty(SubjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SendDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> SendDateProperty = RegisterProperty<SmartDate>(p => p.SendDate, "Data de expedição");
        /// <summary>
        /// Gets or sets the Data de expedição.
        /// </summary>
        /// <value>The Data de expedição.</value>
        public string SendDate
        {
            get { return GetPropertyConvert<SmartDate, string>(SendDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(SendDateProperty, value); }
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
        /// Maintains metadata about <see cref="RecipientTown"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> RecipientTownProperty = RegisterProperty<string>(p => p.RecipientTown, "Localidade do destinatário");
        /// <summary>
        /// Gets or sets the Localidade do destinatário.
        /// </summary>
        /// <value>The Localidade do destinatário.</value>
        public string RecipientTown
        {
            get { return GetProperty(RecipientTownProperty); }
            set { SetProperty(RecipientTownProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Notes"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> NotesProperty = RegisterProperty<string>(p => p.Notes, "Observações");
        /// <summary>
        /// Gets or sets the Observações.
        /// </summary>
        /// <value>The Observações.</value>
        public string Notes
        {
            get { return GetProperty(NotesProperty); }
            set { SetProperty(NotesProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ArchiveLocation"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ArchiveLocationProperty = RegisterProperty<string>(p => p.ArchiveLocation, "Localização");
        /// <summary>
        /// Gets or sets the Localização.
        /// </summary>
        /// <value>The Localização.</value>
        public string ArchiveLocation
        {
            get { return GetProperty(ArchiveLocationProperty); }
            set { SetProperty(ArchiveLocationProperty, value); }
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
        /// Factory method. Creates a new <see cref="OutgoingRegister"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="OutgoingRegister"/> object.</returns>
        public static OutgoingRegister NewOutgoingRegister()
        {
            return DataPortal.Create<OutgoingRegister>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="OutgoingRegister"/> object, based on given parameters.
        /// </summary>
        /// <param name="registerId">The RegisterId parameter of the OutgoingRegister to fetch.</param>
        /// <returns>A reference to the fetched <see cref="OutgoingRegister"/> object.</returns>
        public static OutgoingRegister GetOutgoingRegister(int registerId)
        {
            return DataPortal.Fetch<OutgoingRegister>(registerId);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OutgoingRegister"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public OutgoingRegister()
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
            // Subject
            BusinessRules.AddRule(new CollapseSpace(SubjectProperty) { Priority = 1 });
            // SendDate
            BusinessRules.AddRule(new DateNotInFuture(SendDateProperty) { MessageDelegate = () => Resources.DateNotInFuture, Priority = 1 });
            // RecipientName
            BusinessRules.AddRule(new CollapseWhiteSpace(RecipientNameProperty) { Priority = 1 });
            // RecipientTown
            BusinessRules.AddRule(new CollapseWhiteSpace(RecipientTownProperty) { Priority = 1 });
            // Notes
            BusinessRules.AddRule(new CollapseSpace(NotesProperty));
            // ArchiveLocation
            BusinessRules.AddRule(new CollapseWhiteSpace(ArchiveLocationProperty));

            AddBusinessRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom shared business rules.
        /// </summary>
        partial void AddBusinessRulesExtend();

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="OutgoingRegister"/> object properties.
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
            LoadProperty(SubjectProperty, string.Empty);
            LoadProperty(RecipientNameProperty, string.Empty);
            LoadProperty(RecipientTownProperty, string.Empty);
            LoadProperty(NotesProperty, string.Empty);
            LoadProperty(ArchiveLocationProperty, string.Empty);
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="OutgoingRegister"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        protected void DataPortal_Fetch(int registerId)
        {
            var args = new DataPortalHookArgs(registerId);
            OnFetchPre(args);
            using (var dalManager = DalFactoryGetManager())
            {
                var dal = dalManager.GetProvider<IOutgoingRegisterDal>();
                var data = dal.Fetch(registerId);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads a <see cref="OutgoingRegister"/> object from the given <see cref="OutgoingRegisterDto"/>.
        /// </summary>
        /// <param name="data">The OutgoingRegisterDto to use.</param>
        private void Fetch(OutgoingRegisterDto data)
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
            LoadProperty(CreateDateProperty, data.CreateDate);
            LoadProperty(ChangeDateProperty, data.ChangeDate);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="OutgoingRegister"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            var dto = new OutgoingRegisterDto();
            dto.RegisterDate = ReadProperty(RegisterDateProperty);
            dto.DocumentType = DocumentType;
            dto.DocumentReference = DocumentReference;
            dto.DocumentEntity = DocumentEntity;
            dto.DocumentDept = DocumentDept;
            dto.DocumentClass = DocumentClass;
            dto.DocumentDate = ReadProperty(DocumentDateProperty);
            dto.Subject = Subject;
            dto.SendDate = ReadProperty(SendDateProperty);
            dto.RecipientName = RecipientName;
            dto.RecipientTown = RecipientTown;
            dto.Notes = Notes;
            dto.ArchiveLocation = ArchiveLocation;
            dto.CreateDate = CreateDate;
            dto.ChangeDate = ChangeDate;
            using (var dalManager = DalFactoryGetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IOutgoingRegisterDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(RegisterIdProperty, resultDto.RegisterId);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="OutgoingRegister"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            var dto = new OutgoingRegisterDto();
            dto.RegisterId = RegisterId;
            dto.RegisterDate = ReadProperty(RegisterDateProperty);
            dto.DocumentType = DocumentType;
            dto.DocumentReference = DocumentReference;
            dto.DocumentEntity = DocumentEntity;
            dto.DocumentDept = DocumentDept;
            dto.DocumentClass = DocumentClass;
            dto.DocumentDate = ReadProperty(DocumentDateProperty);
            dto.Subject = Subject;
            dto.SendDate = ReadProperty(SendDateProperty);
            dto.RecipientName = RecipientName;
            dto.RecipientTown = RecipientTown;
            dto.Notes = Notes;
            dto.ArchiveLocation = ArchiveLocation;
            dto.ChangeDate = ChangeDate;
            using (var dalManager = DalFactoryGetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IOutgoingRegisterDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
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
