using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D07_RegionColl type
    /// </summary>
    public partial interface ID07_RegionCollDal
    {
        /// <summary>
        /// Loads a D07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D08_RegionDto"/>.</returns>
        List<D08_RegionDto> Fetch(int parent_Country_ID);
    }
}
