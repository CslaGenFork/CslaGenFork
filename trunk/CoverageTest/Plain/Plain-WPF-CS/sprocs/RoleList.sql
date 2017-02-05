/****** Object:  StoredProcedure [GetRoleList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetRoleList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetRoleList]
GO

CREATE PROCEDURE [GetRoleList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get RoleInfo from table */
        SELECT
            [Roles].[RoleID],
            [Roles].[RoleName],
            [Roles].[IsActive]
        FROM [Roles]

    END
GO

