using System;
using System.Data;
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
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        /// <returns>A data reader to the C05_CountryColl.</returns>
        IDataReader Fetch(int parent_SubContinent_ID);
    }
}
