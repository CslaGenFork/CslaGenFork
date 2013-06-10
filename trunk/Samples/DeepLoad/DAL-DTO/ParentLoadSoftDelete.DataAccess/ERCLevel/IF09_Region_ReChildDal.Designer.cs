using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F09_Region_ReChild type
    /// </summary>
    public partial interface IF09_Region_ReChildDal
    {
        /// <summary>
        /// Inserts a new F09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="f09_Region_ReChild">The F09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="F09_Region_ReChildDto"/>.</returns>
        F09_Region_ReChildDto Insert(F09_Region_ReChildDto f09_Region_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the F09_Region_ReChild object.
        /// </summary>
        /// <param name="f09_Region_ReChild">The F09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="F09_Region_ReChildDto"/>.</returns>
        F09_Region_ReChildDto Update(F09_Region_ReChildDto f09_Region_ReChild);

        /// <summary>
        /// Deletes the F09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        void Delete(int region_ID2);
    }
}
