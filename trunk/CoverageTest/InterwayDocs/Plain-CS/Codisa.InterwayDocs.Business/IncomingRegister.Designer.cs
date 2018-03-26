using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Codisa.InterwayDocs.Business.Properties;
using Codisa.InterwayDocs.Rules;
using Csla.Rules;

namespace Codisa.InterwayDocs.Business
{

    /// <summary>
    /// IncomingRegister (editable root object).<br/>
    /// This is a generated <see cref="IncomingRegister"/> business object.
    /// </summary>
    [Serializable]
    public partial class IncomingRegister : EditOnDemandBase<IncomingRegister>, IHaveAudit
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
        /// Maintains metadata about <see cref="SenderName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SenderNameProperty = RegisterProperty<string>(p => p.SenderName, "Proveniência");
        /// <summary>
        /// Gets or sets the Proveniência.
        /// </summary>
        /// <value>The Proveniência.</value>
        public string SenderName
        {
            get { return GetProperty(SenderNameProperty); }
            set { SetProperty(SenderNameProperty, value); }
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
        /// Maintains metadata about <see cref="RoutedTo"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> RoutedToProperty = RegisterProperty<string>(p => p.RoutedTo, "Encaminhamento");
        /// <summary>
        /// Gets or sets the Encaminhamento.
        /// </summary>
        /// <value>The Encaminhamento.</value>
        public string RoutedTo
        {
            get { return GetProperty(RoutedToProperty); }
            set { SetProperty(RoutedToProperty, value); }
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
        /// Factory method. Creates a new <see cref="IncomingRegister"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="IncomingRegister"/> object.</returns>
        public static IncomingRegister NewIncomingRegister()
        {
            return DataPortal.Create<IncomingRegister>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="IncomingRegister"/> object, based on given parameters.
        /// </summary>
        /// <param name="registerId">The RegisterId parameter of the IncomingRegister to fetch.</param>
        /// <returns>A reference to the fetched <see cref="IncomingRegister"/> object.</returns>
        public static IncomingRegister GetIncomingRegister(int registerId)
        {
            return DataPortal.Fetch<IncomingRegister>(registerId);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomingRegister"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public IncomingRegister()
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
            BusinessRules.AddRule(new CollapseWhiteSpace(DocumentDeptProperty) { Priority = 1 });
            // DocumentClass
            BusinessRules.AddRule(new ClassificationFormat(DocumentClassProperty) { Priority = 1 });
            // DocumentDate
            BusinessRules.AddRule(new DateNotInFuture(DocumentDateProperty) { MessageDelegate = () => Resources.DateNotInFuture, Priority = 1 });
            // Subject
            BusinessRules.AddRule(new CollapseSpace(SubjectProperty) { Priority = 1 });
            // SenderName
            BusinessRules.AddRule(new CollapseWhiteSpace(SenderNameProperty) { Priority = 1 });
            // ReceptionDate
            BusinessRules.AddRule(new DateNotInFuture(ReceptionDateProperty) { MessageDelegate = () => Resources.DateNotInFuture, Priority = 1 });
            // RoutedTo
            BusinessRules.AddRule(new CollapseWhiteSpace(RoutedToProperty) { Priority = 1 });
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
        /// Loads default values for the <see cref="IncomingRegister"/> object properties.
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
            LoadProperty(SenderNameProperty, string.Empty);
            LoadProperty(RoutedToProperty, string.Empty);
            LoadProperty(NotesProperty, string.Empty);
            LoadProperty(ArchiveLocationProperty, string.Empty);
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="IncomingRegister"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        protected void DataPortal_Fetch(int registerId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.InterwayDocsConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.GetIncomingRegister", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", registerId).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, registerId);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="IncomingRegister"/> object from the given SafeDataReader.
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
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="IncomingRegister"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.InterwayDocsConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.AddIncomingRegister", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", ReadProperty(RegisterIdProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@RegisterDate", ReadProperty(RegisterDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", ReadProperty(DocumentTypeProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", ReadProperty(DocumentReferenceProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", ReadProperty(DocumentEntityProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", ReadProperty(DocumentDeptProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", ReadProperty(DocumentClassProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", ReadProperty(DocumentDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SenderName", ReadProperty(SenderNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionDate", ReadProperty(ReceptionDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RoutedTo", ReadProperty(RoutedToProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Notes", ReadProperty(NotesProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ArchiveLocation", ReadProperty(ArchiveLocationProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(RegisterIdProperty, (int) cmd.Parameters["@RegisterId"].Value);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="IncomingRegister"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.InterwayDocsConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.UpdateIncomingRegister", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisterId", ReadProperty(RegisterIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RegisterDate", ReadProperty(RegisterDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@DocumentType", ReadProperty(DocumentTypeProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentReference", ReadProperty(DocumentReferenceProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentEntity", ReadProperty(DocumentEntityProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDept", ReadProperty(DocumentDeptProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentClass", ReadProperty(DocumentClassProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", ReadProperty(DocumentDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SenderName", ReadProperty(SenderNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ReceptionDate", ReadProperty(ReceptionDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@RoutedTo", ReadProperty(RoutedToProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Notes", ReadProperty(NotesProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ArchiveLocation", ReadProperty(ArchiveLocationProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                ctx.Commit();
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
