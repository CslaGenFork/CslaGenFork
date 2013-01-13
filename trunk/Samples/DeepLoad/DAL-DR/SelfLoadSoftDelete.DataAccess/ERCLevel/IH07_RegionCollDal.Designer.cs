using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H07_RegionColl type
    /// </summary>
    public partial interface IH07_RegionCollDal
    {
        /// <summary>
        /// Loads a H07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        /// <returns>A data reader to the H07_RegionColl.</returns>
        IDataReader Fetch(int parent_Country_ID);
    }
}
