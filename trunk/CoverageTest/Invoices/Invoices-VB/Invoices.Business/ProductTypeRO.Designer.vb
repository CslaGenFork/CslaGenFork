Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' ProductTypeRO (read only object).<br/>
    ''' This is a generated base class of <see cref="ProductTypeRO"/> business object.
    ''' This class is a root object.
    ''' </summary>
    <Serializable>
    Public Partial Class ProductTypeRO
        Inherits ReadOnlyBase(Of ProductTypeRO)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductTypeId"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductTypeIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.ProductTypeId, "Product Type Id")
        ''' <summary>
        ''' Gets the Product Type Id.
        ''' </summary>
        ''' <value>The Product Type Id.</value>
        Public ReadOnly Property ProductTypeId As Integer
            Get
                Return GetProperty(ProductTypeIdProperty)
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

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="ProductTypeRO"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="productTypeId">The ProductTypeId parameter of the ProductTypeRO to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="ProductTypeRO"/> object.</returns>
        Public Shared Function GetProductTypeRO(productTypeId As Integer) As ProductTypeRO
            Return DataPortal.Fetch(Of ProductTypeRO)(productTypeId)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="ProductTypeRO"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="productTypeId">The ProductTypeId parameter of the ProductTypeRO to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetProductTypeRO(productTypeId As Integer, ByVal callback As EventHandler(Of DataPortalResult(Of ProductTypeRO)))
            DataPortal.BeginFetch(Of ProductTypeRO)(productTypeId, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ProductTypeRO"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="ProductTypeRO"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="productTypeId">The Product Type Id.</param>
        Protected Sub DataPortal_Fetch(productTypeId As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("Invoices")
                Using cmd = New SqlCommand("dbo.GetProductTypeRO", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, productTypeId)
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
        ''' Loads a <see cref="ProductTypeRO"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"))
            LoadProperty(NameProperty, dr.GetString("Name"))
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
