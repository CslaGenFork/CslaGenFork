using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H04_SubContinent type
    /// </summary>
    public partial interface IH04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new H04_SubContinent object in the database.
        /// </summary>
        /// <param name="h04_SubContinent">The H04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="H04_SubContinentDto"/>.</returns>
        H04_SubContinentDto Insert(H04_SubContinentDto h04_SubContinent);

        /// <summary>
        /// Updates in the database all changes made to the H04_SubContinent object.
        /// </summary>
        /// <param name="h04_SubContinent">The H04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="H04_SubContinentDto"/>.</returns>
        H04_SubContinentDto Update(H04_SubContinentDto h04_SubContinent);

        /// <summary>
        /// Deletes the H04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
