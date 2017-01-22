Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports System.ComponentModel.DataAnnotations
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' Types of document (editable child object).<br/>
    ''' This is a generated base class of <see cref="DocTypeEdit"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="DocTypeEditColl"/> collection.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Partial Public Class DocTypeEdit
    Inherits BusinessBase(Of DocTypeEdit)
        Implements IHaveInterface

        #Region " Static Fields "

            Private Shared _lastID As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="DocTypeID"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly DocTypeIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocTypeID, "Doc Type ID")
        ''' <summary>
        ''' Gets the Doc Type ID.
        ''' </summary>
        ''' <value>The Doc Type ID.</value>
        Public ReadOnly Property DocTypeID As Integer
            Get
                Return GetProperty(DocTypeIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocTypeName"/> property.
        ''' </summary>
        Public Shared ReadOnly DocTypeNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocTypeName, "Doc Type Name")
        ''' <summary>
        ''' Gets or sets the Doc Type Name.
        ''' </summary>
        ''' <value>The Doc Type Name.</value>
        <Required(AllowEmptyStrings := false, ErrorMessage := "Must fill.")>
        Public Property DocTypeName As String
            Get
                Return GetProperty(DocTypeNameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(DocTypeNameProperty, value)
            End Set
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocTypeEdit"/> class.
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
        ''' Loads default values for the <see cref="DocTypeEdit"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub Child_Create()
            LoadProperty(DocTypeIDProperty, System.Threading.Interlocked.Decrement(_lastID))
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.Child_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="DocTypeEdit"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"))
            LoadProperty(DocTypeNameProperty, dr.GetString("DocTypeName"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="DocTypeEdit"/> object in the database.
        ''' </summary>
        Private Sub Child_Insert()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("AddDocTypeEdit", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@DocTypeName", ReadProperty(DocTypeNameProperty)).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(DocTypeIDProperty, DirectCast(cmd.Parameters("@DocTypeID").Value, Integer))
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="DocTypeEdit"/> object.
        ''' </summary>
        Private Sub Child_Update()
            If Not IsDirty
                return
            End If

            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("UpdateDocTypeEdit", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocTypeName", ReadProperty(DocTypeNameProperty)).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="DocTypeEdit"/> object from database.
        ''' </summary>
        Private Sub Child_DeleteSelf()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("DeleteDocTypeEdit", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32
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
