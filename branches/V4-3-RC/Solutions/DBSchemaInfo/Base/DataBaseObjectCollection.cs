using System.Collections.Generic;

namespace DBSchemaInfo.Base
{
    public class DataBaseObjectCollection<T> : ReadOnlyList<T>
        where T : IDataBaseObject
    {
        public DataBaseObjectCollection(IEnumerable<T> items)
            : base(items)
        {
        }

        public T this[string catalogName, string schemaName, string objectName]
        {
            get
            {
                bool isCatNull = (catalogName == null);
                bool isSchNull = (schemaName == null);
                foreach (T obj in this)
                {
                    if (obj.ObjectName.Equals(objectName))
                    {
                        //This is to support the move from the old codesmith schema.
                        if (isCatNull && isSchNull)
                            return obj;

                        if (isCatNull && (string.Compare(obj.ObjectSchema, schemaName, true) == 0))
                            return obj;

                        if (isSchNull && (string.Compare(obj.ObjectCatalog, catalogName, true) == 0))
                            return obj;

                        if (string.Compare(obj.ObjectCatalog, catalogName, true) == 0
                            && string.Compare(obj.ObjectSchema, schemaName, true) == 0)
                            return obj;
                    }
                }
                return default(T);
            }
        }
    }
}
