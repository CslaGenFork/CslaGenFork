Imports System
Imports Csla

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceListGetter (getter unit of work pattern).<br/>
    ''' This is a generated base class of <see cref="InvoiceListGetter"/> business object.
    ''' This class is a root object that implements the Unit of Work pattern.
    ''' </summary>
    <Serializable>
    Public Partial Class InvoiceListGetter
        Inherits ReadOnlyBase(Of InvoiceListGetter)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="Invoices"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoicesProperty As PropertyInfo(Of InvoiceList) = RegisterProperty(Of InvoiceList)(Function(p) p.Invoices, "Invoices")
        ''' <summary>
        ''' Gets the Invoices object (unit of work child property).
        ''' </summary>
        ''' <value>The Invoices.</value>
        Public Property Invoices As InvoiceList
            Get
                Return GetProperty(InvoicesProperty)
            End Get
            Private Set(ByVal value As InvoiceList)
                LoadProperty(InvoicesProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="ProductTypes"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductTypesProperty As PropertyInfo(Of ProductTypeNVL) = RegisterProperty(Of ProductTypeNVL)(Function(p) p.ProductTypes, "Product Types")
        ''' <summary>
        ''' Gets the Product Types object (unit of work child property).
        ''' </summary>
        ''' <value>The Product Types.</value>
        Public Property ProductTypes As ProductTypeNVL
            Get
                Return GetProperty(ProductTypesProperty)
            End Get
            Private Set(ByVal value As ProductTypeNVL)
                LoadProperty(ProductTypesProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="InvoiceListGetter"/> unit of objects.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="InvoiceListGetter"/> unit of objects.</returns>
        Public Shared Function GetInvoiceListGetter() As InvoiceListGetter
            Return DataPortal.Fetch(Of InvoiceListGetter)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="InvoiceListGetter"/> unit of objects.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetInvoiceListGetter(callback As EventHandler(Of DataPortalResult(Of InvoiceListGetter)))
            DataPortal.BeginFetch(Of InvoiceListGetter)(Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                callback(o, e)
            End Sub)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceListGetter"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="InvoiceListGetter"/> unit of objects.
        ''' </summary>
        Protected Sub DataPortal_Fetch()
            LoadProperty(InvoicesProperty, InvoiceList.GetInvoiceList())
            LoadProperty(ProductTypesProperty, ProductTypeNVL.GetProductTypeNVL())
        End Sub

        #End Region

    End Class
End Namespace
