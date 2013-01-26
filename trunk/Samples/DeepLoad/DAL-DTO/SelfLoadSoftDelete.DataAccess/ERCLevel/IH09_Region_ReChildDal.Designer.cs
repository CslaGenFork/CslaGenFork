using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H09_Region_ReChild type
    /// </summary>
    public partial interface IH09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a H09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="H09_Region_ReChildDto"/> object.</returns>
        H09_Region_ReChildDto Fetch(int region_ID2);

        /// <summary>
        /// Inserts a new H09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="h09_Region_ReChild">The H09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="H09_Region_ReChildDto"/>.</returns>
        H09_Region_ReChildDto Insert(H09_Region_ReChildDto h09_Region_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the H09_Region_ReChild object.
        /// </summary>
        /// <param name="h09_Region_ReChild">The H09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="H09_Region_ReChildDto"/>.</returns>
        H09_Region_ReChildDto Update(H09_Region_ReChildDto h09_Region_ReChild);

        /// <summary>
        /// Deletes the H09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
