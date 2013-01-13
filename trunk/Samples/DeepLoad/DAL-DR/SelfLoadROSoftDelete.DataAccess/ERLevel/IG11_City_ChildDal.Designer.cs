using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G11_City_Child type
    /// </summary>
    public partial interface IG11_City_ChildDal
    {
        /// <summary>
        /// Loads a G11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        /// <returns>A data reader to the G11_City_Child.</returns>
        IDataReader Fetch(int city_ID1);
    }
}
