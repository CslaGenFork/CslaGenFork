/****** Object:  StoredProcedure [GetC11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC11Level111111ReChild]
GO

CREATE PROCEDURE [GetC11Level111111ReChild]
    @CQarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C11Level111111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = @CQarentID2

    END
GO

/****** Object:  StoredProcedure [AddC11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC11Level111111ReChild]
GO

CREATE PROCEDURE [AddC11Level111111ReChild]
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_1_1_ReChild */
        INSERT INTO [Level_1_1_1_1_1_1_ReChild]
        (
            [CQarentID2],
            [Level_1_1_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_1_1_ID,
            @Level_1_1_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateC11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC11Level111111ReChild]
GO

CREATE PROCEDURE [UpdateC11Level111111ReChild]
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CQarentID2] FROM [Level_1_1_1_1_1_1_ReChild]
            WHERE
                [CQarentID2] = @Level_1_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''C11Level111111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_1_1_ReChild */
        UPDATE [Level_1_1_1_1_1_1_ReChild]
        SET
            [Level_1_1_1_1_1_1_Child_Name] = @Level_1_1_1_1_1_1_Child_Name
        WHERE
            [CQarentID2] = @Level_1_1_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteC11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC11Level111111ReChild]
GO

CREATE PROCEDURE [DeleteC11Level111111ReChild]
    @Level_1_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CQarentID2] FROM [Level_1_1_1_1_1_1_ReChild]
            WHERE
                [CQarentID2] = @Level_1_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''C11Level111111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C11Level111111ReChild object from Level_1_1_1_1_1_1_ReChild */
        DELETE
        FROM [Level_1_1_1_1_1_1_ReChild]
        WHERE
            [CQarentID2] = @Level_1_1_1_1_1_ID

    END
GO
