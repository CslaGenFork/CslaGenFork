using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBSchemaInfo.Base;
namespace DBSchemaInfo.MsSql
{
    public class SqlStoredProcedureInfo : Base.InformationSchemaProcedureBase
    {

        public SqlStoredProcedureInfo(DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr, ICatalog cat)
            : base(dr, cat)
        {}

        protected override System.Data.IDataAdapter GetDataAdapter(System.Data.IDbCommand cmd)
        {
            return new SqlDataAdapter((SqlCommand)cmd);
        }

        protected override DBSchemaInfo.Base.ReadOnlyList<IParameter> GetParameters(DBStructure.INFORMATION_SCHEMA_PARAMETERSRow[] rows)
        {
            List<Base.IParameter> list = new List<DBSchemaInfo.Base.IParameter>();
            foreach (DBStructure.INFORMATION_SCHEMA_PARAMETERSRow dr in rows)
            {
                //if (dr["PARAMETER_MODE"].ToString() != "OUT")
                    list.Add(new SqlStoredProcedureParameter(dr));
            }
            return new ReadOnlyList<IParameter>(list.ToArray());
        }

        protected override ReadOnlyList<IParameter> GetParameters(IDbConnection cn)
        {
            DBStructure.INFORMATION_SCHEMA_PARAMETERSDataTable dt = new DBStructure.INFORMATION_SCHEMA_PARAMETERSDataTable();
            using (SqlCommand cmd = (SqlCommand)cn.CreateCommand())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(DBSchemaInfo.Properties.Resources.SqlServerGetParameters);
                sb.AppendLine("WHERE");
                if (!string.IsNullOrEmpty(this.ObjectCatalog))
                {
                    sb.Append("SPECIFIC_CATALOG = @Catalog");
                    cmd.Parameters.AddWithValue("@Catalog", this.ObjectCatalog);
                }
                if (!string.IsNullOrEmpty(this.ObjectSchema))
                {
                    sb.Append("SPECIFIC_SCHEMA = @Schema");
                    cmd.Parameters.AddWithValue("@Schema", this.ObjectSchema);
                }
                sb.Append("SPECIFIC_NAME = @Name");
                cmd.Parameters.AddWithValue("@Name", this.ObjectName);

                cmd.CommandText = sb.ToString();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            DBStructure.INFORMATION_SCHEMA_PARAMETERSRow[] rows = new DBStructure.INFORMATION_SCHEMA_PARAMETERSRow[dt.Count];
            return GetParameters(rows);
        }

        protected override void LoadResultSets(IDbConnection cn, bool throwOnError)
        {
            using (IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = "SET ROWCOUNT 1";
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (throwOnError)
                        throw ex;
                }
            }
            base.LoadResultSets(cn, throwOnError);
        }
        

        protected override DBSchemaInfo.Base.IResultSet GetResultSet(IDataReader dr, int rsNum)
        {
            SqlResultSet rs = new SqlResultSet((SqlDataReader)dr);
            rs.ResultIndex=rsNum;
            return rs;
        }
    }
}
