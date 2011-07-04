using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace DBSchemaInfo.Base
{
    public abstract class InformationSchemaProcedureBase : InformationSchemaObjectBase, IStoredProcedureInfo
    {
        public InformationSchemaProcedureBase(DBStructure.INFORMATION_SCHEMA_ROUTINESRow dr, ICatalog cat)
            : base(dr, cat)
        {
            IsLoaded = false;
            ResultSets = new ReadOnlyList<IResultSet>();
            using (var cn = cat.CreateConnection())
            {
                cn.Open();
                Parameters = GetParameters(dr.GetINFORMATION_SCHEMA_PARAMETERSRows());
                //LoadResultSets(cn);	
            }
        }

        #region Information Schema properties overrides...

        protected override string IsObjectCatalog
        {
            get { return "SPECIFIC_CATALOG"; }
        }
        protected override string IsObjectName
        {
            get { return "SPECIFIC_NAME"; }
        }
        protected override string IsObjectSchema
        {
            get { return "SPECIFIC_SCHEMA"; }
        }

        #endregion

        #region IStoredProcedureInfo Members

        [Browsable(false)]
        public ReadOnlyList<IResultSet> ResultSets { get; private set; }

        [Browsable(false)]
        public ReadOnlyList<IParameter> Parameters { get; private set; }

        #endregion

        protected abstract IDataAdapter GetDataAdapter(IDbCommand cmd);
        protected abstract ReadOnlyList<IParameter> GetParameters(DBStructure.INFORMATION_SCHEMA_PARAMETERSRow[] rows);
        protected abstract ReadOnlyList<IParameter> GetParameters(IDbConnection cn);
        protected abstract IResultSet GetResultSet(IDataReader dr, int rsNum);

        protected virtual void LoadResultSets(IDbConnection cn, bool throwOnError)
        {
            using (var cmd = cn.CreateCommand())
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                if (!string.IsNullOrEmpty(ObjectCatalog))
                    cmd.CommandText = ObjectCatalog + ".";
                if (!string.IsNullOrEmpty(ObjectSchema))
                    cmd.CommandText += ObjectSchema + ".";
                cmd.CommandText += ObjectName;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var par in Parameters)
                {
                    cmd.Parameters.Add(par.CreateNullParam());
                }
                using (var trans = cn.BeginTransaction())
                {
                    cmd.Transaction = trans;
                    try
                    {
                        var list = new List<IResultSet>();
                        int rsNum = 1;
                        using (var dr = cmd.ExecuteReader())
                        {
                            do
                            {
                                IResultSet rSet = GetResultSet(dr, rsNum);
                                if (rSet.Columns.Count > 0)
                                    list.Add(rSet);
                                rsNum++;
                            } while (dr.NextResult());
                        }
                        ResultSets = new ReadOnlyList<IResultSet>(list);
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
                            IsLoaded = true;
                        }
                    }
                }
            }
        }

        public bool IsLoaded { get; private set; }

        public override void Reload(bool throwOnError)
        {
            using (var cn = Catalog.CreateConnection())
            {
                cn.Open();
                LoadResultSets(cn, throwOnError);
            }
        }
    }
}
