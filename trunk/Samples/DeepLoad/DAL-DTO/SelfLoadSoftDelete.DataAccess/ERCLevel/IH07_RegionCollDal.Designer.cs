using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H07_RegionColl type
    /// </summary>
    public partial interface IH07_RegionCollDal
    {
        /// <summary>
        /// Loads a H07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H08_RegionDto"/>.</returns>
        List<H08_RegionDto> Fetch(int parent_Country_ID);
    }
}
