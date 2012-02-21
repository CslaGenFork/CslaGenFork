/****** Object:  StoredProcedure [GetD07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD07_Country_ReChild]
GO

CREATE PROCEDURE [GetD07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2

    END
GO

/****** Object:  StoredProcedure [AddD07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD07_Country_ReChild]
GO

CREATE PROCEDURE [AddD07_Country_ReChild]
    @Country_ID int,
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
            @Country_ID,
            @Country_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateD07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD07_Country_ReChild]
GO

CREATE PROCEDURE [UpdateD07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''D07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID

    END
GO

/****** Object:  StoredProcedure [DeleteD07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD07_Country_ReChild]
GO

CREATE PROCEDURE [DeleteD07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''D07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D07_Country_ReChild object from 3_Countries_ReChild */
        DELETE
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
