using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E10_City type
    /// </summary>
    public partial interface IE10_CityDal
    {
        /// <summary>
        /// Inserts a new E10_City object in the database.
        /// </summary>
        /// <param name="e10_City">The E10 City DTO.</param>
        /// <returns>The new <see cref="E10_CityDto"/>.</returns>
        E10_CityDto Insert(E10_CityDto e10_City);

        /// <summary>
        /// Updates in the database all changes made to the E10_City object.
        /// </summary>
        /// <param name="e10_City">The E10 City DTO.</param>
        /// <returns>The updated <see cref="E10_CityDto"/>.</returns>
        E10_CityDto Update(E10_CityDto e10_City);

        /// <summary>
        /// Deletes the E10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
