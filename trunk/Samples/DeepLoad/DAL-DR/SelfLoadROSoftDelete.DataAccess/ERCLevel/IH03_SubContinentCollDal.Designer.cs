using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H03_SubContinentColl type
    /// </summary>
    public partial interface IH03_SubContinentCollDal
    {

        /// <summary>
        /// Loads a H03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent Continent ID.</param>
        /// <returns>A data reader to the H03_SubContinentColl.</returns>
        IDataReader Fetch(int parent_Continent_ID);
    }
}
