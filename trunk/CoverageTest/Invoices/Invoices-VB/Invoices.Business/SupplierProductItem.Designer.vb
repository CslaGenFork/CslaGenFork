Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' SupplierProductItem (editable child object).<br/>
    ''' This is a generated base class of <see cref="SupplierProductItem"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="SupplierProductColl"/> collection.
    ''' </remarks>
    <Serializable()>
    Public Partial Class SupplierProductItem
        Inherits BusinessBase(Of SupplierProductItem)

        #Region " Static Fields "

            Private Shared _lastId As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductSupplierId"/> property.
        ''' </summary>
        <NotUndoable>
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

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SupplierProductItem"/> class.
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
        ''' Loads default values for the <see cref="SupplierProductItem"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub Child_Create()
            LoadProperty(ProductSupplierIdProperty, System.Threading.Interlocked.Decrement(_lastId))
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.Child_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="SupplierProductItem"/> object from the given SafeDataReader.
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

        ''' <summary>
        ''' Inserts a new <see cref="SupplierProductItem"/> object in the database.
        ''' </summary>
        ''' <param name="parent">The parent object.</param>
        <Transactional(TransactionalTypes.TransactionScope)>
        Private Sub Child_Insert(parent As SupplierEdit)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.AddSupplierProductItem", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@SupplierId", parent.SupplierId).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ProductSupplierId", ReadProperty(ProductSupplierIdProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(ProductSupplierIdProperty, DirectCast(cmd.Parameters("@ProductSupplierId").Value, Integer))
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="SupplierProductItem"/> object.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Private Sub Child_Update()
            If Not IsDirty
                return
            End If

            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.UpdateSupplierProductItem", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@ProductSupplierId", ReadProperty(ProductSupplierIdProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="SupplierProductItem"/> object from database.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Private Sub Child_DeleteSelf()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.DeleteSupplierProductItem", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@ProductSupplierId", ReadProperty(ProductSupplierIdProperty)).DbType = DbType.Int32
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
