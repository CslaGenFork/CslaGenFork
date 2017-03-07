Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' SupplierEdit (editable root object).<br/>
    ''' This is a generated base class of <see cref="SupplierEdit"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class contains one child collection:<br/>
    ''' - <see cref="Products"/> of type <see cref="SupplierProductColl"/> (1:M relation to <see cref="SupplierProductItem"/>)
    ''' </remarks>
    <Serializable>
    Public Partial Class SupplierEdit
        Inherits BusinessBase(Of SupplierEdit)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="SupplierId"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly SupplierIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.SupplierId, "Supplier Id")
        ''' <summary>
        ''' For simplicity sake, use the VAT number (no auto increment here).
        ''' </summary>
        ''' <value>The Supplier Id.</value>
        Public Property SupplierId As Integer
            Get
                Return GetProperty(SupplierIdProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(SupplierIdProperty, value)
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
        ''' Maintains metadata about <see cref="AddressLine1"/> property.
        ''' </summary>
        Public Shared ReadOnly AddressLine1Property As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.AddressLine1, "Address Line1")
        ''' <summary>
        ''' Gets or sets the Address Line1.
        ''' </summary>
        ''' <value>The Address Line1.</value>
        Public Property AddressLine1 As String
            Get
                Return GetProperty(AddressLine1Property)
            End Get
            Set(ByVal value As String)
                SetProperty(AddressLine1Property, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="AddressLine2"/> property.
        ''' </summary>
        Public Shared ReadOnly AddressLine2Property As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.AddressLine2, "Address Line2")
        ''' <summary>
        ''' Gets or sets the Address Line2.
        ''' </summary>
        ''' <value>The Address Line2.</value>
        Public Property AddressLine2 As String
            Get
                Return GetProperty(AddressLine2Property)
            End Get
            Set(ByVal value As String)
                SetProperty(AddressLine2Property, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ZipCode"/> property.
        ''' </summary>
        Public Shared ReadOnly ZipCodeProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.ZipCode, "Zip Code")
        ''' <summary>
        ''' Gets or sets the Zip Code.
        ''' </summary>
        ''' <value>The Zip Code.</value>
        Public Property ZipCode As String
            Get
                Return GetProperty(ZipCodeProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(ZipCodeProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="State"/> property.
        ''' </summary>
        Public Shared ReadOnly StateProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.State, "State")
        ''' <summary>
        ''' Gets or sets the State.
        ''' </summary>
        ''' <value>The State.</value>
        Public Property State As String
            Get
                Return GetProperty(StateProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(StateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Country"/> property.
        ''' </summary>
        Public Shared ReadOnly CountryProperty As PropertyInfo(Of Byte?) = RegisterProperty(Of Byte?)(Function(p) p.Country, "Country")
        ''' <summary>
        ''' Gets or sets the Country.
        ''' </summary>
        ''' <value>The Country.</value>
        Public Property Country As Byte?
            Get
                Return GetProperty(CountryProperty)
            End Get
            Set(ByVal value As Byte?)
                SetProperty(CountryProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="Products"/> property.
        ''' </summary>
        Public Shared ReadOnly ProductsProperty As PropertyInfo(Of SupplierProductColl) = RegisterProperty(Of SupplierProductColl)(Function(p) p.Products, "Products", RelationshipTypes.Child Or RelationshipTypes.LazyLoad)
        ''' <summary>
        ''' Gets the Products ("lazy load" child property).
        ''' </summary>
        ''' <value>The Products.</value>
        Public Property Products As SupplierProductColl
    Get
#If ASYNC Then
                Return LazyGetPropertyAsync(ProductsProperty,
                    DataPortal.FetchAsync(Of SupplierProductColl)(ReadProperty(SupplierIdProperty)))
#Else
                Return LazyGetProperty(ProductsProperty,
                    Function() DataPortal.Fetch(Of SupplierProductColl)(ReadProperty(SupplierIdProperty)))
#End If
    End Get
    Private Set
                LoadProperty(ProductsProperty, value)
    End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="SupplierEdit"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="SupplierEdit"/> object.</returns>
        Public Shared Function NewSupplierEdit() As SupplierEdit
            Return DataPortal.Create(Of SupplierEdit)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="SupplierEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="supplierId">The SupplierId parameter of the SupplierEdit to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="SupplierEdit"/> object.</returns>
        Public Shared Function GetSupplierEdit(supplierId As Integer) As SupplierEdit
            Return DataPortal.Fetch(Of SupplierEdit)(supplierId)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="SupplierEdit"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewSupplierEdit(callback As EventHandler(Of DataPortalResult(Of SupplierEdit)))
            DataPortal.BeginCreate(Of SupplierEdit)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="SupplierEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="supplierId">The SupplierId parameter of the SupplierEdit to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetSupplierEdit(supplierId As Integer, ByVal callback As EventHandler(Of DataPortalResult(Of SupplierEdit)))
            DataPortal.BeginFetch(Of SupplierEdit)(supplierId, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SupplierEdit"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnSupplierEditSaved
            AddHandler SupplierEditSaved, AddressOf SupplierEditSavedHandler
        End Sub

        #End Region

        #Region " Cache Invalidation "

        'TODO: edit "SupplierEdit.vb", uncomment the "OnDeserialized" method and add the following line:
        'TODO:     AddHandler SupplierEditSaved, AddressOf SupplierEditSavedHandler

        Private Sub SupplierEditSavedHandler(sender As Object, e As Csla.Core.SavedEventArgs)
            '' this runs on the client
            SupplierList.InvalidateCache()
        End Sub

        ''' <summary>
        ''' Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        ''' </summary>
        ''' <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(e As Csla.DataPortalEventArgs)
            If ApplicationContext.ExecutionLocation = ApplicationContext.ExecutionLocations.Server AndAlso
               e.Operation = DataPortalOperations.Update Then
                '' this runs on the server
                SupplierList.InvalidateCache()
            End If
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="SupplierEdit"/> object properties.
        ''' </summary>
        <RunLocal>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(AddressLine1Property, Nothing)
            LoadProperty(AddressLine2Property, Nothing)
            LoadProperty(ZipCodeProperty, Nothing)
            LoadProperty(StateProperty, Nothing)
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="SupplierEdit"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="supplierId">The Supplier Id.</param>
        Protected Sub DataPortal_Fetch(supplierId As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.InvoicesConnection, False)
                Using cmd = New SqlCommand("dbo.GetSupplierEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, supplierId)
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
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Loads a <see cref="SupplierEdit"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(SupplierIdProperty, dr.GetInt32("SupplierId"))
            LoadProperty(NameProperty, dr.GetString("Name"))
            LoadProperty(AddressLine1Property, If(dr.IsDBNull("AddressLine1"), Nothing, dr.GetString("AddressLine1")))
            LoadProperty(AddressLine2Property, If(dr.IsDBNull("AddressLine2"), Nothing, dr.GetString("AddressLine2")))
            LoadProperty(ZipCodeProperty, If(dr.IsDBNull("ZipCode"), Nothing, dr.GetString("ZipCode")))
            LoadProperty(StateProperty, If(dr.IsDBNull("State"), Nothing, dr.GetString("State")))
            LoadProperty(CountryProperty, DirectCast(dr.GetValue("Country"), Byte?))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="SupplierEdit"/> object in the database.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Overrides Sub DataPortal_Insert()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.InvoicesConnection, False)
                Using cmd = New SqlCommand("dbo.AddSupplierEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@SupplierId", ReadProperty(SupplierIdProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@AddressLine1", If(ReadProperty(AddressLine1Property) Is Nothing, DBNull.Value, ReadProperty(AddressLine1Property))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@AddressLine2", If(ReadProperty(AddressLine2Property) Is Nothing, DBNull.Value, ReadProperty(AddressLine2Property))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@ZipCode", If(ReadProperty(ZipCodeProperty) Is Nothing, DBNull.Value, ReadProperty(ZipCodeProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@State", If(ReadProperty(StateProperty) Is Nothing, DBNull.Value, ReadProperty(StateProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@Country", If(ReadProperty(CountryProperty) Is Nothing, DBNull.Value, ReadProperty(CountryProperty).Value)).DbType = DbType.Byte
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
        ''' Updates in the database all changes made to the <see cref="SupplierEdit"/> object.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.InvoicesConnection, False)
                Using cmd = New SqlCommand("dbo.UpdateSupplierEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@SupplierId", ReadProperty(SupplierIdProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@AddressLine1", If(ReadProperty(AddressLine1Property) Is Nothing, DBNull.Value, ReadProperty(AddressLine1Property))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@AddressLine2", If(ReadProperty(AddressLine2Property) Is Nothing, DBNull.Value, ReadProperty(AddressLine2Property))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@ZipCode", If(ReadProperty(ZipCodeProperty) Is Nothing, DBNull.Value, ReadProperty(ZipCodeProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@State", If(ReadProperty(StateProperty) Is Nothing, DBNull.Value, ReadProperty(StateProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@Country", If(ReadProperty(CountryProperty) Is Nothing, DBNull.Value, ReadProperty(CountryProperty).Value)).DbType = DbType.Byte
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

        #Region " Saved Event "

        'TODO: edit "SupplierEdit.vb", uncomment the "OnDeserialized" method and add the following line:
        'TODO:     AddHandler Saved, AddressOf OnSupplierEditSaved

        Private Sub OnSupplierEditSaved(sender As Object, e As Csla.Core.SavedEventArgs)
                RaiseEvent SupplierEditSaved(sender, e)
        End Sub

        ''' <summary> Use this event to signal a <see cref="SupplierEdit"/> object was saved.</summary>
        Public Shared Event SupplierEditSaved As EventHandler(Of Csla.Core.SavedEventArgs)

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting all defaults for object creation.
        ''' </summary>
        Partial Private Sub OnCreate(args As DataPortalHookArgs)
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
