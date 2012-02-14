/****** Object:  StoredProcedure [AddB08Level1111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB08Level1111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB08Level1111]
GO

CREATE PROCEDURE [AddB08Level1111]
    @Level_1_1_1_1_ID int OUTPUT,
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1 */
        INSERT INTO [Level_1_1_1_1]
        (
            [LarentID1],
            [Level_1_1_1_1_Name]
        )
        VALUES
        (
            @Level_1_1_1_ID,
            @Level_1_1_1_1_Name
        )

        /* Return new primary key */
        SET @Level_1_1_1_1_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateB08Level1111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB08Level1111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB08Level1111]
GO

CREATE PROCEDURE [UpdateB08Level1111]
    @Level_1_1_1_1_ID int,
    @Level_1_1_1_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_1_ID] FROM [Level_1_1_1_1]
            WHERE
                [Level_1_1_1_1_ID] = @Level_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''B08Level1111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1 */
        UPDATE [Level_1_1_1_1]
        SET
            [Level_1_1_1_1_Name] = @Level_1_1_1_1_Name
        WHERE
            [Level_1_1_1_1_ID] = @Level_1_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteB08Level1111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB08Level1111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB08Level1111]
GO

CREATE PROCEDURE [DeleteB08Level1111]
    @Level_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_1_ID] FROM [Level_1_1_1_1]
            WHERE
                [Level_1_1_1_1_ID] = @Level_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''B08Level1111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child B12Level111111 from Level_1_1_1_1_1_1 */
        DELETE
            [Level_1_1_1_1_1_1]
        FROM [Level_1_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1].[QarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
        WHERE
            [Level_1_1_1_1].[Level_1_1_1_1_ID] = @Level_1_1_1_1_ID

        /* Delete child B11Level111111ReChild from Level_1_1_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
        WHERE
            [Level_1_1_1_1].[Level_1_1_1_1_ID] = @Level_1_1_1_1_ID

        /* Delete child B11Level111111Child from Level_1_1_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_1_1_Child]
        FROM [Level_1_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_Child].[CQarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
        WHERE
            [Level_1_1_1_1].[Level_1_1_1_1_ID] = @Level_1_1_1_1_ID

        /* Delete child B10Level11111 from Level_1_1_1_1_1 */
        DELETE
            [Level_1_1_1_1_1]
        FROM [Level_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
        WHERE
            [Level_1_1_1_1].[Level_1_1_1_1_ID] = @Level_1_1_1_1_ID

        /* Delete child B09Level11111ReChild from Level_1_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_ReChild].[CNarentID2] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
        WHERE
            [Level_1_1_1_1].[Level_1_1_1_1_ID] = @Level_1_1_1_1_ID

        /* Delete child B09Level11111Child from Level_1_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_1_Child]
        FROM [Level_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_Child].[CNarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
        WHERE
            [Level_1_1_1_1].[Level_1_1_1_1_ID] = @Level_1_1_1_1_ID

        /* Delete B08Level1111 object from Level_1_1_1_1 */
        DELETE
        FROM [Level_1_1_1_1]
        WHERE
            [Level_1_1_1_1].[Level_1_1_1_1_ID] = @Level_1_1_1_1_ID

    END
GO
