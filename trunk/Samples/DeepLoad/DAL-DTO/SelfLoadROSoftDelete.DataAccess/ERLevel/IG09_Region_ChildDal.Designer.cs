using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G09_Region_Child type
    /// </summary>
    public partial interface IG09_Region_ChildDal
    {
        /// <summary>
        /// Loads a G09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G09_Region_ChildDto"/> object.</returns>
        G09_Region_ChildDto Fetch(int region_ID1);
    }
}
