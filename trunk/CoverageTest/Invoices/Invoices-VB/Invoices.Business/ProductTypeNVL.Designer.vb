Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace Invoices.Business

    ''' <summary>
    ''' ProductTypeNVL (name value list).<br/>
    ''' This is a generated base class of <see cref="ProductTypeNVL"/> business object.
    ''' </summary>
    <Serializable()>
    Partial Public Class ProductTypeNVL
    Inherits NameValueListBase(Of Integer, String)

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="ProductTypeNVL"/> object.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="ProductTypeNVL"/> object.</returns>
        Public Shared Function GetProductTypeNVL() As ProductTypeNVL
            Return DataPortal.Fetch(Of ProductTypeNVL)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="ProductTypeNVL"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetProductTypeNVL(callback As EventHandler(Of DataPortalResult(Of ProductTypeNVL)))
            DataPortal.BeginFetch(Of ProductTypeNVL)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ProductTypeNVL"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="ProductTypeNVL"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager("InvoicesDatabase")
                Using cmd = New SqlCommand("dbo.GetProductTypeNVL", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim args = New DataPortalHookArgs(cmd)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
        End Sub

        Private Sub LoadCollection(cmd As SqlCommand)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Using dr = New SafeDataReader(cmd.ExecuteReader())
                While dr.Read()
                    Add(New NameValuePair(
                        dr.GetInt32("ProductTypeId"),
                        dr.GetString("Name")))
                End While
            End Using
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
