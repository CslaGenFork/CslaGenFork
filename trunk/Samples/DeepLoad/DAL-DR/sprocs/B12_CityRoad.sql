/****** Object:  StoredProcedure [AddB12_CityRoad] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB12_CityRoad]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB12_CityRoad]
GO

CREATE PROCEDURE [AddB12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @City_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 6_CityRoads */
        INSERT INTO [6_CityRoads]
        (
            [Parent_City_ID],
            [CityRoad_Name]
        )
        VALUES
        (
            @City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateB12_CityRoad] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB12_CityRoad]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB12_CityRoad]
GO

CREATE PROCEDURE [UpdateB12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''B12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 6_CityRoads */
        UPDATE [6_CityRoads]
        SET
            [CityRoad_Name] = @CityRoad_Name
        WHERE
            [CityRoad_ID] = @CityRoad_ID

    END
GO

/****** Object:  StoredProcedure [DeleteB12_CityRoad] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB12_CityRoad]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB12_CityRoad]
GO

CREATE PROCEDURE [DeleteB12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''B12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B12_CityRoad object from 6_CityRoads */
        DELETE
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
