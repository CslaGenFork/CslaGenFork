using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for CustomerList type
    /// </summary>
    public partial interface ICustomerListDal
    {
        /// <summary>
        /// Loads a CustomerList collection from the database.
        /// </summary>
        /// <returns>A data reader to the CustomerList.</returns>
        IDataReader Fetch();

        /// <summary>
        /// Loads a CustomerList collection from the database.
        /// </summary>
        /// <param name="name">The Name.</param>
        /// <returns>A data reader to the CustomerList.</returns>
        IDataReader Fetch(string name);
    }
}
