Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' ProductEdit (editable root object).<br/>
    ''' This is a generated base class of <see cref="ProductEdit"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class contains one child collection:<br/>
    ''' - <see cref="Suppliers"/> of type <see cref="ProductSupplierColl"/> (1:M relation to <see cref="ProductSupplierItem"/>)
    ''' </remarks>
    <Serializable>
    Public Partial Class ProductEdit
        Inherits BusinessBase(Of ProductEdit)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductId"/> property.
        ''' </summary>
        <NotUndoable>
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
        ''' Maintains metadata about <see cref="ProductCode"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductCodeProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.ProductCode, "Product Code")
        ''' <summary>
        ''' Gets or sets the Product Code.
        ''' </summary>
        ''' <value>The Product Code.</value>
        Public Property ProductCode As String
            Get
                Return GetProperty(ProductCodeProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(ProductCodeProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Name"/> property.
        ''' </summary>
        Public Shared ReadOnly NameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Name, "Name")
        ''' <summary>
        ''' Gets or sets the Name.
        ''' </summary>
        ''' <value>The Name.</value>
        Public Property Name As String
            Get
                Return GetProperty(NameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(NameProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ProductTypeId"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductTypeIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.ProductTypeId, "Product Type Id")
        ''' <summary>
        ''' Gets or sets the Product Type Id.
        ''' </summary>
        ''' <value>The Product Type Id.</value>
        Public Property ProductTypeId As Integer
            Get
                Return GetProperty(ProductTypeIdProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(ProductTypeIdProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="UnitCost"/> property.
        ''' </summary>
        Public Shared ReadOnly UnitCostProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.UnitCost, "Unit Cost")
        ''' <summary>
        ''' Gets or sets the Unit Cost.
        ''' </summary>
        ''' <value>The Unit Cost.</value>
        Public Property UnitCost As String
            Get
                Return GetProperty(UnitCostProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(UnitCostProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockByteNull"/> property.
        ''' </summary>
        Public Shared ReadOnly StockByteNullProperty As PropertyInfo(Of Byte?) = RegisterProperty(Of Byte?)(Function(p) p.StockByteNull, "Stock Byte Null")
        ''' <summary>
        ''' Gets or sets the Stock Byte Null.
        ''' </summary>
        ''' <value>The Stock Byte Null.</value>
        Public Property StockByteNull As Byte?
            Get
                Return GetProperty(StockByteNullProperty)
            End Get
            Set(ByVal value As Byte?)
                SetProperty(StockByteNullProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockByte"/> property.
        ''' </summary>
        Public Shared ReadOnly StockByteProperty As PropertyInfo(Of Byte) = RegisterProperty(Of Byte)(Function(p) p.StockByte, "Stock Byte")
        ''' <summary>
        ''' Gets or sets the Stock Byte.
        ''' </summary>
        ''' <value>The Stock Byte.</value>
        Public Property StockByte As Byte
            Get
                Return GetProperty(StockByteProperty)
            End Get
            Set(ByVal value As Byte)
                SetProperty(StockByteProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockShortNull"/> property.
        ''' </summary>
        Public Shared ReadOnly StockShortNullProperty As PropertyInfo(Of Short?) = RegisterProperty(Of Short?)(Function(p) p.StockShortNull, "Stock Short Null")
        ''' <summary>
        ''' Gets or sets the Stock Short Null.
        ''' </summary>
        ''' <value>The Stock Short Null.</value>
        Public Property StockShortNull As Short?
            Get
                Return GetProperty(StockShortNullProperty)
            End Get
            Set(ByVal value As Short?)
                SetProperty(StockShortNullProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockShort"/> property.
        ''' </summary>
        Public Shared ReadOnly StockShortProperty As PropertyInfo(Of Short) = RegisterProperty(Of Short)(Function(p) p.StockShort, "Stock Short")
        ''' <summary>
        ''' Gets or sets the Stock Short.
        ''' </summary>
        ''' <value>The Stock Short.</value>
        Public Property StockShort As Short
            Get
                Return GetProperty(StockShortProperty)
            End Get
            Set(ByVal value As Short)
                SetProperty(StockShortProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockIntNull"/> property.
        ''' </summary>
        Public Shared ReadOnly StockIntNullProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.StockIntNull, "Stock Int Null")
        ''' <summary>
        ''' Gets or sets the Stock Int Null.
        ''' </summary>
        ''' <value>The Stock Int Null.</value>
        Public Property StockIntNull As Integer?
            Get
                Return GetProperty(StockIntNullProperty)
            End Get
            Set(ByVal value As Integer?)
                SetProperty(StockIntNullProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockInt"/> property.
        ''' </summary>
        Public Shared ReadOnly StockIntProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.StockInt, "Stock Int")
        ''' <summary>
        ''' Gets or sets the Stock Int.
        ''' </summary>
        ''' <value>The Stock Int.</value>
        Public Property StockInt As Integer
            Get
                Return GetProperty(StockIntProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(StockIntProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockLongNull"/> property.
        ''' </summary>
        Public Shared ReadOnly StockLongNullProperty As PropertyInfo(Of Long?) = RegisterProperty(Of Long?)(Function(p) p.StockLongNull, "Stock Long Null")
        ''' <summary>
        ''' Gets or sets the Stock Long Null.
        ''' </summary>
        ''' <value>The Stock Long Null.</value>
        Public Property StockLongNull As Long?
            Get
                Return GetProperty(StockLongNullProperty)
            End Get
            Set(ByVal value As Long?)
                SetProperty(StockLongNullProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="StockLong"/> property.
        ''' </summary>
        Public Shared ReadOnly StockLongProperty As PropertyInfo(Of Long) = RegisterProperty(Of Long)(Function(p) p.StockLong, "Stock Long")
        ''' <summary>
        ''' Gets or sets the Stock Long.
        ''' </summary>
        ''' <value>The Stock Long.</value>
        Public Property StockLong As Long
            Get
                Return GetProperty(StockLongProperty)
            End Get
            Set(ByVal value As Long)
                SetProperty(StockLongProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="Suppliers"/> property.
        ''' </summary>
        Public Shared ReadOnly SuppliersProperty As PropertyInfo(Of ProductSupplierColl) = RegisterProperty(Of ProductSupplierColl)(Function(p) p.Suppliers, "Suppliers", RelationshipTypes.Child)
        ''' <summary>
        ''' Gets the Suppliers ("parent load" child property).
        ''' </summary>
        ''' <value>The Suppliers.</value>
        Public Property Suppliers As ProductSupplierColl
            Get
                Return GetProperty(SuppliersProperty)
            End Get
            Private Set(ByVal value As ProductSupplierColl)
                LoadProperty(SuppliersProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="ProductEdit"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="ProductEdit"/> object.</returns>
        Public Shared Function NewProductEdit() As ProductEdit
            Return DataPortal.Create(Of ProductEdit)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="ProductEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="productId">The ProductId parameter of the ProductEdit to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="ProductEdit"/> object.</returns>
        Public Shared Function GetProductEdit(productId As Guid) As ProductEdit
            Return DataPortal.Fetch(Of ProductEdit)(productId)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="ProductEdit"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewProductEdit(callback As EventHandler(Of DataPortalResult(Of ProductEdit)))
            DataPortal.BeginCreate(Of ProductEdit)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="ProductEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="productId">The ProductId parameter of the ProductEdit to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetProductEdit(productId As Guid, ByVal callback As EventHandler(Of DataPortalResult(Of ProductEdit)))
            DataPortal.BeginFetch(Of ProductEdit)(productId, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ProductEdit"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="ProductEdit"/> object properties.
        ''' </summary>
        <RunLocal>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(ProductIdProperty, Guid.NewGuid())
            LoadProperty(ProductCodeProperty, Nothing)
            LoadProperty(SuppliersProperty, DataPortal.CreateChild(Of ProductSupplierColl)())
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="ProductEdit"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="productId">The Product Id.</param>
        Protected Sub DataPortal_Fetch(productId As Guid)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("Invoices")
                Using cmd = New SqlCommand("dbo.GetProductEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@ProductId", productId).DbType = DbType.Guid
                    Dim args As New DataPortalHookArgs(cmd, productId)
                    OnFetchPre(args)
                    Fetch(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        Private Sub Fetch(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                If dr.Read() Then
                    Fetch(dr)
                    FetchChildren(dr)
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Loads a <see cref="ProductEdit"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(ProductIdProperty, dr.GetGuid("ProductId"))
            LoadProperty(ProductCodeProperty, If(dr.IsDBNull("ProductCode"), Nothing, dr.GetString("ProductCode")))
            LoadProperty(NameProperty, dr.GetString("Name"))
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"))
            LoadProperty(UnitCostProperty, dr.GetString("UnitCost"))
            LoadProperty(StockByteNullProperty, DirectCast(dr.GetValue("StockByteNull"), Byte?))
            LoadProperty(StockByteProperty, dr.GetByte("StockByte"))
            LoadProperty(StockShortNullProperty, DirectCast(dr.GetValue("StockShortNull"), Short?))
            LoadProperty(StockShortProperty, dr.GetInt16("StockShort"))
            LoadProperty(StockIntNullProperty, DirectCast(dr.GetValue("StockIntNull"), Integer?))
            LoadProperty(StockIntProperty, dr.GetInt32("StockInt"))
            LoadProperty(StockLongNullProperty, DirectCast(dr.GetValue("StockLongNull"), Long?))
            LoadProperty(StockLongProperty, dr.GetInt64("StockLong"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Loads child objects from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub FetchChildren(dr As SafeDataReader)
            dr.NextResult()
            LoadProperty(SuppliersProperty, DataPortal.FetchChild(Of ProductSupplierColl)(dr))
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="ProductEdit"/> object in the database.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Overrides Sub DataPortal_Insert()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("Invoices")
                Using cmd = New SqlCommand("dbo.AddProductEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid
                    cmd.Parameters.AddWithValue("@ProductCode", If(ReadProperty(ProductCodeProperty) Is Nothing, DBNull.Value, ReadProperty(ProductCodeProperty))).DbType = DbType.StringFixedLength
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@ProductTypeId", ReadProperty(ProductTypeIdProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@UnitCost", ReadProperty(UnitCostProperty)).DbType = DbType.StringFixedLength
                    cmd.Parameters.AddWithValue("@StockByteNull", If(ReadProperty(StockByteNullProperty) Is Nothing, DBNull.Value, ReadProperty(StockByteNullProperty).Value)).DbType = DbType.Byte
                    cmd.Parameters.AddWithValue("@StockByte", ReadProperty(StockByteProperty)).DbType = DbType.Byte
                    cmd.Parameters.AddWithValue("@StockShortNull", If(ReadProperty(StockShortNullProperty) Is Nothing, DBNull.Value, ReadProperty(StockShortNullProperty).Value)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@StockShort", ReadProperty(StockShortProperty)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@StockIntNull", If(ReadProperty(StockIntNullProperty) Is Nothing, DBNull.Value, ReadProperty(StockIntNullProperty).Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@StockInt", ReadProperty(StockIntProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@StockLongNull", If(ReadProperty(StockLongNullProperty) Is Nothing, DBNull.Value, ReadProperty(StockLongNullProperty).Value)).DbType = DbType.Int64
                    cmd.Parameters.AddWithValue("@StockLong", ReadProperty(StockLongProperty)).DbType = DbType.Int64
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="ProductEdit"/> object.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("Invoices")
                Using cmd = New SqlCommand("dbo.UpdateProductEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid
                    cmd.Parameters.AddWithValue("@ProductCode", If(ReadProperty(ProductCodeProperty) Is Nothing, DBNull.Value, ReadProperty(ProductCodeProperty))).DbType = DbType.StringFixedLength
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@ProductTypeId", ReadProperty(ProductTypeIdProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@UnitCost", ReadProperty(UnitCostProperty)).DbType = DbType.StringFixedLength
                    cmd.Parameters.AddWithValue("@StockByteNull", If(ReadProperty(StockByteNullProperty) Is Nothing, DBNull.Value, ReadProperty(StockByteNullProperty).Value)).DbType = DbType.Byte
                    cmd.Parameters.AddWithValue("@StockByte", ReadProperty(StockByteProperty)).DbType = DbType.Byte
                    cmd.Parameters.AddWithValue("@StockShortNull", If(ReadProperty(StockShortNullProperty) Is Nothing, DBNull.Value, ReadProperty(StockShortNullProperty).Value)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@StockShort", ReadProperty(StockShortProperty)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@StockIntNull", If(ReadProperty(StockIntNullProperty) Is Nothing, DBNull.Value, ReadProperty(StockIntNullProperty).Value)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@StockInt", ReadProperty(StockIntProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@StockLongNull", If(ReadProperty(StockLongNullProperty) Is Nothing, DBNull.Value, ReadProperty(StockLongNullProperty).Value)).DbType = DbType.Int64
                    cmd.Parameters.AddWithValue("@StockLong", ReadProperty(StockLongProperty)).DbType = DbType.Int64
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
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
