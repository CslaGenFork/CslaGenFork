using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
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

        protected string _ColumnName = string.Empty;
        protected string _ColumnDescription = string.Empty;
        //System.Data.SqlDbType _sqlDbType = System.Data.SqlDbType.NVarChar;

        protected Int64 _ColumnLength = 0;
        protected int _ColumnScale = 0;
        protected int _Order = 0;
        protected bool _IsPrimaryKey = false;
        protected bool _IsIdentity = false;
        protected bool _IsNullable = false;

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
        { }
        public InformationSchemaColumnBase(DBStructure.INFORMATION_SCHEMA_COLUMNSRow dr)
        {
            _ColumnName = dr[ISColumnName].ToString();
            string tempType = dr[ISColumnDataType].ToString();
            LoadTypeInformation( tempType);
            _Order = Convert.ToInt32(dr[ISColumnOrder]);
            if (dr.Table.Columns.Contains(ISColumnCharLength) && !dr.IsNull(ISColumnCharLength))
            {
                _ColumnLength = Convert.ToInt64(dr[ISColumnCharLength]);
            }
            else if (dr.Table.Columns.Contains(ISColumnNumLength) && !dr.IsNull(ISColumnNumLength))
            {
                _ColumnLength = Convert.ToInt64(dr[ISColumnNumLength]);
                if (!dr.IsNull(ISColumnNumScale))
                    _ColumnScale = Convert.ToInt32(dr[ISColumnNumScale]);
            }
            else if (dr.Table.Columns.Contains(ISColumnDateLength) && !dr.IsNull(ISColumnDateLength))
            {
                _ColumnLength = Convert.ToInt64(dr[ISColumnDateLength]);
            }
            _IsPrimaryKey = GetBoolean(dr,"IS_PRIMARY_KEY");
            _IsIdentity = GetBoolean(dr,"IS_IDENTITY");
            _IsNullable = GetBoolean(dr,"IS_NULLABLE");
        }
        private bool GetBoolean(DataRow dr, string columnName)
        {
            if (!dr.Table.Columns.Contains(columnName))
                return false;
                if (dr.IsNull(columnName))
                    return false;
                if (dr[columnName] is bool)
                    return (bool)dr[columnName];
                else if (dr[columnName] is string)
                    return dr[columnName].ToString().Trim().ToUpper() == "NO" ? false : true;
                else
                    return (Convert.ToInt32(dr[columnName]) == 1);
        }

        protected abstract void LoadTypeInformation(string type);

        #region IColumnInfo Members

        public abstract string NativeTypeName { get;}
        //{
        //    get { return _sqlDbType.ToString(); }
        //}

        public abstract System.Data.DbType DbType { get;}
        //{
        //    get { return SqlTypeMapper.GetDbType(_sqlDbType); }
        //}

        public abstract Type ManagedType { get;}
        //{
        //    get { return SqlTypeMapper.GetManagedType(_sqlDbType); }
        //    protected set
        //    {
        //        _sqlDbType = value;
        //    }
        //}

        public string ColumnName
        {
            get { return _ColumnName; }
        }

        public string ColumnDescription
        {
            get { return _ColumnDescription; }
        }

        public Int64 ColumnLength
        {
            get { return _ColumnLength; }
        }

        public int ColumnScale
        {
            get { return _ColumnScale; }
        }
        public int Order
        {
            get
            {
                return _Order;
            }
        }

        public bool IsPrimaryKey
        {
            get
            {
                return _IsPrimaryKey;
            }
        }

        
        public bool IsIdentity
        {
            get
            {
                return _IsIdentity;
            }
        }

        public bool IsNullable
        {
            get
            {
                return _IsNullable;
            }
        }
        #endregion

    }
}
