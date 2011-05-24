using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DBSchemaInfo.Base;
namespace DBSchemaInfo.MsSql
{
    public class SqlStoredProcedureParameter : Base.IParameter
    {
        public SqlStoredProcedureParameter(DBStructure.INFORMATION_SCHEMA_PARAMETERSRow dr)
        {
            _ParameterName = dr.PARAMETER_NAME;
            _ParameterType = dr.DATA_TYPE;

            _sqlDbType = SqlTypeMapper.GetSqlDbType(dr.DATA_TYPE);
            _Order = Convert.ToInt32(dr.ORDINAL_POSITION);
            if (!dr.IsCHARACTER_MAXIMUM_LENGTHNull())
            {
                _ColumnLength = dr.CHARACTER_MAXIMUM_LENGTH;
            }
            else if (!dr.IsNUMERIC_PRECISIONNull())
            {
                _ColumnLength = Convert.ToInt64(dr.NUMERIC_PRECISION);
                if (!dr.IsNUMERIC_SCALENull())
                    _ColumnScale = dr.NUMERIC_SCALE;
            }
            else if (!dr.IsDATETIME_PRECISIONNull())
            {
                _ColumnLength = Convert.ToInt64(dr.DATETIME_PRECISION);
            }
        }

        string _ParameterName;
        string _ParameterType;
        System.Data.SqlDbType _sqlDbType = System.Data.SqlDbType.NVarChar;
        Int64 _ColumnLength = 0;
        int _ColumnScale = 0;
        int _Order = 0;
        #region IParameter Members

        public string ParameterName
        {
            get { return _ParameterName; }
        }

        public string ParameterType
        {
            get { return _ParameterType; }
        }

        public string NativeTypeName
        {
            get { return _sqlDbType.ToString().ToLower(); }
        }

        public System.Data.DbType DbType
        {
            get { return SqlTypeMapper.GetDbType(_sqlDbType); }
        }

        public Type ManagedType
        {
            get { return SqlTypeMapper.GetManagedType(_sqlDbType); }
        }

        public Int64 ColumnLength
        {
            get { return _ColumnLength; }
        }

        public int ColumnScale
        {
            get { return _ColumnScale; }
        }
        public int Order
        {
            get
            {
                return _Order;
            }
        }


        public System.Data.IDbDataParameter CreateNullParam()
        {
            SqlParameter par = new SqlParameter();
            par.ParameterName = _ParameterName;
            par.Value = DBNull.Value;
            return par;
        }

        #endregion
    }
}
