using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C03_SubContinentColl type
    /// </summary>
    public partial interface IC03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a C03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C04_SubContinentDto"/>.</returns>
        List<C04_SubContinentDto> Fetch(int parent_Continent_ID);
    }
}
