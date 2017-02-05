Imports System
Imports Csla

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceGetter (getter unit of work pattern).<br/>
    ''' This is a generated base class of <see cref="InvoiceGetter"/> business object.
    ''' This class is a root object that implements the Unit of Work pattern.
    ''' </summary>
    <Serializable()>
    Partial Public Class InvoiceGetter
    Inherits ReadOnlyBase(Of InvoiceGetter)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="Invoice"/> property.
        ''' </summary>
        Public Shared ReadOnly InvoiceProperty As PropertyInfo(Of InvoiceEdit) = RegisterProperty(Of InvoiceEdit)(Function(p) p.Invoice, "Invoice")
        ''' <summary>
        ''' Gets the Invoice object (unit of work child property).
        ''' </summary>
        ''' <value>The Invoice.</value>
        Public Property Invoice As InvoiceEdit
            Get
                Return GetProperty(InvoiceProperty)
            End Get
            Private Set(ByVal value As InvoiceEdit)
                LoadProperty(InvoiceProperty, value)
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
        ''' Factory method. Loads a <see cref="InvoiceGetter"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId parameter of the InvoiceGetter to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="InvoiceGetter"/> unit of objects.</returns>
        Public Shared Function GetInvoiceGetter(invoiceId As Guid) As InvoiceGetter
            Return DataPortal.Fetch(Of InvoiceGetter)(invoiceId)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="InvoiceGetter"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId parameter of the InvoiceGetter to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetInvoiceGetter(invoiceId As Guid, callback As EventHandler(Of DataPortalResult(Of InvoiceGetter)))
            DataPortal.BeginFetch(Of InvoiceGetter)(invoiceId, Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                callback(o, e)
            End Sub)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceGetter"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="InvoiceGetter"/> unit of objects, based on given criteria.
        ''' </summary>
        ''' <param name="invoiceId">The fetch criteria.</param>
        Protected Sub DataPortal_Fetch(invoiceId As Guid)
            LoadProperty(InvoiceProperty, InvoiceEdit.GetInvoiceEdit(invoiceId))
            LoadProperty(ProductTypesProperty, ProductTypeNVL.GetProductTypeNVL())
        End Sub

        #End Region

    End Class
End Namespace
