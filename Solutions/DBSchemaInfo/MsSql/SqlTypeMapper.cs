using System;
using System.Data;
namespace DBSchemaInfo.MsSql
{
    class SqlTypeMapper
    {
        public static Type GetManagedType(System.Data.SqlDbType nativeType)
        {
            switch (nativeType)
            {
                case System.Data.SqlDbType.BigInt:
                    return typeof(Int64);
                case System.Data.SqlDbType.Binary:
                case System.Data.SqlDbType.Image:
                case System.Data.SqlDbType.Timestamp:
                case System.Data.SqlDbType.VarBinary:
                    return typeof(byte[]);
                case System.Data.SqlDbType.Bit:
                    return typeof(bool);
                case System.Data.SqlDbType.Char:
                case System.Data.SqlDbType.NChar:
                case System.Data.SqlDbType.NText:
                case System.Data.SqlDbType.NVarChar:
                case System.Data.SqlDbType.Text:
                case System.Data.SqlDbType.VarChar:
                case System.Data.SqlDbType.Xml:
                    return typeof(string);
                case System.Data.SqlDbType.DateTime:
                    return typeof(DateTime);
                case System.Data.SqlDbType.Decimal:
                case System.Data.SqlDbType.Money:
                case System.Data.SqlDbType.SmallMoney:
                    return typeof(decimal);
                case System.Data.SqlDbType.Float:
                    return typeof(double);
                case System.Data.SqlDbType.Int:
                    return typeof(int);
                case System.Data.SqlDbType.Real:
                    return typeof(Single);
                case System.Data.SqlDbType.UniqueIdentifier:
                    return typeof(Guid);
                case System.Data.SqlDbType.SmallDateTime:
                    return typeof(DateTime);
                case System.Data.SqlDbType.SmallInt:
                    return typeof(Int16);
                case System.Data.SqlDbType.TinyInt:
                    return typeof(byte);
                case System.Data.SqlDbType.Variant:
                case System.Data.SqlDbType.Udt:
                default:
                    return typeof(object);
            }
        }

        public static System.Data.DbType GetDbType(System.Data.SqlDbType nativeType)
        {
            switch (nativeType)
            {
                case System.Data.SqlDbType.BigInt:
                    return DbType.Int64;
                case System.Data.SqlDbType.Binary:
                case System.Data.SqlDbType.Image:
                case System.Data.SqlDbType.Timestamp:
                case System.Data.SqlDbType.VarBinary:
                    return DbType.Binary;
                case System.Data.SqlDbType.Bit:
                    return DbType.Boolean;
                case System.Data.SqlDbType.Char:
                case System.Data.SqlDbType.NChar:
                    return DbType.StringFixedLength;
                case System.Data.SqlDbType.NText:
                case System.Data.SqlDbType.NVarChar:
                case System.Data.SqlDbType.Text:
                case System.Data.SqlDbType.VarChar:
                case System.Data.SqlDbType.Xml:
                    return DbType.String;
                case System.Data.SqlDbType.DateTime:
                case System.Data.SqlDbType.SmallDateTime:
                    return DbType.DateTime;
                case System.Data.SqlDbType.Decimal:
                case System.Data.SqlDbType.Money:
                case System.Data.SqlDbType.SmallMoney:
                    return DbType.Decimal;
                case System.Data.SqlDbType.Float:
                    return DbType.Double;
                case System.Data.SqlDbType.Int:
                    return DbType.Int32;
                case System.Data.SqlDbType.Real:
                    return DbType.Single;
                case System.Data.SqlDbType.UniqueIdentifier:
                    return DbType.Guid;
                case System.Data.SqlDbType.SmallInt:
                    return DbType.Int16;
                case System.Data.SqlDbType.TinyInt:
                    return DbType.Byte;
                case System.Data.SqlDbType.Variant:
                case System.Data.SqlDbType.Udt:
                default:
                    return DbType.Object;
            }
        }

        public static SqlDbType GetSqlDbType(string type)
        {
            string tempType = type;
            if (tempType == "numeric")
                tempType = "decimal";
            return (SqlDbType)Enum.Parse(typeof(SqlDbType), tempType, true);
        }

    }
}
