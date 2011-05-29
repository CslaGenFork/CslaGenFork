using System;
using System.ComponentModel;
using System.Data.SqlClient;
using DBSchemaInfo.Base;

namespace DBSchemaInfo.MsSql
{
    public class SqlStoredProcedureParameter : IParameter
    {
        public SqlStoredProcedureParameter(DBStructure.INFORMATION_SCHEMA_PARAMETERSRow dr)
        {
            ColumnScale = 0;
            ColumnLength = 0;
            ParameterName = dr.PARAMETER_NAME;
            ParameterType = dr.DATA_TYPE;
            NativeType = ParameterType;

            _sqlDbType = SqlTypeMapper.GetSqlDbType(dr.DATA_TYPE);
            Order = Convert.ToInt32(dr.ORDINAL_POSITION);
            if (!dr.IsCHARACTER_MAXIMUM_LENGTHNull())
            {
                ColumnLength = dr.CHARACTER_MAXIMUM_LENGTH;
            }
            else if (!dr.IsNUMERIC_PRECISIONNull())
            {
                ColumnLength = Convert.ToInt64(dr.NUMERIC_PRECISION);
                if (!dr.IsNUMERIC_SCALENull())
                    ColumnScale = dr.NUMERIC_SCALE;
            }
            else if (!dr.IsDATETIME_PRECISIONNull())
            {
                ColumnLength = Convert.ToInt64(dr.DATETIME_PRECISION);
            }
        }

        readonly System.Data.SqlDbType _sqlDbType = System.Data.SqlDbType.NVarChar;

        #region IParameter Members

        public string ParameterName { get; private set; }
        public string ParameterType { get; private set; }
        public string CondensedDataType
        {
            get { return SqlTypeMapper.GetCondensedDataType(NativeType, ColumnLength, ColumnScale); }
        }
        [Browsable((false))]
        public string NativeType { get; private set; }
        [Browsable(false)]
        public long ColumnLength { get; private set; }
        [Browsable(false)]
        public int ColumnScale { get; private set; }
        [Browsable(false)]
        public int Order { get; private set; }
        public System.Data.DbType DbType
        {
            get { return SqlTypeMapper.GetDbType(_sqlDbType); }
        }
        public Type ManagedType
        {
            get { return SqlTypeMapper.GetManagedType(_sqlDbType); }
        }

        public System.Data.IDbDataParameter CreateNullParam()
        {
            var par = new SqlParameter();
            par.ParameterName = ParameterName;
            par.Value = DBNull.Value;
            return par;
        }

        #endregion
    }
}
