using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for ProductTypeRO type
    /// </summary>
    public partial interface IProductTypeRODal
    {
        /// <summary>
        /// Loads a ProductTypeRO object from the database.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <returns>A data reader to the ProductTypeRO.</returns>
        IDataReader Fetch(int productTypeId);
    }
}
