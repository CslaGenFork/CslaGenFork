using System;
using System.Data;
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
        /// <returns>A data reader to the D01_ContinentColl.</returns>
        IDataReader Fetch();
    }
}
