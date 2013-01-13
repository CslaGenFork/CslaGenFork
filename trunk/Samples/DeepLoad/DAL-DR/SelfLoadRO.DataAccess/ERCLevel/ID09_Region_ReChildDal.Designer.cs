using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D09_Region_ReChild type
    /// </summary>
    public partial interface ID09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a D09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The Region ID2.</param>
        /// <returns>A data reader to the D09_Region_ReChild.</returns>
        IDataReader Fetch(int region_ID2);
    }
}
