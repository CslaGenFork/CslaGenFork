using System;
using System.Data;
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
        /// <returns>A data reader to the ProductList.</returns>
        IDataReader Fetch();
    }
}
