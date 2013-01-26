using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B11_City_Child type
    /// </summary>
    public partial interface IB11_City_ChildDal
    {
        /// <summary>
        /// Inserts a new B11_City_Child object in the database.
        /// </summary>
        /// <param name="b11_City_Child">The B11 City Child DTO.</param>
        /// <returns>The new <see cref="B11_City_ChildDto"/>.</returns>
        B11_City_ChildDto Insert(B11_City_ChildDto b11_City_Child);

        /// <summary>
        /// Updates in the database all changes made to the B11_City_Child object.
        /// </summary>
        /// <param name="b11_City_Child">The B11 City Child DTO.</param>
        /// <returns>The updated <see cref="B11_City_ChildDto"/>.</returns>
        B11_City_ChildDto Update(B11_City_ChildDto b11_City_Child);

        /// <summary>
        /// Deletes the B11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        void Delete(int city_ID);
    }
}
