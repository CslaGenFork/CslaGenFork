'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    CircInfo
' ObjectType:  CircInfo
' CSLAType:    ReadOnlyObject

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports UsingLibrary

Namespace DocStore.Business.Circulations

    ''' <summary>
    ''' Circulation of document or folder (read only object).<br/>
    ''' This is a generated base class of <see cref="CircInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="CircList"/> collection.
    ''' </remarks>
    <Serializable()>
    Public Partial Class CircInfo
        Inherits MyReadOnlyBase(Of CircInfo)
        Implements IHaveInterface, IHaveGenericInterface(Of CircInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="CircID"/> property.
        ''' </summary>
        Public Shared ReadOnly CircIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.CircID, "Circ ID", -1)
        ''' <summary>
        ''' Gets the Circ ID.
        ''' </summary>
        ''' <value>The Circ ID.</value>
        Public ReadOnly Property CircID As Integer
            Get
                Return GetProperty(CircIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocID"/> property.
        ''' </summary>
        Public Shared ReadOnly DocIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.DocID, "Doc ID", New Integer?(Nothing))
        ''' <summary>
        ''' Gets the Doc ID.
        ''' </summary>
        ''' <value>The Doc ID.</value>
        Public ReadOnly Property DocID As Integer?
            Get
                Return GetProperty(DocIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="FolderID"/> property.
        ''' </summary>
        Public Shared ReadOnly FolderIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.FolderID, "Folder ID", New Integer?(Nothing))
        ''' <summary>
        ''' Gets the Folder ID.
        ''' </summary>
        ''' <value>The Folder ID.</value>
        Public ReadOnly Property FolderID As Integer?
            Get
                Return GetProperty(FolderIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="NeedsReply"/> property.
        ''' </summary>
        Public Shared ReadOnly NeedsReplyProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.NeedsReply, "Needs Reply")
        ''' <summary>
        ''' Gets the Needs Reply.
        ''' </summary>
        ''' <value><c>True</c> if Needs Reply; otherwise, <c>false</c>.</value>
        Public ReadOnly Property NeedsReply As Boolean
            Get
                Return GetProperty(NeedsReplyProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="NeedsReplyDecision"/> property.
        ''' </summary>
        Public Shared ReadOnly NeedsReplyDecisionProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.NeedsReplyDecision, "Needs Reply Decision")
        ''' <summary>
        ''' Gets the Needs Reply Decision.
        ''' </summary>
        ''' <value><c>True</c> if Needs Reply Decision; otherwise, <c>false</c>.</value>
        Public ReadOnly Property NeedsReplyDecision As Boolean
            Get
                Return GetProperty(NeedsReplyDecisionProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CircTypeTag"/> property.
        ''' </summary>
        Public Shared ReadOnly CircTypeTagProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.CircTypeTag, "Circ Type Tag")
        ''' <summary>
        ''' Gets the Circ Type Tag.
        ''' </summary>
        ''' <value>The Circ Type Tag.</value>
        Public ReadOnly Property CircTypeTag As String
            Get
                Return GetProperty(CircTypeTagProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="SenderEntityID"/> property.
        ''' </summary>
        Public Shared ReadOnly SenderEntityIDProperty As PropertyInfo(Of Integer?) = RegisterProperty(Of Integer?)(Function(p) p.SenderEntityID, "Sender Entity ID", New Integer?(Nothing))
        ''' <summary>
        ''' Gets the Sender Entity ID.
        ''' </summary>
        ''' <value>The Sender Entity ID.</value>
        Public ReadOnly Property SenderEntityID As Integer?
            Get
                Return GetProperty(SenderEntityIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="SentDateTime"/> property.
        ''' </summary>
        Public Shared ReadOnly SentDateTimeProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.SentDateTime, "Sent Date Time")
        ''' <summary>
        ''' Gets the Sent Date Time.
        ''' </summary>
        ''' <value>The Sent Date Time.</value>
        Public ReadOnly Property SentDateTime As SmartDate
            Get
                Return GetProperty(SentDateTimeProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DaysToReply"/> property.
        ''' </summary>
        Public Shared ReadOnly DaysToReplyProperty As PropertyInfo(Of Short) = RegisterProperty(Of Short)(Function(p) p.DaysToReply, "Days To Reply")
        ''' <summary>
        ''' Gets the Days To Reply.
        ''' </summary>
        ''' <value>The Days To Reply.</value>
        Public ReadOnly Property DaysToReply As Short
            Get
                Return GetProperty(DaysToReplyProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DaysToLive"/> property.
        ''' </summary>
        Public Shared ReadOnly DaysToLiveProperty As PropertyInfo(Of Short) = RegisterProperty(Of Short)(Function(p) p.DaysToLive, "Days To Live")
        ''' <summary>
        ''' Gets the Days To Live.
        ''' </summary>
        ''' <value>The Days To Live.</value>
        Public ReadOnly Property DaysToLive As Short
            Get
                Return GetProperty(DaysToLiveProperty)
            End Get
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="CircInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="CircInfo"/> object.</returns>
        Friend Shared Function GetCircInfo(dr As SafeDataReader) As CircInfo
            Dim obj As CircInfo = New CircInfo()
            obj.Fetch(dr)
            Return obj
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="CircInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="CircInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(CircIDProperty, dr.GetInt32("CircID"))
            LoadProperty(DocIDProperty, DirectCast(dr.GetValue("DocID"), Integer?))
            LoadProperty(FolderIDProperty, DirectCast(dr.GetValue("FolderID"), Integer?))
            LoadProperty(NeedsReplyProperty, dr.GetBoolean("NeedsReply"))
            LoadProperty(NeedsReplyDecisionProperty, dr.GetBoolean("NeedsReplyDecision"))
            LoadProperty(CircTypeTagProperty, dr.GetString("CircTypeTag"))
            LoadProperty(SenderEntityIDProperty, DirectCast(dr.GetValue("SenderEntityID"), Integer?))
            LoadProperty(SentDateTimeProperty, dr.GetSmartDate("SentDateTime", True))
            LoadProperty(DaysToReplyProperty, dr.GetInt16("DaysToReply"))
            LoadProperty(DaysToLiveProperty, dr.GetInt16("DaysToLive"))
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
