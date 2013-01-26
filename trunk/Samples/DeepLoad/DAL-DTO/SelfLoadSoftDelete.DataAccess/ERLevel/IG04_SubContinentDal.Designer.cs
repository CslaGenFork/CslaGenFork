using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G04_SubContinent type
    /// </summary>
    public partial interface IG04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new G04_SubContinent object in the database.
        /// </summary>
        /// <param name="g04_SubContinent">The G04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="G04_SubContinentDto"/>.</returns>
        G04_SubContinentDto Insert(G04_SubContinentDto g04_SubContinent);

        /// <summary>
        /// Updates in the database all changes made to the G04_SubContinent object.
        /// </summary>
        /// <param name="g04_SubContinent">The G04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="G04_SubContinentDto"/>.</returns>
        G04_SubContinentDto Update(G04_SubContinentDto g04_SubContinent);

        /// <summary>
        /// Deletes the G04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
