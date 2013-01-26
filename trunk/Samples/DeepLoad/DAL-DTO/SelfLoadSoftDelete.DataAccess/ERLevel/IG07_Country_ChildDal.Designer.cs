using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G07_Country_Child type
    /// </summary>
    public partial interface IG07_Country_ChildDal
    {
        /// <summary>
        /// Loads a G07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G07_Country_ChildDto"/> object.</returns>
        G07_Country_ChildDto Fetch(int country_ID1);

        /// <summary>
        /// Inserts a new G07_Country_Child object in the database.
        /// </summary>
        /// <param name="g07_Country_Child">The G07 Country Child DTO.</param>
        /// <returns>The new <see cref="G07_Country_ChildDto"/>.</returns>
        G07_Country_ChildDto Insert(G07_Country_ChildDto g07_Country_Child);

        /// <summary>
        /// Updates in the database all changes made to the G07_Country_Child object.
        /// </summary>
        /// <param name="g07_Country_Child">The G07 Country Child DTO.</param>
        /// <returns>The updated <see cref="G07_Country_ChildDto"/>.</returns>
        G07_Country_ChildDto Update(G07_Country_ChildDto g07_Country_Child);

        /// <summary>
        /// Deletes the G07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
