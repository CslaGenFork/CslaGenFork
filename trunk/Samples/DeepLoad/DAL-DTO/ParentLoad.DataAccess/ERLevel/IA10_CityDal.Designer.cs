using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A10_City type
    /// </summary>
    public partial interface IA10_CityDal
    {
        /// <summary>
        /// Inserts a new A10_City object in the database.
        /// </summary>
        /// <param name="a10_City">The A10 City DTO.</param>
        /// <returns>The new <see cref="A10_CityDto"/>.</returns>
        A10_CityDto Insert(A10_CityDto a10_City);

        /// <summary>
        /// Updates in the database all changes made to the A10_City object.
        /// </summary>
        /// <param name="a10_City">The A10 City DTO.</param>
        /// <returns>The updated <see cref="A10_CityDto"/>.</returns>
        A10_CityDto Update(A10_CityDto a10_City);

        /// <summary>
        /// Deletes the A10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
