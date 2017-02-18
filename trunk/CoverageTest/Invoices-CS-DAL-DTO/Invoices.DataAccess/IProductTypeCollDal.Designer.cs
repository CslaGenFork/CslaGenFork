using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeColl type
    /// </summary>
    public partial interface IProductTypeCollDal
    {
        /// <summary>
        /// Loads a ProductTypeColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeItemDto"/>.</returns>
        List<ProductTypeItemDto> Fetch();
    }
}
