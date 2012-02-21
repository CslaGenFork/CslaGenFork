using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D03_Continent_Child type
    /// </summary>
    public partial interface ID03_Continent_ChildDal
    {

        /// <summary>
        /// Loads a D03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The Continent ID1.</param>
        /// <returns>A data reader to the D03_Continent_Child.</returns>
        IDataReader Fetch(int continent_ID1);
    }
}
