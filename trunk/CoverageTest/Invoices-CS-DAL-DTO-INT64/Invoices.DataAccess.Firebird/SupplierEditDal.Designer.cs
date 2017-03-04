using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Firebird
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ISupplierEditDal"/>
    /// </summary>
    public partial class SupplierEditDal : ISupplierEditDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a SupplierEdit object from the database.
        /// </summary>
        /// <param name="supplierId">The fetch criteria.</param>
        /// <returns>A SupplierEditDto object.</returns>
        public SupplierEditDto Fetch(int supplierId)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.GetSupplierEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private SupplierEditDto Fetch(IDataReader data)
        {
            var supplierEdit = new SupplierEditDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    supplierEdit.SupplierId = dr.GetInt32("SupplierId");
                    supplierEdit.Name = dr.GetString("Name");
                    supplierEdit.AddressLine1 = dr.IsDBNull("AddressLine1") ? null : dr.GetString("AddressLine1");
                    supplierEdit.AddressLine2 = dr.IsDBNull("AddressLine2") ? null : dr.GetString("AddressLine2");
                    supplierEdit.ZipCode = dr.IsDBNull("ZipCode") ? null : dr.GetString("ZipCode");
                    supplierEdit.State = dr.IsDBNull("State") ? null : dr.GetString("State");
                    supplierEdit.Country = (byte?)dr.GetValue("Country");
                }
            }
            return supplierEdit;
        }

        /// <summary>
        /// Inserts a new SupplierEdit object in the database.
        /// </summary>
        /// <param name="supplierEdit">The Supplier Edit DTO.</param>
        /// <returns>The new <see cref="SupplierEditDto"/>.</returns>
        public SupplierEditDto Insert(SupplierEditDto supplierEdit)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.AddSupplierEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierEdit.SupplierId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Name", supplierEdit.Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine1", supplierEdit.AddressLine1 == null ? (object)DBNull.Value : supplierEdit.AddressLine1).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine2", supplierEdit.AddressLine2 == null ? (object)DBNull.Value : supplierEdit.AddressLine2).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ZipCode", supplierEdit.ZipCode == null ? (object)DBNull.Value : supplierEdit.ZipCode).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@State", supplierEdit.State == null ? (object)DBNull.Value : supplierEdit.State).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Country", supplierEdit.Country == null ? (object)DBNull.Value : supplierEdit.Country.Value).DbType = DbType.Byte;
                    cmd.ExecuteNonQuery();
                }
            }
            return supplierEdit;
        }

        /// <summary>
        /// Updates in the database all changes made to the SupplierEdit object.
        /// </summary>
        /// <param name="supplierEdit">The Supplier Edit DTO.</param>
        /// <returns>The updated <see cref="SupplierEditDto"/>.</returns>
        public SupplierEditDto Update(SupplierEditDto supplierEdit)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.UpdateSupplierEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierEdit.SupplierId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Name", supplierEdit.Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine1", supplierEdit.AddressLine1 == null ? (object)DBNull.Value : supplierEdit.AddressLine1).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine2", supplierEdit.AddressLine2 == null ? (object)DBNull.Value : supplierEdit.AddressLine2).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ZipCode", supplierEdit.ZipCode == null ? (object)DBNull.Value : supplierEdit.ZipCode).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@State", supplierEdit.State == null ? (object)DBNull.Value : supplierEdit.State).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Country", supplierEdit.Country == null ? (object)DBNull.Value : supplierEdit.Country.Value).DbType = DbType.Byte;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("SupplierEdit");
                }
            }
            return supplierEdit;
        }

        #endregion

    }
}
