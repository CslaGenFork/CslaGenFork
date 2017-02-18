using System;
using System.Data;
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
        /// <returns>A data reader to the ProductTypeDynaColl.</returns>
        IDataReader Fetch();
    }
}
