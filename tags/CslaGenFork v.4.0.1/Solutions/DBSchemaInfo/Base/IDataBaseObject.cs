using System;
using System.Collections.Generic;
using System.Text;

namespace DBSchemaInfo.Base
{
    public interface IDataBaseObject
    {
        string ObjectCatalog { get; }
        string ObjectName { get; }
        string ObjectSchema { get; }
        ICatalog Catalog { get; }
        void Reload(bool throwOnError);
    }
}
