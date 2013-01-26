using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F02_Continent type
    /// </summary>
    public partial interface IF02_ContinentDal
    {
        /// <summary>
        /// Inserts a new F02_Continent object in the database.
        /// </summary>
        /// <param name="f02_Continent">The F02 Continent DTO.</param>
        /// <returns>The new <see cref="F02_ContinentDto"/>.</returns>
        F02_ContinentDto Insert(F02_ContinentDto f02_Continent);

        /// <summary>
        /// Updates in the database all changes made to the F02_Continent object.
        /// </summary>
        /// <param name="f02_Continent">The F02 Continent DTO.</param>
        /// <returns>The updated <see cref="F02_ContinentDto"/>.</returns>
        F02_ContinentDto Update(F02_ContinentDto f02_Continent);

        /// <summary>
        /// Deletes the F02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        void Delete(int continent_ID);
    }
}
