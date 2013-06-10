/****** Object:  StoredProcedure [GetC07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC07_Country_Child]
GO

CREATE PROCEDURE [GetC07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1

    END
GO

/****** Object:  StoredProcedure [AddC07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC07_Country_Child]
GO

CREATE PROCEDURE [AddC07_Country_Child]
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

/****** Object:  StoredProcedure [UpdateC07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC07_Country_Child]
GO

CREATE PROCEDURE [UpdateC07_Country_Child]
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
            RAISERROR ('''C07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteC07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC07_Country_Child]
GO

CREATE PROCEDURE [DeleteC07_Country_Child]
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
            RAISERROR ('''C07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C07_Country_Child object from 3_Countries_Child */
        DELETE
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1

    END
GO
