using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D07_Country_Child type
    /// </summary>
    public partial interface ID07_Country_ChildDal
    {

        /// <summary>
        /// Loads a D07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The Country ID1.</param>
        /// <returns>A data reader to the D07_Country_Child.</returns>
        IDataReader Fetch(int country_ID1);
    }
}
