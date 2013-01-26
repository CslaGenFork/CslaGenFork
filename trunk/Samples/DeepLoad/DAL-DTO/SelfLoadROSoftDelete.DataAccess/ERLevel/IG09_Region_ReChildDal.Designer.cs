using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G09_Region_ReChild type
    /// </summary>
    public partial interface IG09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a G09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G09_Region_ReChildDto"/> object.</returns>
        G09_Region_ReChildDto Fetch(int region_ID2);
    }
}
