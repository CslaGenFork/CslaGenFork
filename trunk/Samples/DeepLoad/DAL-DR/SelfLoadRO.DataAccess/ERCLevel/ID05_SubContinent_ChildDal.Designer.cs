using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D05_SubContinent_Child type
    /// </summary>
    public partial interface ID05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a D05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        /// <returns>A data reader to the D05_SubContinent_Child.</returns>
        IDataReader Fetch(int subContinent_ID1);
    }
}
