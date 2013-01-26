using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D09_Region_ReChild type
    /// </summary>
    public partial interface ID09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a D09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D09_Region_ReChildDto"/> object.</returns>
        D09_Region_ReChildDto Fetch(int region_ID2);
    }
}
