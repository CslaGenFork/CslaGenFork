using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G10_City type
    /// </summary>
    public partial interface IG10_CityDal
    {
        /// <summary>
        /// Inserts a new G10_City object in the database.
        /// </summary>
        /// <param name="g10_City">The G10 City DTO.</param>
        /// <returns>The new <see cref="G10_CityDto"/>.</returns>
        G10_CityDto Insert(G10_CityDto g10_City);

        /// <summary>
        /// Updates in the database all changes made to the G10_City object.
        /// </summary>
        /// <param name="g10_City">The G10 City DTO.</param>
        /// <returns>The updated <see cref="G10_CityDto"/>.</returns>
        G10_CityDto Update(G10_CityDto g10_City);

        /// <summary>
        /// Deletes the G10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
