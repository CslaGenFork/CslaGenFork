using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G02_Continent type
    /// </summary>
    public partial interface IG02_ContinentDal
    {
        /// <summary>
        /// Loads a G02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A <see cref="G02_ContinentDto"/> object.</returns>
        G02_ContinentDto Fetch(int continent_ID);
    }
}
