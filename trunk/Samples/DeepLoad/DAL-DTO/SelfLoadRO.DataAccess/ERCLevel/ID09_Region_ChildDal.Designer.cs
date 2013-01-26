using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D09_Region_Child type
    /// </summary>
    public partial interface ID09_Region_ChildDal
    {
        /// <summary>
        /// Loads a D09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D09_Region_ChildDto"/> object.</returns>
        D09_Region_ChildDto Fetch(int region_ID1);
    }
}
