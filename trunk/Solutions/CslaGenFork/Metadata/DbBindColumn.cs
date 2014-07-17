using System;
using System.ComponentModel;
using System.Data;
using DBSchemaInfo.Base;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for DbBindColumn.
    /// </summary>
    [Serializable]
    public class DbBindColumn : ICloneable
    {
        #region Fields

        private ColumnOriginType _columnOriginType = ColumnOriginType.None;

        // these fields are used to serialize the column name so it can be loaded from a schema
        //private readonly string _tableName = String.Empty;
        //private readonly string _viewName = String.Empty;
        //private readonly string _spName = String.Empty;
        private int _spResultSetIndex;
        private string _columnName = String.Empty;
        private DbType _dataType = DbType.String;
        private string _nativeType = String.Empty;
        private long _size;
        private bool _isPrimaryKey;
        private ICatalog _catalog;
        private IColumnInfo _column;
        private string _objectName;
        private string _catalogName;
        private string _schemaName;
        private IDataBaseObject _databaseObject;
        private IResultSet _resultSet;
        private bool _isNullable;
        private bool _isIdentity;

        #endregion

        #region Properties

        public ColumnOriginType ColumnOriginType
        {
            set { _columnOriginType = value; }
            get { return _columnOriginType; }
        }

        public IColumnInfo Column
        {
            get { return _column; }
        }

        public DbType DataType
        {
            get
            {
                if (Column == null) { return _dataType; }
                return Column.DbType;
            }
            set { _dataType = value; }
        }

        public string NativeType
        {
            get
            {
                if (Column == null) { return _nativeType; }
                return Column.NativeType;
            }
            set
            {
                if (value != null)
                    _nativeType = value;
            }
        }

        public long Size
        {
            get
            {
                if (Column == null) { return _size; }
                return Column.ColumnLength;
            }
            set { _size = value; }
        }

        public int SpResultIndex
        {
            get { return _spResultSetIndex; }
            set { _spResultSetIndex = value; }
        }

        [Obsolete("Use ObjectName instead")]
        [Browsable(false)]
        public string TableName
        {
            get { return _objectName; }
            set
            {
                if (string.IsNullOrEmpty(_objectName) && !string.IsNullOrEmpty(value))
                    _objectName = value;
                //_tableName = value;

            }
        }

        [Obsolete("Use ObjectName instead")]
        [Browsable(false)]
        public string ViewName
        {
            get { return _objectName; }
            set
            {
                if (string.IsNullOrEmpty(_objectName) && !string.IsNullOrEmpty(value))
                    _objectName = value;
                //_viewName = value;
            }
        }

        [Obsolete("Use ObjectName instead")]
        [Browsable(false)]
        public string SpName
        {
            get { return _objectName; }
            set
            {
                if (string.IsNullOrEmpty(_objectName) && !string.IsNullOrEmpty(value))
                    _objectName = value;
                //_spName = value;
            }
        }

        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }

        public string ObjectName
        {
            get { return _objectName; }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_');
                _objectName = value;
            }
        }

        public string CatalogName
        {
            get { return _catalogName; }
            set { _catalogName = value; }
        }

        public string SchemaName
        {
            get { return _schemaName; }
            set { _schemaName = value; }
        }

        [Browsable(false)]
        public IDataBaseObject DatabaseObject
        {
            get { return _databaseObject; }
        }

        [Browsable(false)]
        public IResultSet ResultSet
        {
            get { return _resultSet; }
        }

        #endregion

        #region Methods

        internal void LoadColumn(ICatalog catalog)
        {
            _catalog = catalog;
            _resultSet = null;
            _databaseObject = null;
            _column = null;
            string cat = null;
            if (_catalogName != null)
            {
                if (string.Compare(_catalogName, _catalog.CatalogName, true) != 0)
                    cat = null; //When connecting to a DB with a different name
                else
                    cat = _catalogName;
            }
            try
            {
                switch (_columnOriginType)
                {
                    case ColumnOriginType.Table:
                        ITableInfo tInfo = _catalog.Tables[cat, _schemaName, _objectName];
                        if (tInfo != null)
                        {
                            _databaseObject = tInfo;
                            _resultSet = tInfo;
                        }
                        break;
                    case ColumnOriginType.View:
                        //_Column = _Catalog.Views[_CatalogName, _SchemaName, _objectName].Columns[_columnName];
                        IViewInfo vInfo = _catalog.Views[cat, _schemaName, _objectName];
                        if (vInfo != null)
                        {
                            _databaseObject = vInfo;
                            _resultSet = vInfo;
                        }
                        break;
                    case ColumnOriginType.StoredProcedure:
                        IStoredProcedureInfo pInfo = _catalog.Procedures[cat, _schemaName, _objectName];
                        if (pInfo != null)
                        {
                            _databaseObject = pInfo;
                            if (pInfo.ResultSets.Count > _spResultSetIndex)
                                _resultSet = pInfo.ResultSets[_spResultSetIndex];
                        }
                        break;
                    case ColumnOriginType.None:

                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (_resultSet != null)
                _column = _resultSet.Columns[_columnName];
            ReloadColumnInfo();
        }

        private void ReloadColumnInfo()
        {
            if (_column == null)
                return;
            if (_catalogName == null)
                _catalogName = _databaseObject.ObjectCatalog;
            if (_schemaName == null)
                _schemaName = _databaseObject.ObjectSchema;

            _isPrimaryKey = _column.IsPrimaryKey;
            _isNullable = _column.IsNullable;
            _isIdentity = _column.IsIdentity;
            _dataType = _column.DbType;
            _nativeType = _column.NativeType;
        }

        public bool IsNullable
        {
            get { return _isNullable; }
            set { _isNullable = value; }
        }

        public bool IsIdentity
        {
            get { return _isIdentity; }
            set { _isIdentity = value; }
        }

        public object Clone()
        {
            var clone = (DbBindColumn)Util.ObjectCloner.CloneShallow(this);
            clone.LoadColumn(_catalog);
            return clone;
            //DbBindColumn col = new DbBindColumn();
            //col._columnName = this._columnName;
            //col._columnOriginType = this._columnOriginType;
            //col._spName = this._spName;
            //col._spResultSetIndex = this._spResultSetIndex;
            //col._spSchema = this._spSchema;
            //col._tableName = this._tableName;
            //col._tableSchema = this._tableSchema;
            //col._viewName = this._viewName;
            //col._viewSchema = this._viewSchema;
            //col._dataType = this._dataType;
            //col._nativeType = this._nativeType;
            //return col;
        }

        #endregion
    }
}
