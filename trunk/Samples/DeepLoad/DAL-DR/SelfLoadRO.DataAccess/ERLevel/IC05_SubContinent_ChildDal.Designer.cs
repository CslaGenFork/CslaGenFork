using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C05_SubContinent_Child type
    /// </summary>
    public partial interface IC05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="parentSubContinent_ID1">The Parent Sub Continent ID1.</param>
        /// <returns>A data reader to the C05_SubContinent_Child.</returns>
        IDataReader Fetch(int parentSubContinent_ID1);
    }
}
