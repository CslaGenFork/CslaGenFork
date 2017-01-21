'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    UserInfo
' ObjectType:  UserInfo
' CSLAType:    ReadOnlyObject

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules

Namespace DocStore.Business.Admin

    ''' <summary>
    ''' User basic information (read only object).<br/>
    ''' This is a generated base class of <see cref="UserInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="UserList"/> collection.
    ''' </remarks>
    <Serializable()>
    Partial Public Class UserInfo
        Inherits ReadOnlyBase(Of UserInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="UserID"/> property.
        ''' </summary>
        Public Shared ReadOnly UserIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.UserID, "User ID", -1)
        ''' <summary>
        ''' Gets the User ID.
        ''' </summary>
        ''' <value>The User ID.</value>
        Public ReadOnly Property UserID As Integer
            Get
                Return GetProperty(UserIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Name"/> property.
        ''' </summary>
        Public Shared ReadOnly NameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Name, "Name")
        ''' <summary>
        ''' Gets the Name.
        ''' </summary>
        ''' <value>The Name.</value>
        Public ReadOnly Property Name As String
            Get
                Return GetProperty(NameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Login"/> property.
        ''' </summary>
        Public Shared ReadOnly LoginProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Login, "Login")
        ''' <summary>
        ''' Gets the Login.
        ''' </summary>
        ''' <value>The Login.</value>
        Public ReadOnly Property Login As String
            Get
                Return GetProperty(LoginProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Email"/> property.
        ''' </summary>
        Public Shared ReadOnly EmailProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Email, "Email")
        ''' <summary>
        ''' Gets the Email.
        ''' </summary>
        ''' <value>The Email.</value>
        Public ReadOnly Property Email As String
            Get
                Return GetProperty(EmailProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="IsActive"/> property.
        ''' </summary>
        Public Shared ReadOnly IsActiveProperty As PropertyInfo(Of Boolean?) = RegisterProperty(Of Boolean?)(Function(p) p.IsActive, "IsActive", New Boolean?(Nothing))
        ''' <summary>
        ''' Gets the active or deleted state.
        ''' </summary>
        ''' <value><c>True</c> if IsActive; <c>false</c> if not IsActive; otherwise, <c>null</c>.</value>
        Public ReadOnly Property IsActive As Boolean?
            Get
                Return GetProperty(IsActiveProperty)
            End Get
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="UserInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="UserInfo"/> object.</returns>
        Friend Shared Function GetUserInfo(dr As SafeDataReader) As UserInfo
            Dim obj As UserInfo = New UserInfo()
            obj.Fetch(dr)
            Return obj
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="UserInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(UserInfo), New IsInRole(AuthorizationActions.GetObject, "User"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can retrieve UserInfo's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(UserInfo))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="UserInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(UserIDProperty, dr.GetInt32("UserID"))
            LoadProperty(NameProperty, dr.GetString("Name"))
            LoadProperty(LoginProperty, dr.GetString("Login"))
            LoadProperty(EmailProperty, dr.GetString("Email"))
            LoadProperty(IsActiveProperty, DirectCast(dr.GetValue("IsActive"), Boolean?))
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
