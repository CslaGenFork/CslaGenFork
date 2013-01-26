using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H11_CityRoadColl type
    /// </summary>
    public partial interface IH11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a H11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H12_CityRoadDto"/>.</returns>
        List<H12_CityRoadDto> Fetch(int parent_City_ID);
    }
}
