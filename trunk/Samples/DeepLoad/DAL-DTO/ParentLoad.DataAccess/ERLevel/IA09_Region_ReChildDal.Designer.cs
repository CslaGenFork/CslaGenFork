using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A09_Region_ReChild type
    /// </summary>
    public partial interface IA09_Region_ReChildDal
    {
        /// <summary>
        /// Inserts a new A09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="a09_Region_ReChild">The A09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="A09_Region_ReChildDto"/>.</returns>
        A09_Region_ReChildDto Insert(A09_Region_ReChildDto a09_Region_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the A09_Region_ReChild object.
        /// </summary>
        /// <param name="a09_Region_ReChild">The A09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="A09_Region_ReChildDto"/>.</returns>
        A09_Region_ReChildDto Update(A09_Region_ReChildDto a09_Region_ReChild);

        /// <summary>
        /// Deletes the A09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        void Delete(int region_ID2);
    }
}
