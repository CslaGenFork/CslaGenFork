/****** Object:  StoredProcedure [GetB01Level1Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetB01Level1Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetB01Level1Coll]
GO

CREATE PROCEDURE [GetB01Level1Coll]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get B02Level1 from table */
        SELECT
            [Level_1].[Level_1_ID],
            [Level_1].[Level_1_Name]
        FROM [Level_1]

        /* Get B03Level11Child from table */
        SELECT
            [Level_1_1_Child].[CParentID1],
            [Level_1_1_Child].[Level_1_1_Child_Name]
        FROM [Level_1_1_Child]

        /* Get B03Level11ReChild from table */
        SELECT
            [Level_1_1_ReChild].[CParentID2],
            [Level_1_1_ReChild].[Level_1_1_Child_Name]
        FROM [Level_1_1_ReChild]

        /* Get B04Level11 from table */
        SELECT
            [Level_1_1].[ParentID1],
            [Level_1_1].[Level_1_1_ID],
            [Level_1_1].[Level_1_1_Name]
        FROM [Level_1_1]

        /* Get B05Level111ReChild from table */
        SELECT
            [Level_1_1_1_ReChild].[CMarentID2],
            [Level_1_1_1_ReChild].[Level_1_1_1_Child_Name]
        FROM [Level_1_1_1_ReChild]

        /* Get B05Level111Child from table */
        SELECT
            [Level_1_1_1_Child].[CMarentID1],
            [Level_1_1_1_Child].[Level_1_1_1_Child_Name]
        FROM [Level_1_1_1_Child]

        /* Get B06Level111 from table */
        SELECT
            [Level_1_1_1].[MarentID1],
            [Level_1_1_1].[Level_1_1_1_ID],
            [Level_1_1_1].[Level_1_1_1_Name]
        FROM [Level_1_1_1]

        /* Get B07Level1111Child from table */
        SELECT
            [Level_1_1_1_1_Child].[CLarentID1],
            [Level_1_1_1_1_Child].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_Child]

        /* Get B07Level1111ReChild from table */
        SELECT
            [Level_1_1_1_1_ReChild].[CLarentID2],
            [Level_1_1_1_1_ReChild].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_ReChild]

        /* Get B08Level1111 from table */
        SELECT
            [Level_1_1_1_1].[LarentID1],
            [Level_1_1_1_1].[Level_1_1_1_1_ID],
            [Level_1_1_1_1].[Level_1_1_1_1_Name]
        FROM [Level_1_1_1_1]

        /* Get B09Level11111Child from table */
        SELECT
            [Level_1_1_1_1_1_Child].[CNarentID1],
            [Level_1_1_1_1_1_Child].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_Child]

        /* Get B09Level11111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_ReChild].[CNarentID2],
            [Level_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_ReChild]

        /* Get B10Level11111 from table */
        SELECT
            [Level_1_1_1_1_1].[NarentID1],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1]

        /* Get B11Level111111Child from table */
        SELECT
            [Level_1_1_1_1_1_1_Child].[CQarentID1],
            [Level_1_1_1_1_1_1_Child].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_Child]

        /* Get B11Level111111ReChild from table */
        SELECT
            [Level_1_1_1_1_1_1_ReChild].[CQarentID2],
            [Level_1_1_1_1_1_1_ReChild].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_ReChild]

        /* Get B12Level111111 from table */
        SELECT
            [Level_1_1_1_1_1_1].[QarentID1],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_ID],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1_1]

    END
GO

