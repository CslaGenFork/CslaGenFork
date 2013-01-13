using System;
using System.Data;
using Csla;

namespace SelfLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C05_SubContinent_ReChild type
    /// </summary>
    public partial interface IC05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        /// <returns>A data reader to the C05_SubContinent_ReChild.</returns>
        IDataReader Fetch(int subContinent_ID2);
    }
}
