using System;
using System.Data;
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
        /// <param name="customerId">The Customer Id.</param>
        /// <returns>A data reader to the CustomerEdit.</returns>
        IDataReader Fetch(string customerId);

        /// <summary>
        /// Inserts a new CustomerEdit object in the database.
        /// </summary>
        /// <param name="customerId">The Customer Id.</param>
        /// <param name="name">The Name.</param>
        /// <param name="fiscalNumber">The Fiscal Number.</param>
        /// <param name="addressLine1">The Address Line1.</param>
        /// <param name="addressLine2">The Address Line2.</param>
        /// <param name="zipCode">The Zip Code.</param>
        /// <param name="state">The State.</param>
        /// <param name="country">The Country.</param>
        void Insert(string customerId, string name, string fiscalNumber, string addressLine1, string addressLine2, string zipCode, string state, byte? country);

        /// <summary>
        /// Updates in the database all changes made to the CustomerEdit object.
        /// </summary>
        /// <param name="customerId">The Customer Id.</param>
        /// <param name="name">The Name.</param>
        /// <param name="fiscalNumber">The Fiscal Number.</param>
        /// <param name="addressLine1">The Address Line1.</param>
        /// <param name="addressLine2">The Address Line2.</param>
        /// <param name="zipCode">The Zip Code.</param>
        /// <param name="state">The State.</param>
        /// <param name="country">The Country.</param>
        void Update(string customerId, string name, string fiscalNumber, string addressLine1, string addressLine2, string zipCode, string state, byte? country);

        /// <summary>
        /// Deletes the CustomerEdit object from database.
        /// </summary>
        /// <param name="customerId">The Customer Id.</param>
        void Delete(string customerId);
    }
}
