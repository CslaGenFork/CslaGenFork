using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B11_City_ReChild type
    /// </summary>
    public partial interface IB11_City_ReChildDal
    {
        /// <summary>
        /// Inserts a new B11_City_ReChild object in the database.
        /// </summary>
        /// <param name="b11_City_ReChild">The B11 City Re Child DTO.</param>
        /// <returns>The new <see cref="B11_City_ReChildDto"/>.</returns>
        B11_City_ReChildDto Insert(B11_City_ReChildDto b11_City_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the B11_City_ReChild object.
        /// </summary>
        /// <param name="b11_City_ReChild">The B11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="B11_City_ReChildDto"/>.</returns>
        B11_City_ReChildDto Update(B11_City_ReChildDto b11_City_ReChild);

        /// <summary>
        /// Deletes the B11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        void Delete(int city_ID2);
    }
}
