using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H11_City_ReChild type
    /// </summary>
    public partial interface IH11_City_ReChildDal
    {
        /// <summary>
        /// Loads a H11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="H11_City_ReChildDto"/> object.</returns>
        H11_City_ReChildDto Fetch(int city_ID2);

        /// <summary>
        /// Inserts a new H11_City_ReChild object in the database.
        /// </summary>
        /// <param name="h11_City_ReChild">The H11 City Re Child DTO.</param>
        /// <returns>The new <see cref="H11_City_ReChildDto"/>.</returns>
        H11_City_ReChildDto Insert(H11_City_ReChildDto h11_City_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the H11_City_ReChild object.
        /// </summary>
        /// <param name="h11_City_ReChild">The H11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="H11_City_ReChildDto"/>.</returns>
        H11_City_ReChildDto Update(H11_City_ReChildDto h11_City_ReChild);

        /// <summary>
        /// Deletes the H11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        void Delete(int city_ID2);
    }
}
