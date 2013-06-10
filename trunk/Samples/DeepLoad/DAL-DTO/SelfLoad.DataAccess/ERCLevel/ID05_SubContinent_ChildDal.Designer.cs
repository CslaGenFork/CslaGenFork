using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D05_SubContinent_Child type
    /// </summary>
    public partial interface ID05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a D05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D05_SubContinent_ChildDto"/> object.</returns>
        D05_SubContinent_ChildDto Fetch(int subContinent_ID1);

        /// <summary>
        /// Inserts a new D05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="d05_SubContinent_Child">The D05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="D05_SubContinent_ChildDto"/>.</returns>
        D05_SubContinent_ChildDto Insert(D05_SubContinent_ChildDto d05_SubContinent_Child);

        /// <summary>
        /// Updates in the database all changes made to the D05_SubContinent_Child object.
        /// </summary>
        /// <param name="d05_SubContinent_Child">The D05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="D05_SubContinent_ChildDto"/>.</returns>
        D05_SubContinent_ChildDto Update(D05_SubContinent_ChildDto d05_SubContinent_Child);

        /// <summary>
        /// Deletes the D05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        void Delete(int subContinent_ID1);
    }
}
