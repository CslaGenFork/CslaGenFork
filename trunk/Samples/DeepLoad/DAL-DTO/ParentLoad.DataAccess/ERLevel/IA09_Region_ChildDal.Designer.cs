using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A09_Region_Child type
    /// </summary>
    public partial interface IA09_Region_ChildDal
    {
        /// <summary>
        /// Inserts a new A09_Region_Child object in the database.
        /// </summary>
        /// <param name="a09_Region_Child">The A09 Region Child DTO.</param>
        /// <returns>The new <see cref="A09_Region_ChildDto"/>.</returns>
        A09_Region_ChildDto Insert(A09_Region_ChildDto a09_Region_Child);

        /// <summary>
        /// Updates in the database all changes made to the A09_Region_Child object.
        /// </summary>
        /// <param name="a09_Region_Child">The A09 Region Child DTO.</param>
        /// <returns>The updated <see cref="A09_Region_ChildDto"/>.</returns>
        A09_Region_ChildDto Update(A09_Region_ChildDto a09_Region_Child);

        /// <summary>
        /// Deletes the A09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        void Delete(int region_ID1);
    }
}
