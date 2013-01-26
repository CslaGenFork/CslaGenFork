using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G07_Country_ReChild type
    /// </summary>
    public partial interface IG07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a G07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G07_Country_ReChildDto"/> object.</returns>
        G07_Country_ReChildDto Fetch(int country_ID2);
    }
}
