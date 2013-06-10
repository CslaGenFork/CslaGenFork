using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G11_City_Child type
    /// </summary>
    public partial interface IG11_City_ChildDal
    {
        /// <summary>
        /// Loads a G11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="G11_City_ChildDto"/> object.</returns>
        G11_City_ChildDto Fetch(int city_ID1);

        /// <summary>
        /// Inserts a new G11_City_Child object in the database.
        /// </summary>
        /// <param name="g11_City_Child">The G11 City Child DTO.</param>
        /// <returns>The new <see cref="G11_City_ChildDto"/>.</returns>
        G11_City_ChildDto Insert(G11_City_ChildDto g11_City_Child);

        /// <summary>
        /// Updates in the database all changes made to the G11_City_Child object.
        /// </summary>
        /// <param name="g11_City_Child">The G11 City Child DTO.</param>
        /// <returns>The updated <see cref="G11_City_ChildDto"/>.</returns>
        G11_City_ChildDto Update(G11_City_ChildDto g11_City_Child);

        /// <summary>
        /// Deletes the G11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        void Delete(int city_ID1);
    }
}
