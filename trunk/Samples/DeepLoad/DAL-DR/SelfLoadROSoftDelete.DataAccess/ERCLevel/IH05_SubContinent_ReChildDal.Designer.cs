using System;
using System.Data;
using Csla;

namespace SelfLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H05_SubContinent_ReChild type
    /// </summary>
    public partial interface IH05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a H05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        /// <returns>A data reader to the H05_SubContinent_ReChild.</returns>
        IDataReader Fetch(int subContinent_ID2);
    }
}
