using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_CityRoadColl type
    /// </summary>
    public partial interface IC11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a C11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C12_CityRoadDto"/>.</returns>
        List<C12_CityRoadDto> Fetch(int parent_City_ID);
    }
}
