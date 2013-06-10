using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B05_SubContinent_ReChild type
    /// </summary>
    public partial interface IB05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Inserts a new B05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="b05_SubContinent_ReChild">The B05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="B05_SubContinent_ReChildDto"/>.</returns>
        B05_SubContinent_ReChildDto Insert(B05_SubContinent_ReChildDto b05_SubContinent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the B05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="b05_SubContinent_ReChild">The B05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="B05_SubContinent_ReChildDto"/>.</returns>
        B05_SubContinent_ReChildDto Update(B05_SubContinent_ReChildDto b05_SubContinent_ReChild);

        /// <summary>
        /// Deletes the B05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        void Delete(int subContinent_ID2);
    }
}
