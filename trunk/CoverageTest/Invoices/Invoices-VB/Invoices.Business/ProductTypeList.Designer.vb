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
    ''' ProductTypeList (read only list).<br/>
    ''' This is a generated base class of <see cref="ProductTypeList"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="ProductTypeInfo"/> objects.
    ''' No cache. Updated by ProductTypeDynaItem
    ''' </remarks>
    <Serializable()>
    Public Partial Class ProductTypeList
#If WINFORMS Then
        Inherits ReadOnlyBindingListBase(Of ProductTypeList, ProductTypeInfo)
#Else
        Inherits ReadOnlyListBase(Of ProductTypeList, ProductTypeInfo)
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
        ''' Determines whether a <see cref="ProductTypeInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        ''' <returns><c>True</c> if the ProductTypeInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(productTypeId As Integer) As Boolean
            For Each item As ProductTypeInfo In Me
                If item.ProductTypeId = productTypeId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="ProductTypeList"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="ProductTypeList"/> collection.</returns>
        Public Shared Function GetProductTypeList() As ProductTypeList
            Return DataPortal.Fetch(Of ProductTypeList)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="ProductTypeList"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetProductTypeList(ByVal callback As EventHandler(Of DataPortalResult(Of ProductTypeList)))
            DataPortal.BeginFetch(Of ProductTypeList)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ProductTypeList"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            ProductTypeDynaItemSaved.Register(Me)

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
        ''' Handle Saved events of <see cref="ProductTypeDynaItem"/> to update the list of <see cref="ProductTypeInfo"/> objects.
        ''' </summary>
        ''' <param name="sender">The sender of the event.</param>
        ''' <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        Private Sub ProductTypeDynaItemSavedHandler(sender As Object, e As Csla.Core.SavedEventArgs)
            Dim obj As ProductTypeDynaItem = CType(e.NewObject, ProductTypeDynaItem)
            If CType(sender, ProductTypeDynaItem).IsNew Then
                IsReadOnly = False
                Dim rlce As Boolean = RaiseListChangedEvents
                RaiseListChangedEvents = True
                Add(ProductTypeInfo.LoadInfo(obj))
                RaiseListChangedEvents = rlce
                IsReadOnly = True
            ElseIf CType(sender, ProductTypeDynaItem).IsDeleted Then
                For index = 0 To Count - 1
                    Dim child As ProductTypeInfo = Me(index)
                    If child.ProductTypeId = obj.ProductTypeId Then
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
                    Dim child As ProductTypeInfo = Me(index)
                    If child.ProductTypeId = obj.ProductTypeId Then
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
        ''' Loads a <see cref="ProductTypeList"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.GetProductTypeList", ctx.Connection)
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
        ''' Loads all <see cref="ProductTypeList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of ProductTypeInfo)(dr))
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

        #Region " ProductTypeDynaItemSaved nested class "

        'TODO: edit "ProductTypeList.vb", uncomment the "OnDeserialized" method and add the following line:
        'TODO:     ProductTypeDynaItemSaved.Register(Me)

        ''' <summary>
        ''' Nested class to manage the Saved events of <see cref="ProductTypeDynaItem"/>
        ''' to update the list of <see cref="ProductTypeInfo"/> objects.
        ''' </summary>
        Private NotInheritable Class ProductTypeDynaItemSaved
            Private Shared _references As List(Of WeakReference)

            Private Sub New()
            End Sub

            Private Shared Function Found(ByVal obj As Object) As Boolean
                Return _references.Any(Function(reference) Equals(reference.Target, obj))
            End Function

            ''' <summary>
            ''' Registers a ProductTypeList instance to handle Saved events.
            ''' to update the list of <see cref="ProductTypeInfo"/> objects.
            ''' </summary>
            ''' <param name="obj">The ProductTypeList instance.</param>
            Public Shared Sub Register(ByVal obj As ProductTypeList)
                Dim mustRegister As Boolean = _references Is Nothing

                If mustRegister Then
                    _references = New List(Of WeakReference)()
                End If

                If ProductTypeList.SingleInstanceSavedHandler Then
                    _references.Clear()
                End If

                If Not Found(obj) Then
                    _references.Add(New WeakReference(obj))
                End If

                If mustRegister Then
                    AddHandler ProductTypeDynaItem.ProductTypeDynaItemSaved, AddressOf ProductTypeDynaItemSavedHandler
                End If
            End Sub

            ''' <summary>
            ''' Handles Saved events of <see cref="ProductTypeDynaItem"/>.
            ''' </summary>
            ''' <param name="sender">The sender of the event.</param>
            ''' <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            Public Shared Sub ProductTypeDynaItemSavedHandler(ByVal sender As Object, ByVal e As Csla.Core.SavedEventArgs)
                For Each reference As WeakReference In _references
                    If reference.IsAlive Then
                        CType(reference.Target, ProductTypeList).ProductTypeDynaItemSavedHandler(sender, e)
                    End If
                Next reference
            End Sub

            ''' <summary>
            ''' Removes event handling and clears all registered ProductTypeList instances.
            ''' </summary>
            Public Shared Sub Unregister()
                RemoveHandler ProductTypeDynaItem.ProductTypeDynaItemSaved, AddressOf ProductTypeDynaItemSavedHandler
                _references = Nothing
            End Sub
        End Class

        #End Region

    End Class
End Namespace
