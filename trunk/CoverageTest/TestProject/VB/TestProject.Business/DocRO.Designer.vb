Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' Documents (read only object).<br/>
    ''' This is a generated base class of <see cref="DocRO"/> business object.
    ''' This class is a root object.
    ''' </summary>
    ''' <remarks>
    ''' This class contains one child collection:<br/>
    ''' - <see cref="Folders"/> of type <see cref="DocFolderCollRO"/> (1:M relation to <see cref="DocFolderRO"/>)
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Public Partial Class DocRO
        Inherits ReadOnlyBase(Of DocRO)
        Implements IHaveInterface

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="DocID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocID, "Doc ID", -1)
        ''' <summary>
        ''' Document ID
        ''' </summary>
        ''' <value>The Doc ID.</value>
        Public ReadOnly Property DocID As Integer
            Get
                Return GetProperty(DocIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocTypeID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocTypeIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocTypeID, "Doc Type ID")
        ''' <summary>
        ''' Document Type ID
        ''' </summary>
        ''' <value>The Doc Type ID.</value>
        Public ReadOnly Property DocTypeID As Integer
            Get
                Return GetProperty(DocTypeIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocRef"/> property.
        ''' </summary>
        Public Shared ReadOnly DocRefProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocRef, "Doc Ref", New String(Nothing))
        ''' <summary>
        ''' Gets the Doc Ref.
        ''' </summary>
        ''' <value>The Doc Ref.</value>
        Public ReadOnly Property DocRef As String
            Get
                Return GetProperty(DocRefProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocDate"/> property.
        ''' </summary>
        Public Shared ReadOnly DocDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.DocDate, "Doc Date")
        ''' <summary>
        ''' Gets the Doc Date.
        ''' </summary>
        ''' <value>The Doc Date.</value>
        Public ReadOnly Property DocDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(DocDateProperty)
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
        ''' Maintains metadata about child <see cref="Folders"/> property.
        ''' </summary>
        Public Shared ReadOnly FoldersProperty As PropertyInfo(Of DocFolderCollRO) = RegisterProperty(Of DocFolderCollRO)(Function(p) p.Folders, "Folders")
        ''' <summary>
        ''' Gets the Folders ("parent load" child property).
        ''' </summary>
        ''' <value>The Folders.</value>
        Public Property Folders As DocFolderCollRO
            Get
                Return GetProperty(FoldersProperty)
            End Get
            Private Set(ByVal value As DocFolderCollRO)
                LoadProperty(FoldersProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocRO"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="docID">The DocID parameter of the DocRO to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="DocRO"/> object.</returns>
        Public Shared Function GetDocRO(docID As Integer) As DocRO
            Return DataPortal.Fetch(Of DocRO)(docID)
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocRO"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocRO"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="docID">The Doc ID.</param>
        Protected Sub DataPortal_Fetch(docID As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("GetDocRO", ctx.Connection)
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
        ''' Loads a <see cref="DocRO"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(DocIDProperty, dr.GetInt32("DocID"))
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"))
            LoadProperty(DocRefProperty, If(dr.IsDBNull("DocRef"), Nothing, dr.GetString("DocRef")))
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
            LoadProperty(FoldersProperty, DataPortal.FetchChild(Of DocFolderCollRO)(dr))
        End Sub

        #End Region

        #Region " DataPortal Hooks "

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

        #End Region

    End Class
End Namespace
