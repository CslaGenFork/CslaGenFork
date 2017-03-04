using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for CustomerEdit type
    /// </summary>
    public partial interface ICustomerEditDal
    {
        /// <summary>
        /// Loads a CustomerEdit object from the database.
        /// </summary>
        /// <param name="customerId">The fetch criteria.</param>
        /// <returns>A <see cref="CustomerEditDto"/> object.</returns>
        CustomerEditDto Fetch(string customerId);

        /// <summary>
        /// Inserts a new CustomerEdit object in the database.
        /// </summary>
        /// <param name="customerEdit">The Customer Edit DTO.</param>
        /// <returns>The new <see cref="CustomerEditDto"/>.</returns>
        CustomerEditDto Insert(CustomerEditDto customerEdit);

        /// <summary>
        /// Updates in the database all changes made to the CustomerEdit object.
        /// </summary>
        /// <param name="customerEdit">The Customer Edit DTO.</param>
        /// <returns>The updated <see cref="CustomerEditDto"/>.</returns>
        CustomerEditDto Update(CustomerEditDto customerEdit);

        /// <summary>
        /// Deletes the CustomerEdit object from database.
        /// </summary>
        /// <param name="customerId">The delete criteria.</param>
        void Delete(string customerId);
    }
}
