/****** Object:  StoredProcedure [GetC07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC07_Country_ReChild]
GO

CREATE PROCEDURE [GetC07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2

    END
GO

/****** Object:  StoredProcedure [AddC07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC07_Country_ReChild]
GO

CREATE PROCEDURE [AddC07_Country_ReChild]
    @Country_ID2 int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_ReChild */
        INSERT INTO [3_Countries_ReChild]
        (
            [Country_ID2],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID2,
            @Country_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateC07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC07_Country_ReChild]
GO

CREATE PROCEDURE [UpdateC07_Country_ReChild]
    @Country_ID2 int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID2
        )
        BEGIN
            RAISERROR ('''C07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID2

    END
GO

/****** Object:  StoredProcedure [DeleteC07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC07_Country_ReChild]
GO

CREATE PROCEDURE [DeleteC07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID2
        )
        BEGIN
            RAISERROR ('''C07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C07_Country_ReChild object from 3_Countries_ReChild */
        DELETE
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2

    END
GO
