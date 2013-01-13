using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G02_Continent type
    /// </summary>
    public partial interface IG02_ContinentDal
    {
        /// <summary>
        /// Loads a G02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <returns>A data reader to the G02_Continent.</returns>
        IDataReader Fetch(int continent_ID);
    }
}
