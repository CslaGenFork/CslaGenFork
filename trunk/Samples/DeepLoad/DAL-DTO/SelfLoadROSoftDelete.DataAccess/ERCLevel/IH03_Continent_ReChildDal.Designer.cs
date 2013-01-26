using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H03_Continent_ReChild type
    /// </summary>
    public partial interface IH03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="H03_Continent_ReChildDto"/> object.</returns>
        H03_Continent_ReChildDto Fetch(int continent_ID2);
    }
}
