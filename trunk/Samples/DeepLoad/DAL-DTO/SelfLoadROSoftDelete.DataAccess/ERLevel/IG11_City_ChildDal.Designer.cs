using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G11_City_Child type
    /// </summary>
    public partial interface IG11_City_ChildDal
    {
        /// <summary>
        /// Loads a G11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G11_City_ChildDto"/> object.</returns>
        G11_City_ChildDto Fetch(int city_ID1);
    }
}
