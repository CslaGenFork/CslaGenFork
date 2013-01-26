using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H05_SubContinent_ReChild type
    /// </summary>
    public partial interface IH05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a H05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="H05_SubContinent_ReChildDto"/> object.</returns>
        H05_SubContinent_ReChildDto Fetch(int subContinent_ID2);

        /// <summary>
        /// Inserts a new H05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="h05_SubContinent_ReChild">The H05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="H05_SubContinent_ReChildDto"/>.</returns>
        H05_SubContinent_ReChildDto Insert(H05_SubContinent_ReChildDto h05_SubContinent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the H05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="h05_SubContinent_ReChild">The H05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="H05_SubContinent_ReChildDto"/>.</returns>
        H05_SubContinent_ReChildDto Update(H05_SubContinent_ReChildDto h05_SubContinent_ReChild);

        /// <summary>
        /// Deletes the H05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
