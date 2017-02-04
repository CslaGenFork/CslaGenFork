Imports System.Configuration

Namespace TestProject.Business

    ''' <summary>Class that provides the connection
    ''' strings used by the application.</summary>
    Friend Class Database

        ''' <summary>Connection string to the TestProject database.</summary>
        Friend Shared ReadOnly Property TestProjectConnection As String
            Get
                Return ConfigurationManager.ConnectionStrings("TestProject").ConnectionString
            End Get
        End Property

    End Class

End Namespace
