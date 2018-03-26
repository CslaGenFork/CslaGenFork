using System;
using System.Collections.Generic;
using Csla;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// DAL Interface for OutgoingRegister type
    /// </summary>
    public partial interface IOutgoingRegisterDal
    {
        /// <summary>
        /// Loads a OutgoingRegister object from the database.
        /// </summary>
        /// <param name="registerId">The fetch criteria.</param>
        /// <returns>A <see cref="OutgoingRegisterDto"/> object.</returns>
        OutgoingRegisterDto Fetch(int registerId);

        /// <summary>
        /// Inserts a new OutgoingRegister object in the database.
        /// </summary>
        /// <param name="outgoingRegister">The Outgoing Register DTO.</param>
        /// <returns>The new <see cref="OutgoingRegisterDto"/>.</returns>
        OutgoingRegisterDto Insert(OutgoingRegisterDto outgoingRegister);

        /// <summary>
        /// Updates in the database all changes made to the OutgoingRegister object.
        /// </summary>
        /// <param name="outgoingRegister">The Outgoing Register DTO.</param>
        /// <returns>The updated <see cref="OutgoingRegisterDto"/>.</returns>
        OutgoingRegisterDto Update(OutgoingRegisterDto outgoingRegister);
    }
}
