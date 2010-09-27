using System;
using System.Configuration;
using System.Data;
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
	internal static string	_Server = String.Empty;
	internal static string	_Database = String.Empty;
	internal static string	_User = String.Empty;
	internal static string	_Password = String.Empty;
	private static readonly string	_PacketSize = "4096";
	private static string			_ConnectionString = String.Empty;
	internal static bool _IntegratedSecurity=false;
	public bool IntegratedSecurity
	{
		get
		{
			return _IntegratedSecurity;
		}
		set
		{
			_IntegratedSecurity = value;
		}
	}
	#endregion

	#region Constructors
	// Type Constructor
	static ConnectionFactory()
	{
	}
	
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
			return new SqlConnection(_ConnectionString);
		}
	}

	public static string ConnectionString
	{
		get 
		{ 
			if (_ConnectionString == String.Empty) { BuildConnectionString(); }
			return _ConnectionString;
		}
		set { _ConnectionString = value; }
	}
	#endregion

	#region Private Static Methods
	private static void BuildConnectionString()
	{
		if (_Server == String.Empty && _Database == String.Empty)
			return;
		StringBuilder sb = new StringBuilder();
		if (_IntegratedSecurity)
		{
			sb.Append("data source=");
			sb.Append(_Server);
			sb.Append(";initial catalog=");
			sb.Append(_Database);
			sb.Append(";integrated security=SSPI;");
		}
		else
		{
			sb.Append("Server=");
			sb.Append(_Server);
			sb.Append(";Database=");
			sb.Append(_Database);
			sb.Append(";persist security info=False;user id=");
			sb.Append(_User);
			if (_Password != String.Empty)
			{
				sb.Append(";password=");
				sb.Append(_Password);
			}
			sb.Append(";packet size=");
			sb.Append(_PacketSize);
		}
		_ConnectionString = sb.ToString();
	}
	#endregion
}
}
