using System.Data;

namespace DBSchemaInfo.Base
{
    public abstract class InformationSchemaObjectBase : IDataBaseObject
    {
        public InformationSchemaObjectBase(DataRow dr, ICatalog cat)
        {
            Catalog = cat;
            ObjectName = dr[IsObjectName].ToString();
            ObjectSchema = dr[IsObjectSchema].ToString();
            ObjectCatalog = dr.IsNull(IsObjectCatalog) ? string.Empty : dr[IsObjectCatalog].ToString();
        }

        protected virtual string IsObjectName
        {
            get { return "TABLE_NAME"; }
        }
        protected virtual string IsObjectSchema
        {
            get { return "TABLE_SCHEMA"; }
        }
        protected virtual string IsObjectCatalog
        {
            get { return "TABLE_CATALOG"; }
        }

        public string ObjectCatalog { get; protected internal set; }

        public string ObjectSchema { get; protected internal set; }

        public string ObjectName { get; protected internal set; }

        public string ObjectDescription { get; set; }

        public ICatalog Catalog { get; set; }

        public abstract void Reload(bool throwOnError);

    }
}
