using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBSchemaInfo.Base;
namespace DBSchemaInfo.MsSql
{
    public class SqlColumnInfo : DBSchemaInfo.Base.InformationSchemaColumnBase 
    {

        System.Data.SqlDbType _sqlDbType = System.Data.SqlDbType.NVarChar;
        

        public SqlColumnInfo(DBStructure.INFORMATION_SCHEMA_COLUMNSRow dr) : base(dr)
        {
        }
        public SqlColumnInfo(SqlDataReader dr, int idx)
            : base()
        {
            _ColumnName = dr.GetName(idx);
            _ColumnLength = 0;
            _ColumnScale = 0;
            _Order = idx;
            LoadTypeInformation(dr.GetDataTypeName(idx));
        }



        #region IColumnInfo Members

        public override string NativeTypeName
        {
            get { return _sqlDbType.ToString().ToLower(); }
        }

        public override System.Data.DbType DbType
        {
            get { return SqlTypeMapper.GetDbType(_sqlDbType); }
        }

        public override Type ManagedType
        {
            get { return SqlTypeMapper.GetManagedType(_sqlDbType); }
        }

         #endregion

        protected override void LoadTypeInformation(string type)
        {
            _sqlDbType = SqlTypeMapper.GetSqlDbType(type);
        }
    }
}
