using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D05_SubContinent_ReChild type
    /// </summary>
    public partial interface ID05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a D05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D05_SubContinent_ReChildDto"/> object.</returns>
        D05_SubContinent_ReChildDto Fetch(int subContinent_ID2);
    }
}
