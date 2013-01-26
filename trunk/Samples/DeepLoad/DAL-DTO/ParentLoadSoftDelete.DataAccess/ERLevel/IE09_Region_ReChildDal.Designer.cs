using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E09_Region_ReChild type
    /// </summary>
    public partial interface IE09_Region_ReChildDal
    {
        /// <summary>
        /// Inserts a new E09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="e09_Region_ReChild">The E09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="E09_Region_ReChildDto"/>.</returns>
        E09_Region_ReChildDto Insert(E09_Region_ReChildDto e09_Region_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the E09_Region_ReChild object.
        /// </summary>
        /// <param name="e09_Region_ReChild">The E09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="E09_Region_ReChildDto"/>.</returns>
        E09_Region_ReChildDto Update(E09_Region_ReChildDto e09_Region_ReChild);

        /// <summary>
        /// Deletes the E09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
