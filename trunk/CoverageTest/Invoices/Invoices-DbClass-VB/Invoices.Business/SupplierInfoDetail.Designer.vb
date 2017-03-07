Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' SupplierInfoDetail (read only object).<br/>
    ''' This is a generated base class of <see cref="SupplierInfoDetail"/> business object.
    ''' This class is a root object.
    ''' </summary>
    ''' <remarks>
    ''' This class contains one child collection:<br/>
    ''' - <see cref="Products"/> of type <see cref="SupplierProductList"/> (1:M relation to <see cref="SupplierProductItnfo"/>)
    ''' </remarks>
    <Serializable>
    Public Partial Class SupplierInfoDetail
        Inherits ReadOnlyBase(Of SupplierInfoDetail)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="SupplierId"/> property.
        ''' </summary>
        Public Shared ReadOnly SupplierIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.SupplierId, "Supplier Id")
        ''' <summary>
        ''' For simplicity sake, use the VAT number (no auto increment here).
        ''' </summary>
        ''' <value>The Supplier Id.</value>
        Public ReadOnly Property SupplierId As Integer
            Get
                Return GetProperty(SupplierIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Name"/> property.
        ''' </summary>
        Public Shared ReadOnly NameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Name, "Name")
        ''' <summary>
        ''' Gets the Name.
        ''' </summary>
        ''' <value>The Name.</value>
        Public ReadOnly Property Name As String
            Get
                Return GetProperty(NameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="AddressLine1"/> property.
        ''' </summary>
        Public Shared ReadOnly AddressLine1Property As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.AddressLine1, "Address Line1")
        ''' <summary>
        ''' Gets the Address Line1.
        ''' </summary>
        ''' <value>The Address Line1.</value>
        Public ReadOnly Property AddressLine1 As String
            Get
                Return GetProperty(AddressLine1Property)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="AddressLine2"/> property.
        ''' </summary>
        Public Shared ReadOnly AddressLine2Property As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.AddressLine2, "Address Line2")
        ''' <summary>
        ''' Gets the Address Line2.
        ''' </summary>
        ''' <value>The Address Line2.</value>
        Public ReadOnly Property AddressLine2 As String
            Get
                Return GetProperty(AddressLine2Property)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ZipCode"/> property.
        ''' </summary>
        Public Shared ReadOnly ZipCodeProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.ZipCode, "Zip Code")
        ''' <summary>
        ''' Gets the Zip Code.
        ''' </summary>
        ''' <value>The Zip Code.</value>
        Public ReadOnly Property ZipCode As String
            Get
                Return GetProperty(ZipCodeProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="State"/> property.
        ''' </summary>
        Public Shared ReadOnly StateProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.State, "State")
        ''' <summary>
        ''' Gets the State.
        ''' </summary>
        ''' <value>The State.</value>
        Public ReadOnly Property State As String
            Get
                Return GetProperty(StateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Country"/> property.
        ''' </summary>
        Public Shared ReadOnly CountryProperty As PropertyInfo(Of Byte?) = RegisterProperty(Of Byte?)(Function(p) p.Country, "Country")
        ''' <summary>
        ''' Gets the Country.
        ''' </summary>
        ''' <value>The Country.</value>
        Public ReadOnly Property Country As Byte?
            Get
                Return GetProperty(CountryProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="Products"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductsProperty As PropertyInfo(Of SupplierProductList) = RegisterProperty(Of SupplierProductList)(Function(p) p.Products, "Products")
        ''' <summary>
        ''' Gets the Products ("lazy load" child property).
        ''' </summary>
        ''' <value>The Products.</value>
        Public Property Products As SupplierProductList
            Get
#If ASYNC Then
                Return LazyGetPropertyAsync(ProductsProperty,
                    DataPortal.FetchAsync(Of SupplierProductList)(ReadProperty(SupplierIdProperty)))
#Else
                Return LazyGetProperty(ProductsProperty,
                    Function() DataPortal.Fetch(Of SupplierProductList)(ReadProperty(SupplierIdProperty)))
#End If
            End Get
            Private Set
                LoadProperty(ProductsProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="SupplierInfoDetail"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="supplierId">The SupplierId parameter of the SupplierInfoDetail to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="SupplierInfoDetail"/> object.</returns>
        Public Shared Function GetSupplierInfoDetail(supplierId As Integer) As SupplierInfoDetail
            Return DataPortal.Fetch(Of SupplierInfoDetail)(supplierId)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="SupplierInfoDetail"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="supplierId">The SupplierId parameter of the SupplierInfoDetail to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetSupplierInfoDetail(supplierId As Integer, ByVal callback As EventHandler(Of DataPortalResult(Of SupplierInfoDetail)))
            DataPortal.BeginFetch(Of SupplierInfoDetail)(supplierId, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SupplierInfoDetail"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="SupplierInfoDetail"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="supplierId">The Supplier Id.</param>
        Protected Sub DataPortal_Fetch(supplierId As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.InvoicesConnection, False)
                Using cmd = New SqlCommand("dbo.GetSupplierInfoDetal", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, supplierId)
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
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Loads a <see cref="SupplierInfoDetail"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(SupplierIdProperty, dr.GetInt32("SupplierId"))
            LoadProperty(NameProperty, dr.GetString("Name"))
            LoadProperty(AddressLine1Property, If(dr.IsDBNull("AddressLine1"), Nothing, dr.GetString("AddressLine1")))
            LoadProperty(AddressLine2Property, If(dr.IsDBNull("AddressLine2"), Nothing, dr.GetString("AddressLine2")))
            LoadProperty(ZipCodeProperty, If(dr.IsDBNull("ZipCode"), Nothing, dr.GetString("ZipCode")))
            LoadProperty(StateProperty, If(dr.IsDBNull("State"), Nothing, dr.GetString("State")))
            LoadProperty(CountryProperty, DirectCast(dr.GetValue("Country"), Byte?))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
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
