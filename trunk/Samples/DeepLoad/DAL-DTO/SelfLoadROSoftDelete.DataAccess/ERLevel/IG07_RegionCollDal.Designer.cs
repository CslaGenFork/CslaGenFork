using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G07_RegionColl type
    /// </summary>
    public partial interface IG07_RegionCollDal
    {
        /// <summary>
        /// Loads a G07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G08_RegionDto"/>.</returns>
        List<G08_RegionDto> Fetch(int parent_Country_ID);
    }
}
