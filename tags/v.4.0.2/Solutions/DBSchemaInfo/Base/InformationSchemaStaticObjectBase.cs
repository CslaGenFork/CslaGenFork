using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;

namespace DBSchemaInfo.Base
{
    public abstract class InformationSchemaStaticObjectBase : DBSchemaInfo.Base.InformationSchemaObjectBase, DBSchemaInfo.Base.IResultSet
    {
        public InformationSchemaStaticObjectBase(DBStructure.INFORMATION_SCHEMA_TABLESRow dr, ICatalog cat)
            : base(dr, cat)
        {
            if (dr["TABLE_TYPE"].ToString() == "VIEW")
                _Type = ResultType.View;
            LoadColumnInfo(dr.GetINFORMATION_SCHEMA_COLUMNSRows());
        }
        protected abstract IColumnInfo CreateColumn(DBStructure.INFORMATION_SCHEMA_COLUMNSRow dr);

        protected abstract DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable GetColumnsSchema(IDbCommand cmd);

        protected internal virtual void LoadColumnInfo(IEnumerable<DBStructure.INFORMATION_SCHEMA_COLUMNSRow> rows)
        {
            List<IColumnInfo> list = new List<IColumnInfo>();
            foreach (DBStructure.INFORMATION_SCHEMA_COLUMNSRow row in rows)
            {
                list.Add(CreateColumn(row));
            }
            list.Sort((a, b) => a.Order.CompareTo(b.Order));
            _Columns = new ColumnInfoCollection(list);
        }
        protected internal virtual void LoadColumnInfo(IDbConnection cn)
        {
            DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable table = null;
            using (IDbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = GetColumnsSchemaSearchString();
                cmd.CommandType = CommandType.Text;
                table = GetColumnsSchema(cmd);
            }
            if (table == null)
            {
                return;
            }
            
            LoadColumnInfo(table);
        }

        protected internal void LoadColumnInfo(DBStructure.INFORMATION_SCHEMA_COLUMNSDataTable table)
        {
            DBStructure.INFORMATION_SCHEMA_COLUMNSRow[] rows = new DBStructure.INFORMATION_SCHEMA_COLUMNSRow[table.Rows.Count];
            table.Rows.CopyTo(rows, 0);
            LoadColumnInfo(rows);
        }

        protected virtual void LoadPKInfo()
        {
        }


        private string GetColumnsSchemaSearchString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("	SELECT A.*, CASE WHEN B.COLUMN_NAME IS NULL THEN 0 ELSE 1 END AS IS_PRIMARY_KEY");
            sb.Append(" , 0 AS IS_IDENTITY");
            sb.Append("	FROM INFORMATION_SCHEMA.COLUMNS A");
            sb.Append("	LEFT OUTER JOIN (");
            sb.Append("	SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE");
            sb.Append("	WHERE CONSTRAINT_NAME IN (");
            sb.Append("		SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS");
            sb.Append("		WHERE CONSTRAINT_TYPE = 'PRIMARY KEY')");
            sb.Append("	) B");
            sb.Append("	ON CASE WHEN A.TABLE_CATALOG IS NULL THEN '' ELSE A.TABLE_CATALOG END  = CASE WHEN B.TABLE_CATALOG IS NULL THEN '' ELSE B.TABLE_CATALOG END");
            sb.Append("	AND CASE WHEN A.TABLE_SCHEMA IS NULL THEN '' ELSE A.TABLE_SCHEMA END  = CASE WHEN B.TABLE_SCHEMA IS NULL THEN '' ELSE B.TABLE_SCHEMA END");
            sb.Append("	AND A.TABLE_NAME = B.TABLE_NAME");
            sb.Append("	AND A.COLUMN_NAME = B.COLUMN_NAME");
            sb.Append(" WHERE");
            if (base.ObjectCatalog != null)
                sb.AppendFormat(" A.TABLE_CATALOG = '{0}' AND", base.ObjectCatalog);
            if (base.ObjectSchema != null)
                sb.AppendFormat(" A.TABLE_SCHEMA = '{0}' AND", base.ObjectSchema);
            sb.AppendFormat(" A.TABLE_NAME = '{0}'", base.ObjectName);
            sb.Append("	ORDER BY A.TABLE_CATALOG, A.TABLE_SCHEMA, A.TABLE_NAME, A.ORDINAL_POSITION");
            return sb.ToString();
        }

        private ColumnInfoCollection _Columns;
        private int _ResultIndex = 0;
        private Base.ResultType _Type = DBSchemaInfo.Base.ResultType.Table;
        [Browsable(false)]
        public ColumnInfoCollection Columns
        {
            get
            {
                return _Columns;
            }
            protected set
            {
                _Columns = value;
            }
        }

        
        public int ResultIndex
        {
            get
            {
                return _ResultIndex;
            }
        }

        public Base.ResultType Type
        {
            get
            {
                return _Type;
            }
        }

    }
}
