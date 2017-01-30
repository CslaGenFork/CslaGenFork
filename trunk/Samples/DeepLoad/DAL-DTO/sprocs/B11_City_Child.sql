/****** Object:  StoredProcedure [AddB11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB11_City_Child]
GO

CREATE PROCEDURE [AddB11_City_Child]
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

/****** Object:  StoredProcedure [UpdateB11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB11_City_Child]
GO

CREATE PROCEDURE [UpdateB11_City_Child]
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
            RAISERROR ('''B11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteB11_City_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB11_City_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB11_City_Child]
GO

CREATE PROCEDURE [DeleteB11_City_Child]
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
            RAISERROR ('''B11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B11_City_Child object from 5_Cities_Child */
        DELETE
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1

    END
GO
