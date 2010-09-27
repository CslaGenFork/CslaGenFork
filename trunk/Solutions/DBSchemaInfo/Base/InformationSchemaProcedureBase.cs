using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Collections;
using System.Diagnostics;

namespace DBSchemaInfo.Base
{
    public abstract class InformationSchemaProcedureBase : InformationSchemaObjectBase, IStoredProcedureInfo 
    {
        public InformationSchemaProcedureBase(DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr, ICatalog cat)
            : base(dr, cat)
        {
            using (IDbConnection cn = cat.CreateConnection())
            {
                cn.Open();
                _Parameters = GetParameters(dr.GetINFORMATION_SCHEMA_PARAMETERSRows());
                //LoadResultSets(cn);	
            }
            
        }
        #region Information Schema properties overrides...
        
        protected override string ISObjectCatalog
        {
            get { return "SPECIFIC_CATALOG"; }
        }
        protected override string ISObjectName
        {
            get { return "SPECIFIC_NAME"; }
        }
        protected override string ISObjectSchema
        {
            get { return "SPECIFIC_SCHEMA"; }
        }

        #endregion

        #region IStoredProcedureInfo Members
        private ReadOnlyList<IResultSet> _ResultSets = new ReadOnlyList<IResultSet>();
        [Browsable(false)]
        public ReadOnlyList<IResultSet> ResultSets
        {
            get { return _ResultSets; }
        }
        private ReadOnlyList<IParameter> _Parameters = new ReadOnlyList<IParameter>();
        [Browsable(false)]
        public ReadOnlyList<IParameter> Parameters
        {
            get { return _Parameters; }
        }

        #endregion
        protected abstract IDataAdapter GetDataAdapter(IDbCommand cmd);
        protected abstract ReadOnlyList<IParameter> GetParameters(DBStructure.INFORMATION_SCHEMA_PARAMETERSRow[] rows);
        protected abstract ReadOnlyList<IParameter> GetParameters(IDbConnection cn);
        protected abstract IResultSet GetResultSet(IDataReader dr, int rsNum);
        protected virtual void LoadResultSets(IDbConnection cn, bool throwOnError)
        {
            using (IDbCommand cmd = cn.CreateCommand())
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                if (!string.IsNullOrEmpty(base.ObjectCatalog))
                    cmd.CommandText = base.ObjectCatalog + ".";
                if (!string.IsNullOrEmpty(base.ObjectSchema))
                    cmd.CommandText += base.ObjectSchema + ".";
                cmd.CommandText += base.ObjectName;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (IParameter par in _Parameters)
                {
                    cmd.Parameters.Add(par.CreateNullParam());
                }
                using (IDbTransaction trans = cn.BeginTransaction())
                {
                    cmd.Transaction = trans;
                    try
                    {

                        List<IResultSet> list = new List<IResultSet>();
                        int rsNum = 1;
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            do
                            {
                                IResultSet rSet = GetResultSet(dr, rsNum);
                                if (rSet.Columns.Count > 0)
                                    list.Add(rSet);
                                rsNum++;
                            } while (dr.NextResult());
                        }
                        _ResultSets = new ReadOnlyList<IResultSet>(list);
                    }
                    catch (Exception ex)
                    {
                        if (throwOnError)
                            throw ex;
                    }
                    finally
                    {
                        try { trans.Rollback(); }
                        catch (Exception ex)
                        {
                            if (throwOnError)
                                throw ex;
                        }
                        finally
                        {
                            if (cn.State == ConnectionState.Closed)
                                cn.Open();
                            _IsLoaded = true;
                        }
                    }
                }
            }
        }

        private bool _IsLoaded=false;
        public bool IsLoaded
        {
            get { return _IsLoaded; }
        }
        public override void Reload(bool throwOnError)
        {
           using (IDbConnection cn = Catalog.CreateConnection())
           {
               cn.Open();
               LoadResultSets(cn, throwOnError);           	
           }
        }
    }
}
