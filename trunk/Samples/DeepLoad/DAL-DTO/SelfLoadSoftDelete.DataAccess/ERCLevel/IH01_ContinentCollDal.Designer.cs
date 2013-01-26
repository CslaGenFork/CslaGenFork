using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H01_ContinentColl type
    /// </summary>
    public partial interface IH01_ContinentCollDal
    {
        /// <summary>
        /// Loads a H01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="H02_ContinentDto"/>.</returns>
        List<H02_ContinentDto> Fetch();
    }
}
