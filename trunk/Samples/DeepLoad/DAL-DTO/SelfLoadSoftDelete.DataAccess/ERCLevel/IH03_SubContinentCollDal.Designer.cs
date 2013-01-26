using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H03_SubContinentColl type
    /// </summary>
    public partial interface IH03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a H03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H04_SubContinentDto"/>.</returns>
        List<H04_SubContinentDto> Fetch(int parent_Continent_ID);
    }
}
