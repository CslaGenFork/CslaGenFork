/****** Object:  StoredProcedure [GetD11Level111111Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD11Level111111Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD11Level111111Coll]
GO

CREATE PROCEDURE [GetD11Level111111Coll]
    @QarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D12Level111111 from table */
        SELECT
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_ID],
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1_1]
        WHERE
            [Level_1_1_1_1_1_1].[QarentID1] = @QarentID1

    END
GO

