/****** Object:  StoredProcedure [GetH03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH03_Continent_ReChild]
GO

CREATE PROCEDURE [GetH03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2 AND
            [1_Continents_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH03_Continent_ReChild]
GO

CREATE PROCEDURE [AddH03_Continent_ReChild]
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

/****** Object:  StoredProcedure [UpdateH03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH03_Continent_ReChild]
GO

CREATE PROCEDURE [UpdateH03_Continent_ReChild]
    @Continent_ID2 int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH03_Continent_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH03_Continent_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH03_Continent_ReChild]
GO

CREATE PROCEDURE [DeleteH03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H03_Continent_ReChild object as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2

    END
GO
