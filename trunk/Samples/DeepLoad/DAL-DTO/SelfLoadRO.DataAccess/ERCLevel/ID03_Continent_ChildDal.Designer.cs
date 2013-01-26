using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D03_Continent_Child type
    /// </summary>
    public partial interface ID03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a D03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D03_Continent_ChildDto"/> object.</returns>
        D03_Continent_ChildDto Fetch(int continent_ID1);
    }
}
