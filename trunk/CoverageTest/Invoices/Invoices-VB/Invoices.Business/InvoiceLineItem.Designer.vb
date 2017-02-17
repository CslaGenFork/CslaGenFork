Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceLineItem (editable child object).<br/>
    ''' This is a generated base class of <see cref="InvoiceLineItem"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="InvoiceLineCollection"/> collection.
    ''' </remarks>
    <Serializable>
    Public Partial Class InvoiceLineItem
        Inherits BusinessBase(Of InvoiceLineItem)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="InvoiceLineId"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly InvoiceLineIdProperty As PropertyInfo(Of Guid) = RegisterProperty(Of Guid)(Function(p) p.InvoiceLineId, "Invoice Line Id")
        ''' <summary>
        ''' Gets or sets the Invoice Line Id.
        ''' </summary>
        ''' <value>The Invoice Line Id.</value>
        Public Property InvoiceLineId As Guid
            Get
                Return GetProperty(InvoiceLineIdProperty)
            End Get
            Set(ByVal value As Guid)
                SetProperty(InvoiceLineIdProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductId"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductIdProperty As PropertyInfo(Of Guid) = RegisterProperty(Of Guid)(Function(p) p.ProductId, "Product Id")
        ''' <summary>
        ''' Gets or sets the Product Id.
        ''' </summary>
        ''' <value>The Product Id.</value>
        Public Property ProductId As Guid
            Get
                Return GetProperty(ProductIdProperty)
            End Get
            Set(ByVal value As Guid)
                SetProperty(ProductIdProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Cost"/> property.
        ''' </summary>
        Public Shared ReadOnly CostProperty As PropertyInfo(Of Decimal) = RegisterProperty(Of Decimal)(Function(p) p.Cost, "Cost")
        ''' <summary>
        ''' Gets or sets the Cost.
        ''' </summary>
        ''' <value>The Cost.</value>
        Public Property Cost As Decimal
            Get
                Return GetProperty(CostProperty)
            End Get
            Set(ByVal value As Decimal)
                SetProperty(CostProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="PercentDiscount"/> property.
        ''' </summary>
        Public Shared ReadOnly PercentDiscountProperty As PropertyInfo(Of Byte) = RegisterProperty(Of Byte)(Function(p) p.PercentDiscount, "Percent Discount")
        ''' <summary>
        ''' Gets or sets the Percent Discount.
        ''' </summary>
        ''' <value>The Percent Discount.</value>
        Public Property PercentDiscount As Byte
            Get
                Return GetProperty(PercentDiscountProperty)
            End Get
            Set(ByVal value As Byte)
                SetProperty(PercentDiscountProperty, value)
            End Set
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceLineItem"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            ' show the framework that this is a child object
            MarkAsChild()
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="InvoiceLineItem"/> object properties.
        ''' </summary>
        <RunLocal>
        Protected Overrides Sub Child_Create()
            LoadProperty(InvoiceLineIdProperty, Guid.NewGuid())
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.Child_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="InvoiceLineItem"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(InvoiceLineIdProperty, dr.GetGuid("InvoiceLineId"))
            LoadProperty(ProductIdProperty, dr.GetGuid("ProductId"))
            LoadProperty(CostProperty, dr.GetDecimal("Cost"))
            LoadProperty(PercentDiscountProperty, dr.GetByte("PercentDiscount"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="InvoiceLineItem"/> object in the database.
        ''' </summary>
        ''' <param name="parent">The parent object.</param>
        <Transactional(TransactionalTypes.TransactionScope)>
        Private Sub Child_Insert(parent As InvoiceEdit)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.AddInvoiceLineItem", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@InvoiceId", parent.InvoiceId).DbType = DbType.Guid
                    cmd.Parameters.AddWithValue("@InvoiceLineId", ReadProperty(InvoiceLineIdProperty)).DbType = DbType.Guid
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid
                    cmd.Parameters.AddWithValue("@Cost", ReadProperty(CostProperty)).DbType = DbType.Decimal
                    cmd.Parameters.AddWithValue("@PercentDiscount", ReadProperty(PercentDiscountProperty)).DbType = DbType.Byte
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="InvoiceLineItem"/> object.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Private Sub Child_Update()
            If Not IsDirty
                return
            End If

            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.UpdateInvoiceLineItem", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@InvoiceLineId", ReadProperty(InvoiceLineIdProperty)).DbType = DbType.Guid
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid
                    cmd.Parameters.AddWithValue("@Cost", ReadProperty(CostProperty)).DbType = DbType.Decimal
                    cmd.Parameters.AddWithValue("@PercentDiscount", ReadProperty(PercentDiscountProperty)).DbType = DbType.Byte
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="InvoiceLineItem"/> object from database.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Private Sub Child_DeleteSelf()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.DeleteInvoiceLineItem", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@InvoiceLineId", ReadProperty(InvoiceLineIdProperty)).DbType = DbType.Guid
                    Dim args As New DataPortalHookArgs(cmd)
                    OnDeletePre(args)
                    cmd.ExecuteNonQuery()
                    OnDeletePost(args)
                End Using
            End Using
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting all defaults for object creation.
        ''' </summary>
        Partial Private Sub OnCreate(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        ''' </summary>
        Partial Private Sub OnDeletePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after the delete operation, before Commit().
        ''' </summary>
        Partial Private Sub OnDeletePost(args As DataPortalHookArgs)
        End Sub

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

        ''' <summary>
        ''' Occurs after setting query parameters and before the update operation.
        ''' </summary>
        Partial Private Sub OnUpdatePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnUpdatePost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        ''' </summary>
        Partial Private Sub OnInsertPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnInsertPost(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace
