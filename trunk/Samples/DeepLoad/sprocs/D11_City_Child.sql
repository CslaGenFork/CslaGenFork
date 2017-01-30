/****** Object:  StoredProcedure [GetD11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD11_City_Child]
GO

CREATE PROCEDURE [GetD11_City_Child]
    @City_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1

    END
GO

/****** Object:  StoredProcedure [AddD11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD11_City_Child]
GO

CREATE PROCEDURE [AddD11_City_Child]
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

/****** Object:  StoredProcedure [UpdateD11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD11_City_Child]
GO

CREATE PROCEDURE [UpdateD11_City_Child]
    @City_ID1 int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID1
        )
        BEGIN
            RAISERROR ('''D11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteD11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD11_City_Child]
GO

CREATE PROCEDURE [DeleteD11_City_Child]
    @City_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID1
        )
        BEGIN
            RAISERROR ('''D11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D11_City_Child object from 5_Cities_Child */
        DELETE
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1

    END
GO
