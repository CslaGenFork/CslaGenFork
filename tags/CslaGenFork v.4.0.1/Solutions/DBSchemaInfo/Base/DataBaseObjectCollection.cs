using System;
using System.Collections.Generic;
using System.Text;

namespace DBSchemaInfo.Base
{
    public class DataBaseObjectCollection<T> : ReadOnlyList<T> 
        where T : IDataBaseObject
    {
        public DataBaseObjectCollection(IEnumerable<T> items)
            : base(items)
        {
        }
        public T this[string CatalogName, string SchemaName, string ObjectName]
        {
            get
            {
                bool isCatNull = (CatalogName == null);
                bool isSchNull = (SchemaName == null);
                foreach (T obj in this)
                {
                    if (obj.ObjectName.Equals(ObjectName))
                    {
                        //This is to support the move from the old codesmith schema.
                        if (isCatNull && isSchNull)
                            return obj;
                        else if (isCatNull && (string.Compare(obj.ObjectSchema, SchemaName, true) == 0))
                            return obj;
                        else if (isSchNull && (string.Compare(obj.ObjectCatalog, CatalogName, true) == 0))
                            return obj;
                        else if (string.Compare(obj.ObjectCatalog, CatalogName, true) == 0 
                            && string.Compare(obj.ObjectSchema, SchemaName,true) == 0)
                            return obj;

                    }
                }
                return default(T);
            }
        }
    }
}
