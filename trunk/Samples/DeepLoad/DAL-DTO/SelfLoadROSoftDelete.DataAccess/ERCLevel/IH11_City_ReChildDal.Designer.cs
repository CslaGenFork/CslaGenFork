using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H11_City_ReChild type
    /// </summary>
    public partial interface IH11_City_ReChildDal
    {
        /// <summary>
        /// Loads a H11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="H11_City_ReChildDto"/> object.</returns>
        H11_City_ReChildDto Fetch(int city_ID2);
    }
}
