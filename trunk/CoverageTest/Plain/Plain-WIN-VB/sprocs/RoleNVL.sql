/****** Object:  StoredProcedure [GetRoleNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetRoleNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetRoleNVL]
GO

CREATE PROCEDURE [GetRoleNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get RoleNVL from table */
        SELECT
            [Roles].[RoleID],
            [Roles].[RoleName]
        FROM [Roles]
        WHERE
            [Roles].[IsActive] = 'true'

    END
GO

