/****** Object:  StoredProcedure [GetG07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG07Level1111Child]
GO

CREATE PROCEDURE [GetG07Level1111Child]
    @CLarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G07Level1111Child from table */
        SELECT
            [Level_1_1_1_1_Child].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_Child].[CLarentID1] = @CLarentID1 AND
            [Level_1_1_1_1_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG07Level1111Child]
GO

CREATE PROCEDURE [AddG07Level1111Child]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_Child */
        INSERT INTO [Level_1_1_1_1_Child]
        (
            [CLarentID1],
            [Level_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_ID,
            @Level_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateG07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG07Level1111Child]
GO

CREATE PROCEDURE [UpdateG07Level1111Child]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID1] FROM [Level_1_1_1_1_Child]
            WHERE
                [CLarentID1] = @Level_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07Level1111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_Child */
        UPDATE [Level_1_1_1_1_Child]
        SET
            [Level_1_1_1_1_Child_Name] = @Level_1_1_1_1_Child_Name
        WHERE
            [CLarentID1] = @Level_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteG07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG07Level1111Child]
GO

CREATE PROCEDURE [DeleteG07Level1111Child]
    @Level_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID1] FROM [Level_1_1_1_1_Child]
            WHERE
                [CLarentID1] = @Level_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07Level1111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G07Level1111Child object as not active */
        UPDATE [Level_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        WHERE
            [CLarentID1] = @Level_1_1_1_ID

    END
GO
