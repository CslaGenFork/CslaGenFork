using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using DBSchemaInfo.Base;

namespace DBSchemaInfo.MsSql
{
    public class SqlResultSet : IResultSet
    {
        public SqlResultSet(SqlDataReader dr)
        {
            ResultIndex = 0;
            Type = ResultType.StoredProcedure;
            var list = new List<IColumnInfo>();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                list.Add(new SqlColumnInfo(dr, i));
            }
            Columns = new ColumnInfoCollection(list);
        }

        #region IResultSet Members

        [Browsable(false)]
        public ColumnInfoCollection Columns { get; private set; }

        public int ResultIndex { get; protected internal set; }

        public ResultType Type { get; private set; }

        #endregion
    }
}
