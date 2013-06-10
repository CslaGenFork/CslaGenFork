using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E11_City_ReChild type
    /// </summary>
    public partial interface IE11_City_ReChildDal
    {
        /// <summary>
        /// Inserts a new E11_City_ReChild object in the database.
        /// </summary>
        /// <param name="e11_City_ReChild">The E11 City Re Child DTO.</param>
        /// <returns>The new <see cref="E11_City_ReChildDto"/>.</returns>
        E11_City_ReChildDto Insert(E11_City_ReChildDto e11_City_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the E11_City_ReChild object.
        /// </summary>
        /// <param name="e11_City_ReChild">The E11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="E11_City_ReChildDto"/>.</returns>
        E11_City_ReChildDto Update(E11_City_ReChildDto e11_City_ReChild);

        /// <summary>
        /// Deletes the E11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        void Delete(int city_ID2);
    }
}
