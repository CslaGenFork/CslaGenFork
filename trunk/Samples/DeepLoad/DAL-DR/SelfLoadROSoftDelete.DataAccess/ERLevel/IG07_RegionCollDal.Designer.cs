using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G07_RegionColl type
    /// </summary>
    public partial interface IG07_RegionCollDal
    {

        /// <summary>
        /// Loads a G07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        /// <returns>A data reader to the G07_RegionColl.</returns>
        IDataReader Fetch(int parent_Country_ID);
    }
}
