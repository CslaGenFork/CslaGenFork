using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B10_City type
    /// </summary>
    public partial interface IB10_CityDal
    {
        /// <summary>
        /// Inserts a new B10_City object in the database.
        /// </summary>
        /// <param name="b10_City">The B10 City DTO.</param>
        /// <returns>The new <see cref="B10_CityDto"/>.</returns>
        B10_CityDto Insert(B10_CityDto b10_City);

        /// <summary>
        /// Updates in the database all changes made to the B10_City object.
        /// </summary>
        /// <param name="b10_City">The B10 City DTO.</param>
        /// <returns>The updated <see cref="B10_CityDto"/>.</returns>
        B10_CityDto Update(B10_CityDto b10_City);

        /// <summary>
        /// Deletes the B10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
