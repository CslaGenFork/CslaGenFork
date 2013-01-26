using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E11_City_Child type
    /// </summary>
    public partial interface IE11_City_ChildDal
    {
        /// <summary>
        /// Inserts a new E11_City_Child object in the database.
        /// </summary>
        /// <param name="e11_City_Child">The E11 City Child DTO.</param>
        /// <returns>The new <see cref="E11_City_ChildDto"/>.</returns>
        E11_City_ChildDto Insert(E11_City_ChildDto e11_City_Child);

        /// <summary>
        /// Updates in the database all changes made to the E11_City_Child object.
        /// </summary>
        /// <param name="e11_City_Child">The E11 City Child DTO.</param>
        /// <returns>The updated <see cref="E11_City_ChildDto"/>.</returns>
        E11_City_ChildDto Update(E11_City_ChildDto e11_City_Child);

        /// <summary>
        /// Deletes the E11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        void Delete(int city_ID);
    }
}
