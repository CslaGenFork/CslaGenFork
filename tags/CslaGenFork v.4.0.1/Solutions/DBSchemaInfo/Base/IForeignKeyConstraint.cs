using System;
using System.Collections.Generic;
using System.Text;

namespace DBSchemaInfo.Base
{
    public interface IForeignKeyConstraint
    {
        string ConstraintName { get;}
        ITableInfo PKTable { get;}
        ITableInfo ConstraintTable { get;}
        List<IForeignKeyColumnPair> Columns { get;}
    }

    public interface IForeignKeyColumnPair
    {
        IColumnInfo PKColumn { get;}
        IColumnInfo FKColumn { get;}
    }
}
