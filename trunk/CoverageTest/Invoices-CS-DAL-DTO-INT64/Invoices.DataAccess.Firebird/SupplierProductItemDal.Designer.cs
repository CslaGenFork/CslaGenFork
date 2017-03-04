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
    /// DAL SQL Server implementation of <see cref="ISupplierProductItemDal"/>
    /// </summary>
    public partial class SupplierProductItemDal : ISupplierProductItemDal
    {

        #region DAL methods

        /// <summary>
        /// Inserts a new SupplierProductItem object in the database.
        /// </summary>
        /// <param name="supplierProductItem">The Supplier Product Item DTO.</param>
        /// <returns>The new <see cref="SupplierProductItemDto"/>.</returns>
        public SupplierProductItemDto Insert(SupplierProductItemDto supplierProductItem)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.AddSupplierProductItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierProductItem.Parent_SupplierId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", supplierProductItem.ProductSupplierId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@ProductId", supplierProductItem.ProductId).DbType = DbType.Guid;
                    cmd.ExecuteNonQuery();
                    supplierProductItem.ProductSupplierId = (int)cmd.Parameters["@ProductSupplierId"].Value;
                }
            }
            return supplierProductItem;
        }

        /// <summary>
        /// Updates in the database all changes made to the SupplierProductItem object.
        /// </summary>
        /// <param name="supplierProductItem">The Supplier Product Item DTO.</param>
        /// <returns>The updated <see cref="SupplierProductItemDto"/>.</returns>
        public SupplierProductItemDto Update(SupplierProductItemDto supplierProductItem)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.UpdateSupplierProductItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", supplierProductItem.ProductSupplierId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ProductId", supplierProductItem.ProductId).DbType = DbType.Guid;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("SupplierProductItem");
                }
            }
            return supplierProductItem;
        }

        /// <summary>
        /// Deletes the SupplierProductItem object from database.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        public void Delete(int productSupplierId)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.DeleteSupplierProductItem", ctx.Connection))
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
