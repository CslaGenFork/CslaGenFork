Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' InvoiceList (read only list).<br/>
    ''' This is a generated base class of <see cref="InvoiceList"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="InvoiceInfo"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class InvoiceList
#If WINFORMS Then
        Inherits ReadOnlyBindingListBase(Of InvoiceList, InvoiceInfo)
#Else
        Inherits ReadOnlyListBase(Of InvoiceList, InvoiceInfo)
#End If

        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="InvoiceInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId of the item to search for.</param>
        ''' <returns><c>True</c> if the InvoiceInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(invoiceId As Guid) As Boolean
            For Each item As InvoiceInfo In Me
                If item.InvoiceId = invoiceId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Find Methods "

        ''' <summary>
        ''' Finds a <see cref="InvoiceInfo"/> item of the <see cref="InvoiceList"/> collection, based on a given InvoiceId.
        ''' </summary>
        ''' <param name="invoiceId">The InvoiceId.</param>
        ''' <returns>A <see cref="InvoiceInfo"/> object.</returns>
        Public Function FindInvoiceInfoByInvoiceId(invoiceId As Guid) As InvoiceInfo
            For i As Integer = 0 To Me.Count - 1
                If Me(i).InvoiceId.Equals(invoiceId) Then
                    Return Me(i)
                End If
            Next i

            Return Nothing
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="InvoiceList"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="InvoiceList"/> collection.</returns>
        Public Shared Function GetInvoiceList() As InvoiceList
            Return DataPortal.Fetch(Of InvoiceList)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="InvoiceList"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetInvoiceList(ByVal callback As EventHandler(Of DataPortalResult(Of InvoiceList)))
            DataPortal.BeginFetch(Of InvoiceList)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="InvoiceList"/> class.
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
        ''' Loads a <see cref="InvoiceList"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("Invoices")
                Using cmd = New SqlCommand("dbo.GetInvoiceList", ctx.Connection)
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
        ''' Loads all <see cref="InvoiceList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of InvoiceInfo)(dr))
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
