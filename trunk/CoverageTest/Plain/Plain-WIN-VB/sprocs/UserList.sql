/****** Object:  StoredProcedure [GetUserList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetUserList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetUserList]
GO

CREATE PROCEDURE [GetUserList]
    @Name varchar(50) = NULL,
    @Login varchar(30) = NULL,
    @Email varchar(50) = NULL,
    @IsActive bit = NULL
AS
    BEGIN

        SET NOCOUNT ON

        /* Search Variables */
        IF (@Name <> '')
            SET @Name = @Name + '%'
        ELSE
            SET @Name = '%'
        IF (@Login <> '')
            SET @Login = @Login + '%'
        ELSE
            SET @Login = '%'
        IF (@Email <> '')
            SET @Email = @Email + '%'
        ELSE
            SET @Email = '%'

        /* Get UserInfo from table */
        SELECT
            [Users].[UserID],
            [Users].[Name],
            [Users].[Login],
            [Users].[Email],
            [Users].[IsActive]
        FROM [Users]
        WHERE
            ISNULL([Users].[Name], '') LIKE @Name AND
            ISNULL([Users].[Login], '') LIKE @Login AND
            ISNULL([Users].[Email], '') LIKE @Email AND
            [Users].[IsActive] = ISNULL(@IsActive, [Users].[IsActive])

    END
GO

