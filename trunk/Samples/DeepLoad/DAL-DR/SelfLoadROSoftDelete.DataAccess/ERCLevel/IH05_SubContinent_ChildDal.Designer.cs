using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H05_SubContinent_Child type
    /// </summary>
    public partial interface IH05_SubContinent_ChildDal
    {

        /// <summary>
        /// Loads a H05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        /// <returns>A data reader to the H05_SubContinent_Child.</returns>
        IDataReader Fetch(int subContinent_ID1);
    }
}
