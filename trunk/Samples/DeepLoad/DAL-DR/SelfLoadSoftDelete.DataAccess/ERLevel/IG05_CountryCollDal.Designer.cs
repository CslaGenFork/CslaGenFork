using System;
using System.Data;
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
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        /// <returns>A data reader to the G05_CountryColl.</returns>
        IDataReader Fetch(int parent_SubContinent_ID);
    }
}
