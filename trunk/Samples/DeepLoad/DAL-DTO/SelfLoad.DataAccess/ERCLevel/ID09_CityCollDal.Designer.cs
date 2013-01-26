using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D09_CityColl type
    /// </summary>
    public partial interface ID09_CityCollDal
    {
        /// <summary>
        /// Loads a D09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D10_CityDto"/>.</returns>
        List<D10_CityDto> Fetch(int parent_Region_ID);
    }
}
