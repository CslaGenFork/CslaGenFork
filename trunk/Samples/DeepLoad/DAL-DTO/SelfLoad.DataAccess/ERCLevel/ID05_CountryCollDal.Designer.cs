using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D05_CountryColl type
    /// </summary>
    public partial interface ID05_CountryCollDal
    {
        /// <summary>
        /// Loads a D05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D06_CountryDto"/>.</returns>
        List<D06_CountryDto> Fetch(int parent_SubContinent_ID);
    }
}
