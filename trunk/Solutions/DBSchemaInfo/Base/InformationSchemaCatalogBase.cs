using System;
using System.Collections.Generic;
using System.Data;

namespace DBSchemaInfo.Base
{
    public abstract class InformationSchemaCatalogBase : ICatalog
    {
        public InformationSchemaCatalogBase(string cnString, string catalog)
        {
            ForeignKeyConstraints = new ForeignKeyConstraintCollection();
            ConnectionString = cnString;
            Connection = CreateConnection();
            CatalogName = catalog;
        }

        protected IDbConnection Connection { get; private set; }

        protected void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }

        protected void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

        protected abstract void LoadForeignKeys();

        protected abstract void LoadDescriptions();

        protected virtual void LoadTablesAndViews()
        {
            OpenConnection();
            try
            {
                var listTables = new List<ITableInfo>();
                var listViews = new List<IViewInfo>();
                var ds = GetTableViewSchema(Connection);
                foreach (DBStructure.INFORMATION_SCHEMA_TABLESRow row in ds.INFORMATION_SCHEMA_TABLES)
                {
                    if (row["TABLE_TYPE"].ToString() != "VIEW")
                        listTables.Add(CreateTableInfo(row));
                    else
                        listViews.Add(CreateViewInfo(row));
                }
                Tables = new DataBaseObjectCollection<ITableInfo>(listTables);
                Views = new DataBaseObjectCollection<IViewInfo>(listViews);
            }
            finally
            {
                CloseConnection();
            }
        }

        #region ICatalog Members

        public DataBaseObjectCollection<ITableInfo> Tables { get; private set; }

        public DataBaseObjectCollection<IViewInfo> Views { get; private set; }

        public DataBaseObjectCollection<IStoredProcedureInfo> Procedures { get; private set; }

        public ForeignKeyConstraintCollection ForeignKeyConstraints { get; protected set; }

        public string ConnectionString { get; private set; }

        public string CatalogName { get; private set; }

        public abstract IDbConnection CreateConnection();

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
                var ds = GetProcedureSchema(Connection);
                if (ds != null)
                {
                    var list = new List<IStoredProcedureInfo>();
                    foreach (DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr in ds.INFORMATION_SCHEMA_ROUTINES.Rows)
                    {
                        if (dr.ROUTINE_TYPE.Equals("PROCEDURE", StringComparison.CurrentCultureIgnoreCase))
                            list.Add(CreateProcedureInfo(dr));
                    }
                    Procedures = new DataBaseObjectCollection<IStoredProcedureInfo>(list);
                }
            }
            finally
            {
                CloseConnection();
            }
            LoadDescriptions();
        }

        #endregion

        protected abstract DBStructure GetTableViewSchema(IDbConnection cn);

        protected virtual DBStructure GetProcedureSchema(IDbConnection cn)
        {
            return null;
        }

        protected abstract ITableInfo CreateTableInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr);
        protected abstract IViewInfo CreateViewInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr);

        protected virtual IStoredProcedureInfo CreateProcedureInfo(DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr)
        {
            return null;
        }
    }
}