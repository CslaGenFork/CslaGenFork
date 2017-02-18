using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeRO type
    /// </summary>
    public partial interface IProductTypeRODal
    {
        /// <summary>
        /// Loads a ProductTypeRO object from the database.
        /// </summary>
        /// <param name="productTypeId">The fetch criteria.</param>
        /// <returns>A <see cref="ProductTypeRODto"/> object.</returns>
        ProductTypeRODto Fetch(int productTypeId);
    }
}
