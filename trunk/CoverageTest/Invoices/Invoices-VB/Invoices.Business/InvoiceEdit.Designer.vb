Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceEdit (editable root object).<br/>
    ''' This is a generated base class of <see cref="InvoiceEdit"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class contains one child collection:<br/>
    ''' - <see cref="InvoiceLines"/> of type <see cref="InvoiceLineCollection"/> (1:M relation to <see cref="InvoiceLineItem"/>)
    ''' </remarks>
    <Serializable()>
    Public Partial Class InvoiceEdit
        Inherits BusinessBase(Of InvoiceEdit)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="InvoiceId"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly InvoiceIdProperty As PropertyInfo(Of Guid) = RegisterProperty(Of Guid)(Function(p) p.InvoiceId, "Invoice Id")
        ''' <summary>
        ''' The invoice internal identification
        ''' </summary>
        ''' <value>The Invoice Id.</value>
        Public Property InvoiceId As Guid
            Get
                Return GetProperty(InvoiceIdProperty)
            End Get
            Set(ByVal value As Guid)
                SetProperty(InvoiceIdProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="InvoiceNumber"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoiceNumberProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.InvoiceNumber, "Invoice Number")
        ''' <summary>
        ''' The public invoice number
        ''' </summary>
        ''' <value>The Invoice Number.</value>
        Public Property InvoiceNumber As String
            Get
                Return GetProperty(InvoiceNumberProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(InvoiceNumberProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CustomerId"/> property.
        ''' </summary>
        Public Shared ReadOnly CustomerIdProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.CustomerId, "Customer Id")
        ''' <summary>
        ''' Gets or sets the Customer Id.
        ''' </summary>
        ''' <value>The Customer Id.</value>
        Public Property CustomerId As String
            Get
                Return GetProperty(CustomerIdProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(CustomerIdProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="InvoiceDate"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoiceDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.InvoiceDate, "Invoice Date")
        ''' <summary>
        ''' Gets or sets the Invoice Date.
        ''' </summary>
        ''' <value>The Invoice Date.</value>
        Public Property InvoiceDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(InvoiceDateProperty)
            End Get
            Set(ByVal value As String)
                SetPropertyConvert(Of SmartDate, String)(InvoiceDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="TotalAmount"/> property.
        ''' </summary>
        Public Shared ReadOnly TotalAmountProperty As PropertyInfo(Of Decimal) = RegisterProperty(Of Decimal)(Function(p) p.TotalAmount, "Total Amount")
        ''' <summary>
        ''' Computed invoice total amount
        ''' </summary>
        ''' <value>The Total Amount.</value>
        Public Property TotalAmount As Decimal
            Get
                Return GetProperty(TotalAmountProperty)
            End Get
            Set(ByVal value As Decimal)
                SetProperty(TotalAmountProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateDate"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly CreateDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.CreateDate, "Create Date")
        ''' <summary>
        ''' Gets the Create Date.
        ''' </summary>
        ''' <value>The Create Date.</value>
        Public ReadOnly Property CreateDate As SmartDate
            Get
                Return GetProperty(CreateDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateUser"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly CreateUserProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.CreateUser, "Create User")
        ''' <summary>
        ''' Gets the Create User.
        ''' </summary>
        ''' <value>The Create User.</value>
        Public ReadOnly Property CreateUser As Integer
            Get
                Return GetProperty(CreateUserProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeDate"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly ChangeDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.ChangeDate, "Change Date")
        ''' <summary>
        ''' Gets the Change Date.
        ''' </summary>
        ''' <value>The Change Date.</value>
        Public ReadOnly Property ChangeDate As SmartDate
            Get
                Return GetProperty(ChangeDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeUser"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly ChangeUserProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.ChangeUser, "Change User")
        ''' <summary>
        ''' Gets the Change User.
        ''' </summary>
        ''' <value>The Change User.</value>
        Public ReadOnly Property ChangeUser As Integer
            Get
                Return GetProperty(ChangeUserProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RowVersion"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly RowVersionProperty As PropertyInfo(Of Byte()) = RegisterProperty(Of Byte())(Function(p) p.RowVersion, "Row Version")
        ''' <summary>
        ''' Gets the Row Version.
        ''' </summary>
        ''' <value>The Row Version.</value>
        Public ReadOnly Property RowVersion As Byte()
            Get
                Return GetProperty(RowVersionProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="InvoiceLines"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoiceLinesProperty As PropertyInfo(Of InvoiceLineCollection) = RegisterProperty(Of InvoiceLineCollection)(Function(p) p.InvoiceLines, "Invoice Lines", RelationshipTypes.Child)
        ''' <summary>
        ''' Gets the Invoice Lines ("parent load" child property).
        ''' </summary>
        ''' <value>The Invoice Lines.</value>
        Public Property InvoiceLines As InvoiceLineCollection
            Get
                Return GetProperty(InvoiceLinesProperty)
            End Get
            Private Set(ByVal value As InvoiceLineCollection)
                LoadProperty(InvoiceLinesProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="InvoiceEdit"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="InvoiceEdit"/> object.</returns>
        Public Shared Function NewInvoiceEdit() As InvoiceEdit
            Return DataPortal.Create(Of InvoiceEdit)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="InvoiceEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId parameter of the InvoiceEdit to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="InvoiceEdit"/> object.</returns>
        Public Shared Function GetInvoiceEdit(invoiceId As Guid) As InvoiceEdit
            Return DataPortal.Fetch(Of InvoiceEdit)(invoiceId)
        End Function

        ''' <summary>
        ''' Factory method. Deletes a <see cref="InvoiceEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId of the InvoiceEdit to delete.</param>
        Public Shared Sub DeleteInvoiceEdit(invoiceId As Guid)
            DataPortal.Delete(Of InvoiceEdit)(invoiceId)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="InvoiceEdit"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewInvoiceEdit(callback As EventHandler(Of DataPortalResult(Of InvoiceEdit)))
            DataPortal.BeginCreate(Of InvoiceEdit)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="InvoiceEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId parameter of the InvoiceEdit to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetInvoiceEdit(invoiceId As Guid, ByVal callback As EventHandler(Of DataPortalResult(Of InvoiceEdit)))
            DataPortal.BeginFetch(Of InvoiceEdit)(invoiceId, callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously deletes a <see cref="InvoiceEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId of the InvoiceEdit to delete.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub DeleteInvoiceEdit(invoiceId As Guid, callback As EventHandler(Of DataPortalResult(Of InvoiceEdit)))
            DataPortal.BeginDelete(Of InvoiceEdit)(invoiceId, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceEdit"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="InvoiceEdit"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(InvoiceIdProperty, Guid.NewGuid())
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now))
            LoadProperty(CreateUserProperty, Security.UserInformation.UserId)
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty))
            LoadProperty(ChangeUserProperty, ReadProperty(CreateUserProperty))
            LoadProperty(InvoiceLinesProperty, DataPortal.CreateChild(Of InvoiceLineCollection)())
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="InvoiceEdit"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="invoiceId">The Invoice Id.</param>
        Protected Sub DataPortal_Fetch(invoiceId As Guid)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.GetInvoiceEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid
                    Dim args As New DataPortalHookArgs(cmd, invoiceId)
                    OnFetchPre(args)
                    Fetch(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        Private Sub Fetch(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                If dr.Read() Then
                    Fetch(dr)
                    FetchChildren(dr)
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Loads a <see cref="InvoiceEdit"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(InvoiceIdProperty, dr.GetGuid("InvoiceId"))
            LoadProperty(InvoiceNumberProperty, dr.GetString("InvoiceNumber"))
            LoadProperty(CustomerIdProperty, dr.GetString("CustomerId"))
            LoadProperty(InvoiceDateProperty, dr.GetSmartDate("InvoiceDate", True))
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", True))
            LoadProperty(CreateUserProperty, dr.GetInt32("CreateUser"))
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", True))
            LoadProperty(ChangeUserProperty, dr.GetInt32("ChangeUser"))
            LoadProperty(RowVersionProperty, TryCast(dr.GetValue("RowVersion"), Byte()))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Loads child objects from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub FetchChildren(dr As SafeDataReader)
            dr.NextResult()
            LoadProperty(InvoiceLinesProperty, DataPortal.FetchChild(Of InvoiceLineCollection)(dr))
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="InvoiceEdit"/> object in the database.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Overrides Sub DataPortal_Insert()
            SimpleAuditTrail()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.AddInvoiceEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@InvoiceId", ReadProperty(InvoiceIdProperty)).DbType = DbType.Guid
                    cmd.Parameters.AddWithValue("@InvoiceNumber", ReadProperty(InvoiceNumberProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@CustomerId", ReadProperty(CustomerIdProperty)).DbType = DbType.StringFixedLength
                    cmd.Parameters.AddWithValue("@InvoiceDate", ReadProperty(InvoiceDateProperty).DBValue).DbType = DbType.Date
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@CreateUser", ReadProperty(CreateUserProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUser", ReadProperty(ChangeUserProperty)).DbType = DbType.Int32
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="InvoiceEdit"/> object.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Overrides Sub DataPortal_Update()
            SimpleAuditTrail()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.UpdateInvoiceEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@InvoiceId", ReadProperty(InvoiceIdProperty)).DbType = DbType.Guid
                    cmd.Parameters.AddWithValue("@InvoiceNumber", ReadProperty(InvoiceNumberProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@CustomerId", ReadProperty(CustomerIdProperty)).DbType = DbType.StringFixedLength
                    cmd.Parameters.AddWithValue("@InvoiceDate", ReadProperty(InvoiceDateProperty).DBValue).DbType = DbType.Date
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUser", ReadProperty(ChangeUserProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
            End Using
        End Sub

        Private Sub SimpleAuditTrail()
            LoadProperty(ChangeDateProperty, Date.Now)
            LoadProperty(ChangeUserProperty, Security.UserInformation.UserId)
            If IsNew Then
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty))
                LoadProperty(CreateUserProperty, ReadProperty(ChangeUserProperty))
            End If
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="InvoiceEdit"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(InvoiceId)
        End Sub

        ''' <summary>
        ''' Deletes the <see cref="InvoiceEdit"/> object from database.
        ''' </summary>
        ''' <param name="invoiceId">The delete criteria.</param>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Sub DataPortal_Delete(invoiceId As Guid)
            ' audit the object, just in case soft delete is used on this object
            SimpleAuditTrail()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
                Using cmd = New SqlCommand("dbo.DeleteInvoiceEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid
                    Dim args As New DataPortalHookArgs(cmd, invoiceId)
                    OnDeletePre(args)
                    cmd.ExecuteNonQuery()
                    OnDeletePost(args)
                End Using
            End Using
            ' removes all previous references to children
            LoadProperty(InvoiceLinesProperty, DataPortal.CreateChild(Of InvoiceLineCollection)())
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting all defaults for object creation.
        ''' </summary>
        Partial Private Sub OnCreate(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        ''' </summary>
        Partial Private Sub OnDeletePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after the delete operation, before Commit().
        ''' </summary>
        Partial Private Sub OnDeletePost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after setting query parameters and before the fetch operation.
        ''' </summary>
        Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the fetch operation (object or collection is fully loaded and set up).
        ''' </summary>
        Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the low level fetch operation, before the data reader is destroyed.
        ''' </summary>
        Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after setting query parameters and before the update operation.
        ''' </summary>
        Partial Private Sub OnUpdatePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnUpdatePost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        ''' </summary>
        Partial Private Sub OnInsertPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnInsertPost(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class

End Namespace
