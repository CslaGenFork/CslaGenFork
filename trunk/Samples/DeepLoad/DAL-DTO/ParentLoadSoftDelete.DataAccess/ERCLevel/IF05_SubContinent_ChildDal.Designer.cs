using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F05_SubContinent_Child type
    /// </summary>
    public partial interface IF05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new F05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="f05_SubContinent_Child">The F05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="F05_SubContinent_ChildDto"/>.</returns>
        F05_SubContinent_ChildDto Insert(F05_SubContinent_ChildDto f05_SubContinent_Child);

        /// <summary>
        /// Updates in the database all changes made to the F05_SubContinent_Child object.
        /// </summary>
        /// <param name="f05_SubContinent_Child">The F05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="F05_SubContinent_ChildDto"/>.</returns>
        F05_SubContinent_ChildDto Update(F05_SubContinent_ChildDto f05_SubContinent_Child);

        /// <summary>
        /// Deletes the F05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
