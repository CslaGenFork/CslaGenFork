using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadRO.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B01_ContinentColl type
    /// </summary>
    public partial interface IB01_ContinentCollDal
    {
        /// <summary>
        /// Gets the B03 Continent Single Object.
        /// </summary>
        /// <value>A list of <see cref="B03_Continent_ChildDto"/>.</value>
        List<B03_Continent_ChildDto> B03_Continent_Child { get; }

        /// <summary>
        /// Gets the B03 Continent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B03_Continent_ReChildDto"/>.</value>
        List<B03_Continent_ReChildDto> B03_Continent_ReChild { get; }

        /// <summary>
        /// Gets the B03 SubContinent Objects.
        /// </summary>
        /// <value>A list of <see cref="B04_SubContinentDto"/>.</value>
        List<B04_SubContinentDto> B03_SubContinentColl { get; }

        /// <summary>
        /// Gets the B05 SubContinent Single Object.
        /// </summary>
        /// <value>A list of <see cref="B05_SubContinent_ChildDto"/>.</value>
        List<B05_SubContinent_ChildDto> B05_SubContinent_Child { get; }

        /// <summary>
        /// Gets the B05 SubContinent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B05_SubContinent_ReChildDto"/>.</value>
        List<B05_SubContinent_ReChildDto> B05_SubContinent_ReChild { get; }

        /// <summary>
        /// Gets the B05 Country Objects.
        /// </summary>
        /// <value>A list of <see cref="B06_CountryDto"/>.</value>
        List<B06_CountryDto> B05_CountryColl { get; }

        /// <summary>
        /// Gets the B07 Country Single Object.
        /// </summary>
        /// <value>A list of <see cref="B07_Country_ChildDto"/>.</value>
        List<B07_Country_ChildDto> B07_Country_Child { get; }

        /// <summary>
        /// Gets the B07 Country ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B07_Country_ReChildDto"/>.</value>
        List<B07_Country_ReChildDto> B07_Country_ReChild { get; }

        /// <summary>
        /// Gets the B07 Region Objects.
        /// </summary>
        /// <value>A list of <see cref="B08_RegionDto"/>.</value>
        List<B08_RegionDto> B07_RegionColl { get; }

        /// <summary>
        /// Gets the B09 Region Single Object.
        /// </summary>
        /// <value>A list of <see cref="B09_Region_ChildDto"/>.</value>
        List<B09_Region_ChildDto> B09_Region_Child { get; }

        /// <summary>
        /// Gets the B09 Region ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B09_Region_ReChildDto"/>.</value>
        List<B09_Region_ReChildDto> B09_Region_ReChild { get; }

        /// <summary>
        /// Gets the B09 City Objects.
        /// </summary>
        /// <value>A list of <see cref="B10_CityDto"/>.</value>
        List<B10_CityDto> B09_CityColl { get; }

        /// <summary>
        /// Gets the B11 City Single Object.
        /// </summary>
        /// <value>A list of <see cref="B11_City_ChildDto"/>.</value>
        List<B11_City_ChildDto> B11_City_Child { get; }

        /// <summary>
        /// Gets the B11 City ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B11_City_ReChildDto"/>.</value>
        List<B11_City_ReChildDto> B11_City_ReChild { get; }

        /// <summary>
        /// Gets the B11 CityRoad Objects.
        /// </summary>
        /// <value>A list of <see cref="B12_CityRoadDto"/>.</value>
        List<B12_CityRoadDto> B11_CityRoadColl { get; }

        /// <summary>
        /// Loads a B01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="B02_ContinentDto"/>.</returns>
        List<B02_ContinentDto> Fetch();
    }
}
