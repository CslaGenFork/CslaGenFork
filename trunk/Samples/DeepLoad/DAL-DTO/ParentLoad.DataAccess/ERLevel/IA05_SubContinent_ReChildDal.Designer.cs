using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A05_SubContinent_ReChild type
    /// </summary>
    public partial interface IA05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Inserts a new A05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="a05_SubContinent_ReChild">The A05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="A05_SubContinent_ReChildDto"/>.</returns>
        A05_SubContinent_ReChildDto Insert(A05_SubContinent_ReChildDto a05_SubContinent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the A05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="a05_SubContinent_ReChild">The A05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="A05_SubContinent_ReChildDto"/>.</returns>
        A05_SubContinent_ReChildDto Update(A05_SubContinent_ReChildDto a05_SubContinent_ReChild);

        /// <summary>
        /// Deletes the A05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
