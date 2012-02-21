using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D11_CityRoadColl type
    /// </summary>
    public partial interface ID11_CityRoadCollDal
    {

        /// <summary>
        /// Loads a D11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The Parent City ID.</param>
        /// <returns>A data reader to the D11_CityRoadColl.</returns>
        IDataReader Fetch(int parent_City_ID);
    }
}
