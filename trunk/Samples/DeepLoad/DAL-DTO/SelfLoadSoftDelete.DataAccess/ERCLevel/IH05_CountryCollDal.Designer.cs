using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H05_CountryColl type
    /// </summary>
    public partial interface IH05_CountryCollDal
    {
        /// <summary>
        /// Loads a H05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H06_CountryDto"/>.</returns>
        List<H06_CountryDto> Fetch(int parent_SubContinent_ID);
    }
}
