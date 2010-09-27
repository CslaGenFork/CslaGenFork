using System;
using System.Collections.Generic;
using System.Text;

namespace DBSchemaInfo.Base
{
    public class ForeignKeyConstraintCollection : ReadOnlyList<IForeignKeyConstraint>
    {

        public ForeignKeyConstraintCollection()
            : base()
        {
            IsReadOnly = false;
        }

        public List<IForeignKeyConstraint> GetConstraintsFor(IResultObject table)
        {
            List<IForeignKeyConstraint> list = new List<IForeignKeyConstraint>();
            foreach (IForeignKeyConstraint fkc in this)
            {
                if (fkc.ConstraintTable == table)
                    list.Add(fkc);
            }
            return list;
        }

    }
}
