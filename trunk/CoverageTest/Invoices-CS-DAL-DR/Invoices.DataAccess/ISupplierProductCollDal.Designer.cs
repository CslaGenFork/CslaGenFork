using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierProductColl type
    /// </summary>
    public partial interface ISupplierProductCollDal
    {
        /// <summary>
        /// Loads a SupplierProductColl collection from the database.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <returns>A data reader to the SupplierProductColl.</returns>
        IDataReader Fetch(int supplierId);
    }
}
