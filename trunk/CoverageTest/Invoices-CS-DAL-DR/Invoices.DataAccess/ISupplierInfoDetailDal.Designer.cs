using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierInfoDetail type
    /// </summary>
    public partial interface ISupplierInfoDetailDal
    {
        /// <summary>
        /// Loads a SupplierInfoDetail object from the database.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <returns>A data reader to the SupplierInfoDetail.</returns>
        IDataReader Fetch(int supplierId);
    }
}
