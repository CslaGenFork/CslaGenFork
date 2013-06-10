using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H09_Region_Child type
    /// </summary>
    public partial interface IH09_Region_ChildDal
    {
        /// <summary>
        /// Loads a H09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H09_Region_ChildDto"/> object.</returns>
        H09_Region_ChildDto Fetch(int region_ID1);

        /// <summary>
        /// Inserts a new H09_Region_Child object in the database.
        /// </summary>
        /// <param name="h09_Region_Child">The H09 Region Child DTO.</param>
        /// <returns>The new <see cref="H09_Region_ChildDto"/>.</returns>
        H09_Region_ChildDto Insert(H09_Region_ChildDto h09_Region_Child);

        /// <summary>
        /// Updates in the database all changes made to the H09_Region_Child object.
        /// </summary>
        /// <param name="h09_Region_Child">The H09 Region Child DTO.</param>
        /// <returns>The updated <see cref="H09_Region_ChildDto"/>.</returns>
        H09_Region_ChildDto Update(H09_Region_ChildDto h09_Region_Child);

        /// <summary>
        /// Deletes the H09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        void Delete(int region_ID1);
    }
}
