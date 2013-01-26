using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D03_Continent_Child type
    /// </summary>
    public partial interface ID03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a D03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D03_Continent_ChildDto"/> object.</returns>
        D03_Continent_ChildDto Fetch(int continent_ID1);

        /// <summary>
        /// Inserts a new D03_Continent_Child object in the database.
        /// </summary>
        /// <param name="d03_Continent_Child">The D03 Continent Child DTO.</param>
        /// <returns>The new <see cref="D03_Continent_ChildDto"/>.</returns>
        D03_Continent_ChildDto Insert(D03_Continent_ChildDto d03_Continent_Child);

        /// <summary>
        /// Updates in the database all changes made to the D03_Continent_Child object.
        /// </summary>
        /// <param name="d03_Continent_Child">The D03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="D03_Continent_ChildDto"/>.</returns>
        D03_Continent_ChildDto Update(D03_Continent_ChildDto d03_Continent_Child);

        /// <summary>
        /// Deletes the D03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
