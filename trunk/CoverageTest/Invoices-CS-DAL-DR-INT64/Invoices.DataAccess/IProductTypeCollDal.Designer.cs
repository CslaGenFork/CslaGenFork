using System;
using System.Data;
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
        /// <returns>A data reader to the ProductTypeColl.</returns>
        IDataReader Fetch();
    }
}
