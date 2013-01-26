using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G05_SubContinent_Child type
    /// </summary>
    public partial interface IG05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a G05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G05_SubContinent_ChildDto"/> object.</returns>
        G05_SubContinent_ChildDto Fetch(int subContinent_ID1);

        /// <summary>
        /// Inserts a new G05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="g05_SubContinent_Child">The G05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="G05_SubContinent_ChildDto"/>.</returns>
        G05_SubContinent_ChildDto Insert(G05_SubContinent_ChildDto g05_SubContinent_Child);

        /// <summary>
        /// Updates in the database all changes made to the G05_SubContinent_Child object.
        /// </summary>
        /// <param name="g05_SubContinent_Child">The G05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="G05_SubContinent_ChildDto"/>.</returns>
        G05_SubContinent_ChildDto Update(G05_SubContinent_ChildDto g05_SubContinent_Child);

        /// <summary>
        /// Deletes the G05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
