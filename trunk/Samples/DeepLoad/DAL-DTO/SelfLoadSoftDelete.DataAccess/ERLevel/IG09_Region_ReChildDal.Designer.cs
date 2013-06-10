using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G09_Region_ReChild type
    /// </summary>
    public partial interface IG09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a G09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G09_Region_ReChildDto"/> object.</returns>
        G09_Region_ReChildDto Fetch(int region_ID2);

        /// <summary>
        /// Inserts a new G09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="g09_Region_ReChild">The G09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="G09_Region_ReChildDto"/>.</returns>
        G09_Region_ReChildDto Insert(G09_Region_ReChildDto g09_Region_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the G09_Region_ReChild object.
        /// </summary>
        /// <param name="g09_Region_ReChild">The G09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="G09_Region_ReChildDto"/>.</returns>
        G09_Region_ReChildDto Update(G09_Region_ReChildDto g09_Region_ReChild);

        /// <summary>
        /// Deletes the G09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        void Delete(int region_ID2);
    }
}
