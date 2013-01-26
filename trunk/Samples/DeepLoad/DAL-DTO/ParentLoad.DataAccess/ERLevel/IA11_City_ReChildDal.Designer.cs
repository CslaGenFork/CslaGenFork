using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A11_City_ReChild type
    /// </summary>
    public partial interface IA11_City_ReChildDal
    {
        /// <summary>
        /// Inserts a new A11_City_ReChild object in the database.
        /// </summary>
        /// <param name="a11_City_ReChild">The A11 City Re Child DTO.</param>
        /// <returns>The new <see cref="A11_City_ReChildDto"/>.</returns>
        A11_City_ReChildDto Insert(A11_City_ReChildDto a11_City_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the A11_City_ReChild object.
        /// </summary>
        /// <param name="a11_City_ReChild">The A11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="A11_City_ReChildDto"/>.</returns>
        A11_City_ReChildDto Update(A11_City_ReChildDto a11_City_ReChild);

        /// <summary>
        /// Deletes the A11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        void Delete(int city_ID);
    }
}
