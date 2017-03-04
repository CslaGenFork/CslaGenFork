using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeNVL type
    /// </summary>
    public partial interface IProductTypeNVLDal
    {
        /// <summary>
        /// Loads a ProductTypeNVL list from the database.
        /// </summary>
        /// <returns>A data reader to the ProductTypeNVL.</returns>
        IDataReader Fetch();
    }
}
