using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A02_Continent type
    /// </summary>
    public partial interface IA02_ContinentDal
    {
        /// <summary>
        /// Gets the A03 Continent Single Object.
        /// </summary>
        /// <value>A <see cref="A03_Continent_ChildDto"/> object.</value>
        A03_Continent_ChildDto A03_Continent_Child { get; }

        /// <summary>
        /// Gets the A03 Continent ASingle Object.
        /// </summary>
        /// <value>A <see cref="A03_Continent_ReChildDto"/> object.</value>
        A03_Continent_ReChildDto A03_Continent_ReChild { get; }

        /// <summary>
        /// Gets the A03 SubContinent Objects.
        /// </summary>
        /// <value>A list of <see cref="A04_SubContinentDto"/>.</value>
        List<A04_SubContinentDto> A03_SubContinentColl { get; }

        /// <summary>
        /// Gets the A05 SubContinent Single Object.
        /// </summary>
        /// <value>A list of <see cref="A05_SubContinent_ChildDto"/>.</value>
        List<A05_SubContinent_ChildDto> A05_SubContinent_Child { get; }

        /// <summary>
        /// Gets the A05 SubContinent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="A05_SubContinent_ReChildDto"/>.</value>
        List<A05_SubContinent_ReChildDto> A05_SubContinent_ReChild { get; }

        /// <summary>
        /// Gets the A05 Country Objects.
        /// </summary>
        /// <value>A list of <see cref="A06_CountryDto"/>.</value>
        List<A06_CountryDto> A05_CountryColl { get; }

        /// <summary>
        /// Gets the A07 Country Single Object.
        /// </summary>
        /// <value>A list of <see cref="A07_Country_ChildDto"/>.</value>
        List<A07_Country_ChildDto> A07_Country_Child { get; }

        /// <summary>
        /// Gets the A07 Country ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="A07_Country_ReChildDto"/>.</value>
        List<A07_Country_ReChildDto> A07_Country_ReChild { get; }

        /// <summary>
        /// Gets the A07 Region Objects.
        /// </summary>
        /// <value>A list of <see cref="A08_RegionDto"/>.</value>
        List<A08_RegionDto> A07_RegionColl { get; }

        /// <summary>
        /// Gets the A09 Region Single Object.
        /// </summary>
        /// <value>A list of <see cref="A09_Region_ChildDto"/>.</value>
        List<A09_Region_ChildDto> A09_Region_Child { get; }

        /// <summary>
        /// Gets the A09 Region ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="A09_Region_ReChildDto"/>.</value>
        List<A09_Region_ReChildDto> A09_Region_ReChild { get; }

        /// <summary>
        /// Gets the A09 City Objects.
        /// </summary>
        /// <value>A list of <see cref="A10_CityDto"/>.</value>
        List<A10_CityDto> A09_CityColl { get; }

        /// <summary>
        /// Gets the A11 City Single Object.
        /// </summary>
        /// <value>A list of <see cref="A11_City_ChildDto"/>.</value>
        List<A11_City_ChildDto> A11_City_Child { get; }

        /// <summary>
        /// Gets the A11 City ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="A11_City_ReChildDto"/>.</value>
        List<A11_City_ReChildDto> A11_City_ReChild { get; }

        /// <summary>
        /// Gets the A11 CityRoad Objects.
        /// </summary>
        /// <value>A list of <see cref="A12_CityRoadDto"/>.</value>
        List<A12_CityRoadDto> A11_CityRoadColl { get; }

        /// <summary>
        /// Loads a A02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A <see cref="A02_ContinentDto"/> object.</returns>
        A02_ContinentDto Fetch(int continent_ID);
    }
}
