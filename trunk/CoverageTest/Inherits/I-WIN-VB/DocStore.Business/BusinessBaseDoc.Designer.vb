Imports System
Imports System.Diagnostics.CodeAnalysis
Imports Csla

Namespace DocStore.Business
    ''' <summary>
    ''' BusinessBaseDoc.<br/>
    ''' This is a generated abstract base class of <see cref="BusinessBaseDoc"/>.
    ''' </summary>
    ''' <remarks>
    ''' This class contains two child collections:<br/>
    ''' - <see cref="Contents"/> of type <see cref="DocContentList"/> (1:M relation to <see cref="DocContentInfo"/>)
    ''' </remarks>
    <Serializable>
    Public MustInherit Partial Class BusinessBaseDoc(Of T As BusinessBaseDoc(Of T))
        Inherits BusinessBase(Of T)
        #Region "Business Properties"

        ''' <summary>
        ''' Maintains metadata about <see cref="Secret"/> property.
        ''' </summary>
        <SuppressMessage("ReSharper", "StaticMemberInGenericType")>
        Public Shared ReadOnly SecretProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Secret, "Secret")
        ''' <summary>
        ''' Gets or sets the Secret.
        ''' </summary>
        ''' <value>The Secret.</value>
        Public Property Secret() As String
            Get
                Return GetProperty(SecretProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(SecretProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="ViewContent"/> property.
        ''' </summary>
        <SuppressMessage("ReSharper", "StaticMemberInGenericType")>
        Public Shared ReadOnly ViewContentProperty As PropertyInfo(Of DocContentRO) = RegisterProperty(Of DocContentRO)(Function(p) p.ViewContent, "View Content", RelationshipTypes.Child)
        ''' <summary>
        ''' Gets the View Content ("parent load" child property).
        ''' </summary>
        ''' <value>The View Content.</value>
        Public Property ViewContent() As DocContentRO
            Get
                Return GetProperty(ViewContentProperty)
            End Get
            Private Set(ByVal value As DocContentRO)
                LoadProperty(ViewContentProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="Contents"/> property.
        ''' </summary>
        <SuppressMessage("ReSharper", "StaticMemberInGenericType")>
        Public Shared ReadOnly ContentsProperty As PropertyInfo(Of DocContentList) = RegisterProperty(Of DocContentList)(Function(p) p.Contents, "Contents", RelationshipTypes.Child)
        ''' <summary>
        ''' Gets the Contents ("parent load" child property).
        ''' </summary>
        ''' <value>The Contents.</value>
        Public Property Contents() As DocContentList
            Get
                Return GetProperty(ContentsProperty)
            End Get
            Private Set(ByVal value As DocContentList)
                LoadProperty(ContentsProperty, value)
            End Set
        End Property

        #End Region
    End Class
End Namespace