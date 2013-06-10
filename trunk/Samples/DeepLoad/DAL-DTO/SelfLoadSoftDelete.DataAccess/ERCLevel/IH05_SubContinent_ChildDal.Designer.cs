using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H05_SubContinent_Child type
    /// </summary>
    public partial interface IH05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a H05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H05_SubContinent_ChildDto"/> object.</returns>
        H05_SubContinent_ChildDto Fetch(int subContinent_ID1);

        /// <summary>
        /// Inserts a new H05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="h05_SubContinent_Child">The H05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="H05_SubContinent_ChildDto"/>.</returns>
        H05_SubContinent_ChildDto Insert(H05_SubContinent_ChildDto h05_SubContinent_Child);

        /// <summary>
        /// Updates in the database all changes made to the H05_SubContinent_Child object.
        /// </summary>
        /// <param name="h05_SubContinent_Child">The H05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="H05_SubContinent_ChildDto"/>.</returns>
        H05_SubContinent_ChildDto Update(H05_SubContinent_ChildDto h05_SubContinent_Child);

        /// <summary>
        /// Deletes the H05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        void Delete(int subContinent_ID1);
    }
}
