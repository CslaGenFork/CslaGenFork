/****** Object:  StoredProcedure [GetC09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC09Level11111ReChild]
GO

CREATE PROCEDURE [GetC09Level11111ReChild]
    @CNarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C09Level11111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_1_ReChild].[CNarentID2] = @CNarentID2

    END
GO

/****** Object:  StoredProcedure [AddC09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC09Level11111ReChild]
GO

CREATE PROCEDURE [AddC09Level11111ReChild]
    @Level_1_1_1_1_ID int,
    @Level_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_1_ReChild */
        INSERT INTO [Level_1_1_1_1_1_ReChild]
        (
            [CNarentID2],
            [Level_1_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_1_ID,
            @Level_1_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateC09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC09Level11111ReChild]
GO

CREATE PROCEDURE [UpdateC09Level11111ReChild]
    @Level_1_1_1_1_ID int,
    @Level_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CNarentID2] FROM [Level_1_1_1_1_1_ReChild]
            WHERE
                [CNarentID2] = @Level_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''C09Level11111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_1_ReChild */
        UPDATE [Level_1_1_1_1_1_ReChild]
        SET
            [Level_1_1_1_1_1_Child_Name] = @Level_1_1_1_1_1_Child_Name
        WHERE
            [CNarentID2] = @Level_1_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteC09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC09Level11111ReChild]
GO

CREATE PROCEDURE [DeleteC09Level11111ReChild]
    @Level_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CNarentID2] FROM [Level_1_1_1_1_1_ReChild]
            WHERE
                [CNarentID2] = @Level_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''C09Level11111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C09Level11111ReChild object from Level_1_1_1_1_1_ReChild */
        DELETE
        FROM [Level_1_1_1_1_1_ReChild]
        WHERE
            [CNarentID2] = @Level_1_1_1_1_ID

    END
GO
