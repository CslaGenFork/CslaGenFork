Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' CustomerEdit (editable root object).<br/>
    ''' This is a generated base class of <see cref="CustomerEdit"/> business object.
    ''' </summary>
    <Serializable()>
    Public Partial Class CustomerEdit
        Inherits BusinessBase(Of CustomerEdit)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="CustomerId"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly CustomerIdProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.CustomerId, "Customer Id")
        ''' <summary>
        ''' Gets or sets the Customer Id.
        ''' </summary>
        ''' <value>The Customer Id.</value>
        Public Property CustomerId As String
            Get
                Return GetProperty(CustomerIdProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(CustomerIdProperty, value)
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
        ''' Maintains metadata about <see cref="FiscalNumber"/> property.
        ''' </summary>
        Public Shared ReadOnly FiscalNumberProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.FiscalNumber, "Fiscal Number")
        ''' <summary>
        ''' Gets or sets the Fiscal Number.
        ''' </summary>
        ''' <value>The Fiscal Number.</value>
        Public Property FiscalNumber As String
            Get
                Return GetProperty(FiscalNumberProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(FiscalNumberProperty, value)
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
        ''' Maintains metadata about <see cref="Coutry"/> property.
        ''' </summary>
        Public Shared ReadOnly CoutryProperty As PropertyInfo(Of Byte?) = RegisterProperty(Of Byte?)(Function(p) p.Coutry, "Coutry")
        ''' <summary>
        ''' Gets or sets the Coutry.
        ''' </summary>
        ''' <value>The Coutry.</value>
        Public Property Coutry As Byte?
            Get
                Return GetProperty(CoutryProperty)
            End Get
            Set(ByVal value As Byte?)
                SetProperty(CoutryProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="CustomerEdit"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="CustomerEdit"/> object.</returns>
        Public Shared Function NewCustomerEdit() As CustomerEdit
            Return DataPortal.Create(Of CustomerEdit)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="CustomerEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="customerId">The CustomerId parameter of the CustomerEdit to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="CustomerEdit"/> object.</returns>
        Public Shared Function GetCustomerEdit(customerId As String) As CustomerEdit
            Return DataPortal.Fetch(Of CustomerEdit)(customerId)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="CustomerEdit"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewCustomerEdit(callback As EventHandler(Of DataPortalResult(Of CustomerEdit)))
            DataPortal.BeginCreate(Of CustomerEdit)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="CustomerEdit"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="customerId">The CustomerId parameter of the CustomerEdit to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetCustomerEdit(customerId As String, ByVal callback As EventHandler(Of DataPortalResult(Of CustomerEdit)))
            DataPortal.BeginFetch(Of CustomerEdit)(customerId, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="CustomerEdit"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnCustomerEditSaved
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="CustomerEdit"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(FiscalNumberProperty, Nothing)
            LoadProperty(AddressLine1Property, Nothing)
            LoadProperty(AddressLine2Property, Nothing)
            LoadProperty(ZipCodeProperty, Nothing)
            LoadProperty(StateProperty, Nothing)
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="CustomerEdit"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="customerId">The Customer Id.</param>
        Protected Sub DataPortal_Fetch(customerId As String)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.GetCustomerEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@CustomerId", customerId).DbType = DbType.StringFixedLength
                    Dim args As New DataPortalHookArgs(cmd, customerId)
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
        ''' Loads a <see cref="CustomerEdit"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(CustomerIdProperty, dr.GetString("CustomerId"))
            LoadProperty(NameProperty, dr.GetString("Name"))
            LoadProperty(FiscalNumberProperty, If(dr.IsDBNull("FiscalNumber"), Nothing, dr.GetString("FiscalNumber")))
            LoadProperty(AddressLine1Property, If(dr.IsDBNull("AddressLine1"), Nothing, dr.GetString("AddressLine1")))
            LoadProperty(AddressLine2Property, If(dr.IsDBNull("AddressLine2"), Nothing, dr.GetString("AddressLine2")))
            LoadProperty(ZipCodeProperty, If(dr.IsDBNull("ZipCode"), Nothing, dr.GetString("ZipCode")))
            LoadProperty(StateProperty, If(dr.IsDBNull("State"), Nothing, dr.GetString("State")))
            LoadProperty(CoutryProperty, DirectCast(dr.GetValue("Coutry"), Byte?))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="CustomerEdit"/> object in the database.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Overrides Sub DataPortal_Insert()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.AddCustomerEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@CustomerId", ReadProperty(CustomerIdProperty)).DbType = DbType.StringFixedLength
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@FiscalNumber", If(ReadProperty(FiscalNumberProperty) Is Nothing, DBNull.Value, ReadProperty(FiscalNumberProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@AddressLine1", If(ReadProperty(AddressLine1Property) Is Nothing, DBNull.Value, ReadProperty(AddressLine1Property))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@AddressLine2", If(ReadProperty(AddressLine2Property) Is Nothing, DBNull.Value, ReadProperty(AddressLine2Property))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@ZipCode", If(ReadProperty(ZipCodeProperty) Is Nothing, DBNull.Value, ReadProperty(ZipCodeProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@State", If(ReadProperty(StateProperty) Is Nothing, DBNull.Value, ReadProperty(StateProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@Coutry", If(ReadProperty(CoutryProperty) Is Nothing, DBNull.Value, ReadProperty(CoutryProperty).Value)).DbType = DbType.Byte
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="CustomerEdit"/> object.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.UpdateCustomerEdit", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@CustomerId", ReadProperty(CustomerIdProperty)).DbType = DbType.StringFixedLength
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@FiscalNumber", If(ReadProperty(FiscalNumberProperty) Is Nothing, DBNull.Value, ReadProperty(FiscalNumberProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@AddressLine1", If(ReadProperty(AddressLine1Property) Is Nothing, DBNull.Value, ReadProperty(AddressLine1Property))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@AddressLine2", If(ReadProperty(AddressLine2Property) Is Nothing, DBNull.Value, ReadProperty(AddressLine2Property))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@ZipCode", If(ReadProperty(ZipCodeProperty) Is Nothing, DBNull.Value, ReadProperty(ZipCodeProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@State", If(ReadProperty(StateProperty) Is Nothing, DBNull.Value, ReadProperty(StateProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@Coutry", If(ReadProperty(CoutryProperty) Is Nothing, DBNull.Value, ReadProperty(CoutryProperty).Value)).DbType = DbType.Byte
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
            End Using
        End Sub

        #End Region

        #Region " Saved Event "

        'TODO: edit "CustomerEdit.vb", uncomment the "OnDeserialized" method and add the following line:
        'TODO:     AddHandler Saved, AddressOf OnCustomerEditSaved

        Private Sub OnCustomerEditSaved(sender As Object, e As Csla.Core.SavedEventArgs)
                RaiseEvent CustomerEditSaved(sender, e)
        End Sub

        ''' <summary> Use this event to signal a <see cref="CustomerEdit"/> object was saved.</summary>
        Public Shared Event CustomerEditSaved As EventHandler(Of Csla.Core.SavedEventArgs)

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
