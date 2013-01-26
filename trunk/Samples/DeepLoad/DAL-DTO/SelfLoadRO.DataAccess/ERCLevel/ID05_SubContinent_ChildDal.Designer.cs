using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D05_SubContinent_Child type
    /// </summary>
    public partial interface ID05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a D05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D05_SubContinent_ChildDto"/> object.</returns>
        D05_SubContinent_ChildDto Fetch(int subContinent_ID1);
    }
}
