Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceLineInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="InvoiceLineInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="InvoiceLineList"/> collection.
    ''' </remarks>
    <Serializable()>
    Public Partial Class InvoiceLineInfo
        Inherits ReadOnlyBase(Of InvoiceLineInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="InvoiceLineId"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoiceLineIdProperty As PropertyInfo(Of Guid) = RegisterProperty(Of Guid)(Function(p) p.InvoiceLineId, "Invoice Line Id", Guid.NewGuid())
        ''' <summary>
        ''' Gets the Invoice Line Id.
        ''' </summary>
        ''' <value>The Invoice Line Id.</value>
        Public ReadOnly Property InvoiceLineId As Guid
            Get
                Return GetProperty(InvoiceLineIdProperty)
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

        ''' <summary>
        ''' Maintains metadata about <see cref="Quantity"/> property.
        ''' </summary>
        Public Shared ReadOnly QuantityProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.Quantity, "Quantity")
        ''' <summary>
        ''' Gets the Quantity.
        ''' </summary>
        ''' <value>The Quantity.</value>
        Public ReadOnly Property Quantity As Integer
            Get
                Return GetProperty(QuantityProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="UnitCost"/> property.
        ''' </summary>
        Public Shared ReadOnly UnitCostProperty As PropertyInfo(Of Decimal) = RegisterProperty(Of Decimal)(Function(p) p.UnitCost, "Unit Cost")
        ''' <summary>
        ''' Gets the Unit Cost.
        ''' </summary>
        ''' <value>The Unit Cost.</value>
        Public ReadOnly Property UnitCost As Decimal
            Get
                Return GetProperty(UnitCostProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Cost"/> property.
        ''' </summary>
        Public Shared ReadOnly CostProperty As PropertyInfo(Of Decimal) = RegisterProperty(Of Decimal)(Function(p) p.Cost, "Cost")
        ''' <summary>
        ''' Gets the Cost.
        ''' </summary>
        ''' <value>The Cost.</value>
        Public ReadOnly Property Cost As Decimal
            Get
                Return GetProperty(CostProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="PercentDiscount"/> property.
        ''' </summary>
        Public Shared ReadOnly PercentDiscountProperty As PropertyInfo(Of Byte) = RegisterProperty(Of Byte)(Function(p) p.PercentDiscount, "Percent Discount")
        ''' <summary>
        ''' Gets the Percent Discount.
        ''' </summary>
        ''' <value>The Percent Discount.</value>
        Public ReadOnly Property PercentDiscount As Byte
            Get
                Return GetProperty(PercentDiscountProperty)
            End Get
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceLineInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="InvoiceLineInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(InvoiceLineIdProperty, dr.GetGuid("InvoiceLineId"))
            LoadProperty(ProductIdProperty, dr.GetGuid("ProductId"))
            LoadProperty(QuantityProperty, dr.GetInt32("Quantity"))
            LoadProperty(UnitCostProperty, dr.GetDecimal("UnitCost"))
            LoadProperty(CostProperty, dr.GetDecimal("Cost"))
            LoadProperty(PercentDiscountProperty, dr.GetByte("PercentDiscount"))
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
