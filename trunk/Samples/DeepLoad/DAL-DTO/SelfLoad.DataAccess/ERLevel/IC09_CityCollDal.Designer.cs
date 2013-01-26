using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C09_CityColl type
    /// </summary>
    public partial interface IC09_CityCollDal
    {
        /// <summary>
        /// Loads a C09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C10_CityDto"/>.</returns>
        List<C10_CityDto> Fetch(int parent_Region_ID);
    }
}
