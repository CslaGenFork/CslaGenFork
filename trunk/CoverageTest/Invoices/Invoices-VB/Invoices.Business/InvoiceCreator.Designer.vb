Imports System
Imports Csla

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceCreator (creator unit of work pattern).<br/>
    ''' This is a generated base class of <see cref="InvoiceCreator"/> business object.
    ''' This class is a root object that implements the Unit of Work pattern.
    ''' </summary>
    <Serializable()>
    Public Partial Class InvoiceCreator
        Inherits ReadOnlyBase(Of InvoiceCreator)

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
        ''' Factory method. Creates a new <see cref="InvoiceCreator"/> unit of objects.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="InvoiceCreator"/> unit of objects.</returns>
        Public Shared Function NewInvoiceCreator() As InvoiceCreator
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            Return DataPortal.Fetch(Of InvoiceCreator)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="InvoiceCreator"/> unit of objects.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewInvoiceCreator(callback As EventHandler(Of DataPortalResult(Of InvoiceCreator)))
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch(Of InvoiceCreator)(Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                callback(o, e)
            End Sub)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceCreator"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Creates a new <see cref="InvoiceCreator"/> unit of objects.
        ''' </summary>
        ''' <remarks>
        ''' ReadOnlyBase&lt;T&gt; doesn't allow the use of DataPortal_Create and thus DataPortal_Fetch is used.
        ''' </remarks>
        Protected Sub DataPortal_Fetch()
            LoadProperty(InvoiceProperty, InvoiceEdit.NewInvoiceEdit())
            LoadProperty(ProductTypesProperty, ProductTypeNVL.GetProductTypeNVL())
        End Sub

        #End Region

    End Class
End Namespace
