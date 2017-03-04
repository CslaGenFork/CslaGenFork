using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeDynaColl type
    /// </summary>
    public partial interface IProductTypeDynaCollDal
    {
        /// <summary>
        /// Loads a ProductTypeDynaColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeDynaItemDto"/>.</returns>
        List<ProductTypeDynaItemDto> Fetch();
    }
}
