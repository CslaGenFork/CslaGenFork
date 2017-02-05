/****** Object:  StoredProcedure [GetDecisionTypeTagNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDecisionTypeTagNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDecisionTypeTagNVL]
GO

CREATE PROCEDURE [GetDecisionTypeTagNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DecisionTypeTagNVL from table */
        SELECT
            [DecisionTypeTags].[DecisionTypeID],
            [DecisionTypeTags].[DecisionTypeTag]
        FROM [DecisionTypeTags]
        WHERE
            [DecisionTypeTags].[IsActive] = 'true'

    END
GO

