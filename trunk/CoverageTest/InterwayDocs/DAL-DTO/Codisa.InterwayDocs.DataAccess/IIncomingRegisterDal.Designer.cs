using System;
using System.Collections.Generic;
using Csla;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// DAL Interface for IncomingRegister type
    /// </summary>
    public partial interface IIncomingRegisterDal
    {
        /// <summary>
        /// Loads a IncomingRegister object from the database.
        /// </summary>
        /// <param name="registerId">The fetch criteria.</param>
        /// <returns>A <see cref="IncomingRegisterDto"/> object.</returns>
        IncomingRegisterDto Fetch(int registerId);

        /// <summary>
        /// Inserts a new IncomingRegister object in the database.
        /// </summary>
        /// <param name="incomingRegister">The Incoming Register DTO.</param>
        /// <returns>The new <see cref="IncomingRegisterDto"/>.</returns>
        IncomingRegisterDto Insert(IncomingRegisterDto incomingRegister);

        /// <summary>
        /// Updates in the database all changes made to the IncomingRegister object.
        /// </summary>
        /// <param name="incomingRegister">The Incoming Register DTO.</param>
        /// <returns>The updated <see cref="IncomingRegisterDto"/>.</returns>
        IncomingRegisterDto Update(IncomingRegisterDto incomingRegister);
    }
}
