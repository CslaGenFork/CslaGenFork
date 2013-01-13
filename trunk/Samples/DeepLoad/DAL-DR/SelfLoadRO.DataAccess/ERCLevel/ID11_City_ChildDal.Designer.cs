using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D11_City_Child type
    /// </summary>
    public partial interface ID11_City_ChildDal
    {
        /// <summary>
        /// Loads a D11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        /// <returns>A data reader to the D11_City_Child.</returns>
        IDataReader Fetch(int city_ID1);
    }
}
