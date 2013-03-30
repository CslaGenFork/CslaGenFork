using System;
using System.Collections.Generic;
using System.Text;

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
        /// <param name="columns"></param>
        public StandardForeignKeyConstraint(string constraintName, ITableInfo pKTable, ITableInfo constraintTable)
        {
            _ConstraintName = constraintName;
            _PKTable = pKTable;
            _ConstraintTable = constraintTable;
        }

        #region Private Fields

        string _ConstraintName;
        ITableInfo _PKTable;
        ITableInfo _ConstraintTable;
        List<IForeignKeyColumnPair> _Columns= new List<IForeignKeyColumnPair>();

        #endregion

        #region IForeignKeyConstraint Members

        public string ConstraintName
        {
            get { return _ConstraintName; }
        }

        public ITableInfo PKTable
        {
            get { return _PKTable; }
        }

        public ITableInfo ConstraintTable
        {
            get { return _ConstraintTable; }
        }

        public List<IForeignKeyColumnPair> Columns
        {
            get { return _Columns; }
        }

        #endregion
    }
}
