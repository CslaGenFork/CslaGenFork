using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeCachedList type
    /// </summary>
    public partial interface IProductTypeCachedListDal
    {
        /// <summary>
        /// Loads a ProductTypeCachedList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeCachedInfoDto"/>.</returns>
        List<ProductTypeCachedInfoDto> Fetch();
    }
}
