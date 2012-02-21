/****** Object:  StoredProcedure [AddB10_City] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB10_City]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB10_City]
GO

CREATE PROCEDURE [AddB10_City]
    @City_ID int OUTPUT,
    @Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateB10_City] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB10_City]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB10_City]
GO

CREATE PROCEDURE [UpdateB10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''B10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO

/****** Object:  StoredProcedure [DeleteB10_City] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB10_City]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB10_City]
GO

CREATE PROCEDURE [DeleteB10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''B10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child B12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child B11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child B11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete B10_City object from 5_Cities */
        DELETE
        FROM [5_Cities]
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
