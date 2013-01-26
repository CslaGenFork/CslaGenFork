using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G05_SubContinent_ReChild type
    /// </summary>
    public partial interface IG05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a G05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G05_SubContinent_ReChildDto"/> object.</returns>
        G05_SubContinent_ReChildDto Fetch(int subContinent_ID2);
    }
}
