/****** Object:  StoredProcedure [GetH05Level111Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH05Level111Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH05Level111Coll]
GO

CREATE PROCEDURE [GetH05Level111Coll]
    @MarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H06Level111 from table */
        SELECT
            [Level_1_1_1].[Level_1_1_1_ID],
            [Level_1_1_1].[Level_1_1_1_Name]
        FROM [Level_1_1_1]
        WHERE
            [Level_1_1_1].[MarentID1] = @MarentID1 AND
            [Level_1_1_1].[IsActive] = 'true'

    END
GO

