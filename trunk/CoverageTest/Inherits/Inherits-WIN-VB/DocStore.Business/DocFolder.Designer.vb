'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocFolder
' ObjectType:  DocFolder
' CSLAType:    EditableChild

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports DocStore.Business.Security
Imports UsingLibrary

Namespace DocStore.Business

    ''' <summary>
    ''' Folder where this document is archived (editable child object).<br/>
    ''' This is a generated base class of <see cref="DocFolder"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="DocFolderColl"/> collection.
    ''' </remarks>
    <Serializable()>
    Public Partial Class DocFolder
        Inherits BusinessBase(Of DocFolder)
        Implements IHaveInterface, IHaveGenericInterface(Of DocFolder)

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

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateDate"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.CreateDate, "Create Date")
        ''' <summary>
        ''' Gets the Create Date.
        ''' </summary>
        ''' <value>The Create Date.</value>
        Public ReadOnly Property CreateDate As SmartDate
            Get
                Return GetProperty(CreateDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateUserIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.CreateUserID, "Create User ID")
        ''' <summary>
        ''' Gets the Create User ID.
        ''' </summary>
        ''' <value>The Create User ID.</value>
        Public ReadOnly Property CreateUserID As Integer
            Get
                Return GetProperty(CreateUserIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeDate"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.ChangeDate, "Change Date")
        ''' <summary>
        ''' Gets the Change Date.
        ''' </summary>
        ''' <value>The Change Date.</value>
        Public ReadOnly Property ChangeDate As SmartDate
            Get
                Return GetProperty(ChangeDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeUserIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.ChangeUserID, "Change User ID")
        ''' <summary>
        ''' Gets the Change User ID.
        ''' </summary>
        ''' <value>The Change User ID.</value>
        Public ReadOnly Property ChangeUserID As Integer
            Get
                Return GetProperty(ChangeUserIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RowVersion"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly RowVersionProperty As PropertyInfo(Of Byte()) = RegisterProperty(Of Byte())(Function(p) p.RowVersion, "Row Version")
        ''' <summary>
        ''' Gets the Row Version.
        ''' </summary>
        ''' <value>The Row Version.</value>
        Public ReadOnly Property RowVersion As Byte()
            Get
                Return GetProperty(RowVersionProperty)
            End Get
        End Property

        ''' <summary>
        ''' Gets the Create User Name.
        ''' </summary>
        ''' <value>The Create User Name.</value>
        Public ReadOnly Property CreateUserName As String
            Get
                Dim result = String.Empty
                If Admin.UserNVL.GetUserNVL().ContainsKey(CreateUserID) Then
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(CreateUserID).Value
                End If
                Return result
            End Get
        End Property

        ''' <summary>
        ''' Gets the Change User Name.
        ''' </summary>
        ''' <value>The Change User Name.</value>
        Public ReadOnly Property ChangeUserName As String
            Get
                Dim result = String.Empty
                If Admin.UserNVL.GetUserNVL().ContainsKey(ChangeUserID) Then
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(ChangeUserID).Value
                End If
                Return result
            End Get
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocFolder"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="folderID">The FolderID of the DocFolder to create.</param>
        ''' <returns>A reference to the created <see cref="DocFolder"/> object.</returns>
        Friend Shared Function NewDocFolder(folderID As Integer) As DocFolder
            Return DataPortal.Create(Of DocFolder)(folderID)
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocFolder"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="DocFolder"/> object.</returns>
        Friend Shared Function GetDocFolder(dr As SafeDataReader) As DocFolder
            Dim obj As DocFolder = New DocFolder()
            ' show the framework that this is a child object
            obj.MarkAsChild()
            obj.Fetch(dr)
            obj.MarkOld()
            ' check all object rules and property rules
            obj.BusinessRules.CheckRules()
            Return obj
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="DocFolder"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="folderID">The FolderID of the DocFolder to create.</param>
        ''' <param name="callback">The completion callback method.</param>
        Friend Shared Sub NewDocFolder(folderID As Integer, callback As EventHandler(Of DataPortalResult(Of DocFolder)))
            DataPortal.BeginCreate(Of DocFolder)(folderID, callback)
        End Sub

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
            LoadProperty(CreateDateProperty, new SmartDate(Date.Now))
            LoadProperty(CreateUserIDProperty, UserInformation.UserId)
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty))
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty))
            LoadProperty(FolderIDProperty, folderID)
            Dim args As New DataPortalHookArgs(folderID)
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="DocFolder"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(FolderIDProperty, dr.GetInt32("FolderID"))
            LoadProperty(FolderRefProperty, dr.GetString("FolderRef"))
            LoadProperty(YearProperty, dr.GetInt32("Year"))
            LoadProperty(SubjectProperty, dr.GetString("Subject"))
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", True))
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"))
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", True))
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"))
            LoadProperty(RowVersionProperty, TryCast(dr.GetValue("RowVersion"), Byte()))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="DocFolder"/> object in the database.
        ''' </summary>
        ''' <param name="parent">The parent object.</param>
        Private Sub Child_Insert(parent As Doc)
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("AddDocFolderRelation", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
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

            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("UpdateDocFolderRelation", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", parent.DocID).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@FolderID", ReadProperty(FolderIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
            End Using
        End Sub

        Private Sub SimpleAuditTrail()
            LoadProperty(ChangeDateProperty, Date.Now)
            LoadProperty(ChangeUserIDProperty, UserInformation.UserId)
            OnPropertyChanged("ChangeUserName")
            If IsNew Then
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty))
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty))
                OnPropertyChanged("CreateUserName")
            End If
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="DocFolder"/> object from database.
        ''' </summary>
        ''' <param name="parent">The parent object.</param>
        Private Sub Child_DeleteSelf(parent As Doc)
            ' audit the object, just in case soft delete is used on this object
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
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
