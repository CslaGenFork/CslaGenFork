using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G03_Continent_ReChild type
    /// </summary>
    public partial interface IG03_Continent_ReChildDal
    {

        /// <summary>
        /// Loads a G03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The Continent ID2.</param>
        /// <returns>A data reader to the G03_Continent_ReChild.</returns>
        IDataReader Fetch(int continent_ID2);
    }
}
