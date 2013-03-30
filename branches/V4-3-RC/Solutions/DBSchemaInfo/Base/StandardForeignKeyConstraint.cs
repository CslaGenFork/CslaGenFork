using System.Collections.Generic;

namespace DBSchemaInfo.Base
{
    public class StandardForeignKeyConstraint : IForeignKeyConstraint
    {
        /// <summary>
        /// Initializes a new instance of the StandardForeignKeyConstraint class.
        /// </summary>
        /// <param name="constraintName"></param>
        /// <param name="pKTable"></param>
        /// <param name="constraintTable"></param>
        public StandardForeignKeyConstraint(string constraintName, ITableInfo pKTable, ITableInfo constraintTable)
        {
            _constraintName = constraintName;
            _pkTable = pKTable;
            _constraintTable = constraintTable;
        }

        #region Private Fields

        private readonly List<IForeignKeyColumnPair> _columns = new List<IForeignKeyColumnPair>();
        private readonly string _constraintName;
        private readonly ITableInfo _constraintTable;
        private readonly ITableInfo _pkTable;

        #endregion

        #region IForeignKeyConstraint Members

        public string ConstraintName
        {
            get { return _constraintName; }
        }

        public ITableInfo PKTable
        {
            get { return _pkTable; }
        }

        public ITableInfo ConstraintTable
        {
            get { return _constraintTable; }
        }

        public List<IForeignKeyColumnPair> Columns
        {
            get { return _columns; }
        }

        #endregion
    }
}