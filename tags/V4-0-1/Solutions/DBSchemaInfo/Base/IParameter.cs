using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace DBSchemaInfo.Base
{
    public interface IParameter
    {
        string ParameterName { get;}
        string ParameterType { get;}
        string NativeTypeName { get; }
        System.Data.DbType DbType { get; }
        System.Type ManagedType { get; }
        Int64 ColumnLength { get; }
        int ColumnScale { get; }
        int Order { get; }
        IDbDataParameter CreateNullParam();
    }
}
