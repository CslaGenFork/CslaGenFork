/****** Object:  StoredProcedure [AddF11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF11_City_ReChild]
GO

CREATE PROCEDURE [AddF11_City_ReChild]
    @City_ID2 int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_ReChild */
        INSERT INTO [5_Cities_ReChild]
        (
            [City_ID2],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID2,
            @City_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateF11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF11_City_ReChild]
GO

CREATE PROCEDURE [UpdateF11_City_ReChild]
    @City_ID2 int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_ReChild */
        UPDATE [5_Cities_ReChild]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID2] = @City_ID2

    END
GO

/****** Object:  StoredProcedure [DeleteF11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF11_City_ReChild]
GO

CREATE PROCEDURE [DeleteF11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F11_City_ReChild object as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2

    END
GO
