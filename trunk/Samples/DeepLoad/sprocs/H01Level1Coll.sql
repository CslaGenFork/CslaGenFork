/****** Object:  StoredProcedure [GetH01Level1Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH01Level1Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH01Level1Coll]
GO

CREATE PROCEDURE [GetH01Level1Coll]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H02Level1 from table */
        SELECT
            [Level_1].[Level_1_ID],
            [Level_1].[Level_1_Name]
        FROM [Level_1]
        WHERE
            [Level_1].[IsActive] = 'true'

    END
GO

