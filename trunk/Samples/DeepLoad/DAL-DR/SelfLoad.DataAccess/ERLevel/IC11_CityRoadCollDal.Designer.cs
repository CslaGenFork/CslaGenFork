using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_CityRoadColl type
    /// </summary>
    public partial interface IC11_CityRoadCollDal
    {

        /// <summary>
        /// Loads a C11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The Parent City ID.</param>
        /// <returns>A data reader to the C11_CityRoadColl.</returns>
        IDataReader Fetch(int parent_City_ID);
    }
}
