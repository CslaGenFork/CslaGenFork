using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.MySql
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
            using (var ctx = ConnectionManager<MySqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new MySqlCommand("dbo.AddProductTypeItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeItem.ProductTypeId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Name", productTypeItem.Name).DbType = DbType.String;
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
            using (var ctx = ConnectionManager<MySqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new MySqlCommand("dbo.UpdateProductTypeItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeItem.ProductTypeId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Name", productTypeItem.Name).DbType = DbType.String;
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
            using (var ctx = ConnectionManager<MySqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new MySqlCommand("dbo.DeleteProductTypeItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

    }
}
