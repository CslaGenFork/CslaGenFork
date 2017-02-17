Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceLineCollection (editable child list).<br/>
    ''' This is a generated base class of <see cref="InvoiceLineCollection"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="InvoiceEdit"/> editable root object.<br/>
    ''' The items of the collection are <see cref="InvoiceLineItem"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class InvoiceLineCollection
#If WINFORMS Then
        Inherits BusinessBindingListBase(Of InvoiceLineCollection, InvoiceLineItem)
#Else
        Inherits BusinessListBase(Of InvoiceLineCollection, InvoiceLineItem)
#End If
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Removes a <see cref="InvoiceLineItem"/> item from the collection.
        ''' </summary>
        ''' <param name="invoiceLineId">The InvoiceLineId of the item to be removed.</param>
        Public Overloads Sub Remove(invoiceLineId As Guid)
            For Each item As InvoiceLineItem In Me
                If item.InvoiceLineId = invoiceLineId Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="InvoiceLineItem"/> item is in the collection.
        ''' </summary>
        ''' <param name="invoiceLineId">The InvoiceLineId of the item to search for.</param>
        ''' <returns><c>True</c> if the InvoiceLineItem is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(invoiceLineId As Guid) As Boolean
            For Each item As InvoiceLineItem In Me
                If item.InvoiceLineId = invoiceLineId Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="InvoiceLineItem"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="invoiceLineId">The InvoiceLineId of the item to search for.</param>
        ''' <returns><c>True</c> if the InvoiceLineItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(invoiceLineId As Guid) As Boolean
            For Each item As InvoiceLineItem In DeletedList
                If item.InvoiceLineId = invoiceLineId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceLineCollection"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            ' show the framework that this is a child object
            MarkAsChild()

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = True
            AllowEdit = True
            AllowRemove = True
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads all <see cref="InvoiceLineCollection"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Dim args As New DataPortalHookArgs(dr)
            OnFetchPre(args)
            While dr.Read()
                Add(DataPortal.FetchChild(Of InvoiceLineItem)(dr))
            End While
            OnFetchPost(args)
            RaiseListChangedEvents = rlce
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
