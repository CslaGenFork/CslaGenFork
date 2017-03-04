using System;
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
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="name">The Name.</param>
        public void Insert(out int productTypeId, string name)
        {
            productTypeId = -1;
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.AddProductTypeItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductTypeId", productTypeId).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Name", name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    productTypeId = (int)cmd.Parameters["@ProductTypeId"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeItem object.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="name">The Name.</param>
        public void Update(int productTypeId, string name)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.UpdateProductTypeItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    cmd.Parameters.Add("@Name", name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductTypeItem");
                }
            }
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
