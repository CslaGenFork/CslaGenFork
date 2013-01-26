using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H11_City_Child type
    /// </summary>
    public partial interface IH11_City_ChildDal
    {
        /// <summary>
        /// Loads a H11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H11_City_ChildDto"/> object.</returns>
        H11_City_ChildDto Fetch(int city_ID1);
    }
}
