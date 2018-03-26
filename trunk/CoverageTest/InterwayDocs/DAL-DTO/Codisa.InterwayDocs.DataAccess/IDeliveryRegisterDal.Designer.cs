using System;
using System.Collections.Generic;
using Csla;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// DAL Interface for DeliveryRegister type
    /// </summary>
    public partial interface IDeliveryRegisterDal
    {
        /// <summary>
        /// Loads a DeliveryRegister object from the database.
        /// </summary>
        /// <param name="registerId">The fetch criteria.</param>
        /// <returns>A <see cref="DeliveryRegisterDto"/> object.</returns>
        DeliveryRegisterDto Fetch(int registerId);

        /// <summary>
        /// Inserts a new DeliveryRegister object in the database.
        /// </summary>
        /// <param name="deliveryRegister">The Delivery Register DTO.</param>
        /// <returns>The new <see cref="DeliveryRegisterDto"/>.</returns>
        DeliveryRegisterDto Insert(DeliveryRegisterDto deliveryRegister);

        /// <summary>
        /// Updates in the database all changes made to the DeliveryRegister object.
        /// </summary>
        /// <param name="deliveryRegister">The Delivery Register DTO.</param>
        /// <returns>The updated <see cref="DeliveryRegisterDto"/>.</returns>
        DeliveryRegisterDto Update(DeliveryRegisterDto deliveryRegister);
    }
}
