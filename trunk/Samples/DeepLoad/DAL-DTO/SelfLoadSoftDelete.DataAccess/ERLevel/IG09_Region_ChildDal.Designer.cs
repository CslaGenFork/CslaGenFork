using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G09_Region_Child type
    /// </summary>
    public partial interface IG09_Region_ChildDal
    {
        /// <summary>
        /// Loads a G09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G09_Region_ChildDto"/> object.</returns>
        G09_Region_ChildDto Fetch(int region_ID1);

        /// <summary>
        /// Inserts a new G09_Region_Child object in the database.
        /// </summary>
        /// <param name="g09_Region_Child">The G09 Region Child DTO.</param>
        /// <returns>The new <see cref="G09_Region_ChildDto"/>.</returns>
        G09_Region_ChildDto Insert(G09_Region_ChildDto g09_Region_Child);

        /// <summary>
        /// Updates in the database all changes made to the G09_Region_Child object.
        /// </summary>
        /// <param name="g09_Region_Child">The G09 Region Child DTO.</param>
        /// <returns>The updated <see cref="G09_Region_ChildDto"/>.</returns>
        G09_Region_ChildDto Update(G09_Region_ChildDto g09_Region_Child);

        /// <summary>
        /// Deletes the G09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
