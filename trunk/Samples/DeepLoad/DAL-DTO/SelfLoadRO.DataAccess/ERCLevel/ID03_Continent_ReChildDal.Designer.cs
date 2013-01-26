using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D03_Continent_ReChild type
    /// </summary>
    public partial interface ID03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a D03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D03_Continent_ReChildDto"/> object.</returns>
        D03_Continent_ReChildDto Fetch(int continent_ID2);
    }
}
