using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C09_Region_Child type
    /// </summary>
    public partial interface IC09_Region_ChildDal
    {
        /// <summary>
        /// Loads a C09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C09_Region_ChildDto"/> object.</returns>
        C09_Region_ChildDto Fetch(int region_ID1);
    }
}
