/****** Object:  StoredProcedure [GetH11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH11_City_ReChild]
GO

CREATE PROCEDURE [GetH11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2 AND
            [5_Cities_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH11_City_ReChild]
GO

CREATE PROCEDURE [AddH11_City_ReChild]
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

/****** Object:  StoredProcedure [UpdateH11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH11_City_ReChild]
GO

CREATE PROCEDURE [UpdateH11_City_ReChild]
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
                [City_ID2] = @City_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH11_City_ReChild]
GO

CREATE PROCEDURE [DeleteH11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H11_City_ReChild object as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2

    END
GO
