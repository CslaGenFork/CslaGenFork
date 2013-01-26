using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D01_ContinentColl type
    /// </summary>
    public partial interface ID01_ContinentCollDal
    {
        /// <summary>
        /// Loads a D01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="D02_ContinentDto"/>.</returns>
        List<D02_ContinentDto> Fetch();
    }
}
