/****** Object:  StoredProcedure [AddB11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB11_City_ReChild]
GO

CREATE PROCEDURE [AddB11_City_ReChild]
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

/****** Object:  StoredProcedure [UpdateB11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB11_City_ReChild]
GO

CREATE PROCEDURE [UpdateB11_City_ReChild]
    @City_ID2 int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID2
        )
        BEGIN
            RAISERROR ('''B11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteB11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB11_City_ReChild]
GO

CREATE PROCEDURE [DeleteB11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID2
        )
        BEGIN
            RAISERROR ('''B11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B11_City_ReChild object from 5_Cities_ReChild */
        DELETE
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2

    END
GO
