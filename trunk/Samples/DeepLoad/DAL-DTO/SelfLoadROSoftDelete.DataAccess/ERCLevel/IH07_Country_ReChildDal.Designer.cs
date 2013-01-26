using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H07_Country_ReChild type
    /// </summary>
    public partial interface IH07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a H07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="H07_Country_ReChildDto"/> object.</returns>
        H07_Country_ReChildDto Fetch(int country_ID2);
    }
}
