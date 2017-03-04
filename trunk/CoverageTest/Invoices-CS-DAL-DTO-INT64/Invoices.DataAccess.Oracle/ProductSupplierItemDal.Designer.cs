using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Oracle
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
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.AddProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductId", productSupplierItem.Parent_ProductId).DbType = DbType.Guid;
                    cmd.Parameters.Add("@ProductSupplierId", productSupplierItem.ProductSupplierId).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@SupplierId", productSupplierItem.SupplierId).DbType = DbType.Int32;
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
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.UpdateProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductSupplierId", productSupplierItem.ProductSupplierId).DbType = DbType.Int32;
                    cmd.Parameters.Add("@SupplierId", productSupplierItem.SupplierId).DbType = DbType.Int32;
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
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.DeleteProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductSupplierId", productSupplierId).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

    }
}
