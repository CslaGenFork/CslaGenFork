namespace DBSchemaInfo.Base
{
    public interface IStoredProcedureInfo : IDataBaseObject
    {
        ReadOnlyList<IResultSet> ResultSets { get; }
        ReadOnlyList<IParameter> Parameters { get; }
        bool IsLoaded { get; }
    }
}