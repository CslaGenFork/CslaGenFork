/****** Object:  StoredProcedure [GetUserInactiveNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetUserInactiveNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetUserInactiveNVL]
GO

CREATE PROCEDURE [GetUserInactiveNVL]
    @IsActive bit
AS
    BEGIN

        SET NOCOUNT ON

        /* Get UserInactiveNVL from table */
        SELECT
            [Users].[UserID],
            [Users].[Name]
        FROM [Users]
        WHERE
            [Users].[IsActive] = @IsActive

    END
GO

