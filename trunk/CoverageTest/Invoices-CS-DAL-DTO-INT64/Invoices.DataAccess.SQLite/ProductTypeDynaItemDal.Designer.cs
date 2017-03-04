using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.SQLite
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IProductTypeDynaItemDal"/>
    /// </summary>
    public partial class ProductTypeDynaItemDal : IProductTypeDynaItemDal
    {

        #region DAL methods

        /// <summary>
        /// Inserts a new ProductTypeDynaItem object in the database.
        /// </summary>
        /// <param name="productTypeDynaItem">The Product Type Dyna Item DTO.</param>
        /// <returns>The new <see cref="ProductTypeDynaItemDto"/>.</returns>
        public ProductTypeDynaItemDto Insert(ProductTypeDynaItemDto productTypeDynaItem)
        {
            using (var ctx = ConnectionManager<SQLiteConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SQLiteCommand("dbo.AddProductTypeDynaItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeDynaItem.ProductTypeId).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Name", productTypeDynaItem.Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    productTypeDynaItem.ProductTypeId = (int)cmd.Parameters["@ProductTypeId"].Value;
                }
            }
            return productTypeDynaItem;
        }

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeDynaItem object.
        /// </summary>
        /// <param name="productTypeDynaItem">The Product Type Dyna Item DTO.</param>
        /// <returns>The updated <see cref="ProductTypeDynaItemDto"/>.</returns>
        public ProductTypeDynaItemDto Update(ProductTypeDynaItemDto productTypeDynaItem)
        {
            using (var ctx = ConnectionManager<SQLiteConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SQLiteCommand("dbo.UpdateProductTypeDynaItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeDynaItem.ProductTypeId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Name", productTypeDynaItem.Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductTypeDynaItem");
                }
            }
            return productTypeDynaItem;
        }

        /// <summary>
        /// Deletes the ProductTypeDynaItem object from database.
        /// </summary>
        /// <param name="productTypeId">The delete criteria.</param>
        public void Delete(int productTypeId)
        {
            using (var ctx = ConnectionManager<SQLiteConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SQLiteCommand("dbo.DeleteProductTypeDynaItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductTypeDynaItem");
                }
            }
        }

        #endregion

    }
}
