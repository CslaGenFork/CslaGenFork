using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_City_ReChild type
    /// </summary>
    public partial interface IC11_City_ReChildDal
    {
        /// <summary>
        /// Loads a C11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C11_City_ReChildDto"/> object.</returns>
        C11_City_ReChildDto Fetch(int city_ID2);
    }
}
