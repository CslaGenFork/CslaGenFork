/****** Object:  StoredProcedure [GetC11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC11_City_Child]
GO

CREATE PROCEDURE [GetC11_City_Child]
    @City_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1

    END
GO

/****** Object:  StoredProcedure [AddC11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC11_City_Child]
GO

CREATE PROCEDURE [AddC11_City_Child]
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

/****** Object:  StoredProcedure [UpdateC11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC11_City_Child]
GO

CREATE PROCEDURE [UpdateC11_City_Child]
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
            RAISERROR ('''C11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteC11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC11_City_Child]
GO

CREATE PROCEDURE [DeleteC11_City_Child]
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
            RAISERROR ('''C11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C11_City_Child object from 5_Cities_Child */
        DELETE
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1

    END
GO
