using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G03_SubContinentColl type
    /// </summary>
    public partial interface IG03_SubContinentCollDal
    {

        /// <summary>
        /// Loads a G03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent Continent ID.</param>
        /// <returns>A data reader to the G03_SubContinentColl.</returns>
        IDataReader Fetch(int parent_Continent_ID);
    }
}
