using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F01_ContinentColl type
    /// </summary>
    public partial interface IF01_ContinentCollDal
    {
        /// <summary>
        /// Loads a F01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A data reader to the F01_ContinentColl.</returns>
        IDataReader Fetch();
    }
}
