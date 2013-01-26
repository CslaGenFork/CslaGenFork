using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D05_SubContinent_ReChild type
    /// </summary>
    public partial interface ID05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a D05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D05_SubContinent_ReChildDto"/> object.</returns>
        D05_SubContinent_ReChildDto Fetch(int subContinent_ID2);

        /// <summary>
        /// Inserts a new D05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="d05_SubContinent_ReChild">The D05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="D05_SubContinent_ReChildDto"/>.</returns>
        D05_SubContinent_ReChildDto Insert(D05_SubContinent_ReChildDto d05_SubContinent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the D05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="d05_SubContinent_ReChild">The D05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="D05_SubContinent_ReChildDto"/>.</returns>
        D05_SubContinent_ReChildDto Update(D05_SubContinent_ReChildDto d05_SubContinent_ReChild);

        /// <summary>
        /// Deletes the D05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
