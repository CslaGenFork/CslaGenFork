using System;
using System.Data;

namespace DBSchemaInfo.Base
{
    public interface IParameter
    {
        string ParameterName { get; }
        string ParameterType { get; }
        string NativeType { get; }
        Int64 ColumnLength { get; }
        int ColumnScale { get; }
        int Order { get; }
        DbType DbType { get; }
        Type ManagedType { get; }
        IDbDataParameter CreateNullParam();
    }
}