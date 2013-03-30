using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBSchemaInfo.Base;
namespace DBSchemaInfo.MsSql
{
    public class SqlTableInfo : SqlStaticObjectBase, ITableInfo 
    {
        public SqlTableInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr, ICatalog cat)
            : base(dr, cat)
        { }     
    }

    }
