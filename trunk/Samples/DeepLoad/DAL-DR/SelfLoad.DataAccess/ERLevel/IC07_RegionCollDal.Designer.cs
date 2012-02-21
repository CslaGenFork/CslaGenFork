using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C07_RegionColl type
    /// </summary>
    public partial interface IC07_RegionCollDal
    {

        /// <summary>
        /// Loads a C07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        /// <returns>A data reader to the C07_RegionColl.</returns>
        IDataReader Fetch(int parent_Country_ID);
    }
}
