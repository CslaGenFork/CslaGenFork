/****** Object:  StoredProcedure [GetUserAllNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetUserAllNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetUserAllNVL]
GO

CREATE PROCEDURE [GetUserAllNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get UserAllNVL from table */
        SELECT
            [Users].[UserID],
            [Users].[Name],
            [Users].[IsActive]
        FROM [Users]

    END
GO

