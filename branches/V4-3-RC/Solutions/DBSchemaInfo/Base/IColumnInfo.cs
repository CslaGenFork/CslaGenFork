using System;
using System.Data;

namespace DBSchemaInfo.Base
{
    public interface IColumnInfo
    {
        string ColumnName { get; }
        bool IsNullable { get; }
        bool IsPrimaryKey { get; }
        bool IsIdentity { get; }
        StandardForeignKeyConstraint FKConstraint { get; set;  }
        string ForeignKey { get; }
        string NativeType { get; }
        Int64 ColumnLength { get; }
        int ColumnScale { get; }
        int Order { get; }
        string ColumnDescription { get; set;  }
        DbType DbType { get; }
        Type ManagedType { get; }
    }
}