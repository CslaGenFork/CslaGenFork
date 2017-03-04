using System;
using System.Data;
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
        /// <returns>A data reader to the SupplierList.</returns>
        IDataReader Fetch();

        /// <summary>
        /// Loads a SupplierList collection from the database.
        /// </summary>
        /// <param name="name">The Name.</param>
        /// <returns>A data reader to the SupplierList.</returns>
        IDataReader Fetch(string name);
    }
}
