using System;
using System.Collections.Generic;
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
        /// <returns>A list of <see cref="CustomerInfoDto"/>.</returns>
        List<CustomerInfoDto> Fetch();

        /// <summary>
        /// Loads a CustomerList collection from the database.
        /// </summary>
        /// <param name="name">The fetch criteria.</param>
        /// <returns>A list of <see cref="CustomerInfoDto"/>.</returns>
        List<CustomerInfoDto> Fetch(string name);
    }
}
