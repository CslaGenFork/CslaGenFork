/****** Object:  StoredProcedure [GetD07Level1111Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD07Level1111Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD07Level1111Coll]
GO

CREATE PROCEDURE [GetD07Level1111Coll]
    @LarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D08Level1111 from table */
        SELECT
            [Level_1_1_1_1].[Level_1_1_1_1_ID],
            [Level_1_1_1_1].[Level_1_1_1_1_Name]
        FROM [Level_1_1_1_1]
        WHERE
            [Level_1_1_1_1].[LarentID1] = @LarentID1

    END
GO

