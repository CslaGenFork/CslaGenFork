using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G12_CityRoad type
    /// </summary>
    public partial interface IG12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new G12_CityRoad object in the database.
        /// </summary>
        /// <param name="g12_CityRoad">The G12 City Road DTO.</param>
        /// <returns>The new <see cref="G12_CityRoadDto"/>.</returns>
        G12_CityRoadDto Insert(G12_CityRoadDto g12_CityRoad);

        /// <summary>
        /// Updates in the database all changes made to the G12_CityRoad object.
        /// </summary>
        /// <param name="g12_CityRoad">The G12 City Road DTO.</param>
        /// <returns>The updated <see cref="G12_CityRoadDto"/>.</returns>
        G12_CityRoadDto Update(G12_CityRoadDto g12_CityRoad);

        /// <summary>
        /// Deletes the G12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
