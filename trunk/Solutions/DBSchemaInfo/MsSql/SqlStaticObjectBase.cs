using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBSchemaInfo.Base;

namespace DBSchemaInfo.MsSql
{
    public class SqlStaticObjectBase : Base.InformationSchemaStaticObjectBase
    {

        public SqlStaticObjectBase(DBStructure.INFORMATION_SCHEMA_TABLESRow dr, ICatalog cat)
            : base(dr, cat)
        {
            
        }
    
        protected override Base.IColumnInfo CreateColumn(DBStructure.INFORMATION_SCHEMA_COLUMNSRow dr)
        {
            return new SqlColumnInfo(dr);
        }

        protected override DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable GetColumnsSchema(IDbCommand cmd)
        {
            DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable table = new DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable();
            //System.Data.SqlClient.SqlConnection scn = ((SqlConnection)cn);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(DBSchemaInfo.Properties.Resources.SqlServerGetColumn);
            sb.AppendLine(" WHERE");
            if (base.ObjectCatalog != null)
                sb.AppendFormat(" A.TABLE_CATALOG = '{0}' AND", base.ObjectCatalog);
            if (base.ObjectSchema != null)
                sb.AppendFormat(" A.TABLE_SCHEMA = '{0}' AND", base.ObjectSchema);
            sb.AppendFormat(" A.TABLE_NAME = '{0}'", base.ObjectName);
            sb.AppendLine("	ORDER BY A.TABLE_CATALOG, A.TABLE_SCHEMA, A.TABLE_NAME, A.ORDINAL_POSITION");
            cmd.CommandText = sb.ToString();
             using (SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd))
             {
                 da.Fill(table);
             }   
            
            return table;
        }

        public override void Reload(bool throwOnError)
        {
            using (SqlConnection cn = (SqlConnection)Catalog.CreateConnection())
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(DBSchemaInfo.Properties.Resources.SqlServerGetColumn);
                    sb.AppendLine("WHERE");
                    if (!string.IsNullOrEmpty(this.ObjectCatalog))
                    {
                        sb.AppendLine("A.TABLE_CATALOG = @Catalog AND");
                        cmd.Parameters.AddWithValue("@Catalog", this.ObjectCatalog);
                    }
                    if (!string.IsNullOrEmpty(this.ObjectSchema))
                    {
                        sb.AppendLine("A.TABLE_SCHEMA = @Schema AND");
                        cmd.Parameters.AddWithValue("@Schema", this.ObjectSchema);
                    }
                    sb.Append("A.TABLE_NAME = @Name");
                    cmd.Parameters.AddWithValue("@Name", this.ObjectName);
                    cmd.CommandText = sb.ToString();
                    using (SqlDataAdapter da = new SqlDataAdapter (cmd))
                    {
                        DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable table = new DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable ();
                        try
                        {
                            da.Fill(table);
                        }
                        catch (Exception ex)
                        {
                            if (throwOnError)
                                throw ex;
                        }
                        LoadColumnInfo(table);
                    }
                }
            	
            }
        }

    }
}
