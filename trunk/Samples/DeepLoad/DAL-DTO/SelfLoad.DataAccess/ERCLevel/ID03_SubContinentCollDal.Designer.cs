using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D03_SubContinentColl type
    /// </summary>
    public partial interface ID03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a D03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D04_SubContinentDto"/>.</returns>
        List<D04_SubContinentDto> Fetch(int parent_Continent_ID);
    }
}
