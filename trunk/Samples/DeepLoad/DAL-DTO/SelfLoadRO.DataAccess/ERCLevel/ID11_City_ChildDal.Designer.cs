using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D11_City_Child type
    /// </summary>
    public partial interface ID11_City_ChildDal
    {
        /// <summary>
        /// Loads a D11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D11_City_ChildDto"/> object.</returns>
        D11_City_ChildDto Fetch(int city_ID1);
    }
}
