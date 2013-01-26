using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadROSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F01_ContinentColl type
    /// </summary>
    public partial interface IF01_ContinentCollDal
    {
        /// <summary>
        /// Gets the F03 Continent Single Object.
        /// </summary>
        /// <value>A list of <see cref="F03_Continent_ChildDto"/>.</value>
        List<F03_Continent_ChildDto> F03_Continent_Child { get; }

        /// <summary>
        /// Gets the F03 Continent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F03_Continent_ReChildDto"/>.</value>
        List<F03_Continent_ReChildDto> F03_Continent_ReChild { get; }

        /// <summary>
        /// Gets the F03 SubContinent Objects.
        /// </summary>
        /// <value>A list of <see cref="F04_SubContinentDto"/>.</value>
        List<F04_SubContinentDto> F03_SubContinentColl { get; }

        /// <summary>
        /// Gets the F05 SubContinent Single Object.
        /// </summary>
        /// <value>A list of <see cref="F05_SubContinent_ChildDto"/>.</value>
        List<F05_SubContinent_ChildDto> F05_SubContinent_Child { get; }

        /// <summary>
        /// Gets the F05 SubContinent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F05_SubContinent_ReChildDto"/>.</value>
        List<F05_SubContinent_ReChildDto> F05_SubContinent_ReChild { get; }

        /// <summary>
        /// Gets the F05 Country Objects.
        /// </summary>
        /// <value>A list of <see cref="F06_CountryDto"/>.</value>
        List<F06_CountryDto> F05_CountryColl { get; }

        /// <summary>
        /// Gets the F07 Country Single Object.
        /// </summary>
        /// <value>A list of <see cref="F07_Country_ChildDto"/>.</value>
        List<F07_Country_ChildDto> F07_Country_Child { get; }

        /// <summary>
        /// Gets the F07 Country ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F07_Country_ReChildDto"/>.</value>
        List<F07_Country_ReChildDto> F07_Country_ReChild { get; }

        /// <summary>
        /// Gets the F07 Region Objects.
        /// </summary>
        /// <value>A list of <see cref="F08_RegionDto"/>.</value>
        List<F08_RegionDto> F07_RegionColl { get; }

        /// <summary>
        /// Gets the F09 Region Single Object.
        /// </summary>
        /// <value>A list of <see cref="F09_Region_ChildDto"/>.</value>
        List<F09_Region_ChildDto> F09_Region_Child { get; }

        /// <summary>
        /// Gets the F09 Region ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F09_Region_ReChildDto"/>.</value>
        List<F09_Region_ReChildDto> F09_Region_ReChild { get; }

        /// <summary>
        /// Gets the F09 City Objects.
        /// </summary>
        /// <value>A list of <see cref="F10_CityDto"/>.</value>
        List<F10_CityDto> F09_CityColl { get; }

        /// <summary>
        /// Gets the F11 City Single Object.
        /// </summary>
        /// <value>A list of <see cref="F11_City_ChildDto"/>.</value>
        List<F11_City_ChildDto> F11_City_Child { get; }

        /// <summary>
        /// Gets the F11 City ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F11_City_ReChildDto"/>.</value>
        List<F11_City_ReChildDto> F11_City_ReChild { get; }

        /// <summary>
        /// Gets the F11 CityRoad Objects.
        /// </summary>
        /// <value>A list of <see cref="F12_CityRoadDto"/>.</value>
        List<F12_CityRoadDto> F11_CityRoadColl { get; }

        /// <summary>
        /// Loads a F01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="F02_ContinentDto"/>.</returns>
        List<F02_ContinentDto> Fetch();
    }
}
