Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Codisa.InterwayDocs.Business.SearchObjects
Imports Codisa.InterwayDocs.Rules

Namespace Codisa.InterwayDocs.Business

    ''' <summary>
    ''' IncomingBook (read only list).<br/>
    ''' This is a generated base class of <see cref="IncomingBook"/> business object.
    ''' This class is a root collection.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="IncomingInfo"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class IncomingBook
        Inherits ReadOnlyBindingListBase(Of IncomingBook, IncomingInfo)
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="IncomingInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="registerId">The RegisterId of the item to search for.</param>
        ''' <returns><c>True</c> if the IncomingInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(registerId As Integer) As Boolean
            For Each item As IncomingInfo In Me
                If item.RegisterId = registerId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="IncomingBook"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The fetch criteria.</param>
        ''' <returns>A reference to the fetched <see cref="IncomingBook"/> collection.</returns>
        Public Shared Function GetIncomingBook(crit As IncomingBookCriteriaGet) As IncomingBook
            Return DataPortal.Fetch(Of IncomingBook)(crit)
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="IncomingBook"/> collection, based on given parameters.
        ''' </summary>
        ''' <param name="criteriaStartDate">The CriteriaStartDate parameter of the IncomingBook to fetch.</param>
        ''' <param name="criteriaEndDate">The CriteriaEndDate parameter of the IncomingBook to fetch.</param>
        ''' <param name="archiveLocation">The ArchiveLocation parameter of the IncomingBook to fetch.</param>
        ''' <param name="fullText">The FullText parameter of the IncomingBook to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="IncomingBook"/> collection.</returns>
        Public Shared Function GetIncomingBook(criteriaStartDate As SmartDate, criteriaEndDate As SmartDate, archiveLocation As String, fullText As String) As IncomingBook
            Return DataPortal.Fetch(Of IncomingBook)(New IncomingBookCriteriaGet(criteriaStartDate, criteriaEndDate, archiveLocation, fullText))
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="IncomingBook"/> class.
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
