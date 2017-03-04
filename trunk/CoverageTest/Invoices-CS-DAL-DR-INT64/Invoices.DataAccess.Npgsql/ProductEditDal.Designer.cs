using System;
using System.Data;
using Npgsql;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Npgsql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IProductEditDal"/>
    /// </summary>
    public partial class ProductEditDal : IProductEditDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductEdit object from the database.
        /// </summary>
        /// <param name="productId">The Product Id.</param>
        /// <returns>A data reader to the ProductEdit.</returns>
        public IDataReader Fetch(Guid productId)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.GetProductEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId).DbType = DbType.Guid;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new ProductEdit object in the database.
        /// </summary>
        /// <param name="productId">The Product Id.</param>
        /// <param name="productCode">The Product Code.</param>
        /// <param name="name">The Name.</param>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="unitCost">The Unit Cost.</param>
        /// <param name="stockByteNull">The Stock Byte Null.</param>
        /// <param name="stockByte">The Stock Byte.</param>
        /// <param name="stockShortNull">The Stock Short Null.</param>
        /// <param name="stockShort">The Stock Short.</param>
        /// <param name="stockIntNull">The Stock Int Null.</param>
        /// <param name="stockInt">The Stock Int.</param>
        /// <param name="stockLongNull">The Stock Long Null.</param>
        /// <param name="stockLong">The Stock Long.</param>
        public void Insert(Guid productId, string productCode, string name, int productTypeId, string unitCost, byte? stockByteNull, byte stockByte, short? stockShortNull, short stockShort, int? stockIntNull, int stockInt, long? stockLongNull, long stockLong)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.AddProductEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductCode", productCode == null ? (object)DBNull.Value : productCode).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@UnitCost", unitCost).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@StockByteNull", stockByteNull == null ? (object)DBNull.Value : stockByteNull.Value).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockByte", stockByte).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockShortNull", stockShortNull == null ? (object)DBNull.Value : stockShortNull.Value).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockShort", stockShort).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockIntNull", stockIntNull == null ? (object)DBNull.Value : stockIntNull.Value).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockInt", stockInt).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockLongNull", stockLongNull == null ? (object)DBNull.Value : stockLongNull.Value).DbType = DbType.Int64;
                    cmd.Parameters.AddWithValue("@StockLong", stockLong).DbType = DbType.Int64;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the ProductEdit object.
        /// </summary>
        /// <param name="productId">The Product Id.</param>
        /// <param name="productCode">The Product Code.</param>
        /// <param name="name">The Name.</param>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <param name="unitCost">The Unit Cost.</param>
        /// <param name="stockByteNull">The Stock Byte Null.</param>
        /// <param name="stockByte">The Stock Byte.</param>
        /// <param name="stockShortNull">The Stock Short Null.</param>
        /// <param name="stockShort">The Stock Short.</param>
        /// <param name="stockIntNull">The Stock Int Null.</param>
        /// <param name="stockInt">The Stock Int.</param>
        /// <param name="stockLongNull">The Stock Long Null.</param>
        /// <param name="stockLong">The Stock Long.</param>
        public void Update(Guid productId, string productCode, string name, int productTypeId, string unitCost, byte? stockByteNull, byte stockByte, short? stockShortNull, short stockShort, int? stockIntNull, int stockInt, long? stockLongNull, long stockLong)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.UpdateProductEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductCode", productCode == null ? (object)DBNull.Value : productCode).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@UnitCost", unitCost).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@StockByteNull", stockByteNull == null ? (object)DBNull.Value : stockByteNull.Value).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockByte", stockByte).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockShortNull", stockShortNull == null ? (object)DBNull.Value : stockShortNull.Value).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockShort", stockShort).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockIntNull", stockIntNull == null ? (object)DBNull.Value : stockIntNull.Value).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockInt", stockInt).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockLongNull", stockLongNull == null ? (object)DBNull.Value : stockLongNull.Value).DbType = DbType.Int64;
                    cmd.Parameters.AddWithValue("@StockLong", stockLong).DbType = DbType.Int64;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductEdit");
                }
            }
        }

        #endregion

    }
}
