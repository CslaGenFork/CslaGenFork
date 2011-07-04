using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DBSchemaInfo.Base;

namespace DBSchemaInfo.MsSql
{
    public class SqlCatalog : InformationSchemaCatalogBase
    {
        public SqlCatalog(string cnString, string catalog)
            : base(cnString, catalog)
        {
        }

        protected override DBStructure GetTableViewSchema(IDbConnection cn)
        {
            var ds = new DBStructure();

            using (var cmd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", (SqlConnection)cn))
            {
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds.INFORMATION_SCHEMA_TABLES);
                }
            }
            using (var cmd = new SqlCommand(Properties.Resources.SqlServerGetColumn, (SqlConnection)cn))
            {
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds.INFORMATION_SCHEMA_COLUMNS);
                }
            }
            return ds;
        }

        protected override ITableInfo CreateTableInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr)
        {
            return new SqlTableInfo(dr, this);
        }

        protected override IViewInfo CreateViewInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr)
        {
            return new SqlViewInfo(dr, this);
        }

        protected override void LoadForeignKeys()
        {
            DataTable table = GetConstraintInformation();
            var fkeys = new Dictionary<string, StandardForeignKeyConstraint>();
            foreach (DataRow dr in table.Rows)
            {
                try
                {
                    StandardForeignKeyConstraint constraint;
                    var constraintName = (string)dr["CONSTRAINT_NAME"];
                    if (!fkeys.ContainsKey(constraintName))
                    {
                        ITableInfo cnstTable =
                            Tables[(string)dr["TABLE_CATALOG"], (string)dr["TABLE_SCHEMA"], (string)dr["TABLE_NAME"]];
                        cnstTable.Catalog = this;
                        ITableInfo pkTable =
                            Tables[
                                (string)dr["REF_TABLE_CATALOG"], (string)dr["REF_TABLE_SCHEMA"],
                                (string)dr["REF_TABLE_NAME"]];
                        pkTable.Catalog = this;
                        constraint =
                            new StandardForeignKeyConstraint(
                                constraintName, pkTable, cnstTable);
                        fkeys.Add(constraintName, constraint);
                    }
                    constraint = fkeys[constraintName];
                    var cp = new StandardForeignKeyColumnPair(
                        constraint.PKTable.Columns[(string)dr["REF_COLUMN_NAME"]],
                        constraint.ConstraintTable.Columns[(string)dr["COLUMN_NAME"]]);
                    constraint.Columns.Add(cp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"Failed reading constraint: {0}", ex.Message);
                }
            }
            foreach (string constraintName in fkeys.Keys)
            {
                ForeignKeyConstraints.Add(fkeys[constraintName]);
                foreach (var columnPair in fkeys[constraintName].Columns)
                {
                    columnPair.FKColumn.FKConstraint = fkeys[constraintName];
                }
            }
        }

        private DataTable GetConstraintInformation()
        {
            var table = new DataTable();
            var sb = new System.Text.StringBuilder();
            sb.Append("	select object_name(constid) CONSTRAINT_NAME, ");
            sb.Append(
                "	db_name() TABLE_CATALOG, SCHEMA_NAME(o1.uid) TABLE_SCHEMA, o1.name TABLE_NAME, c1.name COLUMN_NAME,");
            sb.Append(
                "	db_name() REF_TABLE_CATALOG, SCHEMA_NAME(o2.uid) REF_TABLE_SCHEMA, o2.name REF_TABLE_NAME, c2.name  REF_COLUMN_NAME");
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
            OpenConnection();
            try
            {
                var cn = (SqlConnection)Connection;
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sb.ToString();
                    cmd.CommandType = CommandType.Text;
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return table;
        }

        protected override void LoadDescriptions()
        {
            DataTable dt = GetColumnsDescriptionInformation();

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    var schema = (string) dr["SchemaOwner"];
                    var objectName = (string) dr["ObjectName"];
                    var objectType = (string) dr["ObjectType"];
                    var description = (string) dr["Description"];
                    if (dr.IsNull("ColumnName"))
                    {
                        if (objectType == "U ")
                            Tables[CatalogName, schema, objectName].ObjectDescription = description;
                        else if (objectType == "V ")
                            Views[CatalogName, schema, objectName].ObjectDescription = description;
                        else if (objectType == "P ")
                            Procedures[CatalogName, schema, objectName].ObjectDescription = description;
                    }
                    else
                        Tables[CatalogName, schema, objectName].Columns[(string) dr["ColumnName"]].ColumnDescription =
                            description;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"Failed reading descriptions: {0}", ex.Message);
                }
            }
        }

        private DataTable GetColumnsDescriptionInformation()
        {
            var table = new DataTable();
            var sb = new System.Text.StringBuilder();
            sb.Append(" SELECT   s.name AS SchemaOwner,");
            sb.Append("          o.Name AS ObjectName,");
            sb.Append("          o.type AS ObjectType,");
            sb.Append("          c.name AS ColumnName,");
            sb.Append("          ep.value AS Description");
            sb.Append(" FROM     sys.objects o INNER JOIN sys.extended_properties ep");
            sb.Append("          ON o.object_id = ep.major_id");
            sb.Append("          INNER JOIN sys.schemas s");
            sb.Append("          ON o.schema_id = s.schema_id");
            sb.Append("          LEFT JOIN syscolumns c");
            sb.Append("          ON ep.minor_id = c.colid");
            sb.Append("          AND ep.major_id = c.id");
            sb.Append(" WHERE    (o.type ='U' AND c.name IS NOT NULL) OR ");
            sb.Append("          ((o.type ='U' OR o.type ='V' OR o.type ='P') AND c.name IS NULL AND ep.name LIKE '%Description')");
            sb.Append(" ORDER BY SchemaOwner, ObjectName, ObjectType, ColumnName");
            OpenConnection();
            try
            {
                var cn = (SqlConnection)Connection;
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sb.ToString();
                    cmd.CommandType = CommandType.Text;
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return table;
        }

        protected override DBStructure GetProcedureSchema(IDbConnection cn)
        {
            var ds = new DBStructure();
            var scn = (SqlConnection)cn;
            //.GetSchema("Procedures", new string[] { Catalog });
            var sb = new System.Text.StringBuilder();
            if (scn.ServerVersion.StartsWith("08"))
            {
                sb.AppendLine(Properties.Resources.SqlServerGetProcedures2000);
            }
            else
            {
                sb.AppendLine(Properties.Resources.SqlServerGetProcedures2005);
            }

            sb.AppendLine();
            sb.AppendLine(Properties.Resources.SqlServerGetParameters);
            using (SqlCommand cmd = scn.CreateCommand())
            {
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.TableMappings.Add("Table", "INFORMATION_SCHEMA_ROUTINES");
                    da.TableMappings.Add("Table1", "INFORMATION_SCHEMA_PARAMETERS");
                    ds.EnforceConstraints = false;
                    da.Fill(ds);
                }
            }
            return ds;
        }

        protected override IStoredProcedureInfo CreateProcedureInfo(DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr)
        {
            return new SqlStoredProcedureInfo(dr, this);
        }

        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}

