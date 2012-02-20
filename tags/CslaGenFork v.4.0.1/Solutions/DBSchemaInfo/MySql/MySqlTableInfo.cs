using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
namespace DBSchemaInfo.MySql
{
    class MySqlTableInfo : Base.InformationSchemaTableBase
    {
        public MySqlTableInfo(DataRow dr, MySqlConnection cn) : base(dr, cn) { }

        protected override Base.IColumnInfo CreateColumn(System.Data.DataRow dr)
        {
            return new MySqlColumnInfo(dr);
        }

        protected override System.Data.DataTable GetColumnsSchema(System.Data.IDbCommand cmd)
        {
            DataTable table = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter((MySqlCommand)cmd))
            {
                da.Fill(table);
            }
            return table;
            //return ((MySqlConnection)cn).GetSchema("Columns", new string[] {ObjectCatalog, ObjectSchema, ObjectName });
        }
    }
}
