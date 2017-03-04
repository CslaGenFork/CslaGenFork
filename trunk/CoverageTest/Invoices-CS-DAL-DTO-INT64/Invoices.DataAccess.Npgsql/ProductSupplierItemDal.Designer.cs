using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Npgsql
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
        /// <param name="productSupplierItem">The Product Supplier Item DTO.</param>
        /// <returns>The new <see cref="ProductSupplierItemDto"/>.</returns>
        public ProductSupplierItemDto Insert(ProductSupplierItemDto productSupplierItem)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.AddProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productSupplierItem.Parent_ProductId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierItem.ProductSupplierId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SupplierId", productSupplierItem.SupplierId).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                    productSupplierItem.ProductSupplierId = (int)cmd.Parameters["@ProductSupplierId"].Value;
                }
            }
            return productSupplierItem;
        }

        /// <summary>
        /// Updates in the database all changes made to the ProductSupplierItem object.
        /// </summary>
        /// <param name="productSupplierItem">The Product Supplier Item DTO.</param>
        /// <returns>The updated <see cref="ProductSupplierItemDto"/>.</returns>
        public ProductSupplierItemDto Update(ProductSupplierItemDto productSupplierItem)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.UpdateProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierItem.ProductSupplierId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SupplierId", productSupplierItem.SupplierId).DbType = DbType.Int32;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductSupplierItem");
                }
            }
            return productSupplierItem;
        }

        /// <summary>
        /// Deletes the ProductSupplierItem object from database.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        public void Delete(int productSupplierId)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.DeleteProductSupplierItem", ctx.Connection))
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
