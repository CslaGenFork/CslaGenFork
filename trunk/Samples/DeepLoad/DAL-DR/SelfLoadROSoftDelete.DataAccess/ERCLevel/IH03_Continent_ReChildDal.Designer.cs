using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H03_Continent_ReChild type
    /// </summary>
    public partial interface IH03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The Continent ID2.</param>
        /// <returns>A data reader to the H03_Continent_ReChild.</returns>
        IDataReader Fetch(int continent_ID2);
    }
}
