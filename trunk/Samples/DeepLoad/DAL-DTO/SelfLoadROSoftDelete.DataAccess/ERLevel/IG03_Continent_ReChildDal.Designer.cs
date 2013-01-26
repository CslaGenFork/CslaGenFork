using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G03_Continent_ReChild type
    /// </summary>
    public partial interface IG03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a G03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G03_Continent_ReChildDto"/> object.</returns>
        G03_Continent_ReChildDto Fetch(int continent_ID2);
    }
}
