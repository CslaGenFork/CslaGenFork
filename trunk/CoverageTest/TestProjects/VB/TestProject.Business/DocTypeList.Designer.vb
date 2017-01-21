Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports UsingClass

Namespace TestProject.Business

    ''' <summary>
    ''' Collection of document type's basic information (read only list).<br/>
    ''' This is a generated base class of <see cref="DocTypeList"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DocTypeInfo"/> objects.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Partial Public Class DocTypeList
        Inherits ReadOnlyBindingListBase(Of DocTypeList, DocTypeInfo)
        Implements IHaveInterface
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="DocTypeInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="docTypeID">The DocTypeID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocTypeInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(docTypeID As Integer) As Boolean
            For Each item As DocTypeInfo In Me
                If item.DocTypeID = docTypeID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Find Methods "

        ''' <summary>
        ''' Finds a <see cref="DocTypeInfo"/> item of the <see cref="DocTypeList"/> collection, based on a given DocTypeID.
        ''' </summary>
        ''' <param name="docTypeID">The DocTypeID.</param>
        ''' <returns>A <see cref="DocTypeInfo"/> object.</returns>
        Public Function FindDocTypeInfoByDocTypeID(docTypeID As Integer) As DocTypeInfo
            For i As Integer = 0 To Me.Count - 1
                If Me(i).DocTypeID.Equals(docTypeID) Then
                    Return Me(i)
                End If
            Next i

            Return Nothing
        End Function

        #End Region

        #Region " Private Fields "

        Private Shared _list As DocTypeList

        #End Region

        #Region " Cache Management Methods "

        ''' <summary>
        ''' Clears the in-memory DocTypeList cache so it is reloaded on the next request.
        ''' </summary>
        Public Shared Sub InvalidateCache()
            _list = Nothing
        End Sub

        ''' <summary>
        ''' Used by async loaders to load the cache.
        ''' </summary>
        ''' <param name="lst">The list to cache.</param>
        Friend Shared Sub SetCache(lst As DocTypeList)
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
        ''' Factory method. Loads a <see cref="DocTypeList"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocTypeList"/> collection.</returns>
        Public Shared Function GetDocTypeList() As DocTypeList
            If _list Is Nothing Then
                _list = DataPortal.Fetch(Of DocTypeList)()
            End If

            Return _list
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocTypeList"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="docTypeName">The DocTypeName parameter of the DocTypeList to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="DocTypeList"/> collection.</returns>
        Public Shared Function GetDocTypeList(docTypeName As String) As DocTypeList
            Return DataPortal.Fetch(Of DocTypeList)(docTypeName)
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocTypeList"/> class.
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
            BusinessRules.AddRule(GetType(DocTypeList), New IsInRole(AuthorizationActions.GetObject, "User"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can retrieve DocTypeList's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(DocTypeList))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocTypeList"/> collection from the database or from the cache.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            If IsCached Then
                LoadCachedList()
                Exit Sub
            End If

            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("GetDocTypeList", ctx.Connection)
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
        ''' Loads a <see cref="DocTypeList"/> collection from the database, based on given criteria.
        ''' </summary>
        ''' <param name="docTypeName">The Doc Type Name.</param>
        Protected Overloads Sub DataPortal_Fetch(docTypeName As String)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("GetDocTypeList", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocTypeName", docTypeName).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd, docTypeName)
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
        ''' Loads all <see cref="DocTypeList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of DocTypeInfo)(dr))
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
