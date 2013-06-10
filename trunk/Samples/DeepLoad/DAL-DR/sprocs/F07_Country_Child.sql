/****** Object:  StoredProcedure [AddF07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF07_Country_Child]
GO

CREATE PROCEDURE [AddF07_Country_Child]
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

/****** Object:  StoredProcedure [UpdateF07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF07_Country_Child]
GO

CREATE PROCEDURE [UpdateF07_Country_Child]
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
                [Country_ID1] = @Country_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteF07_Country_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF07_Country_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF07_Country_Child]
GO

CREATE PROCEDURE [DeleteF07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F07_Country_Child object as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1

    END
GO
