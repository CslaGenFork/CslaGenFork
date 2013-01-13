using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G09_Region_Child type
    /// </summary>
    public partial interface IG09_Region_ChildDal
    {
        /// <summary>
        /// Loads a G09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The Region ID1.</param>
        /// <returns>A data reader to the G09_Region_Child.</returns>
        IDataReader Fetch(int region_ID1);
    }
}
