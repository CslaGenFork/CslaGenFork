using System;
using System.Collections.Generic;
using System.Text;

namespace DBSchemaInfo.Base
{
    public interface IResultSet
    {
        int ResultIndex { get;}
        ColumnInfoCollection Columns { get;}
        ResultType Type { get;}
    }
}
