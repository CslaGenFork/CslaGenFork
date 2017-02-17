Imports System
Imports Csla

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceCreatorGetter (creator and getter unit of work pattern).<br/>
    ''' This is a generated base class of <see cref="InvoiceCreatorGetter"/> business object.
    ''' This class is a root object that implements the Unit of Work pattern.
    ''' </summary>
    <Serializable>
    Public Partial Class InvoiceCreatorGetter
        Inherits ReadOnlyBase(Of InvoiceCreatorGetter)

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
        ''' Factory method. Creates a new <see cref="InvoiceCreatorGetter"/> unit of objects.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="InvoiceCreatorGetter"/> unit of objects.</returns>
        Public Shared Function NewInvoiceCreatorGetter() As InvoiceCreatorGetter
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            Return DataPortal.Fetch(Of InvoiceCreatorGetter)(New Criteria1(true, New Guid()))
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="InvoiceCreatorGetter"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId parameter of the InvoiceCreatorGetter to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="InvoiceCreatorGetter"/> unit of objects.</returns>
        Public Shared Function GetInvoiceCreatorGetter(invoiceId As Guid) As InvoiceCreatorGetter
            Return DataPortal.Fetch(Of InvoiceCreatorGetter)(New Criteria1(false, invoiceId))
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="InvoiceCreatorGetter"/> unit of objects.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewInvoiceCreatorGetter(callback As EventHandler(Of DataPortalResult(Of InvoiceCreatorGetter)))
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch(Of InvoiceCreatorGetter)(New Criteria1(true, New Guid()), Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                callback(o, e)
            End Sub)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="InvoiceCreatorGetter"/> unit of objects, based on given parameters.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId parameter of the InvoiceCreatorGetter to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetInvoiceCreatorGetter(invoiceId As Guid, callback As EventHandler(Of DataPortalResult(Of InvoiceCreatorGetter)))
            DataPortal.BeginFetch(Of InvoiceCreatorGetter)(New Criteria1(false, invoiceId), Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                callback(o, e)
            End Sub)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceCreatorGetter"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Criteria "

        ''' <summary>
        ''' Criteria1 criteria.
        ''' </summary>
        <Serializable>
        Protected Class Criteria1
            Inherits CriteriaBase(Of Criteria1)

            ''' <summary>
            ''' Maintains metadata about <see cref="CreateInvoiceEdit"/> property.
            ''' </summary>
            Public Shared ReadOnly CreateInvoiceEditProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.CreateInvoiceEdit, "Create Invoice Edit")
            ''' <summary>
            ''' Gets or sets the Create Invoice Edit.
            ''' </summary>
            ''' <value>The Create Invoice Edit.</value>
            Public Property CreateInvoiceEdit As Boolean
                Get
                    Return ReadProperty(CreateInvoiceEditProperty)
                End Get
                Set
                    LoadProperty(CreateInvoiceEditProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Maintains metadata about <see cref="InvoiceId"/> property.
            ''' </summary>
            Public Shared ReadOnly InvoiceIdProperty As PropertyInfo(Of Guid) = RegisterProperty(Of Guid)(Function(p) p.InvoiceId, "Invoice Id")
            ''' <summary>
            ''' Gets or sets the Invoice Id.
            ''' </summary>
            ''' <value>The Invoice Id.</value>
            Public Property InvoiceId As Guid
                Get
                    Return ReadProperty(InvoiceIdProperty)
                End Get
                Set
                    LoadProperty(InvoiceIdProperty, value)
                End Set
            End Property

            ''' <summary>
            ''' Initializes a new instance of the <see cref="Criteria1"/> class.
            ''' </summary>
            ''' <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
            Public Sub New()
            End Sub

            ''' <summary>
            ''' Initializes a new instance of the <see cref="Criteria1"/> class.
            ''' </summary>
            ''' <param name="p_createInvoiceEdit">The CreateInvoiceEdit.</param>
            ''' <param name="p_invoiceId">The InvoiceId.</param>
            Public Sub New(p_createInvoiceEdit As Boolean, p_invoiceId As Guid)
                CreateInvoiceEdit = p_createInvoiceEdit
                InvoiceId = p_invoiceId
            End Sub

            ''' <summary>
            ''' Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            ''' </summary>
            ''' <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            ''' <returns><c>True</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            Public Overrides Function Equals(obj As object) As Boolean
                If TypeOf obj Is Criteria1 Then
                    Dim c As Criteria1 = obj
                    If Not CreateInvoiceEdit.Equals(c.CreateInvoiceEdit) Then
                        Return False
                    End If
                    If Not InvoiceId.Equals(c.InvoiceId) Then
                        Return False
                    End If
                    Return True
                End If
                Return False
            End Function

            ''' <summary>
            ''' Returns a hash code for this instance.
            ''' </summary>
            ''' <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            Public Overrides Function GetHashCode() As Integer
                Return String.Concat("Criteria1", CreateInvoiceEdit.ToString(), InvoiceId.ToString()).GetHashCode()
            End Function
        End Class

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Creates or loads a <see cref="InvoiceCreatorGetter"/> unit of objects, based on given criteria.
        ''' </summary>
        ''' <param name="crit">The create/fetch criteria.</param>
        Protected Overloads Sub DataPortal_Fetch(crit As Criteria1)
            If crit.CreateInvoiceEdit Then
                LoadProperty(InvoiceProperty, InvoiceEdit.NewInvoiceEdit())
            Else
                LoadProperty(InvoiceProperty, InvoiceEdit.GetInvoiceEdit(crit.InvoiceId))
            End If
            LoadProperty(ProductTypesProperty, ProductTypeNVL.GetProductTypeNVL())
        End Sub

        #End Region

    End Class
End Namespace
