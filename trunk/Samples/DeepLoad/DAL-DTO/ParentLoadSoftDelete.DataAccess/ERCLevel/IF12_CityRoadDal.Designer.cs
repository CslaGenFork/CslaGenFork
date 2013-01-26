using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F12_CityRoad type
    /// </summary>
    public partial interface IF12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new F12_CityRoad object in the database.
        /// </summary>
        /// <param name="f12_CityRoad">The F12 City Road DTO.</param>
        /// <returns>The new <see cref="F12_CityRoadDto"/>.</returns>
        F12_CityRoadDto Insert(F12_CityRoadDto f12_CityRoad);

        /// <summary>
        /// Updates in the database all changes made to the F12_CityRoad object.
        /// </summary>
        /// <param name="f12_CityRoad">The F12 City Road DTO.</param>
        /// <returns>The updated <see cref="F12_CityRoadDto"/>.</returns>
        F12_CityRoadDto Update(F12_CityRoadDto f12_CityRoad);

        /// <summary>
        /// Deletes the F12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
