using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C05_CountryColl type
    /// </summary>
    public partial interface IC05_CountryCollDal
    {
        /// <summary>
        /// Loads a C05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C06_CountryDto"/>.</returns>
        List<C06_CountryDto> Fetch(int parent_SubContinent_ID);
    }
}
