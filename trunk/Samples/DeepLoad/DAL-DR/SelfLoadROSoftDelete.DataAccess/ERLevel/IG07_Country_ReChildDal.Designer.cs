using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G07_Country_ReChild type
    /// </summary>
    public partial interface IG07_Country_ReChildDal
    {

        /// <summary>
        /// Loads a G07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The Country ID2.</param>
        /// <returns>A data reader to the G07_Country_ReChild.</returns>
        IDataReader Fetch(int country_ID2);
    }
}
