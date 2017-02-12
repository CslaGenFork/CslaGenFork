Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' SupplierList (read only list).<br/>
    ''' This is a generated base class of <see cref="SupplierList"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="SupplierInfo"/> objects.
    ''' </remarks>
    <Serializable()>
    Public Partial Class SupplierList
#If WINFORMS Then
        Inherits ReadOnlyBindingListBase(Of SupplierList, SupplierInfo)
#Else
        Inherits ReadOnlyListBase(Of SupplierList, SupplierInfo)
#End If
    
        #Region " Event handler properties "

        <NotUndoable>
        Private Shared _singleInstanceSavedHandler As Boolean = True

        ''' <summary>
        ''' Gets or sets a value indicating whether only a single instance should handle the Saved event.
        ''' </summary>
        ''' <value>
        ''' <c>true</c> if only a single instance should handle the Saved event; otherwise, <c>false</c>.
        ''' </value>
        Public Shared Property SingleInstanceSavedHandler() As Boolean
            Get
                Return _singleInstanceSavedHandler
            End Get
            Set(ByVal value As Boolean)
                _singleInstanceSavedHandler = value
            End Set
        End Property

        #End Region

        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="SupplierInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="supplierId">The SupplierId of the item to search for.</param>
        ''' <returns><c>True</c> if the SupplierInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(supplierId As Integer) As Boolean
            For Each item As SupplierInfo In Me
                If item.SupplierId = supplierId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Private Fields "

        Private Shared _list As SupplierList

        #End Region

        #Region " Cache Management Methods "

        ''' <summary>
        ''' Clears the in-memory SupplierList cache so it is reloaded on the next request.
        ''' </summary>
        Public Shared Sub InvalidateCache()
            _list = Nothing
        End Sub

        ''' <summary>
        ''' Used by async loaders to load the cache.
        ''' </summary>
        ''' <param name="lst">The list to cache.</param>
        Friend Shared Sub SetCache(lst As SupplierList)
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
        ''' Factory method. Loads a <see cref="SupplierList"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="SupplierList"/> collection.</returns>
        Public Shared Function GetSupplierList() As SupplierList
            If _list Is Nothing Then
                _list = DataPortal.Fetch(Of SupplierList)()
            End If

            Return _list
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="SupplierList"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetSupplierList(ByVal callback As EventHandler(Of DataPortalResult(Of SupplierList)))
            If _list Is Nothing Then
                DataPortal.BeginFetch(Of SupplierList)(Sub(o, e)
                        _list = e.Object
                        callback(o, e)
                    End Sub)
            Else
                callback(Nothing, New DataPortalResult(Of SupplierList)(_list, Nothing, Nothing))
            End If
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SupplierList"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            SupplierEditSaved.Register(Me)

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = False
            AllowEdit = False
            AllowRemove = False
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Saved Event Handler "

        ''' <summary>
        ''' Handle Saved events of <see cref="SupplierEdit"/> to update the list of <see cref="SupplierInfo"/> objects.
        ''' </summary>
        ''' <param name="sender">The sender of the event.</param>
        ''' <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        Private Sub SupplierEditSavedHandler(sender As Object, e As Csla.Core.SavedEventArgs)
            Dim obj As SupplierEdit = CType(e.NewObject, SupplierEdit)
            If CType(sender, SupplierEdit).IsNew Then
                IsReadOnly = False
                Dim rlce As Boolean = RaiseListChangedEvents
                RaiseListChangedEvents = True
                Add(SupplierInfo.LoadInfo(obj))
                RaiseListChangedEvents = rlce
                IsReadOnly = True
            ElseIf CType(sender, SupplierEdit).IsDeleted Then
                For index = 0 To Count - 1
                    Dim child As SupplierInfo = Me(index)
                    If child.SupplierId = obj.SupplierId Then
                        IsReadOnly = False
                        Dim rlce As Boolean = RaiseListChangedEvents
                        RaiseListChangedEvents = True
                        RemoveItem(index)
                        RaiseListChangedEvents = rlce
                        IsReadOnly = True
                        Exit For
                    End If
                Next
            Else
                For index = 0 To Count - 1
                    Dim child As SupplierInfo = Me(index)
                    If child.SupplierId = obj.SupplierId Then
                        child.UpdatePropertiesOnSaved(obj)
#If Not WINFORMS Then
                        Dim notifyCollectionChangedEventArgs As New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, child, child, index)
                        OnCollectionChanged(notifyCollectionChangedEventArgs)
#Else
                        Dim listChangedEventArgs As New ListChangedEventArgs(ListChangedType.ItemChanged, index)
                        OnListChanged(listChangedEventArgs)
#End If
                        Exit For
                    End If
                Next
            End If
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="SupplierList"/> collection from the database or from the cache.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            If IsCached Then
                LoadCachedList()
                Exit Sub
            End If

            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.GetSupplierList", ctx.Connection)
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

        Private Sub LoadCollection(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                Fetch(dr)
            End Using
        End Sub

        ''' <summary>
        ''' Loads all <see cref="SupplierList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of SupplierInfo)(dr))
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

        #Region " SupplierEditSaved nested class "

        'TODO: edit "SupplierList.vb", uncomment the "OnDeserialized" method and add the following line:
        'TODO:     SupplierEditSaved.Register(Me)

        ''' <summary>
        ''' Nested class to manage the Saved events of <see cref="SupplierEdit"/>
        ''' to update the list of <see cref="SupplierInfo"/> objects.
        ''' </summary>
        Private NotInheritable Class SupplierEditSaved
            Private Shared _references As List(Of WeakReference)

            Private Sub New()
            End Sub

            Private Shared Function Found(ByVal obj As Object) As Boolean
                Return _references.Any(Function(reference) Equals(reference.Target, obj))
            End Function

            ''' <summary>
            ''' Registers a SupplierList instance to handle Saved events.
            ''' to update the list of <see cref="SupplierInfo"/> objects.
            ''' </summary>
            ''' <param name="obj">The SupplierList instance.</param>
            Public Shared Sub Register(ByVal obj As SupplierList)
                Dim mustRegister As Boolean = _references Is Nothing

                If mustRegister Then
                    _references = New List(Of WeakReference)()
                End If

                If SupplierList.SingleInstanceSavedHandler Then
                    _references.Clear()
                End If

                If Not Found(obj) Then
                    _references.Add(New WeakReference(obj))
                End If

                If mustRegister Then
                    AddHandler SupplierEdit.SupplierEditSaved, AddressOf SupplierEditSavedHandler
                End If
            End Sub

            ''' <summary>
            ''' Handles Saved events of <see cref="SupplierEdit"/>.
            ''' </summary>
            ''' <param name="sender">The sender of the event.</param>
            ''' <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            Public Shared Sub SupplierEditSavedHandler(ByVal sender As Object, ByVal e As Csla.Core.SavedEventArgs)
                For Each reference As WeakReference In _references
                    If reference.IsAlive Then
                        CType(reference.Target, SupplierList).SupplierEditSavedHandler(sender, e)
                    End If
                Next reference
            End Sub

            ''' <summary>
            ''' Removes event handling and clears all registered SupplierList instances.
            ''' </summary>
            Public Shared Sub Unregister()
                RemoveHandler SupplierEdit.SupplierEditSaved, AddressOf SupplierEditSavedHandler
                _references = Nothing
            End Sub
        End Class

        #End Region

    End Class
End Namespace
