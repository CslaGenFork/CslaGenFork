using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_City_ReChild type
    /// </summary>
    public partial interface IC11_City_ReChildDal
    {
        /// <summary>
        /// Loads a C11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C11_City_ReChildDto"/> object.</returns>
        C11_City_ReChildDto Fetch(int city_ID2);

        /// <summary>
        /// Inserts a new C11_City_ReChild object in the database.
        /// </summary>
        /// <param name="c11_City_ReChild">The C11 City Re Child DTO.</param>
        /// <returns>The new <see cref="C11_City_ReChildDto"/>.</returns>
        C11_City_ReChildDto Insert(C11_City_ReChildDto c11_City_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the C11_City_ReChild object.
        /// </summary>
        /// <param name="c11_City_ReChild">The C11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="C11_City_ReChildDto"/>.</returns>
        C11_City_ReChildDto Update(C11_City_ReChildDto c11_City_ReChild);

        /// <summary>
        /// Deletes the C11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        void Delete(int city_ID2);
    }
}
