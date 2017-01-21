Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports UsingClass

Namespace TestProject.Business

    ''' <summary>
    ''' Collection of document types (editable root list).<br/>
    ''' This is a generated base class of <see cref="DocTypeEditColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DocTypeEdit"/> objects.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Partial Public Class DocTypeEditColl
        Inherits BusinessBindingListBase(Of DocTypeEditColl, DocTypeEdit)
        Implements IHaveInterface
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Removes a <see cref="DocTypeEdit"/> item from the collection.
        ''' </summary>
        ''' <param name="docTypeID">The DocTypeID of the item to be removed.</param>
        Public Overloads Sub Remove(docTypeID As Integer)
            For Each item As DocTypeEdit In Me
                If item.DocTypeID = docTypeID Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="DocTypeEdit"/> item is in the collection.
        ''' </summary>
        ''' <param name="docTypeID">The DocTypeID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocTypeEdit is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(docTypeID As Integer) As Boolean
            For Each item As DocTypeEdit In Me
                If item.DocTypeID = docTypeID Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="DocTypeEdit"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="docTypeID">The DocTypeID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocTypeEdit is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(docTypeID As Integer) As Boolean
            For Each item As DocTypeEdit In DeletedList
                If item.DocTypeID = docTypeID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocTypeEditColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocTypeEditColl"/> collection.</returns>
        Public Shared Function NewDocTypeEditColl() As DocTypeEditColl
            Return DataPortal.Create(Of DocTypeEditColl)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocTypeEditColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocTypeEditColl"/> collection.</returns>
        Public Shared Function GetDocTypeEditColl() As DocTypeEditColl
            Return DataPortal.Fetch(Of DocTypeEditColl)()
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocTypeEditColl"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnDocTypeEditCollSaved

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = True
            AllowEdit = True
            AllowRemove = True
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Cache Invalidation "

        Private Sub OnDocTypeEditCollSaved(sender As Object, e As Csla.Core.SavedEventArgs)
            '' this runs on the client
            DocTypeList.InvalidateCache()
            DocTypeNVL.InvalidateCache()
        End Sub

        ''' <summary>
        ''' Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        ''' </summary>
        ''' <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(e As Csla.DataPortalEventArgs)
            If ApplicationContext.ExecutionLocation = ApplicationContext.ExecutionLocations.Server AndAlso
               e.Operation = DataPortalOperations.Update Then
                '' this runs on the server
                DocTypeList.InvalidateCache()
                DocTypeNVL.InvalidateCache()
            End If
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocTypeEditColl"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("GetDocTypeEditColl", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim args As New DataPortalHookArgs(cmd)
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
        ''' Loads all <see cref="DocTypeEditColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of DocTypeEdit)(dr))
            End While
            RaiseListChangedEvents = rlce
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="DocTypeEditColl"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.TestProjectConnection, False)
                Child_Update()
                ctx.Commit()
            End Using
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
