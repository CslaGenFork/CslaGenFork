using System;
using System.Data;
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
        /// <returns>A data reader to the H01_ContinentColl.</returns>
        IDataReader Fetch();
    }
}
