using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C04_SubContinent type
    /// </summary>
    public partial interface IC04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new C04_SubContinent object in the database.
        /// </summary>
        /// <param name="c04_SubContinent">The C04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="C04_SubContinentDto"/>.</returns>
        C04_SubContinentDto Insert(C04_SubContinentDto c04_SubContinent);

        /// <summary>
        /// Updates in the database all changes made to the C04_SubContinent object.
        /// </summary>
        /// <param name="c04_SubContinent">The C04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="C04_SubContinentDto"/>.</returns>
        C04_SubContinentDto Update(C04_SubContinentDto c04_SubContinent);

        /// <summary>
        /// Deletes the C04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
