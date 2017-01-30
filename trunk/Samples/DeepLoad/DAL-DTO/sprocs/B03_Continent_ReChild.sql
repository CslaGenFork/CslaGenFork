/****** Object:  StoredProcedure [AddB03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB03_Continent_ReChild]
GO

CREATE PROCEDURE [AddB03_Continent_ReChild]
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

/****** Object:  StoredProcedure [UpdateB03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB03_Continent_ReChild]
GO

CREATE PROCEDURE [UpdateB03_Continent_ReChild]
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
                [Continent_ID2] = @Continent_ID2
        )
        BEGIN
            RAISERROR ('''B03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteB03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB03_Continent_ReChild]
GO

CREATE PROCEDURE [DeleteB03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID2
        )
        BEGIN
            RAISERROR ('''B03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B03_Continent_ReChild object from 1_Continents_ReChild */
        DELETE
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2

    END
GO
