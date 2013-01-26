using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H09_Region_ReChild type
    /// </summary>
    public partial interface IH09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a H09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="H09_Region_ReChildDto"/> object.</returns>
        H09_Region_ReChildDto Fetch(int region_ID2);
    }
}
