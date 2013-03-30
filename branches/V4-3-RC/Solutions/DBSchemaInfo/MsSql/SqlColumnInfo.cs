using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using DBSchemaInfo.Base;

namespace DBSchemaInfo.MsSql
{
    public class SqlColumnInfo : InformationSchemaColumnBase
    {
        SqlDbType _sqlDbType = SqlDbType.NVarChar;

        public SqlColumnInfo(DBStructure.INFORMATION_SCHEMA_COLUMNSRow dr)
            : base(dr)
        {
        }

        public SqlColumnInfo(SqlDataReader dr, int idx)
        {
            ColumnName = dr.GetName(idx);
            ColumnLength = 0;
            ColumnScale = 0;
            Order = idx;
            LoadTypeInformation(dr.GetDataTypeName(idx));
        }

        #region IColumnInfo Members

        public new string ColumnName
        {
            get { return base.ColumnName; }
            private set { base.ColumnName = value; }
        }
        public new bool IsNullable { get { return base.IsNullable; } }
        public new bool IsPrimaryKey { get { return base.IsPrimaryKey; } }
        public new bool IsIdentity { get { return base.IsIdentity; } }
        [Browsable(false)]
        public new StandardForeignKeyConstraint FKConstraint
        {
            get { return base.FKConstraint; }
            private set { base.FKConstraint = value; }
        }
        [TypeConverter(typeof(FKConstraintConverter))]
        public new string ForeignKey
        {
            get { return base.ForeignKey; }
        }
        public string CondensedDataType
        {
            get { return SqlTypeMapper.GetCondensedDataType(NativeType, ColumnLength, ColumnScale); }
        }
        [Browsable((false))]
        public new string NativeType
        {
            get { return base.NativeType; }
            private set { base.NativeType = value; }
        }
        [Browsable(false)]
        public new Int64 ColumnLength
        {
            get { return base.ColumnLength; }
            private set { base.ColumnLength = value; }
        }
        [Browsable(false)]
        public new int ColumnScale
        {
            get { return base.ColumnScale; }
            private set { base.ColumnScale = value; }
        }
        [Browsable(false)]
        public new int Order
        {
            get { return base.Order; }
            private set { base.Order = value; }
        }
        [ReadOnly(true)]
        public new string ColumnDescription { get { return base.ColumnDescription; } }
        public override DbType DbType
        {
            get { return SqlTypeMapper.GetDbType(_sqlDbType); }
        }
        public override Type ManagedType
        {
            get { return SqlTypeMapper.GetManagedType(_sqlDbType); }
        }

        #endregion

        protected override void LoadTypeInformation(string type)
        {
            _sqlDbType = SqlTypeMapper.GetSqlDbType(type);
            NativeType = type;
        }
    }
}
