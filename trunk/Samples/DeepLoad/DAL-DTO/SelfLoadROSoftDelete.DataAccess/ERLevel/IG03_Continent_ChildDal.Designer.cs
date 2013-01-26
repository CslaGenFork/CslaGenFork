using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G03_Continent_Child type
    /// </summary>
    public partial interface IG03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a G03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G03_Continent_ChildDto"/> object.</returns>
        G03_Continent_ChildDto Fetch(int continent_ID1);
    }
}
