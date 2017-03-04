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
    /// DAL SQL Server implementation of <see cref="IProductTypeEditDal"/>
    /// </summary>
    public partial class ProductTypeEditDal : IProductTypeEditDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeEdit object from the database.
        /// </summary>
        /// <param name="productTypeId">The fetch criteria.</param>
        /// <returns>A ProductTypeEditDto object.</returns>
        public ProductTypeEditDto Fetch(int productTypeId)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.GetProductTypeEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private ProductTypeEditDto Fetch(IDataReader data)
        {
            var productTypeEdit = new ProductTypeEditDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    productTypeEdit.ProductTypeId = dr.GetInt32("ProductTypeId");
                    productTypeEdit.Name = dr.GetString("Name");
                }
            }
            return productTypeEdit;
        }

        /// <summary>
        /// Inserts a new ProductTypeEdit object in the database.
        /// </summary>
        /// <param name="productTypeEdit">The Product Type Edit DTO.</param>
        /// <returns>The new <see cref="ProductTypeEditDto"/>.</returns>
        public ProductTypeEditDto Insert(ProductTypeEditDto productTypeEdit)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.AddProductTypeEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductTypeId", productTypeEdit.ProductTypeId).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Name", productTypeEdit.Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    productTypeEdit.ProductTypeId = (int)cmd.Parameters["@ProductTypeId"].Value;
                }
            }
            return productTypeEdit;
        }

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeEdit object.
        /// </summary>
        /// <param name="productTypeEdit">The Product Type Edit DTO.</param>
        /// <returns>The updated <see cref="ProductTypeEditDto"/>.</returns>
        public ProductTypeEditDto Update(ProductTypeEditDto productTypeEdit)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.UpdateProductTypeEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductTypeId", productTypeEdit.ProductTypeId).DbType = DbType.Int32;
                    cmd.Parameters.Add("@Name", productTypeEdit.Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductTypeEdit");
                }
            }
            return productTypeEdit;
        }

        /// <summary>
        /// Deletes the ProductTypeEdit object from database.
        /// </summary>
        /// <param name="productTypeId">The delete criteria.</param>
        public void Delete(int productTypeId)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.DeleteProductTypeEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductTypeEdit");
                }
            }
        }

        #endregion

    }
}
