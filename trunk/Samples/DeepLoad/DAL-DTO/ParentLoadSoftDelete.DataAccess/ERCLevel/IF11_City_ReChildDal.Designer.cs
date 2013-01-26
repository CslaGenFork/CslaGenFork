using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F11_City_ReChild type
    /// </summary>
    public partial interface IF11_City_ReChildDal
    {
        /// <summary>
        /// Inserts a new F11_City_ReChild object in the database.
        /// </summary>
        /// <param name="f11_City_ReChild">The F11 City Re Child DTO.</param>
        /// <returns>The new <see cref="F11_City_ReChildDto"/>.</returns>
        F11_City_ReChildDto Insert(F11_City_ReChildDto f11_City_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the F11_City_ReChild object.
        /// </summary>
        /// <param name="f11_City_ReChild">The F11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="F11_City_ReChildDto"/>.</returns>
        F11_City_ReChildDto Update(F11_City_ReChildDto f11_City_ReChild);

        /// <summary>
        /// Deletes the F11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        void Delete(int city_ID);
    }
}
