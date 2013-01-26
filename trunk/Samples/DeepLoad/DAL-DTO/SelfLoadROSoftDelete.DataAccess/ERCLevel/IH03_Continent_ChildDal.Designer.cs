using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H03_Continent_Child type
    /// </summary>
    public partial interface IH03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H03_Continent_ChildDto"/> object.</returns>
        H03_Continent_ChildDto Fetch(int continent_ID1);
    }
}
