using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D07_Country_Child type
    /// </summary>
    public partial interface ID07_Country_ChildDal
    {
        /// <summary>
        /// Loads a D07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D07_Country_ChildDto"/> object.</returns>
        D07_Country_ChildDto Fetch(int country_ID1);
    }
}
