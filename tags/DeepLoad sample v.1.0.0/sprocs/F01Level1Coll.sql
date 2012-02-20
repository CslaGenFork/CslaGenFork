/****** Object:  StoredProcedure [GetF01Level1Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetF01Level1Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetF01Level1Coll]
GO

CREATE PROCEDURE [GetF01Level1Coll]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get F02Level1 from table */
        SELECT
            [Level_1].[Level_1_ID],
            [Level_1].[Level_1_Name]
        FROM [Level_1]
        WHERE
            [Level_1].[IsActive] = 'true'

        /* Get F03Level11Child from table */
        SELECT
            [Level_1_1_Child].[CParentID1],
            [Level_1_1_Child].[Level_1_1_Child_Name]
        FROM [Level_1_1_Child]
        WHERE
            [Level_1_1_Child].[IsActive] = 'true'

        /* Get F03Level11ReChild from table */
        SELECT
            [Level_1_1_ReChild].[CParentID2],
            [Level_1_1_ReChild].[Level_1_1_Child_Name]
        FROM [Level_1_1_ReChild]
        WHERE
            [Level_1_1_ReChild].[IsActive] = 'true'

        /* Get F04Level11 from table */
        SELECT
            [Level_1_1].[ParentID1],
            [Level_1_1].[Level_1_1_ID],
            [Level_1_1].[Level_1_1_Name]
        FROM [Level_1_1]
        WHERE
            [Level_1_1].[IsActive] = 'true'

        /* Get F05Level111ReChild from table */
        SELECT
            [Level_1_1_1_ReChild].[CMarentID2],
            [Level_1_1_1_ReChild].[Level_1_1_1_Child_Name]
        FROM [Level_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_ReChild].[IsActive] = 'true'

        /* Get F05Level111Child from table */
        SELECT
            [Level_1_1_1_Child].[CMarentID1],
            [Level_1_1_1_Child].[Level_1_1_1_Child_Name]
        FROM [Level_1_1_1_Child]
        WHERE
            [Level_1_1_1_Child].[IsActive] = 'true'

        /* Get F06Level111 from table */
        SELECT
            [Level_1_1_1].[MarentID1],
            [Level_1_1_1].[Level_1_1_1_ID],
            [Level_1_1_1].[Level_1_1_1_Name]
        FROM [Level_1_1_1]
        WHERE
            [Level_1_1_1].[IsActive] = 'true'

        /* Get F07Level1111Child from table */
        SELECT
            [Level_1_1_1_1_Child].[CLarentID1],
            [Level_1_1_1_1_Child].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_Child].[IsActive] = 'true'

        /* Get F07Level1111ReChild from table */
        SELECT
            [Level_1_1_1_1_ReChild].[CLarentID2],
            [Level_1_1_1_1_ReChild].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_ReChild].[IsActive] = 'true'

        /* Get F08Level1111 from table */
        SELECT
            [Level_1_1_1_1].[LarentID1],
            [Level_1_1_1_1].[Level_1_1_1_1_ID],
            [Level_1_1_1_1].[Level_1_1_1_1_Name]
        FROM [Level_1_1_1_1]
        WHERE
            [Level_1_1_1_1].[IsActive] = 'true'

        /* Get F09Level11111Child from table */
        SELECT
            [Level_1_1_1_1_1_Child].[CNarentID1],
            [Level_1_1_1_1_1_Child].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_1_Child].[IsActive] = 'true'

        /* Get F09Level11111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_ReChild].[CNarentID2],
            [Level_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_1_ReChild].[IsActive] = 'true'

        /* Get F10Level11111 from table */
        SELECT
            [Level_1_1_1_1_1].[NarentID1],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1]
        WHERE
            [Level_1_1_1_1_1].[IsActive] = 'true'

        /* Get F11Level111111Child from table */
        SELECT
            [Level_1_1_1_1_1_1_Child].[CQarentID1],
            [Level_1_1_1_1_1_1_Child].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_1_1_Child].[IsActive] = 'true'

        /* Get F11Level111111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_1_ReChild].[CQarentID2],
            [Level_1_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_1_1_1_ReChild].[IsActive] = 'true'

        /* Get F12Level111111 from table */
        SELECT
            [Level_1_1_1_1_1_1].[QarentID1],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_ID],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1_1]
        WHERE
            [Level_1_1_1_1_1_1].[IsActive] = 'true'

    END
GO

