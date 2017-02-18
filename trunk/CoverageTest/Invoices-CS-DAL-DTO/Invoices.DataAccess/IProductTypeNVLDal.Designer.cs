using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeNVL type
    /// </summary>
    public partial interface IProductTypeNVLDal
    {
        /// <summary>
        /// Loads a ProductTypeNVL list from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeNVLItemDto"/>.</returns>
        List<ProductTypeNVLItemDto> Fetch();
    }
}
