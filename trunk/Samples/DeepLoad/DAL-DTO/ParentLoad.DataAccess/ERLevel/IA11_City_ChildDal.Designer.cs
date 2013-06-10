using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A11_City_Child type
    /// </summary>
    public partial interface IA11_City_ChildDal
    {
        /// <summary>
        /// Inserts a new A11_City_Child object in the database.
        /// </summary>
        /// <param name="a11_City_Child">The A11 City Child DTO.</param>
        /// <returns>The new <see cref="A11_City_ChildDto"/>.</returns>
        A11_City_ChildDto Insert(A11_City_ChildDto a11_City_Child);

        /// <summary>
        /// Updates in the database all changes made to the A11_City_Child object.
        /// </summary>
        /// <param name="a11_City_Child">The A11 City Child DTO.</param>
        /// <returns>The updated <see cref="A11_City_ChildDto"/>.</returns>
        A11_City_ChildDto Update(A11_City_ChildDto a11_City_Child);

        /// <summary>
        /// Deletes the A11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        void Delete(int city_ID1);
    }
}
