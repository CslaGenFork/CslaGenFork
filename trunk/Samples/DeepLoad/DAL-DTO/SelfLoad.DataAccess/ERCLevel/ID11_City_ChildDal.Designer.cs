using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D11_City_Child type
    /// </summary>
    public partial interface ID11_City_ChildDal
    {
        /// <summary>
        /// Loads a D11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D11_City_ChildDto"/> object.</returns>
        D11_City_ChildDto Fetch(int city_ID1);

        /// <summary>
        /// Inserts a new D11_City_Child object in the database.
        /// </summary>
        /// <param name="d11_City_Child">The D11 City Child DTO.</param>
        /// <returns>The new <see cref="D11_City_ChildDto"/>.</returns>
        D11_City_ChildDto Insert(D11_City_ChildDto d11_City_Child);

        /// <summary>
        /// Updates in the database all changes made to the D11_City_Child object.
        /// </summary>
        /// <param name="d11_City_Child">The D11 City Child DTO.</param>
        /// <returns>The updated <see cref="D11_City_ChildDto"/>.</returns>
        D11_City_ChildDto Update(D11_City_ChildDto d11_City_Child);

        /// <summary>
        /// Deletes the D11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        void Delete(int city_ID1);
    }
}
