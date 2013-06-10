using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H03_Continent_Child type
    /// </summary>
    public partial interface IH03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H03_Continent_ChildDto"/> object.</returns>
        H03_Continent_ChildDto Fetch(int continent_ID1);

        /// <summary>
        /// Inserts a new H03_Continent_Child object in the database.
        /// </summary>
        /// <param name="h03_Continent_Child">The H03 Continent Child DTO.</param>
        /// <returns>The new <see cref="H03_Continent_ChildDto"/>.</returns>
        H03_Continent_ChildDto Insert(H03_Continent_ChildDto h03_Continent_Child);

        /// <summary>
        /// Updates in the database all changes made to the H03_Continent_Child object.
        /// </summary>
        /// <param name="h03_Continent_Child">The H03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="H03_Continent_ChildDto"/>.</returns>
        H03_Continent_ChildDto Update(H03_Continent_ChildDto h03_Continent_Child);

        /// <summary>
        /// Deletes the H03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        void Delete(int continent_ID1);
    }
}
