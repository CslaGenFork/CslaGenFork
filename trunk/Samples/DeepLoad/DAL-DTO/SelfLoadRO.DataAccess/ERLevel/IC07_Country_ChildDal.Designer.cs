using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C07_Country_Child type
    /// </summary>
    public partial interface IC07_Country_ChildDal
    {
        /// <summary>
        /// Loads a C07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C07_Country_ChildDto"/> object.</returns>
        C07_Country_ChildDto Fetch(int country_ID1);
    }
}
