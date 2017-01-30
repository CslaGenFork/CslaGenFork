/****** Object:  StoredProcedure [GetH03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH03_Continent_Child]
GO

CREATE PROCEDURE [GetH03_Continent_Child]
    @Continent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID1 AND
            [1_Continents_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH03_Continent_Child]
GO

CREATE PROCEDURE [AddH03_Continent_Child]
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

/****** Object:  StoredProcedure [UpdateH03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH03_Continent_Child]
GO

CREATE PROCEDURE [UpdateH03_Continent_Child]
    @Continent_ID1 int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH03_Continent_Child]
GO

CREATE PROCEDURE [DeleteH03_Continent_Child]
    @Continent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H03_Continent_Child object as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID1

    END
GO
