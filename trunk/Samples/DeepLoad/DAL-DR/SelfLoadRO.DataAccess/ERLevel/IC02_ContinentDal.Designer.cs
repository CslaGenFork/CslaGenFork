using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C02_Continent type
    /// </summary>
    public partial interface IC02_ContinentDal
    {
        /// <summary>
        /// Loads a C02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <returns>A data reader to the C02_Continent.</returns>
        IDataReader Fetch(int continent_ID);
    }
}
