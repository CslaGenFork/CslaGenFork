/****** Object:  StoredProcedure [GetD01Level1Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD01Level1Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD01Level1Coll]
GO

CREATE PROCEDURE [GetD01Level1Coll]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D02Level1 from table */
        SELECT
            [Level_1].[Level_1_ID],
            [Level_1].[Level_1_Name]
        FROM [Level_1]

    END
GO

