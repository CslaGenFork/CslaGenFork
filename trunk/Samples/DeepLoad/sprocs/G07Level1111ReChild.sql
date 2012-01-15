/****** Object:  StoredProcedure [GetG07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG07Level1111ReChild]
GO

CREATE PROCEDURE [GetG07Level1111ReChild]
    @CLarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G07Level1111ReChild from table */
        SELECT
            [Level_1_1_1_1_ReChild].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_ReChild].[CLarentID2] = @CLarentID2 AND
            [Level_1_1_1_1_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG07Level1111ReChild]
GO

CREATE PROCEDURE [AddG07Level1111ReChild]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_ReChild */
        INSERT INTO [Level_1_1_1_1_ReChild]
        (
            [CLarentID2],
            [Level_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_ID,
            @Level_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateG07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG07Level1111ReChild]
GO

CREATE PROCEDURE [UpdateG07Level1111ReChild]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID2] FROM [Level_1_1_1_1_ReChild]
            WHERE
                [CLarentID2] = @Level_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07Level1111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_ReChild */
        UPDATE [Level_1_1_1_1_ReChild]
        SET
            [Level_1_1_1_1_Child_Name] = @Level_1_1_1_1_Child_Name
        WHERE
            [CLarentID2] = @Level_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteG07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG07Level1111ReChild]
GO

CREATE PROCEDURE [DeleteG07Level1111ReChild]
    @Level_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID2] FROM [Level_1_1_1_1_ReChild]
            WHERE
                [CLarentID2] = @Level_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07Level1111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G07Level1111ReChild object as not active */
        UPDATE [Level_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [CLarentID2] = @Level_1_1_1_ID

    END
GO
