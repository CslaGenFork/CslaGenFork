using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D11_City_ReChild type
    /// </summary>
    public partial interface ID11_City_ReChildDal
    {
        /// <summary>
        /// Loads a D11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D11_City_ReChildDto"/> object.</returns>
        D11_City_ReChildDto Fetch(int city_ID2);

        /// <summary>
        /// Inserts a new D11_City_ReChild object in the database.
        /// </summary>
        /// <param name="d11_City_ReChild">The D11 City Re Child DTO.</param>
        /// <returns>The new <see cref="D11_City_ReChildDto"/>.</returns>
        D11_City_ReChildDto Insert(D11_City_ReChildDto d11_City_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the D11_City_ReChild object.
        /// </summary>
        /// <param name="d11_City_ReChild">The D11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="D11_City_ReChildDto"/>.</returns>
        D11_City_ReChildDto Update(D11_City_ReChildDto d11_City_ReChild);

        /// <summary>
        /// Deletes the D11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        void Delete(int city_ID2);
    }
}
