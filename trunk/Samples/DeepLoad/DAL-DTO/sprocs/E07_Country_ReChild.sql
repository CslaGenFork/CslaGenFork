/****** Object:  StoredProcedure [AddE07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddE07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddE07_Country_ReChild]
GO

CREATE PROCEDURE [AddE07_Country_ReChild]
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

/****** Object:  StoredProcedure [UpdateE07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateE07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateE07_Country_ReChild]
GO

CREATE PROCEDURE [UpdateE07_Country_ReChild]
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
                [Country_ID2] = @Country_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteE07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteE07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteE07_Country_ReChild]
GO

CREATE PROCEDURE [DeleteE07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E07_Country_ReChild object as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2

    END
GO
