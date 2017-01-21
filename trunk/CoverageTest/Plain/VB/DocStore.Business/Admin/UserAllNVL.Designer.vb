'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    UserAllNVL
' ObjectType:  UserAllNVL
' CSLAType:    NameValueList

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
    ''' All users (regardless of active status) (name value list).<br/>
    ''' This is a generated base class of <see cref="UserAllNVL"/> business object.
    ''' </summary>
    <Serializable()>
    Partial Public Class UserAllNVL
        Inherits NameValueListBase(Of Integer, String)

        #Region " Private Fields "

        Private Shared _list As UserAllNVL

        #End Region

        #Region " Cache Management Methods "

        ''' <summary>
        ''' Clears the in-memory UserAllNVL cache so it is reloaded on the next request.
        ''' </summary>
        Public Shared Sub InvalidateCache()
            If Not CanGetObject() Then
                Throw New System.Security.SecurityException("User not authorized to load a UserAllNVL.")
          End If
            _list = Nothing
        End Sub

        ''' <summary>
        ''' Used by async loaders to load the cache.
        ''' </summary>
        ''' <param name="lst">The list to cache.</param>
        Friend Shared Sub SetCache(lst As UserAllNVL)
            _list = lst
        End Sub

        Friend Shared ReadOnly Property IsCached As Boolean
            Get
                Return _list IsNot Nothing
            End Get
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="UserAllNVL"/> object.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="UserAllNVL"/> object.</returns>
        Public Shared Function GetUserAllNVL() As UserAllNVL
            If Not CanGetObject() Then
                Throw New System.Security.SecurityException("User not authorized to load a UserAllNVL.")
            End If

            If _list Is Nothing Then
                _list = DataPortal.Fetch(Of UserAllNVL)()
            End If

            Return _list
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="UserAllNVL"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetUserAllNVL(callback As EventHandler(Of DataPortalResult(Of UserAllNVL)))
            If  Not CanGetObject() Then
                Throw New System.Security.SecurityException("User not authorized to load a UserAllNVL.")
            End If

            If _list Is Nothing Then
                DataPortal.BeginFetch(Of UserAllNVL)(Sub(o, e)
                        _list = e.Object
                        callback(o, e)
                    End Sub)
            Else
                callback(Nothing, New DataPortalResult(Of UserAllNVL)(_list, Nothing, Nothing))
            End If
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="UserAllNVL"/> class.
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
            BusinessRules.AddRule(GetType(UserAllNVL), New IsInRole(AuthorizationActions.GetObject, "User"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can retrieve UserAllNVL's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(UserAllNVL))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="UserAllNVL"/> collection from the database or from the cache.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            If IsCached Then
                LoadCachedList()
                Return
            End If

            Using cn = New SqlConnection(Database.DocStoreConnection)
                Using cmd = New SqlCommand("GetUserAllNVL", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cn.Open()
                    Dim args = New DataPortalHookArgs(cmd)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            _list = Me
        End Sub

        Private Sub LoadCachedList()
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AddRange(_list)
            RaiseListChangedEvents = rlce
            IsReadOnly = True
        End Sub

        Private Sub LoadCollection(cmd As SqlCommand)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Using dr = New SafeDataReader(cmd.ExecuteReader())
                While dr.Read()
                    Add(New NameValuePair(
                        dr.GetInt32("UserID"),
                        dr.GetString("Name")))
                End While
            End Using
            RaiseListChangedEvents = rlce
            IsReadOnly = True
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

        #End Region

    End Class
End Namespace
