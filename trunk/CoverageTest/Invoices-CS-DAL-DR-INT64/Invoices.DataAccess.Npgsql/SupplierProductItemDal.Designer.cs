using System;
using System.Data;
using Npgsql;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Npgsql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ISupplierProductItemDal"/>
    /// </summary>
    public partial class SupplierProductItemDal : ISupplierProductItemDal
    {

        #region DAL methods

        /// <summary>
        /// Inserts a new SupplierProductItem object in the database.
        /// </summary>
        /// <param name="supplierId">The parent Supplier Id.</param>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        /// <param name="productId">The Product Id.</param>
        public void Insert(int supplierId, out int productSupplierId, Guid productId)
        {
            productSupplierId = -1;
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.AddSupplierProductItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@ProductId", productId).DbType = DbType.Guid;
                    cmd.ExecuteNonQuery();
                    productSupplierId = (int)cmd.Parameters["@ProductSupplierId"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the SupplierProductItem object.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        /// <param name="productId">The Product Id.</param>
        public void Update(int productSupplierId, Guid productId)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.UpdateSupplierProductItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ProductId", productId).DbType = DbType.Guid;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("SupplierProductItem");
                }
            }
        }

        /// <summary>
        /// Deletes the SupplierProductItem object from database.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        public void Delete(int productSupplierId)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.DeleteSupplierProductItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierId).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

    }
}
