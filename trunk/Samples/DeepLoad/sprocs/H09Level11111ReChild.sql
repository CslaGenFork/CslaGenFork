/****** Object:  StoredProcedure [GetH09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH09Level11111ReChild]
GO

CREATE PROCEDURE [GetH09Level11111ReChild]
    @CNarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H09Level11111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_1_ReChild].[CNarentID2] = @CNarentID2 AND
            [Level_1_1_1_1_1_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH09Level11111ReChild]
GO

CREATE PROCEDURE [AddH09Level11111ReChild]
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

/****** Object:  StoredProcedure [UpdateH09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH09Level11111ReChild]
GO

CREATE PROCEDURE [UpdateH09Level11111ReChild]
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
                [CNarentID2] = @Level_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H09Level11111ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH09Level11111ReChild]
GO

CREATE PROCEDURE [DeleteH09Level11111ReChild]
    @Level_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CNarentID2] FROM [Level_1_1_1_1_1_ReChild]
            WHERE
                [CNarentID2] = @Level_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H09Level11111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H09Level11111ReChild object as not active */
        UPDATE [Level_1_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_1_1_ReChild].[CNarentID2] = @Level_1_1_1_1_ID

    END
GO
