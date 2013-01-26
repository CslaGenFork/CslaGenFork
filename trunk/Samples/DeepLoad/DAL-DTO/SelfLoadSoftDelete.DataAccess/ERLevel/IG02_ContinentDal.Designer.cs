using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G02_Continent type
    /// </summary>
    public partial interface IG02_ContinentDal
    {
        /// <summary>
        /// Loads a G02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A <see cref="G02_ContinentDto"/> object.</returns>
        G02_ContinentDto Fetch(int continent_ID);

        /// <summary>
        /// Inserts a new G02_Continent object in the database.
        /// </summary>
        /// <param name="g02_Continent">The G02 Continent DTO.</param>
        /// <returns>The new <see cref="G02_ContinentDto"/>.</returns>
        G02_ContinentDto Insert(G02_ContinentDto g02_Continent);

        /// <summary>
        /// Updates in the database all changes made to the G02_Continent object.
        /// </summary>
        /// <param name="g02_Continent">The G02 Continent DTO.</param>
        /// <returns>The updated <see cref="G02_ContinentDto"/>.</returns>
        G02_ContinentDto Update(G02_ContinentDto g02_Continent);

        /// <summary>
        /// Deletes the G02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The delete criteria.</param>
        void Delete(int continent_ID);
    }
}
