/****** Object:  StoredProcedure [GetD03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD03_Continent_ReChild]
GO

CREATE PROCEDURE [GetD03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2

    END
GO

/****** Object:  StoredProcedure [AddD03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD03_Continent_ReChild]
GO

CREATE PROCEDURE [AddD03_Continent_ReChild]
    @Continent_ID int,
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
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateD03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD03_Continent_ReChild]
GO

CREATE PROCEDURE [UpdateD03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''D03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID

    END
GO

/****** Object:  StoredProcedure [DeleteD03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD03_Continent_ReChild]
GO

CREATE PROCEDURE [DeleteD03_Continent_ReChild]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''D03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D03_Continent_ReChild object from 1_Continents_ReChild */
        DELETE
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID

    END
GO
