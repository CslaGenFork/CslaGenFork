using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E05_SubContinent_Child type
    /// </summary>
    public partial interface IE05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new E05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="e05_SubContinent_Child">The E05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="E05_SubContinent_ChildDto"/>.</returns>
        E05_SubContinent_ChildDto Insert(E05_SubContinent_ChildDto e05_SubContinent_Child);

        /// <summary>
        /// Updates in the database all changes made to the E05_SubContinent_Child object.
        /// </summary>
        /// <param name="e05_SubContinent_Child">The E05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="E05_SubContinent_ChildDto"/>.</returns>
        E05_SubContinent_ChildDto Update(E05_SubContinent_ChildDto e05_SubContinent_Child);

        /// <summary>
        /// Deletes the E05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        void Delete(int subContinent_ID1);
    }
}
