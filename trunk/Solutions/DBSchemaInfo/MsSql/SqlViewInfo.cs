using System.ComponentModel;
using DBSchemaInfo.Base;

namespace DBSchemaInfo.MsSql
{
    public class SqlViewInfo : SqlStaticObjectBase, IViewInfo
    {
        public SqlViewInfo(DBStructure.INFORMATION_SCHEMA_TABLESRow dr, ICatalog cat)
            : base(dr, cat)
        { }

        [Browsable(false)]
        public new ICatalog Catalog { get; set; }

        public new string ObjectCatalog { get { return base.ObjectCatalog; } }
        public new string ObjectSchema { get { return base.ObjectSchema; } }
        public new string ObjectName { get { return base.ObjectName; } }
        [ReadOnly(true)]
        public new string ObjectDescription
        {
            get { return base.ObjectDescription; }
            set { base.ObjectDescription = value; }
        }
        public new ResultType Type { get { return base.Type; } }
        public new ColumnInfoCollection Columns { get { return base.Columns; } }
        public new int ResultIndex { get { return base.ResultIndex; } }
    }
}
