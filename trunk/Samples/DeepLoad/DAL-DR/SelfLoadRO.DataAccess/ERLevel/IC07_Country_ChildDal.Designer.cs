using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C07_Country_Child type
    /// </summary>
    public partial interface IC07_Country_ChildDal
    {
        /// <summary>
        /// Loads a C07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The Country ID1.</param>
        /// <returns>A data reader to the C07_Country_Child.</returns>
        IDataReader Fetch(int country_ID1);
    }
}
