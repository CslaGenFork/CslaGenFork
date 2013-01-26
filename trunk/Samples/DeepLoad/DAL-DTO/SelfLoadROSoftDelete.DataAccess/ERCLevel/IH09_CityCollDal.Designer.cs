using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H09_CityColl type
    /// </summary>
    public partial interface IH09_CityCollDal
    {
        /// <summary>
        /// Loads a H09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H10_CityDto"/>.</returns>
        List<H10_CityDto> Fetch(int parent_Region_ID);
    }
}
