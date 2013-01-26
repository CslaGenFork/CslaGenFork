using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C09_Region_Child type
    /// </summary>
    public partial interface IC09_Region_ChildDal
    {
        /// <summary>
        /// Loads a C09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C09_Region_ChildDto"/> object.</returns>
        C09_Region_ChildDto Fetch(int region_ID1);

        /// <summary>
        /// Inserts a new C09_Region_Child object in the database.
        /// </summary>
        /// <param name="c09_Region_Child">The C09 Region Child DTO.</param>
        /// <returns>The new <see cref="C09_Region_ChildDto"/>.</returns>
        C09_Region_ChildDto Insert(C09_Region_ChildDto c09_Region_Child);

        /// <summary>
        /// Updates in the database all changes made to the C09_Region_Child object.
        /// </summary>
        /// <param name="c09_Region_Child">The C09 Region Child DTO.</param>
        /// <returns>The updated <see cref="C09_Region_ChildDto"/>.</returns>
        C09_Region_ChildDto Update(C09_Region_ChildDto c09_Region_Child);

        /// <summary>
        /// Deletes the C09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
