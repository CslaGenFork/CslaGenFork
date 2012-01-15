/****** Object:  StoredProcedure [GetD11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD11Level111111ReChild]
GO

CREATE PROCEDURE [GetD11Level111111ReChild]
    @CQarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D11Level111111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = @CQarentID2

    END
GO

/****** Object:  StoredProcedure [AddD11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD11Level111111ReChild]
GO

CREATE PROCEDURE [AddD11Level111111ReChild]
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

/****** Object:  StoredProcedure [UpdateD11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD11Level111111ReChild]
GO

CREATE PROCEDURE [UpdateD11Level111111ReChild]
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
            RAISERROR ('''D11Level111111ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteD11Level111111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD11Level111111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD11Level111111ReChild]
GO

CREATE PROCEDURE [DeleteD11Level111111ReChild]
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
            RAISERROR ('''D11Level111111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D11Level111111ReChild object from Level_1_1_1_1_1_1_ReChild */
        DELETE
        FROM [Level_1_1_1_1_1_1_ReChild]
        WHERE
            [CQarentID2] = @Level_1_1_1_1_1_ID

    END
GO
