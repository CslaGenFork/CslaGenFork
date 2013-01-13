using System;
using System.Data;
using Csla;

namespace ParentLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A02_Continent type
    /// </summary>
    public partial interface IA02_ContinentDal
    {
        /// <summary>
        /// Loads a A02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <returns>A data reader to the A02_Continent.</returns>
        IDataReader Fetch(int continent_ID);
    }
}
