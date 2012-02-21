using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D07_Country_ReChild type
    /// </summary>
    public partial interface ID07_Country_ReChildDal
    {

        /// <summary>
        /// Loads a D07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The Country ID2.</param>
        /// <returns>A data reader to the D07_Country_ReChild.</returns>
        IDataReader Fetch(int country_ID2);
    }
}
