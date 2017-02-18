using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierProductItem type
    /// </summary>
    public partial interface ISupplierProductItemDal
    {
        /// <summary>
        /// Inserts a new SupplierProductItem object in the database.
        /// </summary>
        /// <param name="supplierProductItem">The Supplier Product Item DTO.</param>
        /// <returns>The new <see cref="SupplierProductItemDto"/>.</returns>
        SupplierProductItemDto Insert(SupplierProductItemDto supplierProductItem);

        /// <summary>
        /// Updates in the database all changes made to the SupplierProductItem object.
        /// </summary>
        /// <param name="supplierProductItem">The Supplier Product Item DTO.</param>
        /// <returns>The updated <see cref="SupplierProductItemDto"/>.</returns>
        SupplierProductItemDto Update(SupplierProductItemDto supplierProductItem);

        /// <summary>
        /// Deletes the SupplierProductItem object from database.
        /// </summary>
        /// <param name="productSupplierId">The Product Supplier Id.</param>
        void Delete(int productSupplierId);
    }
}
