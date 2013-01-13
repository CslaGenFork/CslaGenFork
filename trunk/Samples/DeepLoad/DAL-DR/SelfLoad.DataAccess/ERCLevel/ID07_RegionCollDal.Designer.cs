using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D07_RegionColl type
    /// </summary>
    public partial interface ID07_RegionCollDal
    {
        /// <summary>
        /// Loads a D07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        /// <returns>A data reader to the D07_RegionColl.</returns>
        IDataReader Fetch(int parent_Country_ID);
    }
}
