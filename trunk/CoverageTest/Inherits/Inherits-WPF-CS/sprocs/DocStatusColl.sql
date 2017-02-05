/****** Object:  StoredProcedure [GetDocStatusColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocStatusColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocStatusColl]
GO

CREATE PROCEDURE [GetDocStatusColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocStatus from table */
        SELECT
            [DocStatus].[DocStatusID],
            [DocStatus].[DocStatusName],
            [DocStatus].[CreateDate],
            [DocStatus].[CreateUserID],
            [DocStatus].[ChangeDate],
            [DocStatus].[ChangeUserID],
            [DocStatus].[RowVersion]
        FROM [DocStatus]
        WHERE
            [DocStatus].[IsActive] = 'true'

    END
GO

