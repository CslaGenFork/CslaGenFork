/****** Object:  StoredProcedure [AddF08_Region] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF08_Region]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF08_Region]
GO

CREATE PROCEDURE [AddF08_Region]
    @Region_ID int OUTPUT,
    @Parent_Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Parent_Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateF08_Region] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF08_Region]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF08_Region]
GO

CREATE PROCEDURE [UpdateF08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO

/****** Object:  StoredProcedure [DeleteF08_Region] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF08_Region]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF08_Region]
GO

CREATE PROCEDURE [DeleteF08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark F08_Region object as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
