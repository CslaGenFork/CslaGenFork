using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G11_City_ReChild type
    /// </summary>
    public partial interface IG11_City_ReChildDal
    {
        /// <summary>
        /// Loads a G11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G11_City_ReChildDto"/> object.</returns>
        G11_City_ReChildDto Fetch(int city_ID2);

        /// <summary>
        /// Inserts a new G11_City_ReChild object in the database.
        /// </summary>
        /// <param name="g11_City_ReChild">The G11 City Re Child DTO.</param>
        /// <returns>The new <see cref="G11_City_ReChildDto"/>.</returns>
        G11_City_ReChildDto Insert(G11_City_ReChildDto g11_City_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the G11_City_ReChild object.
        /// </summary>
        /// <param name="g11_City_ReChild">The G11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="G11_City_ReChildDto"/>.</returns>
        G11_City_ReChildDto Update(G11_City_ReChildDto g11_City_ReChild);

        /// <summary>
        /// Deletes the G11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        void Delete(int city_ID2);
    }
}
