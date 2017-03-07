Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' SupplierProductList (read only list).<br/>
    ''' This is a generated base class of <see cref="SupplierProductList"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="SupplierInfoDetail"/> read only object.<br/>
    ''' The items of the collection are <see cref="SupplierProductItnfo"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class SupplierProductList
#If WINFORMS Then
        Inherits ReadOnlyBindingListBase(Of SupplierProductList, SupplierProductItnfo)
#Else
        Inherits ReadOnlyListBase(Of SupplierProductList, SupplierProductItnfo)
#End If

        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="SupplierProductItnfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        ''' <returns><c>True</c> if the SupplierProductItnfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(productSupplierId As Integer) As Boolean
            For Each item As SupplierProductItnfo In Me
                If item.ProductSupplierId = productSupplierId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="SupplierProductList"/> class.
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
        ''' Loads a <see cref="SupplierProductList"/> collection from the database, based on given criteria.
        ''' </summary>
        ''' <param name="supplierId">The Supplier Id.</param>
        Protected Overloads Sub DataPortal_Fetch(supplierId As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.InvoicesConnection, False)
                Using cmd = New SqlCommand("dbo.GetSupplierProductList", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, supplierId)
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
        ''' Loads all <see cref="SupplierProductList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of SupplierProductItnfo)(dr))
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
