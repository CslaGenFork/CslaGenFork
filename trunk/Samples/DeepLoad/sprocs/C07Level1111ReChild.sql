/****** Object:  StoredProcedure [GetC07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC07Level1111ReChild]
GO

CREATE PROCEDURE [GetC07Level1111ReChild]
    @CLarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C07Level1111ReChild from table */
        SELECT
            [Level_1_1_1_1_ReChild].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_ReChild].[CLarentID2] = @CLarentID2

    END
GO

/****** Object:  StoredProcedure [AddC07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC07Level1111ReChild]
GO

CREATE PROCEDURE [AddC07Level1111ReChild]
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

/****** Object:  StoredProcedure [UpdateC07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC07Level1111ReChild]
GO

CREATE PROCEDURE [UpdateC07Level1111ReChild]
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
                [CLarentID2] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''C07Level1111ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteC07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC07Level1111ReChild]
GO

CREATE PROCEDURE [DeleteC07Level1111ReChild]
    @Level_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID2] FROM [Level_1_1_1_1_ReChild]
            WHERE
                [CLarentID2] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''C07Level1111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C07Level1111ReChild object from Level_1_1_1_1_ReChild */
        DELETE
        FROM [Level_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_ReChild].[CLarentID2] = @Level_1_1_1_ID

    END
GO
