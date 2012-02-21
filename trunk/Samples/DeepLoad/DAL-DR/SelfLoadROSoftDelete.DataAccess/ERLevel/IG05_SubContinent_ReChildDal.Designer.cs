using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G05_SubContinent_ReChild type
    /// </summary>
    public partial interface IG05_SubContinent_ReChildDal
    {

        /// <summary>
        /// Loads a G05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        /// <returns>A data reader to the G05_SubContinent_ReChild.</returns>
        IDataReader Fetch(int subContinent_ID2);
    }
}
