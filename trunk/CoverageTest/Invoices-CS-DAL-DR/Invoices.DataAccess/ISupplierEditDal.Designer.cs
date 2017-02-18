using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for SupplierEdit type
    /// </summary>
    public partial interface ISupplierEditDal
    {
        /// <summary>
        /// Loads a SupplierEdit object from the database.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <returns>A data reader to the SupplierEdit.</returns>
        IDataReader Fetch(int supplierId);

        /// <summary>
        /// Inserts a new SupplierEdit object in the database.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <param name="name">The Name.</param>
        /// <param name="addressLine1">The Address Line1.</param>
        /// <param name="addressLine2">The Address Line2.</param>
        /// <param name="zipCode">The Zip Code.</param>
        /// <param name="state">The State.</param>
        /// <param name="country">The Country.</param>
        void Insert(int supplierId, string name, string addressLine1, string addressLine2, string zipCode, string state, byte? country);

        /// <summary>
        /// Updates in the database all changes made to the SupplierEdit object.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <param name="name">The Name.</param>
        /// <param name="addressLine1">The Address Line1.</param>
        /// <param name="addressLine2">The Address Line2.</param>
        /// <param name="zipCode">The Zip Code.</param>
        /// <param name="state">The State.</param>
        /// <param name="country">The Country.</param>
        void Update(int supplierId, string name, string addressLine1, string addressLine2, string zipCode, string state, byte? country);
    }
}
