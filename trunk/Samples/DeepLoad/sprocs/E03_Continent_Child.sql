/****** Object:  StoredProcedure [AddE03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddE03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddE03_Continent_Child]
GO

CREATE PROCEDURE [AddE03_Continent_Child]
    @Continent_ID1 int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_Child */
        INSERT INTO [1_Continents_Child]
        (
            [Continent_ID1],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID1,
            @Continent_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateE03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateE03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateE03_Continent_Child]
GO

CREATE PROCEDURE [UpdateE03_Continent_Child]
    @Continent_ID1 int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_Child */
        UPDATE [1_Continents_Child]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID1] = @Continent_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteE03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteE03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteE03_Continent_Child]
GO

CREATE PROCEDURE [DeleteE03_Continent_Child]
    @Continent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E03_Continent_Child object as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID1

    END
GO
