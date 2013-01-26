using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D04_SubContinent type
    /// </summary>
    public partial interface ID04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new D04_SubContinent object in the database.
        /// </summary>
        /// <param name="d04_SubContinent">The D04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="D04_SubContinentDto"/>.</returns>
        D04_SubContinentDto Insert(D04_SubContinentDto d04_SubContinent);

        /// <summary>
        /// Updates in the database all changes made to the D04_SubContinent object.
        /// </summary>
        /// <param name="d04_SubContinent">The D04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="D04_SubContinentDto"/>.</returns>
        D04_SubContinentDto Update(D04_SubContinentDto d04_SubContinent);

        /// <summary>
        /// Deletes the D04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
