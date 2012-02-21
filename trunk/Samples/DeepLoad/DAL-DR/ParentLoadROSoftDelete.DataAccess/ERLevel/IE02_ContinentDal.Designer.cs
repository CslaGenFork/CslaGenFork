using System;
using System.Data;
using Csla;

namespace ParentLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E02_Continent type
    /// </summary>
    public partial interface IE02_ContinentDal
    {

        /// <summary>
        /// Loads a E02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <returns>A data reader to the E02_Continent.</returns>
        IDataReader Fetch(int continent_ID);
    }
}
