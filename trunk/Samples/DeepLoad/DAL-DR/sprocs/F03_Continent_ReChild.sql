/****** Object:  StoredProcedure [AddF03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF03_Continent_ReChild]
GO

CREATE PROCEDURE [AddF03_Continent_ReChild]
    @Continent_ID2 int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID2,
            @Continent_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateF03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF03_Continent_ReChild]
GO

CREATE PROCEDURE [UpdateF03_Continent_ReChild]
    @Continent_ID2 int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID2

    END
GO

/****** Object:  StoredProcedure [DeleteF03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF03_Continent_ReChild]
GO

CREATE PROCEDURE [DeleteF03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F03_Continent_ReChild object as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2

    END
GO
