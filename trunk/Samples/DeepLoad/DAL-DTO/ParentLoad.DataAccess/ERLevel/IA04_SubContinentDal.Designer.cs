using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A04_SubContinent type
    /// </summary>
    public partial interface IA04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new A04_SubContinent object in the database.
        /// </summary>
        /// <param name="a04_SubContinent">The A04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="A04_SubContinentDto"/>.</returns>
        A04_SubContinentDto Insert(A04_SubContinentDto a04_SubContinent);

        /// <summary>
        /// Updates in the database all changes made to the A04_SubContinent object.
        /// </summary>
        /// <param name="a04_SubContinent">The A04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="A04_SubContinentDto"/>.</returns>
        A04_SubContinentDto Update(A04_SubContinentDto a04_SubContinent);

        /// <summary>
        /// Deletes the A04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
