using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeEdit type
    /// </summary>
    public partial interface IProductTypeEditDal
    {
        /// <summary>
        /// Loads a ProductTypeEdit object from the database.
        /// </summary>
        /// <param name="productTypeId">The fetch criteria.</param>
        /// <returns>A <see cref="ProductTypeEditDto"/> object.</returns>
        ProductTypeEditDto Fetch(int productTypeId);

        /// <summary>
        /// Inserts a new ProductTypeEdit object in the database.
        /// </summary>
        /// <param name="productTypeEdit">The Product Type Edit DTO.</param>
        /// <returns>The new <see cref="ProductTypeEditDto"/>.</returns>
        ProductTypeEditDto Insert(ProductTypeEditDto productTypeEdit);

        /// <summary>
        /// Updates in the database all changes made to the ProductTypeEdit object.
        /// </summary>
        /// <param name="productTypeEdit">The Product Type Edit DTO.</param>
        /// <returns>The updated <see cref="ProductTypeEditDto"/>.</returns>
        ProductTypeEditDto Update(ProductTypeEditDto productTypeEdit);

        /// <summary>
        /// Deletes the ProductTypeEdit object from database.
        /// </summary>
        /// <param name="productTypeId">The delete criteria.</param>
        void Delete(int productTypeId);
    }
}
