using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H10_City type
    /// </summary>
    public partial interface IH10_CityDal
    {
        /// <summary>
        /// Inserts a new H10_City object in the database.
        /// </summary>
        /// <param name="h10_City">The H10 City DTO.</param>
        /// <returns>The new <see cref="H10_CityDto"/>.</returns>
        H10_CityDto Insert(H10_CityDto h10_City);

        /// <summary>
        /// Updates in the database all changes made to the H10_City object.
        /// </summary>
        /// <param name="h10_City">The H10 City DTO.</param>
        /// <returns>The updated <see cref="H10_CityDto"/>.</returns>
        H10_CityDto Update(H10_CityDto h10_City);

        /// <summary>
        /// Deletes the H10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
