using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A03_Continent_Child type
    /// </summary>
    public partial interface IA03_Continent_ChildDal
    {
        /// <summary>
        /// Inserts a new A03_Continent_Child object in the database.
        /// </summary>
        /// <param name="a03_Continent_Child">The A03 Continent Child DTO.</param>
        /// <returns>The new <see cref="A03_Continent_ChildDto"/>.</returns>
        A03_Continent_ChildDto Insert(A03_Continent_ChildDto a03_Continent_Child);

        /// <summary>
        /// Updates in the database all changes made to the A03_Continent_Child object.
        /// </summary>
        /// <param name="a03_Continent_Child">The A03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="A03_Continent_ChildDto"/>.</returns>
        A03_Continent_ChildDto Update(A03_Continent_ChildDto a03_Continent_Child);

        /// <summary>
        /// Deletes the A03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
