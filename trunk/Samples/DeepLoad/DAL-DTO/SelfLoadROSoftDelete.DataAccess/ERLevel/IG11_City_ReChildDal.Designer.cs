using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G11_City_ReChild type
    /// </summary>
    public partial interface IG11_City_ReChildDal
    {
        /// <summary>
        /// Loads a G11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G11_City_ReChildDto"/> object.</returns>
        G11_City_ReChildDto Fetch(int city_ID2);
    }
}
