/****** Object:  StoredProcedure [GetG11Level111111Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG11Level111111Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG11Level111111Coll]
GO

CREATE PROCEDURE [GetG11Level111111Coll]
    @QarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G12Level111111 from table */
        SELECT
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_ID],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1_1]
        WHERE
            [Level_1_1_1_1_1_1].[QarentID1] = @QarentID1 AND
            [Level_1_1_1_1_1_1].[IsActive] = 'true'

    END
GO

