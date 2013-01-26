using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B04_SubContinent type
    /// </summary>
    public partial interface IB04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new B04_SubContinent object in the database.
        /// </summary>
        /// <param name="b04_SubContinent">The B04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="B04_SubContinentDto"/>.</returns>
        B04_SubContinentDto Insert(B04_SubContinentDto b04_SubContinent);

        /// <summary>
        /// Updates in the database all changes made to the B04_SubContinent object.
        /// </summary>
        /// <param name="b04_SubContinent">The B04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="B04_SubContinentDto"/>.</returns>
        B04_SubContinentDto Update(B04_SubContinentDto b04_SubContinent);

        /// <summary>
        /// Deletes the B04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
