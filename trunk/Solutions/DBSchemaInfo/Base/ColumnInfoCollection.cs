using System.Collections.Generic;

namespace DBSchemaInfo.Base
{
    public class ColumnInfoCollection : ReadOnlyList<IColumnInfo>
    {
        public ColumnInfoCollection(IEnumerable<IColumnInfo> items)
            : base(items)
        { }

        public IColumnInfo this[string columnName]
        {
            get
            {
                foreach (var col in this)
                {
                    if (col.ColumnName.Equals(columnName))
                        return col;
                }
                return null;
            }
        }
    }
}
