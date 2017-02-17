Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' ProductList (read only list).<br/>
    ''' This is a generated base class of <see cref="ProductList"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="ProductInfo"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class ProductList
#If WINFORMS Then
        Inherits ReadOnlyBindingListBase(Of ProductList, ProductInfo)
#Else
        Inherits ReadOnlyListBase(Of ProductList, ProductInfo)
#End If
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="ProductInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="productId">The ProductId of the item to search for.</param>
        ''' <returns><c>True</c> if the ProductInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(productId As Guid) As Boolean
            For Each item As ProductInfo In Me
                If item.ProductId = productId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="ProductList"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="ProductList"/> collection.</returns>
        Public Shared Function GetProductList() As ProductList
            Return DataPortal.Fetch(Of ProductList)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="ProductList"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetProductList(ByVal callback As EventHandler(Of DataPortalResult(Of ProductList)))
            DataPortal.BeginFetch(Of ProductList)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ProductList"/> class.
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
        ''' Loads a <see cref="ProductList"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.GetProductList", ctx.Connection)
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
        ''' Loads all <see cref="ProductList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of ProductInfo)(dr))
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
