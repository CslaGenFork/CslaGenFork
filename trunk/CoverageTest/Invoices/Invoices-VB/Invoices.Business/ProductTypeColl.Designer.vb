Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' ProductTypeColl (editable root list).<br/>
    ''' This is a generated base class of <see cref="ProductTypeColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="ProductTypeItem"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class ProductTypeColl
#If WINFORMS Then
        Inherits BusinessBindingListBase(Of ProductTypeColl, ProductTypeItem)
#Else
        Inherits BusinessListBase(Of ProductTypeColl, ProductTypeItem)
#End If

        #Region " Collection Business Methods "

        ''' <summary>
        ''' Removes a <see cref="ProductTypeItem"/> item from the collection.
        ''' </summary>
        ''' <param name="productTypeId">The ProductTypeId of the item to be removed.</param>
        Public Overloads Sub Remove(productTypeId As Integer)
            For Each item As ProductTypeItem In Me
                If item.ProductTypeId = productTypeId Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="ProductTypeItem"/> item is in the collection.
        ''' </summary>
        ''' <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        ''' <returns><c>True</c> if the ProductTypeItem is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(productTypeId As Integer) As Boolean
            For Each item As ProductTypeItem In Me
                If item.ProductTypeId = productTypeId Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="ProductTypeItem"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        ''' <returns><c>True</c> if the ProductTypeItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(productTypeId As Integer) As Boolean
            For Each item As ProductTypeItem In DeletedList
                If item.ProductTypeId = productTypeId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="ProductTypeColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="ProductTypeColl"/> collection.</returns>
        Public Shared Function NewProductTypeColl() As ProductTypeColl
            Return DataPortal.Create(Of ProductTypeColl)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="ProductTypeColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="ProductTypeColl"/> collection.</returns>
        Public Shared Function GetProductTypeColl() As ProductTypeColl
            Return DataPortal.Fetch(Of ProductTypeColl)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="ProductTypeColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewProductTypeColl(callback As EventHandler(Of DataPortalResult(Of ProductTypeColl)))
            DataPortal.BeginCreate(Of ProductTypeColl)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="ProductTypeColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetProductTypeColl(ByVal callback As EventHandler(Of DataPortalResult(Of ProductTypeColl)))
            DataPortal.BeginFetch(Of ProductTypeColl)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ProductTypeColl"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnProductTypeCollSaved

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = True
            AllowEdit = True
            AllowRemove = True
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Cache Invalidation "

        'TODO: edit "ProductTypeColl.vb", uncomment the "OnDeserialized" method and add the following line:
        'TODO:     AddHandler Saved, AddressOf OnProductTypeCollSaved

        Private Sub OnProductTypeCollSaved(sender As Object, e As Csla.Core.SavedEventArgs)
            '' this runs on the client
            ProductTypeCachedList.InvalidateCache()
            ProductTypeCachedNVL.InvalidateCache()
        End Sub

        ''' <summary>
        ''' Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        ''' </summary>
        ''' <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(e As Csla.DataPortalEventArgs)
            If ApplicationContext.ExecutionLocation = ApplicationContext.ExecutionLocations.Server AndAlso
               e.Operation = DataPortalOperations.Update Then
                '' this runs on the server
                ProductTypeCachedNVL.InvalidateCache()
            End If
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="ProductTypeColl"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("Invoices")
                Using cmd = New SqlCommand("dbo.GetProductTypeColl", ctx.Connection)
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
        ''' Loads all <see cref="ProductTypeColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of ProductTypeItem)(dr))
            End While
            RaiseListChangedEvents = rlce
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="ProductTypeColl"/> object.
        ''' </summary>
        <Transactional(TransactionalTypes.TransactionScope)>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("Invoices")
                Child_Update()
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
