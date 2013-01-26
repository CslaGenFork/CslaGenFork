using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C03_Continent_ReChild type
    /// </summary>
    public partial interface IC03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a C03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C03_Continent_ReChildDto"/> object.</returns>
        C03_Continent_ReChildDto Fetch(int continent_ID2);
    }
}
