Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Codisa.InterwayDocs.Business

    ''' <summary>
    ''' IncomingInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="IncomingInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="IncomingBook"/> collection.
    ''' </remarks>
    <Serializable>
    Public Partial Class IncomingInfo
        Inherits ReadOnlyBase(Of IncomingInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="RegisterId"/> property.
        ''' </summary>
        Public Shared ReadOnly RegisterIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.RegisterId, "Register Id")
        ''' <summary>
        ''' Gets the Register Id.
        ''' </summary>
        ''' <value>The Register Id.</value>
        Public ReadOnly Property RegisterId As Integer
            Get
                Return GetProperty(RegisterIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RegisterDate"/> property.
        ''' </summary>
        Public Shared ReadOnly RegisterDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.RegisterDate, "Register Date")
        ''' <summary>
        ''' Gets the Register Date.
        ''' </summary>
        ''' <value>The Register Date.</value>
        Public ReadOnly Property RegisterDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(RegisterDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocumentType"/> property.
        ''' </summary>
        Public Shared ReadOnly DocumentTypeProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocumentType, "Document Type")
        ''' <summary>
        ''' Gets the Document Type.
        ''' </summary>
        ''' <value>The Document Type.</value>
        Public ReadOnly Property DocumentType As String
            Get
                Return GetProperty(DocumentTypeProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocumentReference"/> property.
        ''' </summary>
        Public Shared ReadOnly DocumentReferenceProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocumentReference, "Document Reference")
        ''' <summary>
        ''' Gets the Document Reference.
        ''' </summary>
        ''' <value>The Document Reference.</value>
        Public ReadOnly Property DocumentReference As String
            Get
                Return GetProperty(DocumentReferenceProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocumentEntity"/> property.
        ''' </summary>
        Public Shared ReadOnly DocumentEntityProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocumentEntity, "Document Entity")
        ''' <summary>
        ''' Gets the Document Entity.
        ''' </summary>
        ''' <value>The Document Entity.</value>
        Public ReadOnly Property DocumentEntity As String
            Get
                Return GetProperty(DocumentEntityProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocumentDept"/> property.
        ''' </summary>
        Public Shared ReadOnly DocumentDeptProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocumentDept, "Document Dept")
        ''' <summary>
        ''' Gets the Document Dept.
        ''' </summary>
        ''' <value>The Document Dept.</value>
        Public ReadOnly Property DocumentDept As String
            Get
                Return GetProperty(DocumentDeptProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocumentClass"/> property.
        ''' </summary>
        Public Shared ReadOnly DocumentClassProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocumentClass, "Document Class")
        ''' <summary>
        ''' Gets the Document Class.
        ''' </summary>
        ''' <value>The Document Class.</value>
        Public ReadOnly Property DocumentClass As String
            Get
                Return GetProperty(DocumentClassProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocumentDate"/> property.
        ''' </summary>
        Public Shared ReadOnly DocumentDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.DocumentDate, "Document Date")
        ''' <summary>
        ''' Gets the Document Date.
        ''' </summary>
        ''' <value>The Document Date.</value>
        Public ReadOnly Property DocumentDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(DocumentDateProperty)
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
        ''' Maintains metadata about <see cref="SenderName"/> property.
        ''' </summary>
        Public Shared ReadOnly SenderNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.SenderName, "Sender Name")
        ''' <summary>
        ''' Gets the Sender Name.
        ''' </summary>
        ''' <value>The Sender Name.</value>
        Public ReadOnly Property SenderName As String
            Get
                Return GetProperty(SenderNameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ReceptionDate"/> property.
        ''' </summary>
        Public Shared ReadOnly ReceptionDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.ReceptionDate, "Reception Date")
        ''' <summary>
        ''' Gets the Reception Date.
        ''' </summary>
        ''' <value>The Reception Date.</value>
        Public ReadOnly Property ReceptionDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(ReceptionDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RoutedTo"/> property.
        ''' </summary>
        Public Shared ReadOnly RoutedToProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.RoutedTo, "Routed To")
        ''' <summary>
        ''' Gets the Routed To.
        ''' </summary>
        ''' <value>The Routed To.</value>
        Public ReadOnly Property RoutedTo As String
            Get
                Return GetProperty(RoutedToProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Notes"/> property.
        ''' </summary>
        Public Shared ReadOnly NotesProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Notes, "Notes")
        ''' <summary>
        ''' Gets the Notes.
        ''' </summary>
        ''' <value>The Notes.</value>
        Public ReadOnly Property Notes As String
            Get
                Return GetProperty(NotesProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ArchiveLocation"/> property.
        ''' </summary>
        Public Shared ReadOnly ArchiveLocationProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.ArchiveLocation, "Archive Location")
        ''' <summary>
        ''' Gets the Archive Location.
        ''' </summary>
        ''' <value>The Archive Location.</value>
        Public ReadOnly Property ArchiveLocation As String
            Get
                Return GetProperty(ArchiveLocationProperty)
            End Get
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="IncomingInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="IncomingInfo"/> object.</returns>
        Friend Shared Function GetIncomingInfo(dr As SafeDataReader) As IncomingInfo
            Dim obj As IncomingInfo = New IncomingInfo()
            obj.Fetch(dr)
            Return obj
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="IncomingInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="IncomingInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(RegisterIdProperty, dr.GetInt32("RegisterId"))
            LoadProperty(RegisterDateProperty, dr.GetSmartDate("RegisterDate", True))
            LoadProperty(DocumentTypeProperty, dr.GetString("DocumentType"))
            LoadProperty(DocumentReferenceProperty, dr.GetString("DocumentReference"))
            LoadProperty(DocumentEntityProperty, dr.GetString("DocumentEntity"))
            LoadProperty(DocumentDeptProperty, dr.GetString("DocumentDept"))
            LoadProperty(DocumentClassProperty, dr.GetString("DocumentClass"))
            LoadProperty(DocumentDateProperty, dr.GetSmartDate("DocumentDate", True))
            LoadProperty(SubjectProperty, dr.GetString("Subject"))
            LoadProperty(SenderNameProperty, dr.GetString("SenderName"))
            LoadProperty(ReceptionDateProperty, dr.GetSmartDate("ReceptionDate", True))
            LoadProperty(RoutedToProperty, dr.GetString("RoutedTo"))
            LoadProperty(NotesProperty, dr.GetString("Notes"))
            LoadProperty(ArchiveLocationProperty, dr.GetString("ArchiveLocation"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after the low level fetch operation, before the data reader is destroyed.
        ''' </summary>
        Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace
