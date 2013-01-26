using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E03_Continent_Child type
    /// </summary>
    public partial interface IE03_Continent_ChildDal
    {
        /// <summary>
        /// Inserts a new E03_Continent_Child object in the database.
        /// </summary>
        /// <param name="e03_Continent_Child">The E03 Continent Child DTO.</param>
        /// <returns>The new <see cref="E03_Continent_ChildDto"/>.</returns>
        E03_Continent_ChildDto Insert(E03_Continent_ChildDto e03_Continent_Child);

        /// <summary>
        /// Updates in the database all changes made to the E03_Continent_Child object.
        /// </summary>
        /// <param name="e03_Continent_Child">The E03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="E03_Continent_ChildDto"/>.</returns>
        E03_Continent_ChildDto Update(E03_Continent_ChildDto e03_Continent_Child);

        /// <summary>
        /// Deletes the E03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
