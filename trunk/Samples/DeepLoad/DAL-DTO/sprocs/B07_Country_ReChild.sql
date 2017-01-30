/****** Object:  StoredProcedure [AddB07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB07_Country_ReChild]
GO

CREATE PROCEDURE [AddB07_Country_ReChild]
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

/****** Object:  StoredProcedure [UpdateB07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB07_Country_ReChild]
GO

CREATE PROCEDURE [UpdateB07_Country_ReChild]
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
            RAISERROR ('''B07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteB07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB07_Country_ReChild]
GO

CREATE PROCEDURE [DeleteB07_Country_ReChild]
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
            RAISERROR ('''B07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B07_Country_ReChild object from 3_Countries_ReChild */
        DELETE
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2

    END
GO
