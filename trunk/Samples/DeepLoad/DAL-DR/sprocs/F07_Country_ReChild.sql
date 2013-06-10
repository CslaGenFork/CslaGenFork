/****** Object:  StoredProcedure [AddF07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF07_Country_ReChild]
GO

CREATE PROCEDURE [AddF07_Country_ReChild]
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

/****** Object:  StoredProcedure [UpdateF07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF07_Country_ReChild]
GO

CREATE PROCEDURE [UpdateF07_Country_ReChild]
    @Country_ID2 int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteF07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF07_Country_ReChild]
GO

CREATE PROCEDURE [DeleteF07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F07_Country_ReChild object as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2

    END
GO
