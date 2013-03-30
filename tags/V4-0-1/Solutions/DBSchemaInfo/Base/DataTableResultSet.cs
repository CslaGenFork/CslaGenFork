//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//namespace DBSchemaInfo.Base
//{
//    public class DataTableResultSet : IResultSet 
//    {
//        public DataTableResultSet(DataTable table)
//        {
//            List<IColumnInfo> list = new List<IColumnInfo>();
//            int idx = 0;
//            foreach (DataColumn col in table.Columns)
//            {
//                list.Add(new DataTableColumn(col, idx));
//                idx++;
//            }
//            _Columns = list.ToArray();

//        }
//        private IColumnInfo[] _Columns;
//        protected int _ResultIndex = 0;
//        private Base.ResultType _Type = DBSchemaInfo.Base.ResultType.StoredProcedure;
        
//        #region IResultSet Members

//        public IColumnInfo[] Columns
//        {
//            get { return _Columns; }
//        }

//        public int ResultIndex
//        {
//            get
//            {
//                return _ResultIndex;
//            }
//            internal set
//            {
//                _ResultIndex = value;
//            }
//        }

//        public Base.ResultType Type
//        {
//            get
//            {
//                return _Type;
//            }
//        }
//        #endregion
//    }

//    public class DataTableColumn : IColumnInfo
//    {
//        public DataTableColumn(DataColumn col, int order)
//        {
//            _NativeType = col.DataType;
//            _ColumnName = col.ColumnName;
//            _ColumnOrder = order;
//        }
//        private Type _NativeType;
//        private string _ColumnName;
//        private int _ColumnOrder;
        
//        #region IColumnInfo Members

//        public string NativeTypeName
//        {
//            get { return _NativeType.Name; }
//        }

//        public DbType DbType
//        {
//            get { return DbType.String; }
//        }

//        public Type ManagedType
//        {
//            get { return _NativeType; }
//        }

//        public string ColumnName
//        {
//            get { return _ColumnName; }
//        }

//        public string ColumnDescription
//        {
//            get { return string.Empty; }
//        }

//        public long ColumnLength
//        {
//            get { return 0; }
//        }

//        public int ColumnScale
//        {
//            get { return 0; }
//        }

//        public int Order
//        {
//            get { return _ColumnOrder; }
//        }
        
        

//        #endregion
//    }
//}
