using System;
using System.Data;
using Csla;

namespace ParentLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B01_ContinentColl type
    /// </summary>
    public partial interface IB01_ContinentCollDal
    {

        /// <summary>
        /// Loads a B01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A data reader to the B01_ContinentColl.</returns>
        IDataReader Fetch();
    }
}
