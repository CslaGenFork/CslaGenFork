using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G07_Country_Child type
    /// </summary>
    public partial interface IG07_Country_ChildDal
    {
        /// <summary>
        /// Loads a G07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G07_Country_ChildDto"/> object.</returns>
        G07_Country_ChildDto Fetch(int country_ID1);
    }
}
