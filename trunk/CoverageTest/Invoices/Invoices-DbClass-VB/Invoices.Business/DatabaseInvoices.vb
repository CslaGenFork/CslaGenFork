Imports System.Configuration

Namespace Invoices.Business

    ''' <summary>Class that provides the connection
    ''' strings used by the application.</summary>
    Friend Class Database

        ''' <summary>Connection string to the Invoices database.</summary>
        Friend Shared ReadOnly Property InvoicesConnection As String
            Get
                Return ConfigurationManager.ConnectionStrings("Invoices").ConnectionString
            End Get
        End Property

    End Class

End Namespace
