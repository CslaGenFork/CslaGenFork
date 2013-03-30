using System.Collections.Generic;

namespace DBSchemaInfo.Base
{
    public class ForeignKeyConstraintCollection : ReadOnlyList<IForeignKeyConstraint>
    {

        public ForeignKeyConstraintCollection()
        {
            IsReadOnly = false;
        }

        public List<IForeignKeyConstraint> GetConstraintsFor(IResultObject table)
        {
            var list = new List<IForeignKeyConstraint>();
            foreach (IForeignKeyConstraint fkc in this)
            {
                if (fkc.ConstraintTable == table)
                    list.Add(fkc);
            }
            return list;
        }
    }
}
