using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C03_Continent_ReChild type
    /// </summary>
    public partial interface IC03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a C03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The Continent ID2.</param>
        /// <returns>A data reader to the C03_Continent_ReChild.</returns>
        IDataReader Fetch(int continent_ID2);
    }
}
