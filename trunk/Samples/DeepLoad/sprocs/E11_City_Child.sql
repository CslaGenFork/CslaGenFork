/****** Object:  StoredProcedure [AddE11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddE11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddE11_City_Child]
GO

CREATE PROCEDURE [AddE11_City_Child]
    @City_ID1 int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_Child */
        INSERT INTO [5_Cities_Child]
        (
            [City_ID1],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID1,
            @City_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateE11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateE11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateE11_City_Child]
GO

CREATE PROCEDURE [UpdateE11_City_Child]
    @City_ID1 int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteE11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteE11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteE11_City_Child]
GO

CREATE PROCEDURE [DeleteE11_City_Child]
    @City_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E11_City_Child object as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1

    END
GO
