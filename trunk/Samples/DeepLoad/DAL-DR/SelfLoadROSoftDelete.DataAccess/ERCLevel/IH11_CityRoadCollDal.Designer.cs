using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H11_CityRoadColl type
    /// </summary>
    public partial interface IH11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a H11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The Parent City ID.</param>
        /// <returns>A data reader to the H11_CityRoadColl.</returns>
        IDataReader Fetch(int parent_City_ID);
    }
}
