using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H05_SubContinent_Child type
    /// </summary>
    public partial interface IH05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a H05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H05_SubContinent_ChildDto"/> object.</returns>
        H05_SubContinent_ChildDto Fetch(int subContinent_ID1);
    }
}
