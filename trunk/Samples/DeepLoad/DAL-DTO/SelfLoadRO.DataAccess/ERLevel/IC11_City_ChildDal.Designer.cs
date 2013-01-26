using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_City_Child type
    /// </summary>
    public partial interface IC11_City_ChildDal
    {
        /// <summary>
        /// Loads a C11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C11_City_ChildDto"/> object.</returns>
        C11_City_ChildDto Fetch(int city_ID1);
    }
}
