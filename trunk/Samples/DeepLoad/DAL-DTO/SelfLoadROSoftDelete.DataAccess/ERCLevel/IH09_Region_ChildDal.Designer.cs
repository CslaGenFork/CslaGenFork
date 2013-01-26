using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H09_Region_Child type
    /// </summary>
    public partial interface IH09_Region_ChildDal
    {
        /// <summary>
        /// Loads a H09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H09_Region_ChildDto"/> object.</returns>
        H09_Region_ChildDto Fetch(int region_ID1);
    }
}
