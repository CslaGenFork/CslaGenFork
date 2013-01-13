using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H07_Country_Child type
    /// </summary>
    public partial interface IH07_Country_ChildDal
    {
        /// <summary>
        /// Loads a H07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The Country ID1.</param>
        /// <returns>A data reader to the H07_Country_Child.</returns>
        IDataReader Fetch(int country_ID1);
    }
}
