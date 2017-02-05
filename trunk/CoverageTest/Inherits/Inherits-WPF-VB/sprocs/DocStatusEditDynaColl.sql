/****** Object:  StoredProcedure [GetDocStatusEditDynaColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocStatusEditDynaColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocStatusEditDynaColl]
GO

CREATE PROCEDURE [GetDocStatusEditDynaColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocStatusEditDyna from table */
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

