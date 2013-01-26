using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G03_SubContinentColl type
    /// </summary>
    public partial interface IG03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a G03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G04_SubContinentDto"/>.</returns>
        List<G04_SubContinentDto> Fetch(int parent_Continent_ID);
    }
}
