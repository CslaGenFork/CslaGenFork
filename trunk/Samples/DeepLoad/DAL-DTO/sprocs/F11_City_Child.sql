/****** Object:  StoredProcedure [AddF11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF11_City_Child]
GO

CREATE PROCEDURE [AddF11_City_Child]
    @City_ID int,
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
            @City_ID,
            @City_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateF11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF11_City_Child]
GO

CREATE PROCEDURE [UpdateF11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID

    END
GO

/****** Object:  StoredProcedure [DeleteF11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF11_City_Child]
GO

CREATE PROCEDURE [DeleteF11_City_Child]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F11_City_Child object as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
