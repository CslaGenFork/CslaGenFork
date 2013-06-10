using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F05_SubContinent_ReChild type
    /// </summary>
    public partial interface IF05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Inserts a new F05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="f05_SubContinent_ReChild">The F05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="F05_SubContinent_ReChildDto"/>.</returns>
        F05_SubContinent_ReChildDto Insert(F05_SubContinent_ReChildDto f05_SubContinent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the F05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="f05_SubContinent_ReChild">The F05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="F05_SubContinent_ReChildDto"/>.</returns>
        F05_SubContinent_ReChildDto Update(F05_SubContinent_ReChildDto f05_SubContinent_ReChild);

        /// <summary>
        /// Deletes the F05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        void Delete(int subContinent_ID2);
    }
}
