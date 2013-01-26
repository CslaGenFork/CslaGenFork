using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C07_Country_ReChild type
    /// </summary>
    public partial interface IC07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a C07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C07_Country_ReChildDto"/> object.</returns>
        C07_Country_ReChildDto Fetch(int country_ID2);
    }
}
