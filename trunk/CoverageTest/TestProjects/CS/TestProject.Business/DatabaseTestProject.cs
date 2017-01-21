using System.Configuration;

namespace TestProject.Business
{
    /// <summary>Class that provides the connection
    /// strings used by the application.</summary>
    internal static class Database
    {
        /// <summary>Connection string to the TestProject database.</summary>
        internal static string TestProjectConnection
        {
            get { return ConfigurationManager.ConnectionStrings["TestProject"].ConnectionString; }
        }
    }
}
