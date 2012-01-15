/****** Object:  StoredProcedure [GetA02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetA02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetA02Level1]
GO

CREATE PROCEDURE [GetA02Level1]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get A02Level1 from table */
        SELECT
            [Level_1].[Level_1_ID],
            [Level_1].[Level_1_Name]
        FROM [Level_1]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A03Level11Child from table */
        SELECT
            [Level_1_1_Child].[Level_1_1_Child_Name]
        FROM [Level_1_1_Child]
            INNER JOIN [Level_1] ON [Level_1_1_Child].[CParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A03Level11ReChild from table */
        SELECT
            [Level_1_1_ReChild].[Level_1_1_Child_Name]
        FROM [Level_1_1_ReChild]
            INNER JOIN [Level_1] ON [Level_1_1_ReChild].[CParentID2] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A04Level11 from table */
        SELECT
            [Level_1_1].[Level_1_1_ID],
            [Level_1_1].[Level_1_1_Name]
        FROM [Level_1_1]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A05Level111Child from table */
        SELECT
            [Level_1_1_1_Child].[CMarentID1],
            [Level_1_1_1_Child].[Level_1_1_1_Child_Name],
            [Level_1_1_1_Child].[RowVersion]
        FROM [Level_1_1_1_Child]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_Child].[CMarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A05Level111ReChild from table */
        SELECT
            [Level_1_1_1_ReChild].[CMarentID2],
            [Level_1_1_1_ReChild].[Level_1_1_1_Child_Name],
            [Level_1_1_1_ReChild].[RowVersion]
        FROM [Level_1_1_1_ReChild]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_ReChild].[CMarentID2] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A06Level111 from table */
        SELECT
            [Level_1_1_1].[MarentID1],
            [Level_1_1_1].[Level_1_1_1_ID],
            [Level_1_1_1].[Level_1_1_1_Name],
            [Level_1_1_1].[RowVersion]
        FROM [Level_1_1_1]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A07Level1111Child from table */
        SELECT
            [Level_1_1_1_1_Child].[CLarentID1],
            [Level_1_1_1_1_Child].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_Child].[CLarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A07Level1111ReChild from table */
        SELECT
            [Level_1_1_1_1_ReChild].[CLarentID2],
            [Level_1_1_1_1_ReChild].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_ReChild].[CLarentID2] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A08Level1111 from table */
        SELECT
            [Level_1_1_1_1].[LarentID1],
            [Level_1_1_1_1].[Level_1_1_1_1_ID],
            [Level_1_1_1_1].[Level_1_1_1_1_Name]
        FROM [Level_1_1_1_1]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A09Level11111Child from table */
        SELECT
            [Level_1_1_1_1_1_Child].[CNarentID1],
            [Level_1_1_1_1_1_Child].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_Child].[CNarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A09Level11111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_ReChild].[CNarentID2],
            [Level_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_ReChild].[CNarentID2] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A10Level11111 from table */
        SELECT
            [Level_1_1_1_1_1].[NarentID1],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A11Level111111Child from table */
        SELECT
            [Level_1_1_1_1_1_1_Child].[CQarentID1],
            [Level_1_1_1_1_1_1_Child].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_Child].[CQarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A11Level111111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_1_ReChild].[CQarentID2],
            [Level_1_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Get A12Level111111 from table */
        SELECT
            [Level_1_1_1_1_1_1].[QarentID1],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_ID],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1].[QarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

    END
GO

/****** Object:  StoredProcedure [AddA02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddA02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddA02Level1]
GO

CREATE PROCEDURE [AddA02Level1]
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

/****** Object:  StoredProcedure [UpdateA02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateA02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateA02Level1]
GO

CREATE PROCEDURE [UpdateA02Level1]
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
            RAISERROR ('''A02Level1'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteA02Level1] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteA02Level1]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteA02Level1]
GO

CREATE PROCEDURE [DeleteA02Level1]
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
            RAISERROR ('''A02Level1'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child A12Level111111 from Level_1_1_1_1_1_1 */
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

        /* Delete child A11Level111111ReChild from Level_1_1_1_1_1_1_ReChild */
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

        /* Delete child A11Level111111Child from Level_1_1_1_1_1_1_Child */
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

        /* Delete child A10Level11111 from Level_1_1_1_1_1 */
        DELETE
            [Level_1_1_1_1_1]
        FROM [Level_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1].[NarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A09Level11111ReChild from Level_1_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_ReChild].[CNarentID2] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A09Level11111Child from Level_1_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_1_Child]
        FROM [Level_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1] ON [Level_1_1_1_1_1_Child].[CNarentID1] = [Level_1_1_1_1].[Level_1_1_1_1_ID]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A08Level1111 from Level_1_1_1_1 */
        DELETE
            [Level_1_1_1_1]
        FROM [Level_1_1_1_1]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1].[LarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A07Level1111ReChild from Level_1_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_1_ReChild]
        FROM [Level_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_ReChild].[CLarentID2] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A07Level1111Child from Level_1_1_1_1_Child */
        DELETE
            [Level_1_1_1_1_Child]
        FROM [Level_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1] ON [Level_1_1_1_1_Child].[CLarentID1] = [Level_1_1_1].[Level_1_1_1_ID]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A06Level111 from Level_1_1_1 */
        DELETE
            [Level_1_1_1]
        FROM [Level_1_1_1]
            INNER JOIN [Level_1_1] ON [Level_1_1_1].[MarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A05Level111ReChild from Level_1_1_1_ReChild */
        DELETE
            [Level_1_1_1_ReChild]
        FROM [Level_1_1_1_ReChild]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_ReChild].[CMarentID2] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A05Level111Child from Level_1_1_1_Child */
        DELETE
            [Level_1_1_1_Child]
        FROM [Level_1_1_1_Child]
            INNER JOIN [Level_1_1] ON [Level_1_1_1_Child].[CMarentID1] = [Level_1_1].[Level_1_1_ID]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A04Level11 from Level_1_1 */
        DELETE
            [Level_1_1]
        FROM [Level_1_1]
            INNER JOIN [Level_1] ON [Level_1_1].[ParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A03Level11ReChild from Level_1_1_ReChild */
        DELETE
            [Level_1_1_ReChild]
        FROM [Level_1_1_ReChild]
            INNER JOIN [Level_1] ON [Level_1_1_ReChild].[CParentID2] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete child A03Level11Child from Level_1_1_Child */
        DELETE
            [Level_1_1_Child]
        FROM [Level_1_1_Child]
            INNER JOIN [Level_1] ON [Level_1_1_Child].[CParentID1] = [Level_1].[Level_1_ID]
        WHERE
            [Level_1].[Level_1_ID] = @Level_1_ID

        /* Delete A02Level1 object from Level_1 */
        DELETE
        FROM [Level_1]
        WHERE
            [Level_1_ID] = @Level_1_ID

    END
GO
