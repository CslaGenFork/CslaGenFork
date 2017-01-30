/****** Object:  StoredProcedure [AddH12_CityRoad] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH12_CityRoad]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH12_CityRoad]
GO

CREATE PROCEDURE [AddH12_CityRoad]
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

/****** Object:  StoredProcedure [UpdateH12_CityRoad] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH12_CityRoad]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH12_CityRoad]
GO

CREATE PROCEDURE [UpdateH12_CityRoad]
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
            RAISERROR ('''H12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH12_CityRoad] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH12_CityRoad]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH12_CityRoad]
GO

CREATE PROCEDURE [DeleteH12_CityRoad]
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
            RAISERROR ('''H12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H12_CityRoad object as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
