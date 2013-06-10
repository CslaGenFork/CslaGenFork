/****** Object:  StoredProcedure [GetC11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC11_City_ReChild]
GO

CREATE PROCEDURE [GetC11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2

    END
GO

/****** Object:  StoredProcedure [AddC11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC11_City_ReChild]
GO

CREATE PROCEDURE [AddC11_City_ReChild]
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

/****** Object:  StoredProcedure [UpdateC11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC11_City_ReChild]
GO

CREATE PROCEDURE [UpdateC11_City_ReChild]
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
                [City_ID2] = @City_ID2
        )
        BEGIN
            RAISERROR ('''C11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteC11_City_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC11_City_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC11_City_ReChild]
GO

CREATE PROCEDURE [DeleteC11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID2
        )
        BEGIN
            RAISERROR ('''C11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C11_City_ReChild object from 5_Cities_ReChild */
        DELETE
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2

    END
GO
