Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports UsingClass

Namespace TestProject.Business

    ''' <summary>
    ''' Types of document (dynamic root object).<br/>
    ''' This is a generated base class of <see cref="DocTypeDynamic"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="DocTypeDynamicCollection"/> collection.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Partial Public Class DocTypeDynamic
        Inherits BusinessBase(Of DocTypeDynamic)
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
        ''' Initializes a new instance of the <see cref="DocTypeDynamic"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="DocTypeDynamic"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(DocTypeIDProperty, System.Threading.Interlocked.Decrement(_lastID))
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="DocTypeDynamic"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub DataPortal_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"))
            LoadProperty(DocTypeNameProperty, dr.GetString("DocTypeName"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="DocTypeDynamic"/> object in the database.
        ''' </summary>
        Protected Overrides Sub DataPortal_Insert()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("AddDocTypeDynamic", ctx.Connection)
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
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="DocTypeDynamic"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("UpdateDocTypeDynamic", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocTypeName", ReadProperty(DocTypeNameProperty)).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="DocTypeDynamic"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(DocTypeID)
        End Sub

        ''' <summary>
        ''' Deletes the <see cref="DocTypeDynamic"/> object from database.
        ''' </summary>
        ''' <param name="docTypeID">The delete criteria.</param>
        Protected Sub DataPortal_Delete(docTypeID As Integer)
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("DeleteDocTypeDynamic", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocTypeID", docTypeID).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, docTypeID)
                    OnDeletePre(args)
                    cmd.ExecuteNonQuery()
                    OnDeletePost(args)
                End Using
                ctx.Commit()
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
