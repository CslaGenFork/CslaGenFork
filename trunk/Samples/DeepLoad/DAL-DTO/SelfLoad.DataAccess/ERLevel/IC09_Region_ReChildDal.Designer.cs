using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C09_Region_ReChild type
    /// </summary>
    public partial interface IC09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a C09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C09_Region_ReChildDto"/> object.</returns>
        C09_Region_ReChildDto Fetch(int region_ID2);

        /// <summary>
        /// Inserts a new C09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="c09_Region_ReChild">The C09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="C09_Region_ReChildDto"/>.</returns>
        C09_Region_ReChildDto Insert(C09_Region_ReChildDto c09_Region_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the C09_Region_ReChild object.
        /// </summary>
        /// <param name="c09_Region_ReChild">The C09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="C09_Region_ReChildDto"/>.</returns>
        C09_Region_ReChildDto Update(C09_Region_ReChildDto c09_Region_ReChild);

        /// <summary>
        /// Deletes the C09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
