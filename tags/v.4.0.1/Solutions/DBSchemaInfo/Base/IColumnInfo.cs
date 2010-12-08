using System;
namespace DBSchemaInfo.Base
{
    public interface IColumnInfo
    {
        string NativeTypeName { get;}
        System.Data.DbType DbType { get;}
        System.Type ManagedType { get;}
        string ColumnName { get;}
        string ColumnDescription { get;}
        Int64 ColumnLength { get;}
        int ColumnScale { get;}
        int Order { get; }
        bool IsPrimaryKey { get;}
        bool IsNullable { get;}
        bool IsIdentity { get;}
        
    }
}
