Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Codisa.InterwayDocs.Business

    ''' <summary>
    ''' OutgoingInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="OutgoingInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="OutgoingBook"/> collection.
    ''' </remarks>
    <Serializable>
    Public Partial Class OutgoingInfo
        Inherits ReadOnlyBase(Of OutgoingInfo)

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
        ''' Maintains metadata about <see cref="SendDate"/> property.
        ''' </summary>
        Public Shared ReadOnly SendDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.SendDate, "Send Date")
        ''' <summary>
        ''' Gets the Send Date.
        ''' </summary>
        ''' <value>The Send Date.</value>
        Public ReadOnly Property SendDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(SendDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RecipientName"/> property.
        ''' </summary>
        Public Shared ReadOnly RecipientNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.RecipientName, "Recipient Name")
        ''' <summary>
        ''' Gets the Recipient Name.
        ''' </summary>
        ''' <value>The Recipient Name.</value>
        Public ReadOnly Property RecipientName As String
            Get
                Return GetProperty(RecipientNameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RecipientTown"/> property.
        ''' </summary>
        Public Shared ReadOnly RecipientTownProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.RecipientTown, "Recipient Town")
        ''' <summary>
        ''' Gets the Recipient Town.
        ''' </summary>
        ''' <value>The Recipient Town.</value>
        Public ReadOnly Property RecipientTown As String
            Get
                Return GetProperty(RecipientTownProperty)
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
        ''' Factory method. Loads a <see cref="OutgoingInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="OutgoingInfo"/> object.</returns>
        Friend Shared Function GetOutgoingInfo(dr As SafeDataReader) As OutgoingInfo
            Dim obj As OutgoingInfo = New OutgoingInfo()
            obj.Fetch(dr)
            Return obj
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="OutgoingInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="OutgoingInfo"/> object from the given SafeDataReader.
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
            LoadProperty(SendDateProperty, dr.GetSmartDate("SendDate", True))
            LoadProperty(RecipientNameProperty, dr.GetString("RecipientName"))
            LoadProperty(RecipientTownProperty, dr.GetString("RecipientTown"))
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
