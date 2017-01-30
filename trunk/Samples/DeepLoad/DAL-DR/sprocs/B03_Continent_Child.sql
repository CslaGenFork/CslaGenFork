/****** Object:  StoredProcedure [AddB03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB03_Continent_Child]
GO

CREATE PROCEDURE [AddB03_Continent_Child]
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

/****** Object:  StoredProcedure [UpdateB03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB03_Continent_Child]
GO

CREATE PROCEDURE [UpdateB03_Continent_Child]
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
                [Continent_ID1] = @Continent_ID1
        )
        BEGIN
            RAISERROR ('''B03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteB03_Continent_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB03_Continent_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB03_Continent_Child]
GO

CREATE PROCEDURE [DeleteB03_Continent_Child]
    @Continent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID1
        )
        BEGIN
            RAISERROR ('''B03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B03_Continent_Child object from 1_Continents_Child */
        DELETE
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID1

    END
GO
