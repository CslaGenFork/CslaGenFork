namespace DBSchemaInfo.Base
{
    public class StandardForeignKeyColumnPair : IForeignKeyColumnPair
    {
        private readonly IColumnInfo _fkColumn;
        private readonly IColumnInfo _pkColumn;

        /// <summary>
        /// Initializes a new instance of the StandardForeignKeyColumnPair class.
        /// </summary>
        /// <param name="pKColumn"></param>
        /// <param name="fKColumn"></param>
        public StandardForeignKeyColumnPair(IColumnInfo pKColumn, IColumnInfo fKColumn)
        {
            _pkColumn = pKColumn;
            _fkColumn = fKColumn;
        }

        #region IForeignKeyColumnPair Members

        public IColumnInfo PKColumn
        {
            get { return _pkColumn; }
        }

        public IColumnInfo FKColumn
        {
            get { return _fkColumn; }
        }

        #endregion
    }
}