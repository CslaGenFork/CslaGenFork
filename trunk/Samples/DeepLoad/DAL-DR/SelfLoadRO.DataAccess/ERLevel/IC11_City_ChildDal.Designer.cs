using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_City_Child type
    /// </summary>
    public partial interface IC11_City_ChildDal
    {
        /// <summary>
        /// Loads a C11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        /// <returns>A data reader to the C11_City_Child.</returns>
        IDataReader Fetch(int city_ID1);
    }
}
