using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G11_CityRoadColl type
    /// </summary>
    public partial interface IG11_CityRoadCollDal
    {

        /// <summary>
        /// Loads a G11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The Parent City ID.</param>
        /// <returns>A data reader to the G11_CityRoadColl.</returns>
        IDataReader Fetch(int parent_City_ID);
    }
}
