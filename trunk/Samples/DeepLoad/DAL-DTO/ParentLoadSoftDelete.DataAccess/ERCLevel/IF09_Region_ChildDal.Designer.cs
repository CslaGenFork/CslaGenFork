using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F09_Region_Child type
    /// </summary>
    public partial interface IF09_Region_ChildDal
    {
        /// <summary>
        /// Inserts a new F09_Region_Child object in the database.
        /// </summary>
        /// <param name="f09_Region_Child">The F09 Region Child DTO.</param>
        /// <returns>The new <see cref="F09_Region_ChildDto"/>.</returns>
        F09_Region_ChildDto Insert(F09_Region_ChildDto f09_Region_Child);

        /// <summary>
        /// Updates in the database all changes made to the F09_Region_Child object.
        /// </summary>
        /// <param name="f09_Region_Child">The F09 Region Child DTO.</param>
        /// <returns>The updated <see cref="F09_Region_ChildDto"/>.</returns>
        F09_Region_ChildDto Update(F09_Region_ChildDto f09_Region_Child);

        /// <summary>
        /// Deletes the F09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
