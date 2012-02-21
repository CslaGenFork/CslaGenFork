using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G07_Country_Child type
    /// </summary>
    public partial interface IG07_Country_ChildDal
    {

        /// <summary>
        /// Loads a G07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The Country ID1.</param>
        /// <returns>A data reader to the G07_Country_Child.</returns>
        IDataReader Fetch(int country_ID1);
    }
}
