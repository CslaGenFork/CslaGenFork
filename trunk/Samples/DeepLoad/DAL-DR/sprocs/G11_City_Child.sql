/****** Object:  StoredProcedure [GetG11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG11_City_Child]
GO

CREATE PROCEDURE [GetG11_City_Child]
    @City_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1 AND
            [5_Cities_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG11_City_Child]
GO

CREATE PROCEDURE [AddG11_City_Child]
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

/****** Object:  StoredProcedure [UpdateG11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG11_City_Child]
GO

CREATE PROCEDURE [UpdateG11_City_Child]
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
            RAISERROR ('''G11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteG11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG11_City_Child]
GO

CREATE PROCEDURE [DeleteG11_City_Child]
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
            RAISERROR ('''G11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G11_City_Child object as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
