using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G03_Continent_Child type
    /// </summary>
    public partial interface IG03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a G03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G03_Continent_ChildDto"/> object.</returns>
        G03_Continent_ChildDto Fetch(int continent_ID1);

        /// <summary>
        /// Inserts a new G03_Continent_Child object in the database.
        /// </summary>
        /// <param name="g03_Continent_Child">The G03 Continent Child DTO.</param>
        /// <returns>The new <see cref="G03_Continent_ChildDto"/>.</returns>
        G03_Continent_ChildDto Insert(G03_Continent_ChildDto g03_Continent_Child);

        /// <summary>
        /// Updates in the database all changes made to the G03_Continent_Child object.
        /// </summary>
        /// <param name="g03_Continent_Child">The G03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="G03_Continent_ChildDto"/>.</returns>
        G03_Continent_ChildDto Update(G03_Continent_ChildDto g03_Continent_Child);

        /// <summary>
        /// Deletes the G03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        void Delete(int continent_ID1);
    }
}
