using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D02_Continent type
    /// </summary>
    public partial interface ID02_ContinentDal
    {
        /// <summary>
        /// Inserts a new D02_Continent object in the database.
        /// </summary>
        /// <param name="d02_Continent">The D02 Continent DTO.</param>
        /// <returns>The new <see cref="D02_ContinentDto"/>.</returns>
        D02_ContinentDto Insert(D02_ContinentDto d02_Continent);

        /// <summary>
        /// Updates in the database all changes made to the D02_Continent object.
        /// </summary>
        /// <param name="d02_Continent">The D02 Continent DTO.</param>
        /// <returns>The updated <see cref="D02_ContinentDto"/>.</returns>
        D02_ContinentDto Update(D02_ContinentDto d02_Continent);

        /// <summary>
        /// Deletes the D02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        void Delete(int continent_ID);
    }
}
