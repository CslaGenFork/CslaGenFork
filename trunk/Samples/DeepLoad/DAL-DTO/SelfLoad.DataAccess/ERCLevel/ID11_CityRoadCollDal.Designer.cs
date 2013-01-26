using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D11_CityRoadColl type
    /// </summary>
    public partial interface ID11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a D11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D12_CityRoadDto"/>.</returns>
        List<D12_CityRoadDto> Fetch(int parent_City_ID);
    }
}
