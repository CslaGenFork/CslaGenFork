Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' ProductTypeDynaColl (dynamic root list).<br/>
    ''' This is a generated base class of <see cref="ProductTypeDynaColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="ProductTypeDyna"/> objects.
    ''' </remarks>
    <Serializable()>
    Partial Public Class ProductTypeDynaColl
#If WINFORMS Then
        Inherits DynamicBindingListBase(Of ProductTypeDyna)
#Else
        Inherits DynamicListBase(Of ProductTypeDyna)
#End If
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="ProductTypeDyna"/> item is in the collection.
        ''' </summary>
        ''' <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        ''' <returns><c>True</c> if the ProductTypeDyna is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(productTypeId As Integer) As Boolean
            For Each item As ProductTypeDyna In Me
                If item.ProductTypeId = productTypeId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="ProductTypeDynaColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="ProductTypeDynaColl"/> collection.</returns>
        Public Shared Function NewProductTypeDynaColl() As ProductTypeDynaColl
            Return DataPortal.Create(Of ProductTypeDynaColl)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="ProductTypeDynaColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="ProductTypeDynaColl"/> collection.</returns>
        Public Shared Function GetProductTypeDynaColl() As ProductTypeDynaColl
            Return DataPortal.Fetch(Of ProductTypeDynaColl)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="ProductTypeDynaColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewProductTypeDynaColl(callback As EventHandler(Of DataPortalResult(Of ProductTypeDynaColl)))
            DataPortal.BeginCreate(Of ProductTypeDynaColl)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="ProductTypeDynaColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetProductTypeDynaColl(ByVal callback As EventHandler(Of DataPortalResult(Of ProductTypeDynaColl)))
            DataPortal.BeginFetch(Of ProductTypeDynaColl)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ProductTypeDynaColl"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

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
        ''' Loads a <see cref="ProductTypeDynaColl"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.GetProductTypeDynaColl", ctx.Connection)
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
        ''' Loads all <see cref="ProductTypeDynaColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.Fetch(Of ProductTypeDyna)(dr))
            End While
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
