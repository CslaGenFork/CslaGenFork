/****** Object:  StoredProcedure [GetH07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH07_Country_ReChild]
GO

CREATE PROCEDURE [GetH07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2 AND
            [3_Countries_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH07_Country_ReChild]
GO

CREATE PROCEDURE [AddH07_Country_ReChild]
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

/****** Object:  StoredProcedure [UpdateH07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH07_Country_ReChild]
GO

CREATE PROCEDURE [UpdateH07_Country_ReChild]
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
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH07_Country_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH07_Country_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH07_Country_ReChild]
GO

CREATE PROCEDURE [DeleteH07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H07_Country_ReChild object as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
