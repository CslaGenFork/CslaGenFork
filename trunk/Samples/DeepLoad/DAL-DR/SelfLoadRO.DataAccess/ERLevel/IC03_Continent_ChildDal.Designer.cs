using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C03_Continent_Child type
    /// </summary>
    public partial interface IC03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a C03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The Continent ID1.</param>
        /// <returns>A data reader to the C03_Continent_Child.</returns>
        IDataReader Fetch(int continent_ID1);
    }
}
