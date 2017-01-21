Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports UsingClass

Namespace TestProject.Business

    ''' <summary>
    ''' Active document types (name value list).<br/>
    ''' This is a generated base class of <see cref="DocTypeNVL"/> business object.
    ''' </summary>
    <Attributable>
    <Serializable()>
    Partial Public Class DocTypeNVL
        Inherits NameValueListBase(Of Integer, String)
        Implements IHaveInterface

        #Region " Private Fields "

        Private Shared _list As DocTypeNVL

        #End Region

        #Region " Cache Management Methods "

        ''' <summary>
        ''' Clears the in-memory DocTypeNVL cache so it is reloaded on the next request.
        ''' </summary>
        Public Shared Sub InvalidateCache()
            _list = Nothing
        End Sub

        ''' <summary>
        ''' Used by async loaders to load the cache.
        ''' </summary>
        ''' <param name="lst">The list to cache.</param>
        Friend Shared Sub SetCache(lst As DocTypeNVL)
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
        ''' Factory method. Loads a <see cref="DocTypeNVL"/> object.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocTypeNVL"/> object.</returns>
        Public Shared Function GetDocTypeNVL() As DocTypeNVL
            If _list Is Nothing Then
                _list = DataPortal.Fetch(Of DocTypeNVL)()
            End If

            Return _list
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocTypeNVL"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocTypeNVL"/> collection from the database or from the cache.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            If IsCached Then
                LoadCachedList()
                Return
            End If

            Using cn = New SqlConnection(Database.TestProjectConnection)
                Using cmd = New SqlCommand("GetDocTypeNVL", cn)
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
                        dr.GetInt32("DocTypeID"),
                        dr.GetString("DocTypeName")))
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
