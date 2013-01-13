using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H11_City_ReChild type
    /// </summary>
    public partial interface IH11_City_ReChildDal
    {
        /// <summary>
        /// Loads a H11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The City ID2.</param>
        /// <returns>A data reader to the H11_City_ReChild.</returns>
        IDataReader Fetch(int city_ID2);
    }
}
