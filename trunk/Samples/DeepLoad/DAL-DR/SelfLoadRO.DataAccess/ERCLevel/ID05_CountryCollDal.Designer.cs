using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D05_CountryColl type
    /// </summary>
    public partial interface ID05_CountryCollDal
    {
        /// <summary>
        /// Loads a D05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        /// <returns>A data reader to the D05_CountryColl.</returns>
        IDataReader Fetch(int parent_SubContinent_ID);
    }
}
