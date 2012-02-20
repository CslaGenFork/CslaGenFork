/****** Object:  StoredProcedure [GetG09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG09Level11111ReChild]
GO

CREATE PROCEDURE [GetG09Level11111ReChild]
    @CNarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G09Level11111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_1_ReChild].[CNarentID2] = @CNarentID2 AND
            [Level_1_1_1_1_1_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG09Level11111ReChild]
GO

CREATE PROCEDURE [AddG09Level11111ReChild]
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

/****** Object:  StoredProcedure [UpdateG09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG09Level11111ReChild]
GO

CREATE PROCEDURE [UpdateG09Level11111ReChild]
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
            RAISERROR ('''G09Level11111ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteG09Level11111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG09Level11111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG09Level11111ReChild]
GO

CREATE PROCEDURE [DeleteG09Level11111ReChild]
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
            RAISERROR ('''G09Level11111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G09Level11111ReChild object as not active */
        UPDATE [Level_1_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_1_1_ReChild].[CNarentID2] = @Level_1_1_1_1_ID

    END
GO
