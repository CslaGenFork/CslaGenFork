/****** Object:  StoredProcedure [GetUserNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetUserNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetUserNVL]
GO

CREATE PROCEDURE [GetUserNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get UserNVL from table */
        SELECT
            [Users].[UserID],
            [Users].[Name]
        FROM [Users]
        WHERE
            [Users].[IsActive] = 'true'

    END
GO

