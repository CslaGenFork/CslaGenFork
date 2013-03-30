using System.Data;

namespace DBSchemaInfo.Base
{
    public interface ICatalog
    {
        DataBaseObjectCollection<ITableInfo> Tables { get; }
        DataBaseObjectCollection<IViewInfo> Views { get; }
        DataBaseObjectCollection<IStoredProcedureInfo> Procedures { get; }
        ForeignKeyConstraintCollection ForeignKeyConstraints { get; }
        string ConnectionString { get; }
        string CatalogName { get; }
        IDbConnection CreateConnection();
        void LoadStaticObjects();
        void LoadProcedures();
    }
}