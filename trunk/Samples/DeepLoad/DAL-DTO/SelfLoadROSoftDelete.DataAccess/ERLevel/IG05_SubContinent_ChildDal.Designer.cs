using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G05_SubContinent_Child type
    /// </summary>
    public partial interface IG05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a G05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="parentSubContinent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G05_SubContinent_ChildDto"/> object.</returns>
        G05_SubContinent_ChildDto Fetch(int parentSubContinent_ID1);
    }
}
