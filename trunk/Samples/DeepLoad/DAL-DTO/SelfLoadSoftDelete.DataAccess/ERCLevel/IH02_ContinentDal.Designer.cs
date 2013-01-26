using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H02_Continent type
    /// </summary>
    public partial interface IH02_ContinentDal
    {
        /// <summary>
        /// Inserts a new H02_Continent object in the database.
        /// </summary>
        /// <param name="h02_Continent">The H02 Continent DTO.</param>
        /// <returns>The new <see cref="H02_ContinentDto"/>.</returns>
        H02_ContinentDto Insert(H02_ContinentDto h02_Continent);

        /// <summary>
        /// Updates in the database all changes made to the H02_Continent object.
        /// </summary>
        /// <param name="h02_Continent">The H02 Continent DTO.</param>
        /// <returns>The updated <see cref="H02_ContinentDto"/>.</returns>
        H02_ContinentDto Update(H02_ContinentDto h02_Continent);

        /// <summary>
        /// Deletes the H02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        void Delete(int continent_ID);
    }
}
