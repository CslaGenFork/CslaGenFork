/****** Object:  StoredProcedure [AddF09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF09Level11111ReChild]
GO

CREATE PROCEDURE [AddF09Level11111ReChild]
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

/****** Object:  StoredProcedure [UpdateF09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF09Level11111ReChild]
GO

CREATE PROCEDURE [UpdateF09Level11111ReChild]
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
            RAISERROR ('''F09Level11111ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteF09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF09Level11111ReChild]
GO

CREATE PROCEDURE [DeleteF09Level11111ReChild]
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
            RAISERROR ('''F09Level11111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F09Level11111ReChild object as not active */
        UPDATE [Level_1_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_1_1_ReChild].[CNarentID2] = @Level_1_1_1_1_ID

    END
GO
