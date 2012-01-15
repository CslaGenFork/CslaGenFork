/****** Object:  StoredProcedure [GetC09Level11111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC09Level11111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC09Level11111Child]
GO

CREATE PROCEDURE [GetC09Level11111Child]
    @CNarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C09Level11111Child from table */
        SELECT
            [Level_1_1_1_1_1_Child].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_1_Child].[CNarentID1] = @CNarentID1

    END
GO

/****** Object:  StoredProcedure [AddC09Level11111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC09Level11111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC09Level11111Child]
GO

CREATE PROCEDURE [AddC09Level11111Child]
    @Level_1_1_1_1_ID int,
    @Level_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_1_Child */
        INSERT INTO [Level_1_1_1_1_1_Child]
        (
            [CNarentID1],
            [Level_1_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_1_ID,
            @Level_1_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateC09Level11111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC09Level11111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC09Level11111Child]
GO

CREATE PROCEDURE [UpdateC09Level11111Child]
    @Level_1_1_1_1_ID int,
    @Level_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CNarentID1] FROM [Level_1_1_1_1_1_Child]
            WHERE
                [CNarentID1] = @Level_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''C09Level11111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_1_Child */
        UPDATE [Level_1_1_1_1_1_Child]
        SET
            [Level_1_1_1_1_1_Child_Name] = @Level_1_1_1_1_1_Child_Name
        WHERE
            [CNarentID1] = @Level_1_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteC09Level11111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC09Level11111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC09Level11111Child]
GO

CREATE PROCEDURE [DeleteC09Level11111Child]
    @Level_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CNarentID1] FROM [Level_1_1_1_1_1_Child]
            WHERE
                [CNarentID1] = @Level_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''C09Level11111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C09Level11111Child object from Level_1_1_1_1_1_Child */
        DELETE
        FROM [Level_1_1_1_1_1_Child]
        WHERE
            [CNarentID1] = @Level_1_1_1_1_ID

    END
GO
