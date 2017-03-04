using System;
using System.Data;
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
        /// <returns>A data reader to the ProductTypeCachedNVL.</returns>
        IDataReader Fetch();
    }
}
