/****** Object:  StoredProcedure [GetD07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD07_Country_Child]
GO

CREATE PROCEDURE [GetD07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1

    END
GO

/****** Object:  StoredProcedure [AddD07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD07_Country_Child]
GO

CREATE PROCEDURE [AddD07_Country_Child]
    @Country_ID1 int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID1,
            @Country_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateD07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD07_Country_Child]
GO

CREATE PROCEDURE [UpdateD07_Country_Child]
    @Country_ID1 int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID1
        )
        BEGIN
            RAISERROR ('''D07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteD07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD07_Country_Child]
GO

CREATE PROCEDURE [DeleteD07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID1
        )
        BEGIN
            RAISERROR ('''D07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D07_Country_Child object from 3_Countries_Child */
        DELETE
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1

    END
GO
