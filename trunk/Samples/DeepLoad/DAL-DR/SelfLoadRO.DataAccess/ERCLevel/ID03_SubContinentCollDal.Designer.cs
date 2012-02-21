using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D03_SubContinentColl type
    /// </summary>
    public partial interface ID03_SubContinentCollDal
    {

        /// <summary>
        /// Loads a D03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent Continent ID.</param>
        /// <returns>A data reader to the D03_SubContinentColl.</returns>
        IDataReader Fetch(int parent_Continent_ID);
    }
}
