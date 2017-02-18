using System;
using System.Data;
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
        /// <returns>A data reader to the ProductTypeUpdatedByRootList.</returns>
        IDataReader Fetch();
    }
}
