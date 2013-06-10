using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A05_SubContinent_Child type
    /// </summary>
    public partial interface IA05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new A05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="a05_SubContinent_Child">The A05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="A05_SubContinent_ChildDto"/>.</returns>
        A05_SubContinent_ChildDto Insert(A05_SubContinent_ChildDto a05_SubContinent_Child);

        /// <summary>
        /// Updates in the database all changes made to the A05_SubContinent_Child object.
        /// </summary>
        /// <param name="a05_SubContinent_Child">The A05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="A05_SubContinent_ChildDto"/>.</returns>
        A05_SubContinent_ChildDto Update(A05_SubContinent_ChildDto a05_SubContinent_Child);

        /// <summary>
        /// Deletes the A05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        void Delete(int subContinent_ID1);
    }
}
