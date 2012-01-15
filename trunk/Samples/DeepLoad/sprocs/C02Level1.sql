/****** Object:  StoredProcedure [GetC02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC02Level1]
GO

CREATE PROCEDURE [GetC02Level1]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C02Level1 from table */
        SELECT
            [Level_1].[Level_1_ID],
            [Level_1].[Level_1_Name]
        FROM [Level_1]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

    END
GO

/****** Object:  StoredProcedure [AddC02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC02Level1]
GO

CREATE PROCEDURE [AddC02Level1]
    @Level_1_ID int OUTPUT,
    @Level_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1 */
        INSERT INTO [Level_1]
        (
            [Level_1_Name]
        )
        VALUES
        (
            @Level_1_Name
        )

        /* Return new primary key */
        SET @Level_1_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateC02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC02Level1]
GO

CREATE PROCEDURE [UpdateC02Level1]
    @Level_1_ID int,
    @Level_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_ID] FROM [Level_1]
            WHERE
                [Level_1_ID] = @Level_1_ID
        )
        BEGIN
            RAISERROR ('''C02Level1'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1 */
        UPDATE [Level_1]
        SET
            [Level_1_Name] = @Level_1_Name
        WHERE
            [Level_1_ID] = @Level_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteC02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC02Level1]
GO

CREATE PROCEDURE [DeleteC02Level1]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_ID] FROM [Level_1]
            WHERE
                [Level_1_ID] = @Level_1_ID
        )
        BEGIN
            RAISERROR ('''C02Level1'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child C12Level111111 from Level_1_1_1_1_1_1 */
        DELETE
            [Level_1_1_1_1_1_1]
        FROM [Level_1_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1].[QarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C11Level111111ReChild from Level_1_1_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C11Level111111Child from Level_1_1_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_1_1_Child]
        FROM [Level_1_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_Child].[CQarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C10Level11111 from Level_1_1_1_1_1 */
        DELETE
            [Level_1_1_1_1_1]
        FROM [Level_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C09Level11111ReChild from Level_1_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_ReChild].[CNarentID2] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C09Level11111Child from Level_1_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_1_Child]
        FROM [Level_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_Child].[CNarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C08Level1111 from Level_1_1_1_1 */
        DELETE
            [Level_1_1_1_1]
        FROM [Level_1_1_1_1]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C07Level1111ReChild from Level_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_ReChild].[CLarentID2] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C07Level1111Child from Level_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_Child]
        FROM [Level_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_Child].[CLarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C06Level111 from Level_1_1_1 */
        DELETE
            [Level_1_1_1]
        FROM [Level_1_1_1]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C05Level111ReChild from Level_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_ReChild]
        FROM [Level_1_1_1_ReChild]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_ReChild].[CMarentID2] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C05Level111Child from Level_1_1_1_Child */
        DELETE
            [Level_1_1_1_Child]
        FROM [Level_1_1_1_Child]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_Child].[CMarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C04Level11 from Level_1_1 */
        DELETE
            [Level_1_1]
        FROM [Level_1_1]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C03Level11ReChild from Level_1_1_ReChild */
        DELETE
            [Level_1_1_ReChild]
        FROM [Level_1_1_ReChild]
            INNER JOIN [Level_1] ON [Level_1_1_ReChild].[CParentID2] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child C03Level11Child from Level_1_1_Child */
        DELETE
            [Level_1_1_Child]
        FROM [Level_1_1_Child]
            INNER JOIN [Level_1] ON [Level_1_1_Child].[CParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete C02Level1 object from Level_1 */
        DELETE
        FROM [Level_1]
        WHERE
            [Level_1_ID] = @Level_1_ID

    END
GO
