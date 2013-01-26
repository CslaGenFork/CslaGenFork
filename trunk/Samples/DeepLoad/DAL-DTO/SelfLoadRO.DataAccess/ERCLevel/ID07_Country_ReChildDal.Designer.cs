using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D07_Country_ReChild type
    /// </summary>
    public partial interface ID07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a D07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D07_Country_ReChildDto"/> object.</returns>
        D07_Country_ReChildDto Fetch(int country_ID2);
    }
}
