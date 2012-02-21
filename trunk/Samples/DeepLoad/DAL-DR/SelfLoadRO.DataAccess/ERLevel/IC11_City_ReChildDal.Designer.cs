using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_City_ReChild type
    /// </summary>
    public partial interface IC11_City_ReChildDal
    {

        /// <summary>
        /// Loads a C11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The City ID2.</param>
        /// <returns>A data reader to the C11_City_ReChild.</returns>
        IDataReader Fetch(int city_ID2);
    }
}
