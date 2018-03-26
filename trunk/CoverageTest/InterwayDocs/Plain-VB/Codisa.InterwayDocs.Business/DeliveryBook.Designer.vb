Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Codisa.InterwayDocs.Business.SearchObjects

Namespace Codisa.InterwayDocs.Business

    ''' <summary>
    ''' DeliveryBook (read only list).<br/>
    ''' This is a generated base class of <see cref="DeliveryBook"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DeliveryInfo"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class DeliveryBook
        Inherits ReadOnlyBindingListBase(Of DeliveryBook, DeliveryInfo)
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="DeliveryInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="registerId">The RegisterId of the item to search for.</param>
        ''' <returns><c>True</c> if the DeliveryInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(registerId As Integer) As Boolean
            For Each item As DeliveryInfo In Me
                If item.RegisterId = registerId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="DeliveryBook"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The fetch criteria.</param>
        ''' <returns>A reference to the fetched <see cref="DeliveryBook"/> collection.</returns>
        Public Shared Function GetDeliveryBook(crit As DeliveryBookCriteriaGet) As DeliveryBook
            Return DataPortal.Fetch(Of DeliveryBook)(crit)
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DeliveryBook"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="criteriaStartDate">The CriteriaStartDate parameter of the DeliveryBook to fetch.</param>
        ''' <param name="criteriaEndDate">The CriteriaEndDate parameter of the DeliveryBook to fetch.</param>
        ''' <param name="fullText">The FullText parameter of the DeliveryBook to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="DeliveryBook"/> collection.</returns>
        Public Shared Function GetDeliveryBook(criteriaStartDate As SmartDate, criteriaEndDate As SmartDate, fullText As String) As DeliveryBook
            Return DataPortal.Fetch(Of DeliveryBook)(New DeliveryBookCriteriaGet(criteriaStartDate, criteriaEndDate, fullText))
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DeliveryBook"/> class.
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

    End Class
End Namespace
