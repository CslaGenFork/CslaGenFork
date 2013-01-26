/****** Object:  StoredProcedure [GetA02_Continent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetA02_Continent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetA02_Continent]
GO

CREATE PROCEDURE [GetA02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get A02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A04_SubContinent from table */
        SELECT
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[SubContinent_Child_Name],
            [2_SubContinents_Child].[RowVersion]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_ID2],
            [2_SubContinents_ReChild].[SubContinent_Child_Name],
            [2_SubContinents_ReChild].[RowVersion]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A06_Country from table */
        SELECT
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name],
            [3_Countries].[RowVersion]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_ID1],
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_ID2],
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A08_Region from table */
        SELECT
            [4_Regions].[Parent_Country_ID],
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_ID1],
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_ID2],
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A10_City from table */
        SELECT
            [5_Cities].[Parent_Region_ID],
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_ID1],
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_ID2],
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A12_CityRoad from table */
        SELECT
            [6_CityRoads].[Parent_City_ID],
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO

/****** Object:  StoredProcedure [AddA02_Continent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddA02_Continent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddA02_Continent]
GO

CREATE PROCEDURE [AddA02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateA02_Continent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateA02_Continent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateA02_Continent]
GO

CREATE PROCEDURE [UpdateA02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''A02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO

/****** Object:  StoredProcedure [DeleteA02_Continent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteA02_Continent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteA02_Continent]
GO

CREATE PROCEDURE [DeleteA02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''A02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child A12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A04_SubContinent from 2_SubContinents */
        DELETE
            [2_SubContinents]
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A03_Continent_ReChild from 1_Continents_ReChild */
        DELETE
            [1_Continents_ReChild]
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A03_Continent_Child from 1_Continents_Child */
        DELETE
            [1_Continents_Child]
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete A02_Continent object from 1_Continents */
        DELETE
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
