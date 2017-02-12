Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports System.ComponentModel.DataAnnotations
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' Documents (editable root object).<br/>
    ''' This is a generated base class of <see cref="Doc"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class contains one child collection:<br/>
    ''' - <see cref="Folders"/> of type <see cref="DocFolderColl"/> (1:M relation to <see cref="DocFolder"/>)
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Public Partial Class Doc
        Inherits MyBusinessBase(Of Doc)
        Implements IHaveInterface

        #Region " Static Fields "

            Private Shared _lastId As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="DocID"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly DocIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocID, "Doc ID")
        ''' <summary>
        ''' Gets or sets the Document ID.
        ''' </summary>
        ''' <value>The Doc ID.</value>
        Public Property DocID As Integer
            Get
                Return GetProperty(DocIDProperty)
            End Get
            Private Set(ByVal value As Integer)
                SetProperty(DocIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocTypeID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocTypeIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocTypeID, "Doc Type ID")
        ''' <summary>
        ''' Gets or sets the Document Type ID.
        ''' </summary>
        ''' <value>The Doc Type ID.</value>
        Public Property DocTypeID As Integer
            Get
                Return GetProperty(DocTypeIDProperty)
            End Get
            Set(ByVal value As Integer)
                SetProperty(DocTypeIDProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocRef"/> property.
        ''' </summary>
        Public Shared ReadOnly DocRefProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocRef, "Doc Ref")
        ''' <summary>
        ''' Gets or sets the Doc Ref.
        ''' </summary>
        ''' <value>The Doc Ref.</value>
        Public Property DocRef As String
            Get
                Return GetProperty(DocRefProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(DocRefProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocDate"/> property.
        ''' </summary>
        Public Shared ReadOnly DocDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.DocDate, "Doc Date")
        ''' <summary>
        ''' Gets or sets the Doc Date.
        ''' </summary>
        ''' <value>The Doc Date.</value>
        <Required>
        Public Property DocDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(DocDateProperty)
            End Get
            Set(ByVal value As String)
                SetPropertyConvert(Of SmartDate, String)(DocDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Subject"/> property.
        ''' </summary>
        Public Shared ReadOnly SubjectProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Subject, "Subject")
        ''' <summary>
        ''' Gets or sets the Subject.
        ''' </summary>
        ''' <value>The Subject.</value>
        Public Property Subject As String
            Get
                Return GetProperty(SubjectProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(SubjectProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="Folders"/> property.
        ''' </summary>
        Public Shared ReadOnly FoldersProperty As PropertyInfo(Of DocFolderColl) = RegisterProperty(Of DocFolderColl)(Function(p) p.Folders, "Folders", RelationshipTypes.Child)
        ''' <summary>
        ''' Gets the Folders ("parent load" child property).
        ''' </summary>
        ''' <value>The Folders.</value>
        Public Property Folders As DocFolderColl
            Get
                Return GetProperty(FoldersProperty)
            End Get
            Private Set(ByVal value As DocFolderColl)
                LoadProperty(FoldersProperty, value)
            End Set
        End Property

        #End Region

        #Region " BusinessBase(Of T) Overrides "

        ''' <summary>
        ''' Returns a string that represents the current <see cref="Doc"/>
        ''' </summary>
        ''' <returns>A <see cref="System.String"/> that represents this instance.</returns>
        Public Overrides Function ToString() As String
            ' Return the Primary Key as a string
            Return DocID.ToString() + ", " + DocRef.ToString()
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="Doc"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="Doc"/> object.</returns>
        Public Shared Function NewDoc() As Doc
            Return DataPortal.Create(Of Doc)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="Doc"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the Doc to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="Doc"/> object.</returns>
        Public Shared Function GetDoc(docID As Integer) As Doc
            Return DataPortal.Fetch(Of Doc)(docID)
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="Doc"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnDocSaved
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(Doc), New IsInRole(AuthorizationActions.CreateObject, "Author"))
            BusinessRules.AddRule(GetType(Doc), New IsInRole(AuthorizationActions.GetObject, "User"))
            BusinessRules.AddRule(GetType(Doc), New IsInRole(AuthorizationActions.EditObject, "Author"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can create a new Doc object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanAddObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, GetType(Doc))
        End Function

        ''' <summary>
        ''' Checks if the current user can retrieve Doc's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(Doc))
        End Function

        ''' <summary>
        ''' Checks if the current user can change Doc's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanEditObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, GetType(Doc))
        End Function

        ''' <summary>
        ''' Checks if the current user can delete a Doc object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanDeleteObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, GetType(Doc))
        End Function

        #End Region

        #Region " Business Rules and Property Authorization "

        ''' <summary>
        ''' Override this method in your business class to be notified when you need to set up shared business rules.
        ''' </summary>
        ''' <remarks>
        ''' This method is automatically called by CSLA.NET when your object should associate
        ''' per-type validation rules with its properties.
        ''' </remarks>
        Protected Overrides Sub AddBusinessRules()
            MyBase.AddBusinessRules()

            ' Property Business Rules

            ' DocTypeID
            BusinessRules.AddRule(New Required(DocTypeIDProperty))
            ' DocRef
            BusinessRules.AddRule(New MaxLength(DocRefProperty, 35))
            ' DocDate
            BusinessRules.AddRule(New Required(DocDateProperty))
            ' Subject
            BusinessRules.AddRule(New Required(SubjectProperty))
            BusinessRules.AddRule(New MaxLength(SubjectProperty, 255))

            AddBusinessRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom shared business rules.
        ''' </summary>
        Partial Private Sub AddBusinessRulesExtend()
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="Doc"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(DocIDProperty, System.Threading.Interlocked.Decrement(_lastId))
            LoadProperty(DocDateProperty, new SmartDate(DateTime.Today))
            LoadProperty(FoldersProperty, DataPortal.CreateChild(Of DocFolderColl)())
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="Doc"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="docID">The Doc ID.</param>
        Protected Sub DataPortal_Fetch(docID As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("GetDoc", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", docID).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, docID)
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
        ''' Loads a <see cref="Doc"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(DocIDProperty, dr.GetInt32("DocID"))
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"))
            LoadProperty(DocRefProperty, dr.GetString("DocRef"))
            LoadProperty(DocDateProperty, dr.GetSmartDate("DocDate", True))
            LoadProperty(SubjectProperty, dr.GetString("Subject"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Loads child objects from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub FetchChildren(dr As SafeDataReader)
            dr.NextResult()
            LoadProperty(FoldersProperty, DataPortal.FetchChild(Of DocFolderColl)(dr))
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="Doc"/> object in the database.
        ''' </summary>
        Protected Overrides Sub DataPortal_Insert()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("AddDoc", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocRef", ReadProperty(DocRefProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@DocDate", ReadProperty(DocDateProperty).DBValue).DbType = DbType.Date
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(DocIDProperty, DirectCast(cmd.Parameters("@DocID").Value, Integer))
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="Doc"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("UpdateDoc", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocRef", ReadProperty(DocRefProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@DocDate", ReadProperty(DocDateProperty).DBValue).DbType = DbType.Date
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
                ctx.Commit()
            End Using
        End Sub

        #End Region

        #Region " Saved Event "

        Private Sub OnDocSaved(sender As Object, e As Csla.Core.SavedEventArgs)
                RaiseEvent DocSaved(sender, e)
        End Sub

        ''' <summary> Use this event to signal a <see cref="Doc"/> object was saved.</summary>
        Public Shared Event DocSaved As EventHandler(Of Csla.Core.SavedEventArgs)

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
