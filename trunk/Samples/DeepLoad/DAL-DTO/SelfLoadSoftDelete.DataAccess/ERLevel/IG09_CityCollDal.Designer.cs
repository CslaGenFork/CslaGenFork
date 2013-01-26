using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G09_CityColl type
    /// </summary>
    public partial interface IG09_CityCollDal
    {
        /// <summary>
        /// Loads a G09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G10_CityDto"/>.</returns>
        List<G10_CityDto> Fetch(int parent_Region_ID);
    }
}
