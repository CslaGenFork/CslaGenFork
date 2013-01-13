using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G03_Continent_Child type
    /// </summary>
    public partial interface IG03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a G03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The Continent ID1.</param>
        /// <returns>A data reader to the G03_Continent_Child.</returns>
        IDataReader Fetch(int continent_ID1);
    }
}
