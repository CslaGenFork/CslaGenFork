Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' SupplierProductInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="SupplierProductInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="SupplierProductList"/> collection.
    ''' </remarks>
    <Serializable>
    Public Partial Class SupplierProductInfo
        Inherits ReadOnlyBase(Of SupplierProductInfo)

        #Region " Static Fields "

            Private Shared _lastId As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductSupplierId"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductSupplierIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.ProductSupplierId, "Product Supplier Id")
        ''' <summary>
        ''' Gets the Product Supplier Id.
        ''' </summary>
        ''' <value>The Product Supplier Id.</value>
        Public ReadOnly Property ProductSupplierId As Integer
            Get
                Return GetProperty(ProductSupplierIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductId"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductIdProperty As PropertyInfo(Of Guid) = RegisterProperty(Of Guid)(Function(p) p.ProductId, "Product Id")
        ''' <summary>
        ''' Gets the Product Id.
        ''' </summary>
        ''' <value>The Product Id.</value>
        Public ReadOnly Property ProductId As Guid
            Get
                Return GetProperty(ProductIdProperty)
            End Get
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SupplierProductInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="SupplierProductInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(ProductSupplierIdProperty, dr.GetInt32("ProductSupplierId"))
            LoadProperty(ProductIdProperty, dr.GetGuid("ProductId"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
            ' check all object rules and property rules
            BusinessRules.CheckRules()
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
