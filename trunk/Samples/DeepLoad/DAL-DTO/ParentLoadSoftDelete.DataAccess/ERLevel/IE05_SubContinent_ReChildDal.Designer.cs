using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E05_SubContinent_ReChild type
    /// </summary>
    public partial interface IE05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Inserts a new E05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="e05_SubContinent_ReChild">The E05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="E05_SubContinent_ReChildDto"/>.</returns>
        E05_SubContinent_ReChildDto Insert(E05_SubContinent_ReChildDto e05_SubContinent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the E05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="e05_SubContinent_ReChild">The E05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="E05_SubContinent_ReChildDto"/>.</returns>
        E05_SubContinent_ReChildDto Update(E05_SubContinent_ReChildDto e05_SubContinent_ReChild);

        /// <summary>
        /// Deletes the E05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        void Delete(int subContinent_ID2);
    }
}
