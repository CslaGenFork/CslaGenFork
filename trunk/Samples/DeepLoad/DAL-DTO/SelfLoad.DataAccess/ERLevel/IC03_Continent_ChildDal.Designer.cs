using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C03_Continent_Child type
    /// </summary>
    public partial interface IC03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a C03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C03_Continent_ChildDto"/> object.</returns>
        C03_Continent_ChildDto Fetch(int continent_ID1);

        /// <summary>
        /// Inserts a new C03_Continent_Child object in the database.
        /// </summary>
        /// <param name="c03_Continent_Child">The C03 Continent Child DTO.</param>
        /// <returns>The new <see cref="C03_Continent_ChildDto"/>.</returns>
        C03_Continent_ChildDto Insert(C03_Continent_ChildDto c03_Continent_Child);

        /// <summary>
        /// Updates in the database all changes made to the C03_Continent_Child object.
        /// </summary>
        /// <param name="c03_Continent_Child">The C03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="C03_Continent_ChildDto"/>.</returns>
        C03_Continent_ChildDto Update(C03_Continent_ChildDto c03_Continent_Child);

        /// <summary>
        /// Deletes the C03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        void Delete(int continent_ID1);
    }
}
