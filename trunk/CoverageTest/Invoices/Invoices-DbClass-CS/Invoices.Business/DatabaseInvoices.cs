using System.Configuration;

namespace Invoices.Business
{
    /// <summary>Class that provides the connection
    /// strings used by the application.</summary>
    internal static class Database
    {
        /// <summary>Connection string to the Invoices database.</summary>
        internal static string InvoicesConnection
        {
            get { return ConfigurationManager.ConnectionStrings["Invoices"].ConnectionString; }
        }
    }
}
