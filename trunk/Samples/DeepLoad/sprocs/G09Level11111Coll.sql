/****** Object:  StoredProcedure [GetG09Level11111Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG09Level11111Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG09Level11111Coll]
GO

CREATE PROCEDURE [GetG09Level11111Coll]
    @NarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G10Level11111 from table */
        SELECT
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID],
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_Name]
        FROM [Level_1_1_1_1_1]
        WHERE
            [Level_1_1_1_1_1].[NarentID1] = @NarentID1 AND
            [Level_1_1_1_1_1].[IsActive] = 'true'

    END
GO

