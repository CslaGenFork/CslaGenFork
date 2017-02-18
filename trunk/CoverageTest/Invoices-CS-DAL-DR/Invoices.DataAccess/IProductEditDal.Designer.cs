using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductEdit type
    /// </summary>
    public partial interface IProductEditDal
    {
        /// <summary>
        /// Loads a ProductEdit object from the database.
        /// </summary>
        /// <param name="productId">The Product Id.</param>
        /// <returns>A data reader to the ProductEdit.</returns>
        IDataReader Fetch(Guid productId);

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
        void Insert(Guid productId, string productCode, string name, int productTypeId, string unitCost, byte? stockByteNull, byte stockByte, short? stockShortNull, short stockShort, int? stockIntNull, int stockInt, long? stockLongNull, long stockLong);

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
        void Update(Guid productId, string productCode, string name, int productTypeId, string unitCost, byte? stockByteNull, byte stockByte, short? stockShortNull, short stockShort, int? stockIntNull, int stockInt, long? stockLongNull, long stockLong);
    }
}
