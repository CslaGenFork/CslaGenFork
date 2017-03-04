using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeItem type
    /// </summary>
    public partial interface IProductTypeItemDal
    {
        /// <summary>
        /// Inserts a new ProductTypeItem object in the database.
        /// </summary>
        /// <param name="productTypeItem">The Product Type Item DTO.</param>
        /// <returns>The new <see cref="ProductTypeItemDto"/>.</returns>
        ProductTypeItemDto Insert(ProductTypeItemDto productTypeItem);

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeItem object.
        /// </summary>
        /// <param name="productTypeItem">The Product Type Item DTO.</param>
        /// <returns>The updated <see cref="ProductTypeItemDto"/>.</returns>
        ProductTypeItemDto Update(ProductTypeItemDto productTypeItem);

        /// <summary>
        /// Deletes the ProductTypeItem object from database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        void Delete(int productTypeId);
    }
}
