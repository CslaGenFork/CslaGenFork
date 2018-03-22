using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierProductList type
    /// </summary>
    public partial interface ISupplierProductListDal
    {
        /// <summary>
        /// Loads a SupplierProductList collection from the database.
        /// </summary>
        /// <param name="supplierId">The fetch criteria.</param>
        /// <returns>A list of <see cref="SupplierProductInfoDto"/>.</returns>
        List<SupplierProductInfoDto> Fetch(int supplierId);
    }
}
