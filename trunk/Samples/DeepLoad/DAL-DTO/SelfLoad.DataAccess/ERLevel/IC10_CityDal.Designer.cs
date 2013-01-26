using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C10_City type
    /// </summary>
    public partial interface IC10_CityDal
    {
        /// <summary>
        /// Inserts a new C10_City object in the database.
        /// </summary>
        /// <param name="c10_City">The C10 City DTO.</param>
        /// <returns>The new <see cref="C10_CityDto"/>.</returns>
        C10_CityDto Insert(C10_CityDto c10_City);

        /// <summary>
        /// Updates in the database all changes made to the C10_City object.
        /// </summary>
        /// <param name="c10_City">The C10 City DTO.</param>
        /// <returns>The updated <see cref="C10_CityDto"/>.</returns>
        C10_CityDto Update(C10_CityDto c10_City);

        /// <summary>
        /// Deletes the C10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
