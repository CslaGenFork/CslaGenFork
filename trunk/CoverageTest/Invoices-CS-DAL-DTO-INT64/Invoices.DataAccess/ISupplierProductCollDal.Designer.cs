using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierProductColl type
    /// </summary>
    public partial interface ISupplierProductCollDal
    {
        /// <summary>
        /// Loads a SupplierProductColl collection from the database.
        /// </summary>
        /// <param name="supplierId">The fetch criteria.</param>
        /// <returns>A list of <see cref="SupplierProductItemDto"/>.</returns>
        List<SupplierProductItemDto> Fetch(int supplierId);
    }
}
