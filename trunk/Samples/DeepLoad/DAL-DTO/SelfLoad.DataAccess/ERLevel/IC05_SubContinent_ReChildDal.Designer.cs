using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C05_SubContinent_ReChild type
    /// </summary>
    public partial interface IC05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C05_SubContinent_ReChildDto"/> object.</returns>
        C05_SubContinent_ReChildDto Fetch(int subContinent_ID2);

        /// <summary>
        /// Inserts a new C05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="c05_SubContinent_ReChild">The C05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="C05_SubContinent_ReChildDto"/>.</returns>
        C05_SubContinent_ReChildDto Insert(C05_SubContinent_ReChildDto c05_SubContinent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the C05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="c05_SubContinent_ReChild">The C05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="C05_SubContinent_ReChildDto"/>.</returns>
        C05_SubContinent_ReChildDto Update(C05_SubContinent_ReChildDto c05_SubContinent_ReChild);

        /// <summary>
        /// Deletes the C05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
