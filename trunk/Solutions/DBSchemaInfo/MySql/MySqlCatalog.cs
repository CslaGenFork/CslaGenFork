using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
namespace DBSchemaInfo.MySql
{
    public class MySqlCatalog : Base.InformationSchemaCatalogBase 
    {
        public MySqlCatalog(string cnString, string catalog)
            : base(new MySqlConnection(cnString), catalog)
        { }
        protected override System.Data.DataTable GetTableSchema(System.Data.IDbConnection cn)
        {
            return ((MySqlConnection)cn).GetSchema("Tables", new string[] { null, CatalogName });
        }

        protected override DBSchemaInfo.Base.ITableInfo CreateTableInfo(System.Data.DataRow dr, System.Data.IDbConnection cn)
        {
            return new MySqlTableInfo(dr, (MySqlConnection)cn);
        }
        protected override DBSchemaInfo.Base.IViewInfo CreateViewInfo(System.Data.DataRow dr, System.Data.IDbConnection cn)
        {
            return new MySqlTableInfo(dr, (MySqlConnection)cn);
        }
        protected override DataTable GetProcedureSchema(IDbConnection cn)
        {
            return ((MySqlConnection)cn).GetSchema("Procedures", new string[] { null, CatalogName });
        }

        protected override DBSchemaInfo.Base.IStoredProcedureInfo CreateProcedureInfo(DataRow dr, IDbConnection cn)
        {
            return new MySqlStoredProcedureInfo(dr, (MySqlConnection)cn);
        }
    }
}
