/****** Object:  StoredProcedure [AddF04_SubContinent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF04_SubContinent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF04_SubContinent]
GO

CREATE PROCEDURE [AddF04_SubContinent]
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

/****** Object:  StoredProcedure [UpdateF04_SubContinent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF04_SubContinent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF04_SubContinent]
GO

CREATE PROCEDURE [UpdateF04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteF04_SubContinent] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF04_SubContinent]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF04_SubContinent]
GO

CREATE PROCEDURE [DeleteF04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark F04_SubContinent object as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
