namespace DBSchemaInfo.Base
{
    public interface IDataBaseObject
    {
        string ObjectCatalog { get; }
        string ObjectSchema { get; }
        string ObjectName { get; }
        string ObjectDescription { get; set; }
        ICatalog Catalog { get; }
        void Reload(bool throwOnError);
    }
}