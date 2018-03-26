using System.Configuration;

namespace Codisa.InterwayDocs.Business
{
    /// <summary>Class that provides the connection
    /// strings used by the application.</summary>
    internal static class Database
    {
        /// <summary>Connection string to the InterwayDocs database.</summary>
        internal static string InterwayDocsConnection
        {
            get { return ConfigurationManager.ConnectionStrings["InterwayDocs"].ConnectionString; }
        }
    }
}
