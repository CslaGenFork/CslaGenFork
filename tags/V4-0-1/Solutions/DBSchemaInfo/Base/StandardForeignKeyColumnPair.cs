using System;
using System.Collections.Generic;
using System.Text;

namespace DBSchemaInfo.Base
{
    public class StandardForeignKeyColumnPair : IForeignKeyColumnPair
    {

        /// <summary>
        /// Initializes a new instance of the StandardForeignKeyColumnPair class.
        /// </summary>
        /// <param name="pKColumn"></param>
        /// <param name="fKColumn"></param>
        public StandardForeignKeyColumnPair(IColumnInfo pKColumn, IColumnInfo fKColumn)
        {
            _PKColumn = pKColumn;
            _FKColumn = fKColumn;
        }

        IColumnInfo _PKColumn;
        IColumnInfo _FKColumn;

        #region IForeignKeyColumnPair Members

        public IColumnInfo PKColumn
        {
            get { return _PKColumn; }
        }

        public IColumnInfo FKColumn
        {
            get { return _FKColumn; }
        }

        #endregion
    }
}
