using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B02_Continent type
    /// </summary>
    public partial interface IB02_ContinentDal
    {
        /// <summary>
        /// Inserts a new B02_Continent object in the database.
        /// </summary>
        /// <param name="b02_Continent">The B02 Continent DTO.</param>
        /// <returns>The new <see cref="B02_ContinentDto"/>.</returns>
        B02_ContinentDto Insert(B02_ContinentDto b02_Continent);

        /// <summary>
        /// Updates in the database all changes made to the B02_Continent object.
        /// </summary>
        /// <param name="b02_Continent">The B02 Continent DTO.</param>
        /// <returns>The updated <see cref="B02_ContinentDto"/>.</returns>
        B02_ContinentDto Update(B02_ContinentDto b02_Continent);

        /// <summary>
        /// Deletes the B02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        void Delete(int continent_ID);
    }
}
