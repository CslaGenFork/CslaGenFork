Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' ProductSupplierColl (editable child list).<br/>
    ''' This is a generated base class of <see cref="ProductSupplierColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="ProductEdit"/> editable root object.<br/>
    ''' The items of the collection are <see cref="ProductSupplierItem"/> objects.
    ''' </remarks>
    <Serializable()>
    Public Partial Class ProductSupplierColl
#If WINFORMS Then
        Inherits BusinessBindingListBase(Of ProductSupplierColl, ProductSupplierItem)
#Else
        Inherits BusinessListBase(Of ProductSupplierColl, ProductSupplierItem)
#End If
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Removes a <see cref="ProductSupplierItem"/> item from the collection.
        ''' </summary>
        ''' <param name="productSupplierId">The ProductSupplierId of the item to be removed.</param>
        Public Overloads Sub Remove(productSupplierId As Integer)
            For Each item As ProductSupplierItem In Me
                If item.ProductSupplierId = productSupplierId Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="ProductSupplierItem"/> item is in the collection.
        ''' </summary>
        ''' <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        ''' <returns><c>True</c> if the ProductSupplierItem is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(productSupplierId As Integer) As Boolean
            For Each item As ProductSupplierItem In Me
                If item.ProductSupplierId = productSupplierId Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="ProductSupplierItem"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        ''' <returns><c>True</c> if the ProductSupplierItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(productSupplierId As Integer) As Boolean
            For Each item As ProductSupplierItem In DeletedList
                If item.ProductSupplierId = productSupplierId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ProductSupplierColl"/> class.
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
        ''' Loads all <see cref="ProductSupplierColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Dim args As New DataPortalHookArgs(dr)
            OnFetchPre(args)
            While dr.Read()
                Add(DataPortal.FetchChild(Of ProductSupplierItem)(dr))
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
