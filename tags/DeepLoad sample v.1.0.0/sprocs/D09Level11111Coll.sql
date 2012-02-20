/****** Object:  StoredProcedure [GetD09Level11111Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD09Level11111Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD09Level11111Coll]
GO

CREATE PROCEDURE [GetD09Level11111Coll]
    @NarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D10Level11111 from table */
        SELECT
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1]
        WHERE
            [Level_1_1_1_1_1].[NarentID1] = @NarentID1

    END
GO

