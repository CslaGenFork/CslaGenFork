Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports UsingLibrary

Namespace TestProject.Business

    ''' <summary>
    ''' DocTypeDynamicCollection (dynamic root list).<br/>
    ''' This is a generated base class of <see cref="DocTypeDynamicCollection"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DocTypeDynamic"/> objects.
    ''' This is a remark
    ''' </remarks>
    <Attributable>
    <Serializable()>
    Partial Public Class DocTypeDynamicCollection
        Inherits DynamicBindingListBase(Of DocTypeDynamic)
        Implements IHaveInterface
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="DocTypeDynamic"/> item is in the collection.
        ''' </summary>
        ''' <param name="docTypeID">The DocTypeID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocTypeDynamic is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(docTypeID As Integer) As Boolean
            For Each item As DocTypeDynamic In Me
                If item.DocTypeID = docTypeID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocTypeDynamicCollection"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocTypeDynamicCollection"/> collection.</returns>
        Public Shared Function NewDocTypeDynamicCollection() As DocTypeDynamicCollection
            Return DataPortal.Create(Of DocTypeDynamicCollection)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocTypeDynamicCollection"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocTypeDynamicCollection"/> collection.</returns>
        Public Shared Function GetDocTypeDynamicCollection() As DocTypeDynamicCollection
            Return DataPortal.Fetch(Of DocTypeDynamicCollection)()
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocTypeDynamicCollection"/> class.
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
        ''' Loads a <see cref="DocTypeDynamicCollection"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.TestProjectConnection, False)
                Using cmd = New SqlCommand("GetDocTypeDynamicCollection", ctx.Connection)
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
        ''' Loads all <see cref="DocTypeDynamicCollection"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.Fetch(Of DocTypeDynamic)(dr))
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
