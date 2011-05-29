using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
namespace DBSchemaInfo.MySql
{
    class MySqlColumnInfo : Base.InformationSchemaColumnBase 
    {
        MySqlDbType _mySqlDbType = MySqlDbType.String;
        public MySqlColumnInfo(DataRow dr) : base(dr)
        {

        }

        public override string NativeType
        {
            get { return _mySqlDbType.ToString(); }
        }

        public override System.Data.DbType DbType
        {
            get { return DbType.Int32; }
        }

        public override Type ManagedType
        {
            get { return typeof (int); }
        }

        protected override void LoadTypeInformation(string type)
        {
            string tempType = FixDbType(type);
            
            
            _mySqlDbType = (MySqlDbType)Enum.Parse(typeof(MySqlDbType), tempType, true);
        }

        string FixDbType(string type)
        {
            type = type.ToLower();
            if (type.Contains("text") || type.Contains("char"))
                return "string";
            switch (type)
            {
                case "int":
                    return "int32";
                case "bigint":
                    return "int64";
                case "smallint":
                    return "int16";
                case "tinyint":
                    return "byte";
                default:
                    return type;
            }
        }
    }
}
