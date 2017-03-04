using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeUpdatedByRootList type
    /// </summary>
    public partial interface IProductTypeUpdatedByRootListDal
    {
        /// <summary>
        /// Loads a ProductTypeUpdatedByRootList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeUpdatedByRootInfoDto"/>.</returns>
        List<ProductTypeUpdatedByRootInfoDto> Fetch();
    }
}
