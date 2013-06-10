using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E09_Region_Child type
    /// </summary>
    public partial interface IE09_Region_ChildDal
    {
        /// <summary>
        /// Inserts a new E09_Region_Child object in the database.
        /// </summary>
        /// <param name="e09_Region_Child">The E09 Region Child DTO.</param>
        /// <returns>The new <see cref="E09_Region_ChildDto"/>.</returns>
        E09_Region_ChildDto Insert(E09_Region_ChildDto e09_Region_Child);

        /// <summary>
        /// Updates in the database all changes made to the E09_Region_Child object.
        /// </summary>
        /// <param name="e09_Region_Child">The E09 Region Child DTO.</param>
        /// <returns>The updated <see cref="E09_Region_ChildDto"/>.</returns>
        E09_Region_ChildDto Update(E09_Region_ChildDto e09_Region_Child);

        /// <summary>
        /// Deletes the E09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        void Delete(int region_ID1);
    }
}
