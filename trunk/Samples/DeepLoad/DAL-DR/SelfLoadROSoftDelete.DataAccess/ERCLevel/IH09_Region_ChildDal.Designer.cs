using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H09_Region_Child type
    /// </summary>
    public partial interface IH09_Region_ChildDal
    {

        /// <summary>
        /// Loads a H09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The Region ID1.</param>
        /// <returns>A data reader to the H09_Region_Child.</returns>
        IDataReader Fetch(int region_ID1);
    }
}
