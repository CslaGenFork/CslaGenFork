using System;
using System.Data;
using System.Data.SQLite;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.SQLite
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IProductSupplierItemDal"/>
    /// </summary>
    public partial class ProductSupplierItemDal : IProductSupplierItemDal
    {

        #region DAL methods

        /// <summary>
        /// Inserts a new ProductSupplierItem object in the database.
        /// </summary>
        /// <param name="productId">The parent Product Id.</param>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        /// <param name="supplierId">The Supplier Id.</param>
        public void Insert(Guid productId, out int productSupplierId, int supplierId)
        {
            productSupplierId = -1;
            using (var ctx = ConnectionManager<SQLiteConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SQLiteCommand("dbo.AddProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                    productSupplierId = (int)cmd.Parameters["@ProductSupplierId"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the ProductSupplierItem object.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        /// <param name="supplierId">The Supplier Id.</param>
        public void Update(int productSupplierId, int supplierId)
        {
            using (var ctx = ConnectionManager<SQLiteConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SQLiteCommand("dbo.UpdateProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductSupplierItem");
                }
            }
        }

        /// <summary>
        /// Deletes the ProductSupplierItem object from database.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        public void Delete(int productSupplierId)
        {
            using (var ctx = ConnectionManager<SQLiteConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SQLiteCommand("dbo.DeleteProductSupplierItem", ctx.Connection))
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
