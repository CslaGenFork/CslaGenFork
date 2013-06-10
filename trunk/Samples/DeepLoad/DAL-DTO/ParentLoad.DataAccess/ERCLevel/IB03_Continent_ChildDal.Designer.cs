using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B03_Continent_Child type
    /// </summary>
    public partial interface IB03_Continent_ChildDal
    {
        /// <summary>
        /// Inserts a new B03_Continent_Child object in the database.
        /// </summary>
        /// <param name="b03_Continent_Child">The B03 Continent Child DTO.</param>
        /// <returns>The new <see cref="B03_Continent_ChildDto"/>.</returns>
        B03_Continent_ChildDto Insert(B03_Continent_ChildDto b03_Continent_Child);

        /// <summary>
        /// Updates in the database all changes made to the B03_Continent_Child object.
        /// </summary>
        /// <param name="b03_Continent_Child">The B03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="B03_Continent_ChildDto"/>.</returns>
        B03_Continent_ChildDto Update(B03_Continent_ChildDto b03_Continent_Child);

        /// <summary>
        /// Deletes the B03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        void Delete(int continent_ID1);
    }
}
