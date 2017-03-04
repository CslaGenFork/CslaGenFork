using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductSupplierItem type
    /// </summary>
    public partial interface IProductSupplierItemDal
    {
        /// <summary>
        /// Inserts a new ProductSupplierItem object in the database.
        /// </summary>
        /// <param name="productSupplierItem">The Product Supplier Item DTO.</param>
        /// <returns>The new <see cref="ProductSupplierItemDto"/>.</returns>
        ProductSupplierItemDto Insert(ProductSupplierItemDto productSupplierItem);

        /// <summary>
        /// Updates in the database all changes made to the ProductSupplierItem object.
        /// </summary>
        /// <param name="productSupplierItem">The Product Supplier Item DTO.</param>
        /// <returns>The updated <see cref="ProductSupplierItemDto"/>.</returns>
        ProductSupplierItemDto Update(ProductSupplierItemDto productSupplierItem);

        /// <summary>
        /// Deletes the ProductSupplierItem object from database.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        void Delete(int productSupplierId);
    }
}
