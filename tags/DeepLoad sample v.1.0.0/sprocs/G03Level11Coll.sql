/****** Object:  StoredProcedure [GetG03Level11Coll] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG03Level11Coll]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG03Level11Coll]
GO

CREATE PROCEDURE [GetG03Level11Coll]
    @ParentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G04Level11 from table */
        SELECT
            [Level_1_1].[Level_1_1_ID],
            [Level_1_1].[Level_1_1_Name]
        FROM [Level_1_1]
        WHERE
            [Level_1_1].[ParentID1] = @ParentID1 AND
            [Level_1_1].[IsActive] = 'true'

    END
GO

