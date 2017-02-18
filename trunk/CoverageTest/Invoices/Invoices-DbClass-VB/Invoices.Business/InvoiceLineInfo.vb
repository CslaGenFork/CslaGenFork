Imports System
Imports Csla

Namespace Invoices.Business

    Public Partial Class InvoiceLineInfo

        #Region " OnDeserialized actions "

        ' ''' <summary>
        ' ''' This method is called on a newly deserialized object
        ' ''' after deserialization is complete.
        ' ''' </summary>
        ' ''' <param name="context">Serialization context object.</param>
        ' Protected Overrides Sub OnDeserialized(context As System.Runtime.Serialization.StreamingContext)
            ' MyBase.OnDeserialized(context)
            ' add your custom OnDeserialized actions here.
        ' End Sub

        #End Region

        #Region " Implementation of DataPortal Hooks "

        ' Private Sub OnFetchRead(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        #End Region

    End Class

End Namespace
