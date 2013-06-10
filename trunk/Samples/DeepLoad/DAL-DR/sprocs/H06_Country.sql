/****** Object:  StoredProcedure [AddH06_Country] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH06_Country]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH06_Country]
GO

CREATE PROCEDURE [AddH06_Country]
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

/****** Object:  StoredProcedure [UpdateH06_Country] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH06_Country]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH06_Country]
GO

CREATE PROCEDURE [UpdateH06_Country]
    @Country_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H06_Country'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH06_Country] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH06_Country]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH06_Country]
GO

CREATE PROCEDURE [DeleteH06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child H12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark H06_Country object as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
