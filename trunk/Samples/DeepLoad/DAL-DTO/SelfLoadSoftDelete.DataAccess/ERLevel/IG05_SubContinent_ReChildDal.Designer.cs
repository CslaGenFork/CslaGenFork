using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G05_SubContinent_ReChild type
    /// </summary>
    public partial interface IG05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a G05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G05_SubContinent_ReChildDto"/> object.</returns>
        G05_SubContinent_ReChildDto Fetch(int subContinent_ID2);

        /// <summary>
        /// Inserts a new G05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="g05_SubContinent_ReChild">The G05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="G05_SubContinent_ReChildDto"/>.</returns>
        G05_SubContinent_ReChildDto Insert(G05_SubContinent_ReChildDto g05_SubContinent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the G05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="g05_SubContinent_ReChild">The G05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="G05_SubContinent_ReChildDto"/>.</returns>
        G05_SubContinent_ReChildDto Update(G05_SubContinent_ReChildDto g05_SubContinent_ReChild);

        /// <summary>
        /// Deletes the G05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        void Delete(int subContinent_ID2);
    }
}
