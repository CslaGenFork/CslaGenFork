using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G05_CountryColl type
    /// </summary>
    public partial interface IG05_CountryCollDal
    {
        /// <summary>
        /// Loads a G05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G06_CountryDto"/>.</returns>
        List<G06_CountryDto> Fetch(int parent_SubContinent_ID);
    }
}
