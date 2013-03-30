using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBSchemaInfo.Base;
using System.Collections;
namespace DBSchemaInfo.MsSql
{
    public class SqlCatalog : Base.InformationSchemaCatalogBase 
    {

        public SqlCatalog(string cnString, string catalog)
            : base(cnString, catalog)
        {
        }


        protected override DBStructure GetTableViewSchema(IDbConnection cn)
        {
            DBStructure ds = new DBStructure();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", (SqlConnection)cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds.INFORMATION_SCHEMA_TABLES);
                }
            }
            using (SqlCommand cmd = new SqlCommand(DBSchemaInfo.Properties.Resources.SqlServerGetColumn, (SqlConnection)cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds.INFORMATION_SCHEMA_COLUMNS);
                }
            }
            return ds;
        }

        protected override DBSchemaInfo.Base.ITableInfo CreateTableInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr)
        {
            return new SqlTableInfo(dr, this);
        }
        protected override DBSchemaInfo.Base.IViewInfo CreateViewInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr)
        {
            return new SqlViewInfo(dr, this);
        }

        protected override void LoadForeignKeys()
        {
            DataTable table = GetConstraintInformation();
            Dictionary<string, StandardForeignKeyConstraint> fkeys = new Dictionary<string, StandardForeignKeyConstraint>();
            foreach (DataRow dr in table.Rows)
            {
                try
                {

                    StandardForeignKeyConstraint constraint = null;
                    string constraintName = (string)dr["CONSTRAINT_NAME"];
                    if (!fkeys.ContainsKey(constraintName))
                    {
                        ITableInfo cnstTable = Tables[(string)dr["TABLE_CATALOG"], (string)dr["TABLE_SCHEMA"], (string)dr["TABLE_NAME"]];
                        ITableInfo pkTable = Tables[(string)dr["REF_TABLE_CATALOG"], (string)dr["REF_TABLE_SCHEMA"], (string)dr["REF_TABLE_NAME"]];
                        constraint =
                            new StandardForeignKeyConstraint(
                                constraintName, pkTable, cnstTable);
                        fkeys.Add(constraintName, constraint);
                    }
                    constraint = fkeys[constraintName];
                    StandardForeignKeyColumnPair cp = new StandardForeignKeyColumnPair(
                        constraint.PKTable.Columns[(string)dr["REF_COLUMN_NAME"]],
                        constraint.ConstraintTable.Columns[(string)dr["COLUMN_NAME"]]);
                    constraint.Columns.Add(cp);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed reading constraint: {0}", ex.Message);
                }
            }
            foreach (string constraintName in fkeys.Keys)
            {
                ForeignKeyConstraints.Add(fkeys[constraintName]);
            }
        }




        private DataTable GetConstraintInformation()
        {
            DataTable table = new DataTable();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("	select object_name(constid) CONSTRAINT_NAME, ");
            sb.Append("	db_name() TABLE_CATALOG, user_name(o1.uid) TABLE_SCHEMA, o1.name TABLE_NAME, c1.name COLUMN_NAME,");
            sb.Append("	db_name() REF_TABLE_CATALOG, user_name(o2.uid) REF_TABLE_SCHEMA, o2.name REF_TABLE_NAME, c2.name  REF_COLUMN_NAME");
            sb.Append("	from sysforeignkeys a");
            sb.Append("	INNER JOIN syscolumns c1");
            sb.Append("		ON a.fkeyid = c1.id");
            sb.Append("		AND a.fkey = c1.colid");
            sb.Append("	INNER JOIN syscolumns c2");
            sb.Append("		ON a.rkeyid = c2.id");
            sb.Append("		AND a.rkey = c2.colid");
            sb.Append("	INNER JOIN sysobjects o1");
            sb.Append("		ON c1.id = o1.id");
            sb.Append("	INNER JOIN sysobjects o2");
            sb.Append("		ON c2.id = o2.id");
            //sb.Append(" WHERE constid in (");
            //sb.Append("         SELECT object_id(CONSTRAINT_NAME)");
            //sb.Append("         FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS)");
            base.OpenConnection();
            try
            {
                SqlConnection cn = (SqlConnection)Connection;
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sb.ToString();
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(table);
                    }
                }
            }
            finally
            {
                base.CloseConnection();
            }
            return table;
        }

        protected override DBStructure GetProcedureSchema(IDbConnection cn)
        {
            DBStructure ds = new DBStructure();
            SqlConnection scn = (SqlConnection)cn;
            //.GetSchema("Procedures", new string[] { Catalog });
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (scn.ServerVersion.StartsWith("08"))
            {
                sb.AppendLine(DBSchemaInfo.Properties.Resources.SqlServerGetProcedures2000);
            }
            else
            {
                sb.AppendLine(DBSchemaInfo.Properties.Resources.SqlServerGetProcedures2005);
            }

            sb.AppendLine();
            sb.AppendLine(DBSchemaInfo.Properties.Resources.SqlServerGetParameters);
            using (SqlCommand cmd = scn.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.TableMappings.Add("Table", "INFORMATION_SCHEMA_ROUTINES");
                    da.TableMappings.Add("Table1", "INFORMATION_SCHEMA_PARAMETERS");
                    ds.EnforceConstraints = false;
                    da.Fill(ds);
                }
            }
            return ds;
        }

        protected override DBSchemaInfo.Base.IStoredProcedureInfo CreateProcedureInfo(DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr)
        {
            return new SqlStoredProcedureInfo(dr, this);
        }

        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }

}
