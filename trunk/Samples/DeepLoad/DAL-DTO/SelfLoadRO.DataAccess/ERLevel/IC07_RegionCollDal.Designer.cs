using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C07_RegionColl type
    /// </summary>
    public partial interface IC07_RegionCollDal
    {
        /// <summary>
        /// Loads a C07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C08_RegionDto"/>.</returns>
        List<C08_RegionDto> Fetch(int parent_Country_ID);
    }
}
