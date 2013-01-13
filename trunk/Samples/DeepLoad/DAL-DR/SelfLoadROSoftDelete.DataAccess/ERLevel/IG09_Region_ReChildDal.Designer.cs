using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G09_Region_ReChild type
    /// </summary>
    public partial interface IG09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a G09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The Region ID2.</param>
        /// <returns>A data reader to the G09_Region_ReChild.</returns>
        IDataReader Fetch(int region_ID2);
    }
}
