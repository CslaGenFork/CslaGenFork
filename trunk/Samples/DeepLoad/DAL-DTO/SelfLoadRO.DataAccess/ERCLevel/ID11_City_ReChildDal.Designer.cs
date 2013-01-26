using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D11_City_ReChild type
    /// </summary>
    public partial interface ID11_City_ReChildDal
    {
        /// <summary>
        /// Loads a D11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D11_City_ReChildDto"/> object.</returns>
        D11_City_ReChildDto Fetch(int city_ID2);
    }
}
