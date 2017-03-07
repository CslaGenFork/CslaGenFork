using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierInfoDetail type
    /// </summary>
    public partial interface ISupplierInfoDetailDal
    {
        /// <summary>
        /// Loads a SupplierInfoDetail object from the database.
        /// </summary>
        /// <param name="supplierId">The fetch criteria.</param>
        /// <returns>A <see cref="SupplierInfoDetailDto"/> object.</returns>
        SupplierInfoDetailDto Fetch(int supplierId);
    }
}
