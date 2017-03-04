using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeList type
    /// </summary>
    public partial interface IProductTypeListDal
    {
        /// <summary>
        /// Loads a ProductTypeList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeInfoDto"/>.</returns>
        List<ProductTypeInfoDto> Fetch();
    }
}
