using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E04_SubContinent type
    /// </summary>
    public partial interface IE04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new E04_SubContinent object in the database.
        /// </summary>
        /// <param name="e04_SubContinent">The E04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="E04_SubContinentDto"/>.</returns>
        E04_SubContinentDto Insert(E04_SubContinentDto e04_SubContinent);

        /// <summary>
        /// Updates in the database all changes made to the E04_SubContinent object.
        /// </summary>
        /// <param name="e04_SubContinent">The E04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="E04_SubContinentDto"/>.</returns>
        E04_SubContinentDto Update(E04_SubContinentDto e04_SubContinent);

        /// <summary>
        /// Deletes the E04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
