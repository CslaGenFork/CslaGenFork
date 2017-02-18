using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierList type
    /// </summary>
    public partial interface ISupplierListDal
    {
        /// <summary>
        /// Loads a SupplierList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="SupplierInfoDto"/>.</returns>
        List<SupplierInfoDto> Fetch();

        /// <summary>
        /// Loads a SupplierList collection from the database.
        /// </summary>
        /// <param name="name">The fetch criteria.</param>
        /// <returns>A list of <see cref="SupplierInfoDto"/>.</returns>
        List<SupplierInfoDto> Fetch(string name);
    }
}
