using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H03_Continent_Child type
    /// </summary>
    public partial interface IH03_Continent_ChildDal
    {

        /// <summary>
        /// Loads a H03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The Continent ID1.</param>
        /// <returns>A data reader to the H03_Continent_Child.</returns>
        IDataReader Fetch(int continent_ID1);
    }
}
