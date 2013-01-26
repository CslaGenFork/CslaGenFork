using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F10_City type
    /// </summary>
    public partial interface IF10_CityDal
    {
        /// <summary>
        /// Inserts a new F10_City object in the database.
        /// </summary>
        /// <param name="f10_City">The F10 City DTO.</param>
        /// <returns>The new <see cref="F10_CityDto"/>.</returns>
        F10_CityDto Insert(F10_CityDto f10_City);

        /// <summary>
        /// Updates in the database all changes made to the F10_City object.
        /// </summary>
        /// <param name="f10_City">The F10 City DTO.</param>
        /// <returns>The updated <see cref="F10_CityDto"/>.</returns>
        F10_CityDto Update(F10_CityDto f10_City);

        /// <summary>
        /// Deletes the F10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
