'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocClassList
' ObjectType:  DocClassList
' CSLAType:    ReadOnlyCollection

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules

Namespace DocStore.Business

    ''' <summary>
    ''' Collection of document class's basic information (read only list).<br/>
    ''' This is a generated base class of <see cref="DocClassList"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DocClassInfo"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class DocClassList
#If WINFORMS Then
        Inherits ReadOnlyBindingListBase(Of DocClassList, DocClassInfo)
#Else
        Inherits ReadOnlyListBase(Of DocClassList, DocClassInfo)
#End If

        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="DocClassInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="docClassID">The DocClassID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocClassInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(docClassID As Integer) As Boolean
            For Each item As DocClassInfo In Me
                If item.DocClassID = docClassID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Find Methods "

        ''' <summary>
        ''' Finds a <see cref="DocClassInfo"/> item of the <see cref="DocClassList"/> collection, based on a given DocClassID.
        ''' </summary>
        ''' <param name="docClassID">The DocClassID.</param>
        ''' <returns>A <see cref="DocClassInfo"/> object.</returns>
        Public Function FindDocClassInfoByDocClassID(docClassID As Integer) As DocClassInfo
            For i As Integer = 0 To Me.Count - 1
                If Me(i).DocClassID.Equals(docClassID) Then
                    Return Me(i)
                End If
            Next i

            Return Nothing
        End Function

        #End Region

        #Region " Private Fields "

        Private Shared _list As DocClassList

        #End Region

        #Region " Cache Management Methods "

        ''' <summary>
        ''' Clears the in-memory DocClassList cache so it is reloaded on the next request.
        ''' </summary>
        Public Shared Sub InvalidateCache()
            _list = Nothing
        End Sub

        ''' <summary>
        ''' Used by async loaders to load the cache.
        ''' </summary>
        ''' <param name="lst">The list to cache.</param>
        Friend Shared Sub SetCache(lst As DocClassList)
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
        ''' Factory method. Loads a <see cref="DocClassList"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocClassList"/> collection.</returns>
        Public Shared Function GetDocClassList() As DocClassList
            If _list Is Nothing Then
                _list = DataPortal.Fetch(Of DocClassList)()
            End If

            Return _list
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocClassList"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="docClassName">The DocClassName parameter of the DocClassList to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="DocClassList"/> collection.</returns>
        Public Shared Function GetDocClassList(docClassName As String) As DocClassList
            Return DataPortal.Fetch(Of DocClassList)(docClassName)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocClassList"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocClassList(ByVal callback As EventHandler(Of DataPortalResult(Of DocClassList)))
            If _list Is Nothing Then
                DataPortal.BeginFetch(Of DocClassList)(Sub(o, e)
                        _list = e.Object
                        callback(o, e)
                    End Sub)
            Else
                callback(Nothing, New DataPortalResult(Of DocClassList)(_list, Nothing, Nothing))
            End If
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocClassList"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="docClassName">The DocClassName parameter of the DocClassList to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocClassList(docClassName As String, ByVal callback As EventHandler(Of DataPortalResult(Of DocClassList)))
            DataPortal.BeginFetch(Of DocClassList)(docClassName, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocClassList"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = False
            AllowEdit = False
            AllowRemove = False
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(DocClassList), New IsInRole(AuthorizationActions.GetObject, "User"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can retrieve DocClassList's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(DocClassList))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocClassList"/> collection from the database or from the cache.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            If IsCached Then
                LoadCachedList()
                Exit Sub
            End If

            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("GetDocClassList", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim args As New DataPortalHookArgs(cmd)
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

        ''' <summary>
        ''' Loads a <see cref="DocClassList"/> collection from the database, based on given criteria.
        ''' </summary>
        ''' <param name="docClassName">The Doc Class Name.</param>
        Protected Overloads Sub DataPortal_Fetch(docClassName As String)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("GetDocClassList", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocClassName", docClassName).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd, docClassName)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
        End Sub

        Private Sub LoadCollection(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                Fetch(dr)
            End Using
        End Sub

        ''' <summary>
        ''' Loads all <see cref="DocClassList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DocClassInfo.GetDocClassInfo(dr))
            End While
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
