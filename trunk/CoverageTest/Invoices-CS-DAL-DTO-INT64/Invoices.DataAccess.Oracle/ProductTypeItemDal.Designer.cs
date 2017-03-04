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
    /// DAL SQL Server implementation of <see cref="IProductTypeItemDal"/>
    /// </summary>
    public partial class ProductTypeItemDal : IProductTypeItemDal
    {

        #region DAL methods

        /// <summary>
        /// Inserts a new ProductTypeItem object in the database.
        /// </summary>
        /// <param name="productTypeItem">The Product Type Item DTO.</param>
        /// <returns>The new <see cref="ProductTypeItemDto"/>.</returns>
        public ProductTypeItemDto Insert(ProductTypeItemDto productTypeItem)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.AddProductTypeItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductTypeId", productTypeItem.ProductTypeId).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Name", productTypeItem.Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    productTypeItem.ProductTypeId = (int)cmd.Parameters["@ProductTypeId"].Value;
                }
            }
            return productTypeItem;
        }

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeItem object.
        /// </summary>
        /// <param name="productTypeItem">The Product Type Item DTO.</param>
        /// <returns>The updated <see cref="ProductTypeItemDto"/>.</returns>
        public ProductTypeItemDto Update(ProductTypeItemDto productTypeItem)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.UpdateProductTypeItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductTypeId", productTypeItem.ProductTypeId).DbType = DbType.Int32;
                    cmd.Parameters.Add("@Name", productTypeItem.Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductTypeItem");
                }
            }
            return productTypeItem;
        }

        /// <summary>
        /// Deletes the ProductTypeItem object from database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        public void Delete(int productTypeId)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.DeleteProductTypeItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

    }
}
