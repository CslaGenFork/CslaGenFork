Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceLineList (read only list).<br/>
    ''' This is a generated base class of <see cref="InvoiceLineList"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="InvoiceView"/> read only object.<br/>
    ''' The items of the collection are <see cref="InvoiceLineInfo"/> objects.
    ''' </remarks>
    <Serializable()>
    Partial Public Class InvoiceLineList
#If WINFORMS Then
        Inherits ReadOnlyBindingListBase(Of InvoiceLineList, InvoiceLineInfo)
#Else
        Inherits ReadOnlyListBase(Of InvoiceLineList, InvoiceLineInfo)
#End If
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="InvoiceLineInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="invoiceLineId">The InvoiceLineId of the item to search for.</param>
        ''' <returns><c>True</c> if the InvoiceLineInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(invoiceLineId As Guid) As Boolean
            For Each item As InvoiceLineInfo In Me
                If item.InvoiceLineId = invoiceLineId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceLineList"/> class.
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

        #Region " Data Access "

        ''' <summary>
        ''' Loads all <see cref="InvoiceLineList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Dim args As New DataPortalHookArgs(dr)
            OnFetchPre(args)
            While dr.Read()
                Add(DataPortal.FetchChild(Of InvoiceLineInfo)(dr))
            End While
            OnFetchPost(args)
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
