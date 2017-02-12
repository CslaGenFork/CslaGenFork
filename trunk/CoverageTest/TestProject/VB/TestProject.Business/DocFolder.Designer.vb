Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' Folder where this document is archived (editable child object).<br/>
    ''' This is a generated base class of <see cref="DocFolder"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="DocFolderColl"/> collection.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Public Partial Class DocFolder
        Inherits MyBusinessBase(Of DocFolder)
        Implements IHaveInterface

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="FolderID"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly FolderIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.FolderID, "Folder ID")
        ''' <summary>
        ''' Gets the Folder ID.
        ''' </summary>
        ''' <value>The Folder ID.</value>
        Public ReadOnly Property FolderID As Integer
            Get
                Return GetProperty(FolderIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="FolderRef"/> property.
        ''' </summary>
        Public Shared ReadOnly FolderRefProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.FolderRef, "Folder Ref")
        ''' <summary>
        ''' Gets the Folder Ref.
        ''' </summary>
        ''' <value>The Folder Ref.</value>
        Public ReadOnly Property FolderRef As String
            Get
                Return GetProperty(FolderRefProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Year"/> property.
        ''' </summary>
        Public Shared ReadOnly YearProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.Year, "Folder Year")
        ''' <summary>
        ''' Gets the Folder Year.
        ''' </summary>
        ''' <value>The Folder Year.</value>
        Public ReadOnly Property Year As Integer
            Get
                Return GetProperty(YearProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Subject"/> property.
        ''' </summary>
        Public Shared ReadOnly SubjectProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Subject, "Subject")
        ''' <summary>
        ''' Gets the Subject.
        ''' </summary>
        ''' <value>The Subject.</value>
        Public ReadOnly Property Subject As String
            Get
                Return GetProperty(SubjectProperty)
            End Get
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocFolder"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            ' show the framework that this is a child object
            MarkAsChild()
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(DocFolder), New IsInRole(AuthorizationActions.CreateObject, "Archivist"))
            BusinessRules.AddRule(GetType(DocFolder), New IsInRole(AuthorizationActions.GetObject, "User"))
            BusinessRules.AddRule(GetType(DocFolder), New IsInRole(AuthorizationActions.EditObject, "Author"))
            BusinessRules.AddRule(GetType(DocFolder), New IsInRole(AuthorizationActions.DeleteObject, "Admin", "Manager"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can create a new DocFolder object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanAddObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, GetType(DocFolder))
        End Function

        ''' <summary>
        ''' Checks if the current user can retrieve DocFolder's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(DocFolder))
        End Function

        ''' <summary>
        ''' Checks if the current user can change DocFolder's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanEditObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, GetType(DocFolder))
        End Function

        ''' <summary>
        ''' Checks if the current user can delete a DocFolder object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanDeleteObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, GetType(DocFolder))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="DocFolder"/> object properties, based on given criteria.
        ''' </summary>
        ''' <param name="folderID">The create criteria.</param>
        Protected Overloads Sub DataPortal_Create(folderID As Integer)
            LoadProperty(FolderIDProperty, folderID)
            Dim args As New DataPortalHookArgs(folderID)
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="DocFolder"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(FolderIDProperty, dr.GetInt32("FolderID"))
            LoadProperty(FolderRefProperty, dr.GetString("FolderRef"))
            LoadProperty(YearProperty, dr.GetInt32("Year"))
            LoadProperty(SubjectProperty, dr.GetString("Subject"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="DocFolder"/> object in the database.
        ''' </summary>
        ''' <param name="parent">The parent object.</param>
        Private Sub Child_Insert(parent As Doc)
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("AddDocFolderRelation", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="DocFolder"/> object.
        ''' </summary>
        ''' <param name="parent">The parent object.</param>
        Private Sub Child_Update(parent As Doc)
            If Not IsDirty
                return
            End If

            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("UpdateDocFolderRelation", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="DocFolder"/> object from database.
        ''' </summary>
        ''' <param name="parent">The parent object.</param>
        Private Sub Child_DeleteSelf(parent As Doc)
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("DeleteDocFolderRelation", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).DbType = DbType.Int32
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
