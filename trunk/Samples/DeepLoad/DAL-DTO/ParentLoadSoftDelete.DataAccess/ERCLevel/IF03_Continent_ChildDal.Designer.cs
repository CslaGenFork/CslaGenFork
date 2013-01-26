using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F03_Continent_Child type
    /// </summary>
    public partial interface IF03_Continent_ChildDal
    {
        /// <summary>
        /// Inserts a new F03_Continent_Child object in the database.
        /// </summary>
        /// <param name="f03_Continent_Child">The F03 Continent Child DTO.</param>
        /// <returns>The new <see cref="F03_Continent_ChildDto"/>.</returns>
        F03_Continent_ChildDto Insert(F03_Continent_ChildDto f03_Continent_Child);

        /// <summary>
        /// Updates in the database all changes made to the F03_Continent_Child object.
        /// </summary>
        /// <param name="f03_Continent_Child">The F03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="F03_Continent_ChildDto"/>.</returns>
        F03_Continent_ChildDto Update(F03_Continent_ChildDto f03_Continent_Child);

        /// <summary>
        /// Deletes the F03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
