using System;
using System.Collections.Generic;
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
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A <see cref="C02_ContinentDto"/> object.</returns>
        C02_ContinentDto Fetch(int continent_ID);
    }
}
