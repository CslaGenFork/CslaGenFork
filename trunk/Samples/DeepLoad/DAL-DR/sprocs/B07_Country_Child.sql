/****** Object:  StoredProcedure [AddB07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB07_Country_Child]
GO

CREATE PROCEDURE [AddB07_Country_Child]
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

/****** Object:  StoredProcedure [UpdateB07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB07_Country_Child]
GO

CREATE PROCEDURE [UpdateB07_Country_Child]
    @Country_ID1 int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID1
        )
        BEGIN
            RAISERROR ('''B07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteB07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB07_Country_Child]
GO

CREATE PROCEDURE [DeleteB07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID1
        )
        BEGIN
            RAISERROR ('''B07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B07_Country_Child object from 3_Countries_Child */
        DELETE
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1

    END
GO
