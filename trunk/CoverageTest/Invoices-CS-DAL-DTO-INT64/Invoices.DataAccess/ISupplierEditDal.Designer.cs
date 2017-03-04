using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierEdit type
    /// </summary>
    public partial interface ISupplierEditDal
    {
        /// <summary>
        /// Loads a SupplierEdit object from the database.
        /// </summary>
        /// <param name="supplierId">The fetch criteria.</param>
        /// <returns>A <see cref="SupplierEditDto"/> object.</returns>
        SupplierEditDto Fetch(int supplierId);

        /// <summary>
        /// Inserts a new SupplierEdit object in the database.
        /// </summary>
        /// <param name="supplierEdit">The Supplier Edit DTO.</param>
        /// <returns>The new <see cref="SupplierEditDto"/>.</returns>
        SupplierEditDto Insert(SupplierEditDto supplierEdit);

        /// <summary>
        /// Updates in the database all changes made to the SupplierEdit object.
        /// </summary>
        /// <param name="supplierEdit">The Supplier Edit DTO.</param>
        /// <returns>The updated <see cref="SupplierEditDto"/>.</returns>
        SupplierEditDto Update(SupplierEditDto supplierEdit);
    }
}
