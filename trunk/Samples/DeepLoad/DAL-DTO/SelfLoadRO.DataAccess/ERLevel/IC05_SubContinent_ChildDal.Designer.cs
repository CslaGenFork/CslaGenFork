using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C05_SubContinent_Child type
    /// </summary>
    public partial interface IC05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C05_SubContinent_ChildDto"/> object.</returns>
        C05_SubContinent_ChildDto Fetch(int subContinent_ID1);
    }
}
