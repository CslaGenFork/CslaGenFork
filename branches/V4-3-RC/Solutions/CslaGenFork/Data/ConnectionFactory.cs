using System;
using System.Data.SqlClient;
using System.Text;

namespace CslaGenerator.Data
{
    /// <summary>
    /// Summary description for ConnectionFactory.
    /// </summary>
    public class ConnectionFactory
    {
        #region Private Static Fields

        private const string PacketSize = "4096";
        private static string _connectionString = String.Empty;

        #endregion

        #region Internal Static Fields

        internal static string Server = String.Empty;
        internal static string Database = String.Empty;
        internal static string User = String.Empty;
        internal static string Password = String.Empty;
        internal static bool IntegratedSecurity;
        
        #endregion

        #region Private Constructors

        // Private constructor to make type uninstantiable
        private ConnectionFactory()
        {
        }

        #endregion

        #region Public Static Properties

        public static SqlConnection NewConnection
        {
            get
            {
                // The ADO Data Provider automatically performs Connection Pooling, so we just send instantiate
                // a new connection and it will handle pooling.
                BuildConnectionString();
                return new SqlConnection(_connectionString);
            }
        }

        public static string ConnectionString
        {
            get
            {
                if (_connectionString == String.Empty)
                {
                    BuildConnectionString();
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
                DecomposeConnectionString();
            }
        }

        #endregion

        #region Private Static Methods

        private static void BuildConnectionString()
        {
            if (Server == String.Empty && Database == String.Empty)
                return;

            var sb = new StringBuilder();
            if (IntegratedSecurity)
            {
                sb.Append("data source=");
                sb.Append(Server);
                sb.Append(";initial catalog=");
                sb.Append(Database);
                sb.Append(";integrated security=SSPI;");
            }
            else
            {
                sb.Append("Server=");
                sb.Append(Server);
                sb.Append(";Database=");
                sb.Append(Database);
                sb.Append(";persist security info=False;user id=");
                sb.Append(User);
                if (Password != String.Empty)
                {
                    sb.Append(";password=");
                    sb.Append(Password);
                }
                sb.Append(";packet size=");
                sb.Append(PacketSize);
            }
            _connectionString = sb.ToString();
        }

        private static void DecomposeConnectionString()
        {
            Server = ConnectionStringPart("data source=", ";initial catalog=");
            Database = ConnectionStringPart(";initial catalog=", ";integrated security=SSPI;");
            if (Server != string.Empty && Database != string.Empty)
            {
                IntegratedSecurity = true;
                return;
            }

            Server = ConnectionStringPart("Server=", ";Database=");
            Database = ConnectionStringPart(";Database=", ";persist security info=False;user id=");
            User = ConnectionStringPart(";persist security info=False;user id=", ";password=");
            Password = ConnectionStringPart(";password=", ";packet size=");
        }

        private static string ConnectionStringPart(string headString, string tailString)
        {
            var start = _connectionString.IndexOf(headString);
            if (start < 0)
                return string.Empty;

            var end = _connectionString.IndexOf(tailString);
            if (end < start)
                return string.Empty;

            start += headString.Length;

            return _connectionString.Substring(start, end - start);
        }

        #endregion
    }
}
