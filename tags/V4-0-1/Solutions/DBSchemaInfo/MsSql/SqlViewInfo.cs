using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBSchemaInfo.Base;
namespace DBSchemaInfo.MsSql
{
    public class SqlViewInfo : SqlStaticObjectBase, IViewInfo
    {
        public SqlViewInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr, ICatalog cat)
            : base(dr, cat)
        { }
    }

}
