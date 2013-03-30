using System;
using System.Collections.Generic;
using System.Data;

namespace DBSchemaInfo.Base
{
    public abstract class InformationSchemaColumnBase : IColumnInfo
    {

        public class ISColumnSortComparer : IComparer<IColumnInfo>
        {
            #region IComparer<IColumnInfo> Members

            public int Compare(IColumnInfo x, IColumnInfo y)
            {
                int dif = x.Order - y.Order;
                if (dif == 0)
                    dif = x.ColumnName.CompareTo(y.ColumnName);
                return dif;
            }

            #endregion
        }

        //System.Data.SqlDbType _sqlDbType = System.Data.SqlDbType.NVarChar;

        protected virtual string ISColumnCharLength
        { get { return "CHARACTER_MAXIMUM_LENGTH"; } }
        protected virtual string ISColumnOrder
        { get { return "ORDINAL_POSITION"; } }
        protected virtual string ISColumnDataType
        { get { return "DATA_TYPE"; } }
        protected virtual string ISColumnName
        { get { return "COLUMN_NAME"; } }
        protected virtual string ISColumnNumLength
        { get { return "NUMERIC_PRECISION"; } }
        protected virtual string ISColumnNumScale
        { get { return "NUMERIC_SCALE"; } }
        protected virtual string ISColumnDateLength
        { get { return "DATETIME_PRECISION"; } }

        protected InformationSchemaColumnBase()
        {
            IsNullable = false;
            IsIdentity = false;
            IsPrimaryKey = false;
            Order = 0;
            ColumnScale = 0;
            ColumnLength = 0;
            ColumnDescription = string.Empty;
            ColumnName = string.Empty;
        }

        public InformationSchemaColumnBase(DBStructure.INFORMATION_SCHEMA_COLUMNSRow dr)
        {
            ColumnScale = 0;
            ColumnLength = 0;
            ColumnDescription = string.Empty;
            ColumnName = dr[ISColumnName].ToString();
            string tempType = dr[ISColumnDataType].ToString();
            LoadTypeInformation(tempType);
            Order = Convert.ToInt32(dr[ISColumnOrder]);
            if (dr.Table.Columns.Contains(ISColumnCharLength) && !dr.IsNull(ISColumnCharLength))
            {
                ColumnLength = Convert.ToInt64(dr[ISColumnCharLength]);
            }
            else if (dr.Table.Columns.Contains(ISColumnNumLength) && !dr.IsNull(ISColumnNumLength))
            {
                ColumnLength = Convert.ToInt64(dr[ISColumnNumLength]);
                if (!dr.IsNull(ISColumnNumScale))
                    ColumnScale = Convert.ToInt32(dr[ISColumnNumScale]);
            }
            else if (dr.Table.Columns.Contains(ISColumnDateLength) && !dr.IsNull(ISColumnDateLength))
            {
                ColumnLength = Convert.ToInt64(dr[ISColumnDateLength]);
            }
            IsPrimaryKey = GetBoolean(dr, "IS_PRIMARY_KEY");
            IsIdentity = GetBoolean(dr, "IS_IDENTITY");
            IsNullable = GetBoolean(dr, "IS_NULLABLE");
        }

        private bool GetBoolean(DataRow dr, string columnName)
        {
            if (!dr.Table.Columns.Contains(columnName))
                return false;
            if (dr.IsNull(columnName))
                return false;

            if (dr[columnName] is bool)
                return (bool)dr[columnName];

            if (dr[columnName] is string)
                return dr[columnName].ToString().Trim().ToUpper() == "NO" ? false : true;

            return (Convert.ToInt32(dr[columnName]) == 1);
        }

        protected abstract void LoadTypeInformation(string type);

        #region IColumnInfo Members

        public string ColumnName { get; protected set; }
        public bool IsNullable { get; protected set; }
        public bool IsPrimaryKey { get; protected set; }
        public bool IsIdentity { get; protected set; }
        public StandardForeignKeyConstraint FKConstraint { get; set; }
        public string ForeignKey { get; protected set; }
        public string NativeType { get; protected set; }
        public long ColumnLength { get; protected set; }
        public int ColumnScale { get; protected set; }
        public int Order { get; protected set; }
        public string ColumnDescription { get; set; }
        public abstract DbType DbType { get; }
        public abstract Type ManagedType { get; }

        #endregion

    }
}
