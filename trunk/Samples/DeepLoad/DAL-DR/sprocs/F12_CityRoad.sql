/****** Object:  StoredProcedure [AddF12_CityRoad] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF12_CityRoad]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF12_CityRoad]
GO

CREATE PROCEDURE [AddF12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @Parent_City_ID int,
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
            @Parent_City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateF12_CityRoad] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF12_CityRoad]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF12_CityRoad]
GO

CREATE PROCEDURE [UpdateF12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteF12_CityRoad] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF12_CityRoad]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF12_CityRoad]
GO

CREATE PROCEDURE [DeleteF12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F12_CityRoad object as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
