/****** Object:  StoredProcedure [AddB06_Country] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB06_Country]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB06_Country]
GO

CREATE PROCEDURE [AddB06_Country]
    @Country_ID int OUTPUT,
    @Parent_SubContinent_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @Parent_SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateB06_Country] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB06_Country]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB06_Country]
GO

CREATE PROCEDURE [UpdateB06_Country]
    @Country_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''B06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name
        WHERE
            [Country_ID] = @Country_ID

    END
GO

/****** Object:  StoredProcedure [DeleteB06_Country] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB06_Country]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB06_Country]
GO

CREATE PROCEDURE [DeleteB06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''B06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child B12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete B06_Country object from 3_Countries */
        DELETE
        FROM [3_Countries]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
