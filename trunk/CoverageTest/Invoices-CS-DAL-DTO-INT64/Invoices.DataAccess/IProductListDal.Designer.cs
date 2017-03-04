using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductList type
    /// </summary>
    public partial interface IProductListDal
    {
        /// <summary>
        /// Loads a ProductList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductInfoDto"/>.</returns>
        List<ProductInfoDto> Fetch();
    }
}
