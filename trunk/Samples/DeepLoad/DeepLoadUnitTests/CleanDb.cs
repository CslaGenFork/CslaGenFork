using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DeepLoadUnitTests
{
    internal static class CleanDb
    {
        public static string ConnectionString { get; private set; }

        internal static void DoClean()
        {
            if (ConnectionString == null)
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DeepLoad"].ConnectionString;
            }

            var startupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            startupPath = startupPath.Replace("file:\\", string.Empty);
            var queryText = System.IO.File.ReadAllText(startupPath + @"\CleanDB.sql");

            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                using (var cmd = new SqlCommand(queryText, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
