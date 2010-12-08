using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
namespace DBSchemaInfo.MySql
{
    public class MySqlStoredProcedureInfo : Base.InformationSchemaProcedureBase
    {

        public MySqlStoredProcedureInfo(DataRow dr, MySqlConnection cn) : base(dr, cn)
        {}

        protected override System.Data.IDataAdapter GetDataAdapter(System.Data.IDbCommand cmd)
        {
            return new MySqlDataAdapter((MySqlCommand)cmd);
        }

        protected override DBSchemaInfo.Base.IParameter[] GetParameters(IDbConnection cn)
        {
            return new Base.IParameter[] { };
        }

        protected override DBSchemaInfo.Base.IResultSet GetResultSet(IDataReader dr, int rsNum)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
