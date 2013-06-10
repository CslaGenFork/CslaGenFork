using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F11_City_Child type
    /// </summary>
    public partial interface IF11_City_ChildDal
    {
        /// <summary>
        /// Inserts a new F11_City_Child object in the database.
        /// </summary>
        /// <param name="f11_City_Child">The F11 City Child DTO.</param>
        /// <returns>The new <see cref="F11_City_ChildDto"/>.</returns>
        F11_City_ChildDto Insert(F11_City_ChildDto f11_City_Child);

        /// <summary>
        /// Updates in the database all changes made to the F11_City_Child object.
        /// </summary>
        /// <param name="f11_City_Child">The F11 City Child DTO.</param>
        /// <returns>The updated <see cref="F11_City_ChildDto"/>.</returns>
        F11_City_ChildDto Update(F11_City_ChildDto f11_City_Child);

        /// <summary>
        /// Deletes the F11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        void Delete(int city_ID1);
    }
}
