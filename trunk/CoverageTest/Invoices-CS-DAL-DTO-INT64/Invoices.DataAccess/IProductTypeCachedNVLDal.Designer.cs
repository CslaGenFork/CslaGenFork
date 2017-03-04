using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeCachedNVL type
    /// </summary>
    public partial interface IProductTypeCachedNVLDal
    {
        /// <summary>
        /// Loads a ProductTypeCachedNVL list from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeCachedNVLItemDto"/>.</returns>
        List<ProductTypeCachedNVLItemDto> Fetch();
    }
}
