using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F04_SubContinent type
    /// </summary>
    public partial interface IF04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new F04_SubContinent object in the database.
        /// </summary>
        /// <param name="f04_SubContinent">The F04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="F04_SubContinentDto"/>.</returns>
        F04_SubContinentDto Insert(F04_SubContinentDto f04_SubContinent);

        /// <summary>
        /// Updates in the database all changes made to the F04_SubContinent object.
        /// </summary>
        /// <param name="f04_SubContinent">The F04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="F04_SubContinentDto"/>.</returns>
        F04_SubContinentDto Update(F04_SubContinentDto f04_SubContinent);

        /// <summary>
        /// Deletes the F04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
