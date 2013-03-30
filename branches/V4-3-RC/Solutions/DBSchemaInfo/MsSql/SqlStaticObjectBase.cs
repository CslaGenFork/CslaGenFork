using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBSchemaInfo.Base;

namespace DBSchemaInfo.MsSql
{
    public class SqlStaticObjectBase : InformationSchemaStaticObjectBase
    {
        public SqlStaticObjectBase(DBStructure.INFORMATION_SCHEMA_TABLESRow dr, ICatalog cat)
            : base(dr, cat)
        {

        }

        protected override IColumnInfo CreateColumn(DBStructure.INFORMATION_SCHEMA_COLUMNSRow dr)
        {
            return new SqlColumnInfo(dr);
        }

        protected override DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable GetColumnsSchema(IDbCommand cmd)
        {
            var table = new DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable();
            //System.Data.SqlClient.SqlConnection scn = ((SqlConnection)cn);
            var sb = new StringBuilder();
            sb.AppendLine(Properties.Resources.SqlServerGetColumn);
            sb.AppendLine(" WHERE");
            if (ObjectCatalog != null)
                sb.AppendFormat(" A.TABLE_CATALOG = '{0}' AND", ObjectCatalog);
            if (ObjectSchema != null)
                sb.AppendFormat(" A.TABLE_SCHEMA = '{0}' AND", ObjectSchema);
            sb.AppendFormat(" A.TABLE_NAME = '{0}'", ObjectName);
            sb.AppendLine("	ORDER BY A.TABLE_CATALOG, A.TABLE_SCHEMA, A.TABLE_NAME, A.ORDINAL_POSITION");
            cmd.CommandText = sb.ToString();
            using (var da = new SqlDataAdapter((SqlCommand)cmd))
            {
                da.Fill(table);
            }

            return table;
        }

        public override void Reload(bool throwOnError)
        {
            using (var cn = (SqlConnection)Catalog.CreateConnection())
            {
                using (var cmd = cn.CreateCommand())
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(Properties.Resources.SqlServerGetColumn);
                    sb.AppendLine("WHERE");
                    if (!string.IsNullOrEmpty(ObjectCatalog))
                    {
                        sb.AppendLine("A.TABLE_CATALOG = @Catalog AND");
                        cmd.Parameters.AddWithValue("@Catalog", ObjectCatalog);
                    }
                    if (!string.IsNullOrEmpty(ObjectSchema))
                    {
                        sb.AppendLine("A.TABLE_SCHEMA = @Schema AND");
                        cmd.Parameters.AddWithValue("@Schema", ObjectSchema);
                    }
                    sb.Append("A.TABLE_NAME = @Name");
                    cmd.Parameters.AddWithValue("@Name", ObjectName);
                    cmd.CommandText = sb.ToString();
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var table = new DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable();
                        try
                        {
                            da.Fill(table);
                        }
                        catch (Exception)
                        {
                            if (throwOnError)
                                throw;
                        }
                        LoadColumnInfo(table);
                    }
                }
            }
        }
    }
}
