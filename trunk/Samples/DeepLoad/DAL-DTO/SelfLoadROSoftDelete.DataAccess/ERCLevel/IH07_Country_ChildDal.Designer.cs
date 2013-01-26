using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H07_Country_Child type
    /// </summary>
    public partial interface IH07_Country_ChildDal
    {
        /// <summary>
        /// Loads a H07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H07_Country_ChildDto"/> object.</returns>
        H07_Country_ChildDto Fetch(int country_ID1);
    }
}
