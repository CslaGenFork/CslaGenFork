using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H12_CityRoad type
    /// </summary>
    public partial interface IH12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new H12_CityRoad object in the database.
        /// </summary>
        /// <param name="h12_CityRoad">The H12 City Road DTO.</param>
        /// <returns>The new <see cref="H12_CityRoadDto"/>.</returns>
        H12_CityRoadDto Insert(H12_CityRoadDto h12_CityRoad);

        /// <summary>
        /// Updates in the database all changes made to the H12_CityRoad object.
        /// </summary>
        /// <param name="h12_CityRoad">The H12 City Road DTO.</param>
        /// <returns>The updated <see cref="H12_CityRoadDto"/>.</returns>
        H12_CityRoadDto Update(H12_CityRoadDto h12_CityRoad);

        /// <summary>
        /// Deletes the H12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
