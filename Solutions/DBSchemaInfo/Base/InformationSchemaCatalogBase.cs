using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DBSchemaInfo.Base
{
    public abstract class InformationSchemaCatalogBase : DBSchemaInfo.Base.ICatalog
    {
        private string _ConnectionString;
        private IDbConnection _cn;
        private string _CatalogName;
        private DataBaseObjectCollection<ITableInfo> _Tables;
        private DataBaseObjectCollection<IViewInfo> _Views;
        private DataBaseObjectCollection<IStoredProcedureInfo> _Procedures;
        public InformationSchemaCatalogBase(string cnString, string catalog)
        {
            _ConnectionString = cnString;
            _cn = CreateConnection();
            _CatalogName = catalog;
        }

        public string CatalogName
        {
            get
            {
                return _CatalogName;
            }
        }
        protected IDbConnection Connection
        { get { return _cn; } }

        protected void OpenConnection()
        {
            if (_cn.State == System.Data.ConnectionState.Closed)
                _cn.Open();
        }
        protected void CloseConnection()
        {
            if (_cn.State != System.Data.ConnectionState.Closed)
                _cn.Close();
        }

        public DataBaseObjectCollection<ITableInfo> Tables
        {
            get
            {
                return _Tables;
            }
        }

        public DataBaseObjectCollection<IViewInfo> Views
        {
            get
            {
                return _Views;
            }
        }
        public DataBaseObjectCollection<IStoredProcedureInfo> Procedures
        {
            get
            {
                return _Procedures;
            }
        }

        public void LoadStaticObjects()
        {
            LoadTablesAndViews();
            LoadForeignKeys();
        }
        public void LoadProcedures()
        {
            OpenConnection();
            try
            {
                DBStructure ds = GetProcedureSchema(_cn);
                if (ds != null)
                {
                    List<IStoredProcedureInfo> list = new List<IStoredProcedureInfo>();
                    foreach (DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr in ds.INFORMATION_SCHEMA_ROUTINES.Rows)
                    {
                        if (dr.ROUTINE_TYPE.Equals("PROCEDURE", StringComparison.CurrentCultureIgnoreCase))
                            list.Add(CreateProcedureInfo(dr));
                    }
                    _Procedures = new DataBaseObjectCollection<IStoredProcedureInfo>(list);
                }
            }
            finally { CloseConnection(); }
        }

        protected abstract void LoadForeignKeys();
        
        protected virtual void LoadTablesAndViews()
        {
            OpenConnection();
            try
            {
                List<ITableInfo> listTables = new List<ITableInfo>();
                List<IViewInfo> listViews = new List<IViewInfo>();
                DBStructure ds = GetTableViewSchema(_cn);
                foreach (DBStructure.INFORMATION_SCHEMA_TABLESRow row in ds.INFORMATION_SCHEMA_TABLES)
                {
                    if (row["TABLE_TYPE"].ToString() != "VIEW")
                        listTables.Add(CreateTableInfo(row));
                    else
                        listViews.Add(CreateViewInfo(row));
                }
                _Tables = new DataBaseObjectCollection<ITableInfo>(listTables);
                _Views = new DataBaseObjectCollection<IViewInfo>(listViews);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected abstract DBStructure GetTableViewSchema(IDbConnection cn);
        protected virtual DBStructure GetProcedureSchema(IDbConnection cn) { return null; }
        protected abstract ITableInfo CreateTableInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr);
        protected abstract IViewInfo CreateViewInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr);
        protected virtual IStoredProcedureInfo CreateProcedureInfo(DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr) { return null; }


        #region ICatalog Members


        public string ConnectionString
        {
            get { return _ConnectionString; }
        }

        #endregion

        #region ICatalog Members

        private ForeignKeyConstraintCollection _ForeignKeyConstraints = new ForeignKeyConstraintCollection();
        public ForeignKeyConstraintCollection ForeignKeyConstraints
        {
            get { return _ForeignKeyConstraints; }
            protected set
            {
                _ForeignKeyConstraints = value;
            }
        }

        public abstract IDbConnection CreateConnection();
        

        #endregion
    }
}
