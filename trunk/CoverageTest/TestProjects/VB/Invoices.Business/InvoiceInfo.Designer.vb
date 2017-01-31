Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="InvoiceInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="InvoiceList"/> collection.
    ''' </remarks>
    <Serializable()>
    Partial Public Class InvoiceInfo
    Inherits ReadOnlyBase(Of InvoiceInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="InvoiceId"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoiceIdProperty As PropertyInfo(Of Guid) = RegisterProperty(Of Guid)(Function(p) p.InvoiceId, "Invoice Id", Guid.NewGuid())
        ''' <summary>
        ''' Gets the Invoice Id.
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
        ''' Maintains metadata about <see cref="CustomerName"/> property.
        ''' </summary>
        Public Shared ReadOnly CustomerNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.CustomerName, "Customer Name")
        ''' <summary>
        ''' Gets the Customer Name.
        ''' </summary>
        ''' <value>The Customer Name.</value>
        Public ReadOnly Property CustomerName As String
            Get
                Return GetProperty(CustomerNameProperty)
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

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="InvoiceInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(InvoiceIdProperty, dr.GetGuid("InvoiceId"))
            LoadProperty(InvoiceNumberProperty, dr.GetString("InvoiceNumber"))
            LoadProperty(CustomerNameProperty, dr.GetString("CustomerName"))
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

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after the low level fetch operation, before the data reader is destroyed.
        ''' </summary>
        Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace
