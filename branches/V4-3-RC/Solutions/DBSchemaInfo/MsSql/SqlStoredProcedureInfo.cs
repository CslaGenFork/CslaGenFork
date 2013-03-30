using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBSchemaInfo.Base;

namespace DBSchemaInfo.MsSql
{
    public class SqlStoredProcedureInfo : InformationSchemaProcedureBase
    {
        [Browsable(false)]
        public new ICatalog Catalog { get; set; }

        public new string ObjectCatalog { get { return base.ObjectCatalog; } }
        public new string ObjectSchema { get { return base.ObjectSchema; } }
        public new string ObjectName { get { return base.ObjectName; } }
        [ReadOnly(true)]
        public new string ObjectDescription { get { return base.ObjectDescription; } }
        public new bool IsLoaded { get { return base.IsLoaded; } }
        public new ReadOnlyList<IParameter> Parameters { get { return base.Parameters; } }
        public new ReadOnlyList<IResultSet> ResultSets { get { return base.ResultSets; } }

        public SqlStoredProcedureInfo(DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr, ICatalog cat)
            : base(dr, cat)
        { }

        protected override IDataAdapter GetDataAdapter(IDbCommand cmd)
        {
            return new SqlDataAdapter((SqlCommand)cmd);
        }

        protected override ReadOnlyList<IParameter> GetParameters(DBStructure.INFORMATION_SCHEMA_PARAMETERSRow[] rows)
        {
            var list = new List<IParameter>();
            foreach (DBStructure.INFORMATION_SCHEMA_PARAMETERSRow dr in rows)
            {
                //if (dr["PARAMETER_MODE"].ToString() != "OUT")
                list.Add(new SqlStoredProcedureParameter(dr));
            }
            return new ReadOnlyList<IParameter>(list.ToArray());
        }

        protected override ReadOnlyList<IParameter> GetParameters(IDbConnection cn)
        {
            var dt = new DBStructure.INFORMATION_SCHEMA_PARAMETERSDataTable();
            using (var cmd = (SqlCommand)cn.CreateCommand())
            {
                var sb = new StringBuilder();
                sb.AppendLine(Properties.Resources.SqlServerGetParameters);
                sb.AppendLine("WHERE");
                if (!string.IsNullOrEmpty(ObjectCatalog))
                {
                    sb.Append("SPECIFIC_CATALOG = @Catalog");
                    cmd.Parameters.AddWithValue("@Catalog", ObjectCatalog);
                }
                if (!string.IsNullOrEmpty(ObjectSchema))
                {
                    sb.Append("SPECIFIC_SCHEMA = @Schema");
                    cmd.Parameters.AddWithValue("@Schema", ObjectSchema);
                }
                sb.Append("SPECIFIC_NAME = @Name");
                cmd.Parameters.AddWithValue("@Name", ObjectName);

                cmd.CommandText = sb.ToString();
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            var rows = new DBStructure.INFORMATION_SCHEMA_PARAMETERSRow[dt.Count];
            return GetParameters(rows);
        }

        protected override void LoadResultSets(IDbConnection cn, bool throwOnError)
        {
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = "SET ROWCOUNT 1";
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    if (throwOnError)
                        throw;
                }
            }
            base.LoadResultSets(cn, throwOnError);
        }

        protected override IResultSet GetResultSet(IDataReader dr, int rsNum)
        {
            var rs = new SqlResultSet((SqlDataReader)dr);
            rs.ResultIndex = rsNum;
            return rs;
        }
    }
}
