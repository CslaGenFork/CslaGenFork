using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G11_CityRoadColl type
    /// </summary>
    public partial interface IG11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a G11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G12_CityRoadDto"/>.</returns>
        List<G12_CityRoadDto> Fetch(int parent_City_ID);
    }
}
