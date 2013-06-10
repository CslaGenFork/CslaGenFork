/****** Object:  StoredProcedure [AddA04_SubContinent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddA04_SubContinent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddA04_SubContinent]
GO

CREATE PROCEDURE [AddA04_SubContinent]
    @SubContinent_ID int OUTPUT,
    @Parent_Continent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents */
        INSERT INTO [2_SubContinents]
        (
            [Parent_Continent_ID],
            [SubContinent_Name]
        )
        VALUES
        (
            @Parent_Continent_ID,
            @SubContinent_Name
        )

        /* Return new primary key */
        SET @SubContinent_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateA04_SubContinent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateA04_SubContinent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateA04_SubContinent]
GO

CREATE PROCEDURE [UpdateA04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''A04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents */
        UPDATE [2_SubContinents]
        SET
            [SubContinent_Name] = @SubContinent_Name
        WHERE
            [SubContinent_ID] = @SubContinent_ID

    END
GO

/****** Object:  StoredProcedure [DeleteA04_SubContinent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteA04_SubContinent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteA04_SubContinent]
GO

CREATE PROCEDURE [DeleteA04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''A04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
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
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete A04_SubContinent object from 2_SubContinents */
        DELETE
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
