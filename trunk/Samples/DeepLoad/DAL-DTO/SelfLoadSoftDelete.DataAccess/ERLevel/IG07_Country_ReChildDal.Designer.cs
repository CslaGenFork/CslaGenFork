using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G07_Country_ReChild type
    /// </summary>
    public partial interface IG07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a G07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G07_Country_ReChildDto"/> object.</returns>
        G07_Country_ReChildDto Fetch(int country_ID2);

        /// <summary>
        /// Inserts a new G07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="g07_Country_ReChild">The G07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="G07_Country_ReChildDto"/>.</returns>
        G07_Country_ReChildDto Insert(G07_Country_ReChildDto g07_Country_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the G07_Country_ReChild object.
        /// </summary>
        /// <param name="g07_Country_ReChild">The G07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="G07_Country_ReChildDto"/>.</returns>
        G07_Country_ReChildDto Update(G07_Country_ReChildDto g07_Country_ReChild);

        /// <summary>
        /// Deletes the G07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        void Delete(int country_ID2);
    }
}
