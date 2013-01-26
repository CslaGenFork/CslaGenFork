using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D10_City type
    /// </summary>
    public partial interface ID10_CityDal
    {
        /// <summary>
        /// Inserts a new D10_City object in the database.
        /// </summary>
        /// <param name="d10_City">The D10 City DTO.</param>
        /// <returns>The new <see cref="D10_CityDto"/>.</returns>
        D10_CityDto Insert(D10_CityDto d10_City);

        /// <summary>
        /// Updates in the database all changes made to the D10_City object.
        /// </summary>
        /// <param name="d10_City">The D10 City DTO.</param>
        /// <returns>The updated <see cref="D10_CityDto"/>.</returns>
        D10_CityDto Update(D10_CityDto d10_City);

        /// <summary>
        /// Deletes the D10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
