using System;
using System.Collections.Generic;
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
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C03_Continent_ChildDto"/> object.</returns>
        C03_Continent_ChildDto Fetch(int continent_ID1);
    }
}
