Imports System
Imports Csla

Namespace Invoices.Business

    Public Partial Class InvoiceLineCollection

        #Region " OnDeserialized actions "

        ' ''' <summary>
        ' ''' This method is called on a newly deserialized object
        ' ''' after deserialization is complete.
        ' ''' </summary>
        ' Protected Overrides Sub OnDeserialized()
            ' MyBase.OnDeserialized()
            ' add your custom OnDeserialized actions here.
        ' End Sub

        #End Region

        #Region " Implementation of DataPortal Hooks "

        ' Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        ' Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        '     Throw New NotImplementedException()
        ' End Sub

        #End Region

    End Class

End Namespace
