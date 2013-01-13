using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H05_CountryColl type
    /// </summary>
    public partial interface IH05_CountryCollDal
    {
        /// <summary>
        /// Loads a H05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        /// <returns>A data reader to the H05_CountryColl.</returns>
        IDataReader Fetch(int parent_SubContinent_ID);
    }
}
