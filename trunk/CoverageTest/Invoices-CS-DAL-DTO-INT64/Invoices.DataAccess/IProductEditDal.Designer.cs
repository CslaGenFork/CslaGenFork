using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductEdit type
    /// </summary>
    public partial interface IProductEditDal
    {
        /// <summary>
        /// Gets the Suppliers.
        /// </summary>
        /// <value>A list of <see cref="ProductSupplierItemDto"/>.</value>
        List<ProductSupplierItemDto> ProductSupplierColl { get; }

        /// <summary>
        /// Loads a ProductEdit object from the database.
        /// </summary>
        /// <param name="productId">The fetch criteria.</param>
        /// <returns>A <see cref="ProductEditDto"/> object.</returns>
        ProductEditDto Fetch(Guid productId);

        /// <summary>
        /// Inserts a new ProductEdit object in the database.
        /// </summary>
        /// <param name="productEdit">The Product Edit DTO.</param>
        /// <returns>The new <see cref="ProductEditDto"/>.</returns>
        ProductEditDto Insert(ProductEditDto productEdit);

        /// <summary>
        /// Updates in the database all changes made to the ProductEdit object.
        /// </summary>
        /// <param name="productEdit">The Product Edit DTO.</param>
        /// <returns>The updated <see cref="ProductEditDto"/>.</returns>
        ProductEditDto Update(ProductEditDto productEdit);
    }
}
