using System;
using System.Data;
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
        /// <returns>A data reader to the ProductTypeCachedList.</returns>
        IDataReader Fetch();
    }
}
