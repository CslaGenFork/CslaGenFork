/****** Object:  StoredProcedure [GetC09Level11111Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC09Level11111Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC09Level11111Coll]
GO

CREATE PROCEDURE [GetC09Level11111Coll]
    @NarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C10Level11111 from table */
        SELECT
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1]
        WHERE
            [Level_1_1_1_1_1].[NarentID1] = @NarentID1

    END
GO

