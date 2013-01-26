using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H11_City_Child type
    /// </summary>
    public partial interface IH11_City_ChildDal
    {
        /// <summary>
        /// Loads a H11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H11_City_ChildDto"/> object.</returns>
        H11_City_ChildDto Fetch(int city_ID1);

        /// <summary>
        /// Inserts a new H11_City_Child object in the database.
        /// </summary>
        /// <param name="h11_City_Child">The H11 City Child DTO.</param>
        /// <returns>The new <see cref="H11_City_ChildDto"/>.</returns>
        H11_City_ChildDto Insert(H11_City_ChildDto h11_City_Child);

        /// <summary>
        /// Updates in the database all changes made to the H11_City_Child object.
        /// </summary>
        /// <param name="h11_City_Child">The H11 City Child DTO.</param>
        /// <returns>The updated <see cref="H11_City_ChildDto"/>.</returns>
        H11_City_ChildDto Update(H11_City_ChildDto h11_City_Child);

        /// <summary>
        /// Deletes the H11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        void Delete(int city_ID);
    }
}
