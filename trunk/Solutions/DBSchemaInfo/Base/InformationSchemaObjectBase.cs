using System.Data;

namespace DBSchemaInfo.Base
{
    public abstract class InformationSchemaObjectBase : IDataBaseObject
    {
        public InformationSchemaObjectBase(DataRow dr, ICatalog cat)
        {
            Catalog = cat;
            ObjectName = dr[ISObjectName].ToString();
            ObjectSchema = dr[ISObjectSchema].ToString();
            ObjectCatalog = dr.IsNull(ISObjectCatalog) ? string.Empty : dr[ISObjectCatalog].ToString();
        }

        protected virtual string ISObjectName
        {
            get { return "TABLE_NAME"; }
        }
        protected virtual string ISObjectSchema
        {
            get { return "TABLE_SCHEMA"; }
        }
        protected virtual string ISObjectCatalog
        {
            get { return "TABLE_CATALOG"; }
        }

        public string ObjectCatalog { get; protected internal set; }

        public string ObjectSchema { get; protected internal set; }

        public string ObjectName { get; protected internal set; }

        public string ObjectDescription { get; set; }

        public ICatalog Catalog { get; private set; }

        public abstract void Reload(bool throwOnError);

    }
}
