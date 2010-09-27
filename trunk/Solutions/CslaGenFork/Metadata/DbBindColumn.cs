using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using CslaGenerator.Design;
using System.Xml.Serialization;
using DBSchemaInfo.Base;
using System.Collections;

namespace CslaGenerator.Metadata
{
	/// <summary>
	/// Summary description for DbBindColumn.
	/// </summary>
	[Serializable]
	public class DbBindColumn : ICloneable
	{
		private ColumnOriginType _columnOriginType = ColumnOriginType.None;


		// these fields used to serialize the column name so it can be loaded from a schema
		private string _tableName = String.Empty;
		private string _viewName = String.Empty;
		private string _spName = String.Empty;
		private int _spResultSetIndex = 0;
		private string _columnName = String.Empty;
		private DbType _dataType = DbType.String;
		private string _nativeType = String.Empty;

		public DbBindColumn()
		{
		}

		[Category("Definition")]
		public ColumnOriginType ColumnOriginType
		{
			set { _columnOriginType = value; }
			get { return _columnOriginType; }
		}


        internal IColumnInfo Column
        {
            get
            {
                return _Column;
            }
        }
        
        
		
		public DbType DataType
		{
			get 
			{
				if (Column == null) { return _dataType; }
				return Column.DbType;
			}
			set
			{
					_dataType = value;
			}
		}

		
		public string NativeType
		{
			get
			{
				if (Column == null) { return _nativeType; }
				return Column.NativeTypeName;
			}
			set
			{
				if (value != null)
					_nativeType = value;
			}
		}

        private long _Size;
        public long Size
        {
            get
            {
                if (Column == null) { return _Size; }
                return Column.ColumnLength;
            }
            set
            {
                _Size = value;
            }
        }

      
		public int SpResultIndex
		{
			get { return _spResultSetIndex; }
			set { _spResultSetIndex = value; }
		}
        
        [Browsable(false)]
		public string TableName
		{
			get { return _tableName; }
			set 
            {
                if (string.IsNullOrEmpty(_objectName) && !string.IsNullOrEmpty(value))
                    _objectName = value;
                //_tableName = value; 
                
            }
		}

        //[Obsolete("Use Object Name instead")]
        [Browsable(false)]
		public string ViewName
		{
			get { return _viewName; }
			set 
            {
                if (string.IsNullOrEmpty(_objectName) && !string.IsNullOrEmpty(value))
                    _objectName = value;
                //_viewName = value; 
            }
		}
        
        //[Obsolete("Use Object Name instead")]
        [Browsable(false)]
		public string SpName
		{
			get { return _spName; }
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

        private bool _IsPrimaryKey=false;
        public bool IsPrimaryKey
        {
            get
            {
                return _IsPrimaryKey;
            }
            set
            {
                _IsPrimaryKey = value;
            }
        }

        private ICatalog _Catalog;
        private IColumnInfo _Column;
        private string _objectName;
        public string ObjectName
        {
            get
            {
                return _objectName;
            }
            set
            {
                value = value.Trim().Replace("  ", " ").Replace(' ', '_');
                _objectName = value;
            }
        }
        private string _CatalogName;
        public string CatalogName
        {
            get
            {
                return _CatalogName;
            }
            set
            {
                _CatalogName = value;
            }
        }
        private string _SchemaName;
        public string SchemaName
        {
            get
            {
                return _SchemaName;
            }
            set
            {
                _SchemaName = value;
            }
        }
        IDataBaseObject _DatabaseObject;
        [Browsable(false)]
        public IDataBaseObject DatabaseObject
        {
            get
            {
                return _DatabaseObject;
            }
        }
        IResultSet _ResultSet;
        [Browsable(false)]
        public IResultSet ResultSet
        {
            get
            {
                return _ResultSet;
            }
        }
        internal void LoadColumn(ICatalog catalog)
        {
            _Catalog = catalog;
            _ResultSet = null;
            _DatabaseObject = null;
            _Column = null;
            string cat=null;
            if (_CatalogName != null)
            {
                if (string.Compare(_CatalogName, _Catalog.CatalogName, true) != 0)
                    cat = null; //When connecting to a DB with a different name
                else
                    cat = _CatalogName;
            }
            try
            {
                switch (_columnOriginType)
                {
                    case ColumnOriginType.Table:
                        ITableInfo tInfo = _Catalog.Tables[cat, _SchemaName, _objectName];
                        if (tInfo != null)
                        {
                            _DatabaseObject = tInfo;
                            _ResultSet = tInfo;
                        }
                        break;
                    case ColumnOriginType.View:
                        //_Column = _Catalog.Views[_CatalogName, _SchemaName, _objectName].Columns[_columnName];
                        IViewInfo vInfo = _Catalog.Views[cat, _SchemaName, _objectName];
                        if (vInfo != null)
                        {
                            _DatabaseObject = vInfo;
                            _ResultSet = vInfo;
                        }
                        break;
                    case ColumnOriginType.StoredProcedure:
                        IStoredProcedureInfo pInfo = _Catalog.Procedures[cat, _SchemaName, _objectName];
                        if (pInfo != null)
                        {
                            _DatabaseObject = pInfo;
                            if (pInfo.ResultSets.Count > _spResultSetIndex)
                                _ResultSet = pInfo.ResultSets[_spResultSetIndex];
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
            if (_ResultSet != null)
                _Column = _ResultSet.Columns[_columnName];
            ReloadColumnInfo();
        }

        void ReloadColumnInfo()
        {
            if (_Column == null)
                return;
            if (_CatalogName == null)
                _CatalogName = _DatabaseObject.ObjectCatalog;
            if (_SchemaName == null)
                _SchemaName = _DatabaseObject.ObjectSchema;

            this._IsPrimaryKey = _Column.IsPrimaryKey;
            this._IsNullable = _Column.IsNullable;
            this._IsIdentity = _Column.IsIdentity;
            this._dataType = _Column.DbType;
            this._nativeType = _Column.NativeTypeName;

        }

        private bool _IsNullable;
        public bool IsNullable
        {
            get
            {
                return _IsNullable;
            }
            set
            {
                _IsNullable = value;
            }
        }

        private bool _IsIdentity;
        public bool IsIdentity
        {
            get
            {
                return _IsIdentity;
            }
            set
            {
                _IsIdentity = value;
            }
        }


		public object Clone()
		{
            DbBindColumn clone = (DbBindColumn)Util.ObjectCloner.CloneShallow(this);
            clone.LoadColumn(_Catalog);
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
	}
}
