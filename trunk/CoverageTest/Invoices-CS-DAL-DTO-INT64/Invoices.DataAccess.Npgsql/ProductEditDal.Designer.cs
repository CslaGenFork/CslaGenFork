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
    /// DAL SQL Server implementation of <see cref="IProductEditDal"/>
    /// </summary>
    public partial class ProductEditDal : IProductEditDal
    {

        #region DAL methods

        private List<ProductSupplierItemDto> _productSupplierColl = new List<ProductSupplierItemDto>();

        /// <summary>
        /// Gets the Suppliers.
        /// </summary>
        /// <value>A list of <see cref="ProductSupplierItemDto"/>.</value>
        public List<ProductSupplierItemDto> ProductSupplierColl
        {
            get { return _productSupplierColl; }
        }

        /// <summary>
        /// Loads a ProductEdit object from the database.
        /// </summary>
        /// <param name="productId">The fetch criteria.</param>
        /// <returns>A ProductEditDto object.</returns>
        public ProductEditDto Fetch(Guid productId)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.GetProductEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId).DbType = DbType.Guid;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private ProductEditDto Fetch(IDataReader data)
        {
            var productEdit = new ProductEditDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    productEdit.ProductId = dr.GetGuid("ProductId");
                    productEdit.ProductCode = dr.IsDBNull("ProductCode") ? null : dr.GetString("ProductCode");
                    productEdit.Name = dr.GetString("Name");
                    productEdit.ProductTypeId = dr.GetInt32("ProductTypeId");
                    productEdit.UnitCost = dr.GetString("UnitCost");
                    productEdit.StockByteNull = (byte?)dr.GetValue("StockByteNull");
                    productEdit.StockByte = dr.GetByte("StockByte");
                    productEdit.StockShortNull = (short?)dr.GetValue("StockShortNull");
                    productEdit.StockShort = dr.GetInt16("StockShort");
                    productEdit.StockIntNull = (int?)dr.GetValue("StockIntNull");
                    productEdit.StockInt = dr.GetInt32("StockInt");
                    productEdit.StockLongNull = (long?)dr.GetValue("StockLongNull");
                    productEdit.StockLong = dr.GetInt64("StockLong");
                }
                FetchChildren(dr);
            }
            return productEdit;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            while (dr.Read())
            {
                _productSupplierColl.Add(FetchProductSupplierItem(dr));
            }
        }

        private ProductSupplierItemDto FetchProductSupplierItem(SafeDataReader dr)
        {
            var productSupplierItem = new ProductSupplierItemDto();
            // Value properties
            productSupplierItem.ProductSupplierId = dr.GetInt32("ProductSupplierId");
            productSupplierItem.SupplierId = dr.GetInt32("SupplierId");

            return productSupplierItem;
        }

        /// <summary>
        /// Inserts a new ProductEdit object in the database.
        /// </summary>
        /// <param name="productEdit">The Product Edit DTO.</param>
        /// <returns>The new <see cref="ProductEditDto"/>.</returns>
        public ProductEditDto Insert(ProductEditDto productEdit)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.AddProductEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productEdit.ProductId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductCode", productEdit.ProductCode == null ? (object)DBNull.Value : productEdit.ProductCode).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", productEdit.Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productEdit.ProductTypeId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@UnitCost", productEdit.UnitCost).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@StockByteNull", productEdit.StockByteNull == null ? (object)DBNull.Value : productEdit.StockByteNull.Value).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockByte", productEdit.StockByte).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockShortNull", productEdit.StockShortNull == null ? (object)DBNull.Value : productEdit.StockShortNull.Value).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockShort", productEdit.StockShort).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockIntNull", productEdit.StockIntNull == null ? (object)DBNull.Value : productEdit.StockIntNull.Value).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockInt", productEdit.StockInt).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockLongNull", productEdit.StockLongNull == null ? (object)DBNull.Value : productEdit.StockLongNull.Value).DbType = DbType.Int64;
                    cmd.Parameters.AddWithValue("@StockLong", productEdit.StockLong).DbType = DbType.Int64;
                    cmd.ExecuteNonQuery();
                }
            }
            return productEdit;
        }

        /// <summary>
        /// Updates in the database all changes made to the ProductEdit object.
        /// </summary>
        /// <param name="productEdit">The Product Edit DTO.</param>
        /// <returns>The updated <see cref="ProductEditDto"/>.</returns>
        public ProductEditDto Update(ProductEditDto productEdit)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.UpdateProductEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productEdit.ProductId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductCode", productEdit.ProductCode == null ? (object)DBNull.Value : productEdit.ProductCode).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", productEdit.Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productEdit.ProductTypeId).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@UnitCost", productEdit.UnitCost).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@StockByteNull", productEdit.StockByteNull == null ? (object)DBNull.Value : productEdit.StockByteNull.Value).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockByte", productEdit.StockByte).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockShortNull", productEdit.StockShortNull == null ? (object)DBNull.Value : productEdit.StockShortNull.Value).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockShort", productEdit.StockShort).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockIntNull", productEdit.StockIntNull == null ? (object)DBNull.Value : productEdit.StockIntNull.Value).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockInt", productEdit.StockInt).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockLongNull", productEdit.StockLongNull == null ? (object)DBNull.Value : productEdit.StockLongNull.Value).DbType = DbType.Int64;
                    cmd.Parameters.AddWithValue("@StockLong", productEdit.StockLong).DbType = DbType.Int64;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("ProductEdit");
                }
            }
            return productEdit;
        }

        #endregion

    }
}
