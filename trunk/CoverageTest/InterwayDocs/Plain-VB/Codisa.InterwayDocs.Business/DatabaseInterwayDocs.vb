Imports System.Configuration

Namespace Codisa.InterwayDocs.Business

    ''' <summary>Class that provides the connection
    ''' strings used by the application.</summary>
    Friend Class Database

        ''' <summary>Connection string to the InterwayDocs database.</summary>
        Friend Shared ReadOnly Property InterwayDocsConnection As String
            Get
                Return ConfigurationManager.ConnectionStrings("InterwayDocs").ConnectionString
            End Get
        End Property

    End Class

End Namespace
