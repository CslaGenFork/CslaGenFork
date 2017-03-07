using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierProductList type
    /// </summary>
    public partial interface ISupplierProductListDal
    {
        /// <summary>
        /// Loads a SupplierProductList collection from the database.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <returns>A data reader to the SupplierProductList.</returns>
        IDataReader Fetch(int supplierId);
    }
}
