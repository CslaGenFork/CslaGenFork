using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data.SqlClient;
namespace DBSchemaInfo.MsSql
{
    public class SqlResultSet : Base.IResultSet
    {

        public SqlResultSet(SqlDataReader dr)
        {
            List<Base.IColumnInfo> list = new List<DBSchemaInfo.Base.IColumnInfo>();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                list.Add(new SqlColumnInfo(dr, i));
            }
            _Columns  = new DBSchemaInfo.Base.ColumnInfoCollection(list);
        }
        private DBSchemaInfo.Base.ColumnInfoCollection _Columns;
        private Base.ResultType _Type = DBSchemaInfo.Base.ResultType.StoredProcedure;

        #region IResultSet Members

        [Browsable(false)]
        public DBSchemaInfo.Base.ColumnInfoCollection Columns
        {
            get { return _Columns; }
        }

        protected int _ResultIndex = 0;
        public int ResultIndex
        {
            get
            {
                return _ResultIndex;
            }
            internal set
            {
                _ResultIndex = value;
            }
        }

        public Base.ResultType Type
        {
            get
            {
                return _Type;
            }
        }

        #endregion

    }
}
