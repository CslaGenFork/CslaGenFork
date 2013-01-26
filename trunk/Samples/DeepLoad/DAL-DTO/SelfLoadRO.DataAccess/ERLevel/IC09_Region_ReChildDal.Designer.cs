using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C09_Region_ReChild type
    /// </summary>
    public partial interface IC09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a C09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C09_Region_ReChildDto"/> object.</returns>
        C09_Region_ReChildDto Fetch(int region_ID2);
    }
}
