Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceView (read only object).<br/>
    ''' This is a generated base class of <see cref="InvoiceView"/> business object.
    ''' This class is a root object.
    ''' </summary>
    ''' <remarks>
    ''' This class contains one child collection:<br/>
    ''' - <see cref="InvoiceLines"/> of type <see cref="InvoiceLineList"/> (1:M relation to <see cref="InvoiceLineInfo"/>)
    ''' </remarks>
    <Serializable()>
    Public Partial Class InvoiceView
        Inherits ReadOnlyBase(Of InvoiceView)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="InvoiceId"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoiceIdProperty As PropertyInfo(Of Guid) = RegisterProperty(Of Guid)(Function(p) p.InvoiceId, "Invoice Id", Guid.NewGuid())
        ''' <summary>
        ''' The invoice internal identification
        ''' </summary>
        ''' <value>The Invoice Id.</value>
        Public ReadOnly Property InvoiceId As Guid
            Get
                Return GetProperty(InvoiceIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="InvoiceNumber"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoiceNumberProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.InvoiceNumber, "Invoice Number")
        ''' <summary>
        ''' The public invoice number
        ''' </summary>
        ''' <value>The Invoice Number.</value>
        Public ReadOnly Property InvoiceNumber As String
            Get
                Return GetProperty(InvoiceNumberProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CustomerId"/> property.
        ''' </summary>
        Public Shared ReadOnly CustomerIdProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.CustomerId, "Customer Id")
        ''' <summary>
        ''' Gets the Customer Id.
        ''' </summary>
        ''' <value>The Customer Id.</value>
        Public ReadOnly Property CustomerId As String
            Get
                Return GetProperty(CustomerIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="InvoiceDate"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoiceDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.InvoiceDate, "Invoice Date")
        ''' <summary>
        ''' Gets the Invoice Date.
        ''' </summary>
        ''' <value>The Invoice Date.</value>
        Public ReadOnly Property InvoiceDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(InvoiceDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="TotalAmount"/> property.
        ''' </summary>
        Public Shared ReadOnly TotalAmountProperty As PropertyInfo(Of Decimal) = RegisterProperty(Of Decimal)(Function(p) p.TotalAmount, "Total Amount")
        ''' <summary>
        ''' Computed invoice total amount
        ''' </summary>
        ''' <value>The Total Amount.</value>
        Public ReadOnly Property TotalAmount As Decimal
            Get
                Return GetProperty(TotalAmountProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="IsActive"/> property.
        ''' </summary>
        Public Shared ReadOnly IsActiveProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.IsActive, "Is Active")
        ''' <summary>
        ''' Gets the Is Active.
        ''' </summary>
        ''' <value><c>True</c> if Is Active; otherwise, <c>false</c>.</value>
        Public ReadOnly Property IsActive As Boolean
            Get
                Return GetProperty(IsActiveProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateDate"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.CreateDate, "Create Date", new SmartDate(DateTime.Now))
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
        Public Shared ReadOnly CreateUserProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.CreateUser, "Create User", Security.UserInformation.UserId)
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
        Public Shared ReadOnly InvoiceLinesProperty As PropertyInfo(Of InvoiceLineList) = RegisterProperty(Of InvoiceLineList)(Function(p) p.InvoiceLines, "Invoice Lines")
        ''' <summary>
        ''' Gets the Invoice Lines ("parent load" child property).
        ''' </summary>
        ''' <value>The Invoice Lines.</value>
        Public Property InvoiceLines As InvoiceLineList
            Get
                Return GetProperty(InvoiceLinesProperty)
            End Get
            Private Set(ByVal value As InvoiceLineList)
                LoadProperty(InvoiceLinesProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="InvoiceView"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId parameter of the InvoiceView to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="InvoiceView"/> object.</returns>
        Public Shared Function GetInvoiceView(invoiceId As Guid) As InvoiceView
            Return DataPortal.Fetch(Of InvoiceView)(invoiceId)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="InvoiceView"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId parameter of the InvoiceView to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetInvoiceView(invoiceId As Guid, ByVal callback As EventHandler(Of DataPortalResult(Of InvoiceView)))
            DataPortal.BeginFetch(Of InvoiceView)(invoiceId, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceView"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="InvoiceView"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="invoiceId">The Invoice Id.</param>
        Protected Sub DataPortal_Fetch(invoiceId As Guid)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.GetInvoiceView", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid
                    Dim args As New DataPortalHookArgs(cmd, invoiceId)
                    OnFetchPre(args)
                    Fetch(cmd)
                    OnFetchPost(args)
                End Using
            End Using
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
        ''' Loads a <see cref="InvoiceView"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(InvoiceIdProperty, dr.GetGuid("InvoiceId"))
            LoadProperty(InvoiceNumberProperty, dr.GetString("InvoiceNumber"))
            LoadProperty(CustomerIdProperty, dr.GetString("CustomerId"))
            LoadProperty(InvoiceDateProperty, dr.GetSmartDate("InvoiceDate", True))
            LoadProperty(IsActiveProperty, dr.GetBoolean("IsActive"))
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
            LoadProperty(InvoiceLinesProperty, DataPortal.FetchChild(Of InvoiceLineList)(dr))
        End Sub

        #End Region

        #Region " DataPortal Hooks "

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

        #End Region

    End Class
End Namespace
