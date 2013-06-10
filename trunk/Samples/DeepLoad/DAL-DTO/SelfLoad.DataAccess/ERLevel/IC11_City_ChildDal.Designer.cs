using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_City_Child type
    /// </summary>
    public partial interface IC11_City_ChildDal
    {
        /// <summary>
        /// Loads a C11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C11_City_ChildDto"/> object.</returns>
        C11_City_ChildDto Fetch(int city_ID1);

        /// <summary>
        /// Inserts a new C11_City_Child object in the database.
        /// </summary>
        /// <param name="c11_City_Child">The C11 City Child DTO.</param>
        /// <returns>The new <see cref="C11_City_ChildDto"/>.</returns>
        C11_City_ChildDto Insert(C11_City_ChildDto c11_City_Child);

        /// <summary>
        /// Updates in the database all changes made to the C11_City_Child object.
        /// </summary>
        /// <param name="c11_City_Child">The C11 City Child DTO.</param>
        /// <returns>The updated <see cref="C11_City_ChildDto"/>.</returns>
        C11_City_ChildDto Update(C11_City_ChildDto c11_City_Child);

        /// <summary>
        /// Deletes the C11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        void Delete(int city_ID1);
    }
}
